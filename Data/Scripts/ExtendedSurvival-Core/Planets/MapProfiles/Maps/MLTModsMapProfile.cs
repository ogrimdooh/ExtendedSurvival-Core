﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class MLTModsMapProfile
    {

        public const ulong SEDONIA_MODID = 709338599;
        public const ulong IRENE1C_MODID = 646630784;

        public const string DEFAULT_SEDONIA = "SEDONIA";
        public const string DEFAULT_IRENE1C = "IRENE1C";

        // Irene1C

        public const string IreneSoil = "IreneSoil";

        // Sedonia

        public const string SedoniaIce = "SedoniaIce";
        public const string SedoniaRock = "SedoniaRock";
        public const string SedoniaRegolith = "SedoniaRegolith";

        public const string REGOLITH_SUBTYPEID = "Regolith";
        public static readonly UniqueEntityId REGOLITH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), REGOLITH_SUBTYPEID);

        static MLTModsMapProfile()
        {
            LoadSedoniaOreMapInfo();
            LoadIrene1COreMapInfo();
            SEDONIA.Ores = VanilaMapProfile.MOON_ORES;
            IRENE1C.Ores = VanilaMapProfile.TRITON_ORES;
        }

        private static void LoadSedoniaOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[145] = 5;
            faceFront[195] = 6;
            faceFront[200] = 6;
            faceFront[220] = 6;
            faceFront[240] = 6;
            faceFront[196] = 8;
            faceFront[80] = 373;
            faceFront[98] = 382;
            faceFront[100] = 570;
            faceFront[96] = 757;
            faceFront[152] = 760;
            faceFront[92] = 761;
            faceFront[104] = 764;
            faceFront[76] = 940;
            faceFront[180] = 1130;
            faceFront[188] = 1134;
            faceFront[88] = 1329;
            faceFront[8] = 1500;
            faceFront[108] = 1524;
            faceFront[112] = 1526;
            faceFront[168] = 1531;
            faceFront[176] = 1534;
            faceFront[84] = 1536;
            faceFront[72] = 1693;
            faceFront[12] = 1705;
            faceFront[160] = 1713;
            faceFront[184] = 2285;
            faceFront[116] = 2295;
            faceFront[172] = 2298;
            faceFront[4] = 2446;
            faceFront[148] = 2448;
            faceFront[68] = 2638;
            faceFront[16] = 2653;
            faceFront[20] = 2830;
            faceFront[64] = 3025;
            faceFront[164] = 3240;
            faceFront[52] = 3401;
            faceFront[48] = 3404;
            faceFront[144] = 3411;
            faceFront[128] = 3579;
            faceFront[156] = 3614;
            faceFront[32] = 3769;
            faceFront[60] = 4173;
            faceFront[1] = 4528;
            faceFront[28] = 4698;
            faceFront[24] = 4899;
            faceFront[56] = 4902;
            faceFront[124] = 6238;
            faceFront[120] = 7184;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[80] = 186;
            faceBack[98] = 194;
            faceBack[100] = 283;
            faceBack[92] = 376;
            faceBack[96] = 376;
            faceBack[104] = 376;
            faceBack[152] = 403;
            faceBack[76] = 466;
            faceBack[180] = 591;
            faceBack[188] = 592;
            faceBack[88] = 656;
            faceBack[8] = 747;
            faceBack[84] = 760;
            faceBack[176] = 805;
            faceBack[112] = 806;
            faceBack[168] = 808;
            faceBack[108] = 809;
            faceBack[72] = 834;
            faceBack[160] = 881;
            faceBack[12] = 888;
            faceBack[184] = 1185;
            faceBack[116] = 1200;
            faceBack[4] = 1213;
            faceBack[172] = 1213;
            faceBack[148] = 1262;
            faceBack[68] = 1334;
            faceBack[16] = 1359;
            faceBack[20] = 1457;
            faceBack[64] = 1527;
            faceBack[164] = 1655;
            faceBack[144] = 1770;
            faceBack[48] = 1780;
            faceBack[52] = 1781;
            faceBack[128] = 1843;
            faceBack[156] = 1869;
            faceBack[32] = 1873;
            faceBack[60] = 2103;
            faceBack[1] = 2250;
            faceBack[28] = 2335;
            faceBack[24] = 2441;
            faceBack[56] = 2602;
            faceBack[124] = 3231;
            faceBack[120] = 3721;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[80] = 234;
            faceLeft[98] = 249;
            faceLeft[100] = 377;
            faceLeft[152] = 470;
            faceLeft[92] = 496;
            faceLeft[96] = 503;
            faceLeft[104] = 504;
            faceLeft[76] = 602;
            faceLeft[188] = 708;
            faceLeft[180] = 709;
            faceLeft[88] = 877;
            faceLeft[108] = 944;
            faceLeft[112] = 945;
            faceLeft[168] = 947;
            faceLeft[176] = 950;
            faceLeft[8] = 981;
            faceLeft[84] = 996;
            faceLeft[12] = 1051;
            faceLeft[160] = 1074;
            faceLeft[72] = 1092;
            faceLeft[184] = 1367;
            faceLeft[116] = 1419;
            faceLeft[172] = 1421;
            faceLeft[148] = 1532;
            faceLeft[4] = 1597;
            faceLeft[16] = 1614;
            faceLeft[68] = 1666;
            faceLeft[20] = 1745;
            faceLeft[64] = 1917;
            faceLeft[164] = 2017;
            faceLeft[52] = 2122;
            faceLeft[144] = 2122;
            faceLeft[48] = 2133;
            faceLeft[128] = 2271;
            faceLeft[156] = 2271;
            faceLeft[32] = 2439;
            faceLeft[60] = 2651;
            faceLeft[1] = 2969;
            faceLeft[28] = 3011;
            faceLeft[56] = 3060;
            faceLeft[24] = 3128;
            faceLeft[124] = 3923;
            faceLeft[120] = 4518;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[200] = 6;
            faceRight[220] = 6;
            faceRight[234] = 6;
            faceRight[240] = 6;
            faceRight[145] = 8;
            faceRight[98] = 260;
            faceRight[80] = 284;
            faceRight[100] = 405;
            faceRight[96] = 537;
            faceRight[92] = 541;
            faceRight[104] = 541;
            faceRight[152] = 555;
            faceRight[76] = 720;
            faceRight[188] = 862;
            faceRight[180] = 863;
            faceRight[88] = 941;
            faceRight[84] = 1079;
            faceRight[108] = 1105;
            faceRight[168] = 1106;
            faceRight[176] = 1110;
            faceRight[112] = 1112;
            faceRight[8] = 1166;
            faceRight[160] = 1269;
            faceRight[72] = 1294;
            faceRight[12] = 1295;
            faceRight[172] = 1662;
            faceRight[116] = 1664;
            faceRight[184] = 1703;
            faceRight[148] = 1795;
            faceRight[4] = 1896;
            faceRight[16] = 2015;
            faceRight[68] = 2080;
            faceRight[20] = 2173;
            faceRight[164] = 2360;
            faceRight[64] = 2367;
            faceRight[52] = 2482;
            faceRight[48] = 2488;
            faceRight[144] = 2550;
            faceRight[156] = 2670;
            faceRight[128] = 2772;
            faceRight[32] = 2969;
            faceRight[60] = 3239;
            faceRight[1] = 3505;
            faceRight[56] = 3603;
            faceRight[28] = 3675;
            faceRight[24] = 3808;
            faceRight[124] = 4747;
            faceRight[120] = 5383;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[98] = 179;
            faceTop[80] = 189;
            faceTop[100] = 279;
            faceTop[104] = 371;
            faceTop[96] = 373;
            faceTop[152] = 377;
            faceTop[92] = 382;
            faceTop[76] = 475;
            faceTop[188] = 570;
            faceTop[180] = 574;
            faceTop[88] = 663;
            faceTop[176] = 748;
            faceTop[84] = 749;
            faceTop[8] = 755;
            faceTop[168] = 755;
            faceTop[112] = 765;
            faceTop[108] = 767;
            faceTop[12] = 853;
            faceTop[72] = 855;
            faceTop[160] = 858;
            faceTop[172] = 1130;
            faceTop[116] = 1140;
            faceTop[184] = 1158;
            faceTop[4] = 1221;
            faceTop[148] = 1228;
            faceTop[68] = 1332;
            faceTop[16] = 1371;
            faceTop[20] = 1451;
            faceTop[64] = 1524;
            faceTop[164] = 1611;
            faceTop[144] = 1701;
            faceTop[48] = 1708;
            faceTop[52] = 1708;
            faceTop[156] = 1796;
            faceTop[128] = 1810;
            faceTop[32] = 1898;
            faceTop[60] = 2092;
            faceTop[1] = 2246;
            faceTop[28] = 2399;
            faceTop[56] = 2457;
            faceTop[24] = 2485;
            faceTop[124] = 3132;
            faceTop[120] = 3587;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[98] = 113;
            faceBottom[80] = 142;
            faceBottom[100] = 191;
            faceBottom[96] = 248;
            faceBottom[92] = 249;
            faceBottom[104] = 258;
            faceBottom[152] = 258;
            faceBottom[76] = 347;
            faceBottom[188] = 411;
            faceBottom[180] = 414;
            faceBottom[88] = 432;
            faceBottom[84] = 496;
            faceBottom[176] = 539;
            faceBottom[168] = 542;
            faceBottom[112] = 544;
            faceBottom[108] = 547;
            faceBottom[8] = 553;
            faceBottom[160] = 611;
            faceBottom[12] = 615;
            faceBottom[72] = 631;
            faceBottom[184] = 809;
            faceBottom[172] = 814;
            faceBottom[116] = 818;
            faceBottom[148] = 834;
            faceBottom[4] = 909;
            faceBottom[16] = 942;
            faceBottom[68] = 956;
            faceBottom[20] = 1011;
            faceBottom[64] = 1083;
            faceBottom[164] = 1121;
            faceBottom[48] = 1158;
            faceBottom[144] = 1160;
            faceBottom[52] = 1162;
            faceBottom[156] = 1284;
            faceBottom[128] = 1316;
            faceBottom[32] = 1363;
            faceBottom[60] = 1479;
            faceBottom[56] = 1684;
            faceBottom[1] = 1699;
            faceBottom[28] = 1731;
            faceBottom[24] = 1788;
            faceBottom[124] = 2225;
            faceBottom[120] = 2497;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_SEDONIA] = mapInfo;
        }

        private static void LoadIrene1COreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[200] = 6;
            faceFront[220] = 6;
            faceFront[240] = 6;
            faceFront[204] = 7;
            faceFront[244] = 494;
            faceFront[98] = 508;
            faceFront[80] = 512;
            faceFront[100] = 762;
            faceFront[234] = 802;
            faceFront[92] = 1013;
            faceFront[104] = 1016;
            faceFront[96] = 1017;
            faceFront[152] = 1018;
            faceFront[76] = 1281;
            faceFront[188] = 1532;
            faceFront[180] = 1534;
            faceFront[145] = 1540;
            faceFront[88] = 1775;
            faceFront[84] = 2030;
            faceFront[168] = 2036;
            faceFront[112] = 2038;
            faceFront[176] = 2038;
            faceFront[8] = 2040;
            faceFront[108] = 2040;
            faceFront[12] = 2298;
            faceFront[72] = 2300;
            faceFront[160] = 2300;
            faceFront[116] = 3056;
            faceFront[172] = 3057;
            faceFront[184] = 3067;
            faceFront[195] = 3288;
            faceFront[148] = 3308;
            faceFront[4] = 3316;
            faceFront[68] = 3570;
            faceFront[16] = 3579;
            faceFront[20] = 3833;
            faceFront[64] = 4078;
            faceFront[196] = 4249;
            faceFront[164] = 4334;
            faceFront[48] = 4579;
            faceFront[52] = 4579;
            faceFront[128] = 4841;
            faceFront[156] = 4842;
            faceFront[32] = 5097;
            faceFront[60] = 5608;
            faceFront[1] = 6118;
            faceFront[28] = 6380;
            faceFront[56] = 6616;
            faceFront[24] = 6634;
            faceFront[124] = 8403;
            faceFront[120] = 9678;
            faceFront[144] = 13909;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[200] = 6;
            faceBack[220] = 6;
            faceBack[240] = 6;
            faceBack[216] = 227;
            faceBack[234] = 251;
            faceBack[213] = 276;
            faceBack[145] = 496;
            faceBack[80] = 506;
            faceBack[98] = 509;
            faceBack[210] = 551;
            faceBack[100] = 768;
            faceBack[152] = 1018;
            faceBack[104] = 1020;
            faceBack[96] = 1021;
            faceBack[92] = 1022;
            faceBack[76] = 1270;
            faceBack[50] = 1514;
            faceBack[180] = 1527;
            faceBack[188] = 1528;
            faceBack[30] = 1538;
            faceBack[88] = 1789;
            faceBack[8] = 2037;
            faceBack[84] = 2041;
            faceBack[108] = 2041;
            faceBack[112] = 2041;
            faceBack[168] = 2041;
            faceBack[176] = 2044;
            faceBack[49] = 2230;
            faceBack[31] = 2261;
            faceBack[72] = 2286;
            faceBack[12] = 2292;
            faceBack[160] = 2293;
            faceBack[14] = 2559;
            faceBack[184] = 3055;
            faceBack[116] = 3061;
            faceBack[172] = 3064;
            faceBack[148] = 3309;
            faceBack[4] = 3313;
            faceBack[16] = 3562;
            faceBack[68] = 3572;
            faceBack[20] = 3818;
            faceBack[64] = 4083;
            faceBack[164] = 4331;
            faceBack[52] = 4586;
            faceBack[48] = 4592;
            faceBack[15] = 4603;
            faceBack[156] = 4842;
            faceBack[128] = 4849;
            faceBack[32] = 5108;
            faceBack[60] = 5615;
            faceBack[1] = 6119;
            faceBack[28] = 6372;
            faceBack[56] = 6621;
            faceBack[24] = 6627;
            faceBack[144] = 7793;
            faceBack[124] = 8424;
            faceBack[120] = 9697;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[200] = 6;
            faceLeft[220] = 6;
            faceLeft[240] = 6;
            faceLeft[167] = 10;
            faceLeft[234] = 237;
            faceLeft[242] = 269;
            faceLeft[98] = 504;
            faceLeft[80] = 512;
            faceLeft[145] = 547;
            faceLeft[100] = 758;
            faceLeft[236] = 805;
            faceLeft[96] = 1011;
            faceLeft[104] = 1011;
            faceLeft[92] = 1012;
            faceLeft[152] = 1016;
            faceLeft[76] = 1277;
            faceLeft[180] = 1530;
            faceLeft[188] = 1530;
            faceLeft[88] = 1767;
            faceLeft[154] = 1812;
            faceLeft[84] = 2024;
            faceLeft[112] = 2040;
            faceLeft[176] = 2040;
            faceLeft[8] = 2041;
            faceLeft[108] = 2042;
            faceLeft[168] = 2043;
            faceLeft[160] = 2292;
            faceLeft[12] = 2295;
            faceLeft[72] = 2297;
            faceLeft[185] = 2591;
            faceLeft[116] = 3059;
            faceLeft[172] = 3059;
            faceLeft[4] = 3315;
            faceLeft[148] = 3317;
            faceLeft[68] = 3570;
            faceLeft[16] = 3574;
            faceLeft[20] = 3828;
            faceLeft[64] = 4072;
            faceLeft[184] = 4107;
            faceLeft[164] = 4321;
            faceLeft[52] = 4586;
            faceLeft[48] = 4587;
            faceLeft[156] = 4831;
            faceLeft[128] = 4840;
            faceLeft[32] = 5094;
            faceLeft[60] = 5594;
            faceLeft[1] = 6124;
            faceLeft[28] = 6359;
            faceLeft[24] = 6616;
            faceLeft[56] = 6618;
            faceLeft[144] = 7774;
            faceLeft[124] = 8395;
            faceLeft[153] = 9219;
            faceLeft[120] = 9663;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[200] = 6;
            faceRight[220] = 6;
            faceRight[240] = 6;
            faceRight[161] = 7;
            faceRight[234] = 229;
            faceRight[230] = 274;
            faceRight[145] = 508;
            faceRight[98] = 510;
            faceRight[80] = 511;
            faceRight[100] = 764;
            faceRight[242] = 815;
            faceRight[123] = 982;
            faceRight[104] = 1019;
            faceRight[92] = 1020;
            faceRight[96] = 1020;
            faceRight[152] = 1020;
            faceRight[76] = 1275;
            faceRight[188] = 1526;
            faceRight[180] = 1527;
            faceRight[88] = 1788;
            faceRight[108] = 2038;
            faceRight[112] = 2038;
            faceRight[84] = 2039;
            faceRight[168] = 2039;
            faceRight[176] = 2040;
            faceRight[8] = 2041;
            faceRight[12] = 2291;
            faceRight[72] = 2296;
            faceRight[160] = 2299;
            faceRight[122] = 2818;
            faceRight[116] = 3058;
            faceRight[172] = 3059;
            faceRight[148] = 3315;
            faceRight[4] = 3316;
            faceRight[16] = 3560;
            faceRight[68] = 3568;
            faceRight[20] = 3817;
            faceRight[64] = 4079;
            faceRight[164] = 4330;
            faceRight[48] = 4583;
            faceRight[52] = 4585;
            faceRight[128] = 4842;
            faceRight[156] = 4843;
            faceRight[32] = 5100;
            faceRight[60] = 5609;
            faceRight[1] = 6122;
            faceRight[184] = 6194;
            faceRight[28] = 6381;
            faceRight[56] = 6620;
            faceRight[24] = 6634;
            faceRight[185] = 7724;
            faceRight[144] = 7814;
            faceRight[124] = 8405;
            faceRight[120] = 9684;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[50] = 5;
            faceTop[200] = 6;
            faceTop[220] = 6;
            faceTop[240] = 6;
            faceTop[115] = 7;
            faceTop[234] = 228;
            faceTop[145] = 505;
            faceTop[80] = 510;
            faceTop[98] = 512;
            faceTop[242] = 520;
            faceTop[225] = 544;
            faceTop[100] = 766;
            faceTop[152] = 1019;
            faceTop[92] = 1020;
            faceTop[104] = 1020;
            faceTop[96] = 1021;
            faceTop[76] = 1275;
            faceTop[180] = 1524;
            faceTop[188] = 1526;
            faceTop[88] = 1786;
            faceTop[108] = 2033;
            faceTop[112] = 2033;
            faceTop[168] = 2034;
            faceTop[176] = 2034;
            faceTop[8] = 2040;
            faceTop[84] = 2040;
            faceTop[12] = 2288;
            faceTop[160] = 2293;
            faceTop[72] = 2295;
            faceTop[94] = 2695;
            faceTop[172] = 3050;
            faceTop[116] = 3054;
            faceTop[4] = 3315;
            faceTop[148] = 3316;
            faceTop[16] = 3557;
            faceTop[68] = 3564;
            faceTop[20] = 3812;
            faceTop[64] = 4069;
            faceTop[164] = 4328;
            faceTop[48] = 4591;
            faceTop[52] = 4591;
            faceTop[93] = 4631;
            faceTop[128] = 4840;
            faceTop[156] = 4840;
            faceTop[32] = 5098;
            faceTop[184] = 5189;
            faceTop[185] = 5200;
            faceTop[60] = 5598;
            faceTop[1] = 6117;
            faceTop[28] = 6370;
            faceTop[24] = 6623;
            faceTop[56] = 6630;
            faceTop[144] = 7822;
            faceTop[124] = 8408;
            faceTop[120] = 9683;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[203] = 5;
            faceBottom[200] = 6;
            faceBottom[220] = 6;
            faceBottom[240] = 6;
            faceBottom[244] = 501;
            faceBottom[98] = 508;
            faceBottom[80] = 510;
            faceBottom[100] = 763;
            faceBottom[234] = 819;
            faceBottom[96] = 1017;
            faceBottom[92] = 1018;
            faceBottom[104] = 1019;
            faceBottom[152] = 1019;
            faceBottom[76] = 1278;
            faceBottom[145] = 1511;
            faceBottom[180] = 1530;
            faceBottom[188] = 1530;
            faceBottom[88] = 1782;
            faceBottom[84] = 2036;
            faceBottom[8] = 2039;
            faceBottom[108] = 2040;
            faceBottom[112] = 2040;
            faceBottom[176] = 2040;
            faceBottom[168] = 2041;
            faceBottom[12] = 2294;
            faceBottom[72] = 2295;
            faceBottom[160] = 2296;
            faceBottom[116] = 3060;
            faceBottom[184] = 3060;
            faceBottom[172] = 3061;
            faceBottom[195] = 3252;
            faceBottom[4] = 3313;
            faceBottom[148] = 3319;
            faceBottom[68] = 3557;
            faceBottom[16] = 3569;
            faceBottom[20] = 3825;
            faceBottom[64] = 4067;
            faceBottom[196] = 4285;
            faceBottom[164] = 4334;
            faceBottom[48] = 4591;
            faceBottom[52] = 4592;
            faceBottom[128] = 4837;
            faceBottom[156] = 4841;
            faceBottom[32] = 5085;
            faceBottom[60] = 5593;
            faceBottom[1] = 6112;
            faceBottom[28] = 6365;
            faceBottom[24] = 6619;
            faceBottom[56] = 6630;
            faceBottom[124] = 8402;
            faceBottom[120] = 9674;
            faceBottom[144] = 13944;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_IRENE1C] = mapInfo;
        }

        // Planets
        public static readonly PlanetProfile SEDONIA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = SEDONIA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, 0.05f, 2.5f, 0.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.3f, 0.0f, 90, 1.0f, 0.25f, 0.075f),
            Gravity = PlanetMapProfile.GetGravity(0.56f, 2.75f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, -77, 47),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(28, 32),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "SedoniaRegolith", "SedoniaRock"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "SedoniaIce")
            )
        };

        public static readonly PlanetProfile IRENE1C = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = IRENE1C_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1.7f, 0, 90, 2.0f, 0.75f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(1.7f, 4.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -157, -17),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(50, 55),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "IreneSoil", "IreneRock"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "BlackIce")
            )
        };

    }

}
