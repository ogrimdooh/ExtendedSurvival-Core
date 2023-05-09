using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class FactionStorage
    {
        
        [XmlElement]
        public long FactionId { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Tag { get; set; }

        [XmlElement]
        public int FactionType { get; set; }

        [XmlElement]
        public bool FirstCheck { get; set; }

        [XmlArray("Stations"), XmlArrayItem("Id", typeof(long))]
        public List<long> Stations { get; set; } = new List<long>();

        [XmlArray("PlayersMapped"), XmlArrayItem("Id", typeof(long))]
        public List<long> PlayersMapped { get; set; } = new List<long>();

        [XmlArray("FactionsMapped"), XmlArrayItem("Id", typeof(long))]
        public List<long> FactionsMapped { get; set; } = new List<long>();

    }

}
