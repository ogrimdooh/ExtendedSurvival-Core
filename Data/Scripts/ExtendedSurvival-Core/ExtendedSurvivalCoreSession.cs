using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class ExtendedSurvivalCoreSession : BaseSessionComponent
    {

        public const string ES_TECHNOLOGY_LOCALNAME = "SEExtendedSurvival-Technology";
        public const string ES_STATS_LOCALNAME = "SEExtendedSurvival-Stats";

        public const ulong ES_TECHNOLOGY_MODID = 2842844421;
        public const ulong ES_STATS_EFFECTS_MODID = 2840924715;

        private static bool? isUsingTechnology = null;
        public static bool IsUsingTechnology()
        {
            if (!isUsingTechnology.HasValue)
                isUsingTechnology =  MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == ES_TECHNOLOGY_MODID || x.Name == ES_TECHNOLOGY_LOCALNAME);
            return isUsingTechnology.Value;
        }

        private static bool? isUsingStatsAndEffects = null;
        public static bool IsUsingStatsAndEffects()
        {
            if (!isUsingStatsAndEffects.HasValue)
                isUsingStatsAndEffects = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == ES_STATS_EFFECTS_MODID || x.Name == ES_STATS_LOCALNAME);
            return isUsingStatsAndEffects.Value;
        }

        public static ExtendedSurvivalCoreSession Static { get; private set; }

        private IMyHudNotification hudMsg;

        public HudAPIv2 TextAPI;

        public const ushort NETWORK_ID_CALLCLIENTSYSTEM = 40422;
        public const ushort NETWORK_ID_COMMANDS = 40423;
        public const ushort NETWORK_ID_DEFINITIONS = 40424;
        public const ushort NETWORK_ID_ENTITYCALLS = 40425;
        public const string CALL_FOR_DEFS = "NEEDDEFS";
        public const string CALL_FOR_WATER = "NEEDWATER";

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_CALLCLIENTSYSTEM, ClientUpdateMsgHandler);
            }

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);

                // Need this because of the recipes need balance
                MyAPIGateway.Session.SessionSettings.AssemblerEfficiencyMultiplier = 1f;

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
                Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, CALL_FOR_DEFS);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageToServer(
                    NETWORK_ID_DEFINITIONS,
                    Encoding.Unicode.GetBytes(message)
                );

            }

        }

        private DateTime lastCallWaterApi = DateTime.Now;
        private void ClientUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_CALLCLIENTSYSTEM)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);

                if (mCommandData.content.Length > 0)
                {

                    switch (mCommandData.content[0])
                    {
                        case CALL_FOR_WATER:

                            if (WaterModAPI.Registered)
                            {
                                if (!IsDedicated)
                                {
                                    if (MyAPIGateway.Session.PromoteLevel >= MyPromoteLevel.Moderator && (DateTime.Now - lastCallWaterApi).TotalMilliseconds > 5000)
                                    {
                                        long planetId = long.Parse(mCommandData.content[1]);
                                        var closestPlanet = MyGamePruningStructure.GetClosestPlanet(MyAPIGateway.Session.Camera.Position);
                                        if (planetId == closestPlanet?.EntityId)
                                        {
                                            float waterSize = float.Parse(mCommandData.content[2]);
                                            WaterModAPI.RunCommand("/wcreate");
                                            DelayWaterRunCommand(1500, $"/wradius {waterSize}", "/wrate 0");
                                            lastCallWaterApi = DateTime.Now;
                                        }
                                    }
                                }
                            }

                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void DelayWaterRunCommand(int millisecondsTimeout, params string[] commands)
        {
            var task = MyAPIGateway.Parallel.StartBackground(() =>
            {
                MyAPIGateway.Parallel.Sleep(millisecondsTimeout);
                foreach (var command in commands)
                {
                    WaterModAPI.RunCommand(command);
                }
            });
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
        private const string SETTINGS_COMMAND_STARSYSTEM = "starsystem";

        private const string SETTINGS_COMMAND_STARSYSTEM_CLEAR = "clear";
        private const string SETTINGS_COMMAND_STARSYSTEM_CREATE = "create";

        private static readonly Dictionary<string, KeyValuePair<int, bool>> VALID_COMMANDS = new Dictionary<string, KeyValuePair<int, bool>>()
        {
            { SETTINGS_COMMAND, new KeyValuePair<int, bool>(3, false) },
            { SETTINGS_COMMAND_VOXEL, new KeyValuePair<int, bool>(4, false) },
            { SETTINGS_COMMAND_PLANET, new KeyValuePair<int, bool>(4, false) },
            { SETTINGS_COMMAND_OREMAP, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_GEOTHERMAL, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_ATMOSPHERE, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_GRAVITY, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_WATER, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_ANIMALS, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_STARSYSTEM, new KeyValuePair<int, bool>(1, true) }
        };

        private void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            sendToOthers = true;
            if (!messageText.StartsWith("/")) return;
            var words = messageText.Trim().ToLower().Replace("/", "").Split(' ');
            if (words.Length > 0)
            {
                if (VALID_COMMANDS.ContainsKey(words[0]))
                {
                    if ((!VALID_COMMANDS[words[0]].Value && words.Length == VALID_COMMANDS[words[0]].Key) ||
                        (VALID_COMMANDS[words[0]].Value && words.Length >= VALID_COMMANDS[words[0]].Key))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                        MyAPIGateway.Multiplayer.SendMessageToServer(
                            NETWORK_ID_COMMANDS,
                            Encoding.Unicode.GetBytes(message)
                        );
                    }
                }
            }
        }

        private string TryToGetNearPlanet(ulong steamId, string nullReturn)
        {
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
                        return planet.SubtypeName;
                    }
                }
            }
            return nullReturn;
        }

        private void CommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (MyAPIGateway.Session.IsUserAdmin(steamId))
                {
                    if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                    {
                        if ((!VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].Key) ||
                            (VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].Key))
                        {
                            switch (mCommandData.content[0])
                            {
                                case SETTINGS_COMMAND:
                                    ExtendedSurvivalSettings.Instance.SetConfigValue(mCommandData.content[1], mCommandData.content[2]);
                                    break;
                                case SETTINGS_COMMAND_PLANET:
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.SetPlanetConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]);
                                    break;
                                case SETTINGS_COMMAND_VOXEL:
                                    ExtendedSurvivalSettings.Instance.SetVoxelConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]);
                                    break;
                                case SETTINGS_COMMAND_OREMAP:
                                    var options = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        options.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetOreMap(mCommandData.content[1], mCommandData.content[2], options.ToArray());
                                    break;
                                case SETTINGS_COMMAND_GEOTHERMAL:
                                    var optionsGeo = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        optionsGeo.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetThermalInfo(mCommandData.content[1], mCommandData.content[2], optionsGeo.ToArray());
                                    break;
                                case SETTINGS_COMMAND_ATMOSPHERE:
                                    var optionsAtm = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        optionsAtm.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetAtmosphereInfo(mCommandData.content[1], mCommandData.content[2], optionsAtm.ToArray());
                                    break;
                                case SETTINGS_COMMAND_GRAVITY:
                                    var optionsGvt = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        optionsGvt.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetGravityInfo(mCommandData.content[1], mCommandData.content[2], optionsGvt.ToArray());
                                    break;
                                case SETTINGS_COMMAND_WATER:
                                    var optionsWt = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        optionsWt.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetWaterInfo(mCommandData.content[1], mCommandData.content[2], optionsWt.ToArray());
                                    break;
                                case SETTINGS_COMMAND_ANIMALS:
                                    var optionsAnm = new List<string>();
                                    for (int i = 3; i < mCommandData.content.Length; i++)
                                    {
                                        optionsAnm.Add(mCommandData.content[i]);
                                    }
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1]);
                                    }
                                    ExtendedSurvivalSettings.Instance.ProcessPlanetAnimalsInfo(mCommandData.content[1], mCommandData.content[2], optionsAnm.ToArray());
                                    break;
                                case SETTINGS_COMMAND_STARSYSTEM:
                                    var optionsStarSystem = new List<string[]>();
                                    for (int i = 2; i < mCommandData.content.Length; i++)
                                    {
                                        optionsStarSystem.Add(mCommandData.content[i].Split('='));
                                    }
                                    switch (mCommandData.content[1])
                                    {
                                        case SETTINGS_COMMAND_STARSYSTEM_CLEAR:
                                            StarSystemController.ClearStarSystem();
                                            break;
                                        case SETTINGS_COMMAND_STARSYSTEM_CREATE:
                                            string profile = StarSystemMapProfile.DEFAULT_PROFILE;
                                            if (optionsStarSystem.Any(x => x.Length == 2 && x[0].ToLower() == "profile"))
                                            {
                                                profile = optionsStarSystem.FirstOrDefault(x => x.Length == 2 && x[0].ToLower() == "profile")[1];
                                            }
                                            var profileInfo = ExtendedSurvivalSettings.Instance.GetStarSystemInfo(profile);
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
                                                StarSystemController.ComputeNewStarSystem(profileInfo, flags);
                                            }
                                            break;
                                    }
                                    break;
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

        private void ClientDefinitionsUpdateServerMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsServer)
                {

                    switch (mCommandData.content[0])
                    {
                        default:
                            Command cmd = new Command(0, CALL_FOR_DEFS);
                            cmd.data = Encoding.Unicode.GetBytes(ExtendedSurvivalSettings.Instance.GetDataToClient());
                            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageTo(
                                NETWORK_ID_DEFINITIONS,
                                Encoding.Unicode.GetBytes(messageToSend),
                                mCommandData.sender
                            );
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ClientDefinitionsUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsClient)
                {
                    var settingsData = Encoding.Unicode.GetString(mCommandData.data);
                    ExtendedSurvivalSettings.ClientLoad(settingsData);
                    CheckDefinitions();
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        public override void SaveData()
        {
            base.SaveData();

            if (IsServer)
            {
                ExtendedSurvivalSettings.Save();
                ExtendedSurvivalStorage.Save();
            }
        }

        public override void LoadData()
        {
            TextAPI = new HudAPIv2();

            if (IsServer)
            {

                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();

            }

            base.LoadData();
        }

        private bool definitionsChecked = false;
        private void CheckDefinitions()
        {
            ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"CheckDefinitions Called");
            if (!definitionsChecked)
            {

                definitionsChecked = true;

                PlanetsOverride.SetDefinitions();
                VoxelMaterialsOverride.SetDefinitions();
                AssemblerOverride.TryOverride();
                DescriptionBlocksOverride.TryOverride();
                RecipientConstants.TryOverrideDefinitions();
                OreConstants.TryOverrideDefinitions();
                IngotsConstants.TryOverrideDefinitions();
                FactionTypeConstants.TryOverrideDefinitions();
                DropContainersOverride.TryOverride();

            }
        }

        protected override void UnloadData()
        {
            TextAPI.Close();

            if (!IsDedicated)
            {
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_CALLCLIENTSYSTEM, ClientUpdateMsgHandler);
            }

            if (IsServer)
            {
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);
            }
            else
            {
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
            }

            base.UnloadData();
        }

        public override void BeforeStart()
        {
            ExtendedSurvivalCoreAPIBackend.BeforeStart();
        }

        public void ShowMessage(string text, string font = MyFontEnum.Red, int timeToLive = 2000)
        {
            if (hudMsg == null)
                hudMsg = MyAPIGateway.Utilities.CreateNotification(string.Empty);

            hudMsg.Hide();
            hudMsg.Font = font;
            hudMsg.AliveTime = timeToLive;
            hudMsg.Text = text;
            hudMsg.Show();
        }

        private void CheckPlanetWaters()
        {
            if (ExtendedSurvivalEntityManager.Instance.HasPlanetNeedingWater())
            {
                var planets = ExtendedSurvivalEntityManager.Instance.GetPlanetNeedingWater();
                foreach (var planet in planets)
                {
                    var playerToAddWater = ExtendedSurvivalEntityManager.Instance.GetClosestPlayer(planet.Center(), MyPromoteLevel.Moderator);
                    if (playerToAddWater != null)
                    {
                        Command cmd = new Command(0, CALL_FOR_WATER, planet.Entity.EntityId.ToString(), planet.Setting.Water.Size.ToString());
                        string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                        MyAPIGateway.Multiplayer.SendMessageTo(
                            NETWORK_ID_CALLCLIENTSYSTEM,
                            Encoding.Unicode.GetBytes(messageToSend),
                            playerToAddWater.SteamUserId
                        );
                    }
                }
            }
        }

        protected override void DoUpdate60()
        {
            base.DoUpdate60();

            if (MyAPIGateway.Session.IsServer)
            {

                CheckPlanetWaters();

            }
        }

    }

}
