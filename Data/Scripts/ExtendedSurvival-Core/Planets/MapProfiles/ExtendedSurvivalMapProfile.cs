﻿using System.Collections.Generic;
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

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> OI_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01
                },
                new string[]
                {
                    PlanetMapProfile.Copper_01,
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
                    PlanetMapProfile.Sulfor_01
                },
                new string[]
                {
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

        public static readonly List<PlanetProfile.OreMapInfo> DOVER_ORES =
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

        // Planets

        public static readonly PlanetProfile OI = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 100,
            TargetColor = "#abab9a",
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 0, 1, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.4f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 10, 120),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(60, 80),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 1,
            MaxGroupSize = 5,
            StartBreak = 3,
            Ores = OI_ORES
        };

        public static readonly PlanetProfile SPATAT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = 15,
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.3f, 0, 0, 0.1f, 0.5f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Moon,
            ParentPlanet = new List<string>() { VanilaMapProfile.DEFAULT_TRITON, DEFAULT_ENITOR },
            MaxGroupSize = 5,
            StartBreak = 2,
            Ores = SPATAT_ORES
        };

        public static readonly PlanetProfile ENITOR = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.85f, 80, 2, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.05f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 25),
            Water = PlanetMapProfile.GetWater(true, 1.0125f, -0.4f, 0.15f, 0.05f),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 2,
            MaxGroupSize = 5,
            StartBreak = 5,
            Ores = ENITOR_ORES
        };

        public static readonly PlanetProfile EREMUS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.6f, 0.35f, 50, 4, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.15f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 15, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 3,
            MaxGroupSize = 5,
            StartBreak = 5,
            Ores = EREMUS_NUBIS_ORES
        };

        public static readonly PlanetProfile DOVER = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 5, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0125f, -0.4f, 0, 0),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(1, 1),
            Order = 4,
            MaxGroupSize = 5,
            StartBreak = 5,
            Ores = DOVER_ORES
        };

    }

}
