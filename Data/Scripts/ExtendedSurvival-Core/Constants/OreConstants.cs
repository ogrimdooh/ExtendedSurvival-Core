using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class OreConstants
    {

        public const string SOIL_SUBTYPEID = "Soil";
        public static readonly UniqueEntityId SOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SOIL_SUBTYPEID);

        public const string ALIENSOIL_SUBTYPEID = "AlienSoil";
        public static readonly UniqueEntityId ALIENSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALIENSOIL_SUBTYPEID);

        public const string DESERTSOIL_SUBTYPEID = "DesertSoil";
        public static readonly UniqueEntityId DESERTSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), DESERTSOIL_SUBTYPEID);

        public const string MOONSOIL_SUBTYPEID = "MoonSoil";
        public static readonly UniqueEntityId MOONSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MOONSOIL_SUBTYPEID);

        public const string ORGANIC_SUBTYPEID = "Organic";
        public static readonly UniqueEntityId ORGANIC_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ORGANIC_SUBTYPEID);

        public const string ICE_SUBTYPEID = "Ice";
        public static readonly UniqueEntityId ICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ICE_SUBTYPEID);

        public const string STONEICE_SUBTYPEID = "StoneIce";
        public static readonly UniqueEntityId STONEICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), STONEICE_SUBTYPEID);

        public const string TOXICICE_SUBTYPEID = "ToxicIce";
        public static readonly UniqueEntityId TOXICICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TOXICICE_SUBTYPEID);

        public static readonly OreDefinition SOIL_DEFINITION = new OreDefinition()
        {
            Id = SOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SOIL_ORE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SOIL_ORE_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>() 
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "Soil_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.05f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SOIL_ID,
                            Ammount = 0.15f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.05f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition ALIENSOIL_DEFINITION = new OreDefinition()
        {
            Id = ALIENSOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENSOIL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENSOIL_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "AlienSoil_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.05f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SOIL_ID,
                            Ammount = 0.125f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.075f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition DESERTSOIL_DEFINITION = new OreDefinition()
        {
            Id = DESERTSOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.DESERTSOIL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.DESERTSOIL_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "DesertSoil_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.15f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.1f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition MOONSOIL_DEFINITION = new OreDefinition()
        {
            Id = MOONSOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.MOONSOIL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MOONSOIL_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "MoonSoil_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.1f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.15f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition ORGANIC_DEFINITION = new OreDefinition()
        {
            Id = ORGANIC_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ORGANIC_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ORGANIC_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>() { }
        };

        public static readonly OreDefinition ICE_DEFINITION = new OreDefinition()
        {
            Id = ICE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ICE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ICE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.35f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>() { }
        };

        public static readonly OreDefinition STONEICE_DEFINITION = new OreDefinition()
        {
            Id = STONEICE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.STONEICE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.STONEICE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "StoneIcePurify",
                    IngredientAmmount = 1,
                    ProductionTime = 2.56f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ICE_ID,
                            Ammount = 0.3f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.35f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.15f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition TOXICICE_DEFINITION = new OreDefinition()
        {
            Id = TOXICICE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.TOXICICE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TOXICICE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "ToxicIcePurify",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ICE_ID,
                            Ammount = 0.5f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, OreDefinition> ORES_DEFINITIONS = new Dictionary<UniqueEntityId, OreDefinition>()
        {
            { SOIL_ID, SOIL_DEFINITION },
            { ALIENSOIL_ID, ALIENSOIL_DEFINITION },
            { DESERTSOIL_ID, DESERTSOIL_DEFINITION },
            { MOONSOIL_ID, MOONSOIL_DEFINITION },
            { ORGANIC_ID, ORGANIC_DEFINITION },
            { ICE_ID, ICE_DEFINITION },
            { STONEICE_ID, STONEICE_DEFINITION },
            { TOXICICE_ID, TOXICICE_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<OreDefinition, MyPhysicalItemDefinition>(ORES_DEFINITIONS, FactionTypeConstants.MINER_ID);
        }

    }

}