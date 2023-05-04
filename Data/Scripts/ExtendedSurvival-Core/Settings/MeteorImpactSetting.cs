using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorImpactSetting
    {

        [XmlElement]
        public bool Enabled { get; set; } = true;

        [XmlElement]
        public float DistanceToSpawn { get; set; } = 2500.0f;

    }

}
