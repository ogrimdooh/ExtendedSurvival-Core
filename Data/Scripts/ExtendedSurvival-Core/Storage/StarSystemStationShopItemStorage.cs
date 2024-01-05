using ProtoBuf;
using System.Xml.Serialization;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemStationShopItemStorage
    {

        [XmlElement]
        public SerializableDefinitionId Id { get; set; }

        [XmlElement]
        public float Amount { get; set; }

        [XmlElement]
        public float Price { get; set; }

        [XmlElement]
        public bool IsSelling { get; set; }

    }

}
