using System.Collections.Generic;
using ProtoBuf;
using System.Xml.Serialization;
using System.Linq;
using VRageMath;

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

        public Dictionary<long, StarSystemMemberStationStorage> GetStationsContainersIds()
        {
            var ids = new Dictionary<long, StarSystemMemberStationStorage>();
            foreach (var member in Members.Where(x => x.Stations.Any(y => y.CargoContainerEntityId != 0)))
            {
                foreach (var y in member.Stations.Where(y => y.CargoContainerEntityId != 0))
                {
                    ids.Add(y.CargoContainerEntityId, y);
                }
            }
            return ids;
        }

        public StarSystemMemberStationStorage GetByCargoId(long id)
        {
            var ids = GetStationsContainersIds();
            if (ids.ContainsKey(id))
                return ids[id];
            return null;
        }

        public StarSystemMemberStationStorage[] GetStations()
        {
            var ids = new List<StarSystemMemberStationStorage>();
            foreach (var member in Members.Where(x => x.Stations.Any(y => y.StationEntityId != 0)))
            {
                ids.AddRange(member.Stations.Where(y => y.StationEntityId != 0));
            }
            return ids.ToArray();
        }

        public StarSystemMemberStationStorage[] GetAllStations()
        {
            var ids = new List<StarSystemMemberStationStorage>();
            foreach (var member in Members.Where(x => x.Stations.Any()))
            {
                ids.AddRange(member.Stations);
            }
            return ids.ToArray();
        }

    }

}
