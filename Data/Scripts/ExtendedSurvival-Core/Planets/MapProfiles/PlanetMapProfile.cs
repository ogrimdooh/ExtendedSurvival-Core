using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;
using static ExtendedSurvival.Core.PlanetProfile;

namespace ExtendedSurvival.Core
{

    public static class PlanetMapProfile
    {

        public enum OreMapType
        {

            Vanilla = 0,
            ExtendedSurvival = 1,
            BetterStoneVanilla = 2,
            BetterStoneExtendedSurvival = 3

        }

        public class OreType
        {

            public string Name { get; set; }
            public PlanetProfile.OreMapInfo DefaultInfo { get; set; }

        }

        public const int PROFILE_VERSION = 23;

        public const ulong EARTHLIKE_ANIMALS_MODID = 2170447225;

        // Valina
        public const string Iron_01 = "Iron_01";
        public const string Iron_02 = "Iron_02";
        public const string Nickel_01 = "Nickel_01";
        public const string Silicon_01 = "Silicon_01";
        public const string Cobalt_01 = "Cobalt_01";
        public const string Gold_01 = "Gold_01";
        public const string Silver_01 = "Silver_01";
        public const string Platinum_01 = "Platinum_01";
        public const string Magnesium_01 = "Magnesium_01";
        public const string Uraninite_01 = "Uraninite_01";
        public const string Ice_01 = "Ice_01";

        // ES Core
        public const string StoneIce_01 = "StoneIce_01";
        public const string DirtySoil_01 = "DirtySoil_01";        

        // ES Technology
        public const string Aluminum_01 = "Aluminum_01";
        public const string Copper_01 = "Copper_01";
        public const string Lead_01 = "Lead_01";
        public const string Sulfur_01 = "Sulfur_01";
        public const string Carbon_01 = "Carbon_01";
        public const string Potassium_01 = "Potassium_01";
        public const string Lithium_01 = "Lithium_01";
        public const string Zinc_01 = "Zinc_01";
        public const string Iridium_01 = "Iridium_01";
        public const string Titanium_01 = "Titanium_01";
        public const string Mercury_01 = "Mercury_01";
        public const string Beryllium_01 = "Beryllium_01";
        public const string Tungsten_01 = "Tungsten_01";
        public const string Plutonium_01 = "Plutonium_01";
        public const string Iron_03 = "Iron_03";
        public const string Iron_04 = "Iron_04";

        public const int COMMON_SPAWN = 9;
        public const int UNCOMMON_SPAWN = 6;
        public const int RARE_SPAWN = 3;

        public const int COMMON_MULTIPLIER_SPAWN = 1;
        public const int UNCOMMON_MULTIPLIER_SPAWN = 1;
        public const int RARE_MULTIPLIER_SPAWN = 1;
        public const int LEGENDARY_MULTIPLIER_SPAWN = 1;

        public static readonly string[] AllValidOres = new string[]
        {
            "IRON",
            "NICKEL",
            "SILICON",
            "COBALT",
            "GOLD",
            "SILVER",
            "PLATINUM",
            "MAGNESIUM",
            "URANIUM",
            "ICE",
            "STONEICE",
            "ALUMINUM",
            "COPPER",
            "LEAD",
            "SULFUR",
            "CARBON",
            "POTASSIUM",
            "LITHIUM",
            "ZINC",
            "IRIDIUM",
            "TITANIUM",
            "MERCURY",
            "BERYLLIUM",
            "TUNGSTEN",
            "PLUTONIUM",
            "TOXICICE",
            "SOIL",
            "MOONSOIL",
            "DESERTSOIL",
            "ALIENSOIL",
            "STONE"
        };

        public static readonly string[] ESTechnologyOres = new string[] 
        { 
            Aluminum_01, 
            Copper_01, 
            Lead_01, 
            Sulfur_01, 
            Carbon_01,
            Potassium_01, 
            Lithium_01,
            Zinc_01,
            Iridium_01,
            Titanium_01,
            Mercury_01,
            Beryllium_01,
            Tungsten_01,
            Plutonium_01
        };

        public static readonly Dictionary<string, string> OresKeys = new Dictionary<string, string>()
        {
            { "IRON", Iron_02 },
            { "NICKEL", Nickel_01 },
            { "SILICON", Silicon_01 },
            { "COBALT", Cobalt_01 },
            { "GOLD", Gold_01 },
            { "SILVER", Silver_01 },
            { "PLATINUM", Platinum_01 },
            { "MAGNESIUM", Magnesium_01 },
            { "URANINITE", Uraninite_01 },
            { "ICE", Ice_01 },
            { "STONEICE", StoneIce_01 },
            { "ALUMINUM", Aluminum_01  },
            { "COPPER", Copper_01  },
            { "LEAD", Lead_01  },
            { "SULFUR", Sulfur_01  },
            { "CARBON", Carbon_01 },
            { "POTASSIUM", Potassium_01 },
            { "LITHIUM", Lithium_01 },
            { "ZINC", Zinc_01 },
            { "IRIDIUM", Iridium_01 },
            { "TITANIUM", Titanium_01 },
            { "MERCURY", Mercury_01 },
            { "BERYLLIUM", Beryllium_01 },
            { "TUNGSTEN", Tungsten_01 },
            { "PLUTONIUM", Plutonium_01 },
            { "IRON1", Iron_01 },
            { "IRON2", Iron_02 },
            { "IRON3", Iron_03 },
            { "IRON4", Iron_04 },
            { "DIRTYSOIL", DirtySoil_01 },
            { "HAPKEITE", BetterStoneIntegrationProfile.Hapkeite_01 },
            { "HEAZLEWOODITE", BetterStoneIntegrationProfile.Heazlewoodite_01 },
            { "PORPHYRY", BetterStoneIntegrationProfile.Porphyry_01 },
            { "DOLOMITE", BetterStoneIntegrationProfile.Dolomite_01 },
            { "CATTIERITE", BetterStoneIntegrationProfile.Cattierite_01 },
            { "NIGGLIITE", BetterStoneIntegrationProfile.Niggliite_01 },
            { "CARNOTITE", BetterStoneIntegrationProfile.Carnotite_01 },
            { "GLAUCODOT", BetterStoneIntegrationProfile.Glaucodot_01 },
            { "SINOITE", BetterStoneIntegrationProfile.Sinoite_01 },
            { "PYRITE", BetterStoneIntegrationProfile.Pyrite_01 },
            { "OLIVINE", BetterStoneIntegrationProfile.Olivine_01 },
            { "COOPERITE", BetterStoneIntegrationProfile.Cooperite_01 },
            { "QUARTZ", BetterStoneIntegrationProfile.Quartz_01 },
            { "GALENA", BetterStoneIntegrationProfile.Galena_01 },
            { "CHLORARGYRITE", BetterStoneIntegrationProfile.Chlorargyrite_01 },
            { "ELECTRUM", BetterStoneIntegrationProfile.Electrum_01 },
            { "SPERRYLITE", BetterStoneIntegrationProfile.Sperrylite_01 },
            { "AUTUNITE", BetterStoneIntegrationProfile.Autunite_01 },
            { "AKIMOTOITE", BetterStoneIntegrationProfile.Akimotoite_01 },
            { "WADSLEYITE", BetterStoneIntegrationProfile.Wadsleyite_01 },
            { "TAENITE", BetterStoneIntegrationProfile.Taenite_01 },
            { "COHENITE", BetterStoneIntegrationProfile.Cohenite_01 },
            { "KAMACITE", BetterStoneIntegrationProfile.Kamacite_01 },
            { "URANIAURITE", BetterStoneIntegrationProfile.Uraniaurite_01 },
            { "PETZIT", BetterStoneIntegrationProfile.Petzite_01 },
            { "GLOWCRYSTAL", InfiniteMapProfile.GlowCrystal }
        };

        public static string[] FilterValidOres(string[] keys)
        {
            if (keys == null)
                return new string[0];
            return keys.Where(x => OresKeys.ContainsKey(x.ToUpper())).ToArray();
        }

        public static string[] GetValidOreKeys(string[] keys)
        {
            if (keys == null)
                return new string[0];
            return keys.Select(x => GetValidOreKey(x)).ToArray();
        }

        public static string GetValidOreKey(string x)
        {
            if (OresKeys.ContainsKey(x.ToUpper()))
                return OresKeys[x.ToUpper()];
            return null;
        }

        public const string DEFAULT_PROFILE = "DEFAULT";

        private static readonly PlanetProfile.GeothermalInfo DEFAULT_GEOTHERMALINFO = new PlanetProfile.GeothermalInfo()
        {
            enabled = true,
            start = new Vector2I(150, 300),
            rowSize = new Vector2I(75, 150),
            power = new Vector2(500, 1500),
            increment = new Vector2(100, 500),
            maxPower = new Vector2(2500, 5000)
        };

        private static readonly Dictionary<string, OreType> DEFAULT_ORE_INFO = new Dictionary<string, OreType>()
        {
            // Vanila
            {
                Iron_02,
                new OreType()
                {
                    Name = Iron_02,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Iron_02,
                        start = new Vector2I(4, 20),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Nickel_01,
                new OreType()
                {
                    Name = Nickel_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Nickel_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Silicon_01,
                new OreType()
                {
                    Name = Silicon_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Silicon_01,
                        start = new Vector2I(8, 40),
                        depth = new Vector2I(6, 15),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Ice_01,
                new OreType()
                {
                    Name = Ice_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Ice_01,
                        start = new Vector2I(10, 50),
                        depth = new Vector2I(8, 16),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Cobalt_01,
                new OreType()
                {
                    Name = Cobalt_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Cobalt_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Gold_01,
                new OreType()
                {
                    Name = Gold_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Gold_01,
                        start = new Vector2I(30, 60),
                        depth = new Vector2I(10, 20),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Silver_01,
                new OreType()
                {
                    Name = Silver_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Silver_01,
                        start = new Vector2I(30, 60),
                        depth = new Vector2I(10, 20),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Platinum_01,
                new OreType()
                {
                    Name = Platinum_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Platinum_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Magnesium_01,
                new OreType()
                {
                    Name = Magnesium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Magnesium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Uraninite_01,
                new OreType()
                {
                    Name = Uraninite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Uraninite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            // ES Core
            {
                StoneIce_01,
                new OreType()
                {
                    Name = StoneIce_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = StoneIce_01,
                        start = new Vector2I(10, 50),
                        depth = new Vector2I(8, 16),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            // ES Technology            
            {
                Aluminum_01,
                new OreType()
                {
                    Name = Aluminum_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Aluminum_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Copper_01,
                new OreType()
                {
                    Name = Copper_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Copper_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Lead_01,
                new OreType()
                {
                    Name = Lead_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Lead_01,
                        start = new Vector2I(15, 50),
                        depth = new Vector2I(10, 25),
                        rarity = PlanetProfile.OreRarity.Uncommon
                    }
                }
            },
            {
                Sulfur_01,
                new OreType()
                {
                    Name = Sulfur_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Sulfur_01,
                        start = new Vector2I(15, 50),
                        depth = new Vector2I(10, 25),
                        rarity = PlanetProfile.OreRarity.Uncommon
                    }
                }
            },
            {
                Carbon_01,
                new OreType()
                {
                    Name = Carbon_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Carbon_01,
                        start = new Vector2I(15, 50),
                        depth = new Vector2I(10, 25),
                        rarity = PlanetProfile.OreRarity.Uncommon
                    }
                }
            },
            {
                Potassium_01,
                new OreType()
                {
                    Name = Potassium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Potassium_01,
                        start = new Vector2I(20, 60),
                        depth = new Vector2I(10, 25),
                        rarity = PlanetProfile.OreRarity.Uncommon
                    }
                }
            },
            {
                Lithium_01,
                new OreType()
                {
                    Name = Lithium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Lithium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                Zinc_01,
                new OreType()
                {
                    Name = Zinc_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Zinc_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Iridium_01,
                new OreType()
                {
                    Name = Iridium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Iridium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Titanium_01,
                new OreType()
                {
                    Name = Titanium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Titanium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Mercury_01,
                new OreType()
                {
                    Name = Mercury_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Mercury_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Beryllium_01,
                new OreType()
                {
                    Name = Beryllium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Beryllium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Tungsten_01,
                new OreType()
                {
                    Name = Tungsten_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Tungsten_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Plutonium_01,
                new OreType()
                {
                    Name = Plutonium_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Plutonium_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Epic
                    }
                }
            },
            {
                Iron_01,
                new OreType()
                {
                    Name = Iron_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Iron_01,
                        start = new Vector2I(12, 36),
                        depth = new Vector2I(8, 16),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Iron_03,
                new OreType()
                {
                    Name = Iron_03,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Iron_03,
                        start = new Vector2I(12, 36),
                        depth = new Vector2I(8, 16),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                Iron_04,
                new OreType()
                {
                    Name = Iron_04,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Iron_04,
                        start = new Vector2I(24, 48),
                        depth = new Vector2I(16, 24),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            // Better Stone
            {
                BetterStoneIntegrationProfile.Hapkeite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Hapkeite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Hapkeite_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Heazlewoodite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Heazlewoodite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Heazlewoodite_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Porphyry_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Porphyry_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Porphyry_01,
                        start = new Vector2I(30, 60),
                        depth = new Vector2I(10, 20),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Dolomite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Dolomite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Dolomite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Cattierite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Cattierite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Cattierite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Niggliite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Niggliite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Niggliite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Carnotite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Carnotite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Carnotite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Glaucodot_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Glaucodot_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Glaucodot_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Sinoite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Sinoite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Sinoite_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Pyrite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Pyrite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Pyrite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Olivine_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Olivine_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Olivine_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Cooperite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Cooperite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Cooperite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Quartz_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Quartz_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Quartz_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Galena_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Galena_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Galena_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Chlorargyrite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Chlorargyrite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Chlorargyrite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Electrum_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Electrum_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Electrum_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Sperrylite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Sperrylite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Sperrylite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Autunite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Autunite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Autunite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Akimotoite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Akimotoite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Akimotoite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Wadsleyite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Wadsleyite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Wadsleyite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Taenite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Taenite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Taenite_01,
                        start = new Vector2I(6, 30),
                        depth = new Vector2I(4, 10),
                        rarity = PlanetProfile.OreRarity.Common
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Cohenite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Cohenite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Cohenite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Kamacite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Kamacite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Kamacite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Uraniaurite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Uraniaurite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Uraniaurite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            {
                BetterStoneIntegrationProfile.Petzite_01,
                new OreType()
                {
                    Name = BetterStoneIntegrationProfile.Petzite_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = BetterStoneIntegrationProfile.Petzite_01,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            },
            // Infinite
            {
                InfiniteMapProfile.GlowCrystal,
                new OreType()
                {
                    Name = InfiniteMapProfile.GlowCrystal,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = InfiniteMapProfile.GlowCrystal,
                        start = new Vector2I(50, 100),
                        depth = new Vector2I(15, 30),
                        rarity = PlanetProfile.OreRarity.Rare
                    }
                }
            }
        };

        public static readonly PlanetProfile.SuperficialMiningInfo EARTH_SUPERFICIAL_MINING = new PlanetProfile.SuperficialMiningInfo()
        {
            enabled = true,
            drops = new PlanetProfile.SuperficialMiningDropInfo[]
            {
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.CHAMPIGNONS_ID,
                    ammount = new Vector2(2, 8),
                    chance = 4,
                    alowFrac = false,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.SHIITAKE_ID,
                    ammount = new Vector2(2, 8),
                    chance = 4,
                    alowFrac = false,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.CAROOT_ID,
                    ammount = new Vector2(1, 4),
                    chance = 2,
                    alowFrac = false,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.BEETROOT_ID,
                    ammount = new Vector2(1, 4),
                    chance = 2,
                    alowFrac = false,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.ALOEVERA_ID,
                    ammount = new Vector2(0.25f, 1.25f),
                    chance = 5,
                    alowFrac = true,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.ERYTHROXYLUM_ID,
                    ammount = new Vector2(0.25f, 1.25f),
                    chance = 5,
                    alowFrac = true,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.ARNICA_ID,
                    ammount = new Vector2(0.25f, 0.75f),
                    chance = 3,
                    alowFrac = true,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.CHAMOMILE_ID,
                    ammount = new Vector2(0.25f, 1.25f),
                    chance = 3,
                    alowFrac = true,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.MINT_ID,
                    ammount = new Vector2(0.25f, 1.25f),
                    chance = 3,
                    alowFrac = true,
                    validSubType = new string[] { "Soil" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.FISH_BAIT_SMALL_ID,
                    ammount = new Vector2(0.25f, 1.25f),
                    chance = 4,
                    alowFrac = true,
                    validSubType = new string[] { "Mud" }
                },
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.FISH_NOBLE_BAIT_ID,
                    ammount = new Vector2(0.25f, 0.75f),
                    chance = 2,
                    alowFrac = true,
                    validSubType = new string[] { "Mud" }
                }
            }
        };

        public static readonly PlanetProfile.SuperficialMiningInfo ALIEN_SUPERFICIAL_MINING = new PlanetProfile.SuperficialMiningInfo()
        {
            enabled = true,
            drops = new PlanetProfile.SuperficialMiningDropInfo[]
            {
                new PlanetProfile.SuperficialMiningDropInfo()
                {
                    itemId = ItensConstants.AMANITAMUSCARIA_ID,
                    ammount = new Vector2(2, 4),
                    chance = 5,
                    alowFrac = false,
                    validSubType = new string[] { "AlienSoil" }
                }
            }
        };

        public static readonly PlanetProfile.SuperficialMiningInfo DISABLE_SUPERFICIAL_MINING = new PlanetProfile.SuperficialMiningInfo()
        {
            enabled = false,
            drops = new PlanetProfile.SuperficialMiningDropInfo[] { }
        };

        public static PlanetProfile.AtmosphereInfo GetAtmosphere(bool enabled, bool breathable = false, float density = 0f, float oxygenDensity = 0f, float maxWindSpeed = 0f, float limitAltitude = 0f, float toxicLevel = 0f, float radiationLevel = 0f)
        {
            return new PlanetProfile.AtmosphereInfo()
            {
                enabled = enabled,
                breathable = breathable,
                density = density,
                oxygenDensity = oxygenDensity,
                maxWindSpeed = maxWindSpeed,
                limitAltitude = limitAltitude,
                toxicLevel = toxicLevel,
                radiationLevel = radiationLevel
            };
        }

        public static PlanetProfile.WaterInfo GetWater(bool enabled, float size = 0f, float factor = 0f, float toxicLevel = 0f, float radiationLevel = 0f)
        {
            return new PlanetProfile.WaterInfo()
            {
                enabled = enabled,
                size = size,
                temperatureFactor = factor,
                toxicLevel = toxicLevel,
                radiationLevel = radiationLevel
            };
        }

        public static PlanetProfile.TemperatureInfo GetTemperature(VRage.Game.MyTemperatureLevel level, float min, float max)
        {
            return new PlanetProfile.TemperatureInfo()
            {
                temperatureLevel = level,
                temperatureRange = new Vector2(min, max)
            };
        }

        public static PlanetProfile.GravityInfo GetGravity(float surface, float fallOff)
        {
            return new PlanetProfile.GravityInfo()
            {
                surfaceGravity = surface,
                gravityFalloffPower = fallOff
            };
        }

        public static PlanetProfile.GeothermalInfo GetGeothermal(bool enabled, float depthMultiplier = 1f, float rowSizeMultiplier = 1f, float powerMultiplier = 1f)
        {
            return new PlanetProfile.GeothermalInfo()
            {
                enabled = enabled,
                start = DEFAULT_GEOTHERMALINFO.start.GetMultiplier(depthMultiplier),
                rowSize = DEFAULT_GEOTHERMALINFO.rowSize.GetMultiplier(rowSizeMultiplier),
                power = DEFAULT_GEOTHERMALINFO.power.GetMultiplier(powerMultiplier),
                increment = DEFAULT_GEOTHERMALINFO.increment.GetMultiplier(powerMultiplier),
                maxPower = DEFAULT_GEOTHERMALINFO.maxPower.GetMultiplier(powerMultiplier)
            };
        }

        public static PlanetProfile.OreMapInfo GetOreMap(string type, PlanetProfile.OreRarity rarity = PlanetProfile.OreRarity.None)
        {
            OreType baseInfo = null;
            if (DEFAULT_ORE_INFO.ContainsKey(type))
                baseInfo = DEFAULT_ORE_INFO[type];
            else
                baseInfo = DEFAULT_ORE_INFO[Iron_02];
            return new PlanetProfile.OreMapInfo()
            {
                type = baseInfo.DefaultInfo.type,
                start = baseInfo.DefaultInfo.start,
                depth = baseInfo.DefaultInfo.depth,
                rarity = rarity == PlanetProfile.OreRarity.None ? baseInfo.DefaultInfo.rarity : rarity
            };
        }

        public static List<PlanetProfile.OreMapInfo> CopyAndAdd(List<PlanetProfile.OreMapInfo> source, string[] common = null, string[] uncommon = null, string[] rare = null, string[] epic = null, string[] ignore = null, OreRarity[] ignoreRariry = null)
        {
            var retorno = new List<PlanetProfile.OreMapInfo>();
            if (source != null && source.Any())
            {
                retorno.AddRange(
                    source.Where(x => 
                        (ignore == null || !ignore.Any(y => y == x.type)) &&
                        (ignoreRariry == null || !ignoreRariry.Any(y => y == x.rarity))
                    )
                );
            }
            if (common != null && common.Any())
            {
                foreach (var item in common)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Common));
                }
            }
            if (uncommon != null && uncommon.Any())
            {
                foreach (var item in uncommon)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Uncommon));
                }
            }
            if (rare != null && rare.Any())
            {
                foreach (var item in rare)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Rare));
                }
            }
            if (epic != null && epic.Any())
            {
                foreach (var item in epic)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Epic));
                }
            }
            return retorno;
        }

        public static List<PlanetProfile.OreMapInfo> BuildOreMap(string[] common = null, string[] uncommon = null, string[] rare = null, string[] epic = null)
        {
            var retorno = new List<PlanetProfile.OreMapInfo>();
            if (common != null && common.Any())
            {
                foreach (var item in common)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Common));
                }
            }
            if (uncommon != null && uncommon.Any())
            {
                foreach (var item in uncommon)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Uncommon));
                }
            }
            if (rare != null && rare.Any())
            {
                foreach (var item in rare)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Rare));
                }
            }
            if (epic != null && epic.Any())
            {
                foreach (var item in epic)
                {
                    retorno.Add(GetOreMap(item, PlanetProfile.OreRarity.Epic));
                }
            }
            return retorno;
        }

        private static readonly Dictionary<string, PlanetProfile> PROFILES = new Dictionary<string, PlanetProfile>()
        {
            {
                // DEFAULT
                DEFAULT_PROFILE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.NotDefined,
                    Version = PROFILE_VERSION,
                    RespawnEnabled = false,
                    Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(1, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    SizeRange = new Vector2(50, 70),
                    Type = PlanetProfile.PlanetType.Planet,
                    GroupType = PlanetProfile.OreGroupType.LargeGroup,
                    Ores =
                    ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                    new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02),
                        GetOreMap(Nickel_01),
                        GetOreMap(Aluminum_01),
                        GetOreMap(Copper_01),
                        GetOreMap(Silicon_01),
                        GetOreMap(Zinc_01),
                        GetOreMap(Lead_01),
                        GetOreMap(Sulfur_01),
                        GetOreMap(Carbon_01),
                        GetOreMap(Potassium_01),
                        GetOreMap(Cobalt_01)
                    }
                    :
                    new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02),
                        GetOreMap(Nickel_01),
                        GetOreMap(Silicon_01),
                        GetOreMap(Magnesium_01),
                        GetOreMap(Cobalt_01),
                        GetOreMap(Gold_01),
                        GetOreMap(Silver_01)
                    }
                }
            },
            // VANILA
            {
                VanilaMapProfile.DEFAULT_EARTHLIKE,
                VanilaMapProfile.EARTHLIKE
            },
            {
                VanilaMapProfile.DEFAULT_MARS,
                VanilaMapProfile.MARS
            },
            {
                VanilaMapProfile.DEFAULT_TRITON,
                VanilaMapProfile.TRITON
            },
            {
                VanilaMapProfile.DEFAULT_ALIEN,
                VanilaMapProfile.ALIEN
            },
            {
                VanilaMapProfile.DEFAULT_PERTAM,
                VanilaMapProfile.PERTAM
            },
            {
                VanilaMapProfile.DEFAULT_TITAN,
                VanilaMapProfile.TITAN
            },
            {
                VanilaMapProfile.DEFAULT_MOON,
                VanilaMapProfile.MOON
            },
            {
                VanilaMapProfile.DEFAULT_EUROPA,
                VanilaMapProfile.EUROPA
            },
            // EXTENDED SURVIVAL
            {
                ExtendedSurvivalMapProfile.DEFAULT_OI,
                ExtendedSurvivalMapProfile.OI
            },            
            {
                ExtendedSurvivalMapProfile.DEFAULT_SPATAT,
                ExtendedSurvivalMapProfile.SPATAT
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                ExtendedSurvivalMapProfile.ENITOR
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                ExtendedSurvivalMapProfile.EREMUS_NUBIS
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                ExtendedSurvivalMapProfile.DOVER
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                ExtendedSurvivalMapProfile.TOTHT
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS,
                ExtendedSurvivalMapProfile.GLEDIUS_NUBIS
            },
            {
                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS,
                ExtendedSurvivalMapProfile.CAPUTALIS_NUBIS
            },
            // ATA MOD STARS
            {
                ATAMapProfile.ATA_STAR_TEST,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_002,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_003,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_005,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_007,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_010,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_022,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_029,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_057,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            {
                ATAMapProfile.ATA_STAR_147,
                ATAMapProfile.ATA_STAR_PROFILE
            },
            // ATA MOD
            {
                ATAMapProfile.ATA_00_SUN,
                ATAMapProfile.ATA_SUN_PROFILE
            },
            {
                ATAMapProfile.ATA_01_MERCURY,
                ATAMapProfile.ATA_01_MERCURY_PROFILE
            },
            {
                ATAMapProfile.ATA_02_VENUS,
                ATAMapProfile.ATA_02_VENUS_PROFILE
            },
            {
                ATAMapProfile.ATA_03_EARTH,
                ATAMapProfile.ATA_03_EARTH_PROFILE
            },
            {
                ATAMapProfile.ATA_03_MOON,
                ATAMapProfile.ATA_03_MOON_PROFILE
            },
            {
                ATAMapProfile.ATA_04_MARS,
                ATAMapProfile.ATA_04_MARS_PROFILE
            },
            {
                ATAMapProfile.ATA_05_JUPITER,
                ATAMapProfile.ATA_05_JUPITER_PROFILE
            },
            {
                ATAMapProfile.ATA_05_CALLISTO,
                ATAMapProfile.ATA_05_CALLISTO_PROFILE
            },
            {
                ATAMapProfile.ATA_05_GANYMEDE,
                ATAMapProfile.ATA_05_GANYMEDE_PROFILE
            },
            {
                ATAMapProfile.ATA_05_EUROPA,
                ATAMapProfile.ATA_05_EUROPA_PROFILE
            },
            {
                ATAMapProfile.ATA_05_IO,
                ATAMapProfile.ATA_05_IO_PROFILE
            },
            {
                ATAMapProfile.ATA_06_SATURN,
                ATAMapProfile.ATA_06_SATURN_PROFILE
            },
            {
                ATAMapProfile.ATA_06_IAPETUS,
                ATAMapProfile.ATA_06_IAPETUS_PROFILE
            },
            {
                ATAMapProfile.ATA_06_TITAN,
                ATAMapProfile.ATA_06_TITAN_PROFILE
            },
            {
                ATAMapProfile.ATA_06_RHEA,
                ATAMapProfile.ATA_06_RHEA_PROFILE
            },
            {
                ATAMapProfile.ATA_06_DIONE,
                ATAMapProfile.ATA_06_DIONE_PROFILE
            },
            {
                ATAMapProfile.ATA_06_TETHYS,
                ATAMapProfile.ATA_06_TETHYS_PROFILE
            },
            {
                ATAMapProfile.ATA_06_ENCELADUS,
                ATAMapProfile.ATA_06_ENCELADUS_PROFILE
            },
            {
                ATAMapProfile.ATA_06_MIMAS,
                ATAMapProfile.ATA_06_MIMAS_PROFILE
            },
            {
                ATAMapProfile.ATA_07_URANUS,
                ATAMapProfile.ATA_07_URANUS_PROFILE
            },
            {
                ATAMapProfile.ATA_07_OBREON,
                ATAMapProfile.ATA_07_OBREON_PROFILE
            },
            {
                ATAMapProfile.ATA_07_TITANIA,
                ATAMapProfile.ATA_07_TITANIA_PROFILE
            },
            {
                ATAMapProfile.ATA_07_UMBRIEL,
                ATAMapProfile.ATA_07_UMBRIEL_PROFILE
            },
            {
                ATAMapProfile.ATA_07_ARIEL,
                ATAMapProfile.ATA_07_ARIEL_PROFILE
            },
            {
                ATAMapProfile.ATA_07_MIRANDA,
                ATAMapProfile.ATA_07_MIRANDA_PROFILE
            },
            {
                ATAMapProfile.ATA_08_NEPTUNE,
                ATAMapProfile.ATA_08_NEPTUNE_PROFILE
            },
            {
                ATAMapProfile.ATA_08_TRITON,
                ATAMapProfile.ATA_08_TRITON_PROFILE
            },
            {
                ATAMapProfile.ATA_09_PLUTO,
                ATAMapProfile.ATA_09_PLUTO_PROFILE
            },
            {
                ATAMapProfile.ATA_09_CHARON,
                ATAMapProfile.ATA_09_CHARON_PROFILE
            },
            // SAMs
            {
                SamMapProfile.DEFAULT_HELIOSTERRAFORMED,
                SamMapProfile.HELIOSTERRAFORMED
            },
            {
                SamMapProfile.DEFAULT_HELIOSTERRAFORMEDWM,
                SamMapProfile.HELIOSTERRAFORMEDWM
            },
            // Elindis
            {
                ElindisMapProfile.DEFAULT_PYKE,
                ElindisMapProfile.PYKE
            },
            {
                ElindisMapProfile.DEFAULT_SILONA,
                ElindisMapProfile.SILONA
            },
            {
                ElindisMapProfile.DEFAULT_SAPRIMENTAS,
                ElindisMapProfile.IsUsingSaprimentasReimagined() ? ElindisMapProfile.SAPRIMENTAS_REIMAGINED : ElindisMapProfile.SAPRIMENTAS
            },
            // CaptainArthur
            {
                CaptainArthurMapProfile.DEFAULT_CRAIT,
                CaptainArthurMapProfile.CRAIT
            },
            {
                CaptainArthurMapProfile.DEFAULT_PLANET26,
                CaptainArthurMapProfile.PLANET26
            },
            // Balmung
            {
                BalmungMapProfile.DEFAULT_BLACKHOLE,
                BalmungMapProfile.BLACKHOLE
            },
            {
                BalmungMapProfile.DEFAULT_BLACKHOLE_NODISK,
                BalmungMapProfile.BLACKHOLE
            },
            // MLTMods
            {
                MLTModsMapProfile.DEFAULT_SEDONIA,
                MLTModsMapProfile.SEDONIA
            },
            {
                MLTModsMapProfile.DEFAULT_IRENE1C,
                MLTModsMapProfile.IRENE1C
            },
            // RheaLicious
            {
                RheaLiciousMapProfile.DEFAULT_MILA,
                RheaLiciousMapProfile.MILA
            },
            // Infinite
            {
                InfiniteMapProfile.DEFAULT_HALCYON,
                InfiniteMapProfile.HALCYON
            },
            {
                InfiniteMapProfile.DEFAULT_PENUMBRA,
                InfiniteMapProfile.PENUMBRA
            },
            {
                InfiniteMapProfile.DEFAULT_VALKOR,
                InfiniteMapProfile.VALKOR
            },
            {
                InfiniteMapProfile.DEFAULT_ORCUS,
                InfiniteMapProfile.ORCUS
            },
            // GHOSTXV
            {
                GHOSTXVMapProfile.DEFAULT_AVALAN,
                GHOSTXVMapProfile.AVALAN
            },
            {
                GHOSTXVMapProfile.DEFAULT_NYOTA,
                GHOSTXVMapProfile.NYOTA
            },
            // FIZZY
            {
                FizzyMapProfile.DEFAULT_CHIMERA,
                FizzyMapProfile.CHIMERA
            },
            {
                FizzyMapProfile.DEFAULT_ZIRA,
                FizzyMapProfile.ZIRA
            },
            // Major Jon
            {
                MajorJonMapProfile.DEFAULT_TRELAN,
                MajorJonMapProfile.TRELAN
            },
            {
                MajorJonMapProfile.DEFAULT_SATREUS,
                MajorJonMapProfile.SATREUS
            },
            {
                MajorJonMapProfile.DEFAULT_KIMI,
                MajorJonMapProfile.KIMI
            },
            {
                MajorJonMapProfile.DEFAULT_QUN,
                MajorJonMapProfile.QUN
            },
            {
                MajorJonMapProfile.DEFAULT_LUMA,
                MajorJonMapProfile.LUMA
            },
            {
                MajorJonMapProfile.DEFAULT_TOHIL,
                MajorJonMapProfile.TOHIL
            },
            {
                MajorJonMapProfile.DEFAULT_TEAL,
                MajorJonMapProfile.TEAL
            },
            {
                MajorJonMapProfile.DEFAULT_TEALWM,
                MajorJonMapProfile.TEAL
            },
            {
                MajorJonMapProfile.DEFAULT_ORLUNDA,
                MajorJonMapProfile.ORLUNDA
            },
            // Shard
            {
                ShardMapProfile.DEFAULT_SAFINA,
                ShardMapProfile.SAFINA
            },
            {
                ShardMapProfile.DEFAULT_THANIAN,
                ShardMapProfile.THANIAN
            },
            {
                ShardMapProfile.DEFAULT_RISHA,
                ShardMapProfile.RISHA
            },
            // Almirante Orloc
            {
                AlmiranteOrlocProfile.DEFAULT_OBJECT85,
                AlmiranteOrlocProfile.OBJECT85
            }
        };

        public static PlanetProfile Get(string key)
        {
            if (PROFILES.ContainsKey(key))
                return PROFILES[key];
            return PROFILES[DEFAULT_PROFILE];
        }

        public static string GetMappedProfiles()
        {
            var sb = new StringBuilder();

            var groups = PROFILES.GroupBy(x => x.Value.Origin).ToDictionary(k => k.Key, v => v.AsEnumerable());

            foreach (var g in groups.Keys)
            {
                sb.AppendLine($"Group: {g}");
                foreach (var item in groups[g].OrderBy(x => x.Value.OriginId))
                {
                    if (item.Value.OriginId != 0)
                    {
                        sb.AppendLine($"- {item.Key} : https://steamcommunity.com/sharedfiles/filedetails/?id={item.Value.OriginId}");
                    }
                    else
                    {
                        sb.AppendLine($"- {item.Key}");
                    }
                }
                sb.AppendLine("");
            }
            return sb.ToString();
        }

    }

}
