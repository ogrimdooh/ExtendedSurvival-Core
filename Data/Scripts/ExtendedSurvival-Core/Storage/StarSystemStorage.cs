using System.Collections.Generic;
using ProtoBuf;
using System.Xml.Serialization;
using System.Linq;

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

        [XmlElement]
        public long ComercialCountdown { get; set; }

        [XmlArray("Members"), XmlArrayItem("Member", typeof(StarSystemMemberStorage))]
        public List<StarSystemMemberStorage> Members { get; set; } = new List<StarSystemMemberStorage>();

        public long[] GetStationsContainersIds()
        {
            var ids = new List<long>();
            foreach (var member in Members.Where(x => x.Stations.Any(y => y.CargoContainerEntityId != 0)))
            {
                ids.AddRange(member.Stations.Where(y => y.CargoContainerEntityId != 0).Select(y => y.CargoContainerEntityId));
            }
            return ids.ToArray();
        }

        public StarSystemMemberStationStorage[] GetStations()
        {
            var ids = new List<StarSystemMemberStationStorage>();
            foreach (var member in Members.Where(x => x.Stations.Any(y => y.CargoContainerEntityId != 0)))
            {
                ids.AddRange(member.Stations.Where(y => y.StationEntityId != 0));
            }
            return ids.ToArray();
        }

    }

}
