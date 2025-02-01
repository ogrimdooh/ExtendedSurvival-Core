using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class MajorJonMapProfile
    {

        public const ulong TRELAN_MODID = 2636128625;
        public const ulong SATREUS_MODID = 2266665708;
        public const ulong KIMI_QUN_MODID = 2459246911;
        public const ulong LUMA_MODID = 2286318683;
        public const ulong TOHIL_MODID = 2296726670;
        public const ulong TEAL_MODID = 2603627657;
        public const ulong TEALWM_MODID = 2644430625;
        public const ulong ORLUNDA_MODID = 2873186053;
        public const ulong KOMOREBI_MODID = 3309805284;

        public const string DEFAULT_TEAL = "TEAL";
        public const string DEFAULT_TEALWM = "TEAL-WATERMOD";
        public const string DEFAULT_TRELAN = "TRELAN";

        public const string DEFAULT_SATREUS = "SATREUS";

        public const string DEFAULT_ORLUNDA = "ORLUNDA";

        public const string DEFAULT_LUMA = "LUMA";
        public const string DEFAULT_KIMI = "KIMI";
        public const string DEFAULT_QUN = "QUN";
        public const string DEFAULT_TOHIL = "TOHIL";

        public const string DEFAULT_KOMOREBI = "KOMOREBI";
        
        // Trelan

        public const string Soil_Trelan = "Soil_Trelan";
        public const string Grass_Trelan = "Grass_Trelan";
        public const string Grass_Trelan_bare = "Grass_Trelan_bare";

        // Satreus

        public const string Desert_01_Satreus = "Desert_01_Satreus";
        public const string Desert_01_Satreus_soil = "Desert_01_Satreus_soil";
        public const string Desert_01_red_Satreus = "Desert_01_red_Satreus";
        public const string Ground_red_Satreus = "Ground_red_Satreus";

        public const string Grass_old_Satreus = "Grass_old_Satreus";

        public const string DustyRocks3_Satreus = "DustyRocks3_Satreus";

        public const string Ice02_Satreus = "Ice02_Satreus";

        // Kimi

        public const string MoonRock_grey2_kimi = "MoonRock_grey2_kimi"; // Fe trace
        public const string MoonRock_black2_kimi = "MoonRock_black2_kimi"; // Fe trace
        public const string MoonRock_green2_kimi = "MoonRock_green2_kimi"; // Ni trace
        public const string Low_Dens_Iron_Kimi = "Low_Dens_Iron_Kimi"; // Fe trace

        // Qun

        public const string MoonRock_grey_qun = "MoonRock_grey_qun";
        public const string MoonRock_grey2_qun = "MoonRock_grey2_qun";
        public const string MoonRock_black2_qun = "MoonRock_black2_qun";

        public const string MoonSoil_grey_qun = "MoonSoil_grey_qun";
        public const string MoonSoil_grey2_qun = "MoonSoil_grey2_qun";
        public const string MoonSoil_black2_qun = "MoonSoil_black2_qun";

        public const string MoonSoil_red2_qun = "MoonSoil_red2_qun";

        // Tohil

        public const string TohilSnow01 = "TohilSnow01";
        public const string TohilSnow02 = "TohilSnow02";

        public const string TohilIce01 = "TohilIce01";
        public const string TohilIce02 = "TohilIce02";
        public const string TohilIce03 = "TohilIce03";

        // Teal

        public const string TealSea = "TealSea";
        public const string TealShore1 = "TealShore1";
        public const string TealShore2 = "TealShore2";
        public const string TealShore3 = "TealShore3";
        public const string TealShore4 = "TealShore4";
        public const string TealShore5 = "TealShore5";
        public const string TealShore6 = "TealShore6";
        public const string TealRiver = "TealRiver";
        public const string TealIce = "TealIce";

        public const string TealBlueGrass = "TealBlueGrass";
        public const string TealRocksGrass = "TealRocksGrass";
        public const string TealSnowGrass = "TealSnowGrass";

        public const string TealBlack_Soil = "TealBlack_Soil";
        public const string TealBlack_Soil_bare = "TealBlack_Soil_bare";

        // Orlunda

        public const string OrlundaRedSoil_1 = "OrlundaRedSoil_1";
        public const string OrlundaRedSoil_2 = "OrlundaRedSoil_2";
        public const string OrlundaRedSoil_3 = "OrlundaRedSoil_3";
        public const string Woods_grass_long = "Woods_grass_long";

        public const string OrlundaBeach = "OrlundaBeach";

        public const string OrlundaSnow = "OrlundaSnow";

        public const string OrlundaIce = "OrlundaIce";
        public const string OrlundaLake = "OrlundaLake";

        // Komorebi

        public const string VolcanoRock = "VolcanoRock";

        public const string Grass_var = "Grass_var";
        public const string Green_02 = "Green_02";
        public const string Green_02_var = "Green_02_var";
        public const string Green_02_bare = "Green_02_bare";
        public const string Green_04 = "Green_04";
        public const string Green_05 = "Green_05";
        public const string Green_06 = "Green_06";
        public const string Green_07 = "Green_07";
        public const string MossCarpet0 = "MossCarpet0";
        public const string MossCarpet2 = "MossCarpet2";
        public const string MossCarpet3 = "MossCarpet3";
        public const string Fungi_01 = "Fungi_01";
        public const string Fungi_01_alt = "Fungi_01_alt";
        public const string Fungi_02 = "Fungi_02";
        public const string Fungi_11 = "Fungi_11";
        public const string Fungi_16 = "Fungi_16";
        public const string Fungi_17 = "Fungi_17";
        public const string Mold_01 = "Mold_01";
        public const string Mold_11 = "Mold_11";
        public const string Mold_11_alt = "Mold_11_alt";

        public const string Desert_Rocks_01 = "Desert_Rocks_01";
        public const string Desert_Rocks_02 = "Desert_Rocks_02";
        public const string Desert_Soil_01 = "Desert_Soil_01";
        public const string Desert_Soil_03 = "Desert_Soil_03";
        public const string Desert_Dunes_01 = "Desert_Dunes_01";
        public const string Desert_Dunes_02 = "Desert_Dunes_02";
        public const string Salt_Flats_01 = "Salt_Flats_01";
        public const string Salt_Flats_03 = "Salt_Flats_03";

        public const string Underground_Ice = "Underground_Ice";

        public const string Mycel_02 = "Mycel_02";
        public const string Mycel_04 = "Mycel_04";
        public const string Mycel_07 = "Mycel_07";
        public const string Mycel_08 = "Mycel_08";

        public const string AcidLake_01 = "AcidLake_01";
        public const string AcidLake_02 = "AcidLake_02";
        public const string AcidLake_03 = "AcidLake_03";
        public const string AcidLake_04 = "AcidLake_04";

        static MajorJonMapProfile()
        {
            LoadTrelanOreMapInfo();
            LoadSatreusOreMapInfo();
            LoaKimiOreMapInfo();
            LoadQunOreMapInfo();
            LoadTohilOreMapInfo();
            LoadTealOreMapInfo();
            LoadTealWMOreMapInfo();
            LoadOrlundaOreMapInfo();
            LoadKomorebiOreMapInfo();
            TEAL.Ores = VanilaMapProfile.EARTHLIKE_ORES;
            TRELAN.Ores = VanilaMapProfile.MOON_ORES;
            ORLUNDA.Ores = VanilaMapProfile.MARS_ORES;
            SATREUS.Ores = VanilaMapProfile.PERTAM_ORES;
            KIMI.Ores = PlanetMapProfile.CopyAndAdd(
                VanilaMapProfile.MOON_ORES, 
                ignoreRariry: new PlanetProfile.OreRarity[] { 
                    PlanetProfile.OreRarity.Common, 
                    PlanetProfile.OreRarity.Rare, 
                    PlanetProfile.OreRarity.Epic 
                }
            );
            QUN.Ores = VanilaMapProfile.ALIEN_ORES;
            TOHIL.Ores = VanilaMapProfile.TRITON_ORES;
            KOMOREBI.Ores = VanilaMapProfile.EARTHLIKE_ORES;
        }

        private static void LoadKomorebiOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[60] = 1741;
            faceFront[10] = 1772;
            faceFront[150] = 1830;
            faceFront[20] = 1838;
            faceFront[180] = 1934;
            faceFront[40] = 2008;
            faceFront[130] = 2100;
            faceFront[80] = 2126;
            faceFront[110] = 2139;
            faceFront[140] = 2172;
            faceFront[50] = 2178;
            faceFront[70] = 2236;
            faceFront[120] = 2276;
            faceFront[200] = 2375;
            faceFront[30] = 2455;
            faceFront[170] = 2472;
            faceFront[100] = 2533;
            faceFront[90] = 2541;
            faceFront[160] = 2590;
            faceFront[190] = 2789;
            faceFront[220] = 86991;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[10] = 1146;
            faceBack[60] = 1298;
            faceBack[170] = 1302;
            faceBack[20] = 1341;
            faceBack[110] = 1420;
            faceBack[80] = 1429;
            faceBack[130] = 1433;
            faceBack[40] = 1564;
            faceBack[150] = 1597;
            faceBack[140] = 1677;
            faceBack[120] = 1693;
            faceBack[30] = 1707;
            faceBack[190] = 1708;
            faceBack[50] = 1719;
            faceBack[90] = 1743;
            faceBack[100] = 1783;
            faceBack[180] = 1874;
            faceBack[200] = 1971;
            faceBack[160] = 2077;
            faceBack[70] = 2099;
            faceBack[220] = 66842;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[80] = 962;
            faceLeft[50] = 1068;
            faceLeft[120] = 1177;
            faceLeft[190] = 1259;
            faceLeft[100] = 1274;
            faceLeft[60] = 1332;
            faceLeft[110] = 1335;
            faceLeft[170] = 1347;
            faceLeft[140] = 1353;
            faceLeft[150] = 1357;
            faceLeft[130] = 1360;
            faceLeft[70] = 1371;
            faceLeft[180] = 1401;
            faceLeft[200] = 1450;
            faceLeft[90] = 1498;
            faceLeft[160] = 1521;
            faceLeft[30] = 1560;
            faceLeft[20] = 1624;
            faceLeft[40] = 1632;
            faceLeft[10] = 1690;
            faceLeft[220] = 29044;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[240] = 511;
            faceRight[10] = 1647;
            faceRight[90] = 1875;
            faceRight[40] = 2033;
            faceRight[50] = 2049;
            faceRight[130] = 2074;
            faceRight[170] = 2121;
            faceRight[60] = 2129;
            faceRight[80] = 2146;
            faceRight[70] = 2193;
            faceRight[30] = 2215;
            faceRight[140] = 2228;
            faceRight[20] = 2284;
            faceRight[180] = 2327;
            faceRight[200] = 2348;
            faceRight[120] = 2368;
            faceRight[110] = 2396;
            faceRight[190] = 2406;
            faceRight[150] = 2425;
            faceRight[100] = 2452;
            faceRight[160] = 2832;
            faceRight[220] = 55768;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[170] = 1021;
            faceTop[90] = 1034;
            faceTop[70] = 1039;
            faceTop[180] = 1040;
            faceTop[50] = 1112;
            faceTop[110] = 1141;
            faceTop[40] = 1222;
            faceTop[140] = 1231;
            faceTop[20] = 1271;
            faceTop[160] = 1291;
            faceTop[80] = 1300;
            faceTop[200] = 1304;
            faceTop[10] = 1392;
            faceTop[130] = 1438;
            faceTop[100] = 1451;
            faceTop[190] = 1453;
            faceTop[150] = 1524;
            faceTop[60] = 1592;
            faceTop[120] = 1677;
            faceTop[30] = 1734;
            faceTop[220] = 25687;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[70] = 1238;
            faceBottom[180] = 1264;
            faceBottom[110] = 1301;
            faceBottom[170] = 1363;
            faceBottom[130] = 1388;
            faceBottom[60] = 1412;
            faceBottom[40] = 1427;
            faceBottom[140] = 1476;
            faceBottom[50] = 1485;
            faceBottom[200] = 1512;
            faceBottom[10] = 1537;
            faceBottom[20] = 1548;
            faceBottom[30] = 1575;
            faceBottom[150] = 1583;
            faceBottom[160] = 1583;
            faceBottom[80] = 1589;
            faceBottom[90] = 1643;
            faceBottom[100] = 1663;
            faceBottom[190] = 1752;
            faceBottom[120] = 1796;
            faceBottom[220] = 8817;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_KOMOREBI] = mapInfo;
        }

        private static void LoadOrlundaOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[240] = 246;
            faceFront[242] = 389;
            faceFront[244] = 397;
            faceFront[243] = 452;
            faceFront[241] = 491;
            faceFront[10] = 1389;
            faceFront[50] = 1499;
            faceFront[20] = 1503;
            faceFront[40] = 1587;
            faceFront[100] = 1616;
            faceFront[60] = 1671;
            faceFront[30] = 1718;
            faceFront[120] = 1825;
            faceFront[160] = 1844;
            faceFront[70] = 1858;
            faceFront[90] = 1858;
            faceFront[110] = 1892;
            faceFront[80] = 1938;
            faceFront[200] = 1996;
            faceFront[180] = 2003;
            faceFront[130] = 2006;
            faceFront[150] = 2064;
            faceFront[170] = 2076;
            faceFront[22] = 2089;
            faceFront[140] = 2099;
            faceFront[190] = 2214;
            faceFront[82] = 2242;
            faceFront[52] = 2260;
            faceFront[102] = 2327;
            faceFront[32] = 2332;
            faceFront[42] = 2414;
            faceFront[92] = 2457;
            faceFront[12] = 2459;
            faceFront[132] = 2462;
            faceFront[162] = 2473;
            faceFront[62] = 2487;
            faceFront[152] = 2542;
            faceFront[72] = 2566;
            faceFront[122] = 2575;
            faceFront[142] = 2622;
            faceFront[172] = 2622;
            faceFront[112] = 2731;
            faceFront[202] = 2841;
            faceFront[182] = 2891;
            faceFront[192] = 2945;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[240] = 201;
            faceBack[244] = 342;
            faceBack[241] = 440;
            faceBack[242] = 584;
            faceBack[243] = 638;
            faceBack[20] = 1467;
            faceBack[50] = 1596;
            faceBack[10] = 1654;
            faceBack[60] = 1671;
            faceBack[100] = 1712;
            faceBack[90] = 1730;
            faceBack[40] = 1750;
            faceBack[30] = 1860;
            faceBack[70] = 1994;
            faceBack[80] = 1997;
            faceBack[120] = 2002;
            faceBack[22] = 2004;
            faceBack[110] = 2020;
            faceBack[150] = 2021;
            faceBack[160] = 2039;
            faceBack[180] = 2062;
            faceBack[140] = 2072;
            faceBack[130] = 2148;
            faceBack[170] = 2162;
            faceBack[42] = 2178;
            faceBack[200] = 2190;
            faceBack[52] = 2216;
            faceBack[102] = 2235;
            faceBack[32] = 2260;
            faceBack[82] = 2266;
            faceBack[12] = 2295;
            faceBack[122] = 2315;
            faceBack[132] = 2321;
            faceBack[162] = 2339;
            faceBack[72] = 2410;
            faceBack[62] = 2430;
            faceBack[92] = 2465;
            faceBack[112] = 2469;
            faceBack[190] = 2470;
            faceBack[172] = 2536;
            faceBack[152] = 2547;
            faceBack[142] = 2625;
            faceBack[202] = 2734;
            faceBack[192] = 2820;
            faceBack[182] = 2924;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[240] = 179;
            faceLeft[244] = 411;
            faceLeft[241] = 646;
            faceLeft[242] = 660;
            faceLeft[243] = 684;
            faceLeft[20] = 1357;
            faceLeft[50] = 1521;
            faceLeft[10] = 1537;
            faceLeft[60] = 1592;
            faceLeft[30] = 1719;
            faceLeft[180] = 1734;
            faceLeft[140] = 1748;
            faceLeft[40] = 1769;
            faceLeft[100] = 1815;
            faceLeft[160] = 1833;
            faceLeft[120] = 1854;
            faceLeft[80] = 1903;
            faceLeft[130] = 1921;
            faceLeft[150] = 1975;
            faceLeft[110] = 1994;
            faceLeft[70] = 1995;
            faceLeft[90] = 2001;
            faceLeft[170] = 2128;
            faceLeft[200] = 2151;
            faceLeft[102] = 2208;
            faceLeft[82] = 2218;
            faceLeft[42] = 2226;
            faceLeft[190] = 2248;
            faceLeft[92] = 2272;
            faceLeft[32] = 2280;
            faceLeft[52] = 2291;
            faceLeft[22] = 2302;
            faceLeft[72] = 2344;
            faceLeft[12] = 2361;
            faceLeft[62] = 2405;
            faceLeft[132] = 2452;
            faceLeft[162] = 2515;
            faceLeft[122] = 2539;
            faceLeft[112] = 2543;
            faceLeft[172] = 2574;
            faceLeft[152] = 2637;
            faceLeft[202] = 2872;
            faceLeft[142] = 2872;
            faceLeft[192] = 2987;
            faceLeft[182] = 3109;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[240] = 260;
            faceRight[244] = 348;
            faceRight[242] = 548;
            faceRight[243] = 644;
            faceRight[241] = 689;
            faceRight[20] = 1349;
            faceRight[10] = 1490;
            faceRight[50] = 1584;
            faceRight[100] = 1693;
            faceRight[40] = 1699;
            faceRight[90] = 1705;
            faceRight[30] = 1738;
            faceRight[60] = 1743;
            faceRight[160] = 1766;
            faceRight[180] = 1819;
            faceRight[80] = 1833;
            faceRight[120] = 1833;
            faceRight[110] = 1868;
            faceRight[130] = 1899;
            faceRight[140] = 1965;
            faceRight[70] = 2000;
            faceRight[170] = 2050;
            faceRight[150] = 2094;
            faceRight[200] = 2104;
            faceRight[22] = 2112;
            faceRight[52] = 2193;
            faceRight[42] = 2239;
            faceRight[190] = 2251;
            faceRight[62] = 2255;
            faceRight[32] = 2265;
            faceRight[102] = 2289;
            faceRight[72] = 2352;
            faceRight[82] = 2352;
            faceRight[12] = 2391;
            faceRight[132] = 2447;
            faceRight[152] = 2468;
            faceRight[92] = 2477;
            faceRight[122] = 2551;
            faceRight[162] = 2596;
            faceRight[112] = 2656;
            faceRight[172] = 2743;
            faceRight[202] = 2776;
            faceRight[142] = 2792;
            faceRight[192] = 2959;
            faceRight[182] = 3054;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[240] = 496;
            faceTop[244] = 975;
            faceTop[241] = 1218;
            faceTop[242] = 1304;
            faceTop[243] = 1444;
            faceTop[22] = 3448;
            faceTop[52] = 3775;
            faceTop[12] = 3808;
            faceTop[102] = 3812;
            faceTop[42] = 3866;
            faceTop[32] = 3884;
            faceTop[62] = 3955;
            faceTop[82] = 3973;
            faceTop[92] = 4156;
            faceTop[72] = 4164;
            faceTop[162] = 4193;
            faceTop[122] = 4215;
            faceTop[132] = 4315;
            faceTop[112] = 4365;
            faceTop[152] = 4443;
            faceTop[172] = 4487;
            faceTop[142] = 4537;
            faceTop[202] = 4715;
            faceTop[182] = 4722;
            faceTop[192] = 4973;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[152] = 6;
            faceBottom[202] = 9;
            faceBottom[72] = 9;
            faceBottom[132] = 9;
            faceBottom[162] = 9;
            faceBottom[62] = 14;
            faceBottom[112] = 18;
            faceBottom[230] = 328;
            faceBottom[234] = 731;
            faceBottom[231] = 811;
            faceBottom[232] = 901;
            faceBottom[28] = 1235;
            faceBottom[88] = 1247;
            faceBottom[18] = 1267;
            faceBottom[98] = 1303;
            faceBottom[233] = 1323;
            faceBottom[8] = 1386;
            faceBottom[58] = 1429;
            faceBottom[38] = 1466;
            faceBottom[48] = 1471;
            faceBottom[78] = 1491;
            faceBottom[118] = 1513;
            faceBottom[198] = 1541;
            faceBottom[128] = 1598;
            faceBottom[158] = 1632;
            faceBottom[68] = 1665;
            faceBottom[148] = 1690;
            faceBottom[168] = 1696;
            faceBottom[138] = 1698;
            faceBottom[178] = 1708;
            faceBottom[108] = 1724;
            faceBottom[188] = 1857;
            faceBottom[20] = 2228;
            faceBottom[50] = 2354;
            faceBottom[10] = 2384;
            faceBottom[40] = 2402;
            faceBottom[100] = 2536;
            faceBottom[60] = 2562;
            faceBottom[70] = 2591;
            faceBottom[160] = 2662;
            faceBottom[80] = 2675;
            faceBottom[30] = 2722;
            faceBottom[110] = 2746;
            faceBottom[120] = 2807;
            faceBottom[130] = 2807;
            faceBottom[140] = 2858;
            faceBottom[150] = 2896;
            faceBottom[170] = 2928;
            faceBottom[90] = 3006;
            faceBottom[180] = 3103;
            faceBottom[190] = 3244;
            faceBottom[200] = 3409;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_ORLUNDA] = mapInfo;
        }

        private static void LoadTealWMOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[100] = 4081;
            faceFront[160] = 4089;
            faceFront[20] = 4124;
            faceFront[50] = 4306;
            faceFront[80] = 4383;
            faceFront[130] = 4390;
            faceFront[150] = 4417;
            faceFront[120] = 4418;
            faceFront[60] = 4425;
            faceFront[40] = 4433;
            faceFront[170] = 4465;
            faceFront[200] = 4482;
            faceFront[110] = 4541;
            faceFront[140] = 4553;
            faceFront[90] = 4554;
            faceFront[180] = 4555;
            faceFront[30] = 4628;
            faceFront[10] = 4635;
            faceFront[70] = 4685;
            faceFront[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[100] = 4081;
            faceBack[160] = 4089;
            faceBack[20] = 4124;
            faceBack[50] = 4306;
            faceBack[80] = 4383;
            faceBack[130] = 4390;
            faceBack[150] = 4417;
            faceBack[120] = 4418;
            faceBack[60] = 4425;
            faceBack[40] = 4433;
            faceBack[170] = 4465;
            faceBack[200] = 4482;
            faceBack[110] = 4541;
            faceBack[140] = 4553;
            faceBack[90] = 4554;
            faceBack[180] = 4555;
            faceBack[30] = 4628;
            faceBack[10] = 4635;
            faceBack[70] = 4685;
            faceBack[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[100] = 4081;
            faceLeft[160] = 4089;
            faceLeft[20] = 4124;
            faceLeft[50] = 4306;
            faceLeft[80] = 4383;
            faceLeft[130] = 4390;
            faceLeft[150] = 4417;
            faceLeft[120] = 4418;
            faceLeft[60] = 4425;
            faceLeft[40] = 4433;
            faceLeft[170] = 4465;
            faceLeft[200] = 4482;
            faceLeft[110] = 4541;
            faceLeft[140] = 4553;
            faceLeft[90] = 4554;
            faceLeft[180] = 4555;
            faceLeft[30] = 4628;
            faceLeft[10] = 4635;
            faceLeft[70] = 4685;
            faceLeft[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[100] = 4081;
            faceRight[160] = 4089;
            faceRight[20] = 4124;
            faceRight[50] = 4306;
            faceRight[80] = 4383;
            faceRight[130] = 4390;
            faceRight[150] = 4417;
            faceRight[120] = 4418;
            faceRight[60] = 4425;
            faceRight[40] = 4433;
            faceRight[170] = 4465;
            faceRight[200] = 4482;
            faceRight[110] = 4541;
            faceRight[140] = 4553;
            faceRight[90] = 4554;
            faceRight[180] = 4555;
            faceRight[30] = 4628;
            faceRight[10] = 4635;
            faceRight[70] = 4685;
            faceRight[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[100] = 4081;
            faceTop[160] = 4089;
            faceTop[20] = 4124;
            faceTop[50] = 4306;
            faceTop[80] = 4383;
            faceTop[130] = 4390;
            faceTop[150] = 4417;
            faceTop[120] = 4418;
            faceTop[60] = 4425;
            faceTop[40] = 4433;
            faceTop[170] = 4465;
            faceTop[200] = 4482;
            faceTop[110] = 4541;
            faceTop[140] = 4553;
            faceTop[90] = 4554;
            faceTop[180] = 4555;
            faceTop[30] = 4628;
            faceTop[10] = 4635;
            faceTop[70] = 4685;
            faceTop[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[100] = 4081;
            faceBottom[160] = 4089;
            faceBottom[20] = 4124;
            faceBottom[50] = 4306;
            faceBottom[80] = 4383;
            faceBottom[130] = 4390;
            faceBottom[150] = 4417;
            faceBottom[120] = 4418;
            faceBottom[60] = 4425;
            faceBottom[40] = 4433;
            faceBottom[170] = 4465;
            faceBottom[200] = 4482;
            faceBottom[110] = 4541;
            faceBottom[140] = 4553;
            faceBottom[90] = 4554;
            faceBottom[180] = 4555;
            faceBottom[30] = 4628;
            faceBottom[10] = 4635;
            faceBottom[70] = 4685;
            faceBottom[190] = 4789;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TEALWM] = mapInfo;
        }

        private static void LoadTealOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[140] = 3813;
            faceFront[20] = 3839;
            faceFront[90] = 4109;
            faceFront[160] = 4279;
            faceFront[60] = 4304;
            faceFront[10] = 4357;
            faceFront[150] = 4476;
            faceFront[30] = 4514;
            faceFront[70] = 4650;
            faceFront[130] = 4795;
            faceFront[100] = 4814;
            faceFront[50] = 4972;
            faceFront[180] = 5072;
            faceFront[40] = 5103;
            faceFront[170] = 5321;
            faceFront[200] = 5325;
            faceFront[80] = 5337;
            faceFront[120] = 5397;
            faceFront[190] = 5579;
            faceFront[110] = 6074;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[140] = 2963;
            faceBack[120] = 3244;
            faceBack[100] = 3266;
            faceBack[90] = 3267;
            faceBack[170] = 3468;
            faceBack[180] = 3683;
            faceBack[60] = 3687;
            faceBack[50] = 3696;
            faceBack[70] = 3761;
            faceBack[30] = 3894;
            faceBack[10] = 4030;
            faceBack[20] = 4264;
            faceBack[150] = 4305;
            faceBack[200] = 4477;
            faceBack[80] = 4696;
            faceBack[130] = 4739;
            faceBack[160] = 4771;
            faceBack[190] = 4792;
            faceBack[40] = 5240;
            faceBack[110] = 5371;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[140] = 2526;
            faceLeft[170] = 2956;
            faceLeft[160] = 3453;
            faceLeft[60] = 3697;
            faceLeft[30] = 3761;
            faceLeft[20] = 3812;
            faceLeft[70] = 3879;
            faceLeft[150] = 3922;
            faceLeft[180] = 3988;
            faceLeft[100] = 4053;
            faceLeft[130] = 4104;
            faceLeft[40] = 4111;
            faceLeft[10] = 4142;
            faceLeft[50] = 4151;
            faceLeft[90] = 4244;
            faceLeft[120] = 4321;
            faceLeft[200] = 4364;
            faceLeft[190] = 4366;
            faceLeft[110] = 4720;
            faceLeft[80] = 5154;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[60] = 3644;
            faceRight[30] = 3721;
            faceRight[200] = 3773;
            faceRight[150] = 3969;
            faceRight[140] = 3995;
            faceRight[120] = 4012;
            faceRight[20] = 4040;
            faceRight[170] = 4175;
            faceRight[70] = 4437;
            faceRight[190] = 4451;
            faceRight[130] = 4467;
            faceRight[90] = 4611;
            faceRight[50] = 4667;
            faceRight[160] = 4784;
            faceRight[40] = 4875;
            faceRight[100] = 4899;
            faceRight[110] = 4999;
            faceRight[180] = 5174;
            faceRight[80] = 5465;
            faceRight[10] = 5570;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[120] = 3342;
            faceTop[160] = 3730;
            faceTop[140] = 3850;
            faceTop[70] = 3969;
            faceTop[10] = 3984;
            faceTop[60] = 4083;
            faceTop[30] = 4109;
            faceTop[180] = 4147;
            faceTop[50] = 4147;
            faceTop[200] = 4178;
            faceTop[90] = 4200;
            faceTop[100] = 4468;
            faceTop[80] = 4470;
            faceTop[20] = 4501;
            faceTop[170] = 4653;
            faceTop[40] = 4771;
            faceTop[150] = 4875;
            faceTop[130] = 5140;
            faceTop[110] = 5314;
            faceTop[190] = 5982;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[140] = 5571;
            faceBottom[90] = 5715;
            faceBottom[70] = 6105;
            faceBottom[150] = 6171;
            faceBottom[30] = 6222;
            faceBottom[180] = 6244;
            faceBottom[60] = 6302;
            faceBottom[160] = 6340;
            faceBottom[190] = 6438;
            faceBottom[200] = 6481;
            faceBottom[170] = 6542;
            faceBottom[20] = 6591;
            faceBottom[50] = 6602;
            faceBottom[100] = 6744;
            faceBottom[80] = 6813;
            faceBottom[10] = 6894;
            faceBottom[40] = 7147;
            faceBottom[120] = 7217;
            faceBottom[130] = 7228;
            faceBottom[110] = 7826;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TEAL] = mapInfo;
        }

        private static void LoadTohilOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[40] = 3718;
            faceFront[100] = 3775;
            faceFront[170] = 3962;
            faceFront[120] = 3988;
            faceFront[180] = 3998;
            faceFront[80] = 4001;
            faceFront[20] = 4150;
            faceFront[160] = 4620;
            faceFront[30] = 4880;
            faceFront[10] = 5017;
            faceFront[90] = 5140;
            faceFront[140] = 5233;
            faceFront[200] = 5331;
            faceFront[110] = 5490;
            faceFront[70] = 5517;
            faceFront[130] = 5668;
            faceFront[190] = 5877;
            faceFront[150] = 5929;
            faceFront[60] = 5995;
            faceFront[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[40] = 3718;
            faceBack[100] = 3775;
            faceBack[170] = 3962;
            faceBack[120] = 3988;
            faceBack[180] = 3998;
            faceBack[80] = 4001;
            faceBack[20] = 4150;
            faceBack[160] = 4620;
            faceBack[30] = 4880;
            faceBack[10] = 5017;
            faceBack[90] = 5140;
            faceBack[140] = 5233;
            faceBack[200] = 5331;
            faceBack[110] = 5490;
            faceBack[70] = 5517;
            faceBack[130] = 5668;
            faceBack[190] = 5877;
            faceBack[150] = 5929;
            faceBack[60] = 5995;
            faceBack[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[40] = 3718;
            faceLeft[100] = 3775;
            faceLeft[170] = 3962;
            faceLeft[120] = 3988;
            faceLeft[180] = 3998;
            faceLeft[80] = 4001;
            faceLeft[20] = 4150;
            faceLeft[160] = 4620;
            faceLeft[30] = 4880;
            faceLeft[10] = 5017;
            faceLeft[90] = 5140;
            faceLeft[140] = 5233;
            faceLeft[200] = 5331;
            faceLeft[110] = 5490;
            faceLeft[70] = 5517;
            faceLeft[130] = 5668;
            faceLeft[190] = 5877;
            faceLeft[150] = 5929;
            faceLeft[60] = 5995;
            faceLeft[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[40] = 3718;
            faceRight[100] = 3775;
            faceRight[170] = 3962;
            faceRight[120] = 3988;
            faceRight[180] = 3998;
            faceRight[80] = 4001;
            faceRight[20] = 4150;
            faceRight[160] = 4620;
            faceRight[30] = 4880;
            faceRight[10] = 5017;
            faceRight[90] = 5140;
            faceRight[140] = 5233;
            faceRight[200] = 5331;
            faceRight[110] = 5490;
            faceRight[70] = 5517;
            faceRight[130] = 5668;
            faceRight[190] = 5877;
            faceRight[150] = 5929;
            faceRight[60] = 5995;
            faceRight[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[40] = 3718;
            faceTop[100] = 3775;
            faceTop[170] = 3962;
            faceTop[120] = 3988;
            faceTop[180] = 3998;
            faceTop[80] = 4001;
            faceTop[20] = 4150;
            faceTop[160] = 4620;
            faceTop[30] = 4880;
            faceTop[10] = 5017;
            faceTop[90] = 5140;
            faceTop[140] = 5233;
            faceTop[200] = 5331;
            faceTop[110] = 5490;
            faceTop[70] = 5517;
            faceTop[130] = 5668;
            faceTop[190] = 5877;
            faceTop[150] = 5929;
            faceTop[60] = 5995;
            faceTop[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[40] = 3718;
            faceBottom[100] = 3775;
            faceBottom[170] = 3962;
            faceBottom[120] = 3988;
            faceBottom[180] = 3998;
            faceBottom[80] = 4001;
            faceBottom[20] = 4150;
            faceBottom[160] = 4620;
            faceBottom[30] = 4880;
            faceBottom[10] = 5017;
            faceBottom[90] = 5140;
            faceBottom[140] = 5233;
            faceBottom[200] = 5331;
            faceBottom[110] = 5490;
            faceBottom[70] = 5517;
            faceBottom[130] = 5668;
            faceBottom[190] = 5877;
            faceBottom[150] = 5929;
            faceBottom[60] = 5995;
            faceBottom[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TOHIL] = mapInfo;
        }

        private static void LoadQunOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[40] = 3718;
            faceFront[100] = 3775;
            faceFront[170] = 3962;
            faceFront[120] = 3988;
            faceFront[180] = 3998;
            faceFront[80] = 4001;
            faceFront[20] = 4150;
            faceFront[160] = 4620;
            faceFront[30] = 4880;
            faceFront[10] = 5017;
            faceFront[90] = 5140;
            faceFront[140] = 5233;
            faceFront[200] = 5331;
            faceFront[110] = 5490;
            faceFront[70] = 5517;
            faceFront[130] = 5668;
            faceFront[190] = 5877;
            faceFront[60] = 5995;
            faceFront[50] = 6157;
            faceFront[150] = 6241;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[40] = 3718;
            faceBack[100] = 3775;
            faceBack[170] = 3962;
            faceBack[120] = 3988;
            faceBack[180] = 3998;
            faceBack[80] = 4001;
            faceBack[20] = 4150;
            faceBack[160] = 4620;
            faceBack[30] = 4880;
            faceBack[10] = 5017;
            faceBack[90] = 5140;
            faceBack[140] = 5233;
            faceBack[200] = 5331;
            faceBack[110] = 5490;
            faceBack[70] = 5517;
            faceBack[130] = 5668;
            faceBack[190] = 5877;
            faceBack[150] = 5929;
            faceBack[60] = 5995;
            faceBack[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[40] = 3718;
            faceLeft[100] = 3775;
            faceLeft[170] = 3962;
            faceLeft[120] = 3988;
            faceLeft[180] = 3998;
            faceLeft[80] = 4001;
            faceLeft[20] = 4150;
            faceLeft[160] = 4620;
            faceLeft[30] = 4880;
            faceLeft[10] = 5017;
            faceLeft[90] = 5140;
            faceLeft[140] = 5233;
            faceLeft[200] = 5331;
            faceLeft[110] = 5490;
            faceLeft[70] = 5517;
            faceLeft[130] = 5668;
            faceLeft[190] = 5877;
            faceLeft[150] = 5929;
            faceLeft[60] = 5995;
            faceLeft[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[40] = 3718;
            faceRight[100] = 3775;
            faceRight[170] = 3962;
            faceRight[120] = 3988;
            faceRight[180] = 3998;
            faceRight[80] = 4001;
            faceRight[20] = 4150;
            faceRight[160] = 4620;
            faceRight[30] = 4880;
            faceRight[10] = 5017;
            faceRight[90] = 5140;
            faceRight[140] = 5233;
            faceRight[200] = 5331;
            faceRight[110] = 5490;
            faceRight[70] = 5517;
            faceRight[130] = 5668;
            faceRight[190] = 5877;
            faceRight[60] = 5995;
            faceRight[50] = 6157;
            faceRight[150] = 6241;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[40] = 3718;
            faceTop[100] = 3775;
            faceTop[170] = 3962;
            faceTop[120] = 3988;
            faceTop[180] = 3998;
            faceTop[80] = 4001;
            faceTop[20] = 4150;
            faceTop[160] = 4620;
            faceTop[30] = 4880;
            faceTop[10] = 5017;
            faceTop[90] = 5140;
            faceTop[140] = 5233;
            faceTop[200] = 5331;
            faceTop[110] = 5490;
            faceTop[70] = 5517;
            faceTop[130] = 5668;
            faceTop[190] = 5877;
            faceTop[60] = 5995;
            faceTop[50] = 6157;
            faceTop[150] = 6241;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[40] = 3718;
            faceBottom[100] = 3775;
            faceBottom[170] = 3962;
            faceBottom[120] = 3988;
            faceBottom[180] = 3998;
            faceBottom[80] = 4001;
            faceBottom[20] = 4150;
            faceBottom[160] = 4620;
            faceBottom[30] = 4880;
            faceBottom[10] = 5017;
            faceBottom[90] = 5140;
            faceBottom[140] = 5233;
            faceBottom[200] = 5331;
            faceBottom[110] = 5490;
            faceBottom[70] = 5517;
            faceBottom[130] = 5668;
            faceBottom[190] = 5877;
            faceBottom[150] = 5929;
            faceBottom[60] = 5995;
            faceBottom[50] = 6157;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_QUN] = mapInfo;
        }

        private static void LoaKimiOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[185] = 7767;
            faceFront[60] = 9474;
            faceFront[150] = 10452;
            faceFront[180] = 10452;
            faceFront[30] = 11958;
            faceFront[35] = 12809;
            faceFront[120] = 13482;
            faceFront[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[185] = 7767;
            faceBack[60] = 9474;
            faceBack[150] = 10452;
            faceBack[180] = 10452;
            faceBack[30] = 11958;
            faceBack[35] = 12809;
            faceBack[120] = 13482;
            faceBack[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[185] = 7767;
            faceLeft[60] = 9474;
            faceLeft[150] = 10452;
            faceLeft[180] = 10452;
            faceLeft[30] = 11958;
            faceLeft[35] = 12809;
            faceLeft[120] = 13482;
            faceLeft[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[185] = 7767;
            faceRight[60] = 9474;
            faceRight[150] = 10452;
            faceRight[180] = 10452;
            faceRight[30] = 11958;
            faceRight[35] = 12809;
            faceRight[120] = 13482;
            faceRight[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[185] = 7767;
            faceTop[60] = 9474;
            faceTop[150] = 10452;
            faceTop[180] = 10452;
            faceTop[30] = 11958;
            faceTop[35] = 12809;
            faceTop[120] = 13482;
            faceTop[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[185] = 7767;
            faceBottom[60] = 9474;
            faceBottom[150] = 10452;
            faceBottom[180] = 10452;
            faceBottom[30] = 11958;
            faceBottom[35] = 12809;
            faceBottom[120] = 13482;
            faceBottom[90] = 14203;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_KIMI] = mapInfo;
        }

        private static void LoadSatreusOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[111] = 5;
            faceFront[183] = 5;
            faceFront[103] = 6;
            faceFront[25] = 715;
            faceFront[135] = 716;
            faceFront[185] = 757;
            faceFront[45] = 773;
            faceFront[115] = 774;
            faceFront[85] = 798;
            faceFront[105] = 798;
            faceFront[155] = 811;
            faceFront[125] = 819;
            faceFront[55] = 827;
            faceFront[175] = 851;
            faceFront[35] = 913;
            faceFront[75] = 930;
            faceFront[15] = 982;
            faceFront[195] = 1023;
            faceFront[65] = 1031;
            faceFront[145] = 1058;
            faceFront[95] = 1063;
            faceFront[165] = 1076;
            faceFront[205] = 1134;
            faceFront[60] = 3357;
            faceFront[10] = 3537;
            faceFront[50] = 3598;
            faceFront[30] = 3628;
            faceFront[110] = 3695;
            faceFront[130] = 3793;
            faceFront[140] = 3837;
            faceFront[80] = 3850;
            faceFront[170] = 3870;
            faceFront[20] = 3902;
            faceFront[40] = 3906;
            faceFront[200] = 3926;
            faceFront[160] = 3951;
            faceFront[180] = 4050;
            faceFront[150] = 4158;
            faceFront[190] = 4209;
            faceFront[70] = 4212;
            faceFront[100] = 4510;
            faceFront[90] = 4559;
            faceFront[120] = 4644;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[85] = 543;
            faceBack[75] = 698;
            faceBack[175] = 744;
            faceBack[185] = 760;
            faceBack[115] = 800;
            faceBack[105] = 804;
            faceBack[25] = 812;
            faceBack[125] = 821;
            faceBack[135] = 838;
            faceBack[195] = 843;
            faceBack[45] = 859;
            faceBack[95] = 934;
            faceBack[55] = 943;
            faceBack[155] = 943;
            faceBack[35] = 958;
            faceBack[165] = 983;
            faceBack[65] = 985;
            faceBack[15] = 1012;
            faceBack[145] = 1065;
            faceBack[205] = 1101;
            faceBack[60] = 3403;
            faceBack[50] = 3482;
            faceBack[10] = 3499;
            faceBack[30] = 3582;
            faceBack[130] = 3666;
            faceBack[110] = 3674;
            faceBack[20] = 3808;
            faceBack[40] = 3813;
            faceBack[140] = 3833;
            faceBack[200] = 3960;
            faceBack[170] = 3973;
            faceBack[150] = 4035;
            faceBack[160] = 4043;
            faceBack[180] = 4048;
            faceBack[80] = 4107;
            faceBack[190] = 4383;
            faceBack[70] = 4446;
            faceBack[100] = 4516;
            faceBack[120] = 4642;
            faceBack[90] = 4682;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[134] = 5;
            faceLeft[192] = 5;
            faceLeft[25] = 652;
            faceLeft[85] = 663;
            faceLeft[195] = 672;
            faceLeft[105] = 708;
            faceLeft[45] = 729;
            faceLeft[15] = 736;
            faceLeft[135] = 736;
            faceLeft[175] = 738;
            faceLeft[115] = 770;
            faceLeft[55] = 775;
            faceLeft[35] = 790;
            faceLeft[185] = 802;
            faceLeft[75] = 806;
            faceLeft[155] = 828;
            faceLeft[125] = 860;
            faceLeft[145] = 891;
            faceLeft[165] = 945;
            faceLeft[205] = 1025;
            faceLeft[65] = 1049;
            faceLeft[95] = 1070;
            faceLeft[60] = 3334;
            faceLeft[50] = 3650;
            faceLeft[110] = 3711;
            faceLeft[30] = 3751;
            faceLeft[130] = 3769;
            faceLeft[10] = 3783;
            faceLeft[40] = 3948;
            faceLeft[20] = 3968;
            faceLeft[80] = 3983;
            faceLeft[170] = 3983;
            faceLeft[140] = 4003;
            faceLeft[180] = 4010;
            faceLeft[200] = 4039;
            faceLeft[160] = 4080;
            faceLeft[150] = 4146;
            faceLeft[70] = 4338;
            faceLeft[90] = 4550;
            faceLeft[190] = 4555;
            faceLeft[120] = 4603;
            faceLeft[100] = 4607;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[63] = 5;
            faceRight[133] = 5;
            faceRight[33] = 10;
            faceRight[85] = 366;
            faceRight[135] = 513;
            faceRight[45] = 536;
            faceRight[105] = 549;
            faceRight[25] = 572;
            faceRight[175] = 617;
            faceRight[15] = 636;
            faceRight[115] = 656;
            faceRight[185] = 679;
            faceRight[65] = 688;
            faceRight[165] = 697;
            faceRight[195] = 703;
            faceRight[35] = 728;
            faceRight[75] = 747;
            faceRight[155] = 747;
            faceRight[55] = 751;
            faceRight[125] = 764;
            faceRight[95] = 797;
            faceRight[145] = 860;
            faceRight[205] = 897;
            faceRight[50] = 3674;
            faceRight[60] = 3692;
            faceRight[30] = 3798;
            faceRight[110] = 3825;
            faceRight[10] = 3873;
            faceRight[130] = 3991;
            faceRight[140] = 4038;
            faceRight[20] = 4048;
            faceRight[170] = 4100;
            faceRight[180] = 4132;
            faceRight[40] = 4139;
            faceRight[200] = 4162;
            faceRight[150] = 4224;
            faceRight[80] = 4282;
            faceRight[160] = 4330;
            faceRight[70] = 4395;
            faceRight[190] = 4525;
            faceRight[120] = 4698;
            faceRight[100] = 4769;
            faceRight[90] = 4821;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[60] = 4388;
            faceTop[50] = 4425;
            faceTop[110] = 4481;
            faceTop[130] = 4514;
            faceTop[10] = 4519;
            faceTop[30] = 4541;
            faceTop[20] = 4620;
            faceTop[80] = 4653;
            faceTop[40] = 4679;
            faceTop[170] = 4721;
            faceTop[180] = 4812;
            faceTop[140] = 4898;
            faceTop[150] = 4978;
            faceTop[160] = 5027;
            faceTop[200] = 5064;
            faceTop[70] = 5144;
            faceTop[190] = 5232;
            faceTop[100] = 5320;
            faceTop[120] = 5463;
            faceTop[90] = 5622;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[60] = 4388;
            faceBottom[50] = 4425;
            faceBottom[110] = 4481;
            faceBottom[130] = 4514;
            faceBottom[10] = 4519;
            faceBottom[30] = 4541;
            faceBottom[20] = 4620;
            faceBottom[80] = 4653;
            faceBottom[40] = 4679;
            faceBottom[170] = 4721;
            faceBottom[180] = 4812;
            faceBottom[140] = 4898;
            faceBottom[150] = 4978;
            faceBottom[160] = 5027;
            faceBottom[200] = 5064;
            faceBottom[70] = 5144;
            faceBottom[190] = 5232;
            faceBottom[100] = 5320;
            faceBottom[120] = 5463;
            faceBottom[90] = 5622;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_SATREUS] = mapInfo;
        }

        private static void LoadTrelanOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[230] = 2703;
            faceFront[60] = 3005;
            faceFront[220] = 3496;
            faceFront[50] = 3507;
            faceFront[120] = 3664;
            faceFront[70] = 3716;
            faceFront[140] = 3722;
            faceFront[30] = 3758;
            faceFront[130] = 3767;
            faceFront[190] = 3950;
            faceFront[40] = 4008;
            faceFront[100] = 4241;
            faceFront[90] = 4255;
            faceFront[80] = 4264;
            faceFront[170] = 4373;
            faceFront[150] = 4377;
            faceFront[110] = 4397;
            faceFront[200] = 4401;
            faceFront[20] = 4638;
            faceFront[10] = 4864;
            faceFront[160] = 4925;
            faceFront[180] = 5059;
            faceFront[210] = 13660;
            faceFront[250] = 566990;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[230] = 2492;
            faceBack[50] = 3015;
            faceBack[60] = 3126;
            faceBack[220] = 3213;
            faceBack[30] = 3433;
            faceBack[120] = 3447;
            faceBack[70] = 3558;
            faceBack[190] = 3625;
            faceBack[130] = 3641;
            faceBack[140] = 3802;
            faceBack[40] = 3846;
            faceBack[100] = 3916;
            faceBack[150] = 4009;
            faceBack[110] = 4167;
            faceBack[80] = 4246;
            faceBack[200] = 4369;
            faceBack[170] = 4373;
            faceBack[10] = 4444;
            faceBack[20] = 4641;
            faceBack[90] = 4703;
            faceBack[160] = 4836;
            faceBack[180] = 5018;
            faceBack[210] = 12670;
            faceBack[250] = 577976;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[230] = 1424;
            faceLeft[220] = 1836;
            faceLeft[60] = 3152;
            faceLeft[50] = 3358;
            faceLeft[120] = 3494;
            faceLeft[190] = 3632;
            faceLeft[30] = 3758;
            faceLeft[130] = 3767;
            faceLeft[70] = 3849;
            faceLeft[140] = 3868;
            faceLeft[40] = 4008;
            faceLeft[170] = 4039;
            faceLeft[100] = 4240;
            faceLeft[80] = 4264;
            faceLeft[90] = 4393;
            faceLeft[110] = 4397;
            faceLeft[150] = 4580;
            faceLeft[200] = 4621;
            faceLeft[20] = 4794;
            faceLeft[10] = 4864;
            faceLeft[180] = 4880;
            faceLeft[160] = 5047;
            faceLeft[210] = 7240;
            faceLeft[250] = 642381;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[230] = 2136;
            faceRight[220] = 2754;
            faceRight[50] = 3335;
            faceRight[60] = 3336;
            faceRight[120] = 3501;
            faceRight[30] = 3583;
            faceRight[130] = 3616;
            faceRight[140] = 3691;
            faceRight[70] = 3849;
            faceRight[40] = 3853;
            faceRight[190] = 3856;
            faceRight[110] = 4150;
            faceRight[80] = 4203;
            faceRight[170] = 4237;
            faceRight[100] = 4268;
            faceRight[150] = 4580;
            faceRight[20] = 4589;
            faceRight[200] = 4621;
            faceRight[10] = 4636;
            faceRight[160] = 4637;
            faceRight[90] = 4819;
            faceRight[180] = 4914;
            faceRight[210] = 10860;
            faceRight[250] = 597408;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[60] = 3212;
            faceTop[230] = 3347;
            faceTop[30] = 3351;
            faceTop[50] = 3400;
            faceTop[190] = 3616;
            faceTop[40] = 3617;
            faceTop[120] = 3664;
            faceTop[70] = 3696;
            faceTop[140] = 3731;
            faceTop[130] = 3767;
            faceTop[90] = 3932;
            faceTop[100] = 4033;
            faceTop[170] = 4107;
            faceTop[150] = 4135;
            faceTop[160] = 4154;
            faceTop[80] = 4285;
            faceTop[220] = 4307;
            faceTop[200] = 4309;
            faceTop[110] = 4397;
            faceTop[20] = 4511;
            faceTop[10] = 4544;
            faceTop[180] = 4734;
            faceTop[210] = 17181;
            faceTop[250] = 553775;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[230] = 2136;
            faceBottom[220] = 2754;
            faceBottom[60] = 3000;
            faceBottom[120] = 3354;
            faceBottom[50] = 3389;
            faceBottom[140] = 3470;
            faceBottom[130] = 3604;
            faceBottom[30] = 3652;
            faceBottom[40] = 3802;
            faceBottom[190] = 3835;
            faceBottom[70] = 3849;
            faceBottom[100] = 4115;
            faceBottom[170] = 4219;
            faceBottom[80] = 4391;
            faceBottom[150] = 4394;
            faceBottom[110] = 4397;
            faceBottom[200] = 4477;
            faceBottom[90] = 4489;
            faceBottom[10] = 4536;
            faceBottom[180] = 4612;
            faceBottom[20] = 4863;
            faceBottom[160] = 4900;
            faceBottom[210] = 10860;
            faceBottom[250] = 621481;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TRELAN] = mapInfo;
        }

        public static readonly PlanetProfile TRELAN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = TRELAN_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(15, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_TOTHT,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 1f, 80, 1.2f, 0.05f, 0.0f),
            Gravity = PlanetMapProfile.GetGravity(0.92f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 8, 53),
            Water = PlanetMapProfile.GetWater(true, 1.015f, -0.6f, 0, 0),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.ALIEN_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Grass_Trelan", "Grass_Trelan_bare", "Soil_Trelan"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Mossy_Rock_2_Trelan", "AlienRockGrass", "AlienRockGrass bare"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "DustyRocks2", "DustyRocks3", "AlienRockyMountain", "Mossy_Rock_2_Trelan")
            )
        };

        public static readonly PlanetProfile SATREUS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = SATREUS_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(15, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_TOTHT,
            Geothermal = PlanetMapProfile.GetGeothermal(true, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.2f, 0.9f, 95, 1.5f, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(0.95f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 10, 65),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 65),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Ground_red_Satreus", "Soil", "AlienRockGrass", "Grass_old", "AlienRockGrass_Satreus"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Desert_01_red_Satreus", "Desert_01_Satreus", "Desert_01_Satreus_soil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone", "DustyRocks3_Satreus", "AlienRockyMountain", ""),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AlienSnow", "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "IceEuropa2", "Ice02_Satreus")
            )
        };

        public static readonly PlanetProfile KIMI = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = KIMI_QUN_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.05f, 7f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(5, 10),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "MoonRock_grey2_kimi", "MoonRock_black2_kimi", "MoonRock_green2_kimi", "Low_Dens_Iron_Kimi")
            )
        };

        public static readonly PlanetProfile QUN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = KIMI_QUN_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#FFFFFF",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.42f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 25),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "MoonSoil_grey_qun", "MoonRock_grey_qun", "MoonSoil_red2_qun", "MoonSoil_black2_qun", "MoonRock_black2_qun", "MoonSoil_grey2_qun", "MoonRock_grey2_qun")
            )
        };

        public static readonly PlanetProfile LUMA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = LUMA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1.5f, 0.05f, 250, 1.2f, 0.5f, 0.75f),
            Gravity = PlanetMapProfile.GetGravity(1.86f, 4.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(950, 1050),
            Type = PlanetProfile.PlanetType.GiantGas,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes()
        };

        public static readonly PlanetProfile TOHIL = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = TOHIL_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 2, rowSizeMultiplier: 2, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.5f, 0.1f, 8, 1.0f, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(0.328f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(15, 25),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "IceEuropa2", "TohilIce03", "TohilIce02", "TohilSnow01", "TohilSnow02")
            )
        };

        public static readonly PlanetProfile TEAL = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = TEAL_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.0f, 1.0f, 120, 2.0f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1f, 7f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0038f, -0.4f, 0, 0),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "TealBlueGrass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "TealRocksGrass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "TealShore1", "TealShore2", "TealShore3", "TealShore4", "TealShore5", "TealBlack_Soil"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Snow", "TealSnowGrass", "AlienSnow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone", "TealGravel"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "TealIce", "TealSea", "TealRiver")
            )
        };

        public static readonly PlanetProfile ORLUNDA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ORLUNDA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(15, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_TOTHT,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.89f, 0.25f, 80, 6.0f, 0.25f, 0f),
            Gravity = PlanetMapProfile.GetGravity(1.12f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 10, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "TealBlueGrass", "TealRocksGrass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "TealBlack_Soil", "TealShore1", "TealShore2", "TealShore3", "TealShore4", "TealShore5", "TealShore6"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AlienSnow", "TealSnowGrass", "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone", "TealGravel", "Stone_01"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "TealSea", "TealRiver", "TealIce")
            )
        };

        public static readonly PlanetProfile KOMOREBI = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = KOMOREBI_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.0f, 1.0f, 80, 2.4f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1.14f, 7f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0038f, -0.4f, 0, 0),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Mold_11_alt", "Mold_11", "Mold_01", "Fungi_17", "Fungi_16", "Fungi_11", "Fungi_02", "Fungi_01_alt", "Fungi_01", "MossCarpet3", "MossCarpet2", "MossCarpet0", "Green_07", "Green_06", "Green_05", "Green_04", "Green_02_bare", "Green_02_var", "Green_02", "Grass_var"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Desert_Rocks_01", "Desert_Rocks_02", "Desert_Soil_01", "Desert_Soil_03", "Desert_Dunes_01", "Desert_Dunes_02", "Salt_Flats_01", "Salt_Flats_03"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Volcanic, "VolcanoRock"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "AcidLake_01", "AcidLake_02", "AcidLake_03", "AcidLake_04")
            )
        };

    }

}
