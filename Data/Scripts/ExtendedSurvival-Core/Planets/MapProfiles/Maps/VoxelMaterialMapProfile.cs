using System;
using System.Collections.Generic;
using System.Linq;
using static ExtendedSurvival.Core.PlanetMapProfile;

namespace ExtendedSurvival.Core
{
    public static class VoxelMaterialMapProfile
    {

        public class VoxelOreReplace
        {

            public string[] TargetVoxels { get; set; }
            public string OreToMine { get; set; }
            public float MineRatio { get; set; }

        }

        public class VoxelType
        {

            public string Name { get; set; }
            public VoxelMaterialProfile DefaultInfo { get; set; }

        }

        // Valina
        public const string Iron_01 = "Iron_01";
        public const string Iron_02 = "Iron_02";
        public const string Nickel_01 = "Nickel_01";
        public const string Silicon_01 = "Silicon_01";
        public const string Cobalt_01 = "Cobalt_01";
        public const string Gold_01 = "Gold_01";
        public const string Silver_01 = "Silver_01";
        public const string Platinum_01 = "Platinum_01";
        public const string Magnesium_01 = "Magnesium_01";
        public const string Uraninite_01 = "Uraninite_01";
        public const string Ice_01 = "Ice_01";
        public const string Ice_02 = "Ice_02";
        public const string Ice_03 = "Ice_03";
        public const string Snow = "Snow";
        public const string Ice = "Ice";
        public const string IceEuropa2 = "IceEuropa2";
        public const string AlienIce = "AlienIce";
        public const string AlienIce_03 = "AlienIce_03";
        public const string AlienSnow = "AlienSnow";
        public const string TritonIce = "TritonIce";

        public const string Grass = "Grass";
        public const string GrassBare = "Grass bare";
        public const string RocksGrass = "Rocks_grass";
        public const string GrassOld = "Grass_old";
        public const string GrassOldBare = "Grass_old bare";
        public const string Grass_02 = "Grass_02";
        public const string WoodsGrass = "Woods_grass";
        public const string WoodsGrassBare = "Woods_grass bare";
        public const string Soil = "Soil";
        public const string AlienGreenGrass = "AlienGreenGrass";
        public const string AlienGreenGrassBare = "AlienGreenGrass bare";
        public const string AlienRockyTerrain = "AlienRockyTerrain";
        public const string AlienRockGrass = "AlienRockGrass";
        public const string AlienRockGrassBare = "AlienRockGrass bare";
        public const string AlienOrangeGrass = "AlienOrangeGrass";
        public const string AlienOrangeGrassBare = "AlienOrangeGrass bare";
        public const string AlienYellowGrass = "AlienYellowGrass";
        public const string AlienYellowGrassBare = "AlienYellowGrass bare";
        public const string AlienSoil = "AlienSoil";
        public const string Sand_02 = "Sand_02";
        public const string MarsSoil = "MarsSoil";
        public const string AlienSand = "AlienSand";
        public const string SmallMoonRocks = "SmallMoonRocks";
        public const string MoonSoil = "MoonSoil";
        public const string CrackedSoil = "CrackedSoil";
        public const string DustyRocks = "DustyRocks";
        public const string DustyRocks2 = "DustyRocks2";
        public const string DustyRocks3 = "DustyRocks3";
        public const string PertamSand = "PertamSand";

        // Helios Planets
        public const string Helios_Sand_02 = "Helios_Sand_02";
        public const string Helios_Grass = "Helios_Grass";
        public const string Helios_Grass_old = "Helios_Grass_old";
        public const string Helios_HighGrass = "Helios_HighGrass";
        public const string Helios_Lava = "Helios_Lava";

        public static readonly string[] AlienSoilVoxels = new string[]
        {
            AlienGreenGrass,
            AlienGreenGrassBare,
            AlienRockyTerrain,
            AlienRockGrass,
            AlienRockGrassBare,
            AlienOrangeGrass,
            AlienOrangeGrassBare,
            AlienYellowGrass,
            AlienYellowGrassBare,
            AlienSoil,
            // Captain Arthur
            CaptainArthurMapProfile.Redsoil,            
            // Major John
            MajorJonMapProfile.Soil_Trelan,
            MajorJonMapProfile.Grass_Trelan,
            MajorJonMapProfile.Grass_Trelan_bare
        };

        public static readonly string[] SoilVoxels = new string[] 
        {
            Grass,
            GrassBare,
            RocksGrass,
            GrassOld,
            GrassOldBare,
            Grass_02,
            WoodsGrass,
            WoodsGrassBare,
            Soil,
            Helios_Grass,
            Helios_Grass_old,
            Helios_HighGrass,
            // Infinite
            InfiniteMapProfile.ValkorGrass,
            InfiniteMapProfile.ValkorTundra,
            InfiniteMapProfile.ValkorGrass2,
            InfiniteMapProfile.ValkorGrass3,
            InfiniteMapProfile.OrcusGrass,
            InfiniteMapProfile.OrcusGrass2,
            InfiniteMapProfile.TundraSoil,
            // Captain Arthur
            CaptainArthurMapProfile.MESoil,
            CaptainArthurMapProfile.SoilDOC,
            CaptainArthurMapProfile.MESteppe,
            CaptainArthurMapProfile.DarinusGrass,
            CaptainArthurMapProfile.DarinusGrass2,
            CaptainArthurMapProfile.PWoodsGrass,
            CaptainArthurMapProfile.PurpleGrass,
            CaptainArthurMapProfile.GrassDOC,
            CaptainArthurMapProfile.Grass_oldDOC,
            CaptainArthurMapProfile.Woods_grassDOC,
            // Fizzy
            FizzyMapProfile.Chimera_Grass,
            FizzyMapProfile.Chimera_Dirt_Grass,
            FizzyMapProfile.Chimera_Light_Grass,
            // GHOSTXV
            GHOSTXVMapProfile.AvalanGrass,
            GHOSTXVMapProfile.WoodForest,
            GHOSTXVMapProfile.DeadGrass2,
            GHOSTXVMapProfile.DesertGrassX,
            GHOSTXVMapProfile.WoodsMountain,
            // Sam
            SamMapProfile.Helios_Grass,
            SamMapProfile.Helios_Grass_old,
            SamMapProfile.Helios_HighGrass,
            // Major John
            MajorJonMapProfile.Grass_old_Satreus,
            MajorJonMapProfile.TealBlueGrass,
            MajorJonMapProfile.TealRocksGrass,
            MajorJonMapProfile.TealSnowGrass,
            MajorJonMapProfile.OrlundaRedSoil_1,
            MajorJonMapProfile.OrlundaRedSoil_2,
            MajorJonMapProfile.OrlundaRedSoil_3,
            MajorJonMapProfile.Woods_grass_long,
            // Elindis
            ElindisMapProfile.SaprimentasWetFlowers,
            ElindisMapProfile.SaprimentasDryFlowers
        };

        public static readonly string[] MudVoxels = new string[]
        {
            // Captain Arthur
            CaptainArthurMapProfile.MEwoods,
            CaptainArthurMapProfile.MEwoodsgrass,
            // GHOSTXV
            GHOSTXVMapProfile.AvalanSoil,
            // Infinite
            InfiniteMapProfile.AquaticGrass1,
            InfiniteMapProfile.aquatic2,
            InfiniteMapProfile.aquatic3,
            // Major John
            MajorJonMapProfile.TealBlack_Soil,
            MajorJonMapProfile.TealBlack_Soil_bare
        };

        public static readonly string[] VulcanicSoilVoxels = new string[]
        {
            // Elindis
            ElindisMapProfile.PykeLava,
            ElindisMapProfile.PykeLavaRock,
            // Sam
            SamMapProfile.Helios_Lava
        };

        public static readonly string[] DesertSoilVoxels = new string[] 
        {
            Sand_02,
            MarsSoil,
            AlienSand,
            CrackedSoil,
            DustyRocks,
            DustyRocks2,
            DustyRocks3,
            PertamSand,
            Helios_Sand_02,
            Helios_Lava,
            // Infinite
            InfiniteMapProfile.ValkorSand,
            InfiniteMapProfile.ValkorDesert,
            InfiniteMapProfile.ValkorSandstone,
            InfiniteMapProfile.AquaticSand,            
            // Captain Arthur
            CaptainArthurMapProfile.Saltflat,
            CaptainArthurMapProfile.Redsand,
            CaptainArthurMapProfile.DOCSand_02,
            // Elindis
            ElindisMapProfile.PykeSand,
            // Fizzy
            FizzyMapProfile.Chimera_Sand,
            FizzyMapProfile.Chimera_Sand2,
            // GHOSTXV
            GHOSTXVMapProfile.AvalanSand,
            // Sam
            SamMapProfile.Helios_Sand_02,
            // Major John
            MajorJonMapProfile.Desert_01_Satreus,
            MajorJonMapProfile.Desert_01_Satreus_soil,
            MajorJonMapProfile.Desert_01_red_Satreus,
            MajorJonMapProfile.Ground_red_Satreus,
            MajorJonMapProfile.OrlundaBeach,
            // Shard
            ShardMapProfile.SafinaSand,
            ShardMapProfile.SafinaRedSand,
            ShardMapProfile.SafinaLakebed
        };

        public static readonly string[] AsteroidSoilVoxels = new string[]
        {
            MajorJonMapProfile.MoonRock_grey_qun,
            MajorJonMapProfile.MoonRock_grey2_qun,
            MajorJonMapProfile.MoonRock_black2_qun
        };

        public static readonly string[] MoomSoilVoxels = new string[] 
        {
            MoonSoil,
            SmallMoonRocks,
            // Captain Arthur
            CaptainArthurMapProfile.MoonAlien,
            CaptainArthurMapProfile.MoonAlienBare,
            // Elindis
            ElindisMapProfile.PykeSoil,
            ElindisMapProfile.PykeGravel,
            //Fizzy
            FizzyMapProfile.Zira_Soil,
            // MLT
            MLTModsMapProfile.IreneSoil,
            // Major John
            MajorJonMapProfile.DustyRocks3_Satreus,
            MajorJonMapProfile.MoonSoil_grey_qun,
            MajorJonMapProfile.MoonSoil_grey2_qun,
            MajorJonMapProfile.MoonSoil_red2_qun,
            MajorJonMapProfile.MoonSoil_black2_qun,
            // Shard
            ShardMapProfile.ThanianSoil,
            ShardMapProfile.RishaSoil,
            // Major John
            MajorJonMapProfile.OrlundaSnow
        };

        public static readonly string[] ESStoneIce = new string[]
        {
            // Infinite
            InfiniteMapProfile.RedIce,
            InfiniteMapProfile.Ice_02New,
            InfiniteMapProfile.BlackIce,
            InfiniteMapProfile.AlienYellowGrass,
            InfiniteMapProfile.PenumbraTerrain,
            // Captain Arthur
            CaptainArthurMapProfile.Beachsideice,
            CaptainArthurMapProfile.Mediumice,
            CaptainArthurMapProfile.Ice_03,
            CaptainArthurMapProfile.DarinusIce,
            CaptainArthurMapProfile.Ice_02DOC,
            //Fizzy
            FizzyMapProfile.Chimera_Ice,
            //Fizzy
            GHOSTXVMapProfile.FrozenIce,
            // MLT
            MLTModsMapProfile.SedoniaIce,
            // Sam
            SamMapProfile.HeliosTE_Ice,
            // Major John
            MajorJonMapProfile.Ice02_Satreus,
            MajorJonMapProfile.TohilIce01,
            MajorJonMapProfile.TohilIce02,
            MajorJonMapProfile.TohilIce03,
            // Shard
            ShardMapProfile.SafinaWater,
            // Major John
            MajorJonMapProfile.TealSea,
            MajorJonMapProfile.TealIce,
            MajorJonMapProfile.TealRiver,
            MajorJonMapProfile.TealShore1,
            MajorJonMapProfile.TealShore2,
            MajorJonMapProfile.TealShore3,
            MajorJonMapProfile.TealShore4,
            MajorJonMapProfile.TealShore5,
            MajorJonMapProfile.TealShore6,
            MajorJonMapProfile.OrlundaIce,
            MajorJonMapProfile.OrlundaLake
        };

        public static readonly string[] ESToxicIce = new string[] 
        {
            IceEuropa2,
            AlienIce,
            AlienIce_03,
            AlienSnow,
            // Infinite
            InfiniteMapProfile.ToxicIce,
            InfiniteMapProfile.AlienSnowNew,
            InfiniteMapProfile.SnowNew,
            InfiniteMapProfile.TritonIceNew,
            InfiniteMapProfile.HalcyonIce,
            // Captain Arthur
            CaptainArthurMapProfile.CraitIce,
            CaptainArthurMapProfile.AlienSnowSpider,
            //Fizzy
            FizzyMapProfile.Zira_Ice,
            //Fizzy
            FizzyMapProfile.Chimera_Snow,
            //GHOSTXV
            GHOSTXVMapProfile.AvalanSnow,
            GHOSTXVMapProfile.GhostSnow,
            // Major John
            MajorJonMapProfile.TohilSnow01,
            MajorJonMapProfile.TohilSnow02
        };

        public static readonly string[] SpaceNeeded = new string[] 
        {
            /* Vanilla */
            Iron_01,
            Iron_02,
            Nickel_01,
            Silicon_01,
            Cobalt_01,
            Gold_01,
            Silver_01,
            /* Extended Survival */
            Aluminum_01,
            Copper_01,
            Zinc_01,
            Lead_01,
            Sulfur_01,
            Carbon_01,
            Potassium_01,
            Lithium_01,
            Mercury_01,
            Iron_03,
            Iron_04,
            /* Better Stone */
            BetterStoneIntegrationProfile.Hapkeite_01,
            BetterStoneIntegrationProfile.Heazlewoodite_01,
            BetterStoneIntegrationProfile.Porphyry_01,
            BetterStoneIntegrationProfile.Cattierite_01,
            BetterStoneIntegrationProfile.Glaucodot_01,
            BetterStoneIntegrationProfile.Sinoite_01,
            BetterStoneIntegrationProfile.Pyrite_01,
            BetterStoneIntegrationProfile.Quartz_01,
            BetterStoneIntegrationProfile.Galena_01,
            BetterStoneIntegrationProfile.Chlorargyrite_01,
            BetterStoneIntegrationProfile.Electrum_01,
            BetterStoneIntegrationProfile.Taenite_01,
            BetterStoneIntegrationProfile.Cohenite_01,
            BetterStoneIntegrationProfile.Kamacite_01,
            BetterStoneIntegrationProfile.Petzite_01
        };

        public static readonly VoxelOreReplace[] VoxelReplaces = new VoxelOreReplace[]
        {
            new VoxelOreReplace()
            {
                TargetVoxels = MoomSoilVoxels,
                OreToMine = OreConstants.MOONSOIL_SUBTYPEID,
                MineRatio = UNCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = AlienSoilVoxels,
                OreToMine = OreConstants.ALIENSOIL_SUBTYPEID,
                MineRatio = VERYCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = SoilVoxels,
                OreToMine = OreConstants.SOIL_SUBTYPEID,
                MineRatio = VERYCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = DesertSoilVoxels,
                OreToMine = OreConstants.DESERTSOIL_SUBTYPEID,
                MineRatio = COMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = ESToxicIce,
                OreToMine = OreConstants.TOXICICE_SUBTYPEID,
                MineRatio = UNCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = ESStoneIce,
                OreToMine = OreConstants.STONEICE_SUBTYPEID,
                MineRatio = UNCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = MudVoxels,
                OreToMine = OreConstants.MUD_SUBTYPEID,
                MineRatio = VERYCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = VulcanicSoilVoxels,
                OreToMine = OreConstants.VULCANICSOIL_SUBTYPEID,
                MineRatio = VERYCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = AsteroidSoilVoxels,
                OreToMine = OreConstants.ASTEROIDSOIL_SUBTYPEID,
                MineRatio = VERYCOMMON_RATIO
            },
            // MTL
            new VoxelOreReplace()
            {
                TargetVoxels = new string[] { MLTModsMapProfile.SedoniaRegolith },
                OreToMine = MLTModsMapProfile.REGOLITH_SUBTYPEID,
                MineRatio = COMMON_RATIO
            },
            // Major Jon
            new VoxelOreReplace()
            {
                TargetVoxels = new string[] { MajorJonMapProfile.MoonRock_grey2_kimi },
                OreToMine = OreConstants.FERROUSMOONSOIL_SUBTYPEID,
                MineRatio = COMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = new string[] { MajorJonMapProfile.MoonRock_black2_kimi, MajorJonMapProfile.MoonSoil_red2_qun },
                OreToMine = OreConstants.FERROUSMOONSOIL_SUBTYPEID,
                MineRatio = UNCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = new string[] { MajorJonMapProfile.MoonRock_green2_kimi },
                OreToMine = OreConstants.CHROMEMOONSOIL_SUBTYPEID,
                MineRatio = UNCOMMON_RATIO
            },
            new VoxelOreReplace()
            {
                TargetVoxels = new string[] { MajorJonMapProfile.Low_Dens_Iron_Kimi },
                OreToMine = OreConstants.IRON_SUBTYPEID,
                MineRatio = EPIC_RATIO
            }
        };
        
        // ES Core
        public const string StoneIce_01 = "StoneIce_01";

        // ES Technology
        public const string Aluminum_01 = "Aluminum_01";
        public const string Copper_01 = "Copper_01";
        public const string Lead_01 = "Lead_01";
        public const string Sulfur_01 = "Sulfur_01";
        public const string Carbon_01 = "Carbon_01";
        public const string Potassium_01 = "Potassium_01";
        public const string Lithium_01 = "Lithium_01";
        public const string Zinc_01 = "Zinc_01";
        public const string Iridium_01 = "Iridium_01";
        public const string Titanium_01 = "Titanium_01";
        public const string Mercury_01 = "Mercury_01";
        public const string Beryllium_01 = "Beryllium_01";
        public const string Tungsten_01 = "Tungsten_01";
        public const string Plutonium_01 = "Plutonium_01";

        public const string Iron_03 = "Iron_03";
        public const string Iron_04 = "Iron_04";

        public static readonly string[] ESTechnologyVoxels = new string[]
        {
            Aluminum_01,
            Copper_01,
            Lead_01,
            Sulfur_01,
            Carbon_01,
            Potassium_01,
            Lithium_01,
            Zinc_01,
            Iridium_01,
            Titanium_01,
            Mercury_01,
            Beryllium_01,
            Tungsten_01,
            Plutonium_01,
            Iron_03,
            Iron_04
        };

        public const float VERYCOMMON_RATIO = 3;
        public const float COMMON_RATIO = 2;
        public const float UNCOMMON_RATIO = 1.5f;
        public const float RARE_RATIO = 1;
        public const float LEGENDARY_RATIO = 0.75f;
        public const float EPIC_RATIO = 0.5f;
        public const float DIVINE_RATIO = 0.25f;

        public const int VERYCOMMON_SPAWN = 10;
        public const int COMMON_SPAWN = 7;
        public const int UNCOMMON_SPAWN = 5;
        public const int RARE_SPAWN = 3;
        public const int LEGENDARY_SPAWN = 2;
        public const int EPIC_SPAWN = 1;
        public const int NO_SPAWN = 0;

        private static readonly VoxelMaterialProfile IRON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VERYCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = VERYCOMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile NICKEL_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = COMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile SILICON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = UNCOMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile COBALT_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile GOLD_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile SILVER_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile PLATINUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile MAGNEZIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile URANITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = RARE_SPAWN
        };

        private static readonly VoxelMaterialProfile STONE_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = RARE_SPAWN
        };

        private static readonly VoxelMaterialProfile SNOW_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = NO_SPAWN
        };

        private static readonly VoxelMaterialProfile EUROPA_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile ALIEN_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile ALIEN_SNOW_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = NO_SPAWN
        };

        private static readonly VoxelMaterialProfile TRITON_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = NO_SPAWN
        };

        // ES Technology

        private static readonly VoxelMaterialProfile ALUMINUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = COMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile ZINC_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = COMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile COPPER_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = COMMON_SPAWN
        };

        private static readonly VoxelMaterialProfile LEAD_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile SULFUR_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = LEGENDARY_SPAWN
        };

        private static readonly VoxelMaterialProfile CARBON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = LEGENDARY_SPAWN
        };

        private static readonly VoxelMaterialProfile POTASSIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile LITHIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile MERCURY_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = DIVINE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile PLUTONIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = DIVINE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile TITANIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile TUNGSTEN_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile IRIDIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly VoxelMaterialProfile BERYLLIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = EPIC_SPAWN
        };

        private static readonly Dictionary<string, VoxelMaterialProfile> PROFILES = new Dictionary<string, VoxelMaterialProfile>()
        {
            { Iron_01.ToUpper(), IRON_VOXEL_MATERIAL },
            { Iron_02.ToUpper(), IRON_VOXEL_MATERIAL },
            { Nickel_01.ToUpper(), NICKEL_VOXEL_MATERIAL },
            { Silicon_01.ToUpper(), SILICON_VOXEL_MATERIAL },
            { Cobalt_01.ToUpper(), COBALT_VOXEL_MATERIAL },
            { Gold_01.ToUpper(), GOLD_VOXEL_MATERIAL },
            { Silver_01.ToUpper(), SILVER_VOXEL_MATERIAL },
            { Platinum_01.ToUpper(), PLATINUM_VOXEL_MATERIAL },
            { Magnesium_01.ToUpper(), MAGNEZIUM_VOXEL_MATERIAL },
            { Uraninite_01.ToUpper(), URANITE_VOXEL_MATERIAL },
            { Ice_01.ToUpper(), ICE_VOXEL_MATERIAL },
            { Ice_02.ToUpper(), ICE_VOXEL_MATERIAL },
            { Ice_03.ToUpper(), ICE_VOXEL_MATERIAL },
            { Snow.ToUpper(), SNOW_VOXEL_MATERIAL },
            { Ice.ToUpper(), ICE_VOXEL_MATERIAL },
            { IceEuropa2.ToUpper(), EUROPA_ICE_VOXEL_MATERIAL },
            { AlienIce.ToUpper(), ALIEN_ICE_VOXEL_MATERIAL },
            { AlienIce_03.ToUpper(), ALIEN_ICE_VOXEL_MATERIAL },
            { AlienSnow.ToUpper(), ALIEN_SNOW_VOXEL_MATERIAL },
            { TritonIce.ToUpper(), TRITON_ICE_VOXEL_MATERIAL },
            // ES Core
            { StoneIce_01.ToUpper(), STONE_ICE_VOXEL_MATERIAL },
            // ES Technology
            { Aluminum_01.ToUpper(), ALUMINUM_VOXEL_MATERIAL },
            { Copper_01.ToUpper(), COPPER_VOXEL_MATERIAL },
            { Lead_01.ToUpper(), LEAD_VOXEL_MATERIAL },
            { Sulfur_01.ToUpper(), SULFUR_VOXEL_MATERIAL },
            { Carbon_01.ToUpper(), CARBON_VOXEL_MATERIAL },
            { Potassium_01.ToUpper(), POTASSIUM_VOXEL_MATERIAL },
            { Lithium_01.ToUpper(), LITHIUM_VOXEL_MATERIAL },
            { Zinc_01.ToUpper(), ZINC_VOXEL_MATERIAL },
            { Iridium_01.ToUpper(), IRIDIUM_VOXEL_MATERIAL },
            { Titanium_01.ToUpper(), TITANIUM_VOXEL_MATERIAL },
            { Mercury_01.ToUpper(), MERCURY_VOXEL_MATERIAL },
            { Beryllium_01.ToUpper(), BERYLLIUM_VOXEL_MATERIAL },
            { Tungsten_01.ToUpper(), TUNGSTEN_VOXEL_MATERIAL },
            { Plutonium_01.ToUpper(), PLUTONIUM_VOXEL_MATERIAL },
            { Iron_03.ToUpper(), IRON_VOXEL_MATERIAL },
            { Iron_04.ToUpper(), IRON_VOXEL_MATERIAL },
            // Better Stone
            { BetterStoneIntegrationProfile.Hapkeite_01.ToUpper(), BetterStoneIntegrationProfile.HAPKEITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Heazlewoodite_01.ToUpper(), BetterStoneIntegrationProfile.HEAZLEWOODITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Porphyry_01.ToUpper(), BetterStoneIntegrationProfile.PORPHYRY_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Dolomite_01.ToUpper(), BetterStoneIntegrationProfile.DOLOMITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Cattierite_01.ToUpper(), BetterStoneIntegrationProfile.CATTIERITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Niggliite_01.ToUpper(), BetterStoneIntegrationProfile.NIGGLIITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Carnotite_01.ToUpper(), BetterStoneIntegrationProfile.CARNOTITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Glaucodot_01.ToUpper(), BetterStoneIntegrationProfile.GLAUCODOT_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Sinoite_01.ToUpper(), BetterStoneIntegrationProfile.SINOITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Pyrite_01.ToUpper(), BetterStoneIntegrationProfile.PYRITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Olivine_01.ToUpper(), BetterStoneIntegrationProfile.OLIVINE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Cooperite_01.ToUpper(), BetterStoneIntegrationProfile.COOPERITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Quartz_01.ToUpper(), BetterStoneIntegrationProfile.QUARTZ_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Galena_01.ToUpper(), BetterStoneIntegrationProfile.GALENA_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Chlorargyrite_01.ToUpper(), BetterStoneIntegrationProfile.CHLORARGYRITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Electrum_01.ToUpper(), BetterStoneIntegrationProfile.ELECTRUM_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Sperrylite_01.ToUpper(), BetterStoneIntegrationProfile.SPERRYLITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Autunite_01.ToUpper(), BetterStoneIntegrationProfile.AUTUNITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Akimotoite_01.ToUpper(), BetterStoneIntegrationProfile.AKIMOTOITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Wadsleyite_01.ToUpper(), BetterStoneIntegrationProfile.WADSLEYITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Taenite_01.ToUpper(), BetterStoneIntegrationProfile.TAENITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Cohenite_01.ToUpper(), BetterStoneIntegrationProfile.COHENITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Kamacite_01.ToUpper(), BetterStoneIntegrationProfile.KAMACITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Uraniaurite_01.ToUpper(), BetterStoneIntegrationProfile.URANIAURITE_VOXEL_MATERIAL },
            { BetterStoneIntegrationProfile.Petzite_01.ToUpper(), BetterStoneIntegrationProfile.PETZITE_VOXEL_MATERIAL },
            // Infinite
            { InfiniteMapProfile.GlowCrystal.ToUpper(), InfiniteMapProfile.GLOWCRYSTAL_MATERIAL }
        };

        private static readonly List<string> ValidVoxels = new List<string>()
        {
            Iron_01,
            Iron_02,
            Nickel_01,
            Silicon_01,
            Cobalt_01,
            Gold_01,
            Silver_01,
            Platinum_01,
            Magnesium_01,
            Uraninite_01,
            Ice_01,
            Ice_02,
            Ice_03,
            Snow,
            Ice,
            IceEuropa2,
            AlienIce,
            AlienIce_03,
            AlienSnow,
            TritonIce,
            // ES Core
            StoneIce_01,
            // ES Technology
            Aluminum_01,
            Copper_01,
            Lead_01,
            Sulfur_01,
            Carbon_01,
            Potassium_01,
            Lithium_01,
            Zinc_01,
            Iridium_01,
            Titanium_01,
            Mercury_01,
            Beryllium_01,
            Tungsten_01,
            Plutonium_01,
            Iron_03,
            Iron_04,
            // Better Stone
            BetterStoneIntegrationProfile.Hapkeite_01,
            BetterStoneIntegrationProfile.Heazlewoodite_01,
            BetterStoneIntegrationProfile.Porphyry_01,
            BetterStoneIntegrationProfile.Dolomite_01,
            BetterStoneIntegrationProfile.Cattierite_01,
            BetterStoneIntegrationProfile.Niggliite_01,
            BetterStoneIntegrationProfile.Carnotite_01,
            BetterStoneIntegrationProfile.Glaucodot_01,
            BetterStoneIntegrationProfile.Sinoite_01,
            BetterStoneIntegrationProfile.Pyrite_01,
            BetterStoneIntegrationProfile.Olivine_01,
            BetterStoneIntegrationProfile.Cooperite_01,
            BetterStoneIntegrationProfile.Quartz_01,
            BetterStoneIntegrationProfile.Galena_01,
            BetterStoneIntegrationProfile.Chlorargyrite_01,
            BetterStoneIntegrationProfile.Electrum_01,
            BetterStoneIntegrationProfile.Sperrylite_01,
            BetterStoneIntegrationProfile.Autunite_01,
            BetterStoneIntegrationProfile.Akimotoite_01,
            BetterStoneIntegrationProfile.Wadsleyite_01,
            BetterStoneIntegrationProfile.Taenite_01,
            BetterStoneIntegrationProfile.Cohenite_01,
            BetterStoneIntegrationProfile.Kamacite_01,
            BetterStoneIntegrationProfile.Uraniaurite_01,
            BetterStoneIntegrationProfile.Petzite_01,
            // Infinite
            InfiniteMapProfile.GlowCrystal
        };

        public static string[] GetNames()
        {
            return ValidVoxels.ToArray();
        }

        public static VoxelMaterialProfile Get(string key)
        {
            if (PROFILES.ContainsKey(key))
                return PROFILES[key];
            return null;
        }

    }

}
