﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class InfiniteMapProfile
    {

        public const ulong HALCYON_MODID = 3028355272;
        public const ulong PENUMBRA_MODID = 3077440417;

        public const string DEFAULT_HALCYON = "HALCYON";
        public const string DEFAULT_PENUMBRA = "PENUMBRA";

        static InfiniteMapProfile()
        {
            LoadHalcyonOreMapInfo();
            LoadPenumbraOreMapInfo();
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

        private static void LoadHalcyonOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[200] = 6;
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_HALCYON] = mapInfo;
        }

        private static void LoadPenumbraOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[19] = 5;
            faceFront[20] = 5;
            faceFront[23] = 5;
            faceFront[29] = 5;
            faceFront[46] = 5;
            faceFront[27] = 6;
            faceFront[47] = 6;
            faceFront[32] = 7;
            faceFront[40] = 7;
            faceFront[48] = 7;
            faceFront[42] = 8;
            faceFront[50] = 8;
            faceFront[68] = 8;
            faceFront[37] = 9;
            faceFront[44] = 9;
            faceFront[51] = 9;
            faceFront[58] = 10;
            faceFront[52] = 11;
            faceFront[53] = 11;
            faceFront[41] = 12;
            faceFront[49] = 12;
            faceFront[54] = 12;
            faceFront[62] = 12;
            faceFront[45] = 13;
            faceFront[60] = 13;
            faceFront[55] = 14;
            faceFront[65] = 14;
            faceFront[57] = 15;
            faceFront[66] = 15;
            faceFront[67] = 15;
            faceFront[63] = 16;
            faceFront[69] = 16;
            faceFront[56] = 17;
            faceFront[61] = 17;
            faceFront[59] = 18;
            faceFront[64] = 18;
            faceFront[78] = 20;
            faceFront[71] = 22;
            faceFront[76] = 22;
            faceFront[81] = 22;
            faceFront[89] = 22;
            faceFront[73] = 23;
            faceFront[70] = 24;
            faceFront[74] = 24;
            faceFront[77] = 24;
            faceFront[86] = 24;
            faceFront[99] = 24;
            faceFront[72] = 25;
            faceFront[92] = 27;
            faceFront[107] = 27;
            faceFront[75] = 30;
            faceFront[87] = 31;
            faceFront[108] = 31;
            faceFront[79] = 32;
            faceFront[91] = 32;
            faceFront[114] = 32;
            faceFront[80] = 33;
            faceFront[88] = 33;
            faceFront[102] = 33;
            faceFront[109] = 33;
            faceFront[113] = 33;
            faceFront[83] = 34;
            faceFront[84] = 34;
            faceFront[90] = 34;
            faceFront[93] = 34;
            faceFront[111] = 34;
            faceFront[94] = 35;
            faceFront[82] = 36;
            faceFront[85] = 36;
            faceFront[103] = 38;
            faceFront[106] = 38;
            faceFront[101] = 39;
            faceFront[95] = 40;
            faceFront[112] = 40;
            faceFront[100] = 41;
            faceFront[116] = 42;
            faceFront[98] = 43;
            faceFront[117] = 46;
            faceFront[105] = 47;
            faceFront[110] = 47;
            faceFront[97] = 50;
            faceFront[118] = 55;
            faceFront[115] = 56;
            faceFront[119] = 57;
            faceFront[96] = 59;
            faceFront[104] = 62;
            faceFront[120] = 65;
            faceFront[122] = 73;
            faceFront[123] = 76;
            faceFront[121] = 83;
            faceFront[124] = 91;
            faceFront[125] = 104;
            faceFront[126] = 114;
            faceFront[131] = 126;
            faceFront[132] = 146;
            faceFront[128] = 149;
            faceFront[129] = 160;
            faceFront[127] = 161;
            faceFront[130] = 161;
            faceFront[136] = 169;
            faceFront[140] = 189;
            faceFront[133] = 190;
            faceFront[138] = 196;
            faceFront[137] = 200;
            faceFront[141] = 200;
            faceFront[135] = 209;
            faceFront[142] = 212;
            faceFront[143] = 215;
            faceFront[139] = 219;
            faceFront[146] = 234;
            faceFront[147] = 244;
            faceFront[134] = 247;
            faceFront[144] = 247;
            faceFront[145] = 254;
            faceFront[152] = 277;
            faceFront[149] = 279;
            faceFront[148] = 290;
            faceFront[159] = 298;
            faceFront[156] = 300;
            faceFront[158] = 301;
            faceFront[154] = 305;
            faceFront[157] = 306;
            faceFront[150] = 307;
            faceFront[162] = 307;
            faceFront[151] = 313;
            faceFront[160] = 321;
            faceFront[153] = 328;
            faceFront[163] = 329;
            faceFront[165] = 331;
            faceFront[161] = 333;
            faceFront[166] = 336;
            faceFront[175] = 339;
            faceFront[164] = 340;
            faceFront[174] = 341;
            faceFront[155] = 348;
            faceFront[178] = 349;
            faceFront[177] = 355;
            faceFront[168] = 369;
            faceFront[169] = 378;
            faceFront[180] = 382;
            faceFront[173] = 384;
            faceFront[167] = 385;
            faceFront[172] = 386;
            faceFront[170] = 388;
            faceFront[171] = 391;
            faceFront[181] = 391;
            faceFront[182] = 395;
            faceFront[179] = 397;
            faceFront[176] = 403;
            faceFront[194] = 451;
            faceFront[184] = 458;
            faceFront[185] = 463;
            faceFront[193] = 466;
            faceFront[183] = 469;
            faceFront[187] = 473;
            faceFront[188] = 473;
            faceFront[186] = 477;
            faceFront[192] = 484;
            faceFront[195] = 493;
            faceFront[198] = 501;
            faceFront[189] = 517;
            faceFront[190] = 526;
            faceFront[191] = 536;
            faceFront[200] = 542;
            faceFront[199] = 554;
            faceFront[202] = 559;
            faceFront[196] = 560;
            faceFront[201] = 565;
            faceFront[197] = 574;
            faceFront[203] = 587;
            faceFront[204] = 616;
            faceFront[207] = 683;
            faceFront[205] = 684;
            faceFront[208] = 689;
            faceFront[211] = 694;
            faceFront[209] = 704;
            faceFront[212] = 706;
            faceFront[210] = 707;
            faceFront[216] = 719;
            faceFront[214] = 727;
            faceFront[218] = 739;
            faceFront[213] = 742;
            faceFront[217] = 742;
            faceFront[206] = 759;
            faceFront[215] = 766;
            faceFront[220] = 786;
            faceFront[219] = 790;
            faceFront[221] = 845;
            faceFront[223] = 846;
            faceFront[222] = 892;
            faceFront[225] = 912;
            faceFront[224] = 921;
            faceFront[226] = 958;
            faceFront[228] = 1021;
            faceFront[230] = 1036;
            faceFront[227] = 1055;
            faceFront[231] = 1079;
            faceFront[229] = 1090;
            faceFront[234] = 1125;
            faceFront[235] = 1150;
            faceFront[232] = 1170;
            faceFront[233] = 1218;
            faceFront[236] = 1232;
            faceFront[238] = 1236;
            faceFront[237] = 1250;
            faceFront[239] = 1349;
            faceFront[240] = 1415;
            faceFront[241] = 1603;
            faceFront[242] = 1607;
            faceFront[243] = 1684;
            faceFront[244] = 1950;
            faceFront[245] = 2128;
            faceFront[246] = 2198;
            faceFront[247] = 2607;
            faceFront[248] = 3185;
            faceFront[249] = 3523;
            faceFront[250] = 4510;
            faceFront[251] = 5668;
            faceFront[252] = 6368;
            faceFront[253] = 8261;
            faceFront[254] = 16608;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[25] = 5;
            faceBack[26] = 5;
            faceBack[29] = 5;
            faceBack[30] = 5;
            faceBack[36] = 5;
            faceBack[43] = 5;
            faceBack[46] = 5;
            faceBack[27] = 6;
            faceBack[23] = 7;
            faceBack[32] = 7;
            faceBack[40] = 7;
            faceBack[47] = 7;
            faceBack[20] = 9;
            faceBack[37] = 9;
            faceBack[44] = 9;
            faceBack[50] = 9;
            faceBack[51] = 9;
            faceBack[53] = 9;
            faceBack[42] = 10;
            faceBack[48] = 10;
            faceBack[54] = 11;
            faceBack[41] = 12;
            faceBack[58] = 12;
            faceBack[68] = 12;
            faceBack[52] = 13;
            faceBack[45] = 14;
            faceBack[62] = 14;
            faceBack[55] = 15;
            faceBack[67] = 15;
            faceBack[69] = 15;
            faceBack[49] = 16;
            faceBack[56] = 17;
            faceBack[60] = 17;
            faceBack[65] = 17;
            faceBack[57] = 18;
            faceBack[66] = 18;
            faceBack[61] = 19;
            faceBack[63] = 19;
            faceBack[64] = 20;
            faceBack[59] = 22;
            faceBack[71] = 23;
            faceBack[73] = 23;
            faceBack[77] = 25;
            faceBack[70] = 26;
            faceBack[76] = 26;
            faceBack[78] = 26;
            faceBack[81] = 26;
            faceBack[99] = 28;
            faceBack[89] = 29;
            faceBack[86] = 30;
            faceBack[92] = 30;
            faceBack[72] = 31;
            faceBack[74] = 31;
            faceBack[91] = 31;
            faceBack[75] = 32;
            faceBack[107] = 32;
            faceBack[83] = 33;
            faceBack[113] = 34;
            faceBack[79] = 35;
            faceBack[87] = 35;
            faceBack[80] = 37;
            faceBack[88] = 37;
            faceBack[108] = 37;
            faceBack[90] = 38;
            faceBack[93] = 38;
            faceBack[111] = 38;
            faceBack[114] = 38;
            faceBack[94] = 40;
            faceBack[82] = 41;
            faceBack[84] = 41;
            faceBack[102] = 41;
            faceBack[106] = 41;
            faceBack[100] = 42;
            faceBack[101] = 42;
            faceBack[103] = 44;
            faceBack[85] = 45;
            faceBack[95] = 45;
            faceBack[109] = 46;
            faceBack[98] = 48;
            faceBack[105] = 48;
            faceBack[117] = 48;
            faceBack[110] = 50;
            faceBack[112] = 52;
            faceBack[116] = 53;
            faceBack[97] = 56;
            faceBack[115] = 58;
            faceBack[119] = 60;
            faceBack[96] = 61;
            faceBack[118] = 64;
            faceBack[104] = 67;
            faceBack[120] = 70;
            faceBack[123] = 83;
            faceBack[122] = 91;
            faceBack[121] = 92;
            faceBack[124] = 105;
            faceBack[125] = 111;
            faceBack[126] = 132;
            faceBack[131] = 152;
            faceBack[128] = 163;
            faceBack[132] = 165;
            faceBack[130] = 173;
            faceBack[127] = 181;
            faceBack[129] = 181;
            faceBack[136] = 190;
            faceBack[140] = 200;
            faceBack[133] = 201;
            faceBack[138] = 206;
            faceBack[137] = 220;
            faceBack[141] = 223;
            faceBack[139] = 225;
            faceBack[143] = 225;
            faceBack[135] = 228;
            faceBack[142] = 230;
            faceBack[146] = 245;
            faceBack[144] = 264;
            faceBack[147] = 272;
            faceBack[134] = 275;
            faceBack[145] = 280;
            faceBack[149] = 294;
            faceBack[152] = 316;
            faceBack[148] = 317;
            faceBack[154] = 328;
            faceBack[150] = 331;
            faceBack[159] = 333;
            faceBack[156] = 336;
            faceBack[158] = 341;
            faceBack[157] = 342;
            faceBack[162] = 342;
            faceBack[151] = 343;
            faceBack[160] = 346;
            faceBack[153] = 351;
            faceBack[161] = 353;
            faceBack[163] = 361;
            faceBack[165] = 366;
            faceBack[166] = 376;
            faceBack[155] = 378;
            faceBack[175] = 379;
            faceBack[164] = 383;
            faceBack[174] = 388;
            faceBack[177] = 394;
            faceBack[168] = 401;
            faceBack[178] = 412;
            faceBack[169] = 414;
            faceBack[171] = 425;
            faceBack[170] = 426;
            faceBack[167] = 430;
            faceBack[180] = 432;
            faceBack[181] = 432;
            faceBack[172] = 433;
            faceBack[173] = 438;
            faceBack[176] = 447;
            faceBack[179] = 452;
            faceBack[182] = 459;
            faceBack[194] = 499;
            faceBack[184] = 511;
            faceBack[187] = 523;
            faceBack[185] = 526;
            faceBack[183] = 528;
            faceBack[188] = 528;
            faceBack[198] = 531;
            faceBack[193] = 532;
            faceBack[186] = 534;
            faceBack[195] = 537;
            faceBack[192] = 546;
            faceBack[189] = 572;
            faceBack[190] = 573;
            faceBack[200] = 582;
            faceBack[191] = 594;
            faceBack[201] = 607;
            faceBack[197] = 612;
            faceBack[202] = 619;
            faceBack[199] = 621;
            faceBack[196] = 624;
            faceBack[203] = 634;
            faceBack[204] = 677;
            faceBack[207] = 748;
            faceBack[208] = 749;
            faceBack[205] = 752;
            faceBack[211] = 759;
            faceBack[209] = 764;
            faceBack[210] = 779;
            faceBack[213] = 800;
            faceBack[214] = 800;
            faceBack[212] = 801;
            faceBack[217] = 805;
            faceBack[218] = 805;
            faceBack[216] = 806;
            faceBack[215] = 819;
            faceBack[206] = 838;
            faceBack[220] = 870;
            faceBack[219] = 879;
            faceBack[221] = 926;
            faceBack[223] = 954;
            faceBack[222] = 960;
            faceBack[224] = 1011;
            faceBack[225] = 1029;
            faceBack[226] = 1067;
            faceBack[228] = 1120;
            faceBack[227] = 1140;
            faceBack[230] = 1141;
            faceBack[229] = 1190;
            faceBack[231] = 1198;
            faceBack[234] = 1243;
            faceBack[235] = 1253;
            faceBack[232] = 1258;
            faceBack[233] = 1330;
            faceBack[236] = 1368;
            faceBack[238] = 1388;
            faceBack[237] = 1400;
            faceBack[239] = 1514;
            faceBack[240] = 1585;
            faceBack[241] = 1668;
            faceBack[242] = 1690;
            faceBack[243] = 1828;
            faceBack[244] = 2070;
            faceBack[245] = 2227;
            faceBack[246] = 2295;
            faceBack[247] = 2796;
            faceBack[248] = 3374;
            faceBack[249] = 3822;
            faceBack[250] = 4842;
            faceBack[251] = 6156;
            faceBack[252] = 6888;
            faceBack[253] = 8988;
            faceBack[254] = 17670;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[72] = 171;
            faceLeft[106] = 173;
            faceLeft[141] = 173;
            faceLeft[184] = 173;
            faceLeft[32] = 174;
            faceLeft[94] = 174;
            faceLeft[130] = 175;
            faceLeft[166] = 175;
            faceLeft[69] = 176;
            faceLeft[155] = 176;
            faceLeft[212] = 176;
            faceLeft[121] = 177;
            faceLeft[208] = 177;
            faceLeft[234] = 177;
            faceLeft[99] = 178;
            faceLeft[147] = 178;
            faceLeft[164] = 178;
            faceLeft[120] = 179;
            faceLeft[122] = 179;
            faceLeft[148] = 179;
            faceLeft[156] = 179;
            faceLeft[187] = 179;
            faceLeft[97] = 180;
            faceLeft[139] = 180;
            faceLeft[140] = 180;
            faceLeft[175] = 180;
            faceLeft[183] = 180;
            faceLeft[189] = 180;
            faceLeft[123] = 181;
            faceLeft[172] = 181;
            faceLeft[186] = 181;
            faceLeft[191] = 181;
            faceLeft[239] = 181;
            faceLeft[151] = 182;
            faceLeft[220] = 182;
            faceLeft[169] = 183;
            faceLeft[178] = 186;
            faceLeft[127] = 344;
            faceLeft[132] = 347;
            faceLeft[49] = 348;
            faceLeft[136] = 349;
            faceLeft[159] = 351;
            faceLeft[167] = 353;
            faceLeft[174] = 353;
            faceLeft[216] = 353;
            faceLeft[158] = 354;
            faceLeft[193] = 354;
            faceLeft[240] = 354;
            faceLeft[79] = 355;
            faceLeft[170] = 356;
            faceLeft[207] = 356;
            faceLeft[113] = 357;
            faceLeft[177] = 358;
            faceLeft[202] = 358;
            faceLeft[197] = 359;
            faceLeft[222] = 360;
            faceLeft[236] = 360;
            faceLeft[203] = 361;
            faceLeft[245] = 361;
            faceLeft[219] = 362;
            faceLeft[233] = 365;
            faceLeft[133] = 522;
            faceLeft[173] = 522;
            faceLeft[232] = 523;
            faceLeft[238] = 523;
            faceLeft[231] = 525;
            faceLeft[180] = 526;
            faceLeft[153] = 528;
            faceLeft[235] = 528;
            faceLeft[196] = 529;
            faceLeft[188] = 531;
            faceLeft[192] = 531;
            faceLeft[126] = 532;
            faceLeft[152] = 532;
            faceLeft[228] = 532;
            faceLeft[145] = 533;
            faceLeft[201] = 533;
            faceLeft[137] = 538;
            faceLeft[217] = 538;
            faceLeft[200] = 539;
            faceLeft[190] = 540;
            faceLeft[198] = 541;
            faceLeft[204] = 542;
            faceLeft[179] = 543;
            faceLeft[229] = 697;
            faceLeft[210] = 701;
            faceLeft[226] = 706;
            faceLeft[160] = 708;
            faceLeft[118] = 710;
            faceLeft[243] = 710;
            faceLeft[143] = 711;
            faceLeft[209] = 714;
            faceLeft[161] = 715;
            faceLeft[199] = 715;
            faceLeft[244] = 874;
            faceLeft[181] = 887;
            faceLeft[237] = 895;
            faceLeft[205] = 896;
            faceLeft[230] = 1057;
            faceLeft[194] = 1065;
            faceLeft[225] = 1067;
            faceLeft[241] = 1083;
            faceLeft[206] = 1239;
            faceLeft[223] = 1247;
            faceLeft[224] = 1401;
            faceLeft[227] = 1417;
            faceLeft[246] = 1597;
            faceLeft[247] = 1977;
            faceLeft[248] = 2290;
            faceLeft[252] = 2552;
            faceLeft[253] = 2683;
            faceLeft[250] = 2843;
            faceLeft[249] = 3201;
            faceLeft[251] = 3396;
            faceLeft[254] = 5065;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[4] = 5;
            faceRight[123] = 183;
            faceRight[220] = 183;
            faceRight[178] = 184;
            faceRight[186] = 184;
            faceRight[122] = 186;
            faceRight[147] = 186;
            faceRight[169] = 186;
            faceRight[94] = 188;
            faceRight[97] = 188;
            faceRight[106] = 188;
            faceRight[139] = 188;
            faceRight[164] = 188;
            faceRight[234] = 188;
            faceRight[130] = 189;
            faceRight[191] = 189;
            faceRight[212] = 189;
            faceRight[69] = 190;
            faceRight[172] = 190;
            faceRight[175] = 190;
            faceRight[72] = 191;
            faceRight[99] = 191;
            faceRight[121] = 191;
            faceRight[141] = 191;
            faceRight[151] = 191;
            faceRight[156] = 191;
            faceRight[140] = 192;
            faceRight[189] = 192;
            faceRight[208] = 192;
            faceRight[148] = 193;
            faceRight[155] = 193;
            faceRight[239] = 193;
            faceRight[166] = 194;
            faceRight[120] = 195;
            faceRight[187] = 196;
            faceRight[32] = 197;
            faceRight[183] = 197;
            faceRight[184] = 198;
            faceRight[233] = 363;
            faceRight[174] = 366;
            faceRight[79] = 367;
            faceRight[132] = 371;
            faceRight[49] = 372;
            faceRight[167] = 372;
            faceRight[177] = 373;
            faceRight[203] = 373;
            faceRight[127] = 374;
            faceRight[197] = 374;
            faceRight[193] = 375;
            faceRight[158] = 378;
            faceRight[170] = 378;
            faceRight[245] = 378;
            faceRight[136] = 379;
            faceRight[113] = 381;
            faceRight[159] = 381;
            faceRight[216] = 381;
            faceRight[219] = 381;
            faceRight[222] = 382;
            faceRight[202] = 383;
            faceRight[207] = 385;
            faceRight[236] = 385;
            faceRight[240] = 388;
            faceRight[173] = 554;
            faceRight[201] = 554;
            faceRight[232] = 556;
            faceRight[145] = 560;
            faceRight[133] = 562;
            faceRight[152] = 562;
            faceRight[153] = 562;
            faceRight[137] = 563;
            faceRight[179] = 565;
            faceRight[204] = 565;
            faceRight[228] = 565;
            faceRight[180] = 566;
            faceRight[196] = 566;
            faceRight[192] = 568;
            faceRight[238] = 569;
            faceRight[190] = 570;
            faceRight[200] = 570;
            faceRight[188] = 574;
            faceRight[217] = 574;
            faceRight[235] = 574;
            faceRight[198] = 575;
            faceRight[231] = 576;
            faceRight[126] = 581;
            faceRight[226] = 737;
            faceRight[118] = 742;
            faceRight[229] = 756;
            faceRight[160] = 757;
            faceRight[209] = 757;
            faceRight[210] = 758;
            faceRight[161] = 759;
            faceRight[143] = 763;
            faceRight[199] = 763;
            faceRight[243] = 770;
            faceRight[237] = 947;
            faceRight[244] = 947;
            faceRight[205] = 952;
            faceRight[181] = 954;
            faceRight[225] = 1122;
            faceRight[241] = 1125;
            faceRight[230] = 1130;
            faceRight[194] = 1133;
            faceRight[206] = 1334;
            faceRight[223] = 1335;
            faceRight[224] = 1479;
            faceRight[227] = 1506;
            faceRight[1] = 1682;
            faceRight[246] = 1705;
            faceRight[247] = 2083;
            faceRight[253] = 2293;
            faceRight[252] = 2455;
            faceRight[248] = 2456;
            faceRight[250] = 3026;
            faceRight[249] = 3424;
            faceRight[251] = 3570;
            faceRight[254] = 6357;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[3] = 5;
            faceTop[5] = 6;
            faceTop[64] = 6;
            faceTop[48] = 7;
            faceTop[4] = 8;
            faceTop[221] = 9;
            faceTop[96] = 10;
            faceTop[16] = 11;
            faceTop[1] = 13;
            faceTop[2] = 14;
            faceTop[242] = 59;
            faceTop[122] = 73;
            faceTop[197] = 73;
            faceTop[211] = 75;
            faceTop[140] = 76;
            faceTop[151] = 76;
            faceTop[178] = 76;
            faceTop[139] = 78;
            faceTop[189] = 78;
            faceTop[147] = 79;
            faceTop[155] = 79;
            faceTop[156] = 79;
            faceTop[99] = 80;
            faceTop[164] = 80;
            faceTop[184] = 81;
            faceTop[123] = 82;
            faceTop[148] = 82;
            faceTop[172] = 82;
            faceTop[69] = 83;
            faceTop[191] = 83;
            faceTop[220] = 83;
            faceTop[234] = 84;
            faceTop[98] = 85;
            faceTop[175] = 85;
            faceTop[72] = 86;
            faceTop[32] = 87;
            faceTop[120] = 87;
            faceTop[141] = 87;
            faceTop[182] = 87;
            faceTop[121] = 88;
            faceTop[166] = 88;
            faceTop[169] = 88;
            faceTop[186] = 88;
            faceTop[94] = 89;
            faceTop[106] = 89;
            faceTop[130] = 89;
            faceTop[208] = 89;
            faceTop[187] = 90;
            faceTop[195] = 90;
            faceTop[239] = 90;
            faceTop[212] = 93;
            faceTop[183] = 96;
            faceTop[79] = 152;
            faceTop[49] = 153;
            faceTop[177] = 158;
            faceTop[170] = 160;
            faceTop[203] = 160;
            faceTop[158] = 161;
            faceTop[132] = 162;
            faceTop[219] = 162;
            faceTop[167] = 163;
            faceTop[161] = 164;
            faceTop[174] = 164;
            faceTop[113] = 165;
            faceTop[192] = 166;
            faceTop[240] = 169;
            faceTop[126] = 170;
            faceTop[202] = 171;
            faceTop[236] = 171;
            faceTop[233] = 172;
            faceTop[216] = 174;
            faceTop[222] = 176;
            faceTop[159] = 180;
            faceTop[245] = 227;
            faceTop[145] = 228;
            faceTop[217] = 230;
            faceTop[201] = 236;
            faceTop[190] = 237;
            faceTop[204] = 237;
            faceTop[200] = 239;
            faceTop[162] = 240;
            faceTop[229] = 244;
            faceTop[133] = 246;
            faceTop[153] = 246;
            faceTop[127] = 248;
            faceTop[188] = 249;
            faceTop[196] = 249;
            faceTop[173] = 252;
            faceTop[228] = 252;
            faceTop[235] = 253;
            faceTop[179] = 254;
            faceTop[180] = 256;
            faceTop[210] = 258;
            faceTop[152] = 259;
            faceTop[232] = 260;
            faceTop[160] = 265;
            faceTop[193] = 266;
            faceTop[238] = 266;
            faceTop[198] = 325;
            faceTop[143] = 332;
            faceTop[226] = 332;
            faceTop[206] = 337;
            faceTop[118] = 342;
            faceTop[199] = 344;
            faceTop[181] = 349;
            faceTop[209] = 355;
            faceTop[243] = 403;
            faceTop[194] = 406;
            faceTop[137] = 409;
            faceTop[205] = 412;
            faceTop[230] = 416;
            faceTop[237] = 423;
            faceTop[231] = 425;
            faceTop[207] = 432;
            faceTop[244] = 483;
            faceTop[224] = 488;
            faceTop[241] = 541;
            faceTop[223] = 593;
            faceTop[225] = 651;
            faceTop[227] = 669;
            faceTop[246] = 796;
            faceTop[247] = 972;
            faceTop[248] = 1172;
            faceTop[252] = 1183;
            faceTop[253] = 1302;
            faceTop[250] = 1328;
            faceTop[249] = 1592;
            faceTop[251] = 1704;
            faceTop[254] = 2471;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[96] = 39;
            faceBottom[195] = 72;
            faceBottom[220] = 72;
            faceBottom[120] = 73;
            faceBottom[178] = 73;
            faceBottom[164] = 74;
            faceBottom[169] = 74;
            faceBottom[106] = 75;
            faceBottom[123] = 75;
            faceBottom[147] = 75;
            faceBottom[197] = 75;
            faceBottom[122] = 76;
            faceBottom[172] = 77;
            faceBottom[191] = 77;
            faceBottom[212] = 77;
            faceBottom[94] = 78;
            faceBottom[130] = 78;
            faceBottom[140] = 78;
            faceBottom[189] = 78;
            faceBottom[211] = 78;
            faceBottom[239] = 78;
            faceBottom[72] = 79;
            faceBottom[155] = 79;
            faceBottom[183] = 79;
            faceBottom[186] = 79;
            faceBottom[98] = 80;
            faceBottom[99] = 80;
            faceBottom[148] = 80;
            faceBottom[156] = 80;
            faceBottom[208] = 80;
            faceBottom[234] = 80;
            faceBottom[151] = 81;
            faceBottom[182] = 81;
            faceBottom[139] = 82;
            faceBottom[121] = 83;
            faceBottom[166] = 83;
            faceBottom[175] = 83;
            faceBottom[187] = 83;
            faceBottom[32] = 85;
            faceBottom[141] = 85;
            faceBottom[184] = 86;
            faceBottom[69] = 87;
            faceBottom[233] = 146;
            faceBottom[167] = 151;
            faceBottom[79] = 152;
            faceBottom[132] = 152;
            faceBottom[170] = 152;
            faceBottom[177] = 152;
            faceBottom[158] = 153;
            faceBottom[49] = 154;
            faceBottom[174] = 154;
            faceBottom[245] = 154;
            faceBottom[161] = 155;
            faceBottom[222] = 156;
            faceBottom[203] = 157;
            faceBottom[216] = 159;
            faceBottom[113] = 160;
            faceBottom[126] = 161;
            faceBottom[192] = 161;
            faceBottom[219] = 161;
            faceBottom[236] = 161;
            faceBottom[240] = 162;
            faceBottom[202] = 164;
            faceBottom[159] = 166;
            faceBottom[145] = 227;
            faceBottom[133] = 232;
            faceBottom[162] = 232;
            faceBottom[200] = 232;
            faceBottom[232] = 232;
            faceBottom[190] = 233;
            faceBottom[229] = 234;
            faceBottom[153] = 235;
            faceBottom[173] = 237;
            faceBottom[204] = 237;
            faceBottom[238] = 237;
            faceBottom[152] = 238;
            faceBottom[228] = 238;
            faceBottom[179] = 239;
            faceBottom[196] = 239;
            faceBottom[217] = 239;
            faceBottom[127] = 240;
            faceBottom[201] = 240;
            faceBottom[235] = 240;
            faceBottom[180] = 241;
            faceBottom[193] = 241;
            faceBottom[188] = 248;
            faceBottom[160] = 249;
            faceBottom[210] = 252;
            faceBottom[226] = 309;
            faceBottom[143] = 317;
            faceBottom[199] = 317;
            faceBottom[243] = 318;
            faceBottom[198] = 320;
            faceBottom[118] = 323;
            faceBottom[206] = 323;
            faceBottom[181] = 334;
            faceBottom[209] = 334;
            faceBottom[137] = 392;
            faceBottom[237] = 392;
            faceBottom[194] = 400;
            faceBottom[205] = 400;
            faceBottom[231] = 401;
            faceBottom[230] = 402;
            faceBottom[207] = 403;
            faceBottom[244] = 404;
            faceBottom[224] = 465;
            faceBottom[241] = 480;
            faceBottom[223] = 572;
            faceBottom[225] = 612;
            faceBottom[227] = 624;
            faceBottom[246] = 713;
            faceBottom[247] = 871;
            faceBottom[252] = 1007;
            faceBottom[248] = 1067;
            faceBottom[253] = 1130;
            faceBottom[250] = 1191;
            faceBottom[249] = 1465;
            faceBottom[251] = 1591;
            faceBottom[254] = 1827;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_PENUMBRA] = mapInfo;
        }

        private static void LoadVanilla()
        {
            HALCYON_ORES = PlanetMapProfile.BuildOreMap(
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
            HALCYON.Ores = HALCYON_ORES;
            PENUMBRA_ORES = PlanetMapProfile.BuildOreMap(
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
            PENUMBRA.Ores = PENUMBRA_ORES;
        }

        private static void LoadExtendedSurvival()
        {
            HALCYON_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    PlanetMapProfile.Silicon_01
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
            HALCYON.Ores = HALCYON_ORES;
            PENUMBRA_ORES = PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01,
                    BetterStoneIntegrationProfile.Heazlewoodite_01,
                    BetterStoneIntegrationProfile.Sinoite_01,
                    BetterStoneIntegrationProfile.Quartz_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01,
                    BetterStoneIntegrationProfile.Hapkeite_01,
                    BetterStoneIntegrationProfile.Taenite_01,
                    PlanetMapProfile.Silicon_01
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
            PENUMBRA.Ores = PENUMBRA_ORES;
        }

        private static void LoadBetterStoneVanilla()
        {
            HALCYON_ORES = PlanetMapProfile.BuildOreMap(
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
            HALCYON.Ores = HALCYON_ORES;
            PENUMBRA_ORES = PlanetMapProfile.BuildOreMap(
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
            PENUMBRA.Ores = PENUMBRA_ORES;
        }

        private static void LoadBetterStoneExtendedSurvival()
        {
            HALCYON_ORES = PlanetMapProfile.BuildOreMap(
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
            HALCYON.Ores = HALCYON_ORES;
            PENUMBRA_ORES = PlanetMapProfile.BuildOreMap(
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
            PENUMBRA.Ores = PENUMBRA_ORES;
        }

        // Ore Maps
        public static List<PlanetProfile.OreMapInfo> HALCYON_ORES;
        public static List<PlanetProfile.OreMapInfo> PENUMBRA_ORES;

        // Planets
        public static readonly PlanetProfile HALCYON = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = HALCYON_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.7f, 0.4f, 70, 1.3f, 0.15f, 0.5f),
            Gravity = PlanetMapProfile.GetGravity(0.5f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = VanilaMapProfile.ALIEN_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile PENUMBRA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = PENUMBRA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1f, 0.8f, 80, 1.0f, 0.15f, 0.5f),
            Gravity = PlanetMapProfile.GetGravity(0.8f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -230, -100),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 65),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = VanilaMapProfile.TRITON_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
