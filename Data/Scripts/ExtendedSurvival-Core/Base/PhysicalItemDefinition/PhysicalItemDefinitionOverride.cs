using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    public static class PhysicalItemDefinitionOverride
    {

        public static void TryOverrideDefinitions<T, K>(Dictionary<UniqueEntityId, T> definitions, Action<T, K> onEndDefinition = null) where T : SimpleDefinition where K : MyPhysicalItemDefinition
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
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