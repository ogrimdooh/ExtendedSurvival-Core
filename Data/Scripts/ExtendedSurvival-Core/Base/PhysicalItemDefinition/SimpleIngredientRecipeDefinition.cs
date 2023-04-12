using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;

namespace ExtendedSurvival.Core
{

    public interface ISimpleIngredientRecipeDefinition
    {

        MyBlueprintDefinitionBase.Item[] GetIngredients(UniqueEntityId ProductId);
        MyBlueprintDefinitionBase.Item[] GetProduct();

    }

    public class SimpleIngredientRecipeDefinition : BaseRecipeDefinition, ISimpleIngredientRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public float IngredientAmmount { get; set; }
        public RecipeItem[] OtherIngredients { get; set; } = new RecipeItem[] { };
        public RecipeItem[] Results { get; set; } = new RecipeItem[] { };

        public MyBlueprintDefinitionBase.Item[] GetIngredients(UniqueEntityId ProductId)
        {
            return OtherIngredients.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).Append(new MyBlueprintDefinitionBase.Item()
            {
                Id = ProductId.DefinitionId,
                Amount = (MyFixedPoint)IngredientAmmount
            }).ToArray();
        }

        public MyBlueprintDefinitionBase.Item[] GetProduct()
        {
            return Results.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).ToArray();
        }

    }

}