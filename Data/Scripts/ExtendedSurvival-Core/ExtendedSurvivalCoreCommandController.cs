using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalCoreCommandController : BaseSessionComponent
    {

        public class ValidCommand
        {

            public string Command { get; set; }
            public int MinOptions { get; set; }
            public bool NotFixedOptions { get; set; }
            public HelpController.CommandEntryHelpInfo HelpInfo { get; set; }

            public ValidCommand(string command, int minOptions, bool notFixedOptions)
            {
                Command = command;
                MinOptions = minOptions;
                NotFixedOptions = notFixedOptions;
            }

        }

        public static ExtendedSurvivalCoreCommandController Static { get; private set; }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
            }

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS, ServerCommandsMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS, ClientCommandsMsgHandler);

            }

        }

        public override void LoadData()
        {
            base.LoadData();
            VALID_COMMANDS[SETTINGS_COMMAND] = new ValidCommand(SETTINGS_COMMAND, 3, false)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND),
                    Title = "Settings",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_SETTINGS_DESCRIPTION),
                    Syntax = "/settings <CONFIG> <VALUE>",
                    CommandSample = "/settings Debug true"
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_VOXEL] = new ValidCommand(SETTINGS_COMMAND_VOXEL, 4, false)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_VOXEL),
                    Title = "Voxel.Settings",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_VOXELSETTINGS_DESCRIPTION),
                    Syntax = "/voxel.settings <VOXEL_TYPE> <CONFIG> <VALUE>",
                    CommandSample = "/voxel.settings Iron_01 MinedOreRatio 10",
                    ShowApplyLevel = true,
                    NeedRestart = true,
                    OnAfterBuildPage = (sb, p) =>
                    {
                        var voxels = ExtendedSurvivalSettings.Instance?.VoxelMaterials.Select(x => x.Id).ToArray() ?? new string[] { };
                        HelpController.FormatHelpLine(sb, $"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDVOXELS)}: ", voxels);
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_PLANET] = new ValidCommand(SETTINGS_COMMAND_PLANET, 4, false)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_PLANET),
                    Title = "Planet.Settings",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_PLANETSETTINGS_DESCRIPTION),
                    Syntax = "/planet.settings <PLANET: Use '$' as nearest Planet> <CONFIG> <VALUE>",
                    CommandSample = "/planet.settings Pertam respawnenabled true" + Environment.NewLine + 
                        "/planet.settings $ type 1",
                    ShowApplyLevel = true,
                    NeedRestart = true,
                    OnAfterBuildPage = (sb, p) =>
                    {
                        var planets = ExtendedSurvivalSettings.Instance?.Planets.Select(x => x.Id).ToArray() ?? new string[] { };
                        HelpController.FormatHelpLine(sb, $"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDPLANETS)}: ", planets);
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_OREMAP] = new ValidCommand(SETTINGS_COMMAND_OREMAP, 3, true)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_OREMAP),
                    Title = "Planet.OreMap",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_SETTINGS_DESCRIPTION),
                    Syntax = "/planet.oremap <PLANET: Use '$' as nearest Planet> generate <OPTIONS>",
                    CommandSample = "/planet.oremap $ generate seed=5514752" + Environment.NewLine +
                        "/planet.oremap Europa generate profile=Oi" + Environment.NewLine +
                        "/planet.oremap EarthLike clear add=Iron,Mercury,Sulfur deep=2" + Environment.NewLine +
                        "/planet.oremap Pertam generate targetColor=#000000 colorInfluence=50|150",
                    ShowApplyLevel = true,
                    NeedRestart = true,
                    ExtraPage = new HelpController.CommandExtraPage[] 
                    { 
                        new HelpController.CommandExtraPage()
                        {
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_PLANETSETTINGS_DESCRIPTION_P2)
                        },
                        new HelpController.CommandExtraPage()
                        {
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_PLANETSETTINGS_DESCRIPTION_P3)
                        }
                    },
                    OnAfterBuildPage = (sb, p) =>
                    {
                        if (p == 0)
                        {
                            var planets = ExtendedSurvivalSettings.Instance?.Planets.Select(x => x.Id).ToArray() ?? new string[] { };
                            HelpController.FormatHelpLine(sb, $"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDPLANETS)}: ", planets);
                        }
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_GEOTHERMAL] = new ValidCommand(SETTINGS_COMMAND_GEOTHERMAL, 3, true)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_GEOTHERMAL),
                    Title = "Planet.Geothermal",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_GEOTHERMAL_DESCRIPTION),
                    Syntax = "/planet.geothermal <PLANET: Use '$' as nearest Planet> <OPERATION> <OPTIONS>",
                    OnAfterBuildPage = (sb, p) =>
                    {
                        if (p == 0)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDOPERATIONS)}:");
                            sb.AppendLine($"- Copy : {LanguageProvider.GetEntry(LanguageEntries.TERMS_INFO_COPY_OPERATION)}.");
                            sb.AppendLine($"- Set: {LanguageProvider.GetEntry(LanguageEntries.TERMS_INFO_SET_OPERATION)}.");
                            sb.AppendLine($"- Generate: {LanguageProvider.GetEntry(LanguageEntries.TERMS_INFO_GENERATE_OPERATION)}.");
                        }
                    },
                    SubCommands = new HelpController.CommandEntryHelpInfo[] 
                    { 
                        new HelpController.CommandEntryHelpInfo()
                        {
                            EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_GEOTHERMAL + "." + SETTINGS_SUBCOMMAND_COPY),
                            Title = "Planet.Geothermal - Copy",
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_GEOTHERMAL_COPY_DESCRIPTION),
                            Syntax = "/planet.geothermal <PLANET: Use '$' as nearest Planet> copy <TARGET>",
                            CommandSample = "/planet.geothermal $ copy Moon" + Environment.NewLine +
                                "/planet.geothermal Triton copy Europa",
                            ShowApplyLevel = true,
                            NeedRestart = false
                        },
                        new HelpController.CommandEntryHelpInfo()
                        {
                            EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_GEOTHERMAL + "." + SETTINGS_SUBCOMMAND_SET),
                            Title = "Planet.Geothermal - Set",
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_GEOTHERMAL_SET_DESCRIPTION),
                            Syntax = "/planet.geothermal <PLANET: Use '$' as nearest Planet> set <CONFIG> <VALUE>",
                            CommandSample = "/planet.geothermal $ set power 200.25" + Environment.NewLine +
                                "/planet.geothermal Triton set increment 125.5",
                            ShowApplyLevel = true,
                            NeedRestart = false
                        },
                        new HelpController.CommandEntryHelpInfo()
                        {
                            EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_GEOTHERMAL + "." + SETTINGS_SUBCOMMAND_GENERATE),
                            Title = "Planet.Geothermal - Generate",
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_GEOTHERMAL_GENERATE_DESCRIPTION),
                            Syntax = "/planet.geothermal <PLANET: Use '$' as nearest Planet> generate <OPTIONS>",
                            CommandSample = "/planet.geothermal Pertam generate startmultiplier=2 profile=Moon" + Environment.NewLine +
                                "/planet.geothermal Triton generate powermultiplier=0.5" + Environment.NewLine +
                                "/planet.geothermal Europa generate profile=Oi",
                            ShowApplyLevel = true,
                            NeedRestart = false,
                            OnAfterBuildPage = (sb, p) =>
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDOPTIONS)}:");
                                sb.AppendLine("- startmultiplier=<NUMBER OF MULTIPLIER START DEPHT>");
                                sb.AppendLine("- rowmultiplier=<NUMBER OF MULTIPLIER ROW DEPHT>");
                                sb.AppendLine("- powermultiplier=<NUMBER OF MULTIPLIER POWER>");
                                sb.AppendLine("- profile=<PLANET TO USE AS SOURCE>");
                                sb.AppendLine("");
                                sb.AppendLine(LanguageProvider.GetEntry(LanguageEntries.TERMS_OPTNOTMANDATORY));
                            }
                        }
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_ATMOSPHERE] = new ValidCommand(SETTINGS_COMMAND_ATMOSPHERE, 3, true)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_ATMOSPHERE),
                    Title = "Planet.Atmosphere",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_ATMOSPHERE_DESCRIPTION),
                    Syntax = "/planet.atmosphere <PLANET: Use '$' as nearest Planet> <OPERATION> <OPTIONS>",
                    OnAfterBuildPage = (sb, p) =>
                    {
                        if (p == 0)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDOPERATIONS)}:");
                            sb.AppendLine($"- Copy : {LanguageProvider.GetEntry(LanguageEntries.TERMS_INFO_COPY_OPERATION)}.");
                            sb.AppendLine($"- Set: {LanguageProvider.GetEntry(LanguageEntries.TERMS_INFO_SET_OPERATION)}.");
                        }
                    },
                    SubCommands = new HelpController.CommandEntryHelpInfo[]
                    {
                        new HelpController.CommandEntryHelpInfo()
                        {
                            EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_ATMOSPHERE + "." + SETTINGS_SUBCOMMAND_COPY),
                            Title = "Planet.Atmosphere - Copy",
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_ATMOSPHERE_COPY_DESCRIPTION),
                            Syntax = "/planet.atmosphere <PLANET: Use '$' as nearest Planet> copy <TARGET>",
                            CommandSample = "/planet.atmosphere $ copy Moon" + Environment.NewLine +
                                "/planet.atmosphere Triton copy Europa",
                            ShowApplyLevel = true,
                            NeedRestart = true
                        },
                        new HelpController.CommandEntryHelpInfo()
                        {
                            EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND_ATMOSPHERE + "." + SETTINGS_SUBCOMMAND_SET),
                            Title = "Planet.Atmosphere - Set",
                            Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_ATMOSPHERE_SET_DESCRIPTION),
                            Syntax = "/planet.atmosphere <PLANET: Use '$' as nearest Planet> set <CONFIG> <VALUE>",
                            CommandSample = "/planet.atmosphere $ set oxygendensity 0.5" + Environment.NewLine +
                                "/planet.atmosphere Triton set maxwindspeed 150",
                            ShowApplyLevel = true,
                            NeedRestart = true
                        }
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_GRAVITY] = new ValidCommand(SETTINGS_COMMAND_GRAVITY, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_WATER] = new ValidCommand(SETTINGS_COMMAND_WATER, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_ANIMALS] = new ValidCommand(SETTINGS_COMMAND_ANIMALS, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_METEORIMPACT] = new ValidCommand(SETTINGS_COMMAND_METEORIMPACT, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_SUPERFICIALMINING] = new ValidCommand(SETTINGS_COMMAND_SUPERFICIALMINING, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_STARSYSTEM] = new ValidCommand(SETTINGS_COMMAND_STARSYSTEM, 1, true);
            VALID_COMMANDS[SETTINGS_COMMAND_METEORWAVE] = new ValidCommand(SETTINGS_COMMAND_METEORWAVE, 0, true);
            VALID_COMMANDS[SETTINGS_COMMAND_GRIDS] = new ValidCommand(SETTINGS_COMMAND_GRIDS, 1, true);
            VALID_COMMANDS[SETTINGS_COMMAND_SESSION] = new ValidCommand(SETTINGS_COMMAND_SESSION, 2, true);
        }

        protected override void UnloadData()
        {
            try
            {
                if (!IsDedicated)
                {
                    MyAPIGateway.Utilities.MessageEntered -= OnMessageEntered;
                }
                if (IsServer)
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS, ServerCommandsMsgHandler);                    
                }
                else
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS, ClientCommandsMsgHandler);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            base.UnloadData();
        }

        private const string SETTINGS_COMMAND = "settings";
        private const string SETTINGS_COMMAND_VOXEL = "voxel.settings";
        private const string SETTINGS_COMMAND_PLANET = "planet.settings";
        private const string SETTINGS_COMMAND_OREMAP = "planet.oremap";
        private const string SETTINGS_COMMAND_GEOTHERMAL = "planet.geothermal";
        private const string SETTINGS_COMMAND_ATMOSPHERE = "planet.atmosphere";
        private const string SETTINGS_COMMAND_GRAVITY = "planet.gravity";
        private const string SETTINGS_COMMAND_WATER = "planet.water";
        private const string SETTINGS_COMMAND_ANIMALS = "planet.animals";
        private const string SETTINGS_COMMAND_METEORIMPACT = "planet.meteorimpact";
        private const string SETTINGS_COMMAND_SUPERFICIALMINING = "planet.superficialmining";
        private const string SETTINGS_COMMAND_STARSYSTEM = "starsystem";
        private const string SETTINGS_COMMAND_METEORWAVE = "meteorwave";
        private const string SETTINGS_COMMAND_GRIDS = "grids";

        private const string SETTINGS_COMMAND_SESSION = "sessionsettings";

        private const string SETTINGS_COMMAND_GRIDS_RENAMEALL = "renameall";

        private const string SETTINGS_COMMAND_STARSYSTEM_CLEAR = "clear";
        private const string SETTINGS_COMMAND_STARSYSTEM_CREATE = "create";
        private const string SETTINGS_COMMAND_STARSYSTEM_COMPLETE = "complete";
        private const string SETTINGS_COMMAND_STARSYSTEM_DELETENPCFACTIONS = "deletenpcfactions";
        private const string SETTINGS_COMMAND_STARSYSTEM_CLEANMETADA = "cleanmetada";
        private const string SETTINGS_COMMAND_STARSYSTEM_CLEANSAFEZONES = "cleansafezones";
        private const string SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY = "reseteconomy";
        private const string SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS = "recreatestation";
        private const string SETTINGS_COMMAND_STARSYSTEM_RECREATEFACTIONS = "recreatefactions";
        private const string SETTINGS_COMMAND_STARSYSTEM_RECREATEASTEROIDS = "recreateasteroids";
        private const string SETTINGS_COMMAND_STARSYSTEM_RESETASTEROIDS = "reseteasteroids";
        private const string SETTINGS_COMMAND_STARSYSTEM_GETALLECONOMYVALUES = "getalleconomyvalues";

        private const string SETTINGS_COMMAND_STARSYSTEM_PVEZONE = "pvezone";
        private const string SETTINGS_COMMAND_STARSYSTEM_GPS = "gps";
        private const string SETTINGS_COMMAND_STARSYSTEM_REQUESTGPS = "requestgps";

        private const string SETTINGS_SUBCOMMAND_GET = "get";
        private const string SETTINGS_SUBCOMMAND_SET = "set";
        private const string SETTINGS_SUBCOMMAND_COPY = "copy";
        private const string SETTINGS_SUBCOMMAND_GENERATE = "generate";
        private const string SETTINGS_SUBCOMMAND_CLEAR = "clear";
        private const string SETTINGS_SUBCOMMAND_REMOVE = "remove";

        private IMyHudNotification hudMsg;

        public const string BASE_TOPIC_TYPE = "ExtendedSurvival.Core.Command";
        public ConcurrentDictionary<string, ValidCommand> VALID_COMMANDS = new ConcurrentDictionary<string, ValidCommand>();

        private void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            sendToOthers = true;
            if (!messageText.StartsWith("/")) return;
            var words = messageText.Trim().ToLower().Replace("/", "").Split(' ');
            if (words.Length > 0)
            {
                if (VALID_COMMANDS.ContainsKey(words[0]))
                {
                    if ((!VALID_COMMANDS[words[0]].NotFixedOptions && words.Length == VALID_COMMANDS[words[0]].MinOptions) ||
                        (VALID_COMMANDS[words[0]].NotFixedOptions && words.Length >= VALID_COMMANDS[words[0]].MinOptions))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        if (IsServer)
                        {
                            if (MyAPIGateway.Session.IsUserAdmin(MyAPIGateway.Multiplayer.MyId))
                            {
                                HandlerMsgCommand(MyAPIGateway.Multiplayer.MyId, cmd);
                            }
                        }
                        else
                        {
                            string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageToServer(
                                ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS,
                                Encoding.Unicode.GetBytes(message)
                            );
                        }
                    }
                }
            }
        }

        private void HandlerMsgCommand(ulong steamId, Command mCommandData)
        {
            if (MyAPIGateway.Session.IsUserAdmin(steamId))
            {
                if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                {
                    if ((!VALID_COMMANDS[mCommandData.content[0]].NotFixedOptions && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].MinOptions) ||
                        (VALID_COMMANDS[mCommandData.content[0]].NotFixedOptions && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].MinOptions))
                    {
                        long planetId = 0;
                        switch (mCommandData.content[0])
                        {
                            case SETTINGS_COMMAND:
                                if (ExtendedSurvivalSettings.Instance.SetConfigValue(mCommandData.content[1], mCommandData.content[2]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Config {mCommandData.content[1]} set to {mCommandData.content[2]}.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_PLANET:
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.SetPlanetConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_PLANET} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_VOXEL:
                                if (ExtendedSurvivalSettings.Instance.SetVoxelConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Voxel {mCommandData.content[1]} set config {mCommandData.content[2]} to {mCommandData.content[3]}.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_OREMAP:
                                var options = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    options.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetOreMap(mCommandData.content[1], mCommandData.content[2], options.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_OREMAP} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_GEOTHERMAL:
                                var optionsGeo = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsGeo.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetThermalInfo(mCommandData.content[1], mCommandData.content[2], optionsGeo.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_GEOTHERMAL} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_ATMOSPHERE:
                                var optionsAtm = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsAtm.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetAtmosphereInfo(mCommandData.content[1], mCommandData.content[2], optionsAtm.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_ATMOSPHERE} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_GRAVITY:
                                var optionsGvt = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsGvt.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetGravityInfo(mCommandData.content[1], mCommandData.content[2], optionsGvt.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_GRAVITY} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_WATER:
                                var optionsWt = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsWt.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetWaterInfo(mCommandData.content[1], mCommandData.content[2], optionsWt.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_WATER} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_ANIMALS:
                                var optionsAnm = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsAnm.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetAnimalsInfo(mCommandData.content[1], mCommandData.content[2], optionsAnm.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_ANIMALS} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_METEORIMPACT:
                                var optionsMip = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsMip.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetMeteorImpactInfo(mCommandData.content[1], mCommandData.content[2], optionsMip.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_METEORIMPACT} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_SUPERFICIALMINING:
                                var optionsSmn = new List<string>();
                                for (int i = 3; i < mCommandData.content.Length; i++)
                                {
                                    optionsSmn.Add(mCommandData.content[i]);
                                }
                                if (mCommandData.content[1] == "$")
                                {
                                    mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                }
                                if (ExtendedSurvivalSettings.Instance.ProcessPlanetSuperficialMiningInfo(mCommandData.content[1], mCommandData.content[2], optionsSmn.ToArray()))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_SUPERFICIALMINING} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_GRIDS:
                                switch (mCommandData.content[1])
                                {
                                    case SETTINGS_COMMAND_GRIDS_RENAMEALL:
                                        if (ExtendedSurvivalEntityManager.Instance.RenameAllPlayerGrids())
                                        {
                                            SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_GRIDS} {SETTINGS_COMMAND_GRIDS_RENAMEALL} executed.", MyFontEnum.White);
                                        }
                                        break;
                                }
                                break;
                            case SETTINGS_COMMAND_STARSYSTEM:
                                var optionsStarSystem = new List<string[]>();
                                for (int i = 2; i < mCommandData.content.Length; i++)
                                {
                                    optionsStarSystem.Add(mCommandData.content[i].Split('='));
                                }
                                switch (mCommandData.content[1])
                                {
                                    case SETTINGS_COMMAND_STARSYSTEM_GETALLECONOMYVALUES:
                                        var data = SpaceStationController.GetEconomyValues();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_GETALLECONOMYVALUES} executed.", MyFontEnum.White, extraInfo: data);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_RESETASTEROIDS:
                                        StarSystemController.RecreateAsteroids(false);
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RESETASTEROIDS} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_RECREATEASTEROIDS:
                                        StarSystemController.RecreateAsteroids();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RECREATEASTEROIDS} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_RECREATEFACTIONS:
                                        StarSystemController.RecreateFactions();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RECREATEFACTIONS} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS:
                                        StarSystemController.RecreateStations();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_DELETENPCFACTIONS:
                                        StarSystemController.DeleteNpcFactions();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_DELETENPCFACTIONS} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_COMPLETE:
                                        string targetprofile = null;
                                        if (optionsStarSystem.Any(x => x.Length == 2 && x[0].ToLower() == "profile"))
                                        {
                                            targetprofile = optionsStarSystem.FirstOrDefault(x => x.Length == 2 && x[0].ToLower() == "profile")[1];
                                        }
                                        StarSystemController.CompleteStarSystem(targetprofile);
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_COMPLETE} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY:
                                        StarSystemController.DoResetAllFactionBalance();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_CLEANMETADA:
                                        StarSystemController.ClearStarSystemMetaData();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CLEANMETADA} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_CLEANSAFEZONES:
                                        StarSystemController.ClearSafeZones();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CLEANSAFEZONES} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_CLEAR:
                                        StarSystemController.ClearStarSystem();
                                        SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CLEAR} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_REQUESTGPS:
                                        if (StarSystemController.CheckGpsToAllPlayers(true))
                                        {
                                            SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_REQUESTGPS} executed.", MyFontEnum.White);
                                        }
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_GPS:
                                        long playerId = 0;
                                        if (mCommandData.content[2] == "$")
                                        {
                                            playerId = MyAPIGateway.Players.TryGetIdentityId(steamId);
                                        }
                                        else
                                        {
                                            var players = new List<IMyPlayer>();
                                            MyAPIGateway.Players.GetPlayers(players, x => x.DisplayName == mCommandData.content[2] || x.SteamUserId.ToString() == mCommandData.content[2]);
                                            if (players.Any())
                                                playerId = players[0].IdentityId;
                                        }
                                        if (playerId != 0)
                                        {
                                            if (StarSystemController.CreateGpsToPlayer(playerId, true))
                                            {
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_GPS} executed.", MyFontEnum.White);
                                            }
                                        }
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_PVEZONE:
                                        var optionsPve = new List<string>();
                                        for (int i = 3; i < mCommandData.content.Length; i++)
                                        {
                                            optionsPve.Add(mCommandData.content[i]);
                                        }
                                        if (mCommandData.content[2] == "$")
                                        {
                                            mCommandData.content[2] = TryToGetNearPlanet(steamId, mCommandData.content[2], out planetId);
                                        }
                                        if (StarSystemController.DoChangePveZone(planetId, optionsPve))
                                            SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_PVEZONE} executed.", MyFontEnum.White);
                                        break;
                                    case SETTINGS_COMMAND_STARSYSTEM_CREATE:
                                        string profile = StarSystemMapProfile.DEFAULT_PROFILE;
                                        if (optionsStarSystem.Any(x => x.Length == 2 && x[0].ToLower() == "profile"))
                                        {
                                            profile = optionsStarSystem.FirstOrDefault(x => x.Length == 2 && x[0].ToLower() == "profile")[1];
                                        }
                                        var profileInfo = ExtendedSurvivalSettings.Instance.GetStarSystemInfo(profile, false);
                                        if (profileInfo != null)
                                        {
                                            var flags = StarSystemController.GenerationFlags.None;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "nostar"))
                                                flags |= StarSystemController.GenerationFlags.NoStar;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "withstar"))
                                                flags |= StarSystemController.GenerationFlags.WithStar;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "nobelt"))
                                                flags |= StarSystemController.GenerationFlags.NoBelt;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "noring"))
                                                flags |= StarSystemController.GenerationFlags.NoRing;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "noasteroids"))
                                                flags |= StarSystemController.GenerationFlags.NoAsteroids;
                                            if (optionsStarSystem.Any(x => x.Length == 1 && x[0].ToLower() == "withasteroids"))
                                                flags |= StarSystemController.GenerationFlags.WithAsteroids;
                                            if (StarSystemController.ComputeNewStarSystem(profileInfo, flags))
                                            {
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CREATE} executed.", MyFontEnum.White);
                                            }
                                        }
                                        break;
                                }
                                break;
                            case SETTINGS_COMMAND_METEORWAVE:
                                if (ExtendedSurvivalCoreSession.IsLocalExecution())
                                {
                                    /* only local execution command - can cause game crash */
                                    var playerId = MyAPIGateway.Players.TryGetIdentityId(steamId);
                                    IMyPlayer player = null;
                                    if (ExtendedSurvivalEntityManager.Instance.Players.TryGetValue(playerId, out player))
                                    {
                                        var playerPos = player.Character?.PositionComp?.GetPosition();
                                        if (playerPos != null)
                                        {
                                            MeteorWaveController.CallMeteorWave(new BoundingSphereD(playerPos.Value, 50));
                                        }
                                    }
                                }
                                break;
                            case SETTINGS_COMMAND_SESSION:
                                switch (mCommandData.content[1])
                                {
                                    case SETTINGS_SUBCOMMAND_GET:
                                        string v;
                                        if (SessionSettingsController.TryGetValue(mCommandData.content[2], out v))
                                        {
                                            SendMessage(steamId, $"[ExtendedSurvivalCore] SessionSettings: {mCommandData.content[2]} is {v}.", MyFontEnum.White);
                                        }
                                        break;
                                    case SETTINGS_SUBCOMMAND_SET:
                                        if (SessionSettingsController.TrySetValue(mCommandData.content[2], mCommandData.content[3]))
                                        {
                                            SendMessage(steamId, $"[ExtendedSurvivalCore] SessionSettings: {mCommandData.content[2]} change to {mCommandData.content[3]}.", MyFontEnum.White);
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void ClientCommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS)
                    return;

                if (IsClient)
                {
                    var message = Encoding.Unicode.GetString(data);
                    var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);

                    int timeToLive = 0;
                    if (mCommandData.content.Length == 4 &&
                        int.TryParse(mCommandData.content[2], out timeToLive))
                    {
                        ShowMessage(mCommandData.content[0], mCommandData.content[1], timeToLive, mCommandData.content[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ServerCommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS)
                    return;

                if (IsServer)
                {
                    var message = Encoding.Unicode.GetString(data);
                    var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);

                    HandlerMsgCommand(steamId, mCommandData);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private string TryToGetNearPlanet(ulong steamId, string nullReturn, out long planetId)
        {
            planetId = 0;
            var playerId = MyAPIGateway.Players.TryGetIdentityId(steamId);
            IMyPlayer player = null;
            if (ExtendedSurvivalEntityManager.Instance.Players.TryGetValue(playerId, out player))
            {
                var playerPos = player.Character?.PositionComp?.GetPosition();
                if (playerPos != null)
                {
                    var planet = ExtendedSurvivalEntityManager.GetPlanetAtRange(playerPos.Value);
                    if (planet != null)
                    {
                        planetId = planet.Entity.EntityId;
                        return planet.SubtypeName;
                    }
                }
            }
            return nullReturn;
        }

        public void SendMessage(ulong target, string text, string font = MyFontEnum.Red, int timeToLive = 5000, string extraInfo = null)
        {
            if (IsDedicated || (IsServer && MyAPIGateway.Multiplayer.MyId != target))
            {
                string[] values = new string[]
                {
                    text,
                    font,
                    timeToLive.ToString(),
                    extraInfo
                };
                Command cmd = new Command(IsDedicated ? 0 : MyAPIGateway.Multiplayer.MyId, values);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageTo(
                    ExtendedSurvivalCoreSession.NETWORK_ID_COMMANDS,
                    Encoding.Unicode.GetBytes(message),
                    target
                );
            }
            else
            {
                ShowMessage(text, font, timeToLive, extraInfo);
            }
        }

        public void ShowMessage(string text, string font = MyFontEnum.Red, int timeToLive = 5000, string extraInfo = null)
        {
            if (hudMsg == null)
                hudMsg = MyAPIGateway.Utilities.CreateNotification(string.Empty);

            hudMsg.Hide();
            hudMsg.Font = font;
            hudMsg.AliveTime = timeToLive;
            hudMsg.Text = text;
            hudMsg.Show();
            if (!string.IsNullOrWhiteSpace(extraInfo))
                VRage.Utils.MyClipboardHelper.SetClipboard(extraInfo);
        }

    }

}
