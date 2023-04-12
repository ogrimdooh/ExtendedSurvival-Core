using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;

namespace ExtendedSurvival.Core
{

    public interface ISimpleRecipeDefinition
    {

        MyBlueprintDefinitionBase.Item[] GetIngredients();
        MyBlueprintDefinitionBase.Item[] GetProduct(UniqueEntityId ProductId);

    }

    public class SimpleRecipeDefinition : BaseRecipeDefinition, ISimpleRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public float ProductAmmount { get; set; }
        public RecipeItem[] Ingredients { get; set; } = new RecipeItem[] { };
        public RecipeItem[] OtherResults { get; set; } = new RecipeItem[] { };

        public MyBlueprintDefinitionBase.Item[] GetIngredients()
        {
            return Ingredients.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).ToArray();
        }

        public MyBlueprintDefinitionBase.Item[] GetProduct(UniqueEntityId ProductId)
        {
            return OtherResults.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).Append(new MyBlueprintDefinitionBase.Item()
            {
                Id = ProductId.DefinitionId,
                Amount = (MyFixedPoint)ProductAmmount
            }).ToArray();
        }

    }

}