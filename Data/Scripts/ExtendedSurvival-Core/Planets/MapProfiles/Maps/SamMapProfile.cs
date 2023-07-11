using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class SamMapProfile
    {

        public const ulong HELIOSTERRAFORMED_MODID = 2781746013;
        public const ulong HELIOSTERRAFORMEDWM_MODID = 2783291521;

        public const string DEFAULT_HELIOSTERRAFORMED = "HELIOSTERRAFORMED";
        public const string DEFAULT_HELIOSTERRAFORMEDWM = "HELIOSTERRAFORMEDWM";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> HELIOSTERRAFORMED_ORES =
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

        // Planets

        public static readonly PlanetProfile HELIOSTERRAFORMED = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = HELIOSTERRAFORMED_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 180, 0.5f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0005f, -0.4f, 0, 0),
            SizeRange = new Vector2(60, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            Ores = HELIOSTERRAFORMED_ORES,
            MeteorImpact = VanilaMapProfile.EARTHLIKE_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

    }

}
