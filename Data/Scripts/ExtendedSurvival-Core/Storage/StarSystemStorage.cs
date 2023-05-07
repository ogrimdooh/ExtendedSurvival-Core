using System.Collections.Generic;
using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemStorage
    {

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public bool Generated { get; set; }

        [XmlElement]
        public long ComercialTick { get; set; }

        [XmlArray("Members"), XmlArrayItem("Member", typeof(StarSystemMemberStorage))]
        public List<StarSystemMemberStorage> Members { get; set; } = new List<StarSystemMemberStorage>();

    }

}
