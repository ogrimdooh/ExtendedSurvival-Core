using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    public static class PhysicalItemDefinitionOverride
    {

        public static readonly ConcurrentDictionary<UniqueEntityId, MyAssemblerDefinition> ASSEMBLERS = new ConcurrentDictionary<UniqueEntityId, MyAssemblerDefinition>();
        public static readonly ConcurrentDictionary<UniqueEntityId, MyRefineryDefinition> REFINERIES = new ConcurrentDictionary<UniqueEntityId, MyRefineryDefinition>();
        public static readonly ConcurrentDictionary<UniqueEntityId, MyOxygenGeneratorDefinition> GASGENERATOR = new ConcurrentDictionary<UniqueEntityId, MyOxygenGeneratorDefinition>();

        public static readonly ConcurrentDictionary<UniqueEntityId, List<MyBlueprintDefinitionBase>> BLUEPRINTS = new ConcurrentDictionary<UniqueEntityId, List<MyBlueprintDefinitionBase>>();

        private static bool IsLoaded = false;

        private static void DoLoad()
        {
            if (!IsLoaded)
            {
                var assemblers = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Id.TypeId == typeof(MyObjectBuilder_Assembler) || x.Id.TypeId == typeof(MyObjectBuilder_SurvivalKit)).Cast<MyAssemblerDefinition>().ToList();
                foreach (var assembler in assemblers)
                {
                    ASSEMBLERS[new UniqueEntityId(assembler.Id)] = assembler;
                    BLUEPRINTS[new UniqueEntityId(assembler.Id)] = new List<MyBlueprintDefinitionBase>();
                    foreach (var blueprintClass in assembler.BlueprintClasses)
                    {
                        BLUEPRINTS[new UniqueEntityId(assembler.Id)].AddRange(blueprintClass);
                    }
                }
                var refineries = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Id.TypeId == typeof(MyObjectBuilder_Refinery)).Cast<MyRefineryDefinition>().ToList();
                foreach (var refinery in refineries)
                {
                    REFINERIES[new UniqueEntityId(refinery.Id)] = refinery;
                    BLUEPRINTS[new UniqueEntityId(refinery.Id)] = new List<MyBlueprintDefinitionBase>();
                    foreach (var blueprintClass in refinery.BlueprintClasses)
                    {
                        BLUEPRINTS[new UniqueEntityId(refinery.Id)].AddRange(blueprintClass);
                    }
                }
                var gasGenerators = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Id.TypeId == typeof(MyObjectBuilder_OxygenGenerator)).Cast<MyOxygenGeneratorDefinition>().ToList();
                foreach (var gasGenerator in gasGenerators)
                {
                    GASGENERATOR[new UniqueEntityId(gasGenerator.Id)] = gasGenerator;
                    BLUEPRINTS[new UniqueEntityId(gasGenerator.Id)] = new List<MyBlueprintDefinitionBase>();
                    foreach (var blueprintClass in gasGenerator.BlueprintClasses)
                    {
                        BLUEPRINTS[new UniqueEntityId(gasGenerator.Id)].AddRange(blueprintClass);
                    }
                }
                IsLoaded = true;
            }
        }

        public static void RecoverBlueprintUse(MyBlueprintDefinitionBase targetBlueprint, ref List<MyAssemblerDefinition> assemblers, ref List<MyRefineryDefinition> refineries, ref List<MyOxygenGeneratorDefinition> gasGenerators)
        {
            DoLoad();
            if (BLUEPRINTS.Any(x => x.Value.Contains(targetBlueprint)))
            {
                var ids = BLUEPRINTS.Where(x => x.Value.Contains(targetBlueprint)).Select(x => x.Key);
                foreach (var id in ids)
                {
                    if (ASSEMBLERS.ContainsKey(id))
                        assemblers.Add(ASSEMBLERS[id]);
                    else if (REFINERIES.ContainsKey(id))
                        refineries.Add(REFINERIES[id]);
                    else if (GASGENERATOR.ContainsKey(id))
                        gasGenerators.Add(GASGENERATOR[id]);
                }
            }
        }

        public static void TryOverrideDefinitions<T, K>(Dictionary<UniqueEntityId, T> definitions, UniqueEntityId targetFactionId, Action<T, K> onEndDefinition = null) where T : SimpleDefinition where K : MyPhysicalItemDefinition
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[targetFactionId];
                // Override medical definition
                foreach (var definition in definitions.Keys)
                {
                    var definitionDef = definitions[definition];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<K>(definition.DefinitionId);
                    if (itemDef != null)
                    {
                        itemDef.Volume = definitionDef.GetVolume();
                        itemDef.Mass = definitionDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = definitionDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = definitionDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = definitionDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = definitionDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = definitionDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = definitionDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = definitionDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = definitionDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = definitionDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + definitionDef.GetFullDescription());
                        if (onEndDefinition != null)
                            onEndDefinition(definitionDef, itemDef);
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(PhysicalItemDefinitionOverride), $"TryOverrideRecipes item not found. Food=[{definition}]");
                    // Recipe definition
                    var factoring = definitionDef as ISimpleFactoringDefinition;
                    if (factoring != null)
                    {
                        foreach (var recipe in factoring.GetRecipesDefinition())
                        {
                            var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                            if (recipeDef != null)
                            {
                                recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                                recipeDef.DisplayNameEnum = null;
                                recipeDef.DisplayNameString = definitionDef.Name;
                                recipeDef.DescriptionEnum = null;
                                recipeDef.DescriptionString = null;
                                var recipeAsProduct = recipe as ISimpleRecipeDefinition;
                                if (recipeAsProduct != null)
                                {
                                    recipeDef.Prerequisites = recipeAsProduct.GetIngredients();
                                    recipeDef.Results = recipeAsProduct.GetProduct(definitionDef.Id);
                                }
                                else
                                {
                                    var recipeAsIngredient = recipe as ISimpleIngredientRecipeDefinition;
                                    if (recipeAsIngredient != null)
                                    {
                                        recipeDef.Prerequisites = recipeAsIngredient.GetIngredients(definitionDef.Id);
                                        recipeDef.Results = recipeAsIngredient.GetProduct();
                                    }
                                    else
                                    {
                                        var recipeAsFull = recipe as IFullRecipeDefinition;
                                        if (recipeAsFull != null)
                                        {
                                            recipeDef.Prerequisites = recipeAsFull.GetIngredients();
                                            recipeDef.Results = recipeAsFull.GetProduct();
                                        }
                                    }
                                }
                                recipeDef.Postprocess();
                            }
                            else
                                ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(PhysicalItemDefinitionOverride), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                        }
                    }
                    // Add itens to faction types
                    if (definitionDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(definition);
                        targetFaction.OrdersList.Add(definition);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(PhysicalItemDefinitionOverride), ex);
            }
        }

    }

}