using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class TradeStationSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.TradeStations";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ComercialCycle"),
                Title = "ComercialCycle",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_TRADESTATIONS_COMERCIALCYCLE_DESCRIPTION),
                DefaultValue = "1200",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings TradeStations.ComercialCycle 2500",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TradeFactionsAmount"),
                Title = "TradeFactionsAmount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_TRADESTATIONS_TRADEFACTIONSAMOUNT_DESCRIPTION),
                DefaultValue = "X: 10 | Y: 20",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings TradeStations.TradeFactionsAmount 5:25",
                ValueType = HelpController.ConfigurationValueType.Integer
            }
        };

        public const string FACTIONRANGE_INFO = "X: Min Amount. Y: Max Amount.";

        [XmlElement]
        public long ComercialCycle { get; set; } = 1200;

        [XmlElement]
        public DocumentedVector2 TradeFactionsAmount { get; set; } = new DocumentedVector2(10, 20, FACTIONRANGE_INFO);

    }

}
