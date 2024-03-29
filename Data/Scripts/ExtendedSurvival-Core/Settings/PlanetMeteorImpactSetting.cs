﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetMeteorImpactSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.MeteorImpact";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_ENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.meteorimpact $ set Enabled true" + Environment.NewLine + "/planet.meteorimpact Pertam set Enabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ChanceToSpawn"),
                Title = "ChanceToSpawn",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_CHANCETOSPAWN_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.meteorimpact $ set ChanceToSpawn 0.75" + Environment.NewLine + "/planet.meteorimpact Pertam set ChanceToSpawn 0.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, MeteorImpactStoneSetting.HELP_TOPIC_SUBTYPE),
                Title = "Stones",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                Entries = MeteorImpactStoneSetting.HELP_INFO,
                CommandSample = "/planet.meteorimpact $ add StoneCoverageIronCore:EarthDesertArea:1" + Environment.NewLine +
                                "/planet.meteorimpact Pertam clear"
            }
        };

        [XmlElement]
        public bool Enabled { get; set; } = true;

        [XmlElement]
        public float ChanceToSpawn { get; set; } = 0.25f;

        [XmlArray("Stones"), XmlArrayItem("Stone", typeof(MeteorImpactStoneSetting))]
        public List<MeteorImpactStoneSetting> Stones { get; set; } = new List<MeteorImpactStoneSetting>();

    }

}
