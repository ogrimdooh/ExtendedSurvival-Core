﻿using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class CaptainArthurMapProfile
    {

        public const ulong CRAIT_MODID = 2394305855;
        public const ulong PLANET26_MODID = 2079185441;

        public const string DEFAULT_CRAIT = "PLANET-CRAIT";
        public const string DEFAULT_PLANET26 = "PLANET-26";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> CRAIT_ORES =
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
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Lead_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Uraninite_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> PLANET26_ORES =
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
                    PlanetMapProfile.Carbon_01,
                    PlanetMapProfile.Lead_01
                },
                new string[]
                {
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
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        // Planets
        public static readonly PlanetProfile CRAIT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = CRAIT_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.0f, 0.5f, 80, 2.0f, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1, 4.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 70, 165),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            Ores = CRAIT_ORES,
            MeteorImpact = VanilaMapProfile.ALIEN_METEOR,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile PLANET26 = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = PLANET26_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.011f, -0.4f, 0, 0),
            SizeRange = new Vector2(110, 150),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            Ores = PLANET26_ORES,
            MeteorImpact = VanilaMapProfile.EARTHLIKE_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

    }

}
