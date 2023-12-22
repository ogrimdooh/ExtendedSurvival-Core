using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ExtendedSurvivalSettings : BaseSettings
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[] 
        { 
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Debug"),
                Title = "Debug",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DEBUG_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Debug true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DinamicWoodGridEnabled"),
                Title = "DinamicWoodGridEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DINAMICWOODGRIDENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings DinamicWoodGridEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DinamicStoneGridEnabled"),
                Title = "DinamicStoneGridEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DINAMICSTONEGRIDENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings DinamicStoneGridEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DinamicConcreteGridEnabled"),
                Title = "DinamicConcreteGridEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DINAMICCONCRETEGRIDENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings DinamicConcreteGridEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RotEnabled"),
                Title = "RotEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_ROTENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings RotEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DisableWaterModFreeIce"),
                Title = "DisableWaterModFreeIce",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DISABLEWATERMODFREEICE_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings DisableWaterModFreeIce true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RespawnSpacePodEnabled"),
                Title = "RespawnSpacePodEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_RESPAWNSPACEPODENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings RespawnSpacePodEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.RespawnLargePodEnabled"),
                Title = "RespawnLargePodEnabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_RESPAWNLARGEPODENABLED_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings RespawnLargePodEnabled true",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.PlanetDeployAltitude"),
                Title = "PlanetDeployAltitude",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETDEPLOYALTITUDE_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings PlanetDeployAltitude 150",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.MoonDeployAltitude"),
                Title = "MoonDeployAltitude",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MOONDEPLOYALTITUDE_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings MoonDeployAltitude 150",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.DropContainerDeployHeight"),
                Title = "DropContainerDeployHeight",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DROPCONTAINERDEPLOYHEIGHT_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/settings DropContainerDeployHeight 150",
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, TradeStationSetting.HELP_TOPIC_SUBTYPE),
                Title = "TradeStations",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_TRADESTATIONS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = TradeStationSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, MeteorImpactSetting.HELP_TOPIC_SUBTYPE),
                Title = "MeteorImpact",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_METEORIMPACT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = MeteorImpactSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, CombatSetting.HELP_TOPIC_SUBTYPE),
                Title = "Combat",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = CombatSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, PlanetSetting.HELP_TOPIC_SUBTYPE),
                Title = "Planets",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = PlanetSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, VoxelMaterialSetting.HELP_TOPIC_SUBTYPE),
                Title = "VoxelMaterials",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_VOXELMATERIALS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = VoxelMaterialSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, VoxelMaterialModifierSetting.HELP_TOPIC_SUBTYPE),
                Title = "MaterialModifiers",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = VoxelMaterialModifierSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, StarSystemGlobalSetting.HELP_TOPIC_SUBTYPE),
                Title = "StarSystemConfiguration",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMCONFIGURATION_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = StarSystemGlobalSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, StarSystemSetting.HELP_TOPIC_SUBTYPE),
                Title = "StarSystems",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_STARSYSTEMS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                Entries = StarSystemSetting.HELP_INFO
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.IgnorePlanets"),
                Title = "IgnorePlanets",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_IGNOREPLANETS_DESCRIPTION),
                DefaultValue = "SYSTEMTESTMAP;EARTHLIKEMODEXAMPLE;MARSTUTORIAL;" + Environment.NewLine + "MOONTUTORIAL;EARTHLIKETUTORIAL",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            }
        };

        private const int CURRENT_VERSION = 2;
        private const string FILE_NAME = "ExtendedSurvival.Core.Settings.xml";

        private static ExtendedSurvivalSettings _instance;
        public static ExtendedSurvivalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        [XmlElement]
        public bool Debug { get; set; } = false;

        [XmlElement]
        public bool DinamicWoodGridEnabled { get; set; } = false;

        [XmlElement]
        public bool DinamicStoneGridEnabled { get; set; } = false;

        [XmlElement]
        public bool DinamicConcreteGridEnabled { get; set; } = false;

        [XmlElement]
        public bool RotEnabled { get; set; } = true;

        [XmlElement]
        public bool DisableWaterModFreeIce { get; set; } = true;

        [XmlElement]
        public bool RespawnSpacePodEnabled { get; set; } = false;

        [XmlElement]
        public bool RespawnLargePodEnabled { get; set; } = false;

        [XmlElement]
        public int PlanetDeployAltitude { get; set; } = 6;

        [XmlElement]
        public int MoonDeployAltitude { get; set; } = 6;

        [XmlElement]
        public int DropContainerDeployHeight { get; set; } = 1000;

        [XmlElement]
        public TradeStationSetting TradeStations { get; set; } = new TradeStationSetting();

        [XmlElement]
        public MeteorImpactSetting MeteorImpact { get; set; } = new MeteorImpactSetting();

        [XmlElement]
        public CombatSetting Combat { get; set; } = new CombatSetting();

        [XmlArray("Planets"), XmlArrayItem("Planet", typeof(PlanetSetting))]
        public List<PlanetSetting> Planets { get; set; } = new List<PlanetSetting>();

        [XmlArray("VoxelMaterials"), XmlArrayItem("VoxelMaterial", typeof(VoxelMaterialSetting))]
        public List<VoxelMaterialSetting> VoxelMaterials { get; set; } = new List<VoxelMaterialSetting>();

        [XmlArray("MaterialModifiers"), XmlArrayItem("MaterialModifier", typeof(VoxelMaterialModifierSetting))]
        public List<VoxelMaterialModifierSetting> MaterialModifiers { get; set; } = new List<VoxelMaterialModifierSetting>();

        [XmlElement]
        public StarSystemGlobalSetting StarSystemConfiguration { get; set; } = new StarSystemGlobalSetting();

        [XmlArray("StarSystems"), XmlArrayItem("StarSystem", typeof(StarSystemSetting))]
        public List<StarSystemSetting> StarSystems { get; set; } = new List<StarSystemSetting>();
        
        [XmlElement]
        public string IgnorePlanets { get; set; } = "SYSTEMTESTMAP;EARTHLIKEMODEXAMPLE;MARSTUTORIAL;MOONTUTORIAL;EARTHLIKETUTORIAL";

        private static bool Validate(ExtendedSurvivalSettings settings)
        {
            var res = true;
            return res;
        }

        private static ExtendedSurvivalSettings Upgrade(ExtendedSurvivalSettings settings)
        {
            if (settings.Version < 2)
            {
                var keys = StarSystemMapProfile.SYSTEMS_PROFILES.Keys.Select(x => x.ToUpper()).ToArray();
                settings.StarSystems.RemoveAll(x => keys.Contains(x.Name.ToUpper()));
            }
            return settings;
        }

        public static ExtendedSurvivalSettings Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); }, Upgrade);
            return _instance;
        }

        public static void ClientLoad(string data)
        {
            _instance = GetData<ExtendedSurvivalSettings>(data);
        }

        public string GetDataToClient()
        {
            return GetData(this);
        }

        public static void Save()
        {
            try
            {
                Save<ExtendedSurvivalSettings>(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        public ExtendedSurvivalSettings()
        {

        }

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();

        }

        public bool HasPlanetInfo(string id)
        {
            return Planets.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool HasMaterialModifierInfo(string id)
        {
            return MaterialModifiers.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool PlanetUsingTecnologyForFirstTime(string id)
        {
            return ExtendedSurvivalCoreSession.IsUsingTechnology() && Planets.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim() && !x.UsingTechnology);
        }

        public bool VoxelUsingTecnologyForFirstTime(string id)
        {
            return ExtendedSurvivalCoreSession.IsUsingTechnology() && VoxelMaterials.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim() && !x.UsingTechnology);
        }

        public bool HasStarSystem(string id)
        {
            return StarSystems.Any(x => x.Name.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public VoxelMaterialModifierSetting GetMaterialModifierInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasMaterialModifierInfo(id))
            {
                var settings = MaterialModifiers.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                var starProfile = VoxelMaterialModifierMapProfile.Get(settings.Id);
                if (starProfile != null)
                    settings = starProfile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                var starProfile = VoxelMaterialModifierMapProfile.Get(id);
                if (starProfile != null)
                {
                    var settings = starProfile.BuildSettings(id);
                    MaterialModifiers.Add(settings);
                    return settings;
                }
            }
            return null;
        }

        public StarSystemSetting GetStarSystemInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasStarSystem(id))
            {
                var settings = StarSystems.FirstOrDefault(x => x.Name.ToUpper().Trim() == id.ToUpper().Trim());
                var starProfile = StarSystemMapProfile.Get(settings.Name, true);
                if (starProfile != null)
                    settings = starProfile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                var starProfile = StarSystemMapProfile.Get(id);
                if (starProfile != null)
                {
                    var settings = starProfile.BuildSettings();
                    StarSystems.Add(settings);
                    return settings;
                }
            }
            return null;
        }

        public PlanetSetting GetPlanetInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasPlanetInfo(id) && (!generateWhenNotExists || !PlanetUsingTecnologyForFirstTime(id)))
            {
                var settings = Planets.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                if (!IgnorePlanets.Split(';').Contains(id.ToUpper()))
                {
                    var profile = PlanetMapProfile.Get(id.ToUpper());
                    if (profile != null && profile.Version > settings.Version)
                        settings = profile.UpgradeSettings(settings);
                }
                return settings;
            }
            else if (generateWhenNotExists)
            {
                if (!IgnorePlanets.Split(';').Contains(id.ToUpper()))
                    return GeneratePlanetInfo(id, MyUtils.GetRandomInt(10000000, int.MaxValue), 1.0f, id.ToUpper(), true, GenerateFlags.All,
                        null, null, false, null, null, null);
            }
            return null;
        }

        [Flags]
        public enum GenerateFlags
        {

            None = 0,
            Atmosphere = 1 << 1,
            Geothermal = 1 << 2,
            Gravity = 1 << 3,
            Water = 1 << 4,
            Animal = 1 << 5,
            OreMap = 1 << 6,
            All = Atmosphere | Geothermal | Gravity | Water | Animal | OreMap

        }

        public PlanetSetting GeneratePlanetInfo(string id, int seed, float deep, string profile, bool force, 
            GenerateFlags replaceFlag, string[] addOres, string[] removeOres,  bool clearOresBeforeAdd, string targetColor, 
            Vector2I? colorInfluence, PlanetProfile.OreGroupType? groupType)
        {
            if (!HasPlanetInfo(id) || force)
            {
                var settings = PlanetMapProfile.Get(profile).BuildSettings(id, seed, deep, addOres, removeOres, clearOresBeforeAdd, 
                    targetColor, colorInfluence, groupType);
                if (HasPlanetInfo(id))
                {
                    var atSet = Planets.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                    if ((GenerateFlags.Atmosphere & replaceFlag) != 0)
                    {
                        atSet.Atmosphere = settings.Atmosphere;
                    }
                    if ((GenerateFlags.Geothermal & replaceFlag) != 0)
                    {
                        atSet.Geothermal = settings.Geothermal;
                    }
                    if ((GenerateFlags.Gravity & replaceFlag) != 0)
                    {
                        atSet.Gravity = settings.Gravity;
                    }
                    if ((GenerateFlags.Animal & replaceFlag) != 0)
                    {
                        atSet.Animal = settings.Animal;
                    }
                    if ((GenerateFlags.Water & replaceFlag) != 0)
                    {
                        atSet.Water = settings.Water;
                    }
                    if ((GenerateFlags.OreMap & replaceFlag) != 0)
                    {
                        atSet.Seed = settings.Seed;
                        atSet.ClearOresBeforeAdd = settings.ClearOresBeforeAdd;
                        atSet.TargetColor = settings.TargetColor;
                        atSet.UseColorInfluence = settings.UseColorInfluence;
                        atSet.ColorInfluence = settings.ColorInfluence;
                        atSet.DeepMultiplier = settings.DeepMultiplier;
                        atSet.AddedOres = settings.AddedOres;
                        atSet.RemovedOres = settings.RemovedOres;
                        atSet.OreMap = settings.OreMap;
                        atSet.OreGroupType = settings.OreGroupType;
                    }
                }
                else
                {
                    Planets.Add(settings);
                }
                return settings;
            }
            return GetPlanetInfo(id, false);
        }

        public bool ProcessPlanetSuperficialMiningInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.SuperficialMining = copyProfile.BuildSuperficialMiningSetting(name);
                                return true;
                            }
                        }
                        break;
                    case "add":
                        if (options.Any())
                        {
                            var values = options[0].Split(':');
                            if (values.Length == 5)
                            {
                                var idValues = options[0].Split('|');
                                if (idValues.Length == 2)
                                {
                                    MyStringHash subtype = MyStringHash.GetOrCompute(idValues[1]);
                                    MyObjectBuilderType type;
                                    if (MyObjectBuilderType.TryParse($"MyObjectBuilder_{idValues[0]}", out type))
                                    {
                                        var amountValues = options[1].Split('|');
                                        if (amountValues.Length == 2)
                                        {
                                            float amount_from = 0;
                                            float amount_to = 0;
                                            if (float.TryParse(amountValues[0], out amount_from) &&
                                                float.TryParse(amountValues[1], out amount_to))
                                            {
                                                float addChance = 0;
                                                if (float.TryParse(options[2], out addChance))
                                                {
                                                    bool alowFrac = false;
                                                    if (bool.TryParse(options[3], out alowFrac))
                                                    {
                                                        var validSubTypes = options[4].Split('|');
                                                        if (validSubTypes.Any())
                                                        {
                                                            info.SuperficialMining.Drops.Add(new SuperficialMiningDropSetting()
                                                            {
                                                                ItemId = new MyDefinitionId(type, subtype),
                                                                Ammount = new DocumentedVector2(amount_from, amount_to, SuperficialMiningDropSetting.AMMOUNT_RANGE_INFO),
                                                                Chance = addChance,
                                                                AlowFrac = alowFrac,
                                                                ValidSubType = validSubTypes.Select(x => new SuperficialMiningDropValidSubTypeSetting() 
                                                                { 
                                                                    Id = x
                                                                }).ToList()
                                                            });
                                                            return true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "remove":
                        if (options.Any())
                        {
                            var values = options[0].Split('|');
                            if (values.Length == 2)
                            {
                                MyStringHash subtype = MyStringHash.GetOrCompute(values[1]);
                                MyObjectBuilderType type;
                                if (MyObjectBuilderType.TryParse($"MyObjectBuilder_{values[0]}", out type))
                                {
                                    info.SuperficialMining.Drops.RemoveAll(x => x.ItemId == new MyDefinitionId(type, subtype));
                                    return true;
                                }
                            }
                        }
                        break;
                    case "clear":
                        info.SuperficialMining.Drops.Clear();
                        return true;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.SuperficialMining.Enabled = enabled;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetMeteorImpactInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.MeteorImpact = copyProfile.BuildMeteorImpactSetting();
                                return true;
                            }
                        }
                        break;
                    case "add":
                        if (options.Any())
                        {
                            var values = options[0].Split(':');
                            if (values.Length == 3)
                            {
                                float chance = 0;
                                if (float.TryParse(values[2], out chance))
                                {
                                    info.MeteorImpact.Stones.Add(new MeteorImpactStoneSetting() 
                                    { 
                                        GroupId = values[0],
                                        ModifierId = values[1],
                                        ChanceToSpawn = chance
                                    });
                                    return true;
                                }
                            }
                        }
                        break;
                    case "clear":
                        info.MeteorImpact.Stones.Clear();
                        return true;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.MeteorImpact.Enabled = enabled;
                                        return true;
                                    }
                                    break;
                                case "chancetospawn":
                                    float chancetospawn = 0;
                                    if (float.TryParse(options[1], out chancetospawn))
                                    {
                                        info.MeteorImpact.ChanceToSpawn = chancetospawn;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetGravityInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Gravity = copyProfile.BuildGravitySetting();
                                return true;
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "surfacegravity":
                                    float surfacegravity = 0;
                                    if (float.TryParse(options[1], out surfacegravity))
                                    {
                                        info.Gravity.SurfaceGravity = surfacegravity;
                                        return true;
                                    }
                                    break;
                                case "gravityfalloffpower":
                                    float gravityfalloffpower = 0;
                                    if (float.TryParse(options[1], out gravityfalloffpower))
                                    {
                                        info.Gravity.GravityFalloffPower = gravityfalloffpower;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetAtmosphereInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Atmosphere = copyProfile.BuildAtmosphereSetting();
                                return true;
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.Atmosphere.Enabled = enabled;
                                        return true;
                                    }
                                    break;
                                case "breathable":
                                    bool breathable = false;
                                    if (bool.TryParse(options[1], out breathable))
                                    {
                                        info.Atmosphere.Breathable = breathable;
                                        return true;
                                    }
                                    break;
                                case "oxygendensity":
                                    float oxygendensity = 0;
                                    if (float.TryParse(options[1], out oxygendensity) && oxygendensity >= 0 && oxygendensity <= 1)
                                    {
                                        info.Atmosphere.OxygenDensity = oxygendensity;
                                        return true;
                                    }
                                    break;
                                case "density":
                                    float density = 0;
                                    if (float.TryParse(options[1], out density) && density >= 0 && density <= 1)
                                    {
                                        info.Atmosphere.Density = density;
                                        return true;
                                    }
                                    break;
                                case "limitaltitude":
                                    float limitaltitude = 0;
                                    if (float.TryParse(options[1], out limitaltitude))
                                    {
                                        info.Atmosphere.LimitAltitude = limitaltitude;
                                        return true;
                                    }
                                    break;
                                case "maxwindspeed":
                                    float maxwindspeed = 0;
                                    if (float.TryParse(options[1], out maxwindspeed))
                                    {
                                        info.Atmosphere.MaxWindSpeed = maxwindspeed;
                                        return true;
                                    }
                                    break;
                                case "temperaturelevel":
                                    int temperaturelevel = 0;
                                    if (int.TryParse(options[1], out temperaturelevel) && 
                                        temperaturelevel >= 0 && temperaturelevel <= 4)
                                    {
                                        info.Atmosphere.TemperatureLevel = temperaturelevel;
                                        return true;
                                    }
                                    break;
                                case "temperaturerange":
                                    var temperaturerange = options[1].Split(':');
                                    if (temperaturerange.Length >= 2)
                                    {
                                        float temperaturerange_from = 0;
                                        float temperaturerange_to = 0;
                                        if (float.TryParse(temperaturerange[0], out temperaturerange_from) &&
                                            float.TryParse(temperaturerange[1], out temperaturerange_to))
                                        {
                                            if (temperaturerange_from <= temperaturerange_to)
                                            {
                                                info.Atmosphere.TemperatureRange.X = temperaturerange_from;
                                                info.Atmosphere.TemperatureRange.Y = temperaturerange_to;
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "toxiclevel":
                                    float toxiclevel = 0;
                                    if (float.TryParse(options[1], out toxiclevel))
                                    {
                                        info.Atmosphere.ToxicLevel = toxiclevel;
                                        return true;
                                    }
                                    break;
                                case "radiationlevel":
                                    float radiationlevel = 0;
                                    if (float.TryParse(options[1], out radiationlevel))
                                    {
                                        info.Atmosphere.RadiationLevel = radiationlevel;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetAnimalsInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Animal = copyProfile.BuildAnimalsSetting();
                                return true;
                            }
                        }
                        break;
                    case "add":
                        if (PlanetMapAnimalsProfile.ValidAnimals.ContainsKey(options[0]))
                        {
                            var targetBodToAdd = PlanetMapAnimalsProfile.ValidAnimals[options[0]];
                            if (!info.Animal.Animals.Any(x => x.Id == targetBodToAdd))
                            {
                                info.Animal.Animals.Add(new PlanetAnimalEntrySetting() { Id = targetBodToAdd });
                                return true;
                            }
                        }
                        break;
                    case "remove":
                        if (PlanetMapAnimalsProfile.ValidAnimals.ContainsKey(options[0]))
                        {
                            var targetBodToRemove = PlanetMapAnimalsProfile.ValidAnimals[options[0]];
                            if (info.Animal.Animals.Any(x => x.Id == targetBodToRemove))
                            {
                                info.Animal.Animals.RemoveAll(x => x.Id == targetBodToRemove);
                                return true;
                            }
                        }
                        break;
                    case "clear":
                        info.Animal.Animals.Clear();
                        return true;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "dayspawn.enabled":
                                    bool dayspawnenabled = false;
                                    if (bool.TryParse(options[1], out dayspawnenabled))
                                    {
                                        info.Animal.DaySpawn.Enabled = dayspawnenabled;
                                        return true;
                                    }
                                    break;
                                case "dayspawn.spawndelay":
                                    var dayspawnspawndelay = options[1].Split(':');
                                    if (dayspawnspawndelay.Length >= 2)
                                    {
                                        int dayspawnspawndelay_from = 0;
                                        int dayspawnspawndelay_to = 0;
                                        if (int.TryParse(dayspawnspawndelay[0], out dayspawnspawndelay_from) &&
                                            int.TryParse(dayspawnspawndelay[1], out dayspawnspawndelay_to))
                                        {
                                            if (dayspawnspawndelay_from <= dayspawnspawndelay_to)
                                            {
                                                info.Animal.DaySpawn.SpawnDelay = new Vector2I(dayspawnspawndelay_from, dayspawnspawndelay_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "dayspawn.spawndist":
                                    var dayspawnspawndist = options[1].Split(':');
                                    if (dayspawnspawndist.Length >= 2)
                                    {
                                        int dayspawnspawndist_from = 0;
                                        int dayspawnspawndist_to = 0;
                                        if (int.TryParse(dayspawnspawndist[0], out dayspawnspawndist_from) &&
                                            int.TryParse(dayspawnspawndist[1], out dayspawnspawndist_to))
                                        {
                                            if (dayspawnspawndist_from <= dayspawnspawndist_to)
                                            {
                                                info.Animal.DaySpawn.SpawnDist = new Vector2I(dayspawnspawndist_from, dayspawnspawndist_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "dayspawn.wavecount":
                                    var dayspawnwavecount = options[1].Split(':');
                                    if (dayspawnwavecount.Length >= 2)
                                    {
                                        int dayspawnwavecount_from = 0;
                                        int dayspawnwavecount_to = 0;
                                        if (int.TryParse(dayspawnwavecount[0], out dayspawnwavecount_from) &&
                                            int.TryParse(dayspawnwavecount[1], out dayspawnwavecount_to))
                                        {
                                            if (dayspawnwavecount_from <= dayspawnwavecount_to)
                                            {
                                                info.Animal.DaySpawn.WaveCount = new Vector2I(dayspawnwavecount_from, dayspawnwavecount_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.enabled":
                                    bool nightspawnenabled = false;
                                    if (bool.TryParse(options[1], out nightspawnenabled))
                                    {
                                        info.Animal.NightSpawn.Enabled = nightspawnenabled;
                                        return true;
                                    }
                                    break;
                                case "nightspawn.spawndelay":
                                    var nightspawnspawndelay = options[1].Split(':');
                                    if (nightspawnspawndelay.Length >= 2)
                                    {
                                        int nightspawnspawndelay_from = 0;
                                        int nightspawnspawndelay_to = 0;
                                        if (int.TryParse(nightspawnspawndelay[0], out nightspawnspawndelay_from) &&
                                            int.TryParse(nightspawnspawndelay[1], out nightspawnspawndelay_to))
                                        {
                                            if (nightspawnspawndelay_from <= nightspawnspawndelay_to)
                                            {
                                                info.Animal.NightSpawn.SpawnDelay = new Vector2I(nightspawnspawndelay_from, nightspawnspawndelay_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.spawndist":
                                    var nightspawnspawndist = options[1].Split(':');
                                    if (nightspawnspawndist.Length >= 2)
                                    {
                                        int nightspawnspawndist_from = 0;
                                        int nightspawnspawndist_to = 0;
                                        if (int.TryParse(nightspawnspawndist[0], out nightspawnspawndist_from) &&
                                            int.TryParse(nightspawnspawndist[1], out nightspawnspawndist_to))
                                        {
                                            if (nightspawnspawndist_from <= nightspawnspawndist_to)
                                            {
                                                info.Animal.NightSpawn.SpawnDist = new Vector2I(nightspawnspawndist_from, nightspawnspawndist_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.wavecount":
                                    var nightspawnwavecount = options[1].Split(':');
                                    if (nightspawnwavecount.Length >= 2)
                                    {
                                        int nightspawnwavecount_from = 0;
                                        int nightspawnwavecount_to = 0;
                                        if (int.TryParse(nightspawnwavecount[0], out nightspawnwavecount_from) &&
                                            int.TryParse(nightspawnwavecount[1], out nightspawnwavecount_to))
                                        {
                                            if (nightspawnwavecount_from <= nightspawnwavecount_to)
                                            {
                                                info.Animal.NightSpawn.WaveCount = new Vector2I(nightspawnwavecount_from, nightspawnwavecount_to);
                                                return true;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetWaterInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Water = copyProfile.BuildWaterSetting();
                                return true;
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.Water.Enabled = enabled;
                                        return true;
                                    }
                                    break;
                                case "size":
                                    float size = 0;
                                    if (float.TryParse(options[1], out size))
                                    {
                                        info.Water.Size = size;
                                        return true;
                                    }
                                    break;
                                case "temperaturefactor":
                                    float temperaturefactor = 0;
                                    if (float.TryParse(options[1], out temperaturefactor))
                                    {
                                        info.Water.TemperatureFactor = temperaturefactor;
                                        return true;
                                    }
                                    break;
                                case "toxiclevel":
                                    float toxiclevel = 0;
                                    if (float.TryParse(options[1], out toxiclevel))
                                    {
                                        info.Water.ToxicLevel = toxiclevel;
                                        return true;
                                    }
                                    break;
                                case "radiationlevel":
                                    float radiationlevel = 0;
                                    if (float.TryParse(options[1], out radiationlevel))
                                    {
                                        info.Water.RadiationLevel = radiationlevel;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetThermalInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string target = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(target);
                            if (copyProfile != null)
                            {
                                info.Geothermal = copyProfile.BuildGeothermalSetting();
                                return true;
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.Geothermal.Enabled = enabled;
                                        return true;
                                    }
                                    break;
                                case "start":
                                    float start = 0;
                                    if (float.TryParse(options[1], out start))
                                    {
                                        info.Geothermal.Start = start;
                                        return true;
                                    }
                                    break;
                                case "rowsize":
                                    float rowsize = 0;
                                    if (float.TryParse(options[1], out rowsize))
                                    {
                                        info.Geothermal.RowSize = rowsize;
                                        return true;
                                    }
                                    break;
                                case "power":
                                    float power = 0;
                                    if (float.TryParse(options[1], out power))
                                    {
                                        info.Geothermal.Power = power;
                                        return true;
                                    }
                                    break;
                                case "maxpower":
                                    float maxpower = 0;
                                    if (float.TryParse(options[1], out maxpower))
                                    {
                                        info.Geothermal.MaxPower = maxpower;
                                        return true;
                                    }
                                    break;
                                case "increment":
                                    float increment = 0;
                                    if (float.TryParse(options[1], out increment))
                                    {
                                        info.Geothermal.Increment = increment;
                                        return true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "generate":
                        float startMultiplier = 1;
                        float rowMultiplier = 1;
                        float powerMultiplier = 1;
                        string profile = planet.ToUpper();
                        foreach (var item in options)
                        {
                            if (item.Contains("="))
                            {
                                var parts = item.Split('=');
                                if (parts.Length == 2)
                                {
                                    float infomultiplier;
                                    switch (parts[0].ToLower())
                                    {
                                        case "startmultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                startMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "rowmultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                rowMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "powermultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                powerMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "profile":
                                            profile = parts[1].ToUpper().Trim();
                                            break;
                                    }
                                }
                            }
                        }
                        info.Geothermal = PlanetMapProfile.Get(profile).BuildGeothermalSetting(startMultiplier, rowMultiplier, powerMultiplier);
                        return true;
                }
            }
            return false;
        }

        public bool ProcessPlanetOreMap(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "generate":
                        int seed = MyUtils.GetRandomInt(10000000, int.MaxValue);
                        float deep = 1.0f;
                        string profile = planet.ToUpper();
                        string[] addOres = new string[0];
                        string[] removeOres = new string[0];
                        bool clearOresBeforeAdd = false;
                        string targetColor = null;
                        Vector2I? colorInfluence = null;
                        PlanetProfile.OreGroupType? groupType = null;
                        foreach (var item in options)
                        {
                            var parts = item.Split('=');
                            switch (parts[0].ToLower())
                            {
                                case "seed":
                                    if (parts.Length >= 2)
                                    {
                                        int infoseed;
                                        if (int.TryParse(parts[1], out infoseed))
                                        {
                                            seed = infoseed;
                                        }
                                    }
                                    break;
                                case "deep":
                                    if (parts.Length >= 2)
                                    {
                                        float infodeep;
                                        if (float.TryParse(parts[1], out infodeep))
                                        {
                                            deep = infodeep;
                                        }
                                    }
                                    break;
                                case "profile":
                                    if (parts.Length >= 2)
                                        profile = parts[1].ToUpper().Trim();
                                    break;
                                case "oregrouptype":
                                    if (parts.Length >= 2)
                                    {
                                        int oregrouptype;
                                        if (int.TryParse(parts[1], out oregrouptype))
                                        {
                                            if (oregrouptype >= 0 && oregrouptype <= 3)
                                            {
                                                groupType = (PlanetProfile.OreGroupType)oregrouptype;
                                            }
                                        }
                                    }
                                    break;
                                case "add":
                                    if (parts.Length >= 2)
                                        addOres = parts[1].ToUpper().Split(',');
                                    break;
                                case "remove":
                                    if (parts.Length >= 2)
                                        removeOres = parts[1].ToUpper().Split(',');
                                    break;
                                case "clear":
                                    clearOresBeforeAdd = true;
                                    break;
                                case "targetcolor":
                                    if (parts.Length >= 2)
                                    {
                                        try
                                        {
                                            string colorcode = parts[1];
                                            colorcode = colorcode.TrimStart('#');
                                            Color col;
                                            if (colorcode.Length == 6)
                                            {
                                                col = new Color(
                                                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                                                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                                                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber),
                                                    255
                                                );
                                                targetColor = parts[1];
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                                        }
                                    }
                                    break;
                                case "colorinfluence":
                                    if (parts.Length >= 2)
                                    {
                                        var influenceRange = parts[1].ToUpper().Split('|');
                                        if (influenceRange.Length >= 2)
                                        {
                                            int influenceFrom, influenceTo;
                                            if (int.TryParse(influenceRange[0], out influenceFrom) &&
                                                int.TryParse(influenceRange[1], out influenceTo))
                                            {
                                                if (influenceFrom <= influenceTo &&
                                                    influenceFrom >= 0 && influenceTo >= 0 &&
                                                    influenceFrom <= 255 && influenceTo <= 255)
                                                {
                                                    colorInfluence = new Vector2I(influenceFrom, influenceTo);
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        GeneratePlanetInfo(info.Id, seed, deep, profile, true, GenerateFlags.OreMap, addOres, removeOres, 
                            clearOresBeforeAdd, targetColor, colorInfluence, groupType);
                        return true;
                }
            }
            return false;
        }

        public bool SetPlanetConfigValue(string planet, string name, string value)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "respawnenabled":
                        bool respawnenabled;
                        if (bool.TryParse(value, out respawnenabled))
                        {
                            info.RespawnEnabled = respawnenabled;
                            return true;
                        }
                        break;
                    case "type":
                        int type;
                        if (int.TryParse(value, out type))
                        {
                            int[] validValues = new int[] { 0, 1, 2, 4 };
                            if (validValues.Contains(type))
                            {
                                info.Type = type;
                                return true;
                            }
                        }
                        break;
                    case "sizerange":
                        var sizerangeparts = value.Split(':');
                        if (sizerangeparts.Length == 2)
                        {
                            float sizerange_p1;
                            float sizerange_p2;
                            if (float.TryParse(sizerangeparts[0], out sizerange_p1) &&
                                float.TryParse(sizerangeparts[1], out sizerange_p2))
                            {
                                TradeStations.TradeFactionsAmount = new DocumentedVector2(sizerange_p1, sizerange_p2, PlanetSetting.SIZERANGE_INFO);
                                return true;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public VoxelMaterialSetting GetVoxelInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasVoxelInfo(id) && !VoxelUsingTecnologyForFirstTime(id))
            {
                var settings = VoxelMaterials.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                var profile = VoxelMaterialMapProfile.Get(id.ToUpper());
                if (profile != null && profile.Version > settings.Version)
                    settings = profile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                return GenerateVoxelInfo(id, true);
            }
            return null;
        }

        public VoxelMaterialSetting GenerateVoxelInfo(string id, bool force = false)
        {
            if (!HasVoxelInfo(id) || force)
            {
                var settings = VoxelMaterialMapProfile.Get(id.ToUpper()).BuildSettings(id);
                if (HasVoxelInfo(id))
                    VoxelMaterials.RemoveAll(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                VoxelMaterials.Add(settings);
                return settings;
            }
            return GetVoxelInfo(id, false);
        }

        public bool HasVoxelInfo(string id)
        {
            return VoxelMaterials.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool SetVoxelConfigValue(string voxel, string name, string value)
        {
            var info = GetVoxelInfo(voxel, false);
            if (info != null)
            {
                switch (name)
                {
                    case "minedoreratio":
                        float minedoreratio;
                        if (float.TryParse(value, out minedoreratio))
                        {
                            info.MinedOreRatio = minedoreratio;
                            return true;
                        }
                        break;
                    case "spawnsfrommeteorites":
                        bool spawnsfrommeteorites;
                        if (bool.TryParse(value, out spawnsfrommeteorites))
                        {
                            info.SpawnsFromMeteorites = spawnsfrommeteorites;
                            return true;
                        }
                        break;
                    case "spawnsinasteroids":
                        bool spawnsinasteroids;
                        if (bool.TryParse(value, out spawnsinasteroids))
                        {
                            info.SpawnsInAsteroids = spawnsinasteroids;
                            return true;
                        }
                        break;
                    case "asteroidspawnprobabilitymultiplier":
                        int asteroidspawnprobabilitymultiplier;
                        if (int.TryParse(value, out asteroidspawnprobabilitymultiplier))
                        {
                            info.AsteroidSpawnProbabilityMultiplier = asteroidspawnprobabilitymultiplier;
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        public bool SetConfigValue(string name, string value)
        {
            switch (name)
            {
                case "debug":
                    bool debug;
                    if (bool.TryParse(value, out debug))
                    {
                        Debug = debug;
                        return true;
                    }
                    break;
                case "rotenabled":
                    bool rotfoodenabled;
                    if (bool.TryParse(value, out rotfoodenabled))
                    {
                        RotEnabled = rotfoodenabled;
                        return true;
                    }
                    break;
                case "dinamicwoodgridenabled":
                    bool dinamicwoodgridenabled;
                    if (bool.TryParse(value, out dinamicwoodgridenabled))
                    {
                        DinamicWoodGridEnabled = dinamicwoodgridenabled;
                        return true;
                    }
                    break;
                case "dinamicstonegridenabled":
                    bool dinamicstonegridenabled;
                    if (bool.TryParse(value, out dinamicstonegridenabled))
                    {
                        DinamicStoneGridEnabled = dinamicstonegridenabled;
                        return true;
                    }
                    break;
                case "dinamicconcretegridenabled":
                    bool dinamicconcretegridenabled;
                    if (bool.TryParse(value, out dinamicconcretegridenabled))
                    {
                        DinamicConcreteGridEnabled = dinamicconcretegridenabled;
                        return true;
                    }
                    break;
                case "respawnspacepodenabled":
                    bool respawnspacepodenabled;
                    if (bool.TryParse(value, out respawnspacepodenabled))
                    {
                        RespawnSpacePodEnabled = respawnspacepodenabled;
                        return true;
                    }
                    break;
                case "disablewatermodfreeice":
                    bool disablewatermodfreeice;
                    if (bool.TryParse(value, out disablewatermodfreeice))
                    {
                        DisableWaterModFreeIce = disablewatermodfreeice;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.autogeneratestarsystemgps":
                    bool starsystemconfigurationautogeneratestarsystemgps;
                    if (bool.TryParse(value, out starsystemconfigurationautogeneratestarsystemgps))
                    {
                        StarSystemConfiguration.AutoGenerateStarSystemGps = starsystemconfigurationautogeneratestarsystemgps;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.addallinfotostarsystemgps":
                    bool starsystemconfigurationaddallinfotostarsystemgps;
                    if (bool.TryParse(value, out starsystemconfigurationaddallinfotostarsystemgps))
                    {
                        StarSystemConfiguration.AddAllInfoToStarSystemGps = starsystemconfigurationaddallinfotostarsystemgps;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.autogeneratetradestationsgps":
                    bool starsystemconfigurationautogeneratetradestationsgps;
                    if (bool.TryParse(value, out starsystemconfigurationautogeneratetradestationsgps))
                    {
                        StarSystemConfiguration.AutoGenerateTradeStationsGps = starsystemconfigurationautogeneratetradestationsgps;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.createdatapadinstartrover":
                    bool starsystemconfigurationcreatedatapadinstartrover;
                    if (bool.TryParse(value, out starsystemconfigurationcreatedatapadinstartrover))
                    {
                        StarSystemConfiguration.CreateDatapadInStartRover = starsystemconfigurationcreatedatapadinstartrover;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.createdatapadindropcontainers":
                    bool starsystemconfigurationcreatedatapadindropcontainers;
                    if (bool.TryParse(value, out starsystemconfigurationcreatedatapadindropcontainers))
                    {
                        StarSystemConfiguration.CreateDatapadInDropContainers = starsystemconfigurationcreatedatapadindropcontainers;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.datapadchanceindropcontainers":
                    float starsystemconfigurationdatapadchanceindropcontainers;
                    if (float.TryParse(value, out starsystemconfigurationdatapadchanceindropcontainers))
                    {
                        StarSystemConfiguration.DatapadChanceInDropContainers = starsystemconfigurationdatapadchanceindropcontainers;
                        return true;
                    }
                    break;
                case "dropcontainerdeployheight":
                    int dropcontainerdeployheight;
                    if (int.TryParse(value, out dropcontainerdeployheight))
                    {
                        DropContainerDeployHeight = Math.Min(Math.Max(dropcontainerdeployheight, 200), 2000);
                        return true;
                    }
                    break;
                case "planetdeployaltitude":
                    int planetdeployaltitude;
                    if (int.TryParse(value, out planetdeployaltitude))
                    {
                        PlanetDeployAltitude = Math.Min(Math.Max(planetdeployaltitude, 5), 2000);
                        return true;
                    }
                    break;
                case "moondeployaltitude":
                    int moondeployaltitude;
                    if (int.TryParse(value, out moondeployaltitude))
                    {
                        MoonDeployAltitude = Math.Min(Math.Max(moondeployaltitude, 5), 1500);
                        return true;
                    }
                    break;
                case "combat.nogrindfunctionalgrids":
                    bool combatsetting_nogrindfunctionalgrids;
                    if (bool.TryParse(value, out combatsetting_nogrindfunctionalgrids))
                    {
                        Combat.NoGrindFunctionalGrids = combatsetting_nogrindfunctionalgrids;
                        return true;
                    }
                    break;
                case "combat.nogridselfdamage":
                    bool combatsetting_nogridselfdamage;
                    if (bool.TryParse(value, out combatsetting_nogridselfdamage))
                    {
                        Combat.NoGridSelfDamage = combatsetting_nogridselfdamage;
                        return true;
                    }
                    break;
                case "combat.logallpvpdamage":
                    bool combatsetting_logallpvpdamage;
                    if (bool.TryParse(value, out combatsetting_logallpvpdamage))
                    {
                        Combat.LogAllPvPDamage = combatsetting_logallpvpdamage;
                        return true;
                    }
                    break;
                case "combat.forceenemytofactions":
                    bool combatsetting_forceenemytofactions;
                    if (bool.TryParse(value, out combatsetting_forceenemytofactions))
                    {
                        Combat.ForceEnemyToFactions = combatsetting_forceenemytofactions;
                        return true;
                    }
                    break;
                case "combat.targetenemyfactions":
                    Combat.TargetEnemyFactions = value;
                    return true;
                case "tradestations.comercialcycle":
                    long tradestations_comercialcycle;
                    if (long.TryParse(value, out tradestations_comercialcycle))
                    {
                        TradeStations.ComercialCycle = tradestations_comercialcycle;
                        return true;
                    }
                    break;
                case "tradestations.tradefactionsamount":
                    var tradestations_tradefactionsamountparts = value.Split(':');
                    if (tradestations_tradefactionsamountparts.Length == 2)
                    {
                        float tradestations_tradefactionsamount_p1;
                        float tradestations_tradefactionsamount_p2;
                        if (float.TryParse(tradestations_tradefactionsamountparts[0], out tradestations_tradefactionsamount_p1) &&
                            float.TryParse(tradestations_tradefactionsamountparts[1], out tradestations_tradefactionsamount_p2))
                        {
                            TradeStations.TradeFactionsAmount = new DocumentedVector2(tradestations_tradefactionsamount_p1, tradestations_tradefactionsamount_p2, TradeStationSetting.FACTIONRANGE_INFO);
                            return true;
                        }
                    }
                    break;
                case "meteorimpact.enabled":
                    bool meteorimpact_enabled;
                    if (bool.TryParse(value, out meteorimpact_enabled))
                    {
                        MeteorImpact.Enabled = meteorimpact_enabled;
                        return true;
                    }
                    break;
                case "meteorimpact.distancetospawn":
                    float meteorimpact_distancetospawn;
                    if (float.TryParse(value, out meteorimpact_distancetospawn))
                    {
                        MeteorImpact.DistanceToSpawn = meteorimpact_distancetospawn;
                        return true;
                    }
                    break;
                case "meteorimpact.stonelifetime":
                    long meteorimpact_stonelifetime;
                    if (long.TryParse(value, out meteorimpact_stonelifetime))
                    {
                        MeteorImpact.StoneLifeTime = meteorimpact_stonelifetime;
                        return true;
                    }
                    break;
            }
            return false;
        }

    }

}
