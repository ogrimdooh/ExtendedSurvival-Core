using ProtoBuf;
using System.Xml.Serialization;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemStationAcquisitionContract
    {

        [XmlElement]
        public SerializableDefinitionId Id { get; set; }

        [XmlElement]
        public int Amount { get; set; }

        [XmlElement]
        public int Reward { get; set; }

        [XmlElement]
        public int Duration { get; set; }

        [XmlElement]
        public int Collateral { get; set; }

        [XmlElement]
        public long? ContractId { get; set; }

        [XmlElement]
        public long? PlayerId { get; set; }
        
    }

}
