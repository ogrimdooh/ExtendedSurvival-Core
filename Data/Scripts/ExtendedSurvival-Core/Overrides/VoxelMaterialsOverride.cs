using Sandbox.Definitions;
using System;
using VRage.Collections;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    public class VoxelMaterialsOverride
    {

        public static void SetDefinitions()
        {
            // Override Voxels
            var voxels = VoxelMaterialMapProfile.GetNames();
            var definitions = MyDefinitionManager.Static.GetVoxelMaterialDefinitions();
            foreach (var voxel in voxels)
            {
                if (!ExtendedSurvivalCoreSession.IsUsingTechnology() && VoxelMaterialMapProfile.ESTechnologyVoxels.Contains(voxel))
                    continue;
                try
                {
                    MyVoxelMaterialDefinition definition;
                    if (definitions.TryGetValue(voxel, out definition))
                    {
                        var info = ExtendedSurvivalSettings.Instance.GetVoxelInfo(voxel);
                        if (info != null)
                        {
                            definition.MinedOreRatio = info.MinedOreRatio;
                            definition.SpawnsInAsteroids = info.SpawnsInAsteroids;
                            definition.SpawnsFromMeteorites = info.SpawnsFromMeteorites;
                            definition.AsteroidGeneratorSpawnProbabilityMultiplier = info.AsteroidSpawnProbabilityMultiplier;
                            if (VoxelMaterialMapProfile.ESToxicIce.Contains(voxel))
                            {
                                definition.MinedOre = ItensConstants.TOXICICE_SUBTYPEID;
                            }
                            definition.Postprocess();
                            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(VoxelMaterialsOverride), $"Override voxel definition : {definition.Id.SubtypeName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(VoxelMaterialsOverride), ex);
                }
            }
            // Override Soil Voxels
            SetMinedOre(definitions, VoxelMaterialMapProfile.SoilVoxels, ItensConstants.SOIL_SUBTYPEID, VoxelMaterialMapProfile.VERYCOMMON_RATIO);
            SetMinedOre(definitions, VoxelMaterialMapProfile.DesertSoilVoxels, ItensConstants.DESERTSOIL_SUBTYPEID, VoxelMaterialMapProfile.COMMON_RATIO);
            SetMinedOre(definitions, VoxelMaterialMapProfile.MoomSoilVoxels, ItensConstants.MOONSOIL_SUBTYPEID, VoxelMaterialMapProfile.UNCOMMON_RATIO);
        }

        private static void SetMinedOre(DictionaryValuesReader<string, MyVoxelMaterialDefinition> definitions, string[] targets, string ore, float ratio)
        {
            foreach (var voxel in targets)
            {
                try
                {
                    MyVoxelMaterialDefinition definition;
                    if (definitions.TryGetValue(voxel, out definition))
                    {
                        definition.MinedOre = ore;
                        definition.MinedOreRatio = ratio;
                        definition.Postprocess();
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(VoxelMaterialsOverride), $"Override voxel definition : {definition.Id.SubtypeName}");
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(VoxelMaterialsOverride), ex);
                }
            }
        }

    }

}