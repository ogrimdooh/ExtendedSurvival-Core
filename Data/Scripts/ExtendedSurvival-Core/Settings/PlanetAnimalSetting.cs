using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Animal";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Animals"),
                Title = "Animals",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_ANIMALS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.animals $ add Wolf" + Environment.NewLine + 
                                "/planet.animals Pertam remove Wolf" + Environment.NewLine +
                                "/planet.animals Pertam clear",
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DaySpawn"),
                Title = "DaySpawn",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_DAYSPAWN_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = PlanetAnimalSpawnSetting.GetHelpInfo("DaySpawn", LanguageProvider.GetEntry(LanguageEntries.TERMS_DAY))
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NightSpawn"),
                Title = "NightSpawn",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_NIGHTSPAWN_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = PlanetAnimalSpawnSetting.GetHelpInfo("NightSpawn", LanguageProvider.GetEntry(LanguageEntries.TERMS_NIGHT))
            }
        };

        [XmlArray("Animals"), XmlArrayItem("Animal", typeof(PlanetAnimalEntrySetting))]
        public List<PlanetAnimalEntrySetting> Animals { get; set; } = new List<PlanetAnimalEntrySetting>();

        [XmlElement]
        public PlanetAnimalSpawnSetting DaySpawn { get; set; } = new PlanetAnimalSpawnSetting();

        [XmlElement]
        public PlanetAnimalSpawnSetting NightSpawn { get; set; } = new PlanetAnimalSpawnSetting();

    }

}
