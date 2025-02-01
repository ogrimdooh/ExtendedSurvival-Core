using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Collections;
using VRage.Game;
using VRage.Utils;

namespace ExtendedSurvival.Core
{

    public class VoxelMaterialsOverride
    {

        public static readonly Dictionary<string, MyVoxelMaterialDefinition> VoxelMap = new Dictionary<string, MyVoxelMaterialDefinition>();

        public static List<string> AsteroidVoxels = new List<string>();

        public static void SetDefinitions()
        {
            // Get Definitions
            var definitions = MyDefinitionManager.Static.GetVoxelMaterialDefinitions();
            // Override Soils and Toxic Voxels
            foreach (var replace in VoxelMaterialMapProfile.VoxelReplaces)
            {
                SetMinedOre(definitions, replace.TargetVoxels, replace.OreToMine, replace.MineRatio);
            }
            // Override Voxels
            var voxels = VoxelMaterialMapProfile.GetNames();
            foreach (var voxel in voxels)
            {
                if (!ExtendedSurvivalCoreSession.IsUsingTechnology() && VoxelMaterialMapProfile.ESTechnologyVoxels.Contains(voxel))
                    continue;
                try
                {
                    MyVoxelMaterialDefinition definition;
                    if (definitions.TryGetValue(voxel, out definition))
                    {
                        VoxelMap.Add(voxel, definition);
                        var info = ExtendedSurvivalSettings.Instance.GetVoxelInfo(voxel);
                        if (info != null)
                        {
                            if (ExtendedSurvivalCoreSession.IsUsingBetterStone())
                            {
                                if (BetterStoneIntegrationProfile.NewOreToVoxelMap.ContainsKey(voxel))
                                {
                                    definition.MinedOre = BetterStoneIntegrationProfile.NewOreToVoxelMap[voxel];
                                }
                            }
                            definition.MinedOreRatio = info.MinedOreRatio;
                            definition.SpawnsInAsteroids = info.SpawnsInAsteroids;
                            /* Force spawn in asteroids when respawn in space is enabled */
                            if (ExtendedSurvivalSettings.Instance.RespawnSpacePodEnabled &&
                                VoxelMaterialMapProfile.SpaceNeeded.Contains(voxel))
                                definition.SpawnsInAsteroids = true;
                            definition.SpawnsFromMeteorites = info.SpawnsFromMeteorites;
                            definition.AsteroidGeneratorSpawnProbabilityMultiplier = info.AsteroidSpawnProbabilityMultiplier;
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
            var maxIdUsed = definitions.Max(x => x.Index);
            if (maxIdUsed >= 128)
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(VoxelMaterialsOverride), $"Voxels over the limit of 128, some materials will not render.");
                var overLimitVoxels = definitions.ToList().Where(x => x.Index >= 128).OrderBy(x => x.Index).ToList();
                foreach (var item in overLimitVoxels)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(VoxelMaterialsOverride), $"Voxel Id={item.Index} Name={item.Id.SubtypeName} from modId={item.Context.ModId} modName={item.Context.ModName} will not render!");
                }
            }
            var asteroidVoxels = VoxelMap.Where(x => x.Value.IsRare && x.Value.SpawnsInAsteroids).Select(x => x.Key).ToArray();
            var tempVoxels = new List<KeyValuePair<string, float>>();
            foreach (var voxel in asteroidVoxels)
            {
                for (int i = 0; i < VoxelMap[voxel].AsteroidGeneratorSpawnProbabilityMultiplier; i++)
                {
                    tempVoxels.Add(new KeyValuePair<string, float>(voxel, MyUtils.GetRandomFloat()));
                }
            }
            AsteroidVoxels = tempVoxels.OrderBy(x => x.Value).Select(x => x.Key).ToList();
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