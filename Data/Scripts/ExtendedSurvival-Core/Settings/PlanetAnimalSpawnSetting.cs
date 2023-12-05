﻿using ProtoBuf;
using System.Xml.Serialization;
using VRageMath;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalSpawnSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Animal.";
        public static HelpController.ConfigurationEntryHelpInfo[] GetHelpInfo(string prefix, string replace)
        {
            return new HelpController.ConfigurationEntryHelpInfo[]
            {
                new HelpController.ConfigurationEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}{prefix}.Enabled"),
                    Title = "Enabled",
                    Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_ENABLED_DESCRIPTION), replace),
                    DefaultValue = "",
                    CanUseSettingsCommand = true,
                    NeedRestart = true
                },
                new HelpController.ConfigurationEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}{prefix}.SpawnDelay"),
                    Title = "SpawnDelay",
                    Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_SPAWNDELAY_DESCRIPTION), replace),
                    DefaultValue = "",
                    CanUseSettingsCommand = true,
                    NeedRestart = true
                },
                new HelpController.ConfigurationEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}{prefix}.SpawnDist"),
                    Title = "SpawnDist",
                    Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_SPAWNDIST_DESCRIPTION), replace),
                    DefaultValue = "",
                    CanUseSettingsCommand = true,
                    NeedRestart = true
                },
                new HelpController.ConfigurationEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}{prefix}.WaveCount"),
                    Title = "WaveCount",
                    Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_WAVECOUNT_DESCRIPTION), replace),
                    DefaultValue = "",
                    CanUseSettingsCommand = true,
                    NeedRestart = true
                }
            };
        }

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public Vector2I SpawnDelay { get; set; }

        [XmlElement]
        public Vector2I SpawnDist { get; set; }

        [XmlElement]
        public Vector2I WaveCount { get; set; }

    }

}
