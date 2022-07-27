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

        private const float VERYCOMMON_RATIO = 5;
        private const float COMMON_RATIO = 4;
        private const float UNCOMMON_RATIO = 3;
        private const float RARE_RATIO = 2;
        private const float LEGENDARY_RATIO = 1;
        private const float EPIC_RATIO = 0.5f;

        private static readonly VoxelMaterialProfile IRON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = VERYCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 10
        };

        private static readonly VoxelMaterialProfile NICKEL_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 8
        };

        private static readonly VoxelMaterialProfile SILICON_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = UNCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 6
        };

        private static readonly VoxelMaterialProfile COBALT_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile GOLD_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile SILVER_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile PLATINUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile MAGNEZIUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = LEGENDARY_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile URANITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = EPIC_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 1
        };

        private static readonly VoxelMaterialProfile ICE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            MinedOreRatio = VERYCOMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = 4
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
            { Ice_03.ToUpper(), ICE_VOXEL_MATERIAL }
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
            Ice_03
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
