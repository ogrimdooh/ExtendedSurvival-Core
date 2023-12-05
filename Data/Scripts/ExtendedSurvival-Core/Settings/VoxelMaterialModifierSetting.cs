using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMaterialModifierSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.MaterialModifiers";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Id"),
                Title = "Id",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_ID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.String
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Version"),
                Title = "Version",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_VERSION_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Integer
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.UsingTechnology"),
                Title = "UsingTechnology",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_USINGTECHNOLOGY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NoChangeChance"),
                Title = "NoChangeChance",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_NOCHANGECHANCE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, VoxelMapModifierOptionSetting.HELP_TOPIC_SUBTYPE),
                Title = "Options",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_MATERIALMODIFIERS_OPTIONS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false,
                Entries = VoxelMapModifierOptionSetting.HELP_INFO
            }
        };

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public int Version { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public float NoChangeChance { get; set; }

        [XmlArray("Options"), XmlArrayItem("Option", typeof(VoxelMapModifierOptionSetting))]
        public List<VoxelMapModifierOptionSetting> Options { get; set; } = new List<VoxelMapModifierOptionSetting>();

        public MyVoxelMapModifierOption[] BuildOptions()
        {
            var lista = new List<MyVoxelMapModifierOption>();
            if (NoChangeChance < 0)
                NoChangeChance = 0;
            if (NoChangeChance > 0)
            {
                lista.Add(new MyVoxelMapModifierOption()
                {
                    Chance = NoChangeChance,
                    Changes = Options.Where(x => x.Default).Select(x => new MyVoxelMapModifierChange() { 
                        From = x.IdFrom,
                        To = x.IdTo
                    }).ToArray()
                });
            }
            if (Options.Any(x => !x.Default))
            {
                var changeToUse = 1 - NoChangeChance;
                var changeOfItem = changeToUse / Options.Count(x => !x.Default);
                foreach (var item in Options.Where(x => !x.Default))
                {
                    var listaChanges = Options.Where(x => x.Default).Select(x => new MyVoxelMapModifierChange()
                    {
                        From = x.IdFrom,
                        To = x.IdTo
                    }).ToList();
                    listaChanges.Add(new MyVoxelMapModifierChange() { 
                        From = PlanetMapProfile.Iron_01,
                        To = item.IdTo
                    });
                    listaChanges.Add(new MyVoxelMapModifierChange()
                    {
                        From = PlanetMapProfile.Iron_02,
                        To = item.IdTo
                    });
                    lista.Add(new MyVoxelMapModifierOption()
                    {
                        Chance = changeOfItem,
                        Changes = listaChanges.ToArray()
                    });
                }
            }
            return lista.ToArray();
        }

    }

}
