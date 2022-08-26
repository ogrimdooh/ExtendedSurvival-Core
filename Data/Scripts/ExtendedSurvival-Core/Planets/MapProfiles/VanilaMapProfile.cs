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
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Sulfor_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Cobalt_01
                },
                null
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
                    PlanetMapProfile.Sulfor_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
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
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfor_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                null
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
                    PlanetMapProfile.Sulfor_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                null
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
                null
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
                    PlanetMapProfile.Aluminum_01
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
                null
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
                null
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
                null
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

        // Planets

        public static readonly PlanetProfile EARTHLIKE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            ColorInfluence = 15,
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.03f, -0.4f, 0, 0),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 5,
            StartBreak = 5,
            Ores = EARTHLIKE_ORES
        };

        public static readonly PlanetProfile ALIEN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 15,
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_03,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1f, 0.15f, 80, 2, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(true, 1.03f, 0.4f, 0.5f, 0.25f),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 5,
            StartBreak = 3,
            Ores = ALIEN_ORES
        };

        public static readonly PlanetProfile MARS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = 15,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_02,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
            Gravity = PlanetMapProfile.GetGravity(0.9f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(80, 90),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 5,
            StartBreak = 5,
            Ores = MARS_ORES
        };

        public static readonly PlanetProfile PERTAM = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#000000",
            ColorInfluence = 200,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.8f, 80, 2, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(1.2f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 5,
            StartBreak = 3,
            Ores = PERTAM_ORES
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
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 5,
            StartBreak = 3,
            Ores = TRITON_ORES
        };

        // Moons

        public static readonly PlanetProfile MOON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 15,
            TargetColor = "#FFFFFF",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 50),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 5,
            StartBreak = 2,
            Ores = MOON_ORES
        };

        public static readonly PlanetProfile EUROPA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 15,
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 50),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 5,
            StartBreak = 2,
            Ores = EUROPA_ORES
        };

        public static readonly PlanetProfile TITAN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 15,
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0.25f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 40),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 5,
            StartBreak = 2,
            Ores = TITAN_ORES
        };

    }

}
