namespace ExtendedSurvival
{
    public class VoxelMaterialProfile
    {

        public int Version { get; set; }
        public float MinedOreRatio { get; set; }
        public bool SpawnsFromMeteorites { get; set; }
        public bool SpawnsInAsteroids { get; set; }
        public int AsteroidSpawnProbabilityMultiplier { get; set; }

        public void UpgradeSettings(VoxelMaterialSetting settings)
        {

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
