using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class DecaySettings
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.DecaySettings";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_ENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.Enabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.CycleTick"),
                Title = "CycleTick",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_CYCLETICK_DESCRIPTION),
                DefaultValue = "3600000",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.CycleTick 75000",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.BlockPercentCycle"),
                Title = "BlockPercentCycle",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_BLOCKPERCENTCYCLE_DESCRIPTION),
                DefaultValue = "0.05",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.BlockPercentCycle 0.15",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ArmorPercentBlock"),
                Title = "ArmorPercentBlock",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_ARMORPERCENTBLOCK_DESCRIPTION),
                DefaultValue = "0.6",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.ArmorPercentBlock 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NewBlocksPercent"),
                Title = "NewBlocksPercent",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_NEWBLOCKSPERCENT_DESCRIPTION),
                DefaultValue = "0.75",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.NewBlocksPercent 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TimeToDecay"),
                Title = "TimeToDecay",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_TIMETODECAY_DESCRIPTION),
                DefaultValue = "0.75",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.TimeToDecay 20160",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.IgnoreGridProtection"),
                Title = "IgnoreGridProtection",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_IGNOREGRIDPROTECTION_DESCRIPTION),
                DefaultValue = "true",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.IgnoreGridProtection false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RustDamage"),
                Title = "RustDamage",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_RUSTDAMAGE_DESCRIPTION),
                DefaultValue = "0.1",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.RustDamage 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DamageCycleTick"),
                Title = "DamageCycleTick",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_DAMAGECYCLETICK_DESCRIPTION),
                DefaultValue = "10000",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.DamageCycleTick 2500",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MaxBlockEachCycle"),
                Title = "MaxBlockEachCycle",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DECAYSETTING_MAXBLOCKEACHCYCLE_DESCRIPTION),
                DefaultValue = "50",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Decay.MaxBlockEachCycle 100",
                ValueType = HelpController.ConfigurationValueType.Integer
            }
        };

        [XmlElement]
        public bool Enabled { get; set; } = false;

        [XmlElement]
        public int CycleTick { get; set; } = 3600000; /* 1 hora */

        [XmlElement]
        public int DamageCycleTick { get; set; } = 10000; /* 10 seconds */

        [XmlElement]
        public int MaxBlockEachCycle { get; set; } = 50; 
        
        [XmlElement]
        public float BlockPercentCycle { get; set; } = 0.05f;

        [XmlElement]
        public float ArmorPercentBlock { get; set; } = 0.6f;

        [XmlElement]
        public float NewBlocksPercent { get; set; } = 0.75f;

        [XmlElement]
        public int TimeToDecay { get; set; } = 10080; /* 7 dias */

        [XmlElement]
        public bool IgnoreGridProtection { get; set; } = true;

        [XmlElement]
        public float RustDamage { get; set; } = 0.1f;

    }

}
