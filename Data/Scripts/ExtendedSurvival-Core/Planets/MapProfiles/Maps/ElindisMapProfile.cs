using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ElindisMapProfile
    {

        public const ulong PYKE_MODID = 3028738424;

        public const string DEFAULT_PYKE = "PYKE";

        // Ore Maps
        public static readonly List<PlanetProfile.OreMapInfo> PYKE_ORES =
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
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Lead_01
                },
                new string[]
                {
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
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        // Planets

        public static readonly PlanetProfile PYKE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = PYKE_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, 0.25f, 0.5f, 3f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1.5f, 0, 60, 2.0f, 0.75f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(1.42f, 3.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 70, 165),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            Ores = PYKE_ORES,
            MeteorImpact = VanilaMapProfile.MARS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
