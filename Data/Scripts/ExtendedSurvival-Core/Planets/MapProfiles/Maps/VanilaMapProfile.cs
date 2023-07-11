using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class VanilaMapProfile
    {

        public const string DEFAULT_EARTHLIKE = "EARTHLIKE";
        public const string DEFAULT_ALIEN = "ALIEN";
        public const string DEFAULT_MARS = "MARS";
        public const string DEFAULT_PERTAM = "PERTAM";
        public const string DEFAULT_TRITON = "TRITON";
        public const string DEFAULT_MOON = "MOON";
        public const string DEFAULT_EUROPA = "EUROPA";
        public const string DEFAULT_TITAN = "TITAN";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> EARTHLIKE_ORES =
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

        public static readonly List<PlanetProfile.OreMapInfo> ALIEN_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Titanium_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
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
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> MARS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
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

        public static readonly List<PlanetProfile.OreMapInfo> PERTAM_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Sulfur_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
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
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> TRITON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
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

        public static readonly List<PlanetProfile.OreMapInfo> MOON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Zinc_01
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

        public static readonly List<PlanetProfile.OreMapInfo> EUROPA_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
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

        public static readonly List<PlanetProfile.OreMapInfo> TITAN_ORES =
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

        public static readonly PlanetProfile.MeteorImpactInfo EARTHLIKE_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        public static readonly PlanetProfile.MeteorImpactInfo ALIEN_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "AlienIcelandArea",
                    chanceToSpawn = 0.25f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "AlienForestArea",
                    chanceToSpawn = 0.5f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "AlienDesertArea",
                    chanceToSpawn = 0.25f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo MARS_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        public static readonly PlanetProfile.MeteorImpactInfo PERTAN_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        public static readonly PlanetProfile.MeteorImpactInfo TRITON_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "EarthSnowArea",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo MOON_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        public static readonly PlanetProfile.MeteorImpactInfo EUROPA_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        public static readonly PlanetProfile.MeteorImpactInfo TITAN_METEOR = new PlanetProfile.MeteorImpactInfo()
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

        // Planets

        public static readonly PlanetProfile EARTHLIKE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.011f, -0.4f, 0, 0),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = EARTHLIKE_ORES,
            MeteorImpact = EARTHLIKE_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile ALIEN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_03,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1f, 0.15f, 80, 2, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(true, 1.03f, 0.4f, 0.5f, 0.25f),
            SizeRange = new Vector2(50, 70),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = ALIEN_ORES,
            MeteorImpact = ALIEN_METEOR,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile MARS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(0, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_02,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
            Gravity = PlanetMapProfile.GetGravity(0.9f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = MARS_ORES,
            MeteorImpact = MARS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile PERTAM = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#000000",
            ColorInfluence = new Vector2I(200, 200),
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.8f, 80, 2, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(1.2f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(65, 85),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = PERTAM_ORES,
            MeteorImpact = PERTAN_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile TRITON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 1.25f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 65),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = TRITON_ORES,
            MeteorImpact = TRITON_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        // Moons

        public static readonly PlanetProfile MOON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#FFFFFF",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 50),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.SmallGroup,
            Ores = MOON_ORES,
            MeteorImpact = MOON_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile EUROPA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 45),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.SmallGroup,
            Ores = EUROPA_ORES,
            MeteorImpact = EUROPA_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile TITAN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(0, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0.25f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 40),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.SmallGroup,
            Ores = TITAN_ORES,
            MeteorImpact = TITAN_METEOR,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING
        };

    }

}
