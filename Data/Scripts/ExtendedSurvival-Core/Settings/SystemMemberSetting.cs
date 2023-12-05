using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SystemMemberSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.StarSystems.Members";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Name"),
                Title = "Name",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_NAME_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MemberType"),
                Title = "MemberType",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_MEMBERTYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DefinitionSubtype"),
                Title = "DefinitionSubtype",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_DEFINITIONSUBTYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.HasRing"),
                Title = "HasRing",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_HASRING_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Density"),
                Title = "Density",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_DENSITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Order"),
                Title = "Order",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_ORDER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MoonCount"),
                Title = "MoonCount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_MOONCOUNT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ValidMoons"),
                Title = "ValidMoons",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_VALIDMOONS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            }
        };

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int MemberType { get; set; }

        [XmlElement]
        public string DefinitionSubtype { get; set; }

        [XmlElement]
        public bool HasRing { get; set; }

        [XmlElement]
        public float Density { get; set; }

        [XmlElement]
        public int Order { get; set; }

        [XmlElement]
        public DocumentedVector2 MoonCount { get; set; } = new DocumentedVector2(0, 0, StarSystemSetting.TOTALMEMBERS_INFO);

        [XmlArray("ValidMoons"), XmlArrayItem("ValidMoon", typeof(ValidMoonEntrySetting))]
        public List<ValidMoonEntrySetting> ValidMoons { get; set; } = new List<ValidMoonEntrySetting>();

    }

}
