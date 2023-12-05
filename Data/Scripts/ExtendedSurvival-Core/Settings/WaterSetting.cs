using ProtoBuf;
using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class WaterSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Water";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_ENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.water $ set Enabled true" + Environment.NewLine + "/planet.water Pertam set Enabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Size"),
                Title = "Size",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_SIZE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.water $ set Size 1.255" + Environment.NewLine + "/planet.water Pertam set Size 0.5",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TemperatureFactor"),
                Title = "TemperatureFactor",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_TEMPERATUREFACTOR_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.water $ set TemperatureFactor 0.75" + Environment.NewLine + "/planet.water Pertam set TemperatureFactor 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ToxicLevel"),
                Title = "ToxicLevel",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_TOXICLEVEL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.water $ set ToxicLevel 0.75" + Environment.NewLine + "/planet.water Pertam set ToxicLevel 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RadiationLevel"),
                Title = "RadiationLevel",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_RADIATIONLEVEL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.water $ set RadiationLevel 0.75" + Environment.NewLine + "/planet.water Pertam set RadiationLevel 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            }
        };

        public const string TEMPERATURE_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public float Size { get; set; }

        [XmlElement]
        public float TemperatureFactor { get; set; } = 0;

        [XmlElement]
        public float ToxicLevel { get; set; } = 0;

        [XmlElement]
        public float RadiationLevel { get; set; } = 0;

    }

}
