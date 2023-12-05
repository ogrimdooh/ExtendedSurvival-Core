using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class CombatSetting 
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.CombatSetting";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.NoGrindFunctionalGrids"),
                Title = "NoGrindFunctionalGrids",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_COMBATSETTING_NOGRINDFUNCTIONALGRIDS_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Combat.NoGrindFunctionalGrids true",
                ValueType = HelpController.ConfigurationValueType.Bool
            }
        };

        [XmlElement]
        public bool NoGrindFunctionalGrids { get; set; } = false;

    }

}
