using Sandbox.Definitions;
using System;
using VRage.Game;

namespace ExtendedSurvival
{

    public class VoxelMaterialsOverride
    {

        public static void SetDefinitions()
        {
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
                            ExtendedSurvivalLogging.Instance.LogInfo(typeof(PlanetsOverride), $"Override voxel definition : {definition.Id.SubtypeName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalLogging.Instance.LogError(typeof(VoxelMaterialsOverride), ex);
                }
            }
        }

    }

}