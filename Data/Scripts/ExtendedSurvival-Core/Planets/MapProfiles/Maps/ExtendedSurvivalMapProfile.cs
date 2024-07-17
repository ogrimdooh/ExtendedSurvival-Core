﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ExtendedSurvivalMapProfile
    {

        public const string DEFAULT_OI = "OI";
        public const string DEFAULT_SPATAT = "SPATAT";
        public const string DEFAULT_ENITOR = "ENITOR";
        public const string DEFAULT_EREMUS_NUBIS = "EREMUS NUBIS";
        public const string DEFAULT_DOVER = "DOVER";
        public const string DEFAULT_TOTHT = "TOTHT";
        public const string DEFAULT_GLEDIUS_NUBIS = "GLEDIUS NUBIS";
        public const string DEFAULT_CAPUTALIS_NUBIS = "CAPUTALIS NUBIS";

        static ExtendedSurvivalMapProfile()
        {
            LoadOreOiMapInfo();
            LoadOreSpatatMapInfo();
            LoadOreEnitorMapInfo();
            LoadOreEremusNubisMapInfo();
            LoadOreDoverMapInfo();
            LoadOreTothtMapInfo();
            LoadOreGlediusNubisMapInfo();
            LoadOreCaputalisNubisMapInfo();
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

        public static void LoadOreOiMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_OI] = mapInfo;
        }

        public static void LoadOreSpatatMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_SPATAT] = mapInfo;
        }

        public static void LoadOreEnitorMapInfo()
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
            faceLeft[200] = 6;
            faceLeft[220] = 6;
            faceLeft[240] = 6;
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
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 6;
            faceTop[220] = 6;
            faceTop[240] = 6;
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
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[200] = 6;
            faceBottom[220] = 6;
            faceBottom[240] = 6;
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
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_ENITOR] = mapInfo;
        }

        public static void LoadOreEremusNubisMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[80] = 103;
            faceFront[98] = 125;
            faceFront[100] = 172;
            faceFront[104] = 223;
            faceFront[96] = 236;
            faceFront[152] = 239;
            faceFront[92] = 242;
            faceFront[76] = 270;
            faceFront[180] = 321;
            faceFront[188] = 325;
            faceFront[88] = 423;
            faceFront[8] = 446;
            faceFront[176] = 447;
            faceFront[168] = 461;
            faceFront[108] = 466;
            faceFront[112] = 468;
            faceFront[72] = 478;
            faceFront[84] = 480;
            faceFront[12] = 505;
            faceFront[160] = 517;
            faceFront[184] = 678;
            faceFront[172] = 684;
            faceFront[116] = 698;
            faceFront[4] = 716;
            faceFront[148] = 765;
            faceFront[68] = 770;
            faceFront[16] = 773;
            faceFront[20] = 819;
            faceFront[64] = 882;
            faceFront[164] = 974;
            faceFront[48] = 1057;
            faceFront[52] = 1059;
            faceFront[128] = 1073;
            faceFront[156] = 1078;
            faceFront[144] = 1082;
            faceFront[32] = 1114;
            faceFront[60] = 1227;
            faceFront[1] = 1316;
            faceFront[28] = 1339;
            faceFront[24] = 1399;
            faceFront[56] = 1546;
            faceFront[124] = 1893;
            faceFront[120] = 2216;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[200] = 6;
            faceBack[220] = 6;
            faceBack[240] = 6;
            faceBack[98] = 128;
            faceBack[80] = 136;
            faceBack[100] = 174;
            faceBack[96] = 235;
            faceBack[104] = 239;
            faceBack[92] = 254;
            faceBack[152] = 256;
            faceBack[76] = 320;
            faceBack[180] = 372;
            faceBack[188] = 372;
            faceBack[88] = 430;
            faceBack[8] = 499;
            faceBack[84] = 499;
            faceBack[176] = 520;
            faceBack[168] = 522;
            faceBack[108] = 528;
            faceBack[112] = 533;
            faceBack[160] = 538;
            faceBack[12] = 565;
            faceBack[72] = 584;
            faceBack[184] = 745;
            faceBack[172] = 778;
            faceBack[116] = 791;
            faceBack[4] = 813;
            faceBack[148] = 873;
            faceBack[16] = 889;
            faceBack[68] = 912;
            faceBack[20] = 958;
            faceBack[64] = 1037;
            faceBack[164] = 1048;
            faceBack[52] = 1168;
            faceBack[156] = 1168;
            faceBack[144] = 1174;
            faceBack[48] = 1179;
            faceBack[128] = 1217;
            faceBack[32] = 1267;
            faceBack[60] = 1428;
            faceBack[1] = 1481;
            faceBack[28] = 1618;
            faceBack[56] = 1669;
            faceBack[24] = 1685;
            faceBack[124] = 2099;
            faceBack[120] = 2464;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[200] = 6;
            faceLeft[220] = 6;
            faceLeft[240] = 10;
            faceLeft[98] = 118;
            faceLeft[80] = 134;
            faceLeft[100] = 180;
            faceLeft[104] = 242;
            faceLeft[92] = 248;
            faceLeft[96] = 249;
            faceLeft[152] = 265;
            faceLeft[76] = 340;
            faceLeft[188] = 393;
            faceLeft[180] = 395;
            faceLeft[88] = 464;
            faceLeft[84] = 487;
            faceLeft[112] = 513;
            faceLeft[108] = 514;
            faceLeft[176] = 520;
            faceLeft[168] = 527;
            faceLeft[8] = 540;
            faceLeft[160] = 578;
            faceLeft[12] = 579;
            faceLeft[142] = 606;
            faceLeft[72] = 613;
            faceLeft[184] = 773;
            faceLeft[116] = 777;
            faceLeft[172] = 786;
            faceLeft[148] = 843;
            faceLeft[16] = 912;
            faceLeft[68] = 918;
            faceLeft[20] = 971;
            faceLeft[64] = 1059;
            faceLeft[164] = 1089;
            faceLeft[48] = 1180;
            faceLeft[52] = 1181;
            faceLeft[144] = 1190;
            faceLeft[156] = 1219;
            faceLeft[128] = 1248;
            faceLeft[32] = 1305;
            faceLeft[60] = 1451;
            faceLeft[1] = 1595;
            faceLeft[28] = 1638;
            faceLeft[56] = 1673;
            faceLeft[24] = 1733;
            faceLeft[124] = 2161;
            faceLeft[120] = 2509;
            faceLeft[4] = 2836;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[80] = 147;
            faceRight[98] = 152;
            faceRight[100] = 225;
            faceRight[152] = 292;
            faceRight[96] = 298;
            faceRight[92] = 301;
            faceRight[104] = 301;
            faceRight[76] = 377;
            faceRight[180] = 461;
            faceRight[188] = 466;
            faceRight[88] = 532;
            faceRight[168] = 588;
            faceRight[112] = 592;
            faceRight[176] = 594;
            faceRight[108] = 597;
            faceRight[84] = 598;
            faceRight[8] = 605;
            faceRight[160] = 674;
            faceRight[72] = 682;
            faceRight[12] = 684;
            faceRight[172] = 878;
            faceRight[116] = 893;
            faceRight[184] = 901;
            faceRight[148] = 963;
            faceRight[4] = 1003;
            faceRight[16] = 1049;
            faceRight[68] = 1063;
            faceRight[20] = 1143;
            faceRight[64] = 1217;
            faceRight[164] = 1272;
            faceRight[48] = 1302;
            faceRight[52] = 1307;
            faceRight[144] = 1317;
            faceRight[156] = 1429;
            faceRight[128] = 1435;
            faceRight[32] = 1568;
            faceRight[60] = 1665;
            faceRight[1] = 1835;
            faceRight[56] = 1884;
            faceRight[28] = 1896;
            faceRight[24] = 1983;
            faceRight[124] = 2506;
            faceRight[120] = 2882;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[200] = 6;
            faceTop[220] = 6;
            faceTop[240] = 6;
            faceTop[98] = 121;
            faceTop[80] = 140;
            faceTop[100] = 187;
            faceTop[152] = 243;
            faceTop[96] = 246;
            faceTop[104] = 247;
            faceTop[92] = 257;
            faceTop[76] = 343;
            faceTop[180] = 368;
            faceTop[188] = 371;
            faceTop[88] = 437;
            faceTop[112] = 472;
            faceTop[108] = 480;
            faceTop[176] = 484;
            faceTop[168] = 491;
            faceTop[84] = 505;
            faceTop[8] = 529;
            faceTop[12] = 550;
            faceTop[160] = 563;
            faceTop[72] = 612;
            faceTop[116] = 714;
            faceTop[172] = 730;
            faceTop[184] = 745;
            faceTop[148] = 812;
            faceTop[4] = 849;
            faceTop[68] = 858;
            faceTop[16] = 884;
            faceTop[20] = 926;
            faceTop[64] = 1005;
            faceTop[164] = 1060;
            faceTop[52] = 1106;
            faceTop[48] = 1107;
            faceTop[144] = 1109;
            faceTop[128] = 1193;
            faceTop[156] = 1208;
            faceTop[32] = 1292;
            faceTop[60] = 1386;
            faceTop[1] = 1554;
            faceTop[56] = 1593;
            faceTop[28] = 1640;
            faceTop[24] = 1707;
            faceTop[124] = 2076;
            faceTop[120] = 2390;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[200] = 6;
            faceBottom[220] = 6;
            faceBottom[240] = 6;
            faceBottom[98] = 95;
            faceBottom[80] = 95;
            faceBottom[100] = 153;
            faceBottom[96] = 208;
            faceBottom[152] = 208;
            faceBottom[104] = 209;
            faceBottom[92] = 214;
            faceBottom[76] = 241;
            faceBottom[188] = 293;
            faceBottom[180] = 301;
            faceBottom[88] = 367;
            faceBottom[8] = 389;
            faceBottom[168] = 399;
            faceBottom[108] = 403;
            faceBottom[112] = 404;
            faceBottom[176] = 404;
            faceBottom[84] = 426;
            faceBottom[72] = 440;
            faceBottom[12] = 446;
            faceBottom[160] = 468;
            faceBottom[184] = 591;
            faceBottom[116] = 601;
            faceBottom[172] = 606;
            faceBottom[4] = 638;
            faceBottom[148] = 691;
            faceBottom[16] = 720;
            faceBottom[68] = 736;
            faceBottom[20] = 746;
            faceBottom[64] = 835;
            faceBottom[164] = 869;
            faceBottom[48] = 918;
            faceBottom[52] = 921;
            faceBottom[144] = 930;
            faceBottom[156] = 987;
            faceBottom[128] = 997;
            faceBottom[32] = 1001;
            faceBottom[60] = 1171;
            faceBottom[1] = 1189;
            faceBottom[28] = 1296;
            faceBottom[56] = 1337;
            faceBottom[24] = 1355;
            faceBottom[124] = 1741;
            faceBottom[120] = 2020;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_EREMUS_NUBIS] = mapInfo;
        }

        public static void LoadOreDoverMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
            faceFront[111] = 1;
            faceFront[154] = 2;
            faceFront[110] = 3;
            faceFront[131] = 4;
            faceFront[107] = 5;
            faceFront[138] = 5;
            faceFront[171] = 5;
            faceFront[115] = 6;
            faceFront[186] = 7;
            faceFront[114] = 9;
            faceFront[103] = 10;
            faceFront[123] = 11;
            faceFront[197] = 11;
            faceFront[199] = 11;
            faceFront[207] = 12;
            faceFront[95] = 14;
            faceFront[90] = 16;
            faceFront[245] = 16;
            faceFront[105] = 17;
            faceFront[158] = 17;
            faceFront[21] = 18;
            faceFront[61] = 18;
            faceFront[195] = 19;
            faceFront[214] = 19;
            faceFront[57] = 20;
            faceFront[137] = 20;
            faceFront[141] = 21;
            faceFront[216] = 21;
            faceFront[102] = 24;
            faceFront[109] = 24;
            faceFront[178] = 25;
            faceFront[169] = 26;
            faceFront[39] = 27;
            faceFront[89] = 27;
            faceFront[210] = 29;
            faceFront[121] = 30;
            faceFront[145] = 30;
            faceFront[212] = 30;
            faceFront[218] = 30;
            faceFront[54] = 31;
            faceFront[157] = 31;
            faceFront[162] = 31;
            faceFront[190] = 31;
            faceFront[36] = 32;
            faceFront[62] = 33;
            faceFront[213] = 33;
            faceFront[106] = 34;
            faceFront[232] = 34;
            faceFront[226] = 35;
            faceFront[117] = 36;
            faceFront[161] = 36;
            faceFront[18] = 37;
            faceFront[47] = 37;
            faceFront[191] = 37;
            faceFront[241] = 38;
            faceFront[159] = 39;
            faceFront[43] = 40;
            faceFront[67] = 40;
            faceFront[208] = 40;
            faceFront[234] = 40;
            faceFront[66] = 41;
            faceFront[209] = 43;
            faceFront[235] = 44;
            faceFront[93] = 46;
            faceFront[193] = 48;
            faceFront[233] = 48;
            faceFront[101] = 49;
            faceFront[205] = 49;
            faceFront[246] = 50;
            faceFront[244] = 51;
            faceFront[150] = 52;
            faceFront[122] = 53;
            faceFront[149] = 53;
            faceFront[240] = 53;
            faceFront[69] = 54;
            faceFront[129] = 55;
            faceFront[174] = 55;
            faceFront[132] = 56;
            faceFront[134] = 56;
            faceFront[177] = 56;
            faceFront[86] = 57;
            faceFront[99] = 57;
            faceFront[243] = 58;
            faceFront[130] = 59;
            faceFront[70] = 60;
            faceFront[151] = 60;
            faceFront[206] = 60;
            faceFront[217] = 60;
            faceFront[222] = 60;
            faceFront[242] = 61;
            faceFront[175] = 62;
            faceFront[182] = 62;
            faceFront[198] = 65;
            faceFront[223] = 65;
            faceFront[211] = 67;
            faceFront[215] = 68;
            faceFront[224] = 70;
            faceFront[136] = 71;
            faceFront[181] = 72;
            faceFront[231] = 72;
            faceFront[155] = 74;
            faceFront[179] = 76;
            faceFront[230] = 76;
            faceFront[125] = 78;
            faceFront[227] = 78;
            faceFront[236] = 79;
            faceFront[165] = 80;
            faceFront[221] = 81;
            faceFront[229] = 81;
            faceFront[73] = 82;
            faceFront[220] = 83;
            faceFront[196] = 86;
            faceFront[170] = 88;
            faceFront[237] = 89;
            faceFront[185] = 90;
            faceFront[204] = 90;
            faceFront[187] = 91;
            faceFront[238] = 93;
            faceFront[77] = 96;
            faceFront[133] = 98;
            faceFront[192] = 98;
            faceFront[147] = 99;
            faceFront[183] = 99;
            faceFront[194] = 102;
            faceFront[163] = 106;
            faceFront[166] = 109;
            faceFront[153] = 111;
            faceFront[202] = 115;
            faceFront[189] = 120;
            faceFront[219] = 133;
            faceFront[201] = 141;
            faceFront[203] = 142;
            faceFront[225] = 152;
            faceFront[91] = 214;
            faceFront[98] = 223;
            faceFront[80] = 225;
            faceFront[146] = 226;
            faceFront[173] = 241;
            faceFront[100] = 302;
            faceFront[228] = 307;
            faceFront[118] = 311;
            faceFront[200] = 341;
            faceFront[152] = 388;
            faceFront[92] = 397;
            faceFront[104] = 447;
            faceFront[76] = 473;
            faceFront[96] = 487;
            faceFront[180] = 606;
            faceFront[188] = 615;
            faceFront[88] = 733;
            faceFront[8] = 767;
            faceFront[108] = 774;
            faceFront[112] = 795;
            faceFront[176] = 801;
            faceFront[84] = 813;
            faceFront[168] = 837;
            faceFront[72] = 860;
            faceFront[12] = 876;
            faceFront[160] = 908;
            faceFront[116] = 1162;
            faceFront[172] = 1185;
            faceFront[184] = 1191;
            faceFront[148] = 1237;
            faceFront[4] = 1251;
            faceFront[16] = 1341;
            faceFront[68] = 1370;
            faceFront[20] = 1437;
            faceFront[164] = 1692;
            faceFront[48] = 1738;
            faceFront[144] = 1766;
            faceFront[52] = 1789;
            faceFront[64] = 1810;
            faceFront[156] = 1887;
            faceFront[128] = 1916;
            faceFront[32] = 1991;
            faceFront[60] = 2169;
            faceFront[1] = 2326;
            faceFront[28] = 2466;
            faceFront[56] = 2501;
            faceFront[24] = 2546;
            faceFront[124] = 3205;
            faceFront[120] = 3764;
            faceFront[50] = 9680;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
            faceBack[107] = 2;
            faceBack[154] = 3;
            faceBack[171] = 5;
            faceBack[110] = 6;
            faceBack[115] = 6;
            faceBack[103] = 7;
            faceBack[131] = 7;
            faceBack[114] = 9;
            faceBack[138] = 9;
            faceBack[245] = 12;
            faceBack[186] = 13;
            faceBack[90] = 15;
            faceBack[137] = 15;
            faceBack[216] = 16;
            faceBack[61] = 17;
            faceBack[95] = 17;
            faceBack[195] = 17;
            faceBack[67] = 18;
            faceBack[158] = 18;
            faceBack[207] = 18;
            faceBack[214] = 19;
            faceBack[36] = 21;
            faceBack[57] = 23;
            faceBack[169] = 26;
            faceBack[178] = 26;
            faceBack[123] = 27;
            faceBack[162] = 28;
            faceBack[141] = 30;
            faceBack[197] = 30;
            faceBack[62] = 31;
            faceBack[21] = 32;
            faceBack[105] = 32;
            faceBack[218] = 32;
            faceBack[161] = 33;
            faceBack[208] = 33;
            faceBack[109] = 34;
            faceBack[199] = 34;
            faceBack[205] = 36;
            faceBack[190] = 38;
            faceBack[240] = 39;
            faceBack[89] = 40;
            faceBack[159] = 40;
            faceBack[66] = 41;
            faceBack[102] = 42;
            faceBack[209] = 42;
            faceBack[117] = 43;
            faceBack[145] = 43;
            faceBack[241] = 43;
            faceBack[246] = 43;
            faceBack[226] = 44;
            faceBack[54] = 45;
            faceBack[47] = 46;
            faceBack[121] = 47;
            faceBack[210] = 47;
            faceBack[206] = 48;
            faceBack[157] = 49;
            faceBack[234] = 49;
            faceBack[175] = 51;
            faceBack[212] = 51;
            faceBack[213] = 52;
            faceBack[18] = 53;
            faceBack[69] = 53;
            faceBack[191] = 54;
            faceBack[215] = 54;
            faceBack[86] = 56;
            faceBack[232] = 56;
            faceBack[149] = 60;
            faceBack[233] = 60;
            faceBack[70] = 61;
            faceBack[217] = 62;
            faceBack[43] = 63;
            faceBack[106] = 63;
            faceBack[174] = 63;
            faceBack[244] = 63;
            faceBack[182] = 64;
            faceBack[39] = 67;
            faceBack[93] = 67;
            faceBack[235] = 67;
            faceBack[130] = 69;
            faceBack[132] = 69;
            faceBack[122] = 72;
            faceBack[99] = 73;
            faceBack[198] = 74;
            faceBack[243] = 76;
            faceBack[134] = 78;
            faceBack[129] = 81;
            faceBack[177] = 82;
            faceBack[211] = 85;
            faceBack[101] = 87;
            faceBack[223] = 88;
            faceBack[227] = 89;
            faceBack[150] = 91;
            faceBack[151] = 92;
            faceBack[236] = 93;
            faceBack[77] = 94;
            faceBack[193] = 95;
            faceBack[133] = 96;
            faceBack[170] = 96;
            faceBack[179] = 98;
            faceBack[163] = 99;
            faceBack[189] = 99;
            faceBack[222] = 99;
            faceBack[242] = 99;
            faceBack[183] = 103;
            faceBack[192] = 106;
            faceBack[230] = 106;
            faceBack[181] = 107;
            faceBack[204] = 108;
            faceBack[229] = 109;
            faceBack[136] = 111;
            faceBack[155] = 112;
            faceBack[185] = 112;
            faceBack[194] = 113;
            faceBack[231] = 113;
            faceBack[224] = 114;
            faceBack[125] = 115;
            faceBack[196] = 116;
            faceBack[165] = 117;
            faceBack[73] = 124;
            faceBack[221] = 127;
            faceBack[237] = 127;
            faceBack[147] = 134;
            faceBack[202] = 135;
            faceBack[187] = 138;
            faceBack[153] = 141;
            faceBack[220] = 141;
            faceBack[238] = 142;
            faceBack[166] = 143;
            faceBack[203] = 148;
            faceBack[201] = 151;
            faceBack[219] = 178;
            faceBack[80] = 193;
            faceBack[98] = 197;
            faceBack[225] = 217;
            faceBack[146] = 230;
            faceBack[118] = 261;
            faceBack[91] = 263;
            faceBack[100] = 269;
            faceBack[173] = 284;
            faceBack[200] = 340;
            faceBack[152] = 350;
            faceBack[92] = 359;
            faceBack[228] = 390;
            faceBack[76] = 401;
            faceBack[104] = 439;
            faceBack[96] = 443;
            faceBack[180] = 543;
            faceBack[188] = 550;
            faceBack[8] = 647;
            faceBack[88] = 660;
            faceBack[108] = 688;
            faceBack[112] = 698;
            faceBack[84] = 727;
            faceBack[72] = 733;
            faceBack[176] = 735;
            faceBack[12] = 760;
            faceBack[168] = 780;
            faceBack[160] = 796;
            faceBack[116] = 1008;
            faceBack[184] = 1049;
            faceBack[4] = 1056;
            faceBack[172] = 1076;
            faceBack[148] = 1124;
            faceBack[16] = 1163;
            faceBack[68] = 1174;
            faceBack[20] = 1239;
            faceBack[164] = 1539;
            faceBack[48] = 1562;
            faceBack[144] = 1608;
            faceBack[52] = 1622;
            faceBack[64] = 1627;
            faceBack[156] = 1634;
            faceBack[32] = 1682;
            faceBack[128] = 1701;
            faceBack[60] = 1858;
            faceBack[1] = 1958;
            faceBack[28] = 2094;
            faceBack[24] = 2188;
            faceBack[56] = 2272;
            faceBack[124] = 2811;
            faceBack[120] = 3386;
            faceBack[50] = 8572;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Back] = faceBack;

            var faceLeft = new ConcurrentDictionary<byte, long>();
            faceLeft[115] = 3;
            faceLeft[138] = 4;
            faceLeft[107] = 5;
            faceLeft[131] = 5;
            faceLeft[171] = 5;
            faceLeft[110] = 6;
            faceLeft[186] = 7;
            faceLeft[154] = 8;
            faceLeft[197] = 8;
            faceLeft[114] = 9;
            faceLeft[123] = 9;
            faceLeft[137] = 9;
            faceLeft[95] = 11;
            faceLeft[103] = 11;
            faceLeft[245] = 11;
            faceLeft[207] = 13;
            faceLeft[162] = 16;
            faceLeft[178] = 17;
            faceLeft[61] = 18;
            faceLeft[214] = 18;
            faceLeft[213] = 21;
            faceLeft[158] = 24;
            faceLeft[216] = 24;
            faceLeft[109] = 25;
            faceLeft[218] = 26;
            faceLeft[36] = 27;
            faceLeft[190] = 27;
            faceLeft[195] = 27;
            faceLeft[57] = 28;
            faceLeft[66] = 28;
            faceLeft[90] = 28;
            faceLeft[141] = 30;
            faceLeft[199] = 30;
            faceLeft[169] = 31;
            faceLeft[191] = 31;
            faceLeft[102] = 33;
            faceLeft[67] = 36;
            faceLeft[161] = 36;
            faceLeft[226] = 36;
            faceLeft[89] = 37;
            faceLeft[121] = 37;
            faceLeft[145] = 38;
            faceLeft[209] = 38;
            faceLeft[54] = 39;
            faceLeft[105] = 39;
            faceLeft[235] = 39;
            faceLeft[21] = 40;
            faceLeft[246] = 40;
            faceLeft[62] = 41;
            faceLeft[208] = 41;
            faceLeft[212] = 41;
            faceLeft[117] = 43;
            faceLeft[106] = 44;
            faceLeft[150] = 44;
            faceLeft[210] = 44;
            faceLeft[234] = 44;
            faceLeft[205] = 45;
            faceLeft[240] = 46;
            faceLeft[69] = 47;
            faceLeft[157] = 47;
            faceLeft[159] = 48;
            faceLeft[47] = 49;
            faceLeft[223] = 51;
            faceLeft[241] = 55;
            faceLeft[18] = 57;
            faceLeft[99] = 57;
            faceLeft[233] = 57;
            faceLeft[242] = 57;
            faceLeft[93] = 58;
            faceLeft[193] = 58;
            faceLeft[132] = 60;
            faceLeft[217] = 61;
            faceLeft[243] = 61;
            faceLeft[231] = 62;
            faceLeft[232] = 62;
            faceLeft[101] = 63;
            faceLeft[206] = 63;
            faceLeft[130] = 66;
            faceLeft[43] = 67;
            faceLeft[39] = 69;
            faceLeft[122] = 70;
            faceLeft[215] = 70;
            faceLeft[192] = 71;
            faceLeft[227] = 73;
            faceLeft[149] = 74;
            faceLeft[211] = 74;
            faceLeft[244] = 74;
            faceLeft[174] = 75;
            faceLeft[86] = 76;
            faceLeft[230] = 76;
            faceLeft[70] = 77;
            faceLeft[181] = 77;
            faceLeft[170] = 78;
            faceLeft[182] = 78;
            faceLeft[155] = 79;
            faceLeft[198] = 79;
            faceLeft[229] = 79;
            faceLeft[222] = 80;
            faceLeft[129] = 81;
            faceLeft[134] = 81;
            faceLeft[177] = 82;
            faceLeft[151] = 84;
            faceLeft[175] = 84;
            faceLeft[77] = 86;
            faceLeft[224] = 87;
            faceLeft[133] = 88;
            faceLeft[183] = 90;
            faceLeft[196] = 92;
            faceLeft[189] = 94;
            faceLeft[221] = 96;
            faceLeft[179] = 97;
            faceLeft[236] = 99;
            faceLeft[136] = 100;
            faceLeft[194] = 100;
            faceLeft[220] = 101;
            faceLeft[73] = 102;
            faceLeft[163] = 104;
            faceLeft[165] = 106;
            faceLeft[185] = 106;
            faceLeft[204] = 107;
            faceLeft[125] = 108;
            faceLeft[147] = 109;
            faceLeft[166] = 109;
            faceLeft[187] = 109;
            faceLeft[153] = 110;
            faceLeft[237] = 117;
            faceLeft[202] = 125;
            faceLeft[238] = 133;
            faceLeft[203] = 149;
            faceLeft[219] = 149;
            faceLeft[225] = 151;
            faceLeft[201] = 161;
            faceLeft[91] = 197;
            faceLeft[80] = 270;
            faceLeft[118] = 280;
            faceLeft[146] = 283;
            faceLeft[173] = 292;
            faceLeft[98] = 300;
            faceLeft[200] = 331;
            faceLeft[100] = 370;
            faceLeft[228] = 378;
            faceLeft[152] = 488;
            faceLeft[92] = 494;
            faceLeft[104] = 541;
            faceLeft[96] = 586;
            faceLeft[76] = 610;
            faceLeft[188] = 781;
            faceLeft[180] = 791;
            faceLeft[88] = 912;
            faceLeft[8] = 976;
            faceLeft[108] = 1003;
            faceLeft[84] = 1004;
            faceLeft[112] = 1015;
            faceLeft[176] = 1041;
            faceLeft[72] = 1091;
            faceLeft[168] = 1100;
            faceLeft[12] = 1121;
            faceLeft[160] = 1136;
            faceLeft[116] = 1498;
            faceLeft[184] = 1523;
            faceLeft[172] = 1556;
            faceLeft[4] = 1588;
            faceLeft[148] = 1589;
            faceLeft[68] = 1705;
            faceLeft[16] = 1753;
            faceLeft[20] = 1880;
            faceLeft[64] = 2166;
            faceLeft[164] = 2179;
            faceLeft[48] = 2206;
            faceLeft[144] = 2221;
            faceLeft[52] = 2277;
            faceLeft[156] = 2358;
            faceLeft[128] = 2435;
            faceLeft[32] = 2476;
            faceLeft[60] = 2665;
            faceLeft[1] = 2921;
            faceLeft[28] = 3057;
            faceLeft[24] = 3179;
            faceLeft[56] = 3195;
            faceLeft[124] = 4061;
            faceLeft[120] = 4729;
            faceLeft[50] = 12311;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Left] = faceLeft;

            var faceRight = new ConcurrentDictionary<byte, long>();
            faceRight[171] = 1;
            faceRight[103] = 2;
            faceRight[110] = 2;
            faceRight[115] = 2;
            faceRight[107] = 3;
            faceRight[114] = 3;
            faceRight[154] = 3;
            faceRight[131] = 5;
            faceRight[138] = 5;
            faceRight[186] = 7;
            faceRight[95] = 12;
            faceRight[141] = 13;
            faceRight[207] = 13;
            faceRight[123] = 14;
            faceRight[61] = 15;
            faceRight[158] = 15;
            faceRight[137] = 16;
            faceRight[197] = 16;
            faceRight[216] = 17;
            faceRight[195] = 18;
            faceRight[245] = 18;
            faceRight[67] = 20;
            faceRight[109] = 20;
            faceRight[90] = 21;
            faceRight[178] = 22;
            faceRight[208] = 22;
            faceRight[218] = 22;
            faceRight[159] = 23;
            faceRight[213] = 23;
            faceRight[102] = 25;
            faceRight[161] = 25;
            faceRight[210] = 25;
            faceRight[214] = 25;
            faceRight[57] = 26;
            faceRight[36] = 27;
            faceRight[54] = 27;
            faceRight[226] = 27;
            faceRight[66] = 28;
            faceRight[162] = 28;
            faceRight[169] = 28;
            faceRight[199] = 29;
            faceRight[21] = 30;
            faceRight[89] = 30;
            faceRight[190] = 31;
            faceRight[105] = 32;
            faceRight[121] = 32;
            faceRight[62] = 33;
            faceRight[191] = 35;
            faceRight[241] = 35;
            faceRight[209] = 36;
            faceRight[117] = 37;
            faceRight[106] = 38;
            faceRight[212] = 38;
            faceRight[244] = 38;
            faceRight[240] = 40;
            faceRight[18] = 43;
            faceRight[157] = 43;
            faceRight[246] = 43;
            faceRight[47] = 45;
            faceRight[69] = 45;
            faceRight[235] = 45;
            faceRight[234] = 48;
            faceRight[93] = 51;
            faceRight[182] = 51;
            faceRight[232] = 51;
            faceRight[145] = 52;
            faceRight[99] = 53;
            faceRight[130] = 53;
            faceRight[233] = 53;
            faceRight[134] = 54;
            faceRight[193] = 54;
            faceRight[215] = 54;
            faceRight[243] = 54;
            faceRight[132] = 55;
            faceRight[198] = 55;
            faceRight[206] = 55;
            faceRight[217] = 56;
            faceRight[39] = 59;
            faceRight[205] = 59;
            faceRight[43] = 60;
            faceRight[175] = 61;
            faceRight[231] = 62;
            faceRight[222] = 63;
            faceRight[242] = 63;
            faceRight[70] = 67;
            faceRight[101] = 67;
            faceRight[149] = 68;
            faceRight[211] = 68;
            faceRight[129] = 69;
            faceRight[181] = 69;
            faceRight[227] = 69;
            faceRight[236] = 69;
            faceRight[133] = 70;
            faceRight[122] = 72;
            faceRight[174] = 72;
            faceRight[170] = 73;
            faceRight[192] = 73;
            faceRight[179] = 75;
            faceRight[86] = 76;
            faceRight[189] = 77;
            faceRight[194] = 78;
            faceRight[150] = 80;
            faceRight[136] = 81;
            faceRight[177] = 81;
            faceRight[220] = 86;
            faceRight[155] = 87;
            faceRight[183] = 88;
            faceRight[187] = 88;
            faceRight[223] = 88;
            faceRight[163] = 89;
            faceRight[77] = 91;
            faceRight[165] = 92;
            faceRight[204] = 92;
            faceRight[151] = 93;
            faceRight[221] = 95;
            faceRight[224] = 96;
            faceRight[230] = 97;
            faceRight[125] = 101;
            faceRight[185] = 103;
            faceRight[196] = 103;
            faceRight[229] = 105;
            faceRight[166] = 107;
            faceRight[203] = 108;
            faceRight[73] = 110;
            faceRight[237] = 112;
            faceRight[202] = 117;
            faceRight[147] = 125;
            faceRight[219] = 128;
            faceRight[153] = 133;
            faceRight[201] = 135;
            faceRight[238] = 143;
            faceRight[225] = 169;
            faceRight[80] = 176;
            faceRight[98] = 193;
            faceRight[146] = 197;
            faceRight[91] = 214;
            faceRight[100] = 223;
            faceRight[173] = 234;
            faceRight[118] = 258;
            faceRight[152] = 291;
            faceRight[92] = 309;
            faceRight[200] = 340;
            faceRight[104] = 349;
            faceRight[228] = 371;
            faceRight[76] = 374;
            faceRight[96] = 383;
            faceRight[188] = 496;
            faceRight[180] = 516;
            faceRight[88] = 576;
            faceRight[8] = 583;
            faceRight[108] = 586;
            faceRight[112] = 597;
            faceRight[176] = 608;
            faceRight[84] = 625;
            faceRight[168] = 660;
            faceRight[72] = 667;
            faceRight[12] = 676;
            faceRight[160] = 696;
            faceRight[116] = 878;
            faceRight[172] = 928;
            faceRight[184] = 941;
            faceRight[4] = 961;
            faceRight[148] = 983;
            faceRight[68] = 1034;
            faceRight[16] = 1059;
            faceRight[20] = 1126;
            faceRight[48] = 1305;
            faceRight[144] = 1348;
            faceRight[52] = 1349;
            faceRight[164] = 1361;
            faceRight[64] = 1400;
            faceRight[156] = 1455;
            faceRight[128] = 1466;
            faceRight[32] = 1492;
            faceRight[60] = 1623;
            faceRight[1] = 1792;
            faceRight[28] = 1847;
            faceRight[56] = 1871;
            faceRight[24] = 1943;
            faceRight[124] = 2418;
            faceRight[120] = 2857;
            faceRight[50] = 7326;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Right] = faceRight;

            var faceTop = new ConcurrentDictionary<byte, long>();
            faceTop[114] = 1;
            faceTop[131] = 1;
            faceTop[110] = 2;
            faceTop[138] = 2;
            faceTop[115] = 3;
            faceTop[90] = 4;
            faceTop[103] = 5;
            faceTop[186] = 5;
            faceTop[107] = 6;
            faceTop[123] = 6;
            faceTop[154] = 6;
            faceTop[171] = 6;
            faceTop[95] = 7;
            faceTop[207] = 7;
            faceTop[61] = 9;
            faceTop[197] = 9;
            faceTop[162] = 10;
            faceTop[158] = 11;
            faceTop[214] = 11;
            faceTop[67] = 12;
            faceTop[137] = 12;
            faceTop[178] = 13;
            faceTop[195] = 13;
            faceTop[216] = 13;
            faceTop[226] = 16;
            faceTop[109] = 17;
            faceTop[245] = 17;
            faceTop[169] = 19;
            faceTop[210] = 19;
            faceTop[57] = 20;
            faceTop[102] = 21;
            faceTop[157] = 21;
            faceTop[199] = 21;
            faceTop[36] = 22;
            faceTop[159] = 23;
            faceTop[209] = 23;
            faceTop[218] = 23;
            faceTop[54] = 24;
            faceTop[62] = 24;
            faceTop[89] = 24;
            faceTop[208] = 24;
            faceTop[213] = 24;
            faceTop[101] = 25;
            faceTop[175] = 25;
            faceTop[21] = 26;
            faceTop[117] = 26;
            faceTop[121] = 26;
            faceTop[190] = 26;
            faceTop[161] = 27;
            faceTop[241] = 27;
            faceTop[106] = 28;
            faceTop[145] = 28;
            faceTop[105] = 30;
            faceTop[141] = 30;
            faceTop[240] = 30;
            faceTop[66] = 31;
            faceTop[234] = 31;
            faceTop[198] = 32;
            faceTop[212] = 32;
            faceTop[232] = 35;
            faceTop[86] = 36;
            faceTop[149] = 36;
            faceTop[182] = 36;
            faceTop[233] = 36;
            faceTop[235] = 36;
            faceTop[43] = 37;
            faceTop[93] = 38;
            faceTop[191] = 38;
            faceTop[47] = 39;
            faceTop[130] = 39;
            faceTop[179] = 39;
            faceTop[69] = 40;
            faceTop[205] = 40;
            faceTop[227] = 40;
            faceTop[39] = 41;
            faceTop[174] = 42;
            faceTop[244] = 42;
            faceTop[99] = 43;
            faceTop[170] = 43;
            faceTop[70] = 45;
            faceTop[151] = 45;
            faceTop[193] = 45;
            faceTop[132] = 46;
            faceTop[18] = 47;
            faceTop[129] = 47;
            faceTop[181] = 48;
            faceTop[134] = 49;
            faceTop[77] = 50;
            faceTop[150] = 50;
            faceTop[155] = 50;
            faceTop[165] = 50;
            faceTop[211] = 50;
            faceTop[215] = 50;
            faceTop[206] = 52;
            faceTop[217] = 52;
            faceTop[133] = 54;
            faceTop[177] = 54;
            faceTop[246] = 54;
            faceTop[73] = 57;
            faceTop[183] = 58;
            faceTop[242] = 58;
            faceTop[136] = 59;
            faceTop[125] = 60;
            faceTop[220] = 60;
            faceTop[204] = 62;
            faceTop[163] = 63;
            faceTop[194] = 63;
            faceTop[192] = 64;
            faceTop[237] = 64;
            faceTop[196] = 67;
            faceTop[243] = 68;
            faceTop[122] = 70;
            faceTop[222] = 70;
            faceTop[231] = 70;
            faceTop[236] = 70;
            faceTop[229] = 71;
            faceTop[185] = 75;
            faceTop[223] = 75;
            faceTop[230] = 75;
            faceTop[166] = 77;
            faceTop[189] = 78;
            faceTop[203] = 78;
            faceTop[147] = 82;
            faceTop[224] = 84;
            faceTop[187] = 90;
            faceTop[221] = 91;
            faceTop[238] = 92;
            faceTop[201] = 99;
            faceTop[202] = 101;
            faceTop[219] = 106;
            faceTop[225] = 109;
            faceTop[153] = 111;
            faceTop[80] = 117;
            faceTop[98] = 124;
            faceTop[91] = 142;
            faceTop[100] = 148;
            faceTop[118] = 149;
            faceTop[146] = 164;
            faceTop[173] = 169;
            faceTop[92] = 195;
            faceTop[152] = 202;
            faceTop[104] = 227;
            faceTop[200] = 239;
            faceTop[96] = 242;
            faceTop[76] = 263;
            faceTop[228] = 274;
            faceTop[180] = 314;
            faceTop[188] = 333;
            faceTop[88] = 360;
            faceTop[108] = 384;
            faceTop[112] = 392;
            faceTop[84] = 397;
            faceTop[176] = 399;
            faceTop[8] = 421;
            faceTop[168] = 422;
            faceTop[12] = 446;
            faceTop[160] = 464;
            faceTop[72] = 472;
            faceTop[116] = 579;
            faceTop[172] = 607;
            faceTop[184] = 614;
            faceTop[148] = 642;
            faceTop[4] = 682;
            faceTop[16] = 693;
            faceTop[68] = 702;
            faceTop[20] = 739;
            faceTop[48] = 883;
            faceTop[164] = 884;
            faceTop[144] = 912;
            faceTop[52] = 918;
            faceTop[156] = 947;
            faceTop[64] = 962;
            faceTop[128] = 985;
            faceTop[32] = 1024;
            faceTop[60] = 1098;
            faceTop[1] = 1266;
            faceTop[28] = 1273;
            faceTop[56] = 1278;
            faceTop[24] = 1337;
            faceTop[124] = 1619;
            faceTop[120] = 1930;
            faceTop[50] = 5077;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Top] = faceTop;

            var faceBottom = new ConcurrentDictionary<byte, long>();
            faceBottom[138] = 1;
            faceBottom[110] = 4;
            faceBottom[115] = 4;
            faceBottom[114] = 5;
            faceBottom[131] = 5;
            faceBottom[171] = 5;
            faceBottom[107] = 7;
            faceBottom[186] = 8;
            faceBottom[103] = 9;
            faceBottom[154] = 11;
            faceBottom[207] = 12;
            faceBottom[245] = 14;
            faceBottom[109] = 14;
            faceBottom[95] = 15;
            faceBottom[197] = 18;
            faceBottom[90] = 18;
            faceBottom[137] = 18;
            faceBottom[61] = 19;
            faceBottom[169] = 19;
            faceBottom[214] = 20;
            faceBottom[123] = 20;
            faceBottom[212] = 22;
            faceBottom[216] = 22;
            faceBottom[57] = 26;
            faceBottom[117] = 27;
            faceBottom[178] = 28;
            faceBottom[195] = 28;
            faceBottom[162] = 29;
            faceBottom[105] = 30;
            faceBottom[158] = 30;
            faceBottom[210] = 31;
            faceBottom[54] = 31;
            faceBottom[89] = 31;
            faceBottom[199] = 33;
            faceBottom[226] = 33;
            faceBottom[218] = 34;
            faceBottom[21] = 34;
            faceBottom[69] = 35;
            faceBottom[102] = 35;
            faceBottom[240] = 36;
            faceBottom[190] = 36;
            faceBottom[36] = 37;
            faceBottom[47] = 37;
            faceBottom[66] = 37;
            faceBottom[141] = 37;
            faceBottom[157] = 37;
            faceBottom[67] = 38;
            faceBottom[62] = 39;
            faceBottom[205] = 40;
            faceBottom[241] = 41;
            faceBottom[213] = 42;
            faceBottom[209] = 43;
            faceBottom[234] = 43;
            faceBottom[43] = 43;
            faceBottom[106] = 44;
            faceBottom[208] = 45;
            faceBottom[235] = 45;
            faceBottom[145] = 45;
            faceBottom[159] = 46;
            faceBottom[161] = 46;
            faceBottom[175] = 47;
            faceBottom[233] = 50;
            faceBottom[70] = 53;
            faceBottom[244] = 54;
            faceBottom[86] = 57;
            faceBottom[121] = 57;
            faceBottom[191] = 57;
            faceBottom[232] = 58;
            faceBottom[39] = 58;
            faceBottom[193] = 61;
            faceBottom[99] = 63;
            faceBottom[243] = 65;
            faceBottom[246] = 65;
            faceBottom[174] = 65;
            faceBottom[122] = 66;
            faceBottom[182] = 67;
            faceBottom[93] = 68;
            faceBottom[132] = 68;
            faceBottom[242] = 69;
            faceBottom[18] = 70;
            faceBottom[231] = 71;
            faceBottom[101] = 71;
            faceBottom[134] = 73;
            faceBottom[149] = 75;
            faceBottom[177] = 75;
            faceBottom[181] = 75;
            faceBottom[77] = 76;
            faceBottom[130] = 76;
            faceBottom[150] = 77;
            faceBottom[222] = 78;
            faceBottom[198] = 79;
            faceBottom[211] = 80;
            faceBottom[230] = 80;
            faceBottom[215] = 82;
            faceBottom[229] = 83;
            faceBottom[223] = 84;
            faceBottom[165] = 85;
            faceBottom[206] = 86;
            faceBottom[227] = 87;
            faceBottom[221] = 90;
            faceBottom[236] = 91;
            faceBottom[129] = 91;
            faceBottom[179] = 91;
            faceBottom[155] = 92;
            faceBottom[224] = 93;
            faceBottom[73] = 93;
            faceBottom[217] = 94;
            faceBottom[237] = 94;
            faceBottom[133] = 94;
            faceBottom[125] = 95;
            faceBottom[170] = 97;
            faceBottom[220] = 99;
            faceBottom[151] = 100;
            faceBottom[194] = 105;
            faceBottom[192] = 107;
            faceBottom[136] = 110;
            faceBottom[183] = 111;
            faceBottom[185] = 112;
            faceBottom[196] = 113;
            faceBottom[204] = 115;
            faceBottom[238] = 115;
            faceBottom[147] = 120;
            faceBottom[163] = 124;
            faceBottom[201] = 128;
            faceBottom[187] = 128;
            faceBottom[202] = 130;
            faceBottom[203] = 132;
            faceBottom[189] = 135;
            faceBottom[166] = 137;
            faceBottom[219] = 146;
            faceBottom[153] = 146;
            faceBottom[225] = 200;
            faceBottom[173] = 220;
            faceBottom[146] = 223;
            faceBottom[91] = 233;
            faceBottom[118] = 244;
            faceBottom[98] = 254;
            faceBottom[80] = 255;
            faceBottom[100] = 312;
            faceBottom[200] = 343;
            faceBottom[228] = 360;
            faceBottom[92] = 421;
            faceBottom[152] = 430;
            faceBottom[104] = 486;
            faceBottom[96] = 513;
            faceBottom[76] = 547;
            faceBottom[180] = 676;
            faceBottom[188] = 698;
            faceBottom[88] = 764;
            faceBottom[108] = 836;
            faceBottom[112] = 838;
            faceBottom[8] = 844;
            faceBottom[84] = 865;
            faceBottom[176] = 872;
            faceBottom[168] = 918;
            faceBottom[12] = 948;
            faceBottom[160] = 973;
            faceBottom[72] = 974;
            faceBottom[116] = 1248;
            faceBottom[184] = 1267;
            faceBottom[172] = 1287;
            faceBottom[4] = 1364;
            faceBottom[148] = 1384;
            faceBottom[16] = 1469;
            faceBottom[68] = 1498;
            faceBottom[20] = 1582;
            faceBottom[164] = 1879;
            faceBottom[48] = 1899;
            faceBottom[144] = 1937;
            faceBottom[52] = 1962;
            faceBottom[64] = 1986;
            faceBottom[156] = 2004;
            faceBottom[32] = 2106;
            faceBottom[128] = 2108;
            faceBottom[60] = 2334;
            faceBottom[1] = 2520;
            faceBottom[28] = 2647;
            faceBottom[56] = 2746;
            faceBottom[24] = 2772;
            faceBottom[124] = 3487;
            faceBottom[120] = 4089;
            faceBottom[50] = 10636;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_DOVER] = mapInfo;
        }

        public static void LoadOreTothtMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_TOTHT] = mapInfo;
        }

        public static void LoadOreGlediusNubisMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_GLEDIUS_NUBIS] = mapInfo;
        }

        public static void LoadOreCaputalisNubisMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_CAPUTALIS_NUBIS] = mapInfo;
        }

        public static void LoadVanilla()
        {
            OI_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );
            OI.Ores = OI_ORES;
            SPATAT_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );
            SPATAT.Ores = SPATAT_ORES;
            ENITOR_ORES = PlanetMapProfile.BuildOreMap(
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
            ENITOR.Ores = ENITOR_ORES;
            EREMUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            EREMUS_NUBIS.Ores = EREMUS_NUBIS_ORES;
            DOVER_ORES = PlanetMapProfile.BuildOreMap(
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
            DOVER.Ores = DOVER_ORES;
            TOTHT_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );
            TOTHT.Ores = TOTHT_ORES;
            GLEDIUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );
            GLEDIUS_NUBIS.Ores = GLEDIUS_NUBIS_ORES;
            CAPUTALIS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );
            CAPUTALIS_NUBIS.Ores = CAPUTALIS_NUBIS_ORES;
        }

        public static void LoadExtendedSurvival()
        {
            OI_ORES = PlanetMapProfile.BuildOreMap(
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
            OI.Ores = OI_ORES;
            SPATAT_ORES = PlanetMapProfile.BuildOreMap(
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
            SPATAT.Ores = SPATAT_ORES;
            ENITOR_ORES = PlanetMapProfile.BuildOreMap(
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
            ENITOR.Ores = ENITOR_ORES;
            EREMUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            EREMUS_NUBIS.Ores = EREMUS_NUBIS_ORES;
            DOVER_ORES = PlanetMapProfile.BuildOreMap(
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
            DOVER.Ores = DOVER_ORES;
            TOTHT_ORES = PlanetMapProfile.BuildOreMap(
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
            TOTHT.Ores = TOTHT_ORES;
            GLEDIUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            GLEDIUS_NUBIS.Ores = GLEDIUS_NUBIS_ORES;
            CAPUTALIS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            CAPUTALIS_NUBIS.Ores = CAPUTALIS_NUBIS_ORES;
        }

        public static void LoadBetterStoneVanilla()
        {
            OI_ORES = PlanetMapProfile.BuildOreMap(
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
            OI.Ores = OI_ORES;
            SPATAT_ORES = PlanetMapProfile.BuildOreMap(
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
            SPATAT.Ores = SPATAT_ORES;
            ENITOR_ORES = PlanetMapProfile.BuildOreMap(
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
            ENITOR.Ores = ENITOR_ORES;
            EREMUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            EREMUS_NUBIS.Ores = EREMUS_NUBIS_ORES;
            DOVER_ORES = PlanetMapProfile.BuildOreMap(
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
            DOVER.Ores = DOVER_ORES;
            TOTHT_ORES = PlanetMapProfile.BuildOreMap(
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
            TOTHT.Ores = TOTHT_ORES;
            GLEDIUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            GLEDIUS_NUBIS.Ores = GLEDIUS_NUBIS_ORES;
            CAPUTALIS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            CAPUTALIS_NUBIS.Ores = CAPUTALIS_NUBIS_ORES;
        }

        public static void LoadBetterStoneExtendedSurvival()
        {
            OI_ORES = PlanetMapProfile.BuildOreMap(
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
            OI.Ores = OI_ORES;
            SPATAT_ORES = PlanetMapProfile.BuildOreMap(
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
                    BetterStoneIntegrationProfile.Porphyry_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            SPATAT.Ores = SPATAT_ORES;
            ENITOR_ORES = PlanetMapProfile.BuildOreMap(
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
            ENITOR.Ores = ENITOR_ORES;
            EREMUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
            EREMUS_NUBIS.Ores = EREMUS_NUBIS_ORES;
            DOVER_ORES = PlanetMapProfile.BuildOreMap(
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
            DOVER.Ores = DOVER_ORES;
            TOTHT_ORES = PlanetMapProfile.BuildOreMap(
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
            TOTHT.Ores = TOTHT_ORES;
            GLEDIUS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
                    BetterStoneIntegrationProfile.Porphyry_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            GLEDIUS_NUBIS.Ores = GLEDIUS_NUBIS_ORES;
            CAPUTALIS_NUBIS_ORES = PlanetMapProfile.BuildOreMap(
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
                    BetterStoneIntegrationProfile.Porphyry_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01,
                    BetterStoneIntegrationProfile.Petzite_01,
                    BetterStoneIntegrationProfile.Electrum_01
                }
            );
            CAPUTALIS_NUBIS.Ores = CAPUTALIS_NUBIS_ORES;
        }

        // Ore Maps
        public static List<PlanetProfile.OreMapInfo> OI_ORES;
        public static List<PlanetProfile.OreMapInfo> SPATAT_ORES;
        public static List<PlanetProfile.OreMapInfo> ENITOR_ORES;
        public static List<PlanetProfile.OreMapInfo> EREMUS_NUBIS_ORES;
        public static List<PlanetProfile.OreMapInfo> DOVER_ORES;
        public static List<PlanetProfile.OreMapInfo> TOTHT_ORES;
        public static List<PlanetProfile.OreMapInfo> GLEDIUS_NUBIS_ORES;
        public static List<PlanetProfile.OreMapInfo> CAPUTALIS_NUBIS_ORES;

        public static readonly PlanetProfile.MeteorImpactInfo OI_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "Stones",
                    modifierId = "Oi",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo SPATAT_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "Stones",
                    modifierId = "Spatat",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo TOTHT_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthDesertArea",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo GLEDIUS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "Europa",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo EREMUS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "Mars",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo ENITOR_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "AlienDesertArea",
                    chanceToSpawn = 1f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo DOVER_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "EarthSnowArea",
                    chanceToSpawn = 0.25f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthForestArea",
                    chanceToSpawn = 0.5f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "EarthDesertArea",
                    chanceToSpawn = 0.25f
                }
            }
        };

        public static readonly PlanetProfile.MeteorImpactInfo CAPUTALIS_NUBIS_METEOR = new PlanetProfile.MeteorImpactInfo()
        {
            enabled = true,
            chanceToSpawn = 0.15f,
            stones = new PlanetProfile.MeteorStonesInfo[] {
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "StoneCoverageIronCore",
                    modifierId = "Moon",
                    chanceToSpawn = 0.75f
                },
                new PlanetProfile.MeteorStonesInfo()
                {
                    groupId = "SnowCoverageIronCore",
                    modifierId = "Moon",
                    chanceToSpawn = 0.25f
                }
            }
        };

        // Planets

        public static readonly PlanetProfile OI = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(100, 100),
            TargetColor = "#abab9a",
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 0, 2, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.4f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 10, 120),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.SmallGroup,
            MeteorImpact = OI_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile SPATAT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#616c83",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 0.45f, 0, 25, 2.5f, 0.5f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -75, 5),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = SPATAT_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile ENITOR = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.85f, 80, 3, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.05f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 25),
            Water = PlanetMapProfile.GetWater(true, 1.0125f, -0.4f, 0.15f, 0.05f),
            SizeRange = new Vector2(50, 70),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = ENITOR_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile EREMUS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_WOLF,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.6f, 0.35f, 50, 2, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(1.15f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 15, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(60, 80),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = EREMUS_NUBIS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile DOVER = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.5f, 0.9f, 120, 6, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1.1f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.01305f, -0.4f, 0, 0),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = DOVER_METEOR,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile TOTHT = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_01,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1.25f, 0.75f, 120, 6, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(1.4f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Hot, 15, 50),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = TOTHT_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile GLEDIUS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.35f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = GLEDIUS_NUBIS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

        public static readonly PlanetProfile CAPUTALIS_NUBIS = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.ExtendedSurvival,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_02,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 0.3f, 0, 40, 0.5f, 0.5f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(0.42f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = CAPUTALIS_NUBIS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
