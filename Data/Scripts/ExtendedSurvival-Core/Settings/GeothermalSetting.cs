using ProtoBuf;
using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class GeothermalSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Geothermal";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_ENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set Enabled true" + Environment.NewLine + "/planet.atmosphere Pertam set Enabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Start"),
                Title = "Start",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_START_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set Start 35.8" + Environment.NewLine + "/planet.atmosphere Pertam set Start 78.9",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RowSize"),
                Title = "RowSize",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_ROWSIZE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set RowSize 35.8" + Environment.NewLine + "/planet.atmosphere Pertam set RowSize 78.9",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Power"),
                Title = "Power",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_POWER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set Power 250.8" + Environment.NewLine + "/planet.atmosphere Pertam set Power 1024.9",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MaxPower"),
                Title = "MaxPower",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_MAXPOWER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set MaxPower 250.8" + Environment.NewLine + "/planet.atmosphere Pertam set MaxPower 1024.9",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Increment"),
                Title = "Increment",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_INCREMENT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.geothermal $ set Increment 250.8" + Environment.NewLine + "/planet.atmosphere Pertam set Increment 1024.9",
                ValueType = HelpController.ConfigurationValueType.Decimal
            }
        };

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public float Start { get; set; }

        [XmlElement]
        public float RowSize { get; set; }

        [XmlElement]
        public float Power { get; set; }

        [XmlElement]
        public float MaxPower { get; set; }

        [XmlElement]
        public float Increment { get; set; }

    }

}
