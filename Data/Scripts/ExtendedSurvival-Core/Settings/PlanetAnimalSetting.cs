using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalSetting
    {

        [XmlArray("Animals"), XmlArrayItem("Animal", typeof(PlanetAnimalEntrySetting))]
        public List<PlanetAnimalEntrySetting> Animals { get; set; } = new List<PlanetAnimalEntrySetting>();

        [XmlElement]
        public PlanetAnimalSpawnSetting DaySpawn { get; set; } = new PlanetAnimalSpawnSetting();

        [XmlElement]
        public PlanetAnimalSpawnSetting NightSpawn { get; set; } = new PlanetAnimalSpawnSetting();

        public MyPlanetAnimalSpawnInfo GetDaySpawnDefinition()
        {
            if (!DaySpawn.Enabled)
                return new MyPlanetAnimalSpawnInfo();
            return new MyPlanetAnimalSpawnInfo()
            {
                Animals = Animals.Select(x=>new MyPlanetAnimal() { AnimalType = x.Id }).ToArray(),
                SpawnDelayMin = DaySpawn.SpawnDelay.X,
                SpawnDelayMax = DaySpawn.SpawnDelay.Y,
                SpawnDistMin = DaySpawn.SpawnDist.X,
                SpawnDistMax = DaySpawn.SpawnDist.Y,
                WaveCountMin = DaySpawn.WaveCount.X,
                WaveCountMax = DaySpawn.WaveCount.Y
            };
        }

        public MyPlanetAnimalSpawnInfo GetNightSpawnDefinition()
        {
            if (!NightSpawn.Enabled)
                return new MyPlanetAnimalSpawnInfo();
            return new MyPlanetAnimalSpawnInfo()
            {
                Animals = Animals.Select(x => new MyPlanetAnimal() { AnimalType = x.Id }).ToArray(),
                SpawnDelayMin = NightSpawn.SpawnDelay.X,
                SpawnDelayMax = NightSpawn.SpawnDelay.Y,
                SpawnDistMin = NightSpawn.SpawnDist.X,
                SpawnDistMax = NightSpawn.SpawnDist.Y,
                WaveCountMin = NightSpawn.WaveCount.X,
                WaveCountMax = NightSpawn.WaveCount.Y
            };
        }

    }

}
