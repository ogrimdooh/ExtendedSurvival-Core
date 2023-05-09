using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorStoneStorage
    {

        [XmlElement]
        public long EntityId { get; set; }

        [XmlElement]
        public long Life { get; set; }

    }

}
