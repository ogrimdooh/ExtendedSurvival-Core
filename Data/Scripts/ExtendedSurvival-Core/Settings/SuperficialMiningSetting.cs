using ProtoBuf;
using System;
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
                NeedRestart = true,
                CommandSample = "/planet.superficialmining $ set Enabled true" + Environment.NewLine + "/planet.superficialmining Pertam set Enabled false",
                ValueType = HelpController.ConfigurationValueType.Bool
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, SuperficialMiningDropSetting.HELP_TOPIC_SUBTYPE),
                Title = "Drops",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                Entries = SuperficialMiningDropSetting.HELP_INFO,
                CommandSample = "/planet.superficialmining $ add ConsumableItem|Champignons:4|8:4:false:Soil|Stone" + Environment.NewLine +
                                "/planet.superficialmining Pertam remove ConsumableItem|Champignons" + Environment.NewLine +
                                "/planet.superficialmining Pertam clear"
            }
        };

        [XmlElement]
        public bool Enabled { get; set; } = false;

        [XmlArray("Drops"), XmlArrayItem("Drop", typeof(SuperficialMiningDropSetting))]
        public List<SuperficialMiningDropSetting> Drops { get; set; } = new List<SuperficialMiningDropSetting>();

    }

}
