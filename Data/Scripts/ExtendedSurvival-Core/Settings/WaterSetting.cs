using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class WaterSetting
    {

        public const string TEMPERATURE_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public float Size { get; set; }

        [XmlElement]
        public float TemperatureFactor { get; set; } = 0;

        [XmlElement]
        public float ToxicLevel { get; set; } = 0;

        [XmlElement]
        public float RadiationLevel { get; set; } = 0;

    }

}
