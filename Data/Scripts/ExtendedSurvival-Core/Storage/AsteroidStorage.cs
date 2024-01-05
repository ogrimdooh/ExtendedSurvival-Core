using ProtoBuf;
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

        [XmlElement]
        public int Seed { get; set; }

        [XmlElement]
        public Vector3 Forward { get; set; }

        [XmlElement]
        public Vector3 Up { get; set; }

        [XmlElement]
        public bool Changed { get; set; }

    }

}
