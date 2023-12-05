using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemGlobalSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.StarSystemConfiguration";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AutoGenerateStarSystemGps"),
                Title = "AutoGenerateStarSystemGps",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_AUTOGENERATESTARSYSTEMGPS_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.AutoGenerateStarSystemGps true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AddAllInfoToStarSystemGps"),
                Title = "AddAllInfoToStarSystemGps",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_ADDALLINFOTOSTARSYSTEMGPS_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.AddAllInfoToStarSystemGps true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AutoGenerateTradeStationsGps"),
                Title = "AutoGenerateTradeStationsGps",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_AUTOGENERATETRADESTATIONSGPS_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.AutoGenerateTradeStationsGps true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.CreateDatapadInStartRover"),
                Title = "CreateDatapadInStartRover",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_CREATEDATAPADINSTARTROVER_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.CreateDatapadInStartRover true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.CreateDatapadInDropContainers"),
                Title = "CreateDatapadInDropContainers",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_CREATEDATAPADINDROPCONTAINERS_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.CreateDatapadInDropContainers true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DatapadChanceInDropContainers"),
                Title = "DatapadChanceInDropContainers",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_DATAPADCHANCEINDROPCONTAINERS_DESCRIPTION),
                DefaultValue = "0.15",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings StarSystem.DatapadChanceInDropContainers 0.75",
                ValueType = HelpController.ConfigurationValueType.Decimal
            }
        };

        [XmlElement]
        public bool AutoGenerateStarSystemGps { get; set; } = true;

        [XmlElement]
        public bool AddAllInfoToStarSystemGps { get; set; } = true;

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
