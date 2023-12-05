using ProtoBuf;
using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMaterialSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.VoxelMaterials";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Id"),
                Title = "Id",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_ID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.UsingTechnology"),
                Title = "UsingTechnology",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_USINGTECHNOLOGY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Version"),
                Title = "Version",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_VERSION_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MinedOreRatio"),
                Title = "MinedOreRatio",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_MINEDORERATIO_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                ValueType = HelpController.ConfigurationValueType.Decimal,
                CommandSample = "/voxel.settings Iron_01 MinedOreRatio 5.2"
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.SpawnsFromMeteorites"),
                Title = "SpawnsFromMeteorites",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_SPAWNSFROMMETEORITES_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                ValueType = HelpController.ConfigurationValueType.Bool,
                CommandSample = "/voxel.settings Iron_01 SpawnsFromMeteorites false"
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.SpawnsInAsteroids"),
                Title = "SpawnsInAsteroids",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_SPAWNSINASTEROIDS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                ValueType = HelpController.ConfigurationValueType.Bool,
                CommandSample = "/voxel.settings Iron_01 SpawnsInAsteroids true"
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AsteroidSpawnProbabilityMultiplier"),
                Title = "AsteroidSpawnProbabilityMultiplier",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_ASTEROIDSPAWNPROBABILITYMULTIPLIER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                ValueType = HelpController.ConfigurationValueType.Integer,
                CommandSample = "/voxel.settings Iron_01 AsteroidSpawnProbabilityMultiplier 3"
            }
        };

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public int Version { get; set; } = 0;

        [XmlElement]
        public float MinedOreRatio { get; set; }

        [XmlElement]
        public bool SpawnsFromMeteorites { get; set; }

        [XmlElement]
        public bool SpawnsInAsteroids { get; set; }

        [XmlElement]
        public int AsteroidSpawnProbabilityMultiplier { get; set; }

    }

}
