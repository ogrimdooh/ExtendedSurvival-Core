using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage;
using VRage.Game;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public abstract class BaseIntegrationOverride
    {

        public abstract void SetDefinitions();

        private readonly MyObjectBuilderType[] FRACTIONAL_TYPES = new MyObjectBuilderType[] { typeof(MyObjectBuilder_Ore), typeof(MyObjectBuilder_Ingot) };

        protected void CopyBlueprintFormulaAsResult(string from, string to, float multiplier, bool clearBeforeCopy, UniqueEntityId[] ignoreIds, Dictionary<UniqueEntityId, UniqueEntityId> replaceIds)
        {
            var fromId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), from);
            var fromBp = MyDefinitionManager.Static.GetBlueprintDefinition(fromId);
            if (fromBp != null)
            {
                var toId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), to);
                var toBp = MyDefinitionManager.Static.GetBlueprintDefinition(toId);
                if (toBp != null)
                {
                    var newResults = new List<MyBlueprintDefinitionBase.Item>();
                    if (!clearBeforeCopy)
                    {
                        newResults.AddRange(toBp.Results);
                    }
                    foreach (var item in fromBp.Prerequisites)
                    {
                        var newId = new UniqueEntityId(item.Id);
                        if (ignoreIds != null && ignoreIds.Contains(newId))
                            continue;
                        if (replaceIds != null && replaceIds.ContainsKey(newId))
                            newId = replaceIds[newId];
                        var allowFrac = FRACTIONAL_TYPES.Contains(newId.typeId);
                        var newAmount = item.Amount * multiplier;
                        if (!allowFrac)
                            newAmount = Math.Max((int)newAmount, 1);
                        var newItem = new MyBlueprintDefinitionBase.Item
                        {
                            Amount = newAmount,
                            Id = newId.DefinitionId
                        };
                        newResults.Add(newItem);
                    }
                    toBp.Results = newResults.ToArray();
                }
                else
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {to} blue print.");
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {from} blue print.");
        }

        protected void CopyBlueprintFormula(string from, string to, float multiplier, bool clearBeforeCopy, UniqueEntityId[] ignoreIds)
        {
            var fromId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), from);
            var fromBp = MyDefinitionManager.Static.GetBlueprintDefinition(fromId);
            if (fromBp != null)
            {
                var toId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), to);
                var toBp = MyDefinitionManager.Static.GetBlueprintDefinition(toId);
                if (toBp != null)
                {
                    var newBlueprint = new List<MyBlueprintDefinitionBase.Item>();
                    if (!clearBeforeCopy)
                    {
                        newBlueprint.AddRange(toBp.Prerequisites);
                    }
                    foreach (var item in fromBp.Prerequisites)
                    {
                        if (ignoreIds != null && ignoreIds.Contains(new UniqueEntityId(item.Id)))
                            continue;
                        var allowFrac = FRACTIONAL_TYPES.Contains(item.Id.TypeId);
                        var newAmount = item.Amount * multiplier;
                        if (!allowFrac)
                            newAmount = Math.Max((int)newAmount, 1);
                        var newItem = new MyBlueprintDefinitionBase.Item
                        {
                            Amount = newAmount,
                            Id = item.Id
                        };
                        newBlueprint.Add(newItem);
                    }
                    toBp.Prerequisites = newBlueprint.ToArray();
                }
                else
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {to} blue print.");
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {from} blue print.");
        }

        public struct FormulaItem
        {

            public UniqueEntityId Id;
            public float Ammount;

            public FormulaItem(UniqueEntityId id, float ammount)
            {
                Id = id;
                Ammount = ammount;
            }

        }

        protected void SetBlueprintFormula(string name, bool clearBeforeAdd, params FormulaItem[] items)
        {
            var fromId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), name);
            var fromBp = MyDefinitionManager.Static.GetBlueprintDefinition(fromId);
            if (fromBp != null)
            {
                var newBlueprint = new List<MyBlueprintDefinitionBase.Item>();
                if (!clearBeforeAdd)
                {
                    newBlueprint.AddRange(fromBp.Prerequisites);
                }
                foreach (var item in items)
                {
                    var allowFrac = FRACTIONAL_TYPES.Contains(item.Id.typeId);
                    var newAmount = item.Ammount;
                    if (!allowFrac)
                        newAmount = Math.Max((int)newAmount, 1);
                    var newItem = new MyBlueprintDefinitionBase.Item
                    {
                        Amount = (MyFixedPoint)newAmount,
                        Id = item.Id.DefinitionId
                    };
                    newBlueprint.Add(newItem);
                }
                fromBp.Prerequisites = newBlueprint.ToArray();
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {name} blue print.");
        }

        protected void AddBluePrintToClass(string className, params string[] blueprints)
        {
            AddBluePrintToClass(className, false, blueprints);
        }

        protected void AddBluePrintToClass(string className, bool clearBeforeSet, params string[] blueprints)
        {
            MyBlueprintClassDefinition components = MyDefinitionManager.Static.GetBlueprintClass(className);
            if (components != null)
            {
                if (clearBeforeSet)
                    components.ClearBlueprints();
                foreach (var item in blueprints)
                {
                    var definitionID = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), item);
                    var blueprint = MyDefinitionManager.Static.GetBlueprintDefinition(definitionID);
                    if (blueprint != null)
                    {
                        if (!components.ContainsBlueprint(blueprint))
                            components.AddBlueprint(blueprint);
                    }
                    else
                        ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {item} blue print.");
                }
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override not found {className} blue print class.");
        }

        protected void RemoveBluePrintFromClass(string classname, params string[] removedComponents)
        {
            MyBlueprintClassDefinition assemblerComponents = MyDefinitionManager.Static.GetBlueprintClass(classname);
            if (assemblerComponents != null)
            {
                var simpleComponents_Sorted = new List<MyBlueprintDefinitionBase>();
                foreach (MyBlueprintDefinitionBase blueprint in assemblerComponents)
                {
                    if (blueprint != null)
                        if (!removedComponents.Contains(blueprint.Id.SubtypeName))
                            simpleComponents_Sorted.Add(blueprint);
                }
                assemblerComponents.ClearBlueprints();
                foreach (MyBlueprintDefinitionBase blueprint in simpleComponents_Sorted)
                {
                    if (blueprint != null)
                        assemblerComponents.AddBlueprint(blueprint);
                }
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override block not found {classname} blue print class.");
        }

    }

}