using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorImpactStoneSetting
    {

        [XmlElement]
        public string GroupId { get; set; }

        [XmlElement]
        public string ModifierId { get; set; }

        [XmlElement]
        public float ChanceToSpawn { get; set; }

    }

}
