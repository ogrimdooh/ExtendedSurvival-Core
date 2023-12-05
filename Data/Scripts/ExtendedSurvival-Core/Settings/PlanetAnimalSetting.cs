using ProtoBuf;
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
                NeedRestart = true
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

        public MyPlanetAnimalSpawnInfo GetDaySpawnDefinition()
        {
            if (!DaySpawn.Enabled)
                return new MyPlanetAnimalSpawnInfo();
            return new MyPlanetAnimalSpawnInfo()
            {
                Animals = Animals.Select(x=>new MyPlanetAnimal() { AnimalType = x.Id }).ToArray(),
                SpawnDelayMin = DaySpawn.SpawnDelay.X,
                SpawnDelayMax = DaySpawn.SpawnDelay.Y,
                SpawnDistMin = DaySpawn.SpawnDist.X,
                SpawnDistMax = DaySpawn.SpawnDist.Y,
                WaveCountMin = DaySpawn.WaveCount.X,
                WaveCountMax = DaySpawn.WaveCount.Y
            };
        }

        public MyPlanetAnimalSpawnInfo GetNightSpawnDefinition()
        {
            if (!NightSpawn.Enabled)
                return new MyPlanetAnimalSpawnInfo();
            return new MyPlanetAnimalSpawnInfo()
            {
                Animals = Animals.Select(x => new MyPlanetAnimal() { AnimalType = x.Id }).ToArray(),
                SpawnDelayMin = NightSpawn.SpawnDelay.X,
                SpawnDelayMax = NightSpawn.SpawnDelay.Y,
                SpawnDistMin = NightSpawn.SpawnDist.X,
                SpawnDistMax = NightSpawn.SpawnDist.Y,
                WaveCountMin = NightSpawn.WaveCount.X,
                WaveCountMax = NightSpawn.WaveCount.Y
            };
        }

    }

}
