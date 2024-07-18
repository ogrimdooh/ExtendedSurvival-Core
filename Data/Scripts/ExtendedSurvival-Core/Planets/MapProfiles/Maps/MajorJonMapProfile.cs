using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class MajorJonMapProfile
    {

        public const ulong TRELAN_MODID = 2636128625;
        public const ulong SATREUS_MODID = 2266665708;

        public const string DEFAULT_TRELAN = "TRELAN";
        public const string DEFAULT_SATREUS = "SATREUS";

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

        static MajorJonMapProfile()
        {
            LoadTrelanOreMapInfo();
            LoadSatreusOreMapInfo();
            TRELAN.Ores = VanilaMapProfile.EARTHLIKE_ORES;
            SATREUS.Ores = VanilaMapProfile.PERTAM_ORES;
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
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 1f, 80, 1.2f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.92f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 8, 53),
            Water = PlanetMapProfile.GetWater(true, 1.015f, -0.6f, 0, 0),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = VanilaMapProfile.EARTHLIKE_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile SATREUS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = SATREUS_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            TargetColor = "#616c83",
            ColorInfluence = new Vector2I(15, 15),
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.2f, 0.9f, 95, 1.5f, 0.05f, 0),
            Gravity = PlanetMapProfile.GetGravity(0.95f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 10, 65),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 65),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.LargeGroup,
            MeteorImpact = VanilaMapProfile.PERTAN_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
