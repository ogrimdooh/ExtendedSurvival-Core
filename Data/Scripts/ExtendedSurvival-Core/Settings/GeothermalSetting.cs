using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class GeothermalSetting
    {

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public float Start { get; set; }

        [XmlElement]
        public float RowSize { get; set; }

        [XmlElement]
        public float Power { get; set; }

        [XmlElement]
        public float MaxPower { get; set; }

        [XmlElement]
        public float Increment { get; set; }

    }

}
