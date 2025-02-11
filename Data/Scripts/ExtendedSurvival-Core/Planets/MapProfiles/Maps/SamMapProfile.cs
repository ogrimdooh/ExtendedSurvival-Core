﻿using Sandbox.Definitions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class SamMapProfile
    {

        public const ulong HELIOSTERRAFORMED_MODID = 2781746013;
        public const ulong HELIOSTERRAFORMEDWM_MODID = 2783291521;

        public const string DEFAULT_HELIOSTERRAFORMED = "HELIOSTERRAFORMED";
        public const string DEFAULT_HELIOSTERRAFORMEDWM = "HELIOSTERRAFORMEDWM";

        public const string Helios_Sand_02 = "Helios_Sand_02";
        public const string Helios_DesertRocks = "Helios_DesertRocks";

        public const string HeliosTE_Ice = "HeliosTE_Ice";
        public const string HeliosWM_Ice = "HeliosWM_Ice";

        public const string Helios_Grass = "Helios_Grass";
        public const string Helios_Grass_old = "Helios_Grass_old";
        public const string Helios_HighGrass = "Helios_HighGrass";

        public const string Helios_Lava = "Helios_Lava";

        public const string Helios_Gravel = "Helios_Gravel";

        public static void ApplyHeliosTerraformedSettings(MyPlanetGeneratorDefinition definition)
        {
            // Constants
            var grassLayerSize = 1;
            var dirtyLayerSize = 9;
            var materialsToRemove = new Dictionary<string, string>()
            {
                { Helios_Gravel, VoxelMaterialMapProfile.Sand_02 },
                { HeliosWM_Ice, VoxelMaterialMapProfile.StoneIce_01 },
                { HeliosTE_Ice, VoxelMaterialMapProfile.StoneIce_01 },
                { VoxelMaterialMapProfile.Ice, VoxelMaterialMapProfile.StoneIce_01 },
                { Helios_Lava, VoxelMaterialMapProfile.LavaSoil_01 }
            };
            var materialsToRemoveIfOver128 = new Dictionary<string, string>()
            {
                { Helios_Grass, VoxelMaterialMapProfile.Grass },
                { Helios_Grass_old, VoxelMaterialMapProfile.GrassOld },
                { Helios_HighGrass, VoxelMaterialMapProfile.Grass_02 },
                { Helios_DesertRocks, VoxelMaterialMapProfile.DustyRocks },
                { Helios_Sand_02, VoxelMaterialMapProfile.PertamSand }
            };
            var materialsToChangeDepth = new Dictionary<string, float>()
            {
                { Helios_Grass, grassLayerSize },
                { Helios_Grass_old, grassLayerSize },
                { Helios_HighGrass, grassLayerSize },
                { VoxelMaterialMapProfile.Grass, grassLayerSize },
            };
            var materialsToAddDirty = new Dictionary<string, float>()
            {
                { Helios_HighGrass, dirtyLayerSize },
                { Helios_Grass, dirtyLayerSize },
                { Helios_Grass_old, dirtyLayerSize },
                { VoxelMaterialMapProfile.Grass, dirtyLayerSize }
            };
            // Set default material
            definition.DefaultSurfaceMaterial.Material = VoxelMaterialMapProfile.Grass;
            definition.DefaultSurfaceMaterial.MaxDepth = grassLayerSize + dirtyLayerSize;
            definition.DefaultSurfaceMaterial.Layers = new MyPlanetMaterialLayer[] 
            { 
                new MyPlanetMaterialLayer()
                {
                    Material = VoxelMaterialMapProfile.Grass,
                    Depth = grassLayerSize
                },
                new MyPlanetMaterialLayer()
                {
                    Material = VoxelMaterialMapProfile.DirtySoil_01,
                    Depth = dirtyLayerSize
                }
            };
            // Set replaces
            PlanetsOverride.DoApplyPlanetDefinitionChanges(definition, materialsToRemove, materialsToRemoveIfOver128, materialsToChangeDepth, materialsToAddDirty);
        }

        static SamMapProfile()
        { 
            LoadHeliosTerraformedOreMapInfo();
            LoadHeliosTerraformedWmOreMapInfo();
            HELIOSTERRAFORMED.Ores = VanilaMapProfile.EARTHLIKE_ORES;
            HELIOSTERRAFORMEDWM.Ores = VanilaMapProfile.EARTHLIKE_ORES;
        }

        private static void LoadHeliosTerraformedOreMapInfo()
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
            faceBack[176] = 2046;
            faceBack[112] = 2047;
            faceBack[8] = 2048;
            faceBack[108] = 2048;
            faceBack[168] = 2048;
            faceBack[84] = 2048;
            faceBack[12] = 2304;
            faceBack[160] = 2304;
            faceBack[72] = 2304;
            faceBack[172] = 3071;
            faceBack[184] = 3072;
            faceBack[116] = 3072;
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
            faceBack[50] = 25847;
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
            faceLeft[176] = 2046;
            faceLeft[112] = 2047;
            faceLeft[8] = 2048;
            faceLeft[108] = 2048;
            faceLeft[168] = 2048;
            faceLeft[84] = 2048;
            faceLeft[12] = 2304;
            faceLeft[160] = 2304;
            faceLeft[72] = 2304;
            faceLeft[172] = 3071;
            faceLeft[184] = 3072;
            faceLeft[116] = 3072;
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
            faceLeft[50] = 25847;
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
            faceRight[176] = 2046;
            faceRight[112] = 2047;
            faceRight[8] = 2048;
            faceRight[108] = 2048;
            faceRight[168] = 2048;
            faceRight[84] = 2048;
            faceRight[12] = 2304;
            faceRight[160] = 2304;
            faceRight[72] = 2304;
            faceRight[172] = 3071;
            faceRight[184] = 3072;
            faceRight[116] = 3072;
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
            faceRight[50] = 25847;
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
            faceTop[176] = 2046;
            faceTop[112] = 2047;
            faceTop[8] = 2048;
            faceTop[108] = 2048;
            faceTop[168] = 2048;
            faceTop[84] = 2048;
            faceTop[12] = 2304;
            faceTop[160] = 2304;
            faceTop[72] = 2304;
            faceTop[172] = 3071;
            faceTop[184] = 3072;
            faceTop[116] = 3072;
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
            faceTop[50] = 25847;
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
            faceBottom[176] = 2046;
            faceBottom[112] = 2047;
            faceBottom[8] = 2048;
            faceBottom[108] = 2048;
            faceBottom[168] = 2048;
            faceBottom[84] = 2048;
            faceBottom[12] = 2304;
            faceBottom[160] = 2304;
            faceBottom[72] = 2304;
            faceBottom[172] = 3071;
            faceBottom[184] = 3072;
            faceBottom[116] = 3072;
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
            faceBottom[50] = 25847;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_HELIOSTERRAFORMED] = mapInfo;
        }

        private static void LoadHeliosTerraformedWmOreMapInfo()
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
            faceBack[176] = 2046;
            faceBack[112] = 2047;
            faceBack[8] = 2048;
            faceBack[108] = 2048;
            faceBack[168] = 2048;
            faceBack[84] = 2048;
            faceBack[12] = 2304;
            faceBack[160] = 2304;
            faceBack[72] = 2304;
            faceBack[172] = 3071;
            faceBack[184] = 3072;
            faceBack[116] = 3072;
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
            faceBack[50] = 25847;
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
            faceLeft[176] = 2046;
            faceLeft[112] = 2047;
            faceLeft[8] = 2048;
            faceLeft[108] = 2048;
            faceLeft[168] = 2048;
            faceLeft[84] = 2048;
            faceLeft[12] = 2304;
            faceLeft[160] = 2304;
            faceLeft[72] = 2304;
            faceLeft[172] = 3071;
            faceLeft[184] = 3072;
            faceLeft[116] = 3072;
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
            faceLeft[50] = 25847;
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
            faceRight[176] = 2046;
            faceRight[112] = 2047;
            faceRight[8] = 2048;
            faceRight[108] = 2048;
            faceRight[168] = 2048;
            faceRight[84] = 2048;
            faceRight[12] = 2304;
            faceRight[160] = 2304;
            faceRight[72] = 2304;
            faceRight[172] = 3071;
            faceRight[184] = 3072;
            faceRight[116] = 3072;
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
            faceRight[50] = 25847;
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
            faceTop[176] = 2046;
            faceTop[112] = 2047;
            faceTop[8] = 2048;
            faceTop[108] = 2048;
            faceTop[168] = 2048;
            faceTop[84] = 2048;
            faceTop[12] = 2304;
            faceTop[160] = 2304;
            faceTop[72] = 2304;
            faceTop[172] = 3071;
            faceTop[184] = 3072;
            faceTop[116] = 3072;
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
            faceTop[50] = 25847;
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
            faceBottom[176] = 2046;
            faceBottom[112] = 2047;
            faceBottom[8] = 2048;
            faceBottom[108] = 2048;
            faceBottom[168] = 2048;
            faceBottom[84] = 2048;
            faceBottom[12] = 2304;
            faceBottom[160] = 2304;
            faceBottom[72] = 2304;
            faceBottom[172] = 3071;
            faceBottom[184] = 3072;
            faceBottom[116] = 3072;
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
            faceBottom[50] = 25847;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Bottom] = faceBottom;

            mapInfo.ProcessAllInfo();

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_HELIOSTERRAFORMEDWM] = mapInfo;
        }

        // Planets

        public static readonly PlanetProfile HELIOSTERRAFORMED = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = HELIOSTERRAFORMED_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 180, 0.5f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0005f, -0.4f, 0, 0),
            SizeRange = new Vector2(60, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Helios_Grass", "Grass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Helios_Grass_old", "Grass_old"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Sand_02", "PertamSand"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Helios_HighGrass", "Grass_02", "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "DustyRocks", "Stone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "StoneIce_01"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Volcanic, "LavaSoil_01")
            )
        };

        public static readonly PlanetProfile HELIOSTERRAFORMEDWM = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = HELIOSTERRAFORMEDWM_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 180, 0.5f, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.0316f, -0.4f, 0, 0),
            SizeRange = new Vector2(60, 75),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.EARTH_SUPERFICIAL_MINING,
            Biome = PlanetMapProfile.BuildBiomes(
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Forest, "Helios_Grass", "Grass"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Savanna, "Helios_Grass_old", "Grass_old"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Desert, "Sand_02", "PertamSand"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Tundra, "Helios_HighGrass", "Grass_02", "Snow"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Cliff, "DustyRocks", "Stone"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Frozen, "StoneIce_01"),
                PlanetMapProfile.GetBiome(PlanetProfile.BiomeTypes.Volcanic, "LavaSoil_01")
            )
        };

    }

}
