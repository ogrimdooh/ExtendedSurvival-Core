using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class CaptainArthurMapProfile
    {

        public const ulong CRAIT_MODID = 2394305855;

        public const string DEFAULT_CRAIT = "PLANET-CRAIT";

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

    }

}
