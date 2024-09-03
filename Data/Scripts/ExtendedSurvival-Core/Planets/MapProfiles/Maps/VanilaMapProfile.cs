using System.Collections.Concurrent;
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

        static VanilaMapProfile()
        {
            LoadEarthLikeOreMapInfo();
            LoadMarsOreMapInfo();
            LoadAlienOreMapInfo();
            LoadTritonOreMapInfo();
            LoadPertamOreMapInfo();
            LoadMoonOreMapInfo();
            LoadEuropaOreMapInfo();
            LoadTitanOreMapInfo();
            switch (ExtendedSurvivalCoreSession.GetOreMapType())
            {
                case PlanetMapProfile.OreMapType.Vanilla:
                    LoadVanilla();
                    break;
                case PlanetMapProfile.OreMapType.ExtendedSurvival:
                    LoadExtendedSurvival();
                    break;
                case PlanetMapProfile.OreMapType.BetterStoneVanilla:
                    LoadBetterStoneVanilla();
                    break;
                case PlanetMapProfile.OreMapType.BetterStoneExtendedSurvival:
                    LoadBetterStoneExtendedSurvival();
                    break;
            }
        }

        private static void LoadMarsOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[220] = 6;
            faceFront[240] = 6;
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
            faceFront[176] = 2046;
            faceFront[112] = 2047;
            faceFront[8] = 2048;
            faceFront[108] = 2048;
            faceFront[168] = 2048;
            faceFront[84] = 2048;
            faceFront[12] = 2304;
            faceFront[160] = 2304;
            faceFront[72] = 2304;
            faceFront[172] = 3071;
            faceFront[184] = 3072;
            faceFront[116] = 3072;
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
            faceFront[50] = 25847;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[240] = 8;
            faceBack[200] = 9;
            faceBack[220] = 9;
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
            faceBack[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[98] = 512;
            faceLeft[80] = 512;
            faceLeft[100] = 768;
            faceLeft[92] = 1024;
            faceLeft[96] = 1024;
            faceLeft[104] = 1024;
            faceLeft[152] = 1024;
            faceLeft[76] = 1280;
            faceLeft[180] = 1536;
            faceLeft[188] = 1536;
            faceLeft[88] = 1792;
            faceLeft[8] = 2048;
            faceLeft[108] = 2048;
            faceLeft[112] = 2048;
            faceLeft[168] = 2048;
            faceLeft[84] = 2048;
            faceLeft[176] = 2048;
            faceLeft[12] = 2304;
            faceLeft[160] = 2304;
            faceLeft[72] = 2304;
            faceLeft[184] = 3072;
            faceLeft[116] = 3072;
            faceLeft[172] = 3072;
            faceLeft[4] = 3328;
            faceLeft[148] = 3328;
            faceLeft[16] = 3584;
            faceLeft[68] = 3584;
            faceLeft[20] = 3840;
            faceLeft[64] = 4096;
            faceLeft[164] = 4352;
            faceLeft[48] = 4608;
            faceLeft[52] = 4608;
            faceLeft[144] = 4608;
            faceLeft[128] = 4864;
            faceLeft[156] = 4864;
            faceLeft[32] = 5120;
            faceLeft[60] = 5632;
            faceLeft[1] = 6144;
            faceLeft[28] = 6400;
            faceLeft[24] = 6656;
            faceLeft[56] = 6656;
            faceLeft[124] = 8448;
            faceLeft[120] = 9728;
            faceLeft[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
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
            faceRight[8] = 2048;
            faceRight[108] = 2048;
            faceRight[112] = 2048;
            faceRight[168] = 2048;
            faceRight[84] = 2048;
            faceRight[176] = 2048;
            faceRight[12] = 2304;
            faceRight[160] = 2304;
            faceRight[72] = 2304;
            faceRight[184] = 3072;
            faceRight[116] = 3072;
            faceRight[172] = 3072;
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
            faceRight[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[98] = 512;
            faceTop[80] = 512;
            faceTop[100] = 768;
            faceTop[92] = 1024;
            faceTop[96] = 1024;
            faceTop[104] = 1024;
            faceTop[152] = 1024;
            faceTop[76] = 1280;
            faceTop[180] = 1536;
            faceTop[188] = 1536;
            faceTop[88] = 1792;
            faceTop[8] = 2048;
            faceTop[108] = 2048;
            faceTop[112] = 2048;
            faceTop[168] = 2048;
            faceTop[84] = 2048;
            faceTop[176] = 2048;
            faceTop[12] = 2304;
            faceTop[160] = 2304;
            faceTop[72] = 2304;
            faceTop[184] = 3072;
            faceTop[116] = 3072;
            faceTop[172] = 3072;
            faceTop[4] = 3328;
            faceTop[148] = 3328;
            faceTop[16] = 3584;
            faceTop[68] = 3584;
            faceTop[20] = 3840;
            faceTop[64] = 4096;
            faceTop[164] = 4352;
            faceTop[48] = 4608;
            faceTop[52] = 4608;
            faceTop[144] = 4608;
            faceTop[128] = 4864;
            faceTop[156] = 4864;
            faceTop[32] = 5120;
            faceTop[60] = 5632;
            faceTop[1] = 6144;
            faceTop[28] = 6400;
            faceTop[24] = 6656;
            faceTop[56] = 6656;
            faceTop[124] = 8448;
            faceTop[120] = 9728;
            faceTop[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
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
            faceBottom[8] = 2048;
            faceBottom[108] = 2048;
            faceBottom[112] = 2048;
            faceBottom[168] = 2048;
            faceBottom[84] = 2048;
            faceBottom[176] = 2048;
            faceBottom[12] = 2304;
            faceBottom[160] = 2304;
            faceBottom[72] = 2304;
            faceBottom[184] = 3072;
            faceBottom[116] = 3072;
            faceBottom[172] = 3072;
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
            faceBottom[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_MARS] = mapInfo;
        }

        private static void LoadAlienOreMapInfo()
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
            faceBack[200] = 14;
            faceBack[240] = 15;
            faceBack[220] = 24;
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
            faceBack[52] = 4608;
            faceBack[144] = 4608;
            faceBack[48] = 4613;
            faceBack[128] = 4864;
            faceBack[156] = 4864;
            faceBack[32] = 5120;
            faceBack[60] = 5632;
            faceBack[1] = 6148;
            faceBack[28] = 6400;
            faceBack[56] = 6656;
            faceBack[24] = 6661;
            faceBack[124] = 8448;
            faceBack[120] = 9728;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[200] = 12;
            faceLeft[220] = 12;
            faceLeft[240] = 12;
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_ALIEN] = mapInfo;
        }

        private static void LoadTritonOreMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TRITON] = mapInfo;
        }

        private static void LoadPertamOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[203] = 6;
            faceFront[236] = 6;
            faceFront[168] = 38;
            faceFront[180] = 62;
            faceFront[176] = 63;
            faceFront[60] = 66;
            faceFront[116] = 67;
            faceFront[120] = 72;
            faceFront[104] = 97;
            faceFront[140] = 141;
            faceFront[72] = 263;
            faceFront[12] = 265;
            faceFront[40] = 269;
            faceFront[92] = 393;
            faceFront[84] = 396;
            faceFront[64] = 403;
            faceFront[20] = 542;
            faceFront[68] = 734;
            faceFront[1] = 740;
            faceFront[44] = 791;
            faceFront[8] = 995;
            faceFront[48] = 1000;
            faceFront[80] = 1057;
            faceFront[36] = 1218;
            faceFront[200] = 1652;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[220] = 6;
            faceBack[180] = 48;
            faceBack[60] = 52;
            faceBack[176] = 53;
            faceBack[116] = 57;
            faceBack[168] = 71;
            faceBack[140] = 108;
            faceBack[120] = 110;
            faceBack[104] = 142;
            faceBack[12] = 208;
            faceBack[40] = 214;
            faceBack[72] = 222;
            faceBack[92] = 317;
            faceBack[64] = 319;
            faceBack[84] = 330;
            faceBack[20] = 467;
            faceBack[68] = 581;
            faceBack[1] = 611;
            faceBack[44] = 629;
            faceBack[8] = 798;
            faceBack[48] = 813;
            faceBack[80] = 888;
            faceBack[36] = 989;
            faceBack[200] = 1326;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[220] = 5;
            faceLeft[253] = 5;
            faceLeft[236] = 7;
            faceLeft[116] = 54;
            faceLeft[60] = 58;
            faceLeft[180] = 58;
            faceLeft[176] = 64;
            faceLeft[140] = 125;
            faceLeft[120] = 136;
            faceLeft[168] = 147;
            faceLeft[104] = 185;
            faceLeft[72] = 232;
            faceLeft[12] = 238;
            faceLeft[40] = 240;
            faceLeft[84] = 362;
            faceLeft[64] = 363;
            faceLeft[92] = 368;
            faceLeft[20] = 485;
            faceLeft[68] = 671;
            faceLeft[1] = 686;
            faceLeft[44] = 735;
            faceLeft[48] = 895;
            faceLeft[8] = 911;
            faceLeft[80] = 975;
            faceLeft[36] = 1109;
            faceLeft[200] = 2308;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[116] = 57;
            faceRight[60] = 59;
            faceRight[176] = 59;
            faceRight[180] = 65;
            faceRight[168] = 105;
            faceRight[140] = 119;
            faceRight[120] = 153;
            faceRight[104] = 156;
            faceRight[12] = 233;
            faceRight[72] = 236;
            faceRight[40] = 240;
            faceRight[64] = 336;
            faceRight[84] = 341;
            faceRight[92] = 347;
            faceRight[20] = 466;
            faceRight[1] = 636;
            faceRight[68] = 646;
            faceRight[44] = 696;
            faceRight[48] = 877;
            faceRight[8] = 879;
            faceRight[80] = 929;
            faceRight[36] = 1106;
            faceRight[200] = 1675;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[228] = 9;
            faceTop[253] = 11;
            faceTop[120] = 45;
            faceTop[180] = 45;
            faceTop[176] = 46;
            faceTop[60] = 48;
            faceTop[116] = 57;
            faceTop[168] = 70;
            faceTop[140] = 104;
            faceTop[104] = 121;
            faceTop[40] = 219;
            faceTop[72] = 226;
            faceTop[12] = 227;
            faceTop[92] = 312;
            faceTop[64] = 321;
            faceTop[84] = 325;
            faceTop[20] = 456;
            faceTop[68] = 561;
            faceTop[1] = 590;
            faceTop[44] = 614;
            faceTop[48] = 791;
            faceTop[8] = 811;
            faceTop[80] = 868;
            faceTop[36] = 1013;
            faceTop[200] = 2289;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[253] = 7;
            faceBottom[120] = 30;
            faceBottom[176] = 58;
            faceBottom[116] = 59;
            faceBottom[180] = 60;
            faceBottom[60] = 60;
            faceBottom[104] = 65;
            faceBottom[140] = 120;
            faceBottom[12] = 249;
            faceBottom[72] = 251;
            faceBottom[40] = 256;
            faceBottom[92] = 366;
            faceBottom[64] = 371;
            faceBottom[84] = 385;
            faceBottom[20] = 510;
            faceBottom[68] = 671;
            faceBottom[1] = 692;
            faceBottom[44] = 747;
            faceBottom[48] = 947;
            faceBottom[8] = 948;
            faceBottom[80] = 1018;
            faceBottom[36] = 1171;
            faceBottom[200] = 1850;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_PERTAM] = mapInfo;
        }

        private static void LoadMoonOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[148] = 128;
            faceFront[222] = 256;
            faceFront[152] = 256;
            faceFront[100] = 384;
            faceFront[76] = 512;
            faceFront[92] = 512;
            faceFront[96] = 512;
            faceFront[108] = 512;
            faceFront[112] = 512;
            faceFront[168] = 512;
            faceFront[176] = 512;
            faceFront[180] = 512;
            faceFront[188] = 512;
            faceFront[208] = 640;
            faceFront[212] = 640;
            faceFront[44] = 640;
            faceFront[88] = 640;
            faceFront[104] = 640;
            faceFront[144] = 640;
            faceFront[12] = 768;
            faceFront[48] = 768;
            faceFront[52] = 768;
            faceFront[68] = 768;
            faceFront[116] = 768;
            faceFront[128] = 768;
            faceFront[172] = 768;
            faceFront[196] = 768;
            faceFront[160] = 896;
            faceFront[64] = 1024;
            faceFront[72] = 1024;
            faceFront[84] = 1024;
            faceFront[217] = 1088;
            faceFront[192] = 1088;
            faceFront[56] = 1280;
            faceFront[164] = 1472;
            faceFront[8] = 1536;
            faceFront[20] = 1536;
            faceFront[60] = 1536;
            faceFront[184] = 1536;
            faceFront[16] = 1664;
            faceFront[124] = 1664;
            faceFront[156] = 1920;
            faceFront[28] = 2048;
            faceFront[120] = 2176;
            faceFront[40] = 2496;
            faceFront[4] = 2560;
            faceFront[24] = 2560;
            faceFront[32] = 2816;
            faceFront[36] = 4288;
            faceFront[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[148] = 128;
            faceBack[222] = 256;
            faceBack[152] = 256;
            faceBack[100] = 384;
            faceBack[76] = 512;
            faceBack[92] = 512;
            faceBack[96] = 512;
            faceBack[108] = 512;
            faceBack[112] = 512;
            faceBack[168] = 512;
            faceBack[176] = 512;
            faceBack[180] = 512;
            faceBack[188] = 512;
            faceBack[208] = 640;
            faceBack[212] = 640;
            faceBack[44] = 640;
            faceBack[88] = 640;
            faceBack[104] = 640;
            faceBack[144] = 640;
            faceBack[12] = 768;
            faceBack[48] = 768;
            faceBack[52] = 768;
            faceBack[68] = 768;
            faceBack[116] = 768;
            faceBack[128] = 768;
            faceBack[172] = 768;
            faceBack[196] = 768;
            faceBack[160] = 896;
            faceBack[64] = 1024;
            faceBack[72] = 1024;
            faceBack[84] = 1024;
            faceBack[217] = 1088;
            faceBack[192] = 1088;
            faceBack[56] = 1280;
            faceBack[164] = 1472;
            faceBack[8] = 1536;
            faceBack[20] = 1536;
            faceBack[60] = 1536;
            faceBack[184] = 1536;
            faceBack[16] = 1664;
            faceBack[124] = 1664;
            faceBack[156] = 1920;
            faceBack[28] = 2048;
            faceBack[120] = 2176;
            faceBack[40] = 2496;
            faceBack[4] = 2560;
            faceBack[24] = 2560;
            faceBack[32] = 2816;
            faceBack[36] = 4288;
            faceBack[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[148] = 128;
            faceLeft[222] = 256;
            faceLeft[152] = 256;
            faceLeft[100] = 384;
            faceLeft[76] = 512;
            faceLeft[92] = 512;
            faceLeft[96] = 512;
            faceLeft[108] = 512;
            faceLeft[112] = 512;
            faceLeft[168] = 512;
            faceLeft[176] = 512;
            faceLeft[180] = 512;
            faceLeft[188] = 512;
            faceLeft[208] = 640;
            faceLeft[212] = 640;
            faceLeft[44] = 640;
            faceLeft[88] = 640;
            faceLeft[104] = 640;
            faceLeft[144] = 640;
            faceLeft[12] = 768;
            faceLeft[48] = 768;
            faceLeft[52] = 768;
            faceLeft[68] = 768;
            faceLeft[116] = 768;
            faceLeft[128] = 768;
            faceLeft[172] = 768;
            faceLeft[196] = 768;
            faceLeft[160] = 896;
            faceLeft[64] = 1024;
            faceLeft[72] = 1024;
            faceLeft[84] = 1024;
            faceLeft[217] = 1088;
            faceLeft[192] = 1088;
            faceLeft[56] = 1280;
            faceLeft[164] = 1472;
            faceLeft[8] = 1536;
            faceLeft[20] = 1536;
            faceLeft[60] = 1536;
            faceLeft[184] = 1536;
            faceLeft[16] = 1664;
            faceLeft[124] = 1664;
            faceLeft[156] = 1920;
            faceLeft[28] = 2048;
            faceLeft[120] = 2176;
            faceLeft[40] = 2496;
            faceLeft[4] = 2560;
            faceLeft[24] = 2560;
            faceLeft[32] = 2816;
            faceLeft[36] = 4288;
            faceLeft[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[148] = 128;
            faceRight[222] = 256;
            faceRight[152] = 256;
            faceRight[100] = 384;
            faceRight[76] = 512;
            faceRight[92] = 512;
            faceRight[96] = 512;
            faceRight[108] = 512;
            faceRight[112] = 512;
            faceRight[168] = 512;
            faceRight[176] = 512;
            faceRight[180] = 512;
            faceRight[188] = 512;
            faceRight[208] = 640;
            faceRight[212] = 640;
            faceRight[44] = 640;
            faceRight[88] = 640;
            faceRight[104] = 640;
            faceRight[144] = 640;
            faceRight[12] = 768;
            faceRight[48] = 768;
            faceRight[52] = 768;
            faceRight[68] = 768;
            faceRight[116] = 768;
            faceRight[128] = 768;
            faceRight[172] = 768;
            faceRight[196] = 768;
            faceRight[160] = 896;
            faceRight[64] = 1024;
            faceRight[72] = 1024;
            faceRight[84] = 1024;
            faceRight[217] = 1088;
            faceRight[192] = 1088;
            faceRight[56] = 1280;
            faceRight[164] = 1472;
            faceRight[8] = 1536;
            faceRight[20] = 1536;
            faceRight[60] = 1536;
            faceRight[184] = 1536;
            faceRight[16] = 1664;
            faceRight[124] = 1664;
            faceRight[156] = 1920;
            faceRight[28] = 2048;
            faceRight[120] = 2176;
            faceRight[40] = 2496;
            faceRight[4] = 2560;
            faceRight[24] = 2560;
            faceRight[32] = 2816;
            faceRight[36] = 4288;
            faceRight[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 75;
            faceTop[240] = 78;
            faceTop[220] = 79;
            faceTop[148] = 128;
            faceTop[222] = 256;
            faceTop[152] = 256;
            faceTop[100] = 384;
            faceTop[76] = 512;
            faceTop[92] = 512;
            faceTop[96] = 512;
            faceTop[108] = 512;
            faceTop[112] = 512;
            faceTop[168] = 512;
            faceTop[176] = 512;
            faceTop[180] = 512;
            faceTop[188] = 512;
            faceTop[208] = 640;
            faceTop[212] = 640;
            faceTop[44] = 640;
            faceTop[88] = 640;
            faceTop[104] = 640;
            faceTop[144] = 640;
            faceTop[12] = 768;
            faceTop[48] = 768;
            faceTop[52] = 768;
            faceTop[68] = 768;
            faceTop[116] = 768;
            faceTop[128] = 768;
            faceTop[172] = 768;
            faceTop[196] = 768;
            faceTop[160] = 896;
            faceTop[64] = 1024;
            faceTop[72] = 1024;
            faceTop[84] = 1024;
            faceTop[217] = 1088;
            faceTop[192] = 1088;
            faceTop[56] = 1280;
            faceTop[164] = 1472;
            faceTop[8] = 1536;
            faceTop[20] = 1536;
            faceTop[60] = 1536;
            faceTop[184] = 1536;
            faceTop[16] = 1664;
            faceTop[124] = 1664;
            faceTop[156] = 1920;
            faceTop[28] = 2048;
            faceTop[120] = 2176;
            faceTop[40] = 2496;
            faceTop[4] = 2560;
            faceTop[24] = 2560;
            faceTop[32] = 2816;
            faceTop[36] = 4288;
            faceTop[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[148] = 128;
            faceBottom[222] = 256;
            faceBottom[152] = 256;
            faceBottom[100] = 384;
            faceBottom[76] = 512;
            faceBottom[92] = 512;
            faceBottom[96] = 512;
            faceBottom[108] = 512;
            faceBottom[112] = 512;
            faceBottom[168] = 512;
            faceBottom[176] = 512;
            faceBottom[180] = 512;
            faceBottom[188] = 512;
            faceBottom[208] = 640;
            faceBottom[212] = 640;
            faceBottom[44] = 640;
            faceBottom[88] = 640;
            faceBottom[104] = 640;
            faceBottom[144] = 640;
            faceBottom[12] = 768;
            faceBottom[48] = 768;
            faceBottom[52] = 768;
            faceBottom[68] = 768;
            faceBottom[116] = 768;
            faceBottom[128] = 768;
            faceBottom[172] = 768;
            faceBottom[196] = 768;
            faceBottom[160] = 896;
            faceBottom[64] = 1024;
            faceBottom[72] = 1024;
            faceBottom[84] = 1024;
            faceBottom[217] = 1088;
            faceBottom[192] = 1088;
            faceBottom[56] = 1280;
            faceBottom[164] = 1472;
            faceBottom[8] = 1536;
            faceBottom[20] = 1536;
            faceBottom[60] = 1536;
            faceBottom[184] = 1536;
            faceBottom[16] = 1664;
            faceBottom[124] = 1664;
            faceBottom[156] = 1920;
            faceBottom[28] = 2048;
            faceBottom[120] = 2176;
            faceBottom[40] = 2496;
            faceBottom[4] = 2560;
            faceBottom[24] = 2560;
            faceBottom[32] = 2816;
            faceBottom[36] = 4288;
            faceBottom[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_MOON] = mapInfo;
        }

        private static void LoadEuropaOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[148] = 128;
            faceFront[222] = 256;
            faceFront[152] = 256;
            faceFront[100] = 384;
            faceFront[76] = 512;
            faceFront[92] = 512;
            faceFront[96] = 512;
            faceFront[108] = 512;
            faceFront[112] = 512;
            faceFront[168] = 512;
            faceFront[176] = 512;
            faceFront[180] = 512;
            faceFront[188] = 512;
            faceFront[208] = 640;
            faceFront[212] = 640;
            faceFront[44] = 640;
            faceFront[88] = 640;
            faceFront[104] = 640;
            faceFront[144] = 640;
            faceFront[12] = 768;
            faceFront[48] = 768;
            faceFront[52] = 768;
            faceFront[68] = 768;
            faceFront[116] = 768;
            faceFront[128] = 768;
            faceFront[172] = 768;
            faceFront[196] = 768;
            faceFront[160] = 896;
            faceFront[64] = 1024;
            faceFront[72] = 1024;
            faceFront[84] = 1024;
            faceFront[217] = 1088;
            faceFront[192] = 1088;
            faceFront[56] = 1280;
            faceFront[164] = 1472;
            faceFront[8] = 1536;
            faceFront[20] = 1536;
            faceFront[60] = 1536;
            faceFront[184] = 1536;
            faceFront[16] = 1664;
            faceFront[124] = 1664;
            faceFront[156] = 1920;
            faceFront[28] = 2048;
            faceFront[120] = 2176;
            faceFront[40] = 2496;
            faceFront[4] = 2560;
            faceFront[24] = 2560;
            faceFront[32] = 2816;
            faceFront[36] = 4288;
            faceFront[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[148] = 128;
            faceBack[222] = 256;
            faceBack[152] = 256;
            faceBack[100] = 384;
            faceBack[76] = 512;
            faceBack[92] = 512;
            faceBack[96] = 512;
            faceBack[108] = 512;
            faceBack[112] = 512;
            faceBack[168] = 512;
            faceBack[176] = 512;
            faceBack[180] = 512;
            faceBack[188] = 512;
            faceBack[208] = 640;
            faceBack[212] = 640;
            faceBack[44] = 640;
            faceBack[88] = 640;
            faceBack[104] = 640;
            faceBack[144] = 640;
            faceBack[12] = 768;
            faceBack[48] = 768;
            faceBack[52] = 768;
            faceBack[68] = 768;
            faceBack[116] = 768;
            faceBack[128] = 768;
            faceBack[172] = 768;
            faceBack[196] = 768;
            faceBack[160] = 896;
            faceBack[64] = 1024;
            faceBack[72] = 1024;
            faceBack[84] = 1024;
            faceBack[217] = 1088;
            faceBack[192] = 1088;
            faceBack[56] = 1280;
            faceBack[164] = 1472;
            faceBack[8] = 1536;
            faceBack[20] = 1536;
            faceBack[60] = 1536;
            faceBack[184] = 1536;
            faceBack[16] = 1664;
            faceBack[124] = 1664;
            faceBack[156] = 1920;
            faceBack[28] = 2048;
            faceBack[120] = 2176;
            faceBack[40] = 2496;
            faceBack[4] = 2560;
            faceBack[24] = 2560;
            faceBack[32] = 2816;
            faceBack[36] = 4288;
            faceBack[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[148] = 128;
            faceLeft[222] = 256;
            faceLeft[152] = 256;
            faceLeft[100] = 384;
            faceLeft[76] = 512;
            faceLeft[92] = 512;
            faceLeft[96] = 512;
            faceLeft[108] = 512;
            faceLeft[112] = 512;
            faceLeft[168] = 512;
            faceLeft[176] = 512;
            faceLeft[180] = 512;
            faceLeft[188] = 512;
            faceLeft[208] = 640;
            faceLeft[212] = 640;
            faceLeft[44] = 640;
            faceLeft[88] = 640;
            faceLeft[104] = 640;
            faceLeft[144] = 640;
            faceLeft[12] = 768;
            faceLeft[48] = 768;
            faceLeft[52] = 768;
            faceLeft[68] = 768;
            faceLeft[116] = 768;
            faceLeft[128] = 768;
            faceLeft[172] = 768;
            faceLeft[196] = 768;
            faceLeft[160] = 896;
            faceLeft[64] = 1024;
            faceLeft[72] = 1024;
            faceLeft[84] = 1024;
            faceLeft[217] = 1088;
            faceLeft[192] = 1088;
            faceLeft[56] = 1280;
            faceLeft[164] = 1472;
            faceLeft[8] = 1536;
            faceLeft[20] = 1536;
            faceLeft[60] = 1536;
            faceLeft[184] = 1536;
            faceLeft[16] = 1664;
            faceLeft[124] = 1664;
            faceLeft[156] = 1920;
            faceLeft[28] = 2048;
            faceLeft[120] = 2176;
            faceLeft[40] = 2496;
            faceLeft[4] = 2560;
            faceLeft[24] = 2560;
            faceLeft[32] = 2816;
            faceLeft[36] = 4288;
            faceLeft[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[148] = 128;
            faceRight[222] = 256;
            faceRight[152] = 256;
            faceRight[100] = 384;
            faceRight[76] = 512;
            faceRight[92] = 512;
            faceRight[96] = 512;
            faceRight[108] = 512;
            faceRight[112] = 512;
            faceRight[168] = 512;
            faceRight[176] = 512;
            faceRight[180] = 512;
            faceRight[188] = 512;
            faceRight[208] = 640;
            faceRight[212] = 640;
            faceRight[44] = 640;
            faceRight[88] = 640;
            faceRight[104] = 640;
            faceRight[144] = 640;
            faceRight[12] = 768;
            faceRight[48] = 768;
            faceRight[52] = 768;
            faceRight[68] = 768;
            faceRight[116] = 768;
            faceRight[128] = 768;
            faceRight[172] = 768;
            faceRight[196] = 768;
            faceRight[160] = 896;
            faceRight[64] = 1024;
            faceRight[72] = 1024;
            faceRight[84] = 1024;
            faceRight[217] = 1088;
            faceRight[192] = 1088;
            faceRight[56] = 1280;
            faceRight[164] = 1472;
            faceRight[8] = 1536;
            faceRight[20] = 1536;
            faceRight[60] = 1536;
            faceRight[184] = 1536;
            faceRight[16] = 1664;
            faceRight[124] = 1664;
            faceRight[156] = 1920;
            faceRight[28] = 2048;
            faceRight[120] = 2176;
            faceRight[40] = 2496;
            faceRight[4] = 2560;
            faceRight[24] = 2560;
            faceRight[32] = 2816;
            faceRight[36] = 4288;
            faceRight[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[148] = 128;
            faceTop[222] = 256;
            faceTop[152] = 256;
            faceTop[100] = 384;
            faceTop[76] = 512;
            faceTop[92] = 512;
            faceTop[96] = 512;
            faceTop[108] = 512;
            faceTop[112] = 512;
            faceTop[168] = 512;
            faceTop[176] = 512;
            faceTop[180] = 512;
            faceTop[188] = 512;
            faceTop[208] = 640;
            faceTop[212] = 640;
            faceTop[44] = 640;
            faceTop[88] = 640;
            faceTop[104] = 640;
            faceTop[144] = 640;
            faceTop[12] = 768;
            faceTop[48] = 768;
            faceTop[52] = 768;
            faceTop[68] = 768;
            faceTop[116] = 768;
            faceTop[128] = 768;
            faceTop[172] = 768;
            faceTop[196] = 768;
            faceTop[160] = 896;
            faceTop[64] = 1024;
            faceTop[72] = 1024;
            faceTop[84] = 1024;
            faceTop[217] = 1088;
            faceTop[192] = 1088;
            faceTop[56] = 1280;
            faceTop[164] = 1472;
            faceTop[8] = 1536;
            faceTop[20] = 1536;
            faceTop[60] = 1536;
            faceTop[184] = 1536;
            faceTop[16] = 1664;
            faceTop[124] = 1664;
            faceTop[156] = 1920;
            faceTop[28] = 2048;
            faceTop[120] = 2176;
            faceTop[40] = 2496;
            faceTop[4] = 2560;
            faceTop[24] = 2560;
            faceTop[32] = 2816;
            faceTop[36] = 4288;
            faceTop[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[148] = 128;
            faceBottom[222] = 256;
            faceBottom[152] = 256;
            faceBottom[100] = 384;
            faceBottom[76] = 512;
            faceBottom[92] = 512;
            faceBottom[96] = 512;
            faceBottom[108] = 512;
            faceBottom[112] = 512;
            faceBottom[168] = 512;
            faceBottom[176] = 512;
            faceBottom[180] = 512;
            faceBottom[188] = 512;
            faceBottom[208] = 640;
            faceBottom[212] = 640;
            faceBottom[44] = 640;
            faceBottom[88] = 640;
            faceBottom[104] = 640;
            faceBottom[144] = 640;
            faceBottom[12] = 768;
            faceBottom[48] = 768;
            faceBottom[52] = 768;
            faceBottom[68] = 768;
            faceBottom[116] = 768;
            faceBottom[128] = 768;
            faceBottom[172] = 768;
            faceBottom[196] = 768;
            faceBottom[160] = 896;
            faceBottom[64] = 1024;
            faceBottom[72] = 1024;
            faceBottom[84] = 1024;
            faceBottom[217] = 1088;
            faceBottom[192] = 1088;
            faceBottom[56] = 1280;
            faceBottom[164] = 1472;
            faceBottom[8] = 1536;
            faceBottom[20] = 1536;
            faceBottom[60] = 1536;
            faceBottom[184] = 1536;
            faceBottom[16] = 1664;
            faceBottom[124] = 1664;
            faceBottom[156] = 1920;
            faceBottom[28] = 2048;
            faceBottom[120] = 2176;
            faceBottom[40] = 2496;
            faceBottom[4] = 2560;
            faceBottom[24] = 2560;
            faceBottom[32] = 2816;
            faceBottom[36] = 4288;
            faceBottom[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_EUROPA] = mapInfo;
        }

        private static void LoadTitanOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[148] = 128;
            faceFront[222] = 256;
            faceFront[152] = 256;
            faceFront[100] = 384;
            faceFront[76] = 512;
            faceFront[92] = 512;
            faceFront[96] = 512;
            faceFront[108] = 512;
            faceFront[112] = 512;
            faceFront[168] = 512;
            faceFront[176] = 512;
            faceFront[180] = 512;
            faceFront[188] = 512;
            faceFront[208] = 640;
            faceFront[212] = 640;
            faceFront[44] = 640;
            faceFront[88] = 640;
            faceFront[104] = 640;
            faceFront[144] = 640;
            faceFront[12] = 768;
            faceFront[48] = 768;
            faceFront[52] = 768;
            faceFront[68] = 768;
            faceFront[116] = 768;
            faceFront[128] = 768;
            faceFront[172] = 768;
            faceFront[196] = 768;
            faceFront[160] = 896;
            faceFront[64] = 1024;
            faceFront[72] = 1024;
            faceFront[84] = 1024;
            faceFront[217] = 1088;
            faceFront[192] = 1088;
            faceFront[56] = 1280;
            faceFront[164] = 1472;
            faceFront[8] = 1536;
            faceFront[20] = 1536;
            faceFront[60] = 1536;
            faceFront[184] = 1536;
            faceFront[16] = 1664;
            faceFront[124] = 1664;
            faceFront[156] = 1920;
            faceFront[28] = 2048;
            faceFront[120] = 2176;
            faceFront[40] = 2496;
            faceFront[4] = 2560;
            faceFront[24] = 2560;
            faceFront[32] = 2816;
            faceFront[36] = 4288;
            faceFront[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[148] = 128;
            faceBack[222] = 256;
            faceBack[152] = 256;
            faceBack[100] = 384;
            faceBack[76] = 512;
            faceBack[92] = 512;
            faceBack[96] = 512;
            faceBack[108] = 512;
            faceBack[112] = 512;
            faceBack[168] = 512;
            faceBack[176] = 512;
            faceBack[180] = 512;
            faceBack[188] = 512;
            faceBack[208] = 640;
            faceBack[212] = 640;
            faceBack[44] = 640;
            faceBack[88] = 640;
            faceBack[104] = 640;
            faceBack[144] = 640;
            faceBack[12] = 768;
            faceBack[48] = 768;
            faceBack[52] = 768;
            faceBack[68] = 768;
            faceBack[116] = 768;
            faceBack[128] = 768;
            faceBack[172] = 768;
            faceBack[196] = 768;
            faceBack[160] = 896;
            faceBack[64] = 1024;
            faceBack[72] = 1024;
            faceBack[84] = 1024;
            faceBack[217] = 1088;
            faceBack[192] = 1088;
            faceBack[56] = 1280;
            faceBack[164] = 1472;
            faceBack[8] = 1536;
            faceBack[20] = 1536;
            faceBack[60] = 1536;
            faceBack[184] = 1536;
            faceBack[16] = 1664;
            faceBack[124] = 1664;
            faceBack[156] = 1920;
            faceBack[28] = 2048;
            faceBack[120] = 2176;
            faceBack[40] = 2496;
            faceBack[4] = 2560;
            faceBack[24] = 2560;
            faceBack[32] = 2816;
            faceBack[36] = 4288;
            faceBack[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[148] = 128;
            faceLeft[222] = 256;
            faceLeft[152] = 256;
            faceLeft[100] = 384;
            faceLeft[76] = 512;
            faceLeft[92] = 512;
            faceLeft[96] = 512;
            faceLeft[108] = 512;
            faceLeft[112] = 512;
            faceLeft[168] = 512;
            faceLeft[176] = 512;
            faceLeft[180] = 512;
            faceLeft[188] = 512;
            faceLeft[208] = 640;
            faceLeft[212] = 640;
            faceLeft[44] = 640;
            faceLeft[88] = 640;
            faceLeft[104] = 640;
            faceLeft[144] = 640;
            faceLeft[12] = 768;
            faceLeft[48] = 768;
            faceLeft[52] = 768;
            faceLeft[68] = 768;
            faceLeft[116] = 768;
            faceLeft[128] = 768;
            faceLeft[172] = 768;
            faceLeft[196] = 768;
            faceLeft[160] = 896;
            faceLeft[64] = 1024;
            faceLeft[72] = 1024;
            faceLeft[84] = 1024;
            faceLeft[217] = 1088;
            faceLeft[192] = 1088;
            faceLeft[56] = 1280;
            faceLeft[164] = 1472;
            faceLeft[8] = 1536;
            faceLeft[20] = 1536;
            faceLeft[60] = 1536;
            faceLeft[184] = 1536;
            faceLeft[16] = 1664;
            faceLeft[124] = 1664;
            faceLeft[156] = 1920;
            faceLeft[28] = 2048;
            faceLeft[120] = 2176;
            faceLeft[40] = 2496;
            faceLeft[4] = 2560;
            faceLeft[24] = 2560;
            faceLeft[32] = 2816;
            faceLeft[36] = 4288;
            faceLeft[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[148] = 128;
            faceRight[222] = 256;
            faceRight[152] = 256;
            faceRight[100] = 384;
            faceRight[76] = 512;
            faceRight[92] = 512;
            faceRight[96] = 512;
            faceRight[108] = 512;
            faceRight[112] = 512;
            faceRight[168] = 512;
            faceRight[176] = 512;
            faceRight[180] = 512;
            faceRight[188] = 512;
            faceRight[208] = 640;
            faceRight[212] = 640;
            faceRight[44] = 640;
            faceRight[88] = 640;
            faceRight[104] = 640;
            faceRight[144] = 640;
            faceRight[12] = 768;
            faceRight[48] = 768;
            faceRight[52] = 768;
            faceRight[68] = 768;
            faceRight[116] = 768;
            faceRight[128] = 768;
            faceRight[172] = 768;
            faceRight[196] = 768;
            faceRight[160] = 896;
            faceRight[64] = 1024;
            faceRight[72] = 1024;
            faceRight[84] = 1024;
            faceRight[217] = 1088;
            faceRight[192] = 1088;
            faceRight[56] = 1280;
            faceRight[164] = 1472;
            faceRight[8] = 1536;
            faceRight[20] = 1536;
            faceRight[60] = 1536;
            faceRight[184] = 1536;
            faceRight[16] = 1664;
            faceRight[124] = 1664;
            faceRight[156] = 1920;
            faceRight[28] = 2048;
            faceRight[120] = 2176;
            faceRight[40] = 2496;
            faceRight[4] = 2560;
            faceRight[24] = 2560;
            faceRight[32] = 2816;
            faceRight[36] = 4288;
            faceRight[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[148] = 128;
            faceTop[222] = 256;
            faceTop[152] = 256;
            faceTop[100] = 384;
            faceTop[76] = 512;
            faceTop[92] = 512;
            faceTop[96] = 512;
            faceTop[108] = 512;
            faceTop[112] = 512;
            faceTop[168] = 512;
            faceTop[176] = 512;
            faceTop[180] = 512;
            faceTop[188] = 512;
            faceTop[208] = 640;
            faceTop[212] = 640;
            faceTop[44] = 640;
            faceTop[88] = 640;
            faceTop[104] = 640;
            faceTop[144] = 640;
            faceTop[12] = 768;
            faceTop[48] = 768;
            faceTop[52] = 768;
            faceTop[68] = 768;
            faceTop[116] = 768;
            faceTop[128] = 768;
            faceTop[172] = 768;
            faceTop[196] = 768;
            faceTop[160] = 896;
            faceTop[64] = 1024;
            faceTop[72] = 1024;
            faceTop[84] = 1024;
            faceTop[217] = 1088;
            faceTop[192] = 1088;
            faceTop[56] = 1280;
            faceTop[164] = 1472;
            faceTop[8] = 1536;
            faceTop[20] = 1536;
            faceTop[60] = 1536;
            faceTop[184] = 1536;
            faceTop[16] = 1664;
            faceTop[124] = 1664;
            faceTop[156] = 1920;
            faceTop[28] = 2048;
            faceTop[120] = 2176;
            faceTop[40] = 2496;
            faceTop[4] = 2560;
            faceTop[24] = 2560;
            faceTop[32] = 2816;
            faceTop[36] = 4288;
            faceTop[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[148] = 128;
            faceBottom[222] = 256;
            faceBottom[152] = 256;
            faceBottom[100] = 384;
            faceBottom[76] = 512;
            faceBottom[92] = 512;
            faceBottom[96] = 512;
            faceBottom[108] = 512;
            faceBottom[112] = 512;
            faceBottom[168] = 512;
            faceBottom[176] = 512;
            faceBottom[180] = 512;
            faceBottom[188] = 512;
            faceBottom[208] = 640;
            faceBottom[212] = 640;
            faceBottom[44] = 640;
            faceBottom[88] = 640;
            faceBottom[104] = 640;
            faceBottom[144] = 640;
            faceBottom[12] = 768;
            faceBottom[48] = 768;
            faceBottom[52] = 768;
            faceBottom[68] = 768;
            faceBottom[116] = 768;
            faceBottom[128] = 768;
            faceBottom[172] = 768;
            faceBottom[196] = 768;
            faceBottom[160] = 896;
            faceBottom[64] = 1024;
            faceBottom[72] = 1024;
            faceBottom[84] = 1024;
            faceBottom[217] = 1088;
            faceBottom[192] = 1088;
            faceBottom[56] = 1280;
            faceBottom[164] = 1472;
            faceBottom[8] = 1536;
            faceBottom[20] = 1536;
            faceBottom[60] = 1536;
            faceBottom[184] = 1536;
            faceBottom[16] = 1664;
            faceBottom[124] = 1664;
            faceBottom[156] = 1920;
            faceBottom[28] = 2048;
            faceBottom[120] = 2176;
            faceBottom[40] = 2496;
            faceBottom[4] = 2560;
            faceBottom[24] = 2560;
            faceBottom[32] = 2816;
            faceBottom[36] = 4288;
            faceBottom[1] = 5120;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TITAN] = mapInfo;
        }

        private static void LoadEarthLikeOreMapInfo()
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
            faceTop[254] = 1;
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_EARTHLIKE] = mapInfo;
        }

        private static void LoadVanilla()
        {
            EARTHLIKE_ORES = PlanetMapProfile.BuildOreMap(
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
            EARTHLIKE.Ores = EARTHLIKE_ORES;
            ALIEN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                }
            );
            ALIEN.Ores = ALIEN_ORES;
            MARS_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                }
            );
            MARS.Ores = MARS_ORES;
            PERTAM_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                }
            );
            PERTAM.Ores = PERTAM_ORES;
            TRITON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );
            TRITON.Ores = TRITON_ORES;
            MOON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                }
            );
            MOON.Ores = MOON_ORES;
            EUROPA_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                }
            );
            EUROPA.Ores = EUROPA_ORES;
            TITAN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                }
            );
            TITAN.Ores = TITAN_ORES;
        }

        private static void LoadExtendedSurvival()
        {
            EARTHLIKE_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Lead_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01
                }
            );
            EARTHLIKE.Ores = EARTHLIKE_ORES;
            ALIEN_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01
                }
            );
            ALIEN.Ores = ALIEN_ORES;
            MARS_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Plutonium_01
                }
            );
            MARS.Ores = MARS_ORES;
            PERTAM_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Iridium_01
                },
                new string[]
                {
                    PlanetMapProfile.Tungsten_01
                }
            );
            PERTAM.Ores = PERTAM_ORES;
            TRITON_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Magnesium_01
                },
                new string[]
                {
                    PlanetMapProfile.Beryllium_01
                }
            );
            TRITON.Ores = TRITON_ORES;
            MOON_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            );
            MOON.Ores = MOON_ORES;
            EUROPA_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            );
            EUROPA.Ores = EUROPA_ORES;
            TITAN_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            );
            TITAN.Ores = TITAN_ORES;
        }

        private static void LoadBetterStoneVanilla()
        {
            EARTHLIKE_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            EARTHLIKE.Ores = EARTHLIKE_ORES;
            ALIEN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Uraninite_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            ALIEN.Ores = ALIEN_ORES;
            MARS_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            MARS.Ores = MARS_ORES;
            PERTAM_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            PERTAM.Ores = PERTAM_ORES;
            TRITON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            TRITON.Ores = TRITON_ORES;
            MOON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            MOON.Ores = MOON_ORES;
            EUROPA_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            EUROPA.Ores = EUROPA_ORES;
            TITAN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Quartz_01,
                    BetterStoneIntegrationProfile.Sinoite_01
                },
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Wadsleyite_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cattierite_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Carnotite_01,
                    BetterStoneIntegrationProfile.Autunite_01
                },
                new string[]
                {
                    BetterStoneIntegrationProfile.Electrum_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            TITAN.Ores = TITAN_ORES;
        }

        private static void LoadBetterStoneExtendedSurvival()
        {
            EARTHLIKE_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Lead_01,
                    BetterStoneIntegrationProfile.Glaucodot_01,
                    BetterStoneIntegrationProfile.Cohenite_01,
                    BetterStoneIntegrationProfile.Kamacite_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01,
                    BetterStoneIntegrationProfile.Cattierite_01
                }
            );
            EARTHLIKE.Ores = EARTHLIKE_ORES;
            ALIEN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Uraninite_01,
                    BetterStoneIntegrationProfile.Autunite_01,
                    BetterStoneIntegrationProfile.Carnotite_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01,
                    BetterStoneIntegrationProfile.Uraniaurite_01
                }
            );
            ALIEN.Ores = ALIEN_ORES;
            MARS_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Sperrylite_01,
                    BetterStoneIntegrationProfile.Niggliite_01
                },
                new string[]
                {
                    PlanetMapProfile.Plutonium_01,
                    BetterStoneIntegrationProfile.Cooperite_01
                }
            );
            MARS.Ores = MARS_ORES;
            PERTAM_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Iridium_01
                },
                new string[]
                {
                    PlanetMapProfile.Tungsten_01
                }
            );
            PERTAM.Ores = PERTAM_ORES;
            TRITON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Magnesium_01,
                    BetterStoneIntegrationProfile.Akimotoite_01,
                    BetterStoneIntegrationProfile.Olivine_01,
                    BetterStoneIntegrationProfile.Dolomite_01
                },
                new string[]
                {
                    PlanetMapProfile.Beryllium_01
                }
            );
            TRITON.Ores = TRITON_ORES;
            MOON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Pyrite_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            MOON.Ores = MOON_ORES;
            EUROPA_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Pyrite_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            EUROPA.Ores = EUROPA_ORES;
            TITAN_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Iron_03,
                    PlanetMapProfile.Iron_04,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Lithium_01,
                    BetterStoneIntegrationProfile.Chlorargyrite_01,
                    BetterStoneIntegrationProfile.Galena_01,
                    BetterStoneIntegrationProfile.Porphyry_01,
                    BetterStoneIntegrationProfile.Pyrite_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            TITAN.Ores = TITAN_ORES;
        }

        // Ore Maps
        public static List<PlanetProfile.OreMapInfo> EARTHLIKE_ORES;
        public static List<PlanetProfile.OreMapInfo> ALIEN_ORES;
        public static List<PlanetProfile.OreMapInfo> MARS_ORES;
        public static List<PlanetProfile.OreMapInfo> PERTAM_ORES;
        public static List<PlanetProfile.OreMapInfo> TRITON_ORES;
        public static List<PlanetProfile.OreMapInfo> MOON_ORES;
        public static List<PlanetProfile.OreMapInfo> EUROPA_ORES;
        public static List<PlanetProfile.OreMapInfo> TITAN_ORES;

        // Planets

        public static readonly PlanetProfile EARTHLIKE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
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
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Grass", "Woods_grass", "Rocks_grass", "Soil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Grass_old"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Sand_02", "DesertRocks"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "Ice_03")
            )
        };

        public static readonly PlanetProfile ALIEN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_ALIEN,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1f, 0.15f, 80, 2, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(true, 1.03f, 0.4f, 0.5f, 0.25f),
            SizeRange = new Vector2(50, 70),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "AlienGreenGrass", "AlienRockGrass", "AlienSoil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "AlienYellowGrass", "AlienOrangeGrass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "AlienSand"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AlienSnow", "AlienIce"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "AlienRockyMountain", "AlienRockyTerrain"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "AlienIce_03")
            )
        };

        public static readonly PlanetProfile MARS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(15, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_MARS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
            Gravity = PlanetMapProfile.GetGravity(0.9f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "MarsRocks", "MarsSoil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AlienSnow")
            )
        };

        public static readonly PlanetProfile PERTAM = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#000000",
            ColorInfluence = new Vector2I(200, 200),
            Animal = PlanetMapAnimalsProfile.DEFAULT_PERTAM,
            Geothermal = PlanetMapProfile.GetGeothermal(true, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.8f, 80, 2, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(1.2f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(65, 85),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Grass_old", "Soil", "Grass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "PertamSand", "DesertRocks", "CrackedSoil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "DustyRocks3", "DustyRocks", "DustyRocks2")
            )
        };

        public static readonly PlanetProfile TRITON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_TRITON,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 1.25f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 65),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Snow", "AlienIce"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "TritonStone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "TritonIce")
            )
        };

        // Moons

        public static readonly PlanetProfile MOON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#FFFFFF",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 50),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "MoonRocks", "MoonSoil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "AlienSnow")
            )
        };

        public static readonly PlanetProfile EUROPA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 45),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "AlienSnow", "IceEuropa2", "Ice_02", "Ice_03")
            )
        };

        public static readonly PlanetProfile TITAN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.Vanila,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0.25f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 5, 60),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 40),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "DesertRocks", "MarsRocks"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "AlienIce")
            )
        };

    }

}
