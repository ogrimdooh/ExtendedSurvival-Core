using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class RecipientConstants
    {

        public const string FLASK_SMALL_SUBTYPEID = "Flask_Small";
        public static readonly UniqueEntityId FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_SMALL_SUBTYPEID);

        public const string FLASK_MEDIUM_SUBTYPEID = "Flask_Medium";
        public static readonly UniqueEntityId FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_MEDIUM_SUBTYPEID);

        public const string FLASK_BIG_SUBTYPEID = "Flask_Big";
        public static readonly UniqueEntityId FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_BIG_SUBTYPEID);

        public const string WATER_FLASK_SMALL_SUBTYPEID = "Water_Flask_Small";
        public static readonly UniqueEntityId WATER_FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_SMALL_SUBTYPEID);

        public const string WATER_FLASK_MEDIUM_SUBTYPEID = "Water_Flask_Medium";
        public static readonly UniqueEntityId WATER_FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_MEDIUM_SUBTYPEID);

        public const string WATER_FLASK_BIG_SUBTYPEID = "Water_Flask_Big";
        public static readonly UniqueEntityId WATER_FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_BIG_SUBTYPEID);

        public static readonly RecipientDefinition FLASK_SMALL_DEFINITION = new RecipientDefinition()
        {
            Id = FLASK_SMALL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FLASK_SMALL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_SMALL_NAME),
                    RecipeName = "Flask_Small_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, RecipientDefinition> RECIPIENTS_DEFINITIONS = new Dictionary<UniqueEntityId, RecipientDefinition>()
        {
            { FLASK_SMALL_ID, FLASK_SMALL_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<RecipientDefinition, MyPhysicalItemDefinition>(RECIPIENTS_DEFINITIONS);
        }

    }

}