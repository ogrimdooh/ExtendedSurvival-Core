using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemGlobalSetting
    {

        [XmlElement]
        public bool AutoGenerateStarSystemGps { get; set; } = true;

        [XmlElement]
        public bool AutoGenerateTradeStationsGps { get; set; } = false;

        [XmlElement]
        public bool CreateDatapadInStartRover { get; set; } = true;

        [XmlElement]
        public bool CreateDatapadInDropContainers { get; set; } = true;

        [XmlElement]
        public float DatapadChanceInDropContainers { get; set; } = 0.15f;

    }

}
