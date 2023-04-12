using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;

namespace ExtendedSurvival.Core
{

    public interface IFullRecipeDefinition
    {

        MyBlueprintDefinitionBase.Item[] GetIngredients();
        MyBlueprintDefinitionBase.Item[] GetProduct();

    }

    public class FullRecipeDefinition : BaseRecipeDefinition, IFullRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public RecipeItem[] Ingredients { get; set; } = new RecipeItem[] { };
        public RecipeItem Product { get; set; }
        public RecipeItem[] OtherResults { get; set; } = new RecipeItem[] { };

        public MyBlueprintDefinitionBase.Item[] GetIngredients()
        {
            return Ingredients.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).ToArray();
        }

        public MyBlueprintDefinitionBase.Item[] GetProduct()
        {
            return OtherResults.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).Append(new MyBlueprintDefinitionBase.Item()
            {
                Id = Product.Id.DefinitionId,
                Amount = (MyFixedPoint)Product.Ammount
            }).ToArray();
        }

    }

}