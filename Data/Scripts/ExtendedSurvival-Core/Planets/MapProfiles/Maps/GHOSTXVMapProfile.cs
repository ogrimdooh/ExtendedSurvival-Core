using Sandbox.Definitions;
using Sandbox.ModAPI;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class GHOSTXVMapProfile
    {

        public const ulong AVALAN_MODID = 834586559;
        public const ulong NYOTA_MODID = 692155257;

        public const string DEFAULT_AVALAN = "AVALAN";
        public const string DEFAULT_NYOTA = "NYOTA";

        // Nyota

        public const string GhostSnow = "GhostSnow";

        // Avalan

        public const string DesertStone = "DesertStone";
        public const string AvalanSand = "AvalanSand";

        public const string AvalanSoil = "AvalanSoil";
        public const string AvalanGrass = "AvalanGrass";
        public const string WoodForest = "WoodForest";
        public const string DeadGrass2 = "DeadGrass2";
        public const string DesertGrassX = "DesertGrassX";
        public const string WoodsMountain = "WoodsMountain";

        public const string FrozenIce = "FrozenIce";
        public const string AvalanSnow = "AvalanSnow";

        static GHOSTXVMapProfile()
        {
            LoadAvalanOreMapInfo();
            LoadNyotaOreMapInfo();
            AVALAN.Ores = VanilaMapProfile.EARTHLIKE_ORES;
            NYOTA.Ores = VanilaMapProfile.MOON_ORES;
        }

        public static void ApplyNyotaSettings(MyPlanetGeneratorDefinition definition)
        {
            definition.DefaultSubSurfaceMaterial = new MyPlanetMaterialDefinition()
            {
                Material = VoxelMaterialMapProfile.StoneIce_01
            };
        }

        public static void ApplyAvalanSettings(MyPlanetGeneratorDefinition definition)
        {
            string[] materialsToRemove = new string[]
            {
                VoxelMaterialMapProfile.Platinum_01,
                VoxelMaterialMapProfile.Uraninite_01,
                VoxelMaterialMapProfile.Gold_01
            };
            definition.SurfaceMaterialTable = definition.SurfaceMaterialTable.Where(x => !materialsToRemove.Contains(x.Material)).ToArray();
            foreach (var group in definition.MaterialGroups)
            {
                foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToRemove.Contains(y.Material))))
                {
                    rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer()
                    {
                        Material = materialsToRemove.Contains(x.Material) ? VoxelMaterialMapProfile.StoneIce_01 : x.Material,
                        Depth = x.Depth
                    }).ToArray();
                }
            }
        }

        private static void LoadNyotaOreMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_NYOTA] = mapInfo;
        }

        private static void LoadAvalanOreMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_AVALAN] = mapInfo;
        }

        public static readonly PlanetProfile AVALAN = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = AVALAN_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 80, 2, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 8),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.011f, -0.4f, 0, 0),
            SizeRange = new Vector2(240, 280),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "AvalanGrass", "WoodForest"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "DesertGrassX", "DeadGrass2"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "AvalanSand", "DesertStone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "AvalanSnow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "AvalanRocks", "WoodsMountain"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "FrozenIce", "StoneIce_01")
            )
        };

        public static readonly PlanetProfile NYOTA = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = NYOTA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            ColorInfluence = new Vector2I(15, 15),
            TargetColor = "#FFFFFF",
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 25),
            Type = PlanetProfile.PlanetType.Moon,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "Stone_05"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "GhostSnow", "Ice_02", "StoneIce_01")
            )
        };

    }

}
