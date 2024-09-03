using System.Collections.Generic;
using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class HuntSystemStorage
    {

        [XmlArray("Players"), XmlArrayItem("Player", typeof(PlayerHuntStorage))]
        public List<PlayerHuntStorage> Players { get; set; } = new List<PlayerHuntStorage>();

    }

}
