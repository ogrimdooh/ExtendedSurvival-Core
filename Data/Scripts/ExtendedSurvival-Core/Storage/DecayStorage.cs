using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class DecayStorage
    {

        [XmlArray("Players"), XmlArrayItem("Player", typeof(PlayerDecayStorage))]
        public List<PlayerDecayStorage> Players { get; set; } = new List<PlayerDecayStorage>();

        public PlayerDecayStorage Get(ulong steamId)
        {
            return Players.FirstOrDefault(x => x.SteamId == steamId);
        }

    }

}
