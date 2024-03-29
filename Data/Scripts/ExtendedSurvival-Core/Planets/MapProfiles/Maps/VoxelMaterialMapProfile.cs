﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Core
{
    public static class VoxelMaterialMapProfile
    {

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
            AlienSoil
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
            Helios_HighGrass
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
            Helios_Lava
        };

        public static readonly string[] MoomSoilVoxels = new string[] 
        {
            MoonSoil,
            SmallMoonRocks
        };

        public static readonly string[] ESToxicIce = new string[] 
        {
            IceEuropa2,
            AlienIce,
            AlienIce_03,
            AlienSnow
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
            Mercury_01
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
            Plutonium_01
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
            { Plutonium_01.ToUpper(), PLUTONIUM_VOXEL_MATERIAL }
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
            Plutonium_01
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
