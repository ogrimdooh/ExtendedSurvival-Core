using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ExtendedSurvivalMapProfile
    {

        public const string DEFAULT_OI = "OI";
        public const string DEFAULT_SPATAT = "SPATAT";
        public const string DEFAULT_ENITOR = "ENITOR";
        public const string DEFAULT_EREMUS_NUBIS = "EREMUS NUBIS";
        public const string DEFAULT_DOVER = "DOVER";
        public const string DEFAULT_TOTHT = "TOTHT";
        public const string DEFAULT_GLEDIUS_NUBIS = "GLEDIUS NUBIS";
        public const string DEFAULT_CAPUTALIS_NUBIS = "CAPUTALIS NUBIS";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> OI_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Sulfur_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                    PlanetMapProfile.Iridium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> SPATAT_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ENITOR_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01
                },
                new string[]
                {
                    PlanetMapProfile.Beryllium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> EREMUS_NUBIS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Sulfur_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01
                },
                new string[]
                {
                    PlanetMapProfile.Tungsten_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> DOVER_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Silicon_01,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Potassium_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> TOTHT_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01,
                    PlanetMapProfile.Plutonium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> GLEDIUS_NUBIS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> CAPUTALIS_NUBIS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly PlanetProfile.MeteorImpactInfo OI_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "Stones",
                    modifierId = "Oi",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo SPATAT_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "Stones",
                    modifierId = "Spatat",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo TOTHT_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthDesertArea",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo GLEDIUS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "Europa",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo EREMUS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "Mars",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo ENITOR_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "AlienDesertArea",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo DOVER_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "EarthSnowArea",
                    chanceToSpawn = 0.25f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthForestArea",
                    chanceToSpawn = 0.5f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthDesertArea",
                    chanceToSpawn = 0.25f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo CAPUTALIS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "Moon",
                    chanceToSpawn = 0.75f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "Moon",
                    chanceToSpawn = 0.25f
                }
            }
        };

        // Planets

        public static readonly PlanetProfile OI = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 100),
            TargetColor = "#abab9a",
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 0, 2, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.4f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 10, 120),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 3,
            Ores = OI_ORES,
            MeteorImpact = OI_METEOR
        };

        public static readonly PlanetProfile SPATAT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.3f, 0, 0, 2, 0.5f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = SPATAT_ORES,
            MeteorImpact = SPATAT_METEOR
        };

        public static readonly PlanetProfile ENITOR = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.85f, 80, 3, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.05f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 25),
            Water = PlanetMapProfile.GetWater(true, 1.0125f, -0.4f, 0.15f, 0.05f),
            SizeRange = new Vector2(50, 70),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 3,
            Ores = ENITOR_ORES,
            MeteorImpact = ENITOR_METEOR
        };

        public static readonly PlanetProfile EREMUS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.6f, 0.35f, 50, 2, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.15f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 15, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(60, 80),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 3,
            Ores = EREMUS_NUBIS_ORES,
            MeteorImpact = EREMUS_NUBIS_METEOR
        };

        public static readonly PlanetProfile DOVER = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 3, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.01305f, -0.4f, 0, 0),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 6,
            Ores = DOVER_ORES,
            MeteorImpact = DOVER_METEOR
        };

        public static readonly PlanetProfile TOTHT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.25f, 0.75f, 120, 6, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(1.9f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 15, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 3,
            Ores = TOTHT_ORES,
            MeteorImpact = TOTHT_METEOR
        };

        public static readonly PlanetProfile GLEDIUS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.35f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = GLEDIUS_NUBIS_ORES,
            MeteorImpact = GLEDIUS_NUBIS_METEOR
        };

        public static readonly PlanetProfile CAPUTALIS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_02,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.3f, 0, 40, 0.5f, 0.5f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(0.42f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = CAPUTALIS_NUBIS_ORES,
            MeteorImpact = CAPUTALIS_NUBIS_METEOR
        };

    }

}
