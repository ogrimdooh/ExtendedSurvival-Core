using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class CombatSetting 
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.CombatSetting";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NoGrindFunctionalGrids"),
                Title = "NoGrindFunctionalGrids",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_NOGRINDFUNCTIONALGRIDS_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.NoGrindFunctionalGrids true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NoGridSelfDamage"),
                Title = "NoGridSelfDamage",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_NOGRIDSELFDAMAGE_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.NoGridSelfDamage true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.LogAllPvPDamage"),
                Title = "LogAllPvPDamage",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_LOGALLPVPDAMAGE_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.LogAllPvPDamage true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ForceEnemyToFactions"),
                Title = "ForceEnemyToFactions",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_FORCEENEMYTOFACTIONS_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.ForceEnemyToFactions false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TargetEnemyFactions"),
                Title = "TargetEnemyFactions",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_TARGETENEMYFACTIONS_DESCRIPTION),
                DefaultValue = "SPRT;SPID",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.TargetEnemyFactions SPRT;SPID;WOLF",
                ValueType = HelpController.ConfigurationValueType.String
            }
        };

        [XmlElement]
        public bool NoGrindFunctionalGrids { get; set; } = false;

        [XmlElement]
        public bool NoGridSelfDamage { get; set; } = false;

        [XmlElement]
        public bool NoSelfOwnerDamage { get; set; } = false;

        [XmlElement]
        public bool LogAllPvPDamage { get; set; } = false;

        [XmlElement]
        public bool ForceEnemyToFactions { get; set; } = true;

        [XmlElement]
        public string TargetEnemyFactions { get; set; } = "SPRT;SPID";

    }

}
