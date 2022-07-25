using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;

namespace ExtendedSurvival
{

    public abstract class BaseIntegrationModRecipesOverride : BaseModIntegrationOverride
    {

        private static readonly Dictionary<string, List<SerializableDefinitionId>> BlockVariantGroups = new Dictionary<string, List<SerializableDefinitionId>>();

        public static void ApplyAllBlockVariantGroups()
        {
            foreach (var key in BlockVariantGroups.Keys)
            {
                try
                {
                    var group = DefinitionUtils.GetBlockVariantGroup(key);
                    if (group != null)
                    {
                        var builder = group.GetObjectBuilder() as MyObjectBuilder_BlockVariantGroup;
                        builder.Blocks = BlockVariantGroups[key].Distinct().ToArray();
                        group.Init(builder, group.Context);
                        group.ResolveBlocks();
                        group.Postprocess();
                    }
                    else
                        ExtendedSurvivalLogging.Instance.LogInfo(typeof(BaseIntegrationModRecipesOverride), $"Override BlockVariantGroup not found. ID=[{key}]");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalLogging.Instance.LogWarning(typeof(BaseIntegrationModRecipesOverride), $"Override BlockVariantGroup error. ID=[{key}]");
                    ExtendedSurvivalLogging.Instance.LogError(typeof(BaseIntegrationModRecipesOverride), ex);
                }
            }            
        }

        public struct ComponentCost
        {

            public string subtype;
            public int count;
            public bool critical;
            public string deconstructId;

            public ComponentCost(string subtype, int count, bool critical = false, string deconstructId = null)
            {
                this.subtype = subtype;
                this.count = count;
                this.critical = critical;
                this.deconstructId = deconstructId;
            }
            
        }

        public class ComponentInfo
        {

            public int integrity;
            public string bluePrintName;
            public Dictionary<UniqueEntityId, float> bluePrintCost = new Dictionary<UniqueEntityId, float>();
            public List<string> targetBlueprintClasses = new List<string>();

            public ComponentInfo(int integrity, string bluePrintName)
            {
                this.integrity = integrity;
                this.bluePrintName = bluePrintName;
            }

        }

        protected static int GetCostMultiplier(float value, float multiplier)
        {
            return Math.Max((int)(value * multiplier), 1);
        }

        protected virtual List<string> GetComponents() { return new List<string>(); }
        protected virtual ComponentInfo GetComponentInfo(string item) { return null; }

        protected abstract List<UniqueEntityId> GetBlocks();
        protected abstract List<ComponentCost> GetBlockCost(UniqueEntityId item);

        protected override void OnSetDefinitions()
        {
            foreach (var block in GetBlocks())
            {
                var blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(block.DefinitionId);
                if (blockDefinition != null)
                    SetComponents(blockDefinition, block);
                else
                    ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"Override block not found. ID=[{block}]");
            }
            foreach (var component in GetComponents())
            {
                var compInfo = GetComponentInfo(component);
                if (compInfo != null)
                {
                    var compBuilder = new MyObjectBuilder_Component { SubtypeName = component };
                    var compDef = MyDefinitionManager.Static.GetComponentDefinition(compBuilder.GetObjectId());
                    if (compDef != null)
                        SetComponentInfo(compDef, compInfo, component);
                    else
                        ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"Override component not found. ID=[{component}]");
                }
                else
                    ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"Override component no info found. ID=[{component}]");
            }
        }

        protected void RemoveBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            var lista = ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)).ToList();
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups[name].RemoveAll(x => lista.Contains(x));
        }

        protected void AppendBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups[name].AddRange(ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)));
            else
                RebuildBlockVariantGroup(name, ids);
        }

        protected void RebuildBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups.Remove(name);
            var lista = ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)).ToList();
            BlockVariantGroups.Add(name, lista);
        }

        protected void RemoveBlockVariantGroup(string name)
        {
            var group = DefinitionUtils.GetBlockVariantGroup(name);
            if (group != null)
                group.Enabled = false;
        }

        private void SetComponentInfo(MyComponentDefinition compDef, ComponentInfo compInfo, string component)
        {
            compDef.MaxIntegrity = compInfo.integrity;
            var definitionID = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), compInfo.bluePrintName);
            var blueprint = MyDefinitionManager.Static.GetBlueprintDefinition(definitionID);
            if (blueprint != null)
            {
                var newBlueprint = new List<MyBlueprintDefinitionBase.Item>();
                foreach (var item in compInfo.bluePrintCost)
                {
                    var newItem = new MyBlueprintDefinitionBase.Item
                    {
                        Amount = (MyFixedPoint)item.Value,
                        Id = item.Key.DefinitionId
                    };
                    newBlueprint.Add(newItem);
                }
                blueprint.Prerequisites = newBlueprint.ToArray();
                foreach (var targetBlueprintClass in compInfo.targetBlueprintClasses)
                {
                    AddBluePrintToClass(targetBlueprintClass, compInfo.bluePrintName);
                }
            }
            else
                ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"Override component no blueprint found. ID=[{component}] BP=[{compInfo.bluePrintName}]");
        }

        protected virtual void OnAfterSetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {

        }

        protected MyComponentDefinition GetComponentDefinition(string subtype)
        {
            if (string.IsNullOrEmpty(subtype))
                return null;
            var compBuilder = new MyObjectBuilder_Component { SubtypeName = subtype };
            return MyDefinitionManager.Static.GetComponentDefinition(compBuilder.GetObjectId());
        }

        private void SetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {
            var newCompsList = GetBlockCost(block);
            if (newCompsList.Count > 0)
            {
                var mass = 0f;
                var maxIntegrity = 0;
                var criticalRatio = 0f;
                var ownershipRatio = 0f;
                var newComps = new List<MyCubeBlockDefinition.Component>();
                foreach (var item in newCompsList)
                {
                    var compDef = GetComponentDefinition(item.subtype);
                    var deconstructDef = GetComponentDefinition(item.deconstructId);
                    var newComp = new MyCubeBlockDefinition.Component
                    {
                        Definition = compDef,
                        Count = item.count,
                        DeconstructItem = deconstructDef != null ? deconstructDef : compDef
                    };
                    newComps.Add(newComp);
                    mass += newComp.Definition.Mass * newComp.Count;
                    ownershipRatio = item.subtype.Equals("Computer") ? maxIntegrity : ownershipRatio;
                    maxIntegrity += newComp.Definition.MaxIntegrity * newComp.Count;
                    criticalRatio = item.critical ? maxIntegrity : criticalRatio;
                }
                blockDefinition.Mass = mass;
                blockDefinition.MaxIntegrity = maxIntegrity;
                blockDefinition.Components = newComps.ToArray();
                blockDefinition.CriticalIntegrityRatio = criticalRatio / maxIntegrity;
                blockDefinition.OwnershipIntegrityRatio = ownershipRatio / maxIntegrity;
            }
            else
                ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"Override block no components to set. ID=[{block}]");
            OnAfterSetComponents(blockDefinition, block);
        }

    }

}