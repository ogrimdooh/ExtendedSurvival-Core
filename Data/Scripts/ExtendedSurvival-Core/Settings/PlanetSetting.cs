using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Id"),
                Title = "Id",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.UsingTechnology"),
                Title = "UsingTechnology",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_USINGTECHNOLOGY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RespawnEnabled"),
                Title = "RespawnEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_RESPAWNENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.settings $ RespawnEnabled true" + Environment.NewLine + "/planet.settings Pertam RespawnEnabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Seed"),
                Title = "Seed",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SEED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Version"),
                Title = "Version",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_VERSION_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DeepMultiplier"),
                Title = "DeepMultiplier",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_DEEPMULTIPLIER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Type"),
                Title = "Type",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_TYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.settings $ Type 0" + Environment.NewLine + "/planet.settings Pertam Type 1",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AddedOres"),
                Title = "AddedOres",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ADDEDORES_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RemovedOres"),
                Title = "RemovedOres",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_REMOVEDORES_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ClearOresBeforeAdd"),
                Title = "ClearOresBeforeAdd",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_CLEARORESBEFOREADD_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.TargetColor"),
                Title = "TargetColor",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_TARGETCOLOR_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.UseColorInfluence"),
                Title = "UseColorInfluence",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_USECOLORINFLUENCE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.OreGroupType"),
                Title = "OreGroupType",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_OREGROUPTYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ColorInfluence"),
                Title = "ColorInfluence",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_COLORINFLUENCE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.SizeRange"),
                Title = "SizeRange",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SIZERANGE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.settings $ SizeRange 35:60" + Environment.NewLine + "/planet.settings Pertam SizeRange 32.5:80",
                ValueType = HelpController.ConfigurationValueType.Vector2
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, AtmosphereSetting.HELP_TOPIC_SUBTYPE),
                Title = "Atmosphere",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = AtmosphereSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, GeothermalSetting.HELP_TOPIC_SUBTYPE),
                Title = "Geothermal",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = GeothermalSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, GravitySetting.HELP_TOPIC_SUBTYPE),
                Title = "Gravity",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = GravitySetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, WaterSetting.HELP_TOPIC_SUBTYPE),
                Title = "Water",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_WATER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = WaterSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, PlanetAnimalSetting.HELP_TOPIC_SUBTYPE),
                Title = "Animal",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = PlanetAnimalSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, SuperficialMiningSetting.HELP_TOPIC_SUBTYPE),
                Title = "SuperficialMining",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = SuperficialMiningSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, PlanetOreMapEntrySetting.HELP_TOPIC_SUBTYPE),
                Title = "OreMap",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                Entries = PlanetOreMapEntrySetting.HELP_INFO,
                CommandSample = "/planet.oremap $ generate seed=5514752" + Environment.NewLine +
                                "/planet.oremap Europa generate profile=Oi" + Environment.NewLine +
                                "/planet.oremap EarthLike clear add=Iron,Mercury,Sulfur" + Environment.NewLine +
                                "/planet.oremap Pertam generate deep=2 profile=Moon targetColor=#000000 colorInfluence=50|150"
            }
        };

        public const string SIZERANGE_INFO = "X: Min Size. Y: Max Size.";
        public const string INFLUENCERANGE_INFO = "X: Min Influence. Y: Max Influence.";

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public bool UsingBetterStone { get; set; } = false;
        
        [XmlElement]
        public bool RespawnEnabled { get; set; } = false;

        [XmlElement]
        public int Seed { get; set; }

        [XmlElement]
        public int Version { get; set; } = 0;

        [XmlElement]
        public float DeepMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public int Type { get; set; } = 0;

        [XmlElement]
        public string AddedOres { get; set; }

        [XmlElement]
        public string RemovedOres { get; set; }

        [XmlElement]
        public bool ScarceEnabled { get; set; }

        [XmlElement]
        public bool ClearOresBeforeAdd { get; set; }

        [XmlElement]
        public string TargetColor { get; set; }

        [XmlElement]
        public bool UseColorInfluence { get; set; }

        [XmlElement]
        public int OreGroupType { get; set; } = 0;
        
        [XmlElement]
        public DocumentedVector2 ColorInfluence { get; set; } = new DocumentedVector2(0, 0, INFLUENCERANGE_INFO);

        [XmlElement]
        public DocumentedVector2 SizeRange { get; set; } = new DocumentedVector2(0, 0, SIZERANGE_INFO);

        [XmlElement]
        public AtmosphereSetting Atmosphere { get; set; } = new AtmosphereSetting();

        [XmlElement]
        public GeothermalSetting Geothermal { get; set; } = new GeothermalSetting();

        [XmlElement]
        public GravitySetting Gravity { get; set; } = new GravitySetting();

        [XmlElement]
        public WaterSetting Water { get; set; } = new WaterSetting();

        [XmlElement]
        public PlanetAnimalSetting Animal { get; set; } = new PlanetAnimalSetting();

        [XmlArray("Biomes"), XmlArrayItem("Biome", typeof(PlanetBiomeSetting))]
        public List<PlanetBiomeSetting> Biomes { get; set; } = new List<PlanetBiomeSetting>();

        [XmlElement]
        public SuperficialMiningSetting SuperficialMining { get; set; } = new SuperficialMiningSetting();

        [XmlArray("OreMap"), XmlArrayItem("Ore", typeof(PlanetOreMapEntrySetting))]
        public List<PlanetOreMapEntrySetting> OreMap { get; set; } = new List<PlanetOreMapEntrySetting>();

        public MyPlanetOreMapping[] GetOreMap()
        {
            return OreMap.Select(x => x.GetDefinition()).ToArray();
        }

    }

}
