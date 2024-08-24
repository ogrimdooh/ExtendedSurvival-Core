using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class BalmungMapProfile
    {

        public const ulong BLACKHOLE_MODID = 2158960565;

        public const string DEFAULT_BLACKHOLE = "BLACKHOLE (BALCORP)";
        public const string DEFAULT_BLACKHOLE_NODISK = "BLACKHOLE (BALCORP) NODISK";
        
        // Planets
        public static readonly PlanetProfile BLACKHOLE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = BLACKHOLE_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.001f, 0, 0, 10000, 5f, 10f),
            Gravity = PlanetMapProfile.GetGravity(10000, 5.6f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 1250, 5600),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(1500, 2000),
            Type = PlanetProfile.PlanetType.Star,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
