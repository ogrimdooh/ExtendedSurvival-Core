using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalEntrySetting
    {

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public int TimeToSpawn { get; set; } = 0;

        [XmlArray("Biomes"), XmlArrayItem("Biome", typeof(PlanetAnimalTargetBiomeSetting))]
        public List<PlanetAnimalTargetBiomeSetting> Biomes { get; set; } = new List<PlanetAnimalTargetBiomeSetting>();

    }

}
