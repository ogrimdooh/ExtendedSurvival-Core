﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ElindisMapProfile
    {

        public const ulong PYKE_MODID = 3028738424;

        public const string DEFAULT_PYKE = "PYKE";

        static ElindisMapProfile()
        {
            LoadPikeOreMapInfo();
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

        private static void LoadPikeOreMapInfo()
        {
            var mapInfo = new PlanetOreMapProfile.PlanetOreMapInfo();

            var faceFront = new ConcurrentDictionary<byte, long>();
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
            faceFront[50] = 25856;
            mapInfo.FaceInfo[PlanetOreMapProfile.PlanetOreMapFace.Front] = faceFront;

            var faceBack = new ConcurrentDictionary<byte, long>();
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

            PlanetOreMapProfile.PLANET_OREMAP_INFO[DEFAULT_PYKE] = mapInfo;
        }

        private static void LoadVanilla()
        {
            PYKE_ORES = PlanetMapProfile.BuildOreMap(
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
            PYKE.Ores = PYKE_ORES;
        }

        private static void LoadExtendedSurvival()
        {
            PYKE_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                    PlanetMapProfile.Plutonium_01
                }
            );
            PYKE.Ores = PYKE_ORES;
        }

        private static void LoadBetterStoneVanilla()
        {
            PYKE_ORES = PlanetMapProfile.BuildOreMap(
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
            PYKE.Ores = PYKE_ORES;
        }

        private static void LoadBetterStoneExtendedSurvival()
        {
            PYKE_ORES = PlanetMapProfile.BuildOreMap(
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
                    PlanetMapProfile.Platinum_01,
                    BetterStoneIntegrationProfile.Sperrylite_01,
                    BetterStoneIntegrationProfile.Niggliite_01
                },
                new string[]
                {
                    PlanetMapProfile.Plutonium_01,
                    BetterStoneIntegrationProfile.Cooperite_01
                }
            );
            PYKE.Ores = PYKE_ORES;
        }

        // Ore Maps
        public static List<PlanetProfile.OreMapInfo> PYKE_ORES;

        // Planets

        public static readonly PlanetProfile PYKE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = PYKE_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, 0.25f, 0.5f, 3f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1.5f, 0, 60, 2.0f, 0.75f, 0.25f),
            Gravity = PlanetMapProfile.GetGravity(1.42f, 3.5f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 70, 165),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(115, 125),
            Type = PlanetProfile.PlanetType.Planet,
            GroupType = PlanetProfile.OreGroupType.Concentrated,
            MeteorImpact = VanilaMapProfile.MARS_METEOR,
            SuperficialMining = PlanetMapProfile.DISABLE_SUPERFICIAL_MINING
        };

    }

}
