using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class RheaLiciousMapProfile
    {

        public const ulong MILA_MODID = 2845740110;

        public const string DEFAULT_MILA = "MILA";

        // Planets
        public static readonly PlanetProfile MILA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = MILA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 27f, 0f, 580, 2, 0.5f, 0.75f),
            Gravity = PlanetMapProfile.GetGravity(2.94f, 4.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(950, 1050),
            Type = PlanetProfile.PlanetType.GiantGas,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = new PlanetProfile.MeteorImpactInfo() { enabled = false },
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
