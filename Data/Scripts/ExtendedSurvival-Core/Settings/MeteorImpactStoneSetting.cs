using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorImpactStoneSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.MeteorImpact.Stones";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.GroupId"),
                Title = "GroupId",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_GROUPID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ModifierId"),
                Title = "ModifierId",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_MODIFIERID_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.ChanceToSpawn"),
                Title = "ChanceToSpawn",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_CHANCETOSPAWN_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = false,
                NeedRestart = false
            }
        };

        [XmlElement]
        public string GroupId { get; set; }

        [XmlElement]
        public string ModifierId { get; set; }

        [XmlElement]
        public float ChanceToSpawn { get; set; }

    }

}
