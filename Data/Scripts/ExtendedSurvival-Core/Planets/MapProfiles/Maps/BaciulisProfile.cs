using System.Collections.Concurrent;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class BaciulisProfile
    {

        public const ulong ENDOR_MODID = 2926996060;

        public const string DEFAULT_ENDOR = "ENDOR";

        public const string Woods_grass_endor = "Woods_grass_endor";

        static BaciulisProfile()
        {
            LoadEndorMapInfo();
            ENDOR.Ores = VanilaMapProfile.TRITON_ORES;
        }

        private static void LoadEndorMapInfo()
        {

            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[200] = 12;
            faceFront[220] = 12;
            faceFront[240] = 12;
            faceFront[98] = 512;
            faceFront[80] = 512;
            faceFront[100] = 768;
            faceFront[92] = 1024;
            faceFront[96] = 1024;
            faceFront[104] = 1024;
            faceFront[152] = 1024;
            faceFront[76] = 1280;
            faceFront[180] = 1536;
            faceFront[188] = 1536;
            faceFront[88] = 1792;
            faceFront[8] = 2048;
            faceFront[108] = 2048;
            faceFront[112] = 2048;
            faceFront[168] = 2048;
            faceFront[84] = 2048;
            faceFront[176] = 2048;
            faceFront[12] = 2304;
            faceFront[160] = 2304;
            faceFront[72] = 2304;
            faceFront[184] = 3072;
            faceFront[116] = 3072;
            faceFront[172] = 3072;
            faceFront[4] = 3328;
            faceFront[148] = 3328;
            faceFront[16] = 3584;
            faceFront[68] = 3584;
            faceFront[20] = 3840;
            faceFront[64] = 4096;
            faceFront[164] = 4352;
            faceFront[48] = 4608;
            faceFront[52] = 4608;
            faceFront[144] = 4608;
            faceFront[128] = 4864;
            faceFront[156] = 4864;
            faceFront[32] = 5120;
            faceFront[60] = 5632;
            faceFront[1] = 6144;
            faceFront[28] = 6400;
            faceFront[24] = 6656;
            faceFront[56] = 6656;
            faceFront[124] = 8448;
            faceFront[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[200] = 6;
            faceBack[220] = 6;
            faceBack[240] = 6;
            faceBack[98] = 512;
            faceBack[80] = 512;
            faceBack[100] = 768;
            faceBack[92] = 1024;
            faceBack[96] = 1024;
            faceBack[104] = 1024;
            faceBack[152] = 1024;
            faceBack[76] = 1280;
            faceBack[180] = 1536;
            faceBack[188] = 1536;
            faceBack[88] = 1792;
            faceBack[8] = 2048;
            faceBack[108] = 2048;
            faceBack[112] = 2048;
            faceBack[168] = 2048;
            faceBack[84] = 2048;
            faceBack[176] = 2048;
            faceBack[12] = 2304;
            faceBack[160] = 2304;
            faceBack[72] = 2304;
            faceBack[184] = 3072;
            faceBack[116] = 3072;
            faceBack[172] = 3072;
            faceBack[4] = 3328;
            faceBack[148] = 3328;
            faceBack[16] = 3584;
            faceBack[68] = 3584;
            faceBack[20] = 3840;
            faceBack[64] = 4096;
            faceBack[164] = 4352;
            faceBack[48] = 4608;
            faceBack[52] = 4608;
            faceBack[144] = 4608;
            faceBack[128] = 4864;
            faceBack[156] = 4864;
            faceBack[32] = 5120;
            faceBack[60] = 5632;
            faceBack[1] = 6144;
            faceBack[28] = 6400;
            faceBack[24] = 6656;
            faceBack[56] = 6656;
            faceBack[124] = 8448;
            faceBack[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[200] = 17;
            faceLeft[220] = 18;
            faceLeft[240] = 20;
            faceLeft[98] = 499;
            faceLeft[80] = 499;
            faceLeft[100] = 753;
            faceLeft[152] = 989;
            faceLeft[92] = 1002;
            faceLeft[96] = 1006;
            faceLeft[104] = 1007;
            faceLeft[76] = 1252;
            faceLeft[188] = 1481;
            faceLeft[180] = 1488;
            faceLeft[112] = 1961;
            faceLeft[108] = 1969;
            faceLeft[168] = 1974;
            faceLeft[176] = 1989;
            faceLeft[8] = 2000;
            faceLeft[84] = 2003;
            faceLeft[12] = 2223;
            faceLeft[160] = 2230;
            faceLeft[72] = 2243;
            faceLeft[116] = 2937;
            faceLeft[184] = 2966;
            faceLeft[172] = 2968;
            faceLeft[148] = 3225;
            faceLeft[16] = 3452;
            faceLeft[68] = 3474;
            faceLeft[88] = 3528;
            faceLeft[20] = 3693;
            faceLeft[142] = 3796;
            faceLeft[64] = 3981;
            faceLeft[164] = 4220;
            faceLeft[144] = 4469;
            faceLeft[48] = 4470;
            faceLeft[52] = 4471;
            faceLeft[156] = 4702;
            faceLeft[128] = 4718;
            faceLeft[32] = 5003;
            faceLeft[60] = 5476;
            faceLeft[1] = 5991;
            faceLeft[28] = 6226;
            faceLeft[56] = 6451;
            faceLeft[24] = 6458;
            faceLeft[124] = 8179;
            faceLeft[4] = 9345;
            faceLeft[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[200] = 6;
            faceRight[220] = 6;
            faceRight[240] = 6;
            faceRight[98] = 512;
            faceRight[80] = 512;
            faceRight[100] = 768;
            faceRight[92] = 1024;
            faceRight[96] = 1024;
            faceRight[104] = 1024;
            faceRight[152] = 1024;
            faceRight[76] = 1280;
            faceRight[180] = 1536;
            faceRight[188] = 1536;
            faceRight[88] = 1792;
            faceRight[108] = 2046;
            faceRight[112] = 2046;
            faceRight[168] = 2046;
            faceRight[176] = 2046;
            faceRight[8] = 2048;
            faceRight[84] = 2048;
            faceRight[12] = 2304;
            faceRight[160] = 2304;
            faceRight[72] = 2304;
            faceRight[116] = 3069;
            faceRight[172] = 3069;
            faceRight[184] = 3072;
            faceRight[4] = 3328;
            faceRight[148] = 3328;
            faceRight[16] = 3584;
            faceRight[68] = 3584;
            faceRight[20] = 3840;
            faceRight[64] = 4096;
            faceRight[164] = 4352;
            faceRight[48] = 4608;
            faceRight[52] = 4608;
            faceRight[144] = 4608;
            faceRight[128] = 4864;
            faceRight[156] = 4864;
            faceRight[32] = 5120;
            faceRight[60] = 5632;
            faceRight[1] = 6144;
            faceRight[28] = 6400;
            faceRight[24] = 6656;
            faceRight[56] = 6656;
            faceRight[124] = 8448;
            faceRight[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 6;
            faceTop[220] = 6;
            faceTop[240] = 6;
            faceTop[80] = 512;
            faceTop[98] = 512;
            faceTop[100] = 768;
            faceTop[92] = 1024;
            faceTop[96] = 1024;
            faceTop[104] = 1024;
            faceTop[152] = 1024;
            faceTop[76] = 1280;
            faceTop[180] = 1534;
            faceTop[188] = 1534;
            faceTop[88] = 1792;
            faceTop[108] = 2044;
            faceTop[112] = 2044;
            faceTop[168] = 2044;
            faceTop[176] = 2044;
            faceTop[8] = 2048;
            faceTop[84] = 2048;
            faceTop[12] = 2301;
            faceTop[160] = 2302;
            faceTop[72] = 2304;
            faceTop[116] = 3066;
            faceTop[172] = 3066;
            faceTop[184] = 3070;
            faceTop[4] = 3328;
            faceTop[148] = 3328;
            faceTop[16] = 3582;
            faceTop[68] = 3584;
            faceTop[20] = 3837;
            faceTop[64] = 4096;
            faceTop[164] = 4350;
            faceTop[48] = 4608;
            faceTop[52] = 4608;
            faceTop[144] = 4608;
            faceTop[156] = 4859;
            faceTop[128] = 4864;
            faceTop[32] = 5120;
            faceTop[60] = 5632;
            faceTop[1] = 6144;
            faceTop[28] = 6400;
            faceTop[24] = 6656;
            faceTop[56] = 6656;
            faceTop[124] = 8448;
            faceTop[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[200] = 12;
            faceBottom[220] = 12;
            faceBottom[240] = 12;
            faceBottom[98] = 512;
            faceBottom[80] = 512;
            faceBottom[100] = 768;
            faceBottom[92] = 1024;
            faceBottom[96] = 1024;
            faceBottom[104] = 1024;
            faceBottom[152] = 1024;
            faceBottom[76] = 1280;
            faceBottom[180] = 1536;
            faceBottom[188] = 1536;
            faceBottom[88] = 1792;
            faceBottom[108] = 2046;
            faceBottom[112] = 2046;
            faceBottom[168] = 2046;
            faceBottom[176] = 2046;
            faceBottom[8] = 2048;
            faceBottom[84] = 2048;
            faceBottom[12] = 2304;
            faceBottom[160] = 2304;
            faceBottom[72] = 2304;
            faceBottom[116] = 3069;
            faceBottom[172] = 3069;
            faceBottom[184] = 3072;
            faceBottom[4] = 3328;
            faceBottom[148] = 3328;
            faceBottom[16] = 3584;
            faceBottom[68] = 3584;
            faceBottom[20] = 3840;
            faceBottom[64] = 4096;
            faceBottom[164] = 4352;
            faceBottom[48] = 4608;
            faceBottom[52] = 4608;
            faceBottom[144] = 4608;
            faceBottom[128] = 4864;
            faceBottom[156] = 4864;
            faceBottom[32] = 5120;
            faceBottom[60] = 5632;
            faceBottom[1] = 6144;
            faceBottom[28] = 6400;
            faceBottom[24] = 6656;
            faceBottom[56] = 6656;
            faceBottom[124] = 8448;
            faceBottom[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_ENDOR] = mapInfo;

        }

        public static readonly PlanetProfile ENDOR = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ENDOR_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.2f, 0.9f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.011f, -0.4f, 0, 0),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Grass", "Woods_grass_endor", "Rocks_grass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Grass_old"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Sand_02"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "Ice_03")
            )
        };

    }

}
