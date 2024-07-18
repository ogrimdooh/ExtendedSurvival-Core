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

        public const string MUD_SUBTYPEID = "Mud";
        public static readonly UniqueEntityId MUD_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MUD_SUBTYPEID);

        public const string ALIENSOIL_SUBTYPEID = "AlienSoil";
        public static readonly UniqueEntityId ALIENSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALIENSOIL_SUBTYPEID);

        public const string ASTEROIDSOIL_SUBTYPEID = "AsteroidSoil";
        public static readonly UniqueEntityId ASTEROIDSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ASTEROIDSOIL_SUBTYPEID);

        public const string DESERTSOIL_SUBTYPEID = "DesertSoil";
        public static readonly UniqueEntityId DESERTSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), DESERTSOIL_SUBTYPEID);

        public const string VULCANICSOIL_SUBTYPEID = "VulcanicSoil";
        public static readonly UniqueEntityId VULCANICSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), VULCANICSOIL_SUBTYPEID);

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

        public const string WOOD_SUBTYPEID = "Wood";
        public static readonly UniqueEntityId WOOD_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WOOD_SUBTYPEID);

        public const string TWIG_SUBTYPEID = "Twig";
        public static readonly UniqueEntityId TWIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TWIG_SUBTYPEID);

        public const string SAWDUST_SUBTYPEID = "Sawdust";
        public static readonly UniqueEntityId SAWDUST_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SAWDUST_SUBTYPEID);

        public const string LEAF_SUBTYPEID = "Leaf";
        public static readonly UniqueEntityId LEAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAF_SUBTYPEID);

        public const string BRANCH_SUBTYPEID = "Branch";
        public static readonly UniqueEntityId BRANCH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BRANCH_SUBTYPEID);

        // Integrations

        public const string IRON_SUBTYPEID = "Iron";
        public static readonly UniqueEntityId IRON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRON_SUBTYPEID);

        public const string FERROUSMOONSOIL_SUBTYPEID = "FerrousMoonSoil";
        public static readonly UniqueEntityId FERROUSMOONSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), FERROUSMOONSOIL_SUBTYPEID);

        public const string CHROMEMOONSOIL_SUBTYPEID = "ChromeMoonSoil";
        public static readonly UniqueEntityId CHROMEMOONSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHROMEMOONSOIL_SUBTYPEID);

        public static readonly OreDefinition SAWDUST_DEFINITION = new OreDefinition()
        {
            Id = SAWDUST_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SAWDUST_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SAWDUST_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.25f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.SAWDUSTTOCARBONPOWDER_NAME),
                    RecipeName = "SawdustToCarbonPowder_Construction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.5f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.CARBON_ID,
                            Ammount = 0.15f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition LEAF_DEFINITION = new OreDefinition()
        {
            Id = LEAF_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.LEAF_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.LEAF_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.LEAFTOORGANIC_NAME),
                    RecipeName = "LeafToOrganic_Disassembly",
                    IngredientAmmount = 1,
                    ProductionTime = 0.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition BRANCH_DEFINITION = new OreDefinition()
        {
            Id = BRANCH_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BRANCH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BRANCH_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 2f,
            Volume = 4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.BRANCHTOSAWDUST_NAME),
                    RecipeName = "BranchToSawdust_Disassembly",
                    IngredientAmmount = 1,
                    ProductionTime = 0.16f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = SAWDUST_ID,
                            Ammount = 0.26f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition TWIG_DEFINITION = new OreDefinition()
        {
            Id = TWIG_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.TWIG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TWIG_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 2f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.TWIGTOSAWDUST_NAME),
                    RecipeName = "TwigToSawdust_Disassembly",
                    IngredientAmmount = 1,
                    ProductionTime = 0.08f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = SAWDUST_ID,
                            Ammount = 0.065f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition WOOD_DEFINITION = new OreDefinition()
        {
            Id = WOOD_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.WOOD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WOOD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 6f,
            Volume = 12f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.WOODLOGTOSAWDUST_NAME),
                    RecipeName = "WoodLogToSawdust_Disassembly",
                    IngredientAmmount = 1,
                    ProductionTime = 0.48f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = SAWDUST_ID,
                            Ammount = 1.6f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition MUD_DEFINITION = new OreDefinition()
        {
            Id = MUD_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.MUD_ORE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MUD_ORE_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "Mud_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.04f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SOIL_ID,
                            Ammount = 0.15f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.0075f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ICE_ID,
                            Ammount = 0.0015f
                        }
                    }
                }
            }
        };

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

        public static readonly OreDefinition ASTEROIDSOIL_DEFINITION = new OreDefinition()
        {
            Id = ASTEROIDSOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ASTEROIDSOIL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ASTEROIDSOIL_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "AsteroidSoil_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.48f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.GRAVEL_ID,
                            Ammount = 0.175f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SAND_ID,
                            Ammount = 0.04625f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.SOIL_ID,
                            Ammount = 0.0275f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ORGANIC_ID,
                            Ammount = 0.00125f
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
            { MUD_ID, MUD_DEFINITION },
            { ALIENSOIL_ID, ALIENSOIL_DEFINITION },
            { ASTEROIDSOIL_ID, ASTEROIDSOIL_DEFINITION },
            { DESERTSOIL_ID, DESERTSOIL_DEFINITION },
            { MOONSOIL_ID, MOONSOIL_DEFINITION },
            { ORGANIC_ID, ORGANIC_DEFINITION },
            { ICE_ID, ICE_DEFINITION },
            { STONEICE_ID, STONEICE_DEFINITION },
            { TOXICICE_ID, TOXICICE_DEFINITION },
            { WOOD_ID, WOOD_DEFINITION },
            { TWIG_ID, TWIG_DEFINITION },
            { BRANCH_ID, BRANCH_DEFINITION },
            { LEAF_ID, LEAF_DEFINITION },
            { SAWDUST_ID, SAWDUST_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<OreDefinition, MyPhysicalItemDefinition>(ORES_DEFINITIONS, FactionTypeConstants.MINER_ID);
            HelpController.AddLoadAction(BuildHelpTopics);
        }

        public const string HELP_TOPIC_SUBTYPE = "PhysicalItem.Ore";

        private static UniqueNameId _HelpTopicId;
        public static UniqueNameId HelpTopicId
        {
            get
            {
                if (_HelpTopicId == null)
                    _HelpTopicId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, HELP_TOPIC_SUBTYPE);
                return _HelpTopicId;
            }
        }

        public static void BuildHelpTopics()
        {
            HelpController.AddTopic(HelpTopicId, LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_ORES_TITLE));
            HelpController.AddEntry(
                HelpTopicId,
                HelpTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_ORES_TITLE),
                0
            );
            HelpController.AddPage(
                HelpTopicId,
                HelpTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_ORES_DESCRIPTION)
            );
            foreach (var itemId in ORES_DEFINITIONS.Keys)
            {
                var itemEntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.{itemId.subtypeId.String}");
                HelpController.AddEntry(
                    HelpTopicId,
                    itemEntryId,
                    ORES_DEFINITIONS[itemId].Name,
                    1
                );
                HelpController.LoadDefinitionHelpEntryPages<OreDefinition, MyPhysicalItemDefinition>(ORES_DEFINITIONS[itemId], HelpTopicId, itemEntryId);
            }
        }

    }

}