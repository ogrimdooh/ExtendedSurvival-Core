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
using VRage.ModAPI;
using VRage.Utils;
using VRage.Voxels;
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
        public const ulong BETTERSTONE_MOD_ID = 406244471;

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

        private static bool? isUsingBetterStone = null;
        public static bool IsUsingBetterStone()
        {
            if (!isUsingBetterStone.HasValue)
                isUsingBetterStone = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == BETTERSTONE_MOD_ID);
            return isUsingBetterStone.Value;
        }

        public const ulong MES_ALIENANIMALS_MODID = 2582239623;
        public const ulong ALIENANIMALS_MODID = 2075243878;

        private static bool? isUsingAlienAnimals = null;
        public static bool IsUsingAlienAnimals()
        {
            if (!isUsingAlienAnimals.HasValue)
                isUsingAlienAnimals = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == MES_ALIENANIMALS_MODID || x.PublishedFileId == ALIENANIMALS_MODID);
            return isUsingAlienAnimals.Value;
        }

        private static bool? isUsingEarthLikeAnimals = null;
        public static bool IsUsingEarthLikeAnimals()
        {
            if (!isUsingEarthLikeAnimals.HasValue)
                isUsingEarthLikeAnimals = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == PlanetMapProfile.EARTHLIKE_ANIMALS_MODID);
            return isUsingEarthLikeAnimals.Value;
        }

        private static PlanetMapProfile.OreMapType? _oreMapType = null;
        public static PlanetMapProfile.OreMapType GetOreMapType()
        {
            if (_oreMapType == null)
            {
                if (IsUsingTechnology() && IsUsingBetterStone())
                    _oreMapType = PlanetMapProfile.OreMapType.BetterStoneExtendedSurvival;
                else if (IsUsingTechnology())
                    _oreMapType = PlanetMapProfile.OreMapType.ExtendedSurvival;
                else if (IsUsingBetterStone())
                    _oreMapType = PlanetMapProfile.OreMapType.BetterStoneVanilla;
                else
                    _oreMapType = PlanetMapProfile.OreMapType.Vanilla;
            }
            return _oreMapType.Value;
        }

        public static ExtendedSurvivalCoreSession Static { get; private set; }

        public HudAPIv2 TextAPI;
        public EasyInventoryAPI EasyInventoryAPI;

        public const ushort NETWORK_ID_CALLSERVERSYSTEM = 40426;
        public const ushort NETWORK_ID_CALLCLIENTSYSTEM = 40422;
        public const ushort NETWORK_ID_COMMANDS = 40423;
        public const ushort NETWORK_ID_DEFINITIONS = 40424;
        public const ushort NETWORK_ID_ENTITYCALLS = 40425;
        public const string CALL_FOR_DEFS = "NEEDDEFS";
        public const string CALL_FOR_WATER = "NEEDWATER";
        public const string BRODCAST_VOXELRESET = "BRODCAST_VOXELRESET";
        public const string STARSHIPKEY_DEF = "STARSHIPKEY_DEF";
        public const string PLAYEROPENSTOREGUI = "PLAYEROPENSTOREGUI";
        public const string PLAYERCLOSESTOREGUI = "PLAYERCLOSESTOREGUI";
        public const string CALLSTARSHIPKEY = "CALLSTARSHIPKEY";
        public const string SENDSTARSHIPKEY = "SENDSTARSHIPKEY";

        public AdvancedPlayerUICoreAPI APUCoreAPI;
        public NanobotAPI NanobotAPI;

        private bool NeedToNullDamage(long attackerPlayerId, bool isAttackerPlayer, long ownerId, MyDamageInformationExtensions.DamageType damageType)
        {
            if (attackerPlayerId != 0)
            {
                var ownerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                var attackerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(attackerPlayerId);
                if (ownerId == attackerPlayerId || ownerFaction?.FactionId == attackerFaction?.FactionId)
                {
                    if (damageType != MyDamageInformationExtensions.DamageType.Tool)
                    {
                        return true;
                    }
                }
                else
                {
                    if (isAttackerPlayer)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (damageType != MyDamageInformationExtensions.DamageType.Fall)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            StarShipKeyConstants.LoadBaseKeys();

            if (!IsDedicated)
            {
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_CALLCLIENTSYSTEM, ClientUpdateMsgHandler);
                MyAPIGateway.Gui.GuiControlCreated += Gui_GuiControlCreated;
                MyAPIGateway.Gui.GuiControlRemoved += Gui_GuiControlRemoved;
            }
            
            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_CALLSERVERSYSTEM, ServerUpdateMsgHandler);
                
                // Need this because of the recipes need balance
                MyAPIGateway.Session.SessionSettings.AssemblerEfficiencyMultiplier = 1f;

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);

                MyAPIGateway.Session.DamageSystem.RegisterBeforeDamageHandler(int.MaxValue, (object entity, ref MyDamageInformation damage) =>
                {
                    try
                    {
                        if (entity != null && damage.Amount > 0)
                        {
                            var cubeBlock = entity as IMySlimBlock;
                            if (cubeBlock != null)
                            {
                                var ownerId = cubeBlock.OwnerId != 0 ? cubeBlock.OwnerId : cubeBlock.CubeGrid.BigOwners.FirstOrDefault();
                                var isPlayer = MyAPIGateway.Players.TryGetSteamId(ownerId) != 0;
                                long attackerPlayerId = 0;
                                MyDamageInformationExtensions.DamageType damageType;
                                MyDamageInformationExtensions.AttackerType attackerType = MyDamageInformationExtensions.AttackerType.None;
                                VRage.ModAPI.IMyEntity attackerEntity = null;
                                if (damage.AttackerId != 0)
                                    attackerEntity = damage.GetAttacker(out attackerPlayerId, out damageType, out attackerType);
                                else
                                    damageType = MyDamageInformationExtensions.GetDamageType(damage.Type);
                                var isAttackerPlayer = MyAPIGateway.Players.TryGetSteamId(attackerPlayerId) != 0;
                                if (damage.Amount > 0)
                                {
                                    CheckGridCanBeDamage(cubeBlock, ownerId, attackerPlayerId, damageType, attackerType, attackerEntity, ref damage);
                                }
                                if (damage.Amount > 0 && ExtendedSurvivalStorage.Instance.StarSystem.Generated &&
                                    ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.HasPveArea))
                                {
                                    if (isPlayer)
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
                                                    if (NeedToNullDamage(attackerPlayerId, isAttackerPlayer, ownerId, damageType))
                                                    {
                                                        damage.Amount = 0;
                                                        damage.IsDeformation = false;
                                                    }
                                                }
                                                else
                                                {
                                                    damage.Amount = 0;
                                                    damage.IsDeformation = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (ExtendedSurvivalSettings.Instance.Combat.LogAllPvPDamage && isPlayer && isAttackerPlayer &&
                                    attackerPlayerId != ownerId && damage.Amount > 0 && ExtendedSurvivalEntityManager.Instance != null)
                                {
                                    ExtendedSurvivalEntityManager.Instance.DamageToLog.Enqueue(new ExtendedSurvivalCoreDamageLogging.DamageToLogInfo()
                                    {
                                        attackerId = attackerPlayerId,
                                        ownerId = ownerId,
                                        damageType = damageType,
                                        gridName = cubeBlock.CubeGrid.CustomName,
                                        position = cubeBlock.CubeGrid.GetPosition(),
                                        amount = damage.Amount,
                                        time = DateTime.Now
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                    }
                });

                NanobotAPI = new NanobotAPI(()=> 
                { 
                    if (NanobotAPI.Registered)
                    {
                        NanobotAPI.OnCanGrindTargetBlock(
                            (nanobotBLock, block, distance) =>
                            {
                                var pos = block.CubeGrid.GetPosition();
                                if (IsPveZone(pos))
                                {
                                    var ownerId = block.OwnerId != 0 ? block.OwnerId : block.CubeGrid.BigOwners.FirstOrDefault();
                                    var isPlayer = MyAPIGateway.Players.TryGetSteamId(ownerId) != 0;
                                    if (isPlayer)
                                    {
                                        var attackerPlayerId = nanobotBLock.OwnerId;
                                        var isAttackerPlayer = MyAPIGateway.Players.TryGetSteamId(attackerPlayerId) != 0;
                                        if (NeedToNullDamage(attackerPlayerId, isAttackerPlayer, ownerId, MyDamageInformationExtensions.DamageType.Tool))
                                        {
                                            return false;
                                        }
                                    }
                                }
                                return true;
                            }, 
                            int.MaxValue
                        );
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

        private void Gui_GuiControlCreated(object obj)
        {
            var guiName = obj.GetType().Name;
            if (guiName == "MyGuiScreenStoreBlock")
            {
                StarShipKeyConstants.PlayerOpenStoreGui();
            }
        }

        private void Gui_GuiControlRemoved(object obj)
        {
            var guiName = obj.GetType().Name;
            if (guiName == "MyGuiScreenStoreBlock")
            {
                StarShipKeyConstants.PlayerCloseStoreGui();
            }
        }

        public bool IsPveZone(Vector3D pos)
        {
            float naturalGravityInterference;
            Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(pos, out naturalGravityInterference);
            if (naturalGravityInterference > 0)
            {
                var neartPlanet = ExtendedSurvivalEntityManager.GetPlanetAtRange(pos);
                var memberInfo = ExtendedSurvivalStorage.Instance.StarSystem.Members.FirstOrDefault(x => x.EntityId == neartPlanet.Entity.EntityId);
                return memberInfo.HasPveArea;
            }
            return false;
        }

        private void CheckGridCanBeDamage(IMySlimBlock cubeBlock, long ownerId, long attackerPlayerId, 
            MyDamageInformationExtensions.DamageType damageType, MyDamageInformationExtensions.AttackerType attackerType,
            VRage.ModAPI.IMyEntity attackerEntity, ref MyDamageInformation damage)
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.Combat.NoGrindFunctionalGrids ||
                    ExtendedSurvivalSettings.Instance.Combat.NoGridSelfDamage)
                {
                    var gridInfo = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(cubeBlock.CubeGrid.EntityId);
                    if (gridInfo != null)
                    {
                        if (gridInfo.Entity.ResourceDistributor.ResourceState != VRage.MyResourceStateEnum.NoPower)
                        {
                            if (gridInfo.AnyWeaponIsFunctional)
                            {
                                if (damage.AttackerId != 0)
                                {
                                    if (MyAPIGateway.Players.TryGetSteamId(attackerPlayerId) != 0)
                                    {
                                        if (damageType == MyDamageInformationExtensions.DamageType.Tool &&
                                            ExtendedSurvivalSettings.Instance.Combat.NoGrindFunctionalGrids)
                                        {
                                            var ownerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                                            var attackerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(attackerPlayerId);
                                            if (ownerId != attackerPlayerId && ownerFaction?.FactionId != attackerFaction?.FactionId)
                                            {
                                                if (cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_Door) &&
                                                    cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightSlideDoor) &&
                                                    cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightHangarDoor))
                                                {
                                                    damage.Amount = 0;
                                                    damage.IsDeformation = false;
                                                }
                                            }
                                        }
                                    }
                                    if (damage.Amount > 0 &&
                                        attackerType == MyDamageInformationExtensions.AttackerType.CubeBlock &&
                                        ExtendedSurvivalSettings.Instance.Combat.NoGridSelfDamage)
                                    {
                                        var attackerBlock = attackerEntity as IMyCubeBlock;
                                        if (attackerBlock != null && attackerBlock.CubeGrid.EntityId == cubeBlock.CubeGrid.EntityId)
                                        {
                                            damage.Amount = 0;
                                            damage.IsDeformation = false;
                                        }
                                    }
                                }
                                else
                                {
                                    /* During a battle a many damages info is lack of attacker id, so better avoid tool damage */
                                    if (damageType == MyDamageInformationExtensions.DamageType.Tool &&
                                        ExtendedSurvivalSettings.Instance.Combat.NoGrindFunctionalGrids)
                                    {
                                        if (cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_Door) &&
                                            cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightSlideDoor) &&
                                            cubeBlock.BlockDefinition.Id.TypeId != typeof(MyObjectBuilder_AirtightHangarDoor))
                                        {
                                            damage.Amount = 0;
                                            damage.IsDeformation = false;
                                        }
                                    }
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

        private void ServerUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_CALLSERVERSYSTEM || !IsServer)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (mCommandData.content.Length > 0)
                {
                    long playerId = 0;
                    switch (mCommandData.content[0])
                    {
                        case PLAYEROPENSTOREGUI:
                            if (long.TryParse(mCommandData.content[1], out playerId))
                            {
                                if (ExtendedSurvivalEntityManager.Instance.Players.ContainsKey(playerId))
                                {
                                    StarShipKeyConstants.DoPlayerOpenStoreGui(ExtendedSurvivalEntityManager.Instance.Players[playerId]);
                                }
                            }
                            break;
                        case PLAYERCLOSESTOREGUI:
                            if (long.TryParse(mCommandData.content[1], out playerId))
                            {
                                if (ExtendedSurvivalEntityManager.Instance.Players.ContainsKey(playerId))
                                {
                                    StarShipKeyConstants.DoPlayerCloseStoreGui(ExtendedSurvivalEntityManager.Instance.Players[playerId]);
                                }
                            }
                            break;
                        case CALLSTARSHIPKEY:
                            StarShipKeyConstants.SendKeysToClient(steamId);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
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
                        case BRODCAST_VOXELRESET:
                            var voxels = mCommandData.content[1].Split(';');
                            foreach (var voxel in voxels)
                            {
                                long entityId = 0;
                                if (long.TryParse(voxel, out entityId))
                                {
                                    IMyEntity entity = null;
                                    if (MyAPIGateway.Entities.TryGetEntityById(entityId, out entity))
                                    {
                                        (entity as IMyVoxelBase)?.Storage.Reset(MyStorageDataTypeFlags.ContentAndMaterial);
                                    }
                                }
                            }
                            break;
                        case STARSHIPKEY_DEF:
                            if (mCommandData.content.Length == 3)
                            {
                                UniqueEntityId starshipid = null;
                                if (UniqueEntityId.TryParse(mCommandData.content[1], out starshipid))
                                {
                                    StarShipKeyConstants.DoUpdateStarShipKeyDesc(starshipid, mCommandData.content[2]);
                                }
                            }
                            break;
                        case SENDSTARSHIPKEY:
                            var keys = mCommandData.content.Skip(2).ToList();
                            if (keys.Any())
                            {
                                StarShipKeyConstants.LoadKeysIntoClient(keys);
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

                InfiniteMapProfile.DoAfterPlanetOverride();

                BetterStoneIntegrationProfile.DoOnSettingsOverride();

                if (IsServer)
                    ExtendedSurvivalSettings.Instance.CheckLoadedValues();
                else
                    StarShipKeyConstants.CallForServerKeys();

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
                    MyAPIGateway.Gui.GuiControlCreated -= Gui_GuiControlCreated;
                    MyAPIGateway.Gui.GuiControlRemoved -= Gui_GuiControlRemoved;
                }

                if (IsServer)
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_CALLSERVERSYSTEM, ServerUpdateMsgHandler);
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);
                }
                else
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
                }

                ExtendedSurvivalCoreLogging.Instance.Close();
                ExtendedSurvivalCoreDamageLogging.Instance.Close();
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

        public static void VoxelResetBrodcast(List<long> idsToReset)
        {
            if (idsToReset != null && idsToReset.Any())
            {
                Command cmd = new Command(0, BRODCAST_VOXELRESET, string.Join(";", idsToReset));
                string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageToOthers(
                    NETWORK_ID_CALLCLIENTSYSTEM,
                    Encoding.Unicode.GetBytes(messageToSend)
                );
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
