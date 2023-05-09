using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class TradeStationSetting
    {

        public const string FACTIONRANGE_INFO = "X: Min Amount. Y: Max Amount.";

        [XmlElement]
        public long ComercialCycle { get; set; } = 1200;

        [XmlElement]
        public DocumentedVector2 TradeFactionsAmount { get; set; } = new DocumentedVector2(10, 20, FACTIONRANGE_INFO);

    }

}
