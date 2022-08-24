using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class PlanetMapProfile
    {

        public class OreType
        {

            public string Name { get; set; }
            public PlanetProfile.OreMapInfo DefaultInfo { get; set; }

        }

        public const int PROFILE_VERSION = 7;

        public const ulong EARTHLIKE_ANIMALS_MODID = 2170447225;

        // Valina
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

        // ES Technology
        public const string Aluminum_01 = "Aluminum_01";
        public const string Copper_01 = "Copper_01";
        public const string Lead_01 = "Lead_01";
        public const string Sulfor_01 = "Sulfor_01";
        public const string Carbon_01 = "Carbon_01";
        public const string Potassium_01 = "Potassium_01";
        public const string Lithium_01 = "Lithium_01";

        public static readonly string[] ESTechnologyOres = new string[] 
        { 
            Aluminum_01, 
            Copper_01, 
            Lead_01, 
            Sulfor_01, 
            Carbon_01,
            Potassium_01, 
            Lithium_01 
        };

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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
                    }
                }
            },
            {
                Sulfor_01,
                new OreType()
                {
                    Name = Sulfor_01,
                    DefaultInfo = new PlanetProfile.OreMapInfo()
                    {
                        type = Sulfor_01,
                        start = new Vector2I(15, 50),
                        depth = new Vector2I(10, 25),
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
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
                        ammount = 3
                    }
                }
            }
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

        public static PlanetProfile.TemperatureInfo GetTemperature(VRage.Game.MyTemperatureLevel level, float min, float max, bool useRangeTemperature = false)
        {
            return new PlanetProfile.TemperatureInfo()
            {
                temperatureLevel = level,
                temperatureRange = new Vector2(min, max),
                useRangeTemperature = useRangeTemperature
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

        public static PlanetProfile.OreMapInfo GetOreMap(string type, float ammountMultiplier = 1f)
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
                ammount = (int)(baseInfo.DefaultInfo.ammount * ammountMultiplier)
            };
        }

        public static List<PlanetProfile.OreMapInfo> BuildOreMap(string[] common, string[] uncommon, string[] rare, string[] legendary, float multiplierCommon = 1f, float multiplierUncommon = 1f, float multiplierRare = 1f, float multiplierLegendary = 1f)
        {
            var retorno = new List<PlanetProfile.OreMapInfo>();
            if (common != null && common.Any())
            {
                foreach (var item in common)
                {
                    retorno.Add(GetOreMap(item, 4f * multiplierCommon));
                }
            }
            if (uncommon != null && uncommon.Any())
            {
                foreach (var item in uncommon)
                {
                    retorno.Add(GetOreMap(item, 3f * multiplierUncommon));
                }
            }
            if (rare != null && rare.Any())
            {
                foreach (var item in rare)
                {
                    retorno.Add(GetOreMap(item, 2f * multiplierRare));
                }
            }
            if (legendary != null && legendary.Any())
            {
                foreach (var item in legendary)
                {
                    retorno.Add(GetOreMap(item, 1f * multiplierLegendary));
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
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores =
                    ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                    new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Aluminum_01, 4),
                        GetOreMap(Copper_01, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Lead_01, 3),
                        GetOreMap(Sulfor_01, 3),
                        GetOreMap(Carbon_01, 3),
                        GetOreMap(Potassium_01, 2),
                        GetOreMap(Cobalt_01, 2)
                    }
                    :
                    new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Magnesium_01, 2),
                        GetOreMap(Cobalt_01, 2),
                        GetOreMap(Gold_01, 2),
                        GetOreMap(Silver_01, 2)
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
            }
        };

        public static PlanetProfile Get(string key)
        {
            if (PROFILES.ContainsKey(key))
                return PROFILES[key];
            return PROFILES[DEFAULT_PROFILE];
        }

    }

}
