using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemPlayerInterationStorage
    {

        [XmlElement]
        public ulong SteamId { get; set; }

        [XmlElement]
        public bool StartGpsGenerated { get; set; }

    }

}
