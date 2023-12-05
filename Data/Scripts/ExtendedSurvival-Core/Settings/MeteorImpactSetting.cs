using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorImpactSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.MeteorImpact";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_METEORIMPACT_ENABLED_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings MeteorImpact.Enabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DistanceToSpawn"),
                Title = "DistanceToSpawn",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_METEORIMPACT_DISTANCETOSPAWN_DESCRIPTION),
                DefaultValue = "2500",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings MeteorImpact.DistanceToSpawn 750.50",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.StoneLifeTime"),
                Title = "StoneLifeTime",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_METEORIMPACT_STONELIFETIME_DESCRIPTION),
                DefaultValue = "3600",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings MeteorImpact.StoneLifeTime 1250",
                ValueType = HelpController.ConfigurationValueType.Integer
            }
        };

        [XmlElement]
        public bool Enabled { get; set; } = true;

        [XmlElement]
        public float DistanceToSpawn { get; set; } = 2500.0f;

        [XmlElement]
        public long StoneLifeTime { get; set; } = 3600;

    }

}
