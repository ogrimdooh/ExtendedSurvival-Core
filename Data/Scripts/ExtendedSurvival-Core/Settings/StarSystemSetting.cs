using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.StarSystems";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Name"),
                Title = "Name",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_NAME_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Type"),
                Title = "Type",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_TYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.PlanetProfile"),
                Title = "PlanetProfile",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_PLANETPROFILE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.StarName"),
                Title = "StarName",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_STARNAME_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, SystemMemberSetting.HELP_TOPIC_SUBTYPE),
                Title = "Members",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_MEMBERS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = SystemMemberSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TotalMembers"),
                Title = "TotalMembers",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_TOTALMEMBERS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DefaultMoonCount"),
                Title = "DefaultMoonCount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DEFAULTMOONCOUNT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DefaultBeltCount"),
                Title = "DefaultBeltCount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DEFAULTBELTCOUNT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DefaultRingCount"),
                Title = "DefaultRingCount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DEFAULTRINGCOUNT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DefaultDensity"),
                Title = "DefaultDensity",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DEFAULTDENSITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DistanceMultiplier"),
                Title = "DistanceMultiplier",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DISTANCEMULTIPLIER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.WithStar"),
                Title = "WithStar",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_WITHSTAR_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AllowDuplicate"),
                Title = "AllowDuplicate",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_ALLOWDUPLICATE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.VanillaAsteroids"),
                Title = "VanillaAsteroids",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_VANILLAASTEROIDS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Version"),
                Title = "Version",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_VERSION_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            }
        };

        public const string TOTALMEMBERS_INFO = "X: Min Ammount. Y: Max Ammount.";
        public const string SIZEMULTIPLIER_INFO = "X: Min Size Multiplier. Y: Max Size Multiplier.";

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int Type { get; set; }

        [XmlElement]
        public int PlanetProfile { get; set; }

        [XmlElement]
        public string StarName { get; set; }

        [XmlArray("Members"), XmlArrayItem("Member", typeof(SystemMemberSetting))]
        public List<SystemMemberSetting> Members { get; set; } = new List<SystemMemberSetting>();

        [XmlElement]
        public DocumentedVector2 TotalMembers { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultMoonCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultBeltCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultRingCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public float DefaultDensity { get; set; } = 0.75f;

        [XmlElement]
        public float DistanceMultiplier { get; set; } = 1f;

        [XmlElement]
        public bool WithStar { get; set; } = false;

        [XmlElement]
        public bool AllowDuplicate { get; set; } = false;

        [XmlElement]
        public bool VanillaAsteroids { get; set; } = false;

        [XmlElement]
        public int Version { get; set; } = 0;

    }

}
