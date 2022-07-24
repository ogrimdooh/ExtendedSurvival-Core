using ProtoBuf;
using System.Xml.Serialization;
using VRageMath;

namespace ExtendedSurvival
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalSpawnSetting
    {

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public Vector2I SpawnDelay { get; set; }

        [XmlElement]
        public Vector2I SpawnDist { get; set; }

        [XmlElement]
        public Vector2I WaveCount { get; set; }

    }

}
