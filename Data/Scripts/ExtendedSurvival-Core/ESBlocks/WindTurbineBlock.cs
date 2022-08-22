using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using SpaceEngineers.Game.Entities.Blocks;
using System.Collections.Generic;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_WindTurbine), false, "LargeBlockWindTurbine", "LargeBlockWindTurbineStackable")]
    public class WindTurbineBlock : BaseLogicComponent<IMyPowerProducer>
    {

        private int maxModules;
        private List<IMyUpgradeModule> connectedModules = new List<IMyUpgradeModule>();

        protected MyResourceSourceComponent _sourceComp;
        protected MyResourceSourceComponent SourceComp
        {
            get
            {
                if (_sourceComp == null)
                    _sourceComp = CurrentEntity.Components.Get<MyResourceSourceComponent>();
                return _sourceComp;
            }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            maxModules = CurrentEntity.BlockDefinition.SubtypeId == "LargeBlockWindTurbineStackable" ? 2 : 1;
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            if (IsServer)
            {
                SourceComp.SetMaxOutput(GetMaxPowerOutput());
            }
        }

        public void AddNewModule(IMyUpgradeModule module)
        {
            if (connectedModules.Count < maxModules)
            {
                connectedModules.Add(module);
            }
        }

        public void RemoveAllModules()
        {
            connectedModules.Clear();
        }

        protected float GetMaxPowerOutput()
        {
            var baseValue = (BlockDefinition as MyWindTurbineDefinition).MaxPowerOutput;
            foreach (var item in connectedModules)
            {
                var definition = DefinitionUtils.TryGetDefinition<MyUpgradeModuleDefinition>(item.BlockDefinition);
                if (definition != null && definition.Upgrades.Length > 0)
                    baseValue *= definition.Upgrades[0].Modifier;
            }
            return baseValue;
        }

    }

}
