using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SuperficialMiningDropSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.SuperficialMining.Drops";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ItemId"),
                Title = "ItemId",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_ITEMID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Ammount"),
                Title = "Ammount",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_AMMOUNT_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Chance"),
                Title = "Chance",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_CHANCE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.AlowFrac"),
                Title = "AlowFrac",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_ALOWFRAC_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ValidSubType"),
                Title = "ValidSubType",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_VALIDSUBTYPE_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            }
        };

        public const string AMMOUNT_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public SerializableDefinitionId ItemId { get; set; }

        [XmlElement]
        public DocumentedVector2 Ammount { get; set; } = new DocumentedVector2(0, 0, AMMOUNT_RANGE_INFO);

        [XmlElement]
        public float Chance { get; set; }

        [XmlElement]
        public bool AlowFrac { get; set; }

        [XmlArray("ValidSubTypes"), XmlArrayItem("Type", typeof(SuperficialMiningDropValidSubTypeSetting))]
        public List<SuperficialMiningDropValidSubTypeSetting> ValidSubType { get; set; } = new List<SuperficialMiningDropValidSubTypeSetting>();

    }

}
