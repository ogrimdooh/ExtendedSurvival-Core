using ProtoBuf;
using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class GravitySetting
    {

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Core.Settings.Planets.Gravity";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.SurfaceGravity"),
                Title = "SurfaceGravity",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_SURFACEGRAVITY_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.gravity $ set SurfaceGravity 0.8" + Environment.NewLine + "/planet.gravity Pertam set SurfaceGravity 1.25",
                ValueType = HelpController.ConfigurationValueType.Decimal
            },
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.GravityFalloffPower"),
                Title = "GravityFalloffPower",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_GRAVITYFALLOFFPOWER_DESCRIPTION),
                DefaultValue = "",
                CanUseSettingsCommand = true,
                NeedRestart = true,
                CommandSample = "/planet.gravity $ set GravityFalloffPower 1.5" + Environment.NewLine + "/planet.gravity Pertam set GravityFalloffPower 2.0",
                ValueType = HelpController.ConfigurationValueType.Decimal
            }
        };

        [XmlElement]
        public float SurfaceGravity { get; set; } = 1;

        [XmlElement]
        public float GravityFalloffPower { get; set; } = 1;

    }

}
