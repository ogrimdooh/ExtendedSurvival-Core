using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMaterialSetting
    {

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public int Version { get; set; } = 0;

        [XmlElement]
        public float MinedOreRatio { get; set; }

        [XmlElement]
        public bool SpawnsFromMeteorites { get; set; }

        [XmlElement]
        public bool SpawnsInAsteroids { get; set; }

        [XmlElement]
        public int AsteroidSpawnProbabilityMultiplier { get; set; }

    }

}
