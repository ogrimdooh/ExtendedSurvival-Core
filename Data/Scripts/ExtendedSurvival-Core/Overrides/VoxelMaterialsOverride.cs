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