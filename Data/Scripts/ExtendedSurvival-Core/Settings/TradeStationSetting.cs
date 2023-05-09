using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class TradeStationSetting
    {

        [XmlElement]
        public long ComercialCycle { get; set; } = 1200;

    }

}
