using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), false, "ThermalSource")]
    public class ThermalSourceBlock : BaseLogicComponent<IMyCargoContainer>
    {

        public const float INTERFERENCE_DISTANCE = 100;
        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 2.587f;

        public bool IsInStatic
        {
            get
            {
                return CurrentEntity.CubeGrid.IsStatic;
            }
        }

        public float Production { get; private set; } = 0;

        public float FinalProduction
        {
            get
            {
                if (otherSourcesInRange > 0)
                    return Production / (1 + otherSourcesInRange);
                return Production;
            }
        }

        protected bool HasPlanetAtRange
        {
            get
            {
                return planetAtRange != null && planetAtRange.Setting != null && planetAtRange.Setting.Geothermal.Enabled;
            }
        }

        protected Vector3D position = Vector3D.Zero;
        protected float depth = 0;
        protected int otherSourcesInRange = 0;
        protected PlanetEntity planetAtRange = null;

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                NeedsUpdate = VRage.ModAPI.MyEntityUpdateEnum.EACH_100TH_FRAME;
            }
        }

        protected override void OnAppendingCustomInfo(StringBuilder sb)
        {
            sb.AppendLine(string.Format("Is in Station={0}", IsInStatic));
            if (IsInStatic)
            {
                sb.AppendLine(string.Format("Depth={0}", DEPTH));
                sb.AppendLine(string.Format("Other Sources={0}", OTHERSOURCES));
                sb.AppendLine(string.Format("Production={0}", PRODUCTION));
                sb.AppendLine(string.Format("Final Production={0}", FINALPRODUCTION));
            }
        }

        private MyInventory _inventory;
        protected bool _initilized = false;
        private bool _inventoryDefined = false;
        protected void DoInitialize()
        {
            if (!_initilized)
            {               
                if (Grid != null)
                    Grid.RegisterThermalSource(this);
                _initilized = true;
            }
        }

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
                    InputConstraint = new MyInventoryConstraint("ThermalSourceInventory", null, true)
                };
                definition.InputConstraint.Add(OreConstants.ICE_ID.DefinitionId);
                _inventory.Init(definition);
                _inventoryDefined = true;
            }
            if (MyAPIGateway.Session.IsServer)
            {
                DoInitialize();
                if (IsInStatic)
                {
                    CheckDetector();
                    CheckThermalSources();
                }
                else
                    ClearDetector();
                SendStoreInfoToClient();
            }
        }

        protected void CheckThermalSources()
        {
            if (planetAtRange != null && Grid != null)
            {
                var allSources = Grid.ThermalSources;
                otherSourcesInRange = allSources.Where(x => x.FatBlock != null && x.FatBlock.EntityId != CurrentEntity.EntityId && Vector3D.Distance(x.FatBlock.GetPosition(), position) <= INTERFERENCE_DISTANCE).Count();
            }
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
                    if (HasPlanetAtRange && depth >= planetAtRange.Setting.Geothermal.Start)
                    {
                        var bonusDepth = depth - planetAtRange.Setting.Geothermal.Start;
                        var bonus = (int)(bonusDepth / planetAtRange.Setting.Geothermal.RowSize);
                        Production = planetAtRange.Setting.Geothermal.Power + (planetAtRange.Setting.Geothermal.Increment * bonus);
                        Production = Math.Min(Production, planetAtRange.Setting.Geothermal.MaxPower);
                    }
                }
            }
        }

        protected void ClearDetector()
        {
            planetAtRange = null;
            depth = 0;
            position = Vector3D.Zero;
            Production = 0;
        }

        public override void CallFromServer(string method, CommandExtraParams extraParams)
        {
            base.CallFromServer(method, extraParams);
            try
            {
                if (method == "StoreInfoToClient")
                {
                    float production = float.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == PRODUCTION_KEY).data);
                    float finalProduction = float.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == FINALPRODUCTION_KEY).data);
                    float depth = float.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == DEPTH_KEY).data);
                    int otherSources = int.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == OTHERSOURCES_KEY).data);
                    StoreInfoToClient(production, finalProduction, depth, otherSources);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private float PRODUCTION;
        private float FINALPRODUCTION;
        private float DEPTH;
        private int OTHERSOURCES;

        private const string PRODUCTION_KEY = "PRODUCTION";
        private const string FINALPRODUCTION_KEY = "FINALPRODUCTION";
        private const string DEPTH_KEY = "DEPTH";
        private const string OTHERSOURCES_KEY = "OTHERSOURCES";

        private void StoreInfoToClient(float production, float finalProduction, float depth, int otherSources)
        {
            PRODUCTION = production;
            FINALPRODUCTION = finalProduction;
            DEPTH = depth;
            OTHERSOURCES = otherSources;
        }

        protected void SendStoreInfoToClient()
        {
            if (IsServer)
            {
                StoreInfoToClient(Production, FinalProduction, depth, otherSourcesInRange);
                SendCallServer(new ulong[] { }, "StoreInfoToClient", new Dictionary<string, string>() {
                    { PRODUCTION_KEY, Production.ToString() },
                    { FINALPRODUCTION_KEY, FinalProduction.ToString() },
                    { DEPTH_KEY, depth.ToString() },
                    { OTHERSOURCES_KEY, otherSourcesInRange.ToString() }
                });
            }
        }

    }

}
