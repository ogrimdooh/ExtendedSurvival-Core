using Sandbox.Definitions;
using System.Collections.Concurrent;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class AlmiranteOrlocProfile
    {

        public const ulong OBJECT85_MODID = 1662457289;

        public const string DEFAULT_OBJECT85 = "OBJETO_85";

        // Objeto 85

        public static void ApplyObject85Settings(MyPlanetGeneratorDefinition definition)
        {
            string[] materialsToRemove = new string[]
            {
                VoxelMaterialMapProfile.Ice_02,
                VoxelMaterialMapProfile.Ice_01
            };
            foreach (var material in definition.SurfaceMaterialTable.Where(x => materialsToRemove.Contains(x.Material)))
            {
                material.Material = VoxelMaterialMapProfile.StoneIce_01;
            }
        }

        static AlmiranteOrlocProfile()
        {
            LoadObject85OreMapInfo();
            OBJECT85.Ores = VanilaMapProfile.ALIEN_ORES;
        }

        private static void LoadObject85OreMapInfo()
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_OBJECT85] = mapInfo;
        }

        public static readonly PlanetProfile OBJECT85 = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = OBJECT85_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1, 0, 80, 1, 0.5f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(0.3f, 7.0f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
