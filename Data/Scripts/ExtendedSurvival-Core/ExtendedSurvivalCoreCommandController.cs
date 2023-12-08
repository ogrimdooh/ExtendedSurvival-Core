﻿using Sandbox.ModAPI;
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
            public bool FixedOptions { get; set; }
            public HelpController.CommandEntryHelpInfo HelpInfo { get; set; }

            public ValidCommand(string command, int minOptions, bool fixedOptions)
            {
                Command = command;
                MinOptions = minOptions;
                FixedOptions = fixedOptions;
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
                    OnAfterBuildPage = (sb) =>
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
                    Syntax = "/planet.settings <PLANET : USE '$' TO USE THE NEAR PLANET> <CONFIG> <VALUE>",
                    CommandSample = "/planet.settings Pertam respawnenabled true" + Environment.NewLine + "/planet.settings $ type 1",
                    OnAfterBuildPage = (sb) =>
                    {
                        var planets = ExtendedSurvivalSettings.Instance?.Planets.Select(x => x.Id).ToArray() ?? new string[] { };
                        HelpController.FormatHelpLine(sb, $"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VALIDPLANETS)}: ", planets);
                    }
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_OREMAP] = new ValidCommand(SETTINGS_COMMAND_OREMAP, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_GEOTHERMAL] = new ValidCommand(SETTINGS_COMMAND_GEOTHERMAL, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_ATMOSPHERE] = new ValidCommand(SETTINGS_COMMAND_ATMOSPHERE, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_GRAVITY] = new ValidCommand(SETTINGS_COMMAND_GRAVITY, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_WATER] = new ValidCommand(SETTINGS_COMMAND_WATER, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_ANIMALS] = new ValidCommand(SETTINGS_COMMAND_ANIMALS, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_METEORIMPACT] = new ValidCommand(SETTINGS_COMMAND_METEORIMPACT, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_SUPERFICIALMINING] = new ValidCommand(SETTINGS_COMMAND_SUPERFICIALMINING, 3, true);
            VALID_COMMANDS[SETTINGS_COMMAND_STARSYSTEM] = new ValidCommand(SETTINGS_COMMAND_STARSYSTEM, 1, true);
            VALID_COMMANDS[SETTINGS_COMMAND_METEORWAVE] = new ValidCommand(SETTINGS_COMMAND_METEORWAVE, 0, true);
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

        private const string SETTINGS_COMMAND_STARSYSTEM_CLEAR = "clear";
        private const string SETTINGS_COMMAND_STARSYSTEM_CREATE = "create";
        private const string SETTINGS_COMMAND_STARSYSTEM_COMPLETE = "complete";
        private const string SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY = "reseteconomy";
        private const string SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS = "recreatestation";
        private const string SETTINGS_COMMAND_STARSYSTEM_PVEZONE = "pvezone";

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
                    if ((!VALID_COMMANDS[words[0]].FixedOptions && words.Length == VALID_COMMANDS[words[0]].MinOptions) ||
                        (VALID_COMMANDS[words[0]].FixedOptions && words.Length >= VALID_COMMANDS[words[0]].MinOptions))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        if (IsServer)
                        {
                            if (MyAPIGateway.Session.IsUserAdmin(MyAPIGateway.Multiplayer.MyId))
                            {
                                HandlerMsgCommand(cmd);
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

        private void HandlerMsgCommand(Command mCommandData)
        {
            
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
                    if (MyAPIGateway.Session.IsUserAdmin(steamId))
                    {
                        if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                        {
                            if ((!VALID_COMMANDS[mCommandData.content[0]].FixedOptions && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].MinOptions) ||
                                (VALID_COMMANDS[mCommandData.content[0]].FixedOptions && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].MinOptions))
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
                                    case SETTINGS_COMMAND_STARSYSTEM:
                                        var optionsStarSystem = new List<string[]>();
                                        for (int i = 2; i < mCommandData.content.Length; i++)
                                        {
                                            optionsStarSystem.Add(mCommandData.content[i].Split('='));
                                        }
                                        switch (mCommandData.content[1])
                                        {
                                            case SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS:
                                                StarSystemController.RecreateStations();
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS} executed.", MyFontEnum.White);
                                                break;
                                            case SETTINGS_COMMAND_STARSYSTEM_COMPLETE:
                                                StarSystemController.CompleteStarSystem();
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_COMPLETE} executed.", MyFontEnum.White);
                                                break;
                                            case SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY:
                                                StarSystemController.DoResetAllFactionBalance();
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY} executed.", MyFontEnum.White);
                                                break;
                                            case SETTINGS_COMMAND_STARSYSTEM_CLEAR:
                                                StarSystemController.ClearStarSystem();
                                                SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CLEAR} executed.", MyFontEnum.White);
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
                                }
                            }
                        }
                    }
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

        public void SendMessage(ulong target, string text, string font = MyFontEnum.Red, int timeToLive = 5000)
        {
            if (IsDedicated || (IsServer && MyAPIGateway.Multiplayer.MyId != target))
            {
                string[] values = new string[]
                {
                    text,
                    font,
                    timeToLive.ToString()
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
                ShowMessage(text, font, timeToLive);
            }
        }

        public void ShowMessage(string text, string font = MyFontEnum.Red, int timeToLive = 5000)
        {
            if (hudMsg == null)
                hudMsg = MyAPIGateway.Utilities.CreateNotification(string.Empty);

            hudMsg.Hide();
            hudMsg.Font = font;
            hudMsg.AliveTime = timeToLive;
            hudMsg.Text = text;
            hudMsg.Show();
        }

    }

}