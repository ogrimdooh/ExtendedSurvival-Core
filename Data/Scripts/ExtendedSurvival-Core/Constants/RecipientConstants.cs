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

        public const string POLIETILENOGLICOL_SUBTYPEID = "Polietilenoglicol";
        public static readonly UniqueEntityId POLIETILENOGLICOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), POLIETILENOGLICOL_SUBTYPEID);

        public const string SILVERSULFADIAZINE_SUBTYPEID = "SilverSulfadiazine";
        public static readonly UniqueEntityId SILVERSULFADIAZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SILVERSULFADIAZINE_SUBTYPEID);

        public static readonly RecipientDefinition SILVERSULFADIAZINE_DEFINITION = new RecipientDefinition()
        {
            Id = SILVERSULFADIAZINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SILVERSULFADIAZINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SILVERSULFADIAZINE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Mass = 4.5f,
            Volume = 1.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.SILVERSULFADIAZINE_NAME),
                    RecipeName = "SilverSulfadiazine_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = WATER_FLASK_BIG_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SILVERPOWDER_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition POLIETILENOGLICOL_DEFINITION = new RecipientDefinition()
        {
            Id = POLIETILENOGLICOL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.POLIETILENOGLICOL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.POLIETILENOGLICOL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Mass = 2f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.POLIETILENOGLICOL_NAME),
                    RecipeName = "Polietilenoglicol_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = WATER_FLASK_SMALL_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.CARBON_ID,
                            Ammount = 2.5f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition WATER_FLASK_SMALL_DEFINITION = new RecipientDefinition()
        {
            Id = WATER_FLASK_SMALL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_NAME),
                    RecipeName = "Water_Flask_Small_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 1.28f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = FLASK_SMALL_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.ICE_ID,
                            Ammount = 0.1f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition WATER_FLASK_MEDIUM_DEFINITION = new RecipientDefinition()
        {
            Id = WATER_FLASK_MEDIUM_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 100,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Mass = 3f,
            Volume = 1f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_NAME),
                    RecipeName = "Water_Flask_Medium_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = FLASK_MEDIUM_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.ICE_ID,
                            Ammount = 0.2f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition WATER_FLASK_BIG_DEFINITION = new RecipientDefinition()
        {
            Id = WATER_FLASK_BIG_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Mass = 4.5f,
            Volume = 1.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_NAME),
                    RecipeName = "Water_Flask_Big_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = FLASK_BIG_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.ICE_ID,
                            Ammount = 0.4f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition FLASK_SMALL_DEFINITION = new RecipientDefinition()
        {
            Id = FLASK_SMALL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FLASK_SMALL_DESCRIPTION),
            CanPlayerOrder = true,
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
                    ProductionTime = 1.28f,
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

        public static readonly RecipientDefinition FLASK_MEDIUM_DEFINITION = new RecipientDefinition()
        {
            Id = FLASK_MEDIUM_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_MEDIUM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FLASK_MEDIUM_DESCRIPTION),
            CanPlayerOrder = true,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_MEDIUM_NAME),
                    RecipeName = "Flask_Medium_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition FLASK_BIG_DEFINITION = new RecipientDefinition()
        {
            Id = FLASK_BIG_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_BIG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FLASK_BIG_DESCRIPTION),
            CanPlayerOrder = true,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.FLASK_BIG_NAME),
                    RecipeName = "Flask_Big_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.75f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, RecipientDefinition> RECIPIENTS_DEFINITIONS = new Dictionary<UniqueEntityId, RecipientDefinition>()
        {
            { FLASK_SMALL_ID, FLASK_SMALL_DEFINITION },
            { FLASK_MEDIUM_ID, FLASK_MEDIUM_DEFINITION },
            { FLASK_BIG_ID, FLASK_BIG_DEFINITION },
            { SILVERSULFADIAZINE_ID, SILVERSULFADIAZINE_DEFINITION },
            { POLIETILENOGLICOL_ID, POLIETILENOGLICOL_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            if (!ExtendedSurvivalCoreSession.IsUsingStatsAndEffects())
            {
                RECIPIENTS_DEFINITIONS.Add(WATER_FLASK_SMALL_ID, WATER_FLASK_SMALL_DEFINITION);
                RECIPIENTS_DEFINITIONS.Add(WATER_FLASK_MEDIUM_ID, WATER_FLASK_MEDIUM_DEFINITION);
                RECIPIENTS_DEFINITIONS.Add(WATER_FLASK_BIG_ID, WATER_FLASK_BIG_DEFINITION);
            }
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<RecipientDefinition, MyPhysicalItemDefinition>(RECIPIENTS_DEFINITIONS, FactionTypeConstants.TRADER_ID);
        }

    }

}