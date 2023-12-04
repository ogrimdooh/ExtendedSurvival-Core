using Sandbox.Common.ObjectBuilders;
using Sandbox.Engine.Physics;
using Sandbox.Game.Entities;
using Sandbox.Game.GameSystems;
using Sandbox.Game.World;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class ExtendedSurvivalCoreSession : BaseSessionComponent
    {

        public const string ES_TECHNOLOGY_LOCALNAME = "SEExtendedSurvival-Technology";
        public const string ES_STATS_LOCALNAME = "SEExtendedSurvival-Stats";

        public const ulong ES_TECHNOLOGY_MODID = 2842844421;
        public const ulong ES_STATS_EFFECTS_MODID = 2840924715;

        private static bool? isLocalExecution = null;
        public static bool IsLocalExecution()
        {
            if (!isLocalExecution.HasValue)
                isLocalExecution = MyAPIGateway.Session.Mods.Any(x => x.Name == ES_STATS_LOCALNAME || x.Name == ES_TECHNOLOGY_LOCALNAME);
            return isLocalExecution.Value;
        }

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
        public EasyInventoryAPI EasyInventoryAPI;

        public const ushort NETWORK_ID_CALLCLIENTSYSTEM = 40422;
        public const ushort NETWORK_ID_COMMANDS = 40423;
        public const ushort NETWORK_ID_DEFINITIONS = 40424;
        public const ushort NETWORK_ID_ENTITYCALLS = 40425;
        public const string CALL_FOR_DEFS = "NEEDDEFS";
        public const string CALL_FOR_WATER = "NEEDWATER";

        public AdvancedPlayerUICoreAPI APUCoreAPI;

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

                MyAPIGateway.Session.DamageSystem.RegisterBeforeDamageHandler(int.MaxValue, (object entity, ref MyDamageInformation damage) =>
                {
                    if (entity != null && damage.Amount > 0)
                    {
                        var cubeBlock = entity as IMySlimBlock;
                        if (cubeBlock != null)
                        {
                            var ownerId = cubeBlock.OwnerId != 0 ? cubeBlock.OwnerId : cubeBlock.CubeGrid.BigOwners.FirstOrDefault();
                            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated &&
                                ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.HasPveArea))
                            {
                                if (MyAPIGateway.Players.TryGetSteamId(ownerId) != 0)
                                {
                                    /* Player GRID */
                                    var pos = cubeBlock.CubeGrid.GetPosition();
                                    float naturalGravityInterference;
                                    Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(pos, out naturalGravityInterference);
                                    if (naturalGravityInterference > 0)
                                    {
                                        var neartPlanet = ExtendedSurvivalEntityManager.GetPlanetAtRange(pos);
                                        var memberInfo = ExtendedSurvivalStorage.Instance.StarSystem.Members.FirstOrDefault(x => x.EntityId == neartPlanet.Entity.EntityId);
                                        if (memberInfo.HasPveArea)
                                        {
                                            if (damage.AttackerId != 0)
                                            {
                                                long attackerPlayerId = 0;
                                                MyDamageInformationExtensions.DamageType damageType;
                                                var attackerEntity = damage.GetAttacker(out attackerPlayerId, out damageType);
                                                if (attackerPlayerId != 0)
                                                {
                                                    var ownerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                                                    var attackerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(attackerPlayerId);
                                                    if (ownerId == attackerPlayerId || ownerFaction.FactionId == attackerFaction.FactionId)
                                                    {
                                                        if (damageType != MyDamageInformationExtensions.DamageType.Tool)
                                                        {
                                                            damage.Amount = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        var steamId = MyAPIGateway.Players.TryGetSteamId(attackerPlayerId);
                                                        if (steamId != 0)
                                                        {
                                                            damage.Amount = 0;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (damageType != MyDamageInformationExtensions.DamageType.Fall)
                                                    {
                                                        damage.Amount = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                damage.Amount = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            if (damage.Amount > 0)
                            {
                                CheckGridCanBeGrinded(cubeBlock, ownerId, ref damage);
                            }
                        }
                    }
                });

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

            APUCoreAPI = new AdvancedPlayerUICoreAPI(() =>
            {
                if (AdvancedPlayerUICoreAPI.Registered)
                {
                    AdvancedPlayerUICoreAPI.RegisterGetHelpTopics("ESCORE", HelpController.GetHelpTopics);
                    AdvancedPlayerUICoreAPI.RegisterGetHelpTopicEntries("ESCORE", HelpController.GetHelpTopicEntries);
                    AdvancedPlayerUICoreAPI.RegisterGetHelpEntryPageData("ESCORE", HelpController.GetHelpEntryPageData);
                }
            });

        }

        private void CheckGridCanBeGrinded(IMySlimBlock cubeBlock, long ownerId, ref MyDamageInformation damage)
        {
            if (ExtendedSurvivalSettings.Instance.CombatSetting.NoGrindFunctionalGrids)
            {
                var gridInfo = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(cubeBlock.CubeGrid.EntityId);
                if (gridInfo != null)
                {
                    if (gridInfo.Entity.ResourceDistributor.ResourceState != VRage.MyResourceStateEnum.NoPower)
                    {
                        if (gridInfo.HasWeapon)
                        {
                            if (damage.AttackerId != 0)
                            {
                                long attackerPlayerId = 0;
                                MyDamageInformationExtensions.DamageType damageType;
                                var attackerEntity = damage.GetAttacker(out attackerPlayerId, out damageType);
                                if (MyAPIGateway.Players.TryGetSteamId(attackerPlayerId) != 0)
                                {
                                    if (damageType == MyDamageInformationExtensions.DamageType.Tool)
                                    {
                                        var ownerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                                        var attackerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(attackerPlayerId);
                                        if (ownerId != attackerPlayerId && ownerFaction.FactionId != attackerFaction.FactionId)
                                        {
                                            if (cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_Door) &&
                                            cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightSlideDoor) &&
                                            cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightHangarDoor))
                                            {
                                                damage.Amount = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public const char COMMAND_PREFIX = '/';
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
                                            WaterModAPI.RunCommand($"{COMMAND_PREFIX}wcreate".Trim());
                                            DelayWaterRunCommand(1500, $"{COMMAND_PREFIX}wradius {waterSize}".Trim(), $"{COMMAND_PREFIX}wrate 0".Trim());
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
        private const string SETTINGS_COMMAND_METEORWAVE = "meteorwave";

        private const string SETTINGS_COMMAND_STARSYSTEM_CLEAR = "clear";
        private const string SETTINGS_COMMAND_STARSYSTEM_CREATE = "create";
        private const string SETTINGS_COMMAND_STARSYSTEM_COMPLETE = "complete";
        private const string SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY = "reseteconomy";
        private const string SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS = "recreatestation";
        private const string SETTINGS_COMMAND_STARSYSTEM_PVEZONE = "pvezone";

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
            { SETTINGS_COMMAND_STARSYSTEM, new KeyValuePair<int, bool>(1, true) },
            { SETTINGS_COMMAND_METEORWAVE, new KeyValuePair<int, bool>(0, true) }
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
                            long planetId = 0;
                            switch (mCommandData.content[0])
                            {
                                case SETTINGS_COMMAND:
                                    if (ExtendedSurvivalSettings.Instance.SetConfigValue(mCommandData.content[1], mCommandData.content[2]))
                                    {
                                        ShowMessage($"[ExtendedSurvivalCore] Config {mCommandData.content[1]} set to {mCommandData.content[2]}.", MyFontEnum.White);
                                    }
                                    break;
                                case SETTINGS_COMMAND_PLANET:
                                    if (mCommandData.content[1] == "$")
                                    {
                                        mCommandData.content[1] = TryToGetNearPlanet(steamId, mCommandData.content[1], out planetId);
                                    }
                                    if (ExtendedSurvivalSettings.Instance.SetPlanetConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]))
                                    {
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_PLANET} executed.", MyFontEnum.White);
                                    }
                                    break;
                                case SETTINGS_COMMAND_VOXEL:
                                    if (ExtendedSurvivalSettings.Instance.SetVoxelConfigValue(mCommandData.content[1], mCommandData.content[2], mCommandData.content[3]))
                                    {
                                        ShowMessage($"[ExtendedSurvivalCore] Voxel {mCommandData.content[1]} set config {mCommandData.content[2]} to {mCommandData.content[3]}.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_OREMAP} executed.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_GEOTHERMAL} executed.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_ATMOSPHERE} executed.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_GRAVITY} executed.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_WATER} executed.", MyFontEnum.White);
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
                                        ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_ANIMALS} executed.", MyFontEnum.White);
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
                                            ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RECREATESTATIONS} executed.", MyFontEnum.White);
                                            break;
                                        case SETTINGS_COMMAND_STARSYSTEM_COMPLETE:
                                            StarSystemController.CompleteStarSystem();
                                            ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_COMPLETE} executed.", MyFontEnum.White);
                                            break;
                                        case SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY:
                                            StarSystemController.DoResetAllFactionBalance();
                                            ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_RESETECONOMY} executed.", MyFontEnum.White);
                                            break;
                                        case SETTINGS_COMMAND_STARSYSTEM_CLEAR:
                                            StarSystemController.ClearStarSystem();
                                            ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CLEAR} executed.", MyFontEnum.White);
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
                                                ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_PVEZONE} executed.", MyFontEnum.White);
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
                                                    ShowMessage($"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_STARSYSTEM} {SETTINGS_COMMAND_STARSYSTEM_CREATE} executed.", MyFontEnum.White);
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case SETTINGS_COMMAND_METEORWAVE:
                                    if (IsLocalExecution())
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
                SpaceStationController.SaveStations();
                ExtendedSurvivalSettings.Save();
                ExtendedSurvivalStorage.Save();
            }
        }

        public override void LoadData()
        {
            TextAPI = new HudAPIv2();
            EasyInventoryAPI = new EasyInventoryAPI(() => {
                EasyInventoryAPI.RegisterEasyFilter("ExtendedSurvival-Stats", (item) => {
                    return new UniqueEntityId(item).typeId == typeof(MyObjectBuilder_ConsumableItem);
                });
            });
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
            
            try
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
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            base.UnloadData();
        }

        public override void BeforeStart()
        {
            ExtendedSurvivalCoreAPIBackend.BeforeStart();
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

        public Vector3 BaseSunDirection { get; private set; }
        public Vector3 SunDirectionNormalized { get; private set; }
        protected void DoUpdateSunDir()
        {
            var session = (MyAPIGateway.Session.WeatherEffects as MySessionComponentBase);
            if (session != null)
            {
                var builder = session.GetObjectBuilder() as MyObjectBuilder_SectorWeatherComponent;
                if (builder != null)
                {
                    BaseSunDirection = builder.BaseSunDirection;
                    SunDirectionNormalized = builder.SunDirectionNormalized;
                }
            }
        }

        protected override void DoUpdate60()
        {
            base.DoUpdate60();

            if (MyAPIGateway.Session.IsServer)
            {

                CheckPlanetWaters();
                DoUpdateSunDir();

            }
        }

    }

}
