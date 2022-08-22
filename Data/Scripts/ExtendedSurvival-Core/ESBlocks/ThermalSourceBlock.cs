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

        public const string PRODUCTION_KEY = "24703B2B-F7EE-4C00-8340-6A6334E70EB2";
        public const string FINALPRODUCTION_KEY = "1EDEB0E3-69C9-4D44-AA86-3E04C1CAEC86";
        public const string DEPTH_KEY = "BC9E2338-E17E-4C60-90CB-212ABEB0235B";
        public const string OTHERSOURCES_KEY = "9CFDE365-9D34-48FC-A404-2FD389D958A7";

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
                sb.AppendLine(string.Format("Depth={0}", GetValue(DEPTH_KEY)));
                sb.AppendLine(string.Format("Other Sources={0}", GetValue(OTHERSOURCES_KEY)));
                sb.AppendLine(string.Format("Production={0}", GetValue(PRODUCTION_KEY)));
                sb.AppendLine(string.Format("Final Production={0}", GetValue(FINALPRODUCTION_KEY)));
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
                definition.InputConstraint.Add(ItensConstants.ICE_ID.DefinitionId);
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
            if (method == "StoreInfoToClient")
            {
                foreach (var item in extraParams.extraParams)
                {
                    StoreValue(item.id, item.data);
                }
            }
        }

        private void StoreInfoToClient(float production, float finalProduction, float depth, int otherSources)
        {
            StoreValue(PRODUCTION_KEY, production.ToString());
            StoreValue(FINALPRODUCTION_KEY, finalProduction.ToString());
            StoreValue(DEPTH_KEY, depth.ToString());
            StoreValue(OTHERSOURCES_KEY, otherSources.ToString());
        }

        protected void SendStoreInfoToClient()
        {
            if (IsServer)
            {
                StoreInfoToClient(Production, FinalProduction, depth, otherSourcesInRange);
                SendCallServer("StoreInfoToClient", new Dictionary<string, string>() {
                    { PRODUCTION_KEY, Production.ToString() },
                    { FINALPRODUCTION_KEY, FinalProduction.ToString() },
                    { DEPTH_KEY, depth.ToString() },
                    { OTHERSOURCES_KEY, otherSourcesInRange.ToString() }
                });
            }
        }

    }

}
