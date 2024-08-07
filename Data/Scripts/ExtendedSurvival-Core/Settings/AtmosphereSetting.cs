﻿using ProtoBuf;
using System;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class AtmosphereSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Atmosphere";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_ENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set Enabled true" + Environment.NewLine + "/planet.atmosphere Pertam set Enabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Breathable"),
                Title = "Breathable",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_BREATHABLE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set Breathable true" + Environment.NewLine + "/planet.atmosphere Pertam set Breathable false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.OxygenDensity"),
                Title = "OxygenDensity",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_OXYGENDENSITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set OxygenDensity 0.25" + Environment.NewLine + "/planet.atmosphere Pertam set OxygenDensity 0.75",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Density"),
                Title = "Density",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_DENSITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set Density 0.25" + Environment.NewLine + "/planet.atmosphere Pertam set Density 0.75",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.LimitAltitude"),
                Title = "LimitAltitude",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_LIMITALTITUDE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set LimitAltitude 1.25" + Environment.NewLine + "/planet.atmosphere Pertam set LimitAltitude 2.05",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MaxWindSpeed"),
                Title = "MaxWindSpeed",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_MAXWINDSPEED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set MaxWindSpeed 75.25" + Environment.NewLine + "/planet.atmosphere Pertam set MaxWindSpeed 105.10",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TemperatureLevel"),
                Title = "TemperatureLevel",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TEMPERATURELEVEL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set TemperatureLevel 1" + Environment.NewLine + "/planet.atmosphere Pertam set TemperatureLevel 0",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TemperatureRange"),
                Title = "TemperatureRange",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TEMPERATURERANGE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set TemperatureRange 0:25" + Environment.NewLine + "/planet.atmosphere Pertam set TemperatureRange -10.5:45",
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ToxicLevel"),
                Title = "ToxicLevel",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TOXICLEVEL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set ToxicLevel 0.25" + Environment.NewLine + "/planet.atmosphere Pertam set ToxicLevel 0.80",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RadiationLevel"),
                Title = "RadiationLevel",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_RADIATIONLEVEL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.atmosphere $ set RadiationLevel 0.25" + Environment.NewLine + "/planet.atmosphere Pertam set RadiationLevel 0.80",
                ValueType = HelpController.ConfigurationValueType.Decimal
            }
        };

        public const string TEMPERATURE_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public bool Breathable { get; set; }

        [XmlElement]
        public float OxygenDensity { get; set; }

        [XmlElement]
        public float Density { get; set; }

        [XmlElement]
        public float LimitAltitude { get; set; }

        [XmlElement]
        public float MaxWindSpeed { get; set; }

        [XmlElement]
        public int TemperatureLevel { get; set; } = 0;

        [XmlElement]
        public DocumentedVector2 TemperatureRange { get; set; } = new DocumentedVector2(0, 0, TEMPERATURE_RANGE_INFO);

        [XmlElement]
        public float ToxicLevel { get; set; } = 0;

        [XmlElement]
        public float RadiationLevel { get; set; } = 0;

        public MyPlanetAtmosphere GetAtmosphere()
        {
            return new MyPlanetAtmosphere()
            {
                Breathable = Breathable,
                Density = Density,
                OxygenDensity = OxygenDensity,
                LimitAltitude = LimitAltitude,
                MaxWindSpeed = MaxWindSpeed
            };
        }

    }

}
