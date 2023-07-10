using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class AsteroidStorage
    {

        [XmlElement]
        public long Id { get; set; }

        [XmlElement]
        public Vector3D Position { get; set; }

        [XmlElement]
        public float Radius { get; set; }

    }

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

        [XmlElement]
        public bool StationsGenerated { get; set; }

        [XmlArray("Asteroids"), XmlArrayItem("Id", typeof(long))]
        public List<long> Asteroids { get; set; } = new List<long>();

        [XmlArray("AsteroidsData"), XmlArrayItem("Asteroid", typeof(AsteroidStorage))]
        public List<AsteroidStorage> AsteroidsData { get; set; } = new List<AsteroidStorage>();

        [XmlArray("NotSpawnAsteroids"), XmlArrayItem("Pos", typeof(Vector3D))]
        public List<Vector3D> NotSpawnAsteroids { get; set; } = new List<Vector3D>();

        [XmlArray("Stations"), XmlArrayItem("Station", typeof(StarSystemMemberStationStorage))]
        public List<StarSystemMemberStationStorage> Stations { get; set; } = new List<StarSystemMemberStationStorage>();

    }

}
