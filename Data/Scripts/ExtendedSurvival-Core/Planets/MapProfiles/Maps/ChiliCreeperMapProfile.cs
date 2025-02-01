using System.Collections.Concurrent;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ChiliCreeperMapProfile
    {

        public const ulong TAKAMA_MODID = 3265497551;

        public const string DEFAULT_TAKAMA = "TAKAMA";

        public const string BrokenBalcor = "BrokenBalcor";
        public const string Balcor = "Balcor";
        public const string DamagedBalcor = "DamagedBalcor";
        public const string Magma = "Magma";
        public const string Crystal = "Crystal";
        public const string Veil = "Veil";
        public const string Fabric = "Fabric";
        public const string BalcorGlass = "BalcorGlass";

        static ChiliCreeperMapProfile()
        {
            LoadTakamaOreMapInfo();
            TAKAMA.Ores = VanilaMapProfile.PERTAM_ORES;
        }

        private static void LoadTakamaOreMapInfo()
        {

            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[51] = 227;
            faceFront[119] = 235;
            faceFront[170] = 239;
            faceFront[204] = 246;
            faceFront[136] = 251;
            faceFront[34] = 252;
            faceFront[85] = 257;
            faceFront[17] = 259;
            faceFront[221] = 260;
            faceFront[238] = 260;
            faceFront[153] = 262;
            faceFront[102] = 264;
            faceFront[68] = 332;
            faceFront[187] = 355;
            faceFront[1] = 41129;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[15] = 5;
            faceBack[23] = 5;
            faceBack[24] = 5;
            faceBack[12] = 6;
            faceBack[18] = 6;
            faceBack[22] = 6;
            faceBack[16] = 9;
            faceBack[9] = 10;
            faceBack[28] = 10;
            faceBack[10] = 14;
            faceBack[8] = 19;
            faceBack[3] = 169;
            faceBack[51] = 235;
            faceBack[119] = 240;
            faceBack[170] = 240;
            faceBack[204] = 244;
            faceBack[136] = 250;
            faceBack[34] = 256;
            faceBack[221] = 265;
            faceBack[102] = 266;
            faceBack[85] = 267;
            faceBack[238] = 269;
            faceBack[153] = 272;
            faceBack[17] = 273;
            faceBack[68] = 343;
            faceBack[187] = 366;
            faceBack[6] = 1937;
            faceBack[1] = 4549;
            faceBack[5] = 5290;
            faceBack[4] = 5573;
            faceBack[2] = 5597;
            faceBack[7] = 72733;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[8] = 5;
            faceLeft[14] = 5;
            faceLeft[21] = 5;
            faceLeft[10] = 7;
            faceLeft[11] = 7;
            faceLeft[5] = 8;
            faceLeft[3] = 10;
            faceLeft[7] = 10;
            faceLeft[4] = 14;
            faceLeft[2] = 18;
            faceLeft[1] = 21;
            faceLeft[51] = 246;
            faceLeft[170] = 251;
            faceLeft[119] = 255;
            faceLeft[204] = 265;
            faceLeft[136] = 268;
            faceLeft[34] = 276;
            faceLeft[238] = 276;
            faceLeft[85] = 279;
            faceLeft[221] = 280;
            faceLeft[102] = 285;
            faceLeft[153] = 285;
            faceLeft[17] = 296;
            faceLeft[68] = 358;
            faceLeft[187] = 392;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[163] = 5;
            faceRight[137] = 6;
            faceRight[202] = 10;
            faceRight[222] = 10;
            faceRight[105] = 11;
            faceRight[1] = 12;
            faceRight[170] = 236;
            faceRight[119] = 239;
            faceRight[51] = 241;
            faceRight[204] = 257;
            faceRight[136] = 257;
            faceRight[221] = 268;
            faceRight[34] = 268;
            faceRight[238] = 268;
            faceRight[102] = 271;
            faceRight[17] = 275;
            faceRight[85] = 275;
            faceRight[153] = 281;
            faceRight[68] = 348;
            faceRight[187] = 384;
            faceRight[4] = 449;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[119] = 238;
            faceTop[51] = 243;
            faceTop[170] = 243;
            faceTop[136] = 247;
            faceTop[204] = 254;
            faceTop[85] = 258;
            faceTop[34] = 264;
            faceTop[238] = 267;
            faceTop[153] = 267;
            faceTop[221] = 269;
            faceTop[102] = 269;
            faceTop[17] = 271;
            faceTop[68] = 338;
            faceTop[187] = 371;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[51] = 250;
            faceBottom[170] = 253;
            faceBottom[119] = 254;
            faceBottom[204] = 266;
            faceBottom[136] = 269;
            faceBottom[238] = 276;
            faceBottom[34] = 279;
            faceBottom[85] = 279;
            faceBottom[221] = 280;
            faceBottom[102] = 283;
            faceBottom[17] = 284;
            faceBottom[153] = 285;
            faceBottom[68] = 355;
            faceBottom[187] = 390;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TAKAMA] = mapInfo;

        }

        public static readonly PlanetProfile TAKAMA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = TAKAMA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, 0.25f, 0.75f, 2.0f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.15f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.5f, 4.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 50, 225),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "BrokenBalcor", "Balcor", "DamagedBalcor"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Volcanic, "Magma")
            )
        };

    }

}
