using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class MLTModsMapProfile
    {

        public const ulong SEDONIA_MODID = 709338599;

        public const string DEFAULT_SEDONIA = "SEDONIA";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> SEDONIA_ORES =
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
                    PlanetMapProfile.Lithium_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
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
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        // Planets
        public static readonly PlanetProfile SEDONIA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = SEDONIA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, 1.5f, 1.25f, 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.3f, 0.0f, 90, 1.0f, 0.25f, 0.075f),
            Gravity = PlanetMapProfile.GetGravity(0.56f, 2.75f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, -77, 47),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(18, 22),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            Ores = SEDONIA_ORES,
            MeteorImpact = VanilaMapProfile.ALIEN_METEOR,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING
        };

    }

}
