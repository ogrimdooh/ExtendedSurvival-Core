using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemMemberStorage
    {

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int MemberType { get; set; }

        [XmlElement]
        public int ItemType { get; set; }

        [XmlElement]
        public Vector3D Position { get; set; }

        [XmlElement]
        public long EntityId { get; set; }

        [XmlArray("Asteroids"), XmlArrayItem("Id", typeof(long))]
        public List<long> Asteroids { get; set; } = new List<long>();

        [XmlArray("Stations"), XmlArrayItem("Station", typeof(StarSystemMemberStationStorage))]
        public List<StarSystemMemberStationStorage> Stations { get; set; } = new List<StarSystemMemberStationStorage>();

    }

}
