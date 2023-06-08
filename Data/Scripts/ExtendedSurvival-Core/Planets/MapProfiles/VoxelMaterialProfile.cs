namespace ExtendedSurvival.Core
{
    public class VoxelMaterialProfile
    {

        public int Version { get; set; }
        public float MinedOreRatio { get; set; }
        public bool SpawnsFromMeteorites { get; set; }
        public bool SpawnsInAsteroids { get; set; }
        public int AsteroidSpawnProbabilityMultiplier { get; set; }

        public VoxelMaterialSetting UpgradeSettings(VoxelMaterialSetting settings)
        {
            if (settings != null)
            {
                if (Version < 1)
                {
                    settings = BuildSettings(settings.Id);
                }
                settings.Version = Version;
            }
            return settings;
        }

        public VoxelMaterialSetting BuildSettings(string id)
        {
            return new VoxelMaterialSetting()
            {
                Id = id,
                UsingTechnology = ExtendedSurvivalCoreSession.IsUsingTechnology(),
                Version = Version,
                MinedOreRatio = MinedOreRatio,
                SpawnsFromMeteorites = SpawnsFromMeteorites,
                SpawnsInAsteroids = SpawnsInAsteroids,
                AsteroidSpawnProbabilityMultiplier = AsteroidSpawnProbabilityMultiplier
            };
        }

    }

}
