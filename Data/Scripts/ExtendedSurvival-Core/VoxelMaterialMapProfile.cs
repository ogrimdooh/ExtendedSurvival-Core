using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival
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

        public static readonly string[] ESToxicIce = new string[] 
        {
            IceEuropa2,
            AlienIce,
            AlienIce_03,
            AlienSnow
        };

        // ES Technology
        public const string Aluminum_01 = "Aluminum_01";
        public const string Copper_01 = "Copper_01";
        public const string Lead_01 = "Lead_01";
        public const string Sulfor_01 = "Sulfor_01";
        public const string Carbon_01 = "Carbon_01";
        public const string Potassium_01 = "Potassium_01";
        public const string Lithium_01 = "Lithium_01";

        public static readonly string[] ESTechnologyVoxels = new string[]
        {
            Aluminum_01,
            Copper_01,
            Lead_01,
            Sulfor_01,
            Carbon_01,
            Potassium_01,
            Lithium_01
        };

        private const float VERYCOMMON_RATIO = 5;
        private const float COMMON_RATIO = 4;
        private const float UNCOMMON_RATIO = 3;
        private const float RARE_RATIO = 2;
        private const float LEGENDARY_RATIO = 1;
        private const float EPIC_RATIO = 0.5f;

        private static readonly VoxelMaterialProfile IRON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = VERYCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 10
        };

        private static readonly VoxelMaterialProfile NICKEL_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 8
        };

        private static readonly VoxelMaterialProfile SILICON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 6
        };

        private static readonly VoxelMaterialProfile COBALT_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile GOLD_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile SILVER_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile PLATINUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile MAGNEZIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile URANITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 4
        };

        private static readonly VoxelMaterialProfile SNOW_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 0
        };

        private static readonly VoxelMaterialProfile EUROPA_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 0
        };

        private static readonly VoxelMaterialProfile ALIEN_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 0
        };

        private static readonly VoxelMaterialProfile ALIEN_SNOW_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 0
        };

        private static readonly VoxelMaterialProfile TRITON_ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 0
        };

        // ES Technology

        private static readonly VoxelMaterialProfile ALUMINUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 6
        };

        private static readonly VoxelMaterialProfile COPPER_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 8
        };

        private static readonly VoxelMaterialProfile LEAD_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile SULFOR_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 2
        };

        private static readonly VoxelMaterialProfile CARBON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 2
        };

        private static readonly VoxelMaterialProfile POTASSIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = RARE_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile LITHIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 0,
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = false,
            SpawnsInAsteroids = false,
            AsteroidSpawnProbabilityMultiplier = 1
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
            {Snow.ToUpper(), SNOW_VOXEL_MATERIAL },
            {Ice.ToUpper(), ICE_VOXEL_MATERIAL },
            {IceEuropa2.ToUpper(), EUROPA_ICE_VOXEL_MATERIAL },
            {AlienIce.ToUpper(), ALIEN_ICE_VOXEL_MATERIAL },
            {AlienIce_03.ToUpper(), ALIEN_ICE_VOXEL_MATERIAL },
            {AlienSnow.ToUpper(), ALIEN_SNOW_VOXEL_MATERIAL },
            {TritonIce.ToUpper(), TRITON_ICE_VOXEL_MATERIAL },
            // ES Technology
            { Aluminum_01.ToUpper(), ALUMINUM_VOXEL_MATERIAL },
            { Copper_01.ToUpper(), COPPER_VOXEL_MATERIAL },
            { Lead_01.ToUpper(), LEAD_VOXEL_MATERIAL },
            { Sulfor_01.ToUpper(), SULFOR_VOXEL_MATERIAL },
            { Carbon_01.ToUpper(), CARBON_VOXEL_MATERIAL },
            { Potassium_01.ToUpper(), POTASSIUM_VOXEL_MATERIAL },
            { Lithium_01.ToUpper(), LITHIUM_VOXEL_MATERIAL }
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
            // ES Technology
            Aluminum_01,
            Copper_01,
            Lead_01,
            Sulfor_01,
            Carbon_01,
            Potassium_01,
            Lithium_01
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
