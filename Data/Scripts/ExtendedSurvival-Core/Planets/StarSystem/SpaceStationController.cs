using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Blocks;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Collections;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class SpaceStationController
    {

        public static int SPAWN_DISTANCE = 10000;

        public static readonly Vector2 STATION_BUY_VALUE_MULTIPLIER = new Vector2(0.75f, 0.85f);

        public const string STOREBLOCK_SUBTYPEID = "StoreBlock";
        public static readonly UniqueEntityId STOREBLOCK_ID = new UniqueEntityId(typeof(MyObjectBuilder_StoreBlock), STOREBLOCK_SUBTYPEID);

        public const string LARGEBLOCKLARGECONTAINER_SUBTYPEID = "LargeBlockLargeContainer";
        public static readonly UniqueEntityId LARGEBLOCKLARGECONTAINER_ID = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), LARGEBLOCKLARGECONTAINER_SUBTYPEID);

        public enum StationType
        {

            MiningStation = 0,
            Outpost = 1,
            OrbitalStation = 2,
            SpaceStation = 3

        }

        public enum StationLevel
        {

            Small = 0,
            Medium = 1,
            Large = 2

        }

        public class BaseMaterialItem
        {

            public UniqueEntityId Id { get; set; }
            public MyPhysicalItemDefinition Definition { get; set; }
            public bool ForceMinimalPrice { get; set; }

            public bool IsLoaded { get; set; }
            public bool IsBlueprintChecked { get; set; }
            public MyBlueprintDefinitionBase RecipeBlueprint { get; set; }

            public long BaseValue { get; set; }

        }

        public class StationShopItem : BaseMaterialItem
        {

            public ItemRarity Rarity { get; set; }
            public FactionType[] TargetFactions { get; set; }
            public bool CanBuy { get; set; }
            public bool CanSell { get; set; }
            public bool CanOrder { get; set; }

        }

        public struct StationItensAmountProfile
        {

            public Vector2I SellItensCount;
            public Vector2I BuyItensCount;
            public ItemRarity[] CanSellRarity;

        }

        public static readonly ConcurrentDictionary<UniqueEntityId, StationShopItem> SHOP_ITENS = new ConcurrentDictionary<UniqueEntityId, StationShopItem>();
        public static readonly ConcurrentDictionary<UniqueEntityId, BaseMaterialItem> BASE_ITENS = new ConcurrentDictionary<UniqueEntityId, BaseMaterialItem>();

        // PG = 12,21 * 4,54 (5-1)
        public static readonly Dictionary<PlanetProfile.OreRarity, float> BASE_ORE_VALUE = new Dictionary<PlanetProfile.OreRarity, float>()
        {
            { PlanetProfile.OreRarity.None, 12.21f },
            { PlanetProfile.OreRarity.Common, 55.43f },
            { PlanetProfile.OreRarity.Uncommon, 251.66f },
            { PlanetProfile.OreRarity.Rare, 1142.57f },
            { PlanetProfile.OreRarity.Epic, 5187.27f }
        };

        public static readonly Dictionary<ItemRarity, Vector2> ITEM_RARITY_AMOUNT = new Dictionary<ItemRarity, Vector2>()
        {
            { ItemRarity.Common, new Vector2(256, 512) },
            { ItemRarity.Uncommon, new Vector2(128, 256) },
            { ItemRarity.Normal, new Vector2(64, 128) },
            { ItemRarity.Rare, new Vector2(32, 64) },
            { ItemRarity.Epic, new Vector2(16, 32) },
        };

        public static readonly Vector2 ORE_INGOT_AMOUNT_MULTIPLIER = new Vector2(100, 200);
        public static readonly Vector2 GASCONTAINER_AMOUNT_MULTIPLIER = new Vector2(0.15f, 0.35f);

        public static readonly Dictionary<StationLevel, StationItensAmountProfile> STATION_ITENS_PROFILE = new Dictionary<StationLevel, StationItensAmountProfile>()
        {
            { 
                StationLevel.Small,
                new StationItensAmountProfile()
                {
                    BuyItensCount = new Vector2I(5, 10),
                    SellItensCount = new Vector2I(5, 10),
                    CanSellRarity = new ItemRarity[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Normal }
                }
            },
            {
                StationLevel.Medium,
                new StationItensAmountProfile()
                {
                    BuyItensCount = new Vector2I(10, 15),
                    SellItensCount = new Vector2I(10, 15),
                    CanSellRarity = new ItemRarity[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Normal, ItemRarity.Rare }
                }
            },
            {
                StationLevel.Large,
                new StationItensAmountProfile()
                {
                    BuyItensCount = new Vector2I(15, 20),
                    SellItensCount = new Vector2I(15, 20),
                    CanSellRarity = new ItemRarity[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Normal, ItemRarity.Rare, ItemRarity.Epic }
                }
            }
        };

        public struct StationPrefabInfo
        {

            public string name;
            public float upIncrement;
            public bool swapUpToFoward;

            public StationPrefabInfo(string name, float upIncrement = 0, bool swapUpToFoward = false)
            {
                this.name = name;
                this.upIncrement = upIncrement;
                this.swapUpToFoward = swapUpToFoward;
            }

        }

        public static readonly Dictionary<StationType, StationPrefabInfo[]> VALID_PREFABS = new Dictionary<StationType, StationPrefabInfo[]>()
        {
            {
                StationType.MiningStation,
                new StationPrefabInfo[]
                {
                    //new StationPrefabInfo("Economy_MiningStation_1", upIncrement: 3.5f, swapUpToFoward: true), this two had align problems
                    //new StationPrefabInfo("Economy_MiningStation_3", upIncrement: 3.5f, swapUpToFoward: true),       
                    new StationPrefabInfo("Economy_Outpost_1"),
                    new StationPrefabInfo("Economy_Outpost_2"),
                    new StationPrefabInfo("Economy_Outpost_3"),
                    new StationPrefabInfo("Economy_Outpost_4"),
                    new StationPrefabInfo("Economy_Outpost_5"),
                    new StationPrefabInfo("Economy_Outpost_6"),
                    new StationPrefabInfo("Economy_Outpost_7"),
                    new StationPrefabInfo("Economy_Outpost_8"),
                    new StationPrefabInfo("Economy_Outpost_9"),
                    new StationPrefabInfo("Economy_MiningStation_2", upIncrement: 8.0f)
                }
            },
            {
                StationType.Outpost,
                new StationPrefabInfo[]
                {
                    new StationPrefabInfo("Economy_Outpost_1"),
                    new StationPrefabInfo("Economy_Outpost_2"),
                    new StationPrefabInfo("Economy_Outpost_3"),
                    new StationPrefabInfo("Economy_Outpost_4"),
                    new StationPrefabInfo("Economy_Outpost_5"),
                    new StationPrefabInfo("Economy_Outpost_6"),
                    new StationPrefabInfo("Economy_Outpost_7"),
                    new StationPrefabInfo("Economy_Outpost_8"),
                    new StationPrefabInfo("Economy_Outpost_9")
                }
            },
            {
                StationType.OrbitalStation,
                new StationPrefabInfo[]
                {
                    new StationPrefabInfo("Economy_OrbitalStation_1"),
                    new StationPrefabInfo("Economy_OrbitalStation_2"),
                    new StationPrefabInfo("Economy_OrbitalStation_3"),
                    new StationPrefabInfo("Economy_OrbitalStation_4"),
                    new StationPrefabInfo("Economy_OrbitalStation_5"),
                    new StationPrefabInfo("Economy_OrbitalStation_6"),
                    new StationPrefabInfo("Economy_OrbitalStation_7")
                }
            },
            {
                StationType.SpaceStation,
                new StationPrefabInfo[]
                {
                    new StationPrefabInfo("Economy_SpaceStation_1"),
                    new StationPrefabInfo("Economy_SpaceStation_2"),
                    new StationPrefabInfo("Economy_SpaceStation_3"),
                    new StationPrefabInfo("Economy_SpaceStation_4"),
                    new StationPrefabInfo("Economy_SpaceStation_5")
                }
            }
        }; 

        public static readonly Dictionary<StationType, string> STATION_TYPE_NAME = new Dictionary<StationType, string>()
        {
            { StationType.MiningStation, "Mining Station" },
            { StationType.Outpost, "Outpost" },
            { StationType.OrbitalStation, "Orbital Station" },
            { StationType.SpaceStation, "Space Station" }
        };

        private static readonly Dictionary<FactionType, string> FACTION_PREFIX = new Dictionary<FactionType, string>()
        {
            { FactionType.Miner, "M" },
            { FactionType.Lumber, "L" },
            { FactionType.Shipyard, "S" },
            { FactionType.Trader, "T" },
            { FactionType.Armory, "A" },
            { FactionType.Farming, "F" },
            { FactionType.Livestock, "V" },
            { FactionType.Market, "K" },
        };

        private static readonly Dictionary<FactionType, string[]> FACTION_DESCS = new Dictionary<FactionType, string[]>()
        {
            {
                FactionType.Miner,
                new string[]
                {
                    "We are a mining company focused on the future, always offering the best ores for your production.",
                    "Wherever you hear ore, we'll be there!"
                }
            },
            {
                FactionType.Lumber,
                new string[]
                {
                    "We offer the best wood in the solar system.",
                    "Whether for construction or fuel, you will find your wood here."
                }
            },
            {
                FactionType.Shipyard,
                new string[]
                {
                    "Specializing in spacecraft construction for over 350 years.",
                    "If you produce quality ships, you've come to the right place."
                }
            },
            {
                FactionType.Trader,
                new string[]
                {
                    "From tools to components, we make the best deal for you.",
                    "Don't manufacture what you can buy, and if you're going to buy it, buy it from us."
                }
            },
            {
                FactionType.Armory,
                new string[]
                {
                    "If you are going to shoot, better shoot with quality bullets that we can offer.",
                    "Why spend time making gunpowder? Only buy ammunition that we can offer at a good price."
                }
            },
            {
                FactionType.Farming,
                new string[]
                {
                    "The best fruits and vegetables that can be found in the sector.",
                    "Producing food in zero gravity isn't easy, and we're not kidding."
                }
            },
            {
                FactionType.Livestock,
                new string[]
                {
                    "From fat cows to angry spiders, you can find them here.",
                    "Nothing beats the taste of an animal raised for slaughter."
                }
            },
            {
                FactionType.Market,
                new string[]
                {
                    "We provide all the utensils and processed foods needed to survive in the void.",
                    "From your hunger to your health, we offer what you need."
                }
            }
        };

        private static readonly string[] FIRST_NAMES = new string[] 
        {
            "Meta",
            "Solar",
            "Enlisted",
            "Sixth",
            "Golden",
            "Uncharted",
            "Prime",
            "Outer",
            "Blighted",
            "Vagrant",
            "Hyperion",
            "Sacred",
            "Expanse",
            "Pligrims",
            "Nation"
        };

        private static readonly string[] MIDDLE_NAMES = new string[] 
        {
            "Viceroy",
            "Terran",
            "Syndical",
            "Magisters",
            "Ursan",
            "Alogithmic",
            "Anarchic",
            "Aegir",
            "Sacred",
            "Alpha",
            "of",
            "Nomads",
            "Elders"
        };

        private static readonly string[] LAST_NAMES = new string[] 
        {
            "Suns",
            "Triad",
            "Citizenry",
            "Excommunicate",
            "Inquisition",
            "Faction",
            "Syndicate",
            "Network",
            "Corporation",
            "Front",
            "Saiph",
            "Andromeda",
            "Systems",
            "Vega"
        };

        static SpaceStationController()
        {
            // Lumber
            AddItemToShop(ItensConstants.WOODLOG_ID, ItemRarity.Common, true, true, true, FactionType.Lumber);
            AddItemToShop(ItensConstants.SAWDUST_ID, ItemRarity.Common, true, true, true, FactionType.Lumber);
            // Miner
            AddItemToShop(ItensConstants.IRON_ORE_ID, ItemRarity.Common, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.IRON_INGOT_ID, ItemRarity.Common, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.NICKEL_ORE_ID, ItemRarity.Uncommon, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.NICKEL_INGOT_ID, ItemRarity.Uncommon, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SILICON_ORE_ID, ItemRarity.Uncommon, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SILICON_INGOT_ID, ItemRarity.Uncommon, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.COBALT_ORE_ID, ItemRarity.Normal, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.COBALT_INGOT_ID, ItemRarity.Normal, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.MAGNESIUM_ORE_ID, ItemRarity.Normal, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.MAGNESIUM_INGOT_ID, ItemRarity.Normal, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.GOLD_ORE_ID, ItemRarity.Rare, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.GOLD_INGOT_ID, ItemRarity.Rare, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SILVER_ORE_ID, ItemRarity.Rare, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SILVER_INGOT_ID, ItemRarity.Rare, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.PLATINUM_ORE_ID, ItemRarity.Epic, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.PLATINUM_INGOT_ID, ItemRarity.Epic, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.URANIUM_ORE_ID, ItemRarity.Epic, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.URANIUM_INGOT_ID, ItemRarity.Epic, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SILVERPOWDER_ID, ItemRarity.Rare, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.CARBON_POWDER_ID, ItemRarity.Uncommon, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SAND_ID, ItemRarity.Common, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.SOIL_INGOT_ID, ItemRarity.Common, true, true, true, FactionType.Miner);
            AddItemToShop(ItensConstants.ICE_ID, ItemRarity.Normal, true, true, true, FactionType.Miner);
            // Armory
            AddItemToShop(ItensConstants.SEMIAUTOPISTOL_ID, ItemRarity.Common, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.FULLAUTOPISTOL_ID, ItemRarity.Uncommon, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.ELITEAUTOPISTOL_ID, ItemRarity.Normal, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.AUTOMATICRIFLE_ID, ItemRarity.Uncommon, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.RAPIDFIREAUTOMATICRIFLE_ID, ItemRarity.Normal, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.PRECISEAUTOMATICRIFLE_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.ULTIMATEAUTOMATICRIFLE_ID, ItemRarity.Epic, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.BASICHANDHELDLAUNCHER_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.ADVANCEDHANDHELDLAUNCHER_ID, ItemRarity.Epic, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.PISTOL_SA_MAGZINE_ID, ItemRarity.Common, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.PISTOL_RF_MAGZINE_ID, ItemRarity.Uncommon, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.PISTOL_PF_MAGZINE_ID, ItemRarity.Normal, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.RIFLE_SA_MAGZINE_ID, ItemRarity.Uncommon, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.RIFLE_RF_MAGZINE_ID, ItemRarity.Normal, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.RIFLE_PF_MAGZINE_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.RIFLE_E_MAGZINE_ID, ItemRarity.Epic, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.AUTOCANNONCLIP_ID, ItemRarity.Common, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.NATO_25X184MM_ID, ItemRarity.Uncommon, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.MEDIUMCALIBREAMMO_ID, ItemRarity.Normal, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.MISSILE200MM_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.EXPLOSIVES_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.LARGECALIBREAMMO_ID, ItemRarity.Rare, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.SMALLRAILGUNAMMO_ID, ItemRarity.Epic, true, true, true, FactionType.Armory);
            AddItemToShop(ItensConstants.LARGERAILGUNAMMO_ID, ItemRarity.Epic, true, true, true, FactionType.Armory);
            /* Check other mods */
            // Trader
            AddItemToShop(ItensConstants.STEELPLATE_ID, ItemRarity.Common, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.BULLETPROOFGLASS_ID, ItemRarity.Common, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.INTERIORPLATE_ID, ItemRarity.Common, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.CONSTRUCTION_ID, ItemRarity.Common, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.GIRDER_ID, ItemRarity.Common, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.MOTOR_ID, ItemRarity.Uncommon, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.COMPUTER_ID, ItemRarity.Uncommon, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.SOLARCELL_ID, ItemRarity.Uncommon, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.DISPLAY_ID, ItemRarity.Uncommon, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.SMALLTUBE_ID, ItemRarity.Normal, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.LARGETUBE_ID, ItemRarity.Normal, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.RADIO_COMP_ID, ItemRarity.Normal, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.DETECTOR_ID, ItemRarity.Normal, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.POWERCELL_ID, ItemRarity.Normal, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.MEDICAL_ID, ItemRarity.Rare, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.SUPERCONDUCTOR_ID, ItemRarity.Rare, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.REACTOR_ID, ItemRarity.Epic, true, true, true, FactionType.Trader);
            AddItemToShop(ItensConstants.THRUST_ID, ItemRarity.Epic, true, true, true, FactionType.Trader);
            // Market
            AddItemToShop(ItensConstants.HANDDRILLITEM_ID, ItemRarity.Common, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.HANDDRILL2ITEM_ID, ItemRarity.Uncommon, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.HANDDRILL3ITEM_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.HANDDRILL4ITEM_ID, ItemRarity.Epic, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.WELDERITEM_ID, ItemRarity.Common, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.WELDER2ITEM_ID, ItemRarity.Uncommon, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.WELDER3ITEM_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.WELDER4ITEM_ID, ItemRarity.Epic, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.ANGLEGRINDERITEM_ID, ItemRarity.Common, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.ANGLEGRINDER2ITEM_ID, ItemRarity.Uncommon, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.ANGLEGRINDER3ITEM_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.ANGLEGRINDER4ITEM_ID, ItemRarity.Epic, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.OXYGENBOTTLE_ID, ItemRarity.Normal, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.HYDROGENBOTTLE_ID, ItemRarity.Normal, true, true, true, FactionType.Market);
            AddItemToShop(RecipientConstants.WATER_FLASK_SMALL_ID, ItemRarity.Uncommon, true, true, true, FactionType.Market);
            AddItemToShop(RecipientConstants.WATER_FLASK_MEDIUM_ID, ItemRarity.Normal, true, true, true, FactionType.Market);
            AddItemToShop(RecipientConstants.WATER_FLASK_BIG_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            AddItemToShop(RecipientConstants.POLIETILENOGLICOL_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            AddItemToShop(RecipientConstants.SILVERSULFADIAZINE_ID, ItemRarity.Epic, true, true, true, FactionType.Market);
            AddItemToShop(ItensConstants.MEDKIT_ID, ItemRarity.Rare, true, true, true, FactionType.Market);
            // Shipyard
            /* Need to check how to do this! */
            // Trader & Market
            AddItemToShop(ItensConstants.ZONECHIP_ID, ItemRarity.Rare, true, true, true, FactionType.Trader, FactionType.Market);
            AddItemToShop(RecipientConstants.FLASK_SMALL_ID, ItemRarity.Uncommon, true, true, true, FactionType.Trader, FactionType.Market);
            AddItemToShop(RecipientConstants.FLASK_MEDIUM_ID, ItemRarity.Normal, true, true, true, FactionType.Trader, FactionType.Market);
            AddItemToShop(RecipientConstants.FLASK_BIG_ID, ItemRarity.Rare, true, true, true, FactionType.Trader, FactionType.Market);
            // Trader & Market & Shipyard
            AddItemToShop(ItensConstants.CANVAS_ID, ItemRarity.Normal, true, true, true, FactionType.Trader, FactionType.Market, FactionType.Shipyard);
            SelfLoaded = true;
            MarkAsAllItensLoaded(0);
        }

        private static bool SelfLoaded = false;
        private static bool TechnologyLoaded = false;
        private static bool StatsAndEffectsLoaded = false;

        private static bool IsAllLoaded
        {
            get
            {
                return SelfLoaded && TechnologyLoaded && StatsAndEffectsLoaded;
            }
        }

        public static void MarkAsAllItensLoaded(ulong modId)
        {
            if (!TechnologyLoaded)
                TechnologyLoaded = !ExtendedSurvivalCoreSession.IsUsingTechnology() || modId == ExtendedSurvivalCoreSession.ES_TECHNOLOGY_MODID;
            if (!StatsAndEffectsLoaded)
                StatsAndEffectsLoaded = !ExtendedSurvivalCoreSession.IsUsingStatsAndEffects() || modId == ExtendedSurvivalCoreSession.ES_STATS_EFFECTS_MODID;
            if (IsAllLoaded)
                DoCalcAllItensInfo();
        }

        public static bool ChangeItemRarity(UniqueEntityId id, ItemRarity rarity)
        {
            if (SHOP_ITENS.ContainsKey(id))
            {
                SHOP_ITENS[id].Rarity = rarity;
                ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"ChangeItemRarity: Item {id.DefinitionId} rarity change to {rarity}.");
                return true;
            }
            ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"ChangeItemRarity: Item {id.DefinitionId} not found.");
            return false;
        }

        public static bool AddItemToShop(UniqueEntityId id, ItemRarity rarity, bool canBuy, bool canSell, bool canOrder, params FactionType[] targetFactions)
        {
            return AddItemToShop(id, rarity, canBuy, canSell, canOrder, false, targetFactions);
        }

        public static bool AddItemToShop(UniqueEntityId id, ItemRarity rarity, bool canBuy, bool canSell, bool canOrder, bool forceMinimalPrice, params FactionType[] targetFactions)
        {
            if (!SHOP_ITENS.ContainsKey(id))
            {
                if (targetFactions != null && targetFactions.Any())
                {
                    var def = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(id.DefinitionId);
                    if (def != null)
                    {
                        SHOP_ITENS[id] = new StationShopItem()
                        {
                            Id = id,
                            Rarity = rarity,
                            CanBuy = canBuy,
                            CanSell = canSell,
                            CanOrder = canOrder,
                            ForceMinimalPrice = forceMinimalPrice,
                            TargetFactions = targetFactions,
                            Definition = def
                        };
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"AddItemToShop: Item {id.DefinitionId} registered.");
                        return true;
                    }
                    else
                    {
                        ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"AddItemToShop: Item {id.DefinitionId} has no definition.");
                    }
                }
                else
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"AddItemToShop: Item {id.DefinitionId} has no target factions.");
                }
            }
            ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"AddItemToShop: Item {id.DefinitionId} already registered.");
            return false;
        }

        private static void DoCheckForBaseMaterials<T>(IEnumerable<KeyValuePair<UniqueEntityId, T>> queryItemBaseMaterial) where T : BaseMaterialItem
        {
            while (queryItemBaseMaterial.Any())
            {
                var itemToCheck = queryItemBaseMaterial.FirstOrDefault();
                var requisitesToAdd = itemToCheck.Value.RecipeBlueprint.Prerequisites.Where(y =>
                    !SHOP_ITENS.ContainsKey(new UniqueEntityId(y.Id)) &&
                    !BASE_ITENS.ContainsKey(new UniqueEntityId(y.Id))
                ).ToArray();
                foreach (var requisite in requisitesToAdd)
                {
                    var id = new UniqueEntityId(requisite.Id);
                    var def = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(id.DefinitionId);
                    if (ExtendedSurvivalSettings.Instance.Debug)
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"DoCheckForBaseMaterials: BASE_ITENS ADD {id}");
                    BASE_ITENS[id] = new BaseMaterialItem()
                    {
                        Id = id,
                        Definition = def,
                        IsLoaded = def == null,
                        IsBlueprintChecked = def == null,
                        BaseValue = def == null ? 1 : 0
                    };
                }
            }
            var queryBaseItens = BASE_ITENS.Where(x => !x.Value.IsLoaded);
            var queryBaseItemBlueprint = queryBaseItens.Where(x => !x.Value.IsBlueprintChecked);
            while (queryBaseItemBlueprint.Any())
            {
                var itemToCheck = queryBaseItemBlueprint.FirstOrDefault();
                if (!itemToCheck.Value.ForceMinimalPrice)
                {
                    var idToFind = itemToCheck.Key.DefinitionId;
                    var isBaseOre = idToFind.TypeId == typeof(MyObjectBuilder_Ore) && PlanetMapProfile.AllValidOres.Contains(idToFind.SubtypeName.ToUpper());
                    if (!isBaseOre)
                    {
                        var queryBlueprint = bluePrints.Where(x => x.Results.Any(y => y.Id == idToFind) && !x.Prerequisites.Any(y => y.Id == idToFind));
                        if (queryBlueprint.Any())
                        {
                            var bluePrintsToChouse = queryBlueprint.OrderBy(x => x.Results.Count()).ToList();
                            if (bluePrintsToChouse.Any(x => x.IsPrimary))
                                itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.Where(x => x.IsPrimary).FirstOrDefault();
                            else
                                itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.FirstOrDefault();
                        }
                    }
                }
                itemToCheck.Value.IsBlueprintChecked = true;
            }
        }

        private static DictionaryValuesReader<MyDefinitionId, MyBlueprintDefinitionBase>? _bluePrints = null;
        private static DictionaryValuesReader<string, MyVoxelMaterialDefinition>? _voxelDefinitions = null;

        private static DictionaryValuesReader<MyDefinitionId, MyBlueprintDefinitionBase> bluePrints
        {
            get
            {
                if (_bluePrints == null)
                    _bluePrints = MyDefinitionManager.Static.GetBlueprintDefinitions();
                return _bluePrints.Value;
            }
        }

        private static DictionaryValuesReader<string, MyVoxelMaterialDefinition> voxelDefinitions
        {
            get
            {
                if (_voxelDefinitions == null)
                    _voxelDefinitions = MyDefinitionManager.Static.GetVoxelMaterialDefinitions();
                return _voxelDefinitions.Value;
            }
        }

        private static void DoCalcAllItensInfo()
        {
            try
            {
                // Filter not loaded
                var query = SHOP_ITENS.Where(x => !x.Value.IsLoaded);
                if (query.Any())
                {
                    // Get all blueprints
                    _bluePrints = null;
                    _voxelDefinitions = null;
                    // Find target blueprint
                    var queryItemBlueprint = query.Where(x => !x.Value.IsBlueprintChecked);
                    while (queryItemBlueprint.Any())
                    {
                        var itemToCheck = queryItemBlueprint.FirstOrDefault();
                        if (!itemToCheck.Value.ForceMinimalPrice)
                        {
                            var idToFind = itemToCheck.Key.DefinitionId;
                            var isBaseOre = idToFind.TypeId == typeof(MyObjectBuilder_Ore) && PlanetMapProfile.AllValidOres.Contains(idToFind.SubtypeName.ToUpper());
                            if (!isBaseOre)
                            {
                                var queryBlueprint = bluePrints.Where(x => x.Results.Any(y => y.Id == idToFind) && !x.Prerequisites.Any(y => y.Id == idToFind));
                                if (queryBlueprint.Any())
                                {
                                    var bluePrintsToChouse = queryBlueprint.OrderBy(x => x.Results.Count()).ToList();
                                    if (bluePrintsToChouse.Any(x => x.IsPrimary))
                                        itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.Where(x => x.IsPrimary).FirstOrDefault();
                                    else
                                        itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.FirstOrDefault();
                                }
                            }
                        }
                        itemToCheck.Value.IsBlueprintChecked = true;
                    }
                    // Check blueprints for base materials
                    var queryItemBaseMaterial = query.Where(x =>
                        x.Value.IsBlueprintChecked &&
                        x.Value.RecipeBlueprint != null &&
                        x.Value.RecipeBlueprint.Prerequisites.Any(y => 
                            !SHOP_ITENS.ContainsKey(new UniqueEntityId(y.Id)) &&
                            !BASE_ITENS.ContainsKey(new UniqueEntityId(y.Id))
                        )
                    );
                    DoCheckForBaseMaterials(queryItemBaseMaterial);
                    // Check base materials blueprints for base materials
                    int index = 1;
                    do
                    {
                        if (ExtendedSurvivalSettings.Instance.Debug)
                            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"DoCalcAllItensInfo: CHECK BASE_ITENS {index}");
                        var queryBaseItemBaseMaterial = BASE_ITENS.Where(x =>
                            !x.Value.IsLoaded &&
                            x.Value.IsBlueprintChecked &&
                            x.Value.RecipeBlueprint != null &&
                            x.Value.RecipeBlueprint.Prerequisites.Any(y =>
                                !SHOP_ITENS.ContainsKey(new UniqueEntityId(y.Id)) &&
                                !BASE_ITENS.ContainsKey(new UniqueEntityId(y.Id))
                            )
                        );
                        DoCheckForBaseMaterials(queryBaseItemBaseMaterial);
                        index++;
                    } while (BASE_ITENS.Any(x =>
                            !x.Value.IsLoaded &&
                            x.Value.IsBlueprintChecked &&
                            x.Value.RecipeBlueprint != null &&
                            x.Value.RecipeBlueprint.Prerequisites.Any(y =>
                                !SHOP_ITENS.ContainsKey(new UniqueEntityId(y.Id)) &&
                                !BASE_ITENS.ContainsKey(new UniqueEntityId(y.Id))
                            )
                        ));
                    // Load values based in the target recipe
                    var queryBaseItens = BASE_ITENS.Where(x => !x.Value.IsLoaded);
                    DoLoadByType(query, typeof(MyObjectBuilder_Ore));
                    DoLoadByType(queryBaseItens, typeof(MyObjectBuilder_Ore));
                    DoLoadByType(query, typeof(MyObjectBuilder_Ingot));
                    DoLoadByType(queryBaseItens, typeof(MyObjectBuilder_Ingot));
                    DoLoadByType(query);
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
            }
        }

        private static void DoLoadByType<T>(IEnumerable<KeyValuePair<UniqueEntityId, T>> baseQuery, Type filter = null) where T : BaseMaterialItem
        {
            var query = filter != null ? baseQuery.Where(x => x.Key.DefinitionId.TypeId == filter) : baseQuery;
            while (query.Any())
            {
                var itemToCheck = query.FirstOrDefault();
                if (GetAndCalcItemInfo(itemToCheck.Key) == null)
                    GetAndCalcBaseItemInfo(itemToCheck.Key);
            }
        }

        private static readonly List<MyDefinitionId> ValueCalcLock = new List<MyDefinitionId>();
        private static float GetBluePrintValue(MyBlueprintDefinitionBase bluePrint, MyPhysicalItemDefinition baseDef)
        {
            float baseValue = 0;
            if (ExtendedSurvivalSettings.Instance.Debug)
                ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : START");
            if (!ValueCalcLock.Contains(baseDef.Id))
            {
                try
                {
                    ValueCalcLock.Add(baseDef.Id);
                    if (bluePrint != null)
                    {
                        foreach (var prerequisite in bluePrint.Prerequisites)
                        {
                            if (!prerequisite.Id.TypeId.IsNull && !string.IsNullOrWhiteSpace(prerequisite.Id.SubtypeId.String))
                            {
                                var targetId = new UniqueEntityId(prerequisite.Id);
                                if (ExtendedSurvivalSettings.Instance.Debug)
                                    ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : {bluePrint.Id} get prerequisite {prerequisite.Id}");
                                var prerequisiteShopItem = GetAndCalcItemInfo(targetId);
                                if (prerequisiteShopItem != null)
                                {
                                    baseValue += (float)prerequisiteShopItem.BaseValue * (float)prerequisite.Amount;
                                }
                                else
                                {
                                    var prerequisiteBaseItem = GetAndCalcBaseItemInfo(targetId);
                                    if (prerequisiteBaseItem != null)
                                    {
                                        baseValue += (float)prerequisiteBaseItem.BaseValue * (float)prerequisite.Amount;
                                    }
                                }
                            }
                            else
                            {
                                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"GetBluePrintValue: {bluePrint.Id} had invalid prerequisite!");
                            }
                        }
                        baseValue *= 1 + (bluePrint.BaseProductionTimeInSeconds / 10);
                    }
                    else
                    {
                        if (baseDef != null)
                        {
                            // Check if is a ore to use time to refine and voxel ratio to influece the value
                            if (baseDef.Id.TypeId == typeof(MyObjectBuilder_Ore) && PlanetMapProfile.AllValidOres.Contains(baseDef.Id.SubtypeName.ToUpper()))
                            {
                                // Get Ratio
                                PlanetProfile.OreRarity rarity = PlanetProfile.OreRarity.Common;
                                float baseRatio = 1;
                                var voxelQuery = voxelDefinitions.Where(x => x.MinedOre == baseDef.Id.SubtypeName);
                                if (voxelQuery.Any())
                                {
                                    baseRatio = voxelQuery.Sum(x => x.MinedOreRatio) / voxelQuery.Count();
                                    rarity = (PlanetProfile.OreRarity)voxelQuery.Max(x => (int)PlanetMapProfile.GetOreMap(x.Id.SubtypeName).rarity);
                                }
                                // Get time to refine
                                float lostFactor = 1;
                                float baseRefineTime = 1;
                                float baseSourceAmount = 0;
                                float baseEndAmount = 0;
                                var refineQuery = bluePrints.Where(x => x.Prerequisites.Any(y => y.Id == baseDef.Id) && x.Prerequisites.Length == 1 && x.Results.Length == 1);
                                if (refineQuery.Any())
                                {
                                    var count = refineQuery.Count();
                                    baseRefineTime += refineQuery.Sum(x => x.BaseProductionTimeInSeconds) / count;
                                    baseSourceAmount = refineQuery.Sum(x => x.Prerequisites.Where(y => y.Id == baseDef.Id).Sum(y => (float)y.Amount)) / count;
                                    baseEndAmount = refineQuery.Sum(x => x.Results.Sum(y => (float)y.Amount) / x.Results.Count()) / count;
                                }
                                if (baseSourceAmount > 0)
                                {
                                    lostFactor += (baseSourceAmount - baseEndAmount) / baseSourceAmount;
                                }
                                // Calculate value
                                baseValue = BASE_ORE_VALUE[rarity];
                                baseValue /= baseRatio;
                                baseValue *= lostFactor;
                                baseValue *= baseRefineTime;
                            }
                            else
                            {
                                baseValue = baseDef.MinimalPricePerUnit;
                            }
                        }
                    }
                    if (ExtendedSurvivalSettings.Instance.Debug)
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : END");
                }
                finally
                {
                    ValueCalcLock.Remove(baseDef.Id);
                }                
            }
            else
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : Avoid stack overflow, maybe recipes got conflicted!");
            }
            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : BASE VALUE = {baseValue}");
            return Math.Max(baseValue, 1);
        }

        private static BaseMaterialItem GetAndCalcBaseItemInfo(UniqueEntityId id)
        {
            if (BASE_ITENS.ContainsKey(id))
            {
                if (!BASE_ITENS[id].IsLoaded)
                {
                    BASE_ITENS[id].BaseValue = (long)GetBluePrintValue(BASE_ITENS[id].RecipeBlueprint, BASE_ITENS[id].Definition);
                    BASE_ITENS[id].IsLoaded = true;
                }
                return BASE_ITENS[id];
            }
            return null;
        }

        private static StationShopItem GetAndCalcItemInfo(UniqueEntityId id)
        {
            if (SHOP_ITENS.ContainsKey(id))
            {
                if (!SHOP_ITENS[id].IsLoaded)
                {
                    SHOP_ITENS[id].BaseValue = (long)GetBluePrintValue(SHOP_ITENS[id].RecipeBlueprint, SHOP_ITENS[id].Definition);
                    SHOP_ITENS[id].IsLoaded = true;
                }
                return SHOP_ITENS[id];
            }
            return null;
        }

        public static string GetFactionName(FactionType type, out string tag)
        {
            var first = FIRST_NAMES.OrderBy(x => GetRandomDouble()).FirstOrDefault();
            var middle = MIDDLE_NAMES.OrderBy(x => GetRandomDouble()).FirstOrDefault();
            var last = LAST_NAMES.OrderBy(x => GetRandomDouble()).FirstOrDefault();
            tag = (FACTION_PREFIX[type] + new string(new char[] { first[0], middle[0], last[0] })).ToUpper();
            return $"{first} {middle} {last}";
        }

        public static string GetStationName()
        {
            return FIRST_NAMES.Concat(LAST_NAMES).OrderBy(x => GetRandomDouble()).FirstOrDefault();
        }

        public static string GetFactionDesc(FactionType type)
        {
            return FACTION_DESCS[type].OrderBy(x => GetRandomDouble()).FirstOrDefault();
        }

        private static double GetRandomDouble(double max = 1f)
        {
            return MyUtils.GetRandomDouble(0f, max);
        }

        public static void DoCycle()
        {
            try
            {
                if (ExtendedSurvivalEntityManager.Instance != null)
                {
                    var query = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.Stations.Any());
                    if (query.Any())
                    {
                        foreach (var member in query)
                        {
                            if (member.Stations.Any())
                            {
                                foreach (var station in member.Stations)
                                {
                                    if (station.StationEntityId == 0 && !station.IsSpawning)
                                    {
                                        if (ExtendedSurvivalEntityManager.Instance.AnyInRange(station.Position, SPAWN_DISTANCE))
                                        {
                                            try
                                            {
                                                station.IsSpawning = true;
                                                var faction = MyAPIGateway.Session.Factions.TryGetFactionById(station.FactionId);
                                                var options = SpawningOptions.UseOnlyWorldMatrix | SpawningOptions.SetAuthorship;
                                                var gridListDummy = new List<IMyCubeGrid>();
                                                MyAPIGateway.PrefabManager.SpawnPrefab(
                                                    gridListDummy,
                                                    station.PrefabName,
                                                    station.Position + (station.Up * (0.025f + station.PrefabUpIncrement)),
                                                    station.Foward,
                                                    station.Up,
                                                    Vector3.Zero,
                                                    Vector3.Zero,
                                                    faction.Tag + " Station",
                                                    options,
                                                    faction.FounderId,
                                                    true,
                                                    () =>
                                                    {
                                                        var grid = gridListDummy.FirstOrDefault();
                                                        if (grid != null)
                                                        {
                                                            grid.IsStatic = true;
                                                            station.StationEntityId = grid.EntityId;
                                                            var safeDef = new MyObjectBuilder_SafeZone();
                                                            safeDef.EntityId = 0;
                                                            safeDef.PositionAndOrientation = new VRage.MyPositionAndOrientation(station.Position, station.Up, station.Foward);
                                                            safeDef.Radius = 150;
                                                            safeDef.AccessTypeFactions = MySafeZoneAccess.Blacklist;
                                                            safeDef.AccessTypePlayers = MySafeZoneAccess.Blacklist;
                                                            safeDef.AccessTypeFloatingObjects = MySafeZoneAccess.Blacklist;
                                                            safeDef.AccessTypeGrids = MySafeZoneAccess.Blacklist;
                                                            safeDef.Factions = new long[] { };
                                                            safeDef.Players = new long[] { };
                                                            safeDef.Entities = new long[] { };
                                                            safeDef.Enabled = true;
                                                            safeDef.Shape = MySafeZoneShape.Sphere;
                                                            var safeZone = new MySafeZone();
                                                            safeZone.Init(safeDef);
                                                            station.SafeZoneEntityId = safeZone.EntityId;
                                                            MyEntities.Add(safeZone, false);
                                                            if (!station.FirstContact || 
                                                                station.ComercialTick < ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick ||
                                                                !station.ShopItems.Any())
                                                            {
                                                                DoBuildShopItens(station);
                                                                station.FirstContact = true;
                                                            }
                                                            else
                                                            {
                                                                DoApplyItensToGrid(station);
                                                            }
                                                        }
                                                        station.IsSpawning = false;
                                                    }
                                                );
                                            }
                                            catch (Exception ex)
                                            {
                                                station.IsSpawning = false;
                                                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
                                            }
                                        }
                                    }
                                    else if (station.StationEntityId != 0)
                                    {
                                        if (!ExtendedSurvivalEntityManager.Instance.AnyInRange(station.Position, SPAWN_DISTANCE, station.StationEntityId))
                                        {
                                            try
                                            {
                                                SaveStationStoreChange(station);
                                                var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
                                                if (entity != null)
                                                {
                                                    entity.Entity.Close();
                                                    var safeZone = ExtendedSurvivalEntityManager.GetSafeZoneById(station.SafeZoneEntityId);
                                                    if (safeZone != null)
                                                        safeZone.Close();
                                                    station.StationEntityId = 0;
                                                    station.SafeZoneEntityId = 0;
                                                    station.CargoContainerEntityId = 0;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
            }
        }

        public static void SaveStations()
        {
            var stations = ExtendedSurvivalStorage.Instance.StarSystem.GetStations();
            foreach (var station in stations)
            {
                SaveStationStoreChange(station);
            }
        }

        public static void SaveStationStoreChange(StarSystemMemberStationStorage station)
        {
            var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
            if (entity != null)
            {
                if (entity._blocksById.ContainsKey(STOREBLOCK_ID))
                {
                    var storeBlock = entity._blocksById[STOREBLOCK_ID].FirstOrDefault().FatBlock as IMyStoreBlock;
                    if (storeBlock != null)
                    {
                        List<IMyStoreItem> items = new List<IMyStoreItem>();
                        storeBlock.GetStoreItems(items);
                        var checkList = station.ShopItems.ToArray();
                        foreach (var item in checkList)
                        {
                            var targetSoreType = item.IsSelling ? StoreItemTypes.Offer : StoreItemTypes.Order;
                            var query = items.Where(x => x.Item.HasValue && (MyDefinitionId)x.Item.Value == item.Id && x.StoreItemType == targetSoreType);
                            if (query.Any() && query.First().Amount > 0)
                            {
                                item.Amount = query.First().Amount;
                            }
                            else
                            {
                                station.ShopItems.Remove(item);
                            }
                        }
                    }
                }
            }
        }

        private static float GetAmountWithMultiplier(float baseValue, MyDefinitionId id)
        {
            if (id.TypeId == typeof(MyObjectBuilder_Ore) || id.TypeId == typeof(MyObjectBuilder_Ingot))
                return baseValue * ORE_INGOT_AMOUNT_MULTIPLIER.GetRandom();
            if (id.TypeId == typeof(MyObjectBuilder_GasContainerObject) || id.TypeId == typeof(MyObjectBuilder_OxygenContainerObject))
                return baseValue * GASCONTAINER_AMOUNT_MULTIPLIER.GetRandom();
            return baseValue;
        }

        public static void DoBuildShopItens(StarSystemMemberStationStorage station)
        {
            var faction = ExtendedSurvivalStorage.Instance.GetFaction(station.FactionId);
            if (faction != null)
            {
                station.ShopItems.Clear();
                var factionType = (FactionType)faction.FactionType;
                var stationLevel = (StationLevel)station.StationLevel;
                var countToBuy = STATION_ITENS_PROFILE[stationLevel].BuyItensCount.GetRandomInt();
                var countToSell = STATION_ITENS_PROFILE[stationLevel].SellItensCount.GetRandomInt();
                var itensQuery = SHOP_ITENS.Values.Where(x => x.TargetFactions.Contains(factionType) && STATION_ITENS_PROFILE[stationLevel].CanSellRarity.Contains(x.Rarity));
                if (itensQuery.Any())
                {
                    // BUY Item List
                    var itensToBuyQuery = itensQuery.Where(x => x.CanBuy);
                    if (itensToBuyQuery.Any())
                    {
                        if (itensToBuyQuery.Count() <= countToBuy)
                        {
                            foreach (var item in itensToBuyQuery)
                            {
                                station.ShopItems.Add(new StarSystemStationShopItemStorage() 
                                { 
                                    Id = item.Id.DefinitionId,
                                    Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[item.Rarity].GetRandom(), item.Id.DefinitionId),
                                    Price = (long)((float)item.BaseValue * STATION_BUY_VALUE_MULTIPLIER.GetRandom())
                                });
                            }
                        }
                        else
                        {
                            var queryCheck = station.ShopItems.Where(x => !x.IsSelling);
                            while (queryCheck.Count() < countToBuy)
                            {
                                var itemToUse = itensToBuyQuery.Where(x => !queryCheck.Any(y => y.Id == x.Id.DefinitionId)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                if (itemToUse == null)
                                    break;
                                station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                {
                                    Id = itemToUse.Id.DefinitionId,
                                    Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[itemToUse.Rarity].GetRandom(), itemToUse.Id.DefinitionId),
                                    Price = (long)((float)itemToUse.BaseValue * STATION_BUY_VALUE_MULTIPLIER.GetRandom())
                                });
                            }
                        }
                    }
                    // SELL Item List
                    var itensToSellQuery = itensQuery.Where(x => x.CanSell);
                    if (itensToSellQuery.Any())
                    {
                        if (itensToSellQuery.Count() <= countToSell)
                        {
                            foreach (var item in itensToSellQuery)
                            {
                                station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                {
                                    Id = item.Id.DefinitionId,
                                    Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[item.Rarity].GetRandom(), item.Id.DefinitionId),
                                    Price = item.BaseValue,
                                    IsSelling = true
                                });
                            }
                        }
                        else
                        {
                            var queryCheck = station.ShopItems.Where(x => x.IsSelling);
                            while (queryCheck.Count() < countToSell)
                            {
                                var itemToUse = itensToSellQuery.Where(x => !queryCheck.Any(y => y.Id == x.Id.DefinitionId)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                if (itemToUse == null)
                                    break;
                                station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                {
                                    Id = itemToUse.Id.DefinitionId,
                                    Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[itemToUse.Rarity].GetRandom(), itemToUse.Id.DefinitionId),
                                    Price = itemToUse.BaseValue,
                                    IsSelling = true
                                });
                            }
                        }
                    }
                }
            }
            station.ComercialTick = ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick;
            if (station.StationEntityId != 0)
            {
                DoApplyItensToGrid(station);
            }
        }

        private static void DoApplyItensToGrid(StarSystemMemberStationStorage station)
        {
            var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
            if (entity != null)
            {
                if (entity._blocksByType.ContainsKey(typeof(MyObjectBuilder_OxygenGenerator)))
                {
                    foreach (var block in entity._blocksByType[typeof(MyObjectBuilder_OxygenGenerator)])
                    {
                         var o2Generator = block.FatBlock as IMyGasGenerator;
                        if (o2Generator != null)
                        {
                            var inventory = o2Generator.GetInventory();
                            if (inventory != null)
                            {
                                var maxToAdd = (float)inventory.MaxVolume * 1000f / 0.35f;
                                inventory.AddMaxItems(maxToAdd, ItensConstants.GetPhysicalObjectBuilder(OreConstants.ICE_ID));
                                o2Generator.Enabled = true;
                            }
                            else
                            {
                                o2Generator.Enabled = false;
                            }
                        }
                    }
                }
                if (entity._blocksByType.ContainsKey(typeof(MyObjectBuilder_BatteryBlock)))
                {
                    foreach (var block in entity._blocksByType[typeof(MyObjectBuilder_BatteryBlock)])
                    {
                        var battery = block.FatBlock as MyBatteryBlock;
                        if (battery != null)
                        {
                            battery.CurrentStoredPower = battery.MaxStoredPower;
                        }
                    }
                }
                if (entity._blocksById.ContainsKey(STOREBLOCK_ID) && entity._blocksById.ContainsKey(LARGEBLOCKLARGECONTAINER_ID))
                {
                    var storeBlock = entity._blocksById[STOREBLOCK_ID].FirstOrDefault().FatBlock as IMyStoreBlock;
                    var cargoContainer = entity._blocksById[LARGEBLOCKLARGECONTAINER_ID].FirstOrDefault().FatBlock as IMyCargoContainer;
                    if (storeBlock != null && cargoContainer != null)
                    {
                        var inventory = cargoContainer.GetInventory();
                        if (inventory != null)
                        {
                            station.CargoContainerEntityId = cargoContainer.EntityId;
                            var observer = MyInventoryObserverProgressController.Get(cargoContainer.EntityId, 0);
                            if (observer != null)
                            {
                                observer.SpoilEnabled = false;
                            }
                            inventory.Clear();
                            // Clear the store
                            List<IMyStoreItem> items = new List<IMyStoreItem>();
                            storeBlock.GetStoreItems(items);
                            foreach (var item in items)
                            {
                                storeBlock.RemoveStoreItem(item);
                            }
                            // Add item to store
                            foreach (var shopItem in station.ShopItems)
                            {
                                if (shopItem.IsSelling)
                                {
                                    var finalAmount = inventory.AddMaxItems(shopItem.Amount, ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(shopItem.Id)));
                                    var item = storeBlock.CreateStoreItem(shopItem.Id, (int)finalAmount, (int)shopItem.Price, StoreItemTypes.Offer);
                                    storeBlock.InsertStoreItem(item);
                                }
                                else
                                {
                                    var item = storeBlock.CreateStoreItem(shopItem.Id, (int)shopItem.Amount, (int)shopItem.Price, StoreItemTypes.Order);
                                    storeBlock.InsertStoreItem(item);
                                }
                                
                            }
                        }
                    }
                }
            }
        }

    }

}