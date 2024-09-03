using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlayerHuntStorage
    {

        [XmlElement]
        public ulong SteamId { get; set; }

        [XmlElement]
        public long CountDownTimer { get; set; }

    }

}
