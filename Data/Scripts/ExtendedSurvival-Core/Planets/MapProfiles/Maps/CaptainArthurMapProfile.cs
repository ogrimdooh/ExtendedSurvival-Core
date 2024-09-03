using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class CaptainArthurMapProfile
    {

        public const ulong CRAIT_MODID = 2394305855;
        public const ulong PLANET26_MODID = 2079185441;

        public const string DEFAULT_CRAIT = "PLANET-CRAIT";
        public const string DEFAULT_PLANET26 = "PLANET-26";

        // Crait

        public const string MoonAlien = "MoonAlien";
        public const string MoonAlienBare = "MoonAlien bare";
        public const string Saltflat = "Saltflat";
        public const string Redsand = "Redsand";
        public const string Redsoil = "Redsoil";
        public const string CraitIce = "CraitIce";
        public const string AlienSnowSpider = "AlienSnowSpider";

        // Planet-26

        public const string Beachsideice = "Beachsideice";
        public const string Mediumice = "Mediumice";
        public const string Ice_03 = "Ice_03";
        public const string DarinusIce = "DarinusIce";
        public const string Ice_02DOC = "Ice_02DOC";

        public const string MEwoods = "MEwoods";
        public const string MEwoodsgrass = "MEwoodsgrass";
        public const string MESoil = "MESoil";
        public const string MESteppe = "MESteppe";
        public const string DarinusGrass = "DarinusGrass";
        public const string DarinusGrass2 = "DarinusGrass2";
        public const string PWoodsGrass = "P-Woods_grass";
        public const string PurpleGrass = "purple Grass";
        public const string GrassDOC = "Grass DOC";
        public const string Grass_oldDOC = "Grass_old DOC";
        public const string Woods_grassDOC = "Woods_grass DOC";
        public const string SoilDOC = "Soil DOC";

        public const string DOCSand_02 = "DOC Sand_02";

        static CaptainArthurMapProfile()
        {
            LoadCraitOreMapInfo();
            LoadPlanet26OreMapInfo();
            CRAIT.Ores = VanilaMapProfile.ALIEN_ORES;
            PLANET26.Ores = VanilaMapProfile.EARTHLIKE_ORES;
        }

        private static void LoadCraitOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[200] = 17;
            faceFront[220] = 18;
            faceFront[240] = 20;
            faceFront[98] = 499;
            faceFront[80] = 499;
            faceFront[100] = 753;
            faceFront[152] = 989;
            faceFront[92] = 1002;
            faceFront[96] = 1006;
            faceFront[104] = 1007;
            faceFront[76] = 1252;
            faceFront[188] = 1481;
            faceFront[180] = 1488;
            faceFront[112] = 1961;
            faceFront[108] = 1969;
            faceFront[168] = 1974;
            faceFront[176] = 1989;
            faceFront[8] = 2000;
            faceFront[84] = 2003;
            faceFront[12] = 2223;
            faceFront[160] = 2230;
            faceFront[72] = 2243;
            faceFront[116] = 2937;
            faceFront[184] = 2966;
            faceFront[172] = 2968;
            faceFront[148] = 3225;
            faceFront[16] = 3452;
            faceFront[68] = 3474;
            faceFront[88] = 3528;
            faceFront[20] = 3693;
            faceFront[142] = 3796;
            faceFront[64] = 3981;
            faceFront[164] = 4220;
            faceFront[144] = 4469;
            faceFront[48] = 4470;
            faceFront[52] = 4471;
            faceFront[156] = 4702;
            faceFront[128] = 4718;
            faceFront[32] = 5003;
            faceFront[60] = 5476;
            faceFront[1] = 5991;
            faceFront[28] = 6226;
            faceFront[56] = 6451;
            faceFront[24] = 6458;
            faceFront[124] = 8179;
            faceFront[4] = 9345;
            faceFront[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[200] = 17;
            faceBack[220] = 18;
            faceBack[240] = 20;
            faceBack[98] = 499;
            faceBack[80] = 499;
            faceBack[100] = 753;
            faceBack[152] = 989;
            faceBack[92] = 1002;
            faceBack[96] = 1006;
            faceBack[104] = 1007;
            faceBack[76] = 1252;
            faceBack[188] = 1481;
            faceBack[180] = 1488;
            faceBack[112] = 1961;
            faceBack[108] = 1969;
            faceBack[168] = 1974;
            faceBack[176] = 1989;
            faceBack[8] = 2000;
            faceBack[84] = 2003;
            faceBack[12] = 2223;
            faceBack[160] = 2230;
            faceBack[72] = 2243;
            faceBack[116] = 2937;
            faceBack[184] = 2966;
            faceBack[172] = 2968;
            faceBack[148] = 3225;
            faceBack[16] = 3452;
            faceBack[68] = 3474;
            faceBack[88] = 3528;
            faceBack[20] = 3693;
            faceBack[142] = 3796;
            faceBack[64] = 3981;
            faceBack[164] = 4220;
            faceBack[144] = 4469;
            faceBack[48] = 4470;
            faceBack[52] = 4471;
            faceBack[156] = 4702;
            faceBack[128] = 4718;
            faceBack[32] = 5003;
            faceBack[60] = 5476;
            faceBack[1] = 5991;
            faceBack[28] = 6226;
            faceBack[56] = 6451;
            faceBack[24] = 6458;
            faceBack[124] = 8179;
            faceBack[4] = 9345;
            faceBack[120] = 9410;
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
            faceRight[200] = 17;
            faceRight[220] = 18;
            faceRight[240] = 20;
            faceRight[98] = 499;
            faceRight[80] = 499;
            faceRight[100] = 753;
            faceRight[152] = 989;
            faceRight[92] = 1002;
            faceRight[96] = 1006;
            faceRight[104] = 1007;
            faceRight[76] = 1252;
            faceRight[188] = 1481;
            faceRight[180] = 1488;
            faceRight[112] = 1961;
            faceRight[108] = 1969;
            faceRight[168] = 1974;
            faceRight[176] = 1989;
            faceRight[8] = 2000;
            faceRight[84] = 2003;
            faceRight[12] = 2223;
            faceRight[160] = 2230;
            faceRight[72] = 2243;
            faceRight[116] = 2937;
            faceRight[184] = 2966;
            faceRight[172] = 2968;
            faceRight[148] = 3225;
            faceRight[16] = 3452;
            faceRight[68] = 3474;
            faceRight[88] = 3528;
            faceRight[20] = 3693;
            faceRight[142] = 3796;
            faceRight[64] = 3981;
            faceRight[164] = 4220;
            faceRight[144] = 4469;
            faceRight[48] = 4470;
            faceRight[52] = 4471;
            faceRight[156] = 4702;
            faceRight[128] = 4718;
            faceRight[32] = 5003;
            faceRight[60] = 5476;
            faceRight[1] = 5991;
            faceRight[28] = 6226;
            faceRight[56] = 6451;
            faceRight[24] = 6458;
            faceRight[124] = 8179;
            faceRight[4] = 9345;
            faceRight[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 12;
            faceTop[220] = 12;
            faceTop[240] = 12;
            faceTop[98] = 510;
            faceTop[80] = 511;
            faceTop[100] = 767;
            faceTop[152] = 1022;
            faceTop[104] = 1023;
            faceTop[92] = 1024;
            faceTop[96] = 1024;
            faceTop[76] = 1280;
            faceTop[180] = 1536;
            faceTop[188] = 1536;
            faceTop[88] = 1792;
            faceTop[176] = 2044;
            faceTop[108] = 2045;
            faceTop[112] = 2045;
            faceTop[168] = 2045;
            faceTop[8] = 2048;
            faceTop[84] = 2048;
            faceTop[12] = 2302;
            faceTop[72] = 2303;
            faceTop[160] = 2304;
            faceTop[172] = 3065;
            faceTop[116] = 3066;
            faceTop[184] = 3072;
            faceTop[148] = 3323;
            faceTop[4] = 3327;
            faceTop[68] = 3580;
            faceTop[16] = 3584;
            faceTop[20] = 3840;
            faceTop[64] = 4090;
            faceTop[164] = 4352;
            faceTop[250] = 4433;
            faceTop[144] = 4602;
            faceTop[52] = 4603;
            faceTop[48] = 4604;
            faceTop[128] = 4861;
            faceTop[156] = 4861;
            faceTop[32] = 5115;
            faceTop[60] = 5628;
            faceTop[1] = 6138;
            faceTop[28] = 6396;
            faceTop[56] = 6649;
            faceTop[24] = 6652;
            faceTop[124] = 8437;
            faceTop[120] = 9719;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[200] = 17;
            faceBottom[220] = 18;
            faceBottom[240] = 20;
            faceBottom[98] = 497;
            faceBottom[80] = 497;
            faceBottom[100] = 751;
            faceBottom[152] = 986;
            faceBottom[92] = 1000;
            faceBottom[96] = 1003;
            faceBottom[104] = 1006;
            faceBottom[76] = 1249;
            faceBottom[188] = 1475;
            faceBottom[180] = 1484;
            faceBottom[112] = 1957;
            faceBottom[108] = 1965;
            faceBottom[168] = 1970;
            faceBottom[176] = 1985;
            faceBottom[8] = 1992;
            faceBottom[84] = 1999;
            faceBottom[12] = 2215;
            faceBottom[160] = 2222;
            faceBottom[72] = 2234;
            faceBottom[116] = 2931;
            faceBottom[184] = 2954;
            faceBottom[172] = 2962;
            faceBottom[148] = 3216;
            faceBottom[16] = 3439;
            faceBottom[68] = 3464;
            faceBottom[88] = 3524;
            faceBottom[20] = 3678;
            faceBottom[142] = 3796;
            faceBottom[64] = 3968;
            faceBottom[164] = 4205;
            faceBottom[144] = 4456;
            faceBottom[48] = 4457;
            faceBottom[52] = 4458;
            faceBottom[156] = 4686;
            faceBottom[128] = 4707;
            faceBottom[32] = 4991;
            faceBottom[60] = 5459;
            faceBottom[1] = 5969;
            faceBottom[28] = 6208;
            faceBottom[56] = 6432;
            faceBottom[24] = 6438;
            faceBottom[124] = 8158;
            faceBottom[4] = 9333;
            faceBottom[120] = 9385;
            faceBottom[251] = 12623;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_CRAIT] = mapInfo;
        }

        private static void LoadPlanet26OreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[200] = 17;
            faceFront[220] = 18;
            faceFront[240] = 20;
            faceFront[98] = 499;
            faceFront[80] = 499;
            faceFront[100] = 753;
            faceFront[152] = 989;
            faceFront[92] = 1002;
            faceFront[96] = 1006;
            faceFront[104] = 1007;
            faceFront[76] = 1252;
            faceFront[188] = 1481;
            faceFront[180] = 1488;
            faceFront[112] = 1961;
            faceFront[108] = 1969;
            faceFront[168] = 1974;
            faceFront[176] = 1989;
            faceFront[8] = 2000;
            faceFront[84] = 2003;
            faceFront[12] = 2223;
            faceFront[160] = 2230;
            faceFront[72] = 2243;
            faceFront[116] = 2937;
            faceFront[184] = 2966;
            faceFront[172] = 2968;
            faceFront[148] = 3225;
            faceFront[16] = 3452;
            faceFront[68] = 3474;
            faceFront[88] = 3528;
            faceFront[20] = 3693;
            faceFront[142] = 3796;
            faceFront[64] = 3981;
            faceFront[164] = 4220;
            faceFront[144] = 4469;
            faceFront[48] = 4470;
            faceFront[52] = 4471;
            faceFront[156] = 4702;
            faceFront[128] = 4718;
            faceFront[32] = 5003;
            faceFront[60] = 5476;
            faceFront[1] = 5991;
            faceFront[28] = 6226;
            faceFront[56] = 6451;
            faceFront[24] = 6458;
            faceFront[124] = 8179;
            faceFront[4] = 9345;
            faceFront[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[200] = 17;
            faceBack[220] = 18;
            faceBack[240] = 20;
            faceBack[98] = 499;
            faceBack[80] = 499;
            faceBack[100] = 753;
            faceBack[152] = 989;
            faceBack[92] = 1002;
            faceBack[96] = 1006;
            faceBack[104] = 1007;
            faceBack[76] = 1252;
            faceBack[188] = 1481;
            faceBack[180] = 1488;
            faceBack[112] = 1961;
            faceBack[108] = 1969;
            faceBack[168] = 1974;
            faceBack[176] = 1989;
            faceBack[8] = 2000;
            faceBack[84] = 2003;
            faceBack[12] = 2223;
            faceBack[160] = 2230;
            faceBack[72] = 2243;
            faceBack[116] = 2937;
            faceBack[184] = 2966;
            faceBack[172] = 2968;
            faceBack[148] = 3225;
            faceBack[16] = 3452;
            faceBack[68] = 3474;
            faceBack[88] = 3528;
            faceBack[20] = 3693;
            faceBack[142] = 3796;
            faceBack[64] = 3981;
            faceBack[164] = 4220;
            faceBack[144] = 4469;
            faceBack[48] = 4470;
            faceBack[52] = 4471;
            faceBack[156] = 4702;
            faceBack[128] = 4718;
            faceBack[32] = 5003;
            faceBack[60] = 5476;
            faceBack[1] = 5991;
            faceBack[28] = 6226;
            faceBack[56] = 6451;
            faceBack[24] = 6458;
            faceBack[124] = 8179;
            faceBack[4] = 9345;
            faceBack[120] = 9410;
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
            faceRight[200] = 17;
            faceRight[220] = 18;
            faceRight[240] = 20;
            faceRight[98] = 499;
            faceRight[80] = 499;
            faceRight[100] = 753;
            faceRight[152] = 989;
            faceRight[92] = 1002;
            faceRight[96] = 1006;
            faceRight[104] = 1007;
            faceRight[76] = 1252;
            faceRight[188] = 1481;
            faceRight[180] = 1488;
            faceRight[112] = 1961;
            faceRight[108] = 1969;
            faceRight[168] = 1974;
            faceRight[176] = 1989;
            faceRight[8] = 2000;
            faceRight[84] = 2003;
            faceRight[12] = 2223;
            faceRight[160] = 2230;
            faceRight[72] = 2243;
            faceRight[116] = 2937;
            faceRight[184] = 2966;
            faceRight[172] = 2968;
            faceRight[148] = 3225;
            faceRight[16] = 3452;
            faceRight[68] = 3474;
            faceRight[88] = 3528;
            faceRight[20] = 3693;
            faceRight[142] = 3796;
            faceRight[64] = 3981;
            faceRight[164] = 4220;
            faceRight[144] = 4469;
            faceRight[48] = 4470;
            faceRight[52] = 4471;
            faceRight[156] = 4702;
            faceRight[128] = 4718;
            faceRight[32] = 5003;
            faceRight[60] = 5476;
            faceRight[1] = 5991;
            faceRight[28] = 6226;
            faceRight[56] = 6451;
            faceRight[24] = 6458;
            faceRight[124] = 8179;
            faceRight[4] = 9345;
            faceRight[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 17;
            faceTop[220] = 18;
            faceTop[240] = 20;
            faceTop[98] = 499;
            faceTop[80] = 499;
            faceTop[100] = 753;
            faceTop[152] = 989;
            faceTop[92] = 1002;
            faceTop[96] = 1006;
            faceTop[104] = 1007;
            faceTop[76] = 1252;
            faceTop[188] = 1481;
            faceTop[180] = 1488;
            faceTop[112] = 1961;
            faceTop[108] = 1969;
            faceTop[168] = 1974;
            faceTop[176] = 1989;
            faceTop[8] = 2000;
            faceTop[84] = 2003;
            faceTop[12] = 2223;
            faceTop[160] = 2230;
            faceTop[72] = 2243;
            faceTop[116] = 2937;
            faceTop[184] = 2966;
            faceTop[172] = 2968;
            faceTop[148] = 3225;
            faceTop[16] = 3452;
            faceTop[68] = 3474;
            faceTop[88] = 3528;
            faceTop[20] = 3693;
            faceTop[142] = 3796;
            faceTop[64] = 3981;
            faceTop[164] = 4220;
            faceTop[144] = 4469;
            faceTop[48] = 4470;
            faceTop[52] = 4471;
            faceTop[156] = 4702;
            faceTop[128] = 4718;
            faceTop[32] = 5003;
            faceTop[60] = 5476;
            faceTop[1] = 5991;
            faceTop[28] = 6226;
            faceTop[56] = 6451;
            faceTop[24] = 6458;
            faceTop[124] = 8179;
            faceTop[4] = 9345;
            faceTop[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[200] = 17;
            faceBottom[220] = 18;
            faceBottom[240] = 20;
            faceBottom[98] = 499;
            faceBottom[80] = 499;
            faceBottom[100] = 753;
            faceBottom[152] = 989;
            faceBottom[92] = 1002;
            faceBottom[96] = 1006;
            faceBottom[104] = 1007;
            faceBottom[76] = 1252;
            faceBottom[188] = 1481;
            faceBottom[180] = 1488;
            faceBottom[112] = 1961;
            faceBottom[108] = 1969;
            faceBottom[168] = 1974;
            faceBottom[176] = 1989;
            faceBottom[8] = 2000;
            faceBottom[84] = 2003;
            faceBottom[12] = 2223;
            faceBottom[160] = 2230;
            faceBottom[72] = 2243;
            faceBottom[116] = 2937;
            faceBottom[184] = 2966;
            faceBottom[172] = 2968;
            faceBottom[148] = 3225;
            faceBottom[16] = 3452;
            faceBottom[68] = 3474;
            faceBottom[88] = 3528;
            faceBottom[20] = 3693;
            faceBottom[142] = 3796;
            faceBottom[64] = 3981;
            faceBottom[164] = 4220;
            faceBottom[144] = 4469;
            faceBottom[48] = 4470;
            faceBottom[52] = 4471;
            faceBottom[156] = 4702;
            faceBottom[128] = 4718;
            faceBottom[32] = 5003;
            faceBottom[60] = 5476;
            faceBottom[1] = 5991;
            faceBottom[28] = 6226;
            faceBottom[56] = 6451;
            faceBottom[24] = 6458;
            faceBottom[124] = 8179;
            faceBottom[4] = 9345;
            faceBottom[120] = 9410;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_PLANET26] = mapInfo;
        }

        // Planets
        public static readonly PlanetProfile CRAIT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = CRAIT_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_TOTHT,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.0f, 0.5f, 80, 2.0f, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1, 4.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 70, 165),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "MoonAlien"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Redsoil", "Redsand", "Saltflat"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "RedRocks", "AlienRockyMountain", "MoonRocks", "TritonStone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AlienSnowSpider", "AlienSnow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "CraitIce")
            )
        };

        public static readonly PlanetProfile PLANET26 = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = PLANET26_MODID,
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
            SizeRange = new Vector2(110, 150),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Woods_grass DOC", "P-Woods_grass", "MEwoods", "Grass", "Woods_grass", "DarinusGrass2", "Grass DOC", "DarinusGrass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Rocks_grass", "Rocks_grass", "Grass_old", "purple Grass", "Rocks_grass", "Limestone", "MESteppe", "RavSoil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Sand_02", "DesertRocks", "MarsSoil", "MarsRocks", "DOC Sand_02"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Snow", "Grass_old DOC"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone", "MarsRocks", "TritonStone", "AlienRockyMountain", "DarinusRock", "RavRock", "RavCrackedRock"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "Ice_03", "Beachsideice", "Mediumice", "Ice_02DOC", "TritonIce", "DarinusIce", "IceEuropa2"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Volcanic, "RavLava")
            )
        };

    }

}
