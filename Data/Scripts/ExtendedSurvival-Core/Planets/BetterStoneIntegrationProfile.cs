using Medieval.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Trace;
using VRage.Utils;

namespace ExtendedSurvival.Core
{
    public class BetterStoneIntegrationProfile
    {

        public class VoxelTextureReplace
        {

            public string ColorMetalXZnY { get; set; }
            public float InitialScale { get; set; }
            public VRageMath.Vector4 Far3Color { get; set; }
            public ColorDefinitionRGBA ColorKey { get; set; }

        }

        public static readonly Dictionary<string, string> NewOreToVoxelMap = new Dictionary<string, string>()
        {
            { VoxelMaterialMapProfile.Iron_01, OreConstants.IRON_SUBTYPEID },
            { VoxelMaterialMapProfile.Iron_02, OreConstants.IRON_SUBTYPEID },
            { VoxelMaterialMapProfile.Iron_03, OreConstants.CM_IRON_FE_SUBTYPEID },
            { VoxelMaterialMapProfile.Iron_04, OreConstants.CM_DENSE_IRON_FE_SUBTYPEID }
        };

        public static readonly Dictionary<UniqueEntityId, BaseIntegrationModRecipesOverride.ExternalModCustomIcon> OresNewIcons = new Dictionary<UniqueEntityId, BaseIntegrationModRecipesOverride.ExternalModCustomIcon>()
        {
            {
                OreConstants.CM_IRON_FE_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_icy_iron.dds",
                    false
                )
            },
            {
                OreConstants.CM_DENSE_IRON_FE_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_dense_iron.dds",
                    false
                )
            },
            {
                OreConstants.S_HAPKEITE_FESI_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_hapkeite.dds",
                    false
                )
            },
            {
                OreConstants.CM_HEAZLEWOODITE_NI_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_heazlewoodite.dds",
                    false
                )
            },
            {
                OreConstants.PM_PORPHYRY_AU_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_porphyry.dds",
                    false
                )
            },
            {
                OreConstants.S_DOLOMITE_MG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_dolomite.dds",
                    false
                )
            },
            {
                OreConstants.CM_CATTIERITE_CO_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_cattierite.dds",
                    false
                )
            },
            {
                OreConstants.PM_NIGGLIITE_PT_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_niggliite.dds",
                    false
                )
            },
            {
                OreConstants.EI_CARNOTITE_U_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_carnotite.dds",
                    false
                )
            },
            {
                OreConstants.CM_GLAUCODOT_FECO_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_glaucodot.dds",
                    false
                )
            },
            {
                OreConstants.S_SINOITE_SI_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_sinoite.dds",
                    false
                )
            },
            {
                OreConstants.CM_PYRITE_FEAU_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_pyrite.dds",
                    false
                )
            },
            {
                OreConstants.S_OLIVINE_SIMG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_olivine.dds",
                    false
                )
            },
            {
                OreConstants.PM_COOPERITE_NIPT_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_cooperite.dds",
                    false
                )
            },
            {
                OreConstants.S_QUARTZ_SI_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_quartz.dds",
                    false
                )
            },
            {
                OreConstants.PM_GALENA_AG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_galena.dds",
                    false
                )
            },
            {
                OreConstants.PM_CHLORARGYRITE_AG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_chlorargyrite.dds",
                    false
                )
            },
            {
                OreConstants.PM_ELECTRUM_AUAG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_electrum.dds",
                    false
                )
            },
            {
                OreConstants.PM_SPERRYLITE_PT_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_sperrylite.dds",
                    false
                )
            },
            {
                OreConstants.EI_AUTUNITE_U_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_autunite.dds",
                    false
                )
            },
            {
                OreConstants.S_AKIMOTOITE_SIMG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_akimotoite.dds",
                    false
                )
            },
            {
                OreConstants.S_WADSLEYITE_SIMG_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_wadsleyite.dds",
                    false
                )
            },
            {
                OreConstants.CM_TAENITE_FENI_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_taenite.dds",
                    false
                )
            },
            {
                OreConstants.CM_COHENITE_NICO_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_cohenite.dds",
                    false
                )
            },
            {
                OreConstants.CM_KAMACITE_FENICO_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_kamacite.dds",
                    false
                )
            },
            {
                OreConstants.EI_URANIAURITE_UAU_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_uraniaurite.dds",
                    false
                )
            },
            {
                OreConstants.PM_PETZITE_AGAU_ID,
                new BaseIntegrationModRecipesOverride.ExternalModCustomIcon(
                    "Textures\\GUI\\Icons\\Integrations\\ore_petzite.dds",
                    false
                )
            }
        };

        public static void DoOnSettingsOverride()
        {
            if (ExtendedSurvivalCoreSession.IsUsingBetterStone())
            {
                foreach (var item in OresNewIcons.Keys)
                {
                    var itemDef = MyDefinitionManager.Static.GetPhysicalItemDefinition(item.DefinitionId);
                    if (itemDef != null)
                    {
                        itemDef.Icons = new string[] { BaseIntegrationModRecipesOverride.GetCustomIcon(itemDef.Context, OresNewIcons[item]) };
                        itemDef.Postprocess();
                    }
                }
            }
        }

        /// <summary>
        /// Fe + Si
        /// </summary>
        public const string Hapkeite_01 = "Hapkeite_01";

        /// <summary>
        /// Ni
        /// </summary>
        public const string Heazlewoodite_01 = "Heazlewoodite_01";

        /// <summary>
        /// Au
        /// </summary>
        public const string Porphyry_01 = "Porphyry_01";

        /// <summary>
        /// Mg
        /// </summary>
        public const string Dolomite_01 = "Dolomite_01";

        /// <summary>
        /// Co
        /// </summary>
        public const string Cattierite_01 = "Cattierite_01";

        /// <summary>
        /// Pt
        /// </summary>
        public const string Niggliite_01 = "Niggliite_01";

        /// <summary>
        /// U
        /// </summary>
        public const string Carnotite_01 = "Carnotite_01";

        /// <summary>
        /// Fe + Co
        /// </summary>
        public const string Glaucodot_01 = "Glaucodot_01";

        /// <summary>
        /// Si
        /// </summary>
        public const string Sinoite_01 = "Sinoite_01";

        /// <summary>
        /// Fe + Au
        /// </summary>
        public const string Pyrite_01 = "Pyrite_01";

        /// <summary>
        /// Si + Mg
        /// </summary>
        public const string Olivine_01 = "Olivine_01";

        /// <summary>
        /// Ni + Pt
        /// </summary>
        public const string Cooperite_01 = "Cooperite_01";

        /// <summary>
        /// Si
        /// </summary>
        public const string Quartz_01 = "Quartz_01";

        /// <summary>
        /// Ag
        /// </summary>
        public const string Galena_01 = "Galena_01";

        /// <summary>
        /// Ag
        /// </summary>
        public const string Chlorargyrite_01 = "Chlorargyrite_01";

        /// <summary>
        /// Au + Ag
        /// </summary>
        public const string Electrum_01 = "Electrum_01";

        /// <summary>
        /// Pt
        /// </summary>
        public const string Sperrylite_01 = "Sperrylite_01";

        /// <summary>
        /// U
        /// </summary>
        public const string Autunite_01 = "Autunite_01";

        /// <summary>
        /// Si + Mg
        /// </summary>
        public const string Akimotoite_01 = "Akimotoite_01";
        
        /// <summary>
        /// Si + Mg
        /// </summary>
        public const string Wadsleyite_01 = "Wadsleyite_01";

        /// <summary>
        /// Fe + Ni
        /// </summary>
        public const string Taenite_01 = "Taenite_01";

        /// <summary>
        /// Ni + Co
        /// </summary>
        public const string Cohenite_01 = "Cohenite_01";

        /// <summary>
        /// Fe + Ni + Co
        /// </summary>
        public const string Kamacite_01 = "Kamacite_01";

        /// <summary>
        /// U + Au
        /// </summary>
        public const string Uraniaurite_01 = "Uraniaurite_01";

        /// <summary>
        /// Ag + Au
        /// </summary>
        public const string Petzite_01 = "Petzite_01";

        public static readonly string[] BetterStoneVoxels = new string[]
        {
            Hapkeite_01,
            Heazlewoodite_01,
            Porphyry_01,
            Dolomite_01,
            Cattierite_01,
            Niggliite_01,
            Carnotite_01,
            Glaucodot_01,
            Sinoite_01,
            Pyrite_01,
            Olivine_01,
            Cooperite_01,
            Quartz_01,
            Galena_01,
            Chlorargyrite_01,
            Electrum_01,
            Sperrylite_01,
            Autunite_01,
            Akimotoite_01,
            Wadsleyite_01,
            Taenite_01,
            Cohenite_01,
            Kamacite_01,
            Uraniaurite_01,
            Petzite_01
        };

        public static readonly VoxelMaterialProfile HAPKEITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.COMMON_SPAWN
        };

        public static readonly VoxelMaterialProfile HEAZLEWOODITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.COMMON_SPAWN
        };

        public static readonly VoxelMaterialProfile PORPHYRY_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile DOLOMITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile CATTIERITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile NIGGLIITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile CARNOTITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile GLAUCODOT_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.UNCOMMON_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile SINOITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.COMMON_SPAWN
        };

        public static readonly VoxelMaterialProfile PYRITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.RARE_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile OLIVINE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.RARE_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile COOPERITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.RARE_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile QUARTZ_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.COMMON_RATIO,
            SpawnsFromMeteorites = true,
            SpawnsInAsteroids = true,
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.COMMON_SPAWN
        };

        public static readonly VoxelMaterialProfile GALENA_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile CHLORARGYRITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile ELECTRUM_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile SPERRYLITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile AUTUNITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile AKIMOTOITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile WADSLEYITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile TAENITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.VERYCOMMON_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.COMMON_SPAWN
        };

        public static readonly VoxelMaterialProfile COHENITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.UNCOMMON_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.RARE_SPAWN
        };

        public static readonly VoxelMaterialProfile KAMACITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.RARE_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile URANIAURITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.LEGENDARY_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

        public static readonly VoxelMaterialProfile PETZITE_VOXEL_MATERIAL = new VoxelMaterialProfile()
        {
            Version = 1,
            MinedOreRatio = VoxelMaterialMapProfile.EPIC_RATIO,
            SpawnsFromMeteorites = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            SpawnsInAsteroids = !ExtendedSurvivalCoreSession.IsUsingTechnology(),
            AsteroidSpawnProbabilityMultiplier = VoxelMaterialMapProfile.EPIC_SPAWN
        };

    }

}
