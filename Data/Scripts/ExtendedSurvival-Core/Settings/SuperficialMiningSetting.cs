using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SuperficialMiningSetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.SuperficialMining";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Enabled"),
                Title = "Enabled",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_ENABLED_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, SuperficialMiningDropSetting.HELP_TOPIC_SUBTYPE),
                Title = "Drops",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                Entries = SuperficialMiningDropSetting.HELP_INFO
            }
        };

        [XmlElement]
        public bool Enabled { get; set; } = false;

        [XmlArray("Drops"), XmlArrayItem("Drop", typeof(SuperficialMiningDropSetting))]
        public List<SuperficialMiningDropSetting> Drops { get; set; } = new List<SuperficialMiningDropSetting>();

    }

}
