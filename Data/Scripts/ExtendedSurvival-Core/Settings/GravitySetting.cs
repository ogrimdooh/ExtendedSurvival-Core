using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class GravitySetting
    {

        [XmlElement]
        public float SurfaceGravity { get; set; } = 1;

        [XmlElement]
        public float GravityFalloffPower { get; set; } = 1;

    }

}
