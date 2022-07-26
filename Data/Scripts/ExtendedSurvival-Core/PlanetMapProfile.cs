using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival
{

    public static class PlanetMapProfile
    {

        public class OreType
        {

            public string Name { get; set; }
            public PlanetProfile.OreMapInfo DefaultInfo { get; set; }

        }

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

        public const ulong EARTHLIKE_ANIMALS_MODID = 2170447225;

        public const string DEFAULT_PROFILE = "DEFAULT";

        public const string DEFAULT_EARTHLIKE = "EARTHLIKE";
        public const string DEFAULT_ALIEN = "ALIEN";
        public const string DEFAULT_MARS = "MARS";
        public const string DEFAULT_OI = "OI";
        public const string DEFAULT_PERTAM = "PERTAM";
        public const string DEFAULT_TRITON = "TRITON";
        public const string DEFAULT_MOON = "MOON";
        public const string DEFAULT_EUROPA = "EUROPA";
        public const string DEFAULT_SPATAT = "SPATAT";
        public const string DEFAULT_TITAN = "TITAN";

        public const ulong ATA_MODID = 1697074695;

        public const string ATA_00_SUN = "ATA 00 SUN";
        public const string ATA_01_MERCURY = "ATA 01 MERCURY";
        public const string ATA_02_VENUS = "ATA 02 VENUS";
        public const string ATA_03_EARTH = "ATA 03 EARTH";
        public const string ATA_03_MOON = "ATA 03.MOON";
        public const string ATA_04_MARS = "ATA 04 Mars";
        public const string ATA_05_JUPITER = "ATA 05 Jupiter";
        public const string ATA_05_CALLISTO = "ATA 05....Callisto";
        public const string ATA_05_GANYMEDE = "ATA 05...Ganymede";
        public const string ATA_05_EUROPA = "ATA 05..Europa";
        public const string ATA_05_IO = "ATA 05.Io";
        public const string ATA_06_SATURN = "ATA 06 Saturn";
        public const string ATA_06_IAPETUS = "ATA 06.......Iapetus";
        public const string ATA_06_TITAN = "ATA 06......Titan";
        public const string ATA_06_RHEA = "ATA 06.....Rhea";
        public const string ATA_06_DIONE = "ATA 06....Dione";
        public const string ATA_06_TETHYS = "ATA 06...Tethys";
        public const string ATA_06_ENCELADUS = "ATA 06..Enceladus";
        public const string ATA_06_MIMAS = "ATA 06.Mimas";
        public const string ATA_07_URANUS = "ATA 07 Uranus";
        public const string ATA_07_OBREON = "ATA 07.....Obreon";
        public const string ATA_07_TITANIA = "ATA 07....Titania";
        public const string ATA_07_UMBRIEL = "ATA 07...Umbriel";
        public const string ATA_07_ARIEL = "ATA 07..Ariel";
        public const string ATA_07_MIRANDA = "ATA 07.Miranda";
        public const string ATA_08_NEPTUNE = "ATA 08 Neptune";
        public const string ATA_08_TRITON = "ATA 08.Triton";
        public const string ATA_09_PLUTO = "ATA 09 Pluto";
        public const string ATA_09_CHARON = "ATA 09.Charon";

        private static readonly PlanetProfile.AnimalInfo DEFAULT_EARTH = new PlanetProfile.AnimalInfo()
        {
            types = MyAPIGateway.Session.Mods.Any(x => EARTHLIKE_ANIMALS_MODID == x.PublishedFileId) ? new string[] { "Wolf", "deer_bot", "deerbuck_bot", "Horse_Bot", "Cow_Bot", "Sheep_Bot" } : new string[] { "Wolf" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(2, 4)
            }
        };

        private static readonly PlanetProfile.AnimalInfo DEFAULT_WOLF = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "Wolf" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(2, 4)
            }
        };

        private static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_01 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpiderBrown", "SpaceSpiderBlack" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        private static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_02 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpider", "SpaceSpiderGreen" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        private static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_03 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpider", "SpaceSpiderGreen", "SpaceSpiderBrown", "SpaceSpiderBlack" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        private static readonly PlanetProfile.AnimalInfo DEFAULT_NO_ANIMALS = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                spawnDelay = Vector2I.Zero,
                spawnDist = Vector2I.Zero,
                waveCount = Vector2I.Zero
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                spawnDelay = Vector2I.Zero,
                spawnDist = Vector2I.Zero,
                waveCount = Vector2I.Zero
            }
        };

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
            }
        };

        private static PlanetProfile.AtmosphereInfo GetAtmosphere(bool enabled, bool breathable = false, float density = 0f, float oxygenDensity = 0f, float maxWindSpeed = 0f, float limitAltitude = 0f, float toxicLevel = 0f, float radiationLevel = 0f)
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

        private static PlanetProfile.WaterInfo GetWater(bool enabled, float size = 0f, float factor = 0f, float toxicLevel = 0f, float radiationLevel = 0f)
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

        private static PlanetProfile.TemperatureInfo GetTemperature(VRage.Game.MyTemperatureLevel level, float min, float max, bool useRangeTemperature = false)
        {
            return new PlanetProfile.TemperatureInfo()
            {
                temperatureLevel = level,
                temperatureRange = new Vector2(min, max),
                useRangeTemperature = useRangeTemperature
            };
        }

        private static PlanetProfile.GravityInfo GetGravity(float surface, float fallOff)
        {
            return new PlanetProfile.GravityInfo()
            {
                surfaceGravity = surface,
                gravityFalloffPower = fallOff
            };
        }

        private static PlanetProfile.GeothermalInfo GetGeothermal(bool enabled, float depthMultiplier = 1f, float rowSizeMultiplier = 1f, float powerMultiplier = 1f)
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

        private static PlanetProfile.OreMapInfo GetOreMap(string type, float ammountMultiplier = 1f)
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

        private static readonly Dictionary<string, PlanetProfile> PROFILES = new Dictionary<string, PlanetProfile>()
        {
            {
                DEFAULT_PROFILE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.NotDefined,
                    Version = 5,
                    Animal = DEFAULT_SPIDERS_01,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(1, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Cobalt_01, 2)
                    }
                }
            },
            {
                DEFAULT_EARTHLIKE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#616c83",
                    Animal = DEFAULT_EARTH,
                    Geothermal = GetGeothermal(true),
                    Atmosphere = GetAtmosphere(true, true, 1, 0.9f, 80, 2, 0, 0),
                    Gravity = GetGravity(1, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
                    Water = GetWater(true, 1.025f, -0.4f, 0, 0),
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Cobalt_01, 2)
                    }
                }
            },
            {
                DEFAULT_TRITON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    Animal = DEFAULT_WOLF,
                    Geothermal = GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
                    Atmosphere = GetAtmosphere(true, true, 1, 0.9f, 80, 0.5f, 0, 0),
                    Gravity = GetGravity(1, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Magnesium_01, 2)
                    }
                }
            },
            {
                DEFAULT_MARS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    TargetColor = "#616c83",
                    ColorInfluence = 15,
                    Animal = DEFAULT_SPIDERS_02,
                    Geothermal = GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
                    Gravity = GetGravity(0.9f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 5),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Ice_01, 3),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                DEFAULT_PERTAM,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    TargetColor = "#000000",
                    ColorInfluence = 200,
                    Animal = DEFAULT_SPIDERS_01,
                    Geothermal = GetGeothermal(true, powerMultiplier: 0.75f),
                    Atmosphere = GetAtmosphere(true, true, 1, 0.8f, 80, 2, 0.05f, 0),
                    Gravity = GetGravity(1.2f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 5),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                DEFAULT_OI,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
                    Version = 5,
                    ColorInfluence = 100,
                    TargetColor = "#abab9a",
                    Animal = DEFAULT_SPIDERS_01,
                    Geothermal = GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
                    Atmosphere = GetAtmosphere(true, false, 1, 0, 0, 1, 0.25f, 0.15f),
                    Gravity = GetGravity(0.4f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 10, 120),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Uraninite_01, 2)
                    }
                }
            },
            {
                DEFAULT_TITAN,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#616c83",
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1, 0, 80, 1, 0.25f, 0.05f),
                    Gravity = GetGravity(0.25f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                DEFAULT_SPATAT,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#616c83",
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 0.3f, 0, 0, 0.1f, 0.5f, 0.15f),
                    Gravity = GetGravity(0.25f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                DEFAULT_MOON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#FFFFFF",
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.25f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                DEFAULT_EUROPA,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#616c83",
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1, 0, 80, 1, 0, 0),
                    Gravity = GetGravity(0.25f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                DEFAULT_ALIEN,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.Vanila,
                    Version = 5,
                    ColorInfluence = 15,
                    TargetColor = "#616c83",
                    Animal = DEFAULT_SPIDERS_03,
                    Geothermal = GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
                    Atmosphere = GetAtmosphere(true, true, 1f, 0.15f, 80, 2, 0.25f, 0.15f),
                    Gravity = GetGravity(1.1f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
                    Water = GetWater(true, 1.025f, 0.4f, 0.5f, 0.25f),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Uraninite_01, 2)
                    }
                }
            },
            {
                ATA_00_SUN,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(true, depthMultiplier: 0.1f, rowSizeMultiplier: 0.25f, powerMultiplier: 5f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0, 170, 1000, 2.5f, 5f),
                    Gravity = GetGravity(28f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 1250, 5600, true),
                    Water = GetWater(false)
                }
            },
            {
                ATA_01_MERCURY,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(true, depthMultiplier: 0.5f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0, 15, 5, 0.25f, 0.15f),
                    Gravity = GetGravity(0.38f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 120, 360, true),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4)
                    }
                }
            },
            {
                ATA_02_VENUS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(true, depthMultiplier: 1f, rowSizeMultiplier: 0.5f, powerMultiplier: 0.75f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0, 380, 5, 0.5f, 0.05f),
                    Gravity = GetGravity(0.9f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 420, 980, true),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Silicon_01, 4)
                    }
                }
            },
            {
                ATA_03_EARTH,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_EARTH,
                    Geothermal = GetGeothermal(true),
                    Atmosphere = GetAtmosphere(true, true, 1, 0.9f, 372, 5, 0, 0),
                    Gravity = GetGravity(1, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
                    Water = GetWater(true, 1.025f, -0.4f, 0, 0),
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Cobalt_01, 2)
                    }
                }
            },
            {
                ATA_03_MOON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.25f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_04_MARS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_SPIDERS_02,
                    Geothermal = GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
                    Gravity = GetGravity(0.38f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 5,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 5),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Ice_01, 3),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                ATA_05_JUPITER,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 580, 5, 0.5f, 0.75f),
                    Gravity = GetGravity(1.25f, 1.3f),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Uraninite_01, 2)
                    }
                }
            },
            {
                ATA_05_CALLISTO,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.126f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3),
                        GetOreMap(Uraninite_01, 2)
                    }
                }
            },
            {
                ATA_05_GANYMEDE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.134f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3),
                        GetOreMap(Uraninite_01, 2)
                    }
                }
            },
            {
                ATA_05_EUROPA,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.134f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_05_IO,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.183f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_SATURN,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 580, 5, 0.15f, 0.05f),
                    Gravity = GetGravity(1.05f, 1.6f),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Ice_01, 6),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                ATA_06_IAPETUS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1228f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_TITAN,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.138f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_RHEA,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1269f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_DIONE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1236f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_TETHYS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1148f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_ENCELADUS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1113f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_06_MIMAS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.10648f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_07_URANUS,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 350, 5, 0.15f, 0.05f),
                    Gravity = GetGravity(1f, 1.7f),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Ice_01, 6),
                        GetOreMap(Magnesium_01, 2),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                ATA_07_OBREON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1387f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_07_TITANIA,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1387f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_07_UMBRIEL,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1235f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_07_ARIEL,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.127f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_07_MIRANDA,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.108f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_08_NEPTUNE,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 350, 5, 0.15f, 0.05f),
                    Gravity = GetGravity(1f, 1.8f),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 3,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Nickel_01, 4),
                        GetOreMap(Ice_01, 6),
                        GetOreMap(Silver_01, 2),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                ATA_08_TRITON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.1387f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
            },
            {
                ATA_09_PLUTO,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(true, false, 1f, 0f, 10, 5, 0.15f, 0.05f),
                    Gravity = GetGravity(0.6f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Nickel_01, 3),
                        GetOreMap(Magnesium_01, 3),
                        GetOreMap(Platinum_01, 2)
                    }
                }
            },
            {
                ATA_09_CHARON,
                new PlanetProfile()
                {
                    Origin = PlanetProfile.PlanetOrigin.OtherMod,
                    OriginId = ATA_MODID,
                    Version = 5,
                    Animal = DEFAULT_NO_ANIMALS,
                    Geothermal = GetGeothermal(false),
                    Atmosphere = GetAtmosphere(false),
                    Gravity = GetGravity(0.3f, 1),
                    Temperature = GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
                    Water = GetWater(false),
                    MaxGroupSize = 5,
                    StartBreak = 2,
                    Ores = new List<PlanetProfile.OreMapInfo>()
                    {
                        GetOreMap(Iron_02, 4),
                        GetOreMap(Silicon_01, 4),
                        GetOreMap(Silver_01, 3),
                        GetOreMap(Gold_01, 3)
                    }
                }
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
