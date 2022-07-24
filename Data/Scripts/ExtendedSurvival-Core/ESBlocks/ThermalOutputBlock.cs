using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), false, "ThermalOutput")]
    public class ThermalOutputBlock : BaseLogicComponent<IMyCargoContainer>
    {

        public const float MAX_DEAPH_DISTANCE = 2.5f;
        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 2.587f;

        public const string CANPRODUCE_KEY = "A65DD1A9-3F2B-42D4-9505-F93A1F2D76A7";
        public const string DEPTH_KEY = "BF06D221-FCCB-420E-9631-1A5B944E870F";
        public const string SERVEROUTPUT_KEY = "BE5504B8-70B9-4516-8F90-88445E941E9B";
        public const string CURRENTOUTPUT_KEY = "68F3EF00-354A-40EE-8A10-634F69B63F4F";

        public bool IsInStatic
        {
            get
            {
                return CurrentEntity.CubeGrid.IsStatic;
            }
        }

        public bool CanProduce
        {
            get
            {
                return IsInStatic && Grid != null && depth <= MAX_DEAPH_DISTANCE;
            }
        }

        protected bool HasPlanetAtRange
        {
            get
            {
                return planetAtRange != null && planetAtRange.Setting != null && planetAtRange.Setting.Geothermal.Enabled;
            }
        }

        protected float depth = 0;
        protected PlanetEntity planetAtRange = null;
        private MyResourceSourceComponent m_sourceComp;

        public MyResourceSourceComponent SourceComp
        {
            get { return m_sourceComp; }
            set { if (CurrentEntity.Components.Contains(typeof(MyResourceSourceComponent))) CurrentEntity.Components.Remove<MyResourceSourceComponent>(); CurrentEntity.Components.Add<MyResourceSourceComponent>(value); m_sourceComp = value; }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            SourceComp = new MyResourceSourceComponent(1);
            SourceComp.Init(
                MyStringHash.Get("Reactors"),
                new MyResourceSourceInfo
                {
                    ResourceTypeId = ItensConstants.THERMALGAS_ID.DefinitionId,
                    DefinedOutput = 0,
                    ProductionToCapacityMultiplier = 1
                }
            );
            SourceComp.Enabled = true;
            if (IsServer)
            {
                SourceComp.OutputChanged += SourceComp_OutputChanged;
                NeedsUpdate = VRage.ModAPI.MyEntityUpdateEnum.EACH_100TH_FRAME;
            }
        }

        protected override void OnAppendingCustomInfo(StringBuilder sb)
        {
            sb.AppendLine(string.Format("Is in Station={0}", IsInStatic));
            if (IsInStatic)
            {
                sb.AppendLine(string.Format("Depth={0}", GetValue(DEPTH_KEY)));
                sb.AppendLine(string.Format("Can Produce={0}", GetValue(CANPRODUCE_KEY)));
                sb.AppendLine(string.Format("Max Output={0}", GetValue(SERVEROUTPUT_KEY)));
                sb.AppendLine(string.Format("Current Output={0}", GetValue(CURRENTOUTPUT_KEY)));
            }
        }

        protected Vector3D position = Vector3D.Zero;
        private MyInventory _inventory;
        protected bool _initilized = false;
        private bool _inventoryDefined = false;
        protected float output;

        protected void DoInitialize()
        {
            if (!_initilized)
            {
                if (Grid != null)
                    Grid.RegisterThermalOutput(this);
                _initilized = true;
            }
        }

        private void SourceComp_OutputChanged(VRage.Game.MyDefinitionId changedResourceId, float oldOutput, MyResourceSourceComponent source)
        {

        }

        protected void CheckDetector()
        {
            if (planetAtRange == null && Grid != null)
            {
                planetAtRange = Grid.PlanetAtRange;
                if (planetAtRange != null)
                {
                    position = CurrentEntity.GetPosition();
                    if (planetAtRange.Entity.IsUnderGround(position))
                    {
                        depth = (float)Vector3D.Distance(planetAtRange.Entity.GetClosestSurfacePointGlobal(position), position);
                    }
                    else
                    {
                        depth = 0;
                    }
                }
            }
        }

        protected void ClearDetector()
        {
            planetAtRange = null;
            position = Vector3D.Zero;
            depth = 0;
            output = 0;
        }

        protected int cicleCount = 0;
        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            if (!_inventoryDefined)
            {
                _inventory = (MyInventory)CurrentEntity.GetInventory(0);
                var definition = new MyInventoryComponentDefinition
                {
                    RemoveEntityOnEmpty = false,
                    MultiplierEnabled = false,
                    MaxItemCount = int.MaxValue,
                    Mass = MAS_MASS,
                    Volume = MAS_VOLUME,
                    InputConstraint = new MyInventoryConstraint("ThermalOutputInventory", null, true)
                };
                definition.InputConstraint.Add(ItensConstants.ICE_ID.DefinitionId);
                _inventory.Init(definition);
                _inventoryDefined = true;
            }
            if (IsServer)
            {
                DoInitialize();
                if (IsInStatic)
                {
                    cicleCount++;
                    CheckDetector();
                    if (CanProduce)
                    {
                        output = Grid.GetMaxThermalOutput(CurrentEntity.EntityId);
                        SourceComp.SetMaxOutputByType(ItensConstants.THERMALGAS_ID.DefinitionId, output);
                        SourceComp.SetRemainingCapacityByType(ItensConstants.THERMALGAS_ID.DefinitionId, output * 10);
                    }
                    if (cicleCount > 10)
                    {
                        if (!CanProduce)
                            Grid.CheckThermalConnections();
                        cicleCount = 0;
                    }
                }
                else
                {
                    ClearDetector();
                    SourceComp.SetMaxOutputByType(ItensConstants.THERMALGAS_ID.DefinitionId, 0);
                    SourceComp.SetRemainingCapacityByType(ItensConstants.THERMALGAS_ID.DefinitionId, 0);
                }
                SendStoreInfoToClient();
            }
        }

        public override void CallFromServer(string method, CommandExtraParams extraParams)
        {
            base.CallFromServer(method, extraParams);
            if (method == "StoreInfoToClient")
            {
                foreach (var item in extraParams.extraParams)
                {
                    StoreValue(item.id, item.data);
                }
            }
        }

        private void StoreInfoToClient(bool canProduce, float depth, float output, float current)
        {
            StoreValue(CANPRODUCE_KEY, CanProduce.ToString());
            StoreValue(DEPTH_KEY, depth.ToString());
            StoreValue(SERVEROUTPUT_KEY, output.ToString());
            StoreValue(CURRENTOUTPUT_KEY, current.ToString());
        }

        protected void SendStoreInfoToClient()
        {
            if (IsServer)
            {
                StoreInfoToClient(CanProduce, depth, output, SourceComp.CurrentOutput);
                SendCallServer("StoreInfoToClient", new Dictionary<string, string>() {
                    { CANPRODUCE_KEY, CanProduce.ToString() },
                    { DEPTH_KEY, depth.ToString() },
                    { SERVEROUTPUT_KEY, output.ToString() },
                    { CURRENTOUTPUT_KEY, SourceComp.CurrentOutput.ToString() }
                });
            }
        }

    }

}
