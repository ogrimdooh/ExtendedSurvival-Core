using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Blocks;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class SpaceStationController
    {

        public static string GetFactionTypeName(FactionType type)
        {
            switch (type)
            {
                case FactionType.Miner:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_MINER);
                case FactionType.Lumber:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_LUMBER);
                case FactionType.Shipyard:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_SHIPYARD);
                case FactionType.Armory:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_ARMORY);
                case FactionType.Trader:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_TRADER);
                case FactionType.Farming:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_FARMING);
                case FactionType.Livestock:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_LIVESTOCK);
                case FactionType.Market:
                    return LanguageProvider.GetEntry(LanguageEntries.FACTIONTYPE_MARKET);
                default:
                    return "";
            }
        }

        public static string GetItemRarityName(ItemRarity rarity)
        {
            switch (rarity)
            {
                case ItemRarity.Common:
                    return LanguageProvider.GetEntry(LanguageEntries.ITEMRARITY_COMMON);
                case ItemRarity.Uncommon:
                    return LanguageProvider.GetEntry(LanguageEntries.ITEMRARITY_UNCOMMON);
                case ItemRarity.Normal:
                    return LanguageProvider.GetEntry(LanguageEntries.ITEMRARITY_NORMAL);
                case ItemRarity.Rare:
                    return LanguageProvider.GetEntry(LanguageEntries.ITEMRARITY_RARE);
                case ItemRarity.Epic:
                    return LanguageProvider.GetEntry(LanguageEntries.ITEMRARITY_EPIC);
                default:
                    return "";
            }
        }

        public static int SPAWN_DISTANCE = 10000;

        public static readonly Vector2 STATION_BUY_VALUE_MULTIPLIER = new Vector2(0.65f, 0.75f);
        public static readonly Vector2 STATION_ORDER_VALUE_MULTIPLIER = new Vector2(0.75f, 0.85f);
        public static readonly Vector2 STATION_SELL_VALUE_MULTIPLIER = new Vector2(1.25f, 1.35f);

        public const int DEFAULT_COLLATERAL_CONTRACT = 20;
        public const int DEFAULT_DURATION_CONTRACT = 600;

        public const string STOREBLOCK_SUBTYPEID = "StoreBlock";
        public static readonly UniqueEntityId STOREBLOCK_ID = new UniqueEntityId(typeof(MyObjectBuilder_StoreBlock), STOREBLOCK_SUBTYPEID);

        public const string CONTRACTBLOCK_SUBTYPEID = "ContractBlock";
        public static readonly UniqueEntityId CONTRACTBLOCK_ID = new UniqueEntityId(typeof(MyObjectBuilder_ContractBlock), CONTRACTBLOCK_SUBTYPEID);

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

            public float BaseValue { get; set; }
            public ConcurrentDictionary<string, float> Composition { get; set; } = new ConcurrentDictionary<string, float>();

            public long GetValue(StarSystemMemberStationStorage station, bool buy, float modifier = 1f)
            {
                var finalValue = BaseValue;
                if (Composition.Any())
                {
                    var member = station.GetMember();
                    if (member != null)
                    {
                        PlanetEntity nearPlanet = null;
                        float distanceToPlanet = 0;
                        if (member.IsPlanet)
                        {
                            nearPlanet = member.Planet;
                            if (station.IsOrbitalStation && nearPlanet != null)
                            {
                                distanceToPlanet = (float)Vector3D.Distance(station.Position, nearPlanet.SurfaceAtPosition(station.Position));
                            }
                        }
                        else if (member.IsAsteroidBelt)
                        {
                            nearPlanet = ExtendedSurvivalEntityManager.GetPlanetAtRange(station.Position);
                            if (nearPlanet != null)
                            {
                                distanceToPlanet = (float)Vector3D.Distance(station.Position, nearPlanet.Center());
                            }
                        }
                        if (nearPlanet != null && nearPlanet.Setting != null)
                        {
                            var voxelTypes = nearPlanet.Setting.OreMap.Select(x => x.Type).Distinct().ToArray();
                            var ores = voxelTypes.Select(x => MyDefinitionManager.Static.GetVoxelMaterialDefinition(x)).Where(x => x != null).Select(x => x.MinedOre.ToUpper()).ToArray();
                            var pEasy = Composition.Where(x => ores.Contains(x.Key)).Sum(x => x.Value);
                            var pHard = Composition.Values.Sum() - pEasy;
                            var eValue = (finalValue * pEasy) / (buy ? 5f : 7.5f);
                            var hValue = (finalValue * pHard) / (buy ? 1.25f : 2.5f);
                            var dValue = finalValue * (distanceToPlanet / 100000000);
                            finalValue -= eValue;
                            finalValue += hValue;
                            finalValue += dValue;
                        }
                    }
                }
                return (long)(finalValue * modifier);
            }

        }

        public class StationShopItem : BaseMaterialItem
        {

            public ItemRarity Rarity { get; set; }
            public FactionType[] TargetFactions { get; set; }
            public bool CanBuy { get; set; }
            public bool CanSell { get; set; }
            public bool CanOrder { get; set; }

            public void DoForceDefinition()
            {
                Definition.CanPlayerOrder = CanOrder;
                Definition.MinimalPricePerUnit = (int)BaseValue;
            }

        }

        [Flags]
        public enum StationPrefabFlag
        {

            None = 0,
            Rover = 1 << 1,
            IonThruster = 1 << 2,
            H2Thruster = 1 << 3,
            AtmThruster = 1 << 4,
            LargeGrid = 1 << 5,
            SmallGrid = 1 << 6,
            Reactor = 1 << 7,
            JumpDrive = 1 << 8

        }

        [Flags]
        public enum StationPrefabCategory
        {

            None = 0,
            Tiny = 1 << 1,
            Small = 1 << 2,
            Medium = 1 << 3,
            Big = 1 << 4,
            Huge = 1 << 5,

            TinyToMedium = Tiny | Small | Medium,
            TinyToBig = Tiny | Small | Medium | Big,
            All = Tiny | Small | Medium | Big | Huge

        }

        public class StationPrefabItem
        {

            public string PrefabName { get; set; }
            public MyPrefabDefinition Definition { get; set; }

            public bool IsLoaded { get; set; }
            public StationPrefabFlag Flags { get; set; }
            public StationPrefabCategory Category { get; set; }
            public long BlockCount { get; set; }
            public long TotalPCU { get; set; }

            public bool IsValid { get; set; }
            public float BaseValue { get; set; }

        }

        public struct StationItensAmountProfile
        {

            public Vector2I PrefabsCount;
            public Vector2I SellItensCount;
            public Vector2I BuyItensCount;
            public Vector2I AcquisitionContractsCount;
            public ItemRarity[] CanSellRarity;

        }

        public struct StationPrefabFilter
        {

            public StationPrefabFlag excludeFlags;
            public StationPrefabFlag requiredFlags;
            public StationPrefabCategory validCategories;

        }

        public static readonly ConcurrentDictionary<UniqueEntityId, StationShopItem> SHOP_ITENS = new ConcurrentDictionary<UniqueEntityId, StationShopItem>();
        public static readonly ConcurrentDictionary<UniqueEntityId, BaseMaterialItem> BASE_ITENS = new ConcurrentDictionary<UniqueEntityId, BaseMaterialItem>();

        // PG = 25.15 * 1.95 (5-1)
        public static readonly Dictionary<PlanetProfile.OreRarity, float> BASE_ORE_VALUE = new Dictionary<PlanetProfile.OreRarity, float>()
        {
            { PlanetProfile.OreRarity.None, 5.75f },
            { PlanetProfile.OreRarity.Common, 12.94f },
            { PlanetProfile.OreRarity.Uncommon, 29.11f },
            { PlanetProfile.OreRarity.Rare, 65.50f },
            { PlanetProfile.OreRarity.Epic, 147.37f }
        };

        public static readonly Dictionary<ItemRarity, Vector2> ITEM_RARITY_AMOUNT = new Dictionary<ItemRarity, Vector2>()
        {
            { ItemRarity.Common, new Vector2(64, 128) },
            { ItemRarity.Uncommon, new Vector2(32, 64) },
            { ItemRarity.Normal, new Vector2(16, 32) },
            { ItemRarity.Rare, new Vector2(8, 16) },
            { ItemRarity.Epic, new Vector2(4, 8) },
        };

        public static readonly Vector2 ORE_INGOT_AMOUNT_MULTIPLIER = new Vector2(5, 25);
        public static readonly Vector2 GASCONTAINER_AMOUNT_MULTIPLIER = new Vector2(0.25f, 0.5f);

        public static readonly Dictionary<KeyValuePair<StationType, StationLevel>, StationPrefabFilter> STATION_PREFAB_FILTERS = new Dictionary<KeyValuePair<StationType, StationLevel>, StationPrefabFilter>
        {
            {
                new KeyValuePair<StationType, StationLevel>(StationType.Outpost, StationLevel.Small),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.Reactor | StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.Outpost, StationLevel.Medium),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.Outpost, StationLevel.Large),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.All
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.OrbitalStation, StationLevel.Small),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.Rover | StationPrefabFlag.Reactor | StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.OrbitalStation, StationLevel.Medium),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.Rover | StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.OrbitalStation, StationLevel.Large),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.All,
                    excludeFlags = StationPrefabFlag.Rover
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.SpaceStation, StationLevel.Small),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.Rover | StationPrefabFlag.Reactor | StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.SpaceStation, StationLevel.Medium),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.TinyToMedium,
                    excludeFlags = StationPrefabFlag.Rover | StationPrefabFlag.JumpDrive
                }
            },
            {
                new KeyValuePair<StationType, StationLevel>(StationType.SpaceStation, StationLevel.Large),
                new StationPrefabFilter()
                {
                    validCategories = StationPrefabCategory.All,
                    excludeFlags = StationPrefabFlag.Rover
                }
            }
        };

        public static readonly Dictionary<StationLevel, StationItensAmountProfile> STATION_ITENS_PROFILE = new Dictionary<StationLevel, StationItensAmountProfile>()
        {
            {
                StationLevel.Small,
                new StationItensAmountProfile()
                {
                    PrefabsCount = new Vector2I(2, 4),
                    BuyItensCount = new Vector2I(5, 10),
                    SellItensCount = new Vector2I(5, 10),
                    AcquisitionContractsCount = new Vector2I(5, 10),
                    CanSellRarity = new ItemRarity[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Normal }
                }
            },
            {
                StationLevel.Medium,
                new StationItensAmountProfile()
                {
                    PrefabsCount = new Vector2I(3, 6),
                    BuyItensCount = new Vector2I(10, 15),
                    SellItensCount = new Vector2I(10, 15),
                    AcquisitionContractsCount = new Vector2I(10, 15),
                    CanSellRarity = new ItemRarity[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Normal, ItemRarity.Rare }
                }
            },
            {
                StationLevel.Large,
                new StationItensAmountProfile()
                {
                    PrefabsCount = new Vector2I(4, 8),
                    BuyItensCount = new Vector2I(15, 20),
                    SellItensCount = new Vector2I(15, 20),
                    AcquisitionContractsCount = new Vector2I(15, 20),
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
                    new StationPrefabInfo("Economy_OrbitalStation_6")//,
                    //new StationPrefabInfo("Economy_OrbitalStation_7") has no cargo container
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

        public static readonly string[] PREFABS_TO_SELL = new string[] 
        {
            "ATV-Survivor",
            "Fighter2",
            "MinerSmallShip",
            "Civic Hauler",
            "Cursor",
            "Buddy Miner",
            "Atmo Constructor",
            "Scout Miner",
            "Solar Scout",
            "Aggressive Miner",
            "Gerbil Miner",
            "Ion Constructor",
            "Kite Miner",
            "Ion Light Scout",
            "Ion Tug Ship",
            "Turtle Miner",
            "U-92 Patrol Craft",
            "Lunar Scout mk.4",
            "LCC-3 Freighter",
            "Burstfire Bomber",
            "Hydro Scout Rover",
            "Lunar Scout mk.2",
            "T-Ion Fade",
            "Blue Ambassador Explorer",
            "Red Cruiser",
            "Rescue Rover 1",
            "TT-15 Freighter",
            "RespawnSpacePod",
            "RespawnShip",
            "B-980 Hauler",
            "TT-420 Freighter",
            "J-Class Courier",
            "B-60 Bulk Freighter",
            "H-01 Prospector",
            "H-01 Sapper",
            "PV-4 Buggy",
            "MiniMerchant",
            "Cargo Shuttle"
        };

        public static readonly ConcurrentDictionary<string, StationPrefabItem> LOADED_PREFABS_TO_SELL = new ConcurrentDictionary<string, StationPrefabItem>();

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
            "Nation",
            "Stoyer",
            "Newcorp",
            "Berrett",
            "Myshkin",
            "Rosek",
            "Sonoda",
            "NanoDev",
            "TeraTek",
            "Omegadev"
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
            "Elders",
            "Diversified",
            "Heavy",
            "Light",
            "Multinational",
            "Development",
            "Transport",
            "Integrated",
            "Evolved",
            "Biotech",
            "Advanced",
            "Specialized",
            "Consolidated",
            "Productions",
            "Global",
            "Engineering",
            "Financial"
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
            "Vega",
            "Armament",
            "Cybernetics",
            "Entertainment",
            "Media",
            "Communications",
            "Security",
            "Industrial",
            "Financial"
        };

        static SpaceStationController()
        {
            // Lumber
            AddItemToShop(ItensConstants.WOODLOG_ID, ItemRarity.Common, true, true, true, true, FactionType.Lumber);
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
            // Add prefabs
            foreach (var item in PREFABS_TO_SELL)
            {
                AddPrefabToShop(item);
            }
            SelfLoaded = true;
            MarkAsAllItensLoaded(0);
        }

        private static bool SelfLoaded = false;
        private static bool TechnologyLoaded = false;
        private static bool StatsAndEffectsLoaded = false;

        public static bool IsAllLoaded
        {
            get
            {
                return SelfLoaded && TechnologyLoaded && StatsAndEffectsLoaded;
            }
        }

        public static event Action OnAllLoaded;

        public static void MarkAsAllItensLoaded(ulong modId)
        {
            if (!TechnologyLoaded)
                TechnologyLoaded = !ExtendedSurvivalCoreSession.IsUsingTechnology() || modId == ExtendedSurvivalCoreSession.ES_TECHNOLOGY_MODID;
            if (!StatsAndEffectsLoaded)
                StatsAndEffectsLoaded = !ExtendedSurvivalCoreSession.IsUsingStatsAndEffects() || modId == ExtendedSurvivalCoreSession.ES_STATS_EFFECTS_MODID;
            if (IsAllLoaded)
            {
                if (MyAPIGateway.Session.IsServer)
                    DoCalcAllItensInfo();
                OnAllLoaded?.Invoke();
            }
        }

        public static bool ChangeItemRarity(UniqueEntityId id, ItemRarity rarity)
        {
            if (SHOP_ITENS.ContainsKey(id))
            {
                SHOP_ITENS[id].Rarity = rarity;
                if (ExtendedSurvivalSettings.Instance.Debug)
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"ChangeItemRarity: Item {id.DefinitionId} rarity change to {rarity}.");
                return true;
            }
            ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"ChangeItemRarity: Item {id.DefinitionId} not found.");
            return false;
        }

        public static bool AddPrefabToShop(string prefabName)
        {
            if (!LOADED_PREFABS_TO_SELL.ContainsKey(prefabName))
            {                
                var def = MyDefinitionManager.Static.GetPrefabDefinition(prefabName);
                if (def != null)
                {
                    LOADED_PREFABS_TO_SELL[prefabName] = new StationPrefabItem()
                    {
                        PrefabName = prefabName,
                        Definition = def
                    };
                    return true;
                }
                else
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"AddPrefabToShop: Prefab {prefabName} has no definition.");
                }
            }
            ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"AddPrefabToShop: Prefab {prefabName} already registered.");
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
                        if (ExtendedSurvivalSettings.Instance.Debug)
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
                                var queryBlueprint = bluePrints.Where(x => 
                                    x.Results.Any(y => y.Id == idToFind) && 
                                    !x.Prerequisites.Any(y => y.Id == idToFind
                                ));
                                if (queryBlueprint.Any())
                                {
                                    if (queryBlueprint.Count() > 1)
                                    {
                                        var newQuery = queryBlueprint.Where(x => !x.Id.SubtypeName.StartsWith("Position"));
                                        if (newQuery.Any())
                                            queryBlueprint = newQuery;
                                    }
                                    var bluePrintsToChouse = queryBlueprint.OrderBy(x => x.Results.Count()).ToList();
                                    if (bluePrintsToChouse.Any(x => x.IsPrimary))
                                        itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.Where(x => x.IsPrimary).FirstOrDefault();
                                    else
                                        itemToCheck.Value.RecipeBlueprint = bluePrintsToChouse.FirstOrDefault();
                                }
                                if (ExtendedSurvivalSettings.Instance.Debug)
                                    ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"DoCalcAllItensInfo: USE {itemToCheck.Value.RecipeBlueprint?.Id} TO {idToFind}");
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
                    LoadPrefabsToSell();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
            }
        }

        private static void LoadPrefabsToSell()
        {
            try
            {
                // Filter not loaded
                var query = LOADED_PREFABS_TO_SELL.Where(x => !x.Value.IsLoaded);
                if (query.Any())
                {
                    while (query.Any())
                    {
                        var prefabToCheck = query.FirstOrDefault().Value;
                        foreach (var grid in prefabToCheck.Definition.CubeGrids)
                        {
                            switch (grid.GridSizeEnum)
                            {
                                case MyCubeSize.Large:
                                    prefabToCheck.Flags |= StationPrefabFlag.LargeGrid;
                                    break;
                                case MyCubeSize.Small:
                                    prefabToCheck.Flags |= StationPrefabFlag.SmallGrid;
                                    break;
                            }
                            prefabToCheck.BlockCount += grid.CubeBlocks.Count;
                            prefabToCheck.TotalPCU += grid.CubeBlocks.Sum(x => MyDefinitionManager.Static.GetCubeBlockDefinition(x.GetId()).PCU);
                            if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_Reactor)))
                                prefabToCheck.Flags |= StationPrefabFlag.Reactor;
                            if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_JumpDrive)))
                                prefabToCheck.Flags |= StationPrefabFlag.JumpDrive;
                            if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_MotorSuspension)))
                                prefabToCheck.Flags |= StationPrefabFlag.Rover;
                            if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_Thrust)))
                            {
                                if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_Thrust) && IsAtmThruster(MyDefinitionManager.Static.GetCubeBlockDefinition(x.GetId()))))
                                    prefabToCheck.Flags |= StationPrefabFlag.AtmThruster;
                                if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_Thrust) && IsH2Thruster(MyDefinitionManager.Static.GetCubeBlockDefinition(x.GetId()))))
                                    prefabToCheck.Flags |= StationPrefabFlag.H2Thruster;
                                if (grid.CubeBlocks.Any(x => x.TypeId == typeof(MyObjectBuilder_Thrust) && IsIonThruster(MyDefinitionManager.Static.GetCubeBlockDefinition(x.GetId()))))
                                    prefabToCheck.Flags |= StationPrefabFlag.IonThruster;
                            }
                        }
                        if (prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.SmallGrid) && !prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.LargeGrid))
                        {
                            if (prefabToCheck.BlockCount > 3000)
                                prefabToCheck.Category = StationPrefabCategory.Huge;
                            else if (prefabToCheck.BlockCount >= 1000 && prefabToCheck.BlockCount < 3000)
                                prefabToCheck.Category = StationPrefabCategory.Big;
                            else if (prefabToCheck.BlockCount >= 500 && prefabToCheck.BlockCount < 1000)
                                prefabToCheck.Category = StationPrefabCategory.Medium;
                            else if (prefabToCheck.BlockCount >= 250 && prefabToCheck.BlockCount < 500)
                                prefabToCheck.Category = StationPrefabCategory.Small;
                            else
                                prefabToCheck.Category = StationPrefabCategory.Tiny;
                        } 
                        else 
                        {
                            if (prefabToCheck.BlockCount > 1500)
                                prefabToCheck.Category = StationPrefabCategory.Huge;
                            else if (prefabToCheck.BlockCount >= 750 && prefabToCheck.BlockCount < 1500)
                                prefabToCheck.Category = StationPrefabCategory.Big;
                            else if (prefabToCheck.BlockCount >= 300 && prefabToCheck.BlockCount < 750)
                                prefabToCheck.Category = StationPrefabCategory.Medium;
                            else if (prefabToCheck.BlockCount >= 100 && prefabToCheck.BlockCount < 300)
                                prefabToCheck.Category = StationPrefabCategory.Small;
                            else
                                prefabToCheck.Category = StationPrefabCategory.Tiny;
                        }
                        prefabToCheck.IsValid = prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.Rover) ||
                            prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.AtmThruster) ||
                            prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.H2Thruster) ||
                            prefabToCheck.Flags.IsFlagSet(StationPrefabFlag.IonThruster);
                        if (prefabToCheck.IsValid)
                        {
                            foreach (var grid in prefabToCheck.Definition.CubeGrids)
                            {
                                foreach (var block in grid.CubeBlocks)
                                {
                                    if (block.TypeId == typeof(MyObjectBuilder_BatteryBlock))
                                    {
                                        var blockDef = block as MyObjectBuilder_BatteryBlock;
                                        if (blockDef != null)
                                        {
                                            if (_blockMaxStoredPower.ContainsKey(block.GetId()))
                                            {
                                                blockDef.CurrentStoredPower = _blockMaxStoredPower[block.GetId()];
                                            }
                                            else
                                            {
                                                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(block.GetId()) as MyBatteryBlockDefinition;
                                                if (def != null)
                                                {
                                                    _blockMaxStoredPower[block.GetId()] = def.MaxStoredPower;
                                                    blockDef.CurrentStoredPower = _blockMaxStoredPower[block.GetId()];
                                                }
                                            }
                                        }
                                    }
                                    prefabToCheck.BaseValue += GetCubeBlockBaseValue(block.GetId());
                                }
                            }
                        }
                        prefabToCheck.IsLoaded = true;
                        if (ExtendedSurvivalSettings.Instance.Debug)
                            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"LoadPrefabsToSell: {prefabToCheck.PrefabName} : BASE VALUE = {prefabToCheck.BaseValue}");
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
            }
        }

        private static readonly ConcurrentDictionary<MyDefinitionId, float> _blockMaxStoredPower = new ConcurrentDictionary<MyDefinitionId, float>();
        private static readonly ConcurrentDictionary<MyDefinitionId, float> _blockValues = new ConcurrentDictionary<MyDefinitionId, float>();
        private static float GetCubeBlockBaseValue(MyDefinitionId blockId)
        {
            if (_blockValues.ContainsKey(blockId))
                return _blockValues[blockId];
            var def = MyDefinitionManager.Static.GetCubeBlockDefinition(blockId);
            float value = 0;
            if (def != null)
            {
                var components = def.Components.GroupBy(x => x.Definition.Id).ToDictionary(x => x.Key, x => x.Sum(y => y.Count));
                foreach (var compId in components.Keys)
                {
                    var itemCalculated = GetItemInfo(new UniqueEntityId(compId));
                    if (itemCalculated != null)
                    {
                        value += itemCalculated.BaseValue * components[compId];
                    }
                }
            }
            _blockValues[blockId] = value;
            return Math.Max(value, 1);
        }

        private static bool IsAtmThruster(MyCubeBlockDefinition blockDef)
        {
            var thrusterDef = blockDef as MyThrustDefinition;
            if (thrusterDef != null)
            {
                var useFuel = thrusterDef.FuelConverter != null && !thrusterDef.FuelConverter.FuelId.IsNull();
                return thrusterDef.NeedsAtmosphereForInfluence && !useFuel;
            }
            return false;
        }

        private static bool IsH2Thruster(MyCubeBlockDefinition blockDef)
        {
            var thrusterDef = blockDef as MyThrustDefinition;
            if (thrusterDef != null)
            {
                return thrusterDef.FuelConverter != null && !thrusterDef.FuelConverter.FuelId.IsNull();
            }
            return false;
        }

        private static bool IsIonThruster(MyCubeBlockDefinition blockDef)
        {
            var thrusterDef = blockDef as MyThrustDefinition;
            if (thrusterDef != null)
            {
                var useFuel = thrusterDef.FuelConverter != null && !thrusterDef.FuelConverter.FuelId.IsNull();
                return !thrusterDef.NeedsAtmosphereForInfluence && !useFuel;
            }
            return false;
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
        private static float GetBluePrintValue(MyBlueprintDefinitionBase bluePrint, MyPhysicalItemDefinition baseDef, ref ConcurrentDictionary<string, float> composition)
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
                        var resultaAmount = (float)bluePrint.Results.FirstOrDefault(x => x.Id == baseDef.Id).Amount;
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
                                    baseValue += prerequisiteShopItem.BaseValue * (float)prerequisite.Amount;
                                    foreach (var c in prerequisiteShopItem.Composition)
                                    {
                                        if (composition.ContainsKey(c.Key))
                                            composition[c.Key] += c.Value * (float)prerequisite.Amount;
                                        else
                                            composition[c.Key] = c.Value * (float)prerequisite.Amount;
                                    }
                                }
                                else
                                {
                                    var prerequisiteBaseItem = GetAndCalcBaseItemInfo(targetId);
                                    if (prerequisiteBaseItem != null)
                                    {
                                        baseValue += prerequisiteBaseItem.BaseValue * (float)prerequisite.Amount;
                                        foreach (var c in prerequisiteBaseItem.Composition)
                                        {
                                            if (composition.ContainsKey(c.Key))
                                                composition[c.Key] += c.Value * (float)prerequisite.Amount;
                                            else
                                                composition[c.Key] = c.Value * (float)prerequisite.Amount;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(SpaceStationController), $"GetBluePrintValue: {bluePrint.Id} had invalid prerequisite!");
                            }
                        }
                        baseValue *= 1 + (bluePrint.BaseProductionTimeInSeconds / 60);
                        if (resultaAmount >= 1)
                            baseValue /= resultaAmount;
                        else if (resultaAmount < 1 && resultaAmount > 0)
                            baseValue *= 1 + ((1 - resultaAmount) / 2);
                        var totalMax = composition.Values.Sum();
                        foreach (var k in composition.Keys)
                        {
                            composition[k] = composition[k] / totalMax;
                        }
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
                                composition[baseDef.Id.SubtypeName.ToUpper()] = 1f;
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
            if (ExtendedSurvivalSettings.Instance.Debug)
                ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(SpaceStationController), $"GetBluePrintValue: {baseDef.Id} : BASE VALUE = {baseValue}");
            return Math.Max(baseValue, 1);
        }

        private static BaseMaterialItem GetItemInfo(UniqueEntityId id)
        {
            BaseMaterialItem item = GetAndCalcItemInfo(id);
            if (item == null)
                item = GetAndCalcBaseItemInfo(id);
            return item;
        }

        private static BaseMaterialItem GetAndCalcBaseItemInfo(UniqueEntityId id)
        {
            if (BASE_ITENS.ContainsKey(id))
            {
                if (!BASE_ITENS[id].IsLoaded)
                {
                    var compostion = new ConcurrentDictionary<string, float>();
                    BASE_ITENS[id].BaseValue = (long)GetBluePrintValue(BASE_ITENS[id].RecipeBlueprint, BASE_ITENS[id].Definition, ref compostion);
                    BASE_ITENS[id].IsLoaded = true;
                    BASE_ITENS[id].Composition = compostion;
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
                    var compostion = new ConcurrentDictionary<string, float>();
                    SHOP_ITENS[id].BaseValue = (long)GetBluePrintValue(SHOP_ITENS[id].RecipeBlueprint, SHOP_ITENS[id].Definition, ref compostion);
                    SHOP_ITENS[id].DoForceDefinition();
                    SHOP_ITENS[id].IsLoaded = true;
                    SHOP_ITENS[id].Composition = compostion;
                }
                return SHOP_ITENS[id];
            }
            return null;
        }

        public static string GetEconomyValues()
        {
            var sb = new StringBuilder();
            var validTypes = BASE_ITENS.Keys.Select(x => x.typeId).Concat(SHOP_ITENS.Keys.Select(x => x.typeId)).Distinct().ToArray();
            foreach (var validType in validTypes)
            {
                sb.AppendLine($"Group {validType}:");
                var itens = BASE_ITENS.Where(x => x.Key.typeId == validType).Select(x => x.Value)
                    .Concat(SHOP_ITENS.Where(x => x.Key.typeId == validType).Select(x => x.Value as BaseMaterialItem))
                    .OrderBy(x => x.BaseValue).ToArray();
                foreach (var item in itens)
                {
                    sb.AppendLine($"- {item.Definition.DisplayNameText} = $ {item.BaseValue.ToString("#0.00")}:");
                }
                sb.AppendLine();
            }
            return sb.ToString();
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
            return FIRST_NAMES.Concat(MIDDLE_NAMES).Concat(LAST_NAMES).Where(x => x.Length >= 4).OrderBy(x => GetRandomDouble()).FirstOrDefault();
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
                    var query = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.Stations.Any()).ToArray();
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
                                                var stationType = (StationType)station.StationType;
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
                                                        try
                                                        {
                                                            var grid = gridListDummy.FirstOrDefault();
                                                            if (grid != null)
                                                            {
                                                                grid.IsStatic = true;
                                                                station.StationEntityId = grid.EntityId;
                                                                var safeZone = MySessionComponentSafeZones.CrateSafeZone(
                                                                    MatrixD.CreateWorld(station.Position, station.Up, station.Foward),
                                                                    MySafeZoneShape.Sphere,
                                                                    MySafeZoneAccess.Blacklist,
                                                                    new long[] { },
                                                                    new long[] { },
                                                                    stationType == StationType.OrbitalStation || stationType == StationType.SpaceStation ? 100 : 75,
                                                                    true
                                                                );
                                                                station.SafeZoneEntityId = safeZone.EntityId;
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
                                                        }
                                                        finally
                                                        {
                                                            station.IsSpawning = false;
                                                        }
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
                                        if (!station.HasActiveContracts && !ExtendedSurvivalEntityManager.Instance.AnyInRange(station.Position, SPAWN_DISTANCE, station.StationEntityId))
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
                        try
                        {
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
                        catch (Exception ex)
                        {
                            ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SpaceStationController), ex);
                        }
                        try
                        {
                            var checkPrefabList = station.ShopPrefabs.ToArray();
                            foreach (var item in checkPrefabList)
                            {
                                var query = items.Where(x => x.PrefabName == item.PrefabName);
                                if (!query.Any() || query.First().Amount <= 0)
                                {
                                    station.ShopPrefabs.Remove(item);
                                }
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

        private static float GetAmountWithMultiplier(float baseValue, MyDefinitionId id)
        {
            if (id.TypeId == typeof(MyObjectBuilder_Ore) || id.TypeId == typeof(MyObjectBuilder_Ingot))
                return baseValue * ORE_INGOT_AMOUNT_MULTIPLIER.GetRandom();
            if (id.TypeId == typeof(MyObjectBuilder_GasContainerObject) || id.TypeId == typeof(MyObjectBuilder_OxygenContainerObject))
                return baseValue * GASCONTAINER_AMOUNT_MULTIPLIER.GetRandom();
            return baseValue;
        }

        public static void DoBuildContracts(StarSystemMemberStationStorage station)
        {
            var faction = ExtendedSurvivalStorage.Instance.GetFaction(station.FactionId);
            if (faction != null)
            {
                if (station.AcquisitionContracts.Any(x => x.ContractId.HasValue && !x.PlayerId.HasValue))
                {
                    foreach (var contrat in station.AcquisitionContracts.Where(x => x.ContractId.HasValue && !x.PlayerId.HasValue))
                    {
                        MyVisualScriptLogicProvider.RemoveContract(contrat.ContractId.Value);
                    }
                }
                station.AcquisitionContracts.RemoveAll(x => x.ContractId.HasValue && !x.PlayerId.HasValue);
                var factionType = (FactionType)faction.FactionType;
                var stationLevel = (StationLevel)station.StationLevel;
                var countToOrder = Math.Max(0, STATION_ITENS_PROFILE[stationLevel].AcquisitionContractsCount.GetRandomInt() - station.AcquisitionContracts.Count);
                var itensQuery = SHOP_ITENS.Values.Where(x => x.TargetFactions.Contains(factionType) && STATION_ITENS_PROFILE[stationLevel].CanSellRarity.Contains(x.Rarity));
                if (itensQuery.Any() && countToOrder > 0)
                {
                    var itensToOrderQuery = itensQuery.Where(x => x.CanOrder);
                    if (itensToOrderQuery.Any())
                    {
                        lock (station.AcquisitionContracts)
                        {
                            var queryCheck = station.AcquisitionContracts.AsQueryable();
                            while (queryCheck.Count() < countToOrder)
                            {
                                var itemToUse = itensToOrderQuery.Where(x => !queryCheck.Any(y => y.Id == x.Id.DefinitionId)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                if (itemToUse == null)
                                    break;
                                var finalValue = itemToUse.GetValue(station, true, STATION_BUY_VALUE_MULTIPLIER.GetRandom());
                                if (finalValue > 0)
                                {
                                    var amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[itemToUse.Rarity].GetRandom(), itemToUse.Id.DefinitionId);
                                    station.AcquisitionContracts.Add(new StarSystemStationAcquisitionContract()
                                    {
                                        Id = itemToUse.Id.DefinitionId,
                                        Amount = amount,
                                        Reward = (int)finalValue * amount,
                                        Collateral = DEFAULT_COLLATERAL_CONTRACT,
                                        Duration = DEFAULT_DURATION_CONTRACT
                                    });
                                }
                                else
                                {
                                    countToOrder--;
                                }
                            }
                        }
                    }
                }
            }
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
                            lock (station.ShopItems)
                            {
                                foreach (var item in itensToBuyQuery)
                                {
                                    var finalValue = item.GetValue(station, true, STATION_BUY_VALUE_MULTIPLIER.GetRandom());
                                    if (finalValue > 0)
                                    {
                                        station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                        {
                                            Id = item.Id.DefinitionId,
                                            Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[item.Rarity].GetRandom(), item.Id.DefinitionId),
                                            Price = finalValue
                                        });
                                    }
                                }
                            }
                        }
                        else
                        {
                            lock (station.ShopItems)
                            {
                                var queryCheck = station.ShopItems.Where(x => !x.IsSelling);
                                while (queryCheck.Count() < countToBuy)
                                {
                                    var itemToUse = itensToBuyQuery.Where(x => !queryCheck.Any(y => y.Id == x.Id.DefinitionId)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                    if (itemToUse == null)
                                        break;
                                    var finalValue = itemToUse.GetValue(station, true, STATION_BUY_VALUE_MULTIPLIER.GetRandom());
                                    if (finalValue > 0)
                                    {
                                        station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                        {
                                            Id = itemToUse.Id.DefinitionId,
                                            Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[itemToUse.Rarity].GetRandom(), itemToUse.Id.DefinitionId),
                                            Price = finalValue
                                        });
                                    }
                                    else
                                    {
                                        countToBuy--;
                                    }
                                }
                            }
                        }
                    }
                    // SELL Item List
                    var itensToSellQuery = itensQuery.Where(x => x.CanSell);
                    if (itensToSellQuery.Any())
                    {
                        if (itensToSellQuery.Count() <= countToSell)
                        {
                            lock (station.ShopItems)
                            {
                                foreach (var item in itensToSellQuery)
                                {
                                    var finalValue = item.GetValue(station, false, STATION_SELL_VALUE_MULTIPLIER.GetRandom());
                                    if (finalValue > 0)
                                    {
                                        station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                        {
                                            Id = item.Id.DefinitionId,
                                            Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[item.Rarity].GetRandom(), item.Id.DefinitionId),
                                            Price = finalValue,
                                            IsSelling = true
                                        });
                                    }
                                }
                            }
                        }
                        else
                        {
                            lock (station.ShopItems)
                            {
                                var queryCheck = station.ShopItems.Where(x => x.IsSelling);
                                while (queryCheck.Count() < countToSell)
                                {
                                    var itemToUse = itensToSellQuery.Where(x => !queryCheck.Any(y => y.Id == x.Id.DefinitionId)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                    if (itemToUse == null)
                                        break;
                                    var finalValue = itemToUse.GetValue(station, false, STATION_SELL_VALUE_MULTIPLIER.GetRandom());
                                    if (finalValue > 0)
                                    {
                                        station.ShopItems.Add(new StarSystemStationShopItemStorage()
                                        {
                                            Id = itemToUse.Id.DefinitionId,
                                            Amount = (int)GetAmountWithMultiplier(ITEM_RARITY_AMOUNT[itemToUse.Rarity].GetRandom(), itemToUse.Id.DefinitionId),
                                            Price = itemToUse.BaseValue,
                                            IsSelling = true
                                        });
                                    }
                                    else
                                    {
                                        countToSell--;
                                    }
                                }
                            }
                        }
                    }
                }
                if (factionType == FactionType.Shipyard)
                {
                    var prefabsToSell = STATION_ITENS_PROFILE[stationLevel].PrefabsCount.GetRandomInt();
                    var prefabsQuery = LOADED_PREFABS_TO_SELL.Values.Where(x => x.IsValid && CheckPrefabCanGoInStation(station, x));
                    if (prefabsQuery.Any())
                    {
                        if (prefabsQuery.Count() <= prefabsToSell)
                        {
                            lock (station.ShopPrefabs)
                            {
                                foreach (var item in prefabsQuery)
                                {
                                    station.ShopPrefabs.Add(new StarSystemStationShopPrefabStorage()
                                    {
                                        PrefabName = item.PrefabName,
                                        Price = item.BaseValue
                                    });
                                }
                            }
                        }
                        else
                        {
                            lock (station.ShopPrefabs)
                            {
                                while (station.ShopPrefabs.Count < prefabsToSell)
                                {
                                    var itemToUse = prefabsQuery.Where(x => !station.ShopPrefabs.Any(y => y.PrefabName == x.PrefabName)).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                    if (itemToUse == null)
                                        break;
                                    station.ShopPrefabs.Add(new StarSystemStationShopPrefabStorage()
                                    {
                                        PrefabName = itemToUse.PrefabName,
                                        Price = itemToUse.BaseValue
                                    });
                                }
                            }
                        }
                    }
                }
            }
            DoBuildContracts(station);
            station.ComercialTick = ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick;
            if (station.StationEntityId != 0)
            {
                DoApplyItensToGrid(station);
            }
        }

        private static bool CheckPrefabCanGoInStation(StarSystemMemberStationStorage station, StationPrefabItem prefab)
        {
            var stationLevel = (StationLevel)station.StationLevel;
            var stationType = (StationType)station.StationType;
            switch (stationType)
            {
                case StationType.MiningStation:
                case StationType.Outpost:
                    if ((!station.WithAtmosphere || station.LowAtmosphereDensity) && 
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.Rover) && 
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.H2Thruster) && 
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.IonThruster))
                        return false; /* no hight density atm and is not a rover and only thusters are atm */
                    if (station.WithAtmosphere &&
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.Rover) &&
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.H2Thruster) &&
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.AtmThruster))
                        return false; /* atm and is not a rover and only thusters are ion */
                    break;
                case StationType.OrbitalStation:
                case StationType.SpaceStation:
                    if (prefab.Flags.IsFlagSet(StationPrefabFlag.Rover))
                        return false; /* no rover in space */
                    if (!prefab.Flags.IsFlagSet(StationPrefabFlag.H2Thruster) &&
                        !prefab.Flags.IsFlagSet(StationPrefabFlag.IonThruster) &&
                        prefab.Flags.IsFlagSet(StationPrefabFlag.AtmThruster))
                        return false; /* is space and only thusters are atm */
                    break;
            }
            var keyFilter = new KeyValuePair<StationType, StationLevel>(stationType, stationLevel);
            if (STATION_PREFAB_FILTERS.ContainsKey(keyFilter))
            {
                if (!STATION_PREFAB_FILTERS[keyFilter].validCategories.IsFlagSet(prefab.Category))
                    return false; /* mapped category flag */
                if (STATION_PREFAB_FILTERS[keyFilter].excludeFlags != StationPrefabFlag.None)
                {
                    foreach (var flag in STATION_PREFAB_FILTERS[keyFilter].excludeFlags.GetFlags())
                    {
                        if (prefab.Flags.IsFlagSet(flag))
                            return false; /* mapped excluded flag */
                    }
                }
                if (STATION_PREFAB_FILTERS[keyFilter].requiredFlags != StationPrefabFlag.None)
                {
                    foreach (var flag in STATION_PREFAB_FILTERS[keyFilter].requiredFlags.GetFlags())
                    {
                        if (!prefab.Flags.IsFlagSet(flag))
                            return false; /* mapped required flag */
                    }
                }                
            }
            else
                return false;
            return true;
        }

        public static void DoCheckStationGrid(StarSystemMemberStationStorage station, GridEntity entity, bool onlyIfNoPower = false)
        {
            if (entity == null)
                entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
            if (entity != null)
            {
                if (onlyIfNoPower && entity.Entity.ResourceDistributor.ResourceState != MyResourceStateEnum.NoPower)
                    return;
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
                                var maxToAdd = ((float)inventory.MaxVolume * 1000f / 0.35f) - 1;
                                var amount = (float)inventory.GetItemAmount(ItensConstants.ICE_ID.DefinitionId);
                                inventory.AddMaxItems(maxToAdd - amount, ItensConstants.GetPhysicalObjectBuilder(OreConstants.ICE_ID));
                                o2Generator.Enabled = true;
                            }
                            else
                            {
                                o2Generator.Enabled = false;
                            }
                        }
                    }
                }
                if (entity._blocksByType.ContainsKey(typeof(MyObjectBuilder_Reactor)))
                {
                    foreach (var block in entity._blocksByType[typeof(MyObjectBuilder_Reactor)])
                    {
                        var reactor = block.FatBlock as IMyReactor;
                        if (reactor != null)
                        {
                            var inventory = reactor.GetInventory();
                            if (inventory != null)
                            {
                                var maxToAdd = ((float)inventory.MaxVolume * 1000f / 0.125f) - 1;
                                var amount = (float)inventory.GetItemAmount(ItensConstants.URANIUM_INGOT_ID.DefinitionId);
                                inventory.AddMaxItems(maxToAdd - amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.URANIUM_INGOT_ID));
                                reactor.Enabled = true;
                            }
                            else
                            {
                                reactor.Enabled = false;
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
            }
        }

        private static void DoApplyContractsToStation(GridEntity entity, StarSystemMemberStationStorage station)
        {
            if (entity != null)
            {
                if (entity._blocksById.ContainsKey(CONTRACTBLOCK_ID))
                {
                    var contractBlock = entity._blocksById[CONTRACTBLOCK_ID].FirstOrDefault();
                    if (contractBlock != null)
                    {
                        bool balanceChange = false;
                        foreach (var contract in station.AcquisitionContracts.Where(x => !x.ContractId.HasValue))
                        {
                            StarSystemController.InvokeOnGameThread(() =>
                            {
                                if (!balanceChange)
                                {
                                    MyAPIGateway.Players.RequestChangeBalance(contractBlock.OwnerId, long.MaxValue / 2);
                                    balanceChange = true;
                                }
                                long contractId = 0;
                                if (MyVisualScriptLogicProvider.AddAcquisitionContract(
                                    contractBlock.FatBlock.EntityId,
                                    contract.Reward,
                                    contract.Collateral,
                                    contract.Duration,
                                    contractBlock.FatBlock.EntityId,
                                    contract.Id,
                                    contract.Amount,
                                    out contractId
                                ))
                                {
                                    contract.ContractId = contractId;
                                }
                            });
                        }
                    }
                }
            }
        }

        private static void DoApplyItensToGrid(StarSystemMemberStationStorage station)
        {
            var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
            if (entity != null)
            {
                DoCheckStationGrid(station, entity);
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
                            // Add Prefabs to sell
                            foreach (var prefab in station.ShopPrefabs)
                            {
                                if (LOADED_PREFABS_TO_SELL.ContainsKey(prefab.PrefabName))
                                {
                                    var def = LOADED_PREFABS_TO_SELL[prefab.PrefabName];
                                    var item = storeBlock.CreateStoreItem(prefab.PrefabName, 1, (int)def.BaseValue, (int)def.TotalPCU);
                                    storeBlock.InsertStoreItem(item);
                                }
                            }
                        }
                    }
                }
                DoApplyContractsToStation(entity, station);
            }
        }

    }

}