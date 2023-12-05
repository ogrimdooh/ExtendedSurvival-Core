using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMapModifierOptionSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.MaterialModifiers.Options";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.IdFrom"),
                Title = "IdFrom",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_OPTIONS_IDFROM_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.IdTo"),
                Title = "IdTo",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_OPTIONS_IDTO_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Default"),
                Title = "Default",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_OPTIONS_DEFAULT_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            }
        };

        [XmlElement]
        public string IdFrom { get; set; }

        [XmlElement]
        public string IdTo { get; set; }

        [XmlElement]
        public bool Default { get; set; }

    }

}
