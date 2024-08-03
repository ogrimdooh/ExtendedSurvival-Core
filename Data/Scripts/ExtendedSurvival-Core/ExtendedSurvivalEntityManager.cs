using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.Game;
using VRage.Game.ModAPI;
using Sandbox.Game.Entities;
using VRageMath;
using VRage.Game.Entity;
using System.Collections.Concurrent;
using Sandbox.ModAPI.Weapons;
using Sandbox.Game;
using System.Text;
using Sandbox.Game.GameSystems;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.World;
using VRage.Utils;
using Sandbox.Definitions;

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalEntityManager : BaseSessionComponent
    {

        public class OnReloadHandheldGun
        {

            public Action<IMyAutomaticRifleGun, int, MyDefinitionId, IMyInventory> Action { get; set; }
            public int Priority { get; set; }

        }

        public static Dictionary<UniqueEntityId, float> ExtraStartLoot { get; set; } = new Dictionary<UniqueEntityId, float>();
        public static ExtendedSurvivalEntityManager Instance { get; private set; }

        private static readonly Random rnd = new Random();

        public static List<OnReloadHandheldGun> ReloadHandheldGun { get; set; } = new List<OnReloadHandheldGun>();

        public List<MyPlanet> PlanetsOnLoad { get; private set; } = new List<MyPlanet>();
        public List<IMyCubeGrid> GridsOnLoad { get; private set; } = new List<IMyCubeGrid>();
        public List<GridEntity> Grids { get; private set; } = new List<GridEntity>();
        public List<MySafeZone> SafeZones { get; private set; } = new List<MySafeZone>();
        public ConcurrentDictionary<long, IMyVoxelMap> VoxelMaps { get; private set; } = new ConcurrentDictionary<long, IMyVoxelMap>();
        public ConcurrentDictionary<long, PlanetEntity> Planets { get; private set; } = new ConcurrentDictionary<long, PlanetEntity>();
        public ConcurrentDictionary<long, HandheldGunEntity> HandheldGuns { get; private set; } = new ConcurrentDictionary<long, HandheldGunEntity>();
        public ConcurrentDictionary<long, IMyPlayer> Players { get; private set; } = new ConcurrentDictionary<long, IMyPlayer>();

        public ConcurrentQueue<ExtendedSurvivalCoreDamageLogging.DamageToLogInfo> DamageToLog = new ConcurrentQueue<ExtendedSurvivalCoreDamageLogging.DamageToLogInfo>();

        public bool InicialLoadComplete { get; private set; } = false;

        public bool HasPlanetNeedingWater()
        {
            if (!WaterModAPI.Registered)
                return false;
            return Planets.Values.Any(x => x.Setting != null && x.Setting.Water.Enabled && !x.HasWater());
        }

        public List<PlanetEntity> GetPlanetNeedingWater()
        {
            return Planets.Values.Where(x => x.Setting != null && x.Setting.Water.Enabled && !x.HasWater()).ToList();
        }

        public GridEntity GetGridByUuid(long uuid)
        {
            return Grids.FirstOrDefault(x => x.Entity.EntityId == uuid);
        }

        protected bool canRun;
        protected ParallelTasks.Task task;
        protected ParallelTasks.Task taskStations;
        protected ParallelTasks.Task taskStones;
        protected ParallelTasks.Task taskFactions;
        protected ParallelTasks.Task taskGuns;
        protected ParallelTasks.Task taskAsteroids;
        protected ParallelTasks.Task taskLogDamage;
        protected ParallelTasks.Task taskGpsPlayers;
        protected ParallelTasks.Task taskDecaySystem;
        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            Instance = this;
            if (MyAPIGateway.Session.IsServer)
            {
                canRun = true;
                task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [CheckAllGrids START]");
                    // Loop CheckAllGrids
                    while (canRun)
                    {
                        CheckAllGrids();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(250);
                        else
                            break;
                    }
                });
                taskStations = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [SpaceStationController START]");
                    // Loop CheckTradeStations
                    while (canRun)
                    {
                        SpaceStationController.DoCycle();
                        CheckTradeStations();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(2500);
                        else
                            break;
                    }
                });
                taskAsteroids = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [StarSystemController START]");
                    // Loop CheckTradeStations
                    int runCount = 0;
                    while (canRun)
                    {
                        StarSystemController.DoCycle();
                        if (runCount % 10 == 0)
                        {
                            StarSystemController.ClearAsteroidsThatCanBeRemoved();
                            runCount = 0;
                        }
                        else
                        {
                            runCount++;
                        }
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(2500);
                        else
                            break;
                    }
                });
                taskStones = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [MeteorStonesController START]");
                    while (MyExtendedSurvivalTimeManager.Instance == null)
                    {
                        MyAPIGateway.Parallel.Sleep(100);
                    }
                    _lastCheckMeteorStones = MyExtendedSurvivalTimeManager.Instance.GameTime;
                    // Loop CheckMeteorStones
                    while (canRun)
                    {
                        CheckMeteorStones();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(10000);
                        else
                            break;
                    }
                });
                taskFactions = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [CheckFactions START]");
                    // Loop CheckFactions
                    int c = 0;
                    bool first = true;
                    while (canRun)
                    {
                        if (!FactionsLocked && (Instance?.Loaded ?? false))
                        {
                            CheckFactions(first || c >= 30); /* force every 10 minutes */
                            c++;
                            if (c >= 7)
                                c = 0;
                            first = false;
                        }
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(10000);
                        else
                            break;
                    }
                });
                taskGuns = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [CheckHandGuns START]");
                    // Loop StoreCurrentAmmo
                    while (canRun)
                    {
                        try
                        {
                            long[] keys;
                            lock (HandheldGuns)
                            {
                                keys = HandheldGuns.Keys.ToArray();
                            }
                            for (int i = 0; i < keys.Length; i++)
                            {
                                if (HandheldGuns.ContainsKey(keys[i]))
                                {
                                    HandheldGuns[keys[i]].StoreCurrentAmmo();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                        }
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(25);
                        else
                            break;
                    }
                });
                taskLogDamage = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [LogDamage START]");
                    while (canRun)
                    {
                        try
                        {
                            while (DamageToLog.Any())
                            {
                                ExtendedSurvivalCoreDamageLogging.DamageToLogInfo info;
                                if (DamageToLog.TryDequeue(out info))
                                {
                                    ExtendedSurvivalCoreDamageLogging.Instance.Log(info);
                                }
                                else
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                        }
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(25);
                        else
                            break;
                    }
                });
                taskGpsPlayers = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [CheckGpsToAllPlayers START]");
                    // Loop CheckGpsToAllPlayers
                    while (canRun)
                    {
                        StarSystemController.CheckGpsToAllPlayers();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(60000);
                        else
                            break;
                    }
                });
                taskDecaySystem = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [DecaySystemController START]");
                    // Loop DecaySystemController
                    int runCount = 0;
                    while (canRun)
                    {
                        var decayTime = ExtendedSurvivalSettings.Instance?.Decay.CycleTick ?? 600000;
                        var damageTime = ExtendedSurvivalSettings.Instance?.Decay.DamageCycleTick ?? 10000;
                        var maxRunToCheckDecay = decayTime / damageTime;
                        DecaySystemController.DoCycle(runCount < maxRunToCheckDecay);
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(damageTime);
                        else
                            break;
                        if (runCount >= maxRunToCheckDecay)
                        {
                            runCount = 0;
                        }
                        else
                        {
                            runCount++;
                        }
                    }
                });
            }
        }

        public bool FactionsLocked { get; set; } = false;

        public override void BeforeStart()
        {
            try
            {
                if (MyAPIGateway.Session.IsServer)
                {
                    RegisterWatcher();
                    SuperficialMiningController.InitShipDrillCollec();
                }
                ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"RegisterSecureMessageHandler EntityCallsMsgHandler");
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            base.BeforeStart();
        }

        private void EntityCallsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS || (fromServer && IsServer))
                    return;
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                long entityId = long.Parse(mCommandData.content[0]);
                var entity = MyEntities.GetEntityById(entityId);
                if (entity != null)
                {
                    var blockLogic = entity.GameLogic;
                    if (blockLogic != null)
                    {
                        var compositeLogic = blockLogic as MyCompositeGameLogicComponent;
                        if (compositeLogic != null)
                        {
                            blockLogic = compositeLogic.GetComponents().FirstOrDefault(x => x.GetType().Name.Contains(mCommandData.content[1]));
                        }
                        if (blockLogic != null)
                        {
                            var syncComponent = blockLogic as IMySyncDataComponent;
                            if (syncComponent != null)
                            {
                                var componentParamData = Encoding.Unicode.GetString(mCommandData.data);
                                var componentParams = MyAPIGateway.Utilities.SerializeFromXML<CommandExtraParams>(componentParamData);
                                if (fromServer)
                                    syncComponent.CallFromServer(mCommandData.content[2], componentParams);
                                else
                                    syncComponent.CallFromClient(steamId, mCommandData.content[2], componentParams);
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

        protected override void UnloadData()
        {
            if (MyAPIGateway.Session.IsServer)
            {
                canRun = false;
                task.Wait();
                taskFactions.Wait();
                taskStations.Wait();
                taskAsteroids.Wait();
                taskStones.Wait();
                Players?.Clear();
                Players = null;
                MyVisualScriptLogicProvider.PlayerConnected -= Players_PlayerConnected;
                MyVisualScriptLogicProvider.PlayerDisconnected -= Players_PlayerDisconnected;
                MyEntities.OnEntityAdd -= Entities_OnEntityAdd;
                MyEntities.OnEntityRemove -= Entities_OnEntityRemove;
                MyVisualScriptLogicProvider.ContractAccepted -= Contracts_ContractAccepted;
                MyVisualScriptLogicProvider.ContractAbandoned -= Contracts_ContractAbandoned;
                MyVisualScriptLogicProvider.ContractFailed -= Contracts_ContractFailed;
                MyVisualScriptLogicProvider.ContractFinished -= Contracts_ContractFinished;
                SuperficialMiningController.ClearShipDrillCollec();
            }
            MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
            base.UnloadData();
        }

        public void Players_PlayerConnected(long playerId)
        {
            UpdatePlayerList();
            StarSystemController.CreateGpsToPlayer(playerId);
            DecaySystemController.RegisterPlayerAction(playerId);
        }

        public void Players_PlayerDisconnected(long playerId)
        {
            UpdatePlayerList();
            DecaySystemController.RegisterPlayerAction(playerId);
        }

        public void UpdatePlayerList()
        {
            Players.Clear();
            var tempPlayers = new List<IMyPlayer>();
            MyAPIGateway.Players.GetPlayers(tempPlayers);

            foreach (var p in tempPlayers)
            {
                if (p.IsValidPlayer())
                {
                    Players[p.IdentityId] = p;
                }
            }
        }

        public void RegisterWatcher()
        {

            ExtraStartLoot.Add(ItensConstants.SEMIAUTOPISTOL_ID, 1);
            ExtraStartLoot.Add(ItensConstants.PISTOL_SA_MAGZINE_ID, 30);

            MyEntities.SafeAreasSelectable = true;
            foreach (var entity in MyEntities.GetEntities())
            {
                if (entity as IMyCubeGrid != null)
                    GridsOnLoad.Add(entity as IMyCubeGrid);
                if (entity as MyPlanet != null)
                    PlanetsOnLoad.Add(entity as MyPlanet);
                Entities_OnEntityAdd(entity);
            }
            InicialLoadComplete = true;

            UpdatePlayerList();
            foreach (var playerId in Players.Keys)
            {
                DecaySystemController.RegisterPlayerAction(playerId);
            }
            lock (Grids)
            {
                foreach (var item in Grids.Where(x=>x.OwnerId.HasValue))
                {
                    ulong steamId = 0;
                    DecaySystemController.CreatePlayerInfoIfNotExits(item.OwnerId.Value, out steamId);
                }
            }

            MyVisualScriptLogicProvider.PlayerConnected += Players_PlayerConnected;
            MyVisualScriptLogicProvider.PlayerDisconnected += Players_PlayerDisconnected;

            MyEntities.OnEntityAdd += Entities_OnEntityAdd;
            MyEntities.OnEntityRemove += Entities_OnEntityRemove;

            MyVisualScriptLogicProvider.ContractAccepted += Contracts_ContractAccepted;
            MyVisualScriptLogicProvider.ContractAbandoned += Contracts_ContractAbandoned;
            MyVisualScriptLogicProvider.ContractFailed += Contracts_ContractFailed;
            MyVisualScriptLogicProvider.ContractFinished += Contracts_ContractFinished;

        }

        private void Contracts_ContractFinished(long contractId, MyDefinitionId contractDefinitionId, long acceptingPlayerId, bool isPlayerMade, long startingBlockId, long startingFactionId, long startingStationId)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                StarSystemStationAcquisitionContract contract;
                var station = ExtendedSurvivalStorage.Instance.StarSystem.GetByContractId(contractId, out contract);
                if (station != null)
                {
                    station.AcquisitionContracts.Remove(contract);
                }
            }
        }

        private void Contracts_ContractFailed(long contractId, MyDefinitionId contractDefinitionId, long acceptingPlayerId, bool isPlayerMade, long startingBlockId, long startingFactionId, long startingStationId, bool IsAbandon)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                StarSystemStationAcquisitionContract contract;
                var station = ExtendedSurvivalStorage.Instance.StarSystem.GetByContractId(contractId, out contract);
                if (station != null)
                {
                    station.AcquisitionContracts.Remove(contract);
                }
            }
        }

        private void Contracts_ContractAbandoned(long contractId, MyDefinitionId contractDefinitionId, long acceptingPlayerId, bool isPlayerMade, long startingBlockId, long startingFactionId, long startingStationId)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                StarSystemStationAcquisitionContract contract;
                var station = ExtendedSurvivalStorage.Instance.StarSystem.GetByContractId(contractId, out contract);
                if (station != null)
                {
                    contract.PlayerId = null;
                }
            }
        }

        private void  Contracts_ContractAccepted(long contractId, MyDefinitionId contractDefinitionId, long acceptingPlayerId, bool isPlayerMade, long startingBlockId, long startingFactionId, long startingStationId)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                StarSystemStationAcquisitionContract contract;
                var station = ExtendedSurvivalStorage.Instance.StarSystem.GetByContractId(contractId, out contract);
                if (station != null)
                {
                    contract.PlayerId = acceptingPlayerId;
                }
            }
        }

        private void Entities_OnEntityRemove(MyEntity entity)
        {
            var safeZone = entity as MySafeZone;
            if (safeZone != null && SafeZones.Any(x => x.EntityId == safeZone.EntityId))
            {
                lock (SafeZones)
                {
                    SafeZones.RemoveAll(x => x.EntityId == safeZone.EntityId);
                }
            }
            var cubeGrid = entity as IMyCubeGrid;
            if (cubeGrid != null && Grids.Any(x => x.Entity == cubeGrid))
            {
                lock (Grids)
                {
                    Grids.RemoveAll(x => x.Entity == cubeGrid);
                }
                return;
            }
            var planet = entity as MyPlanet;
            if (planet != null && Planets.ContainsKey(planet.EntityId))
            {
                lock (Planets)
                {
                    Planets.Remove(planet.EntityId);
                }
                return;
            }
            var voxelMap = entity as IMyVoxelMap;
            if (voxelMap != null && VoxelMaps.ContainsKey(voxelMap.EntityId))
            {
                lock (VoxelMaps)
                {
                    VoxelMaps.Remove(voxelMap.EntityId);
                }
                return;
            }
            var handheldGunObj = entity as IMyAutomaticRifleGun;
            if (handheldGunObj != null)
            {
                if (HandheldGuns.ContainsKey(handheldGunObj.EntityId))
                    HandheldGuns.Remove(handheldGunObj.EntityId);
            }
        }

        private void Entities_OnEntityAdd(MyEntity entity)
        {
            try
            {
                if (InicialLoadComplete)
                {
                    string entityName = entity.ToString();
                    if (WoodChopController.CheckEntityIsATree(entityName, entity))
                        return;
                    var floatingObj = entity as MyFloatingObject;
                    if (floatingObj != null)
                    {
                        SuperficialMiningController.CheckEntityIsAFloatingObject(floatingObj);
                    }
                }
                var meteor = entity as IMyMeteor;
                if (meteor != null)
                {
                    MeteorImpactController.CheckEntityCanGenerateStone(meteor);
                    return;
                }
                var safeZone = entity as MySafeZone;
                if (safeZone != null)
                {
                    lock (SafeZones)
                    {
                        SafeZones.Add(safeZone);
                    }
                    return;
                }
                var cubeGrid = entity as IMyCubeGrid;
                if (cubeGrid != null)
                {
                    var gridEntity = new GridEntity(cubeGrid);
                    lock (Grids)
                    {
                        Grids.Add(gridEntity);
                    }
                    if (InicialLoadComplete)
                    {
                        if (cubeGrid.IsRespawnGrid)
                        {
                            var playerId = cubeGrid.BigOwners.FirstOrDefault();
                            // Teleport Grid to Belt if Vanila Asteroid Disabled
                            if (MyAPIGateway.Session.SessionSettings.ProceduralDensity == 0 &&
                                ExtendedSurvivalStorage.Instance.StarSystem.Generated &&
                                ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt) &&
                                gridEntity.Entity.NaturalGravity == Vector3.Zero /* In Space */)
                            {
                                var targetBelt = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                var targetAsteroid = targetBelt.GetAsteroidStorage().AsteroidsData.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                var targetOrientations = new List<Vector3D>
                                {
                                    targetAsteroid.Position + (MatrixD.Identity.Up * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2))),
                                    targetAsteroid.Position + (MatrixD.Identity.Down * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2))),
                                    targetAsteroid.Position + (MatrixD.Identity.Left * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2))),
                                    targetAsteroid.Position + (MatrixD.Identity.Right * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2))),
                                    targetAsteroid.Position + (MatrixD.Identity.Forward * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2))),
                                    targetAsteroid.Position + (MatrixD.Identity.Backward * (targetAsteroid.Radius + (StarSystemController.SAFE_DISTANCE * 2)))
                                };
                                var startPos = targetOrientations[new Vector2I(0, 5).GetRandomInt()];
                                gridEntity.Entity.SetPosition(startPos);
                                gridEntity.TargetTeleportPosition = startPos;
                                gridEntity.NeedTeleport = true;
                            }
                            // Added extra start itens to main cargo
                            if (ExtraStartLoot.Any())
                            {
                                var terminalSystem = MyAPIGateway.TerminalActionsHelper.GetTerminalSystemForGrid(cubeGrid);
                                var cargoGroup = terminalSystem.GetBlockGroupWithName("Main Cargo");
                                if (cargoGroup != null)
                                {
                                    List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock>();
                                    cargoGroup.GetBlocksOfType<IMyCargoContainer>(blocks);
                                    if (blocks.Any())
                                    {
                                        var cargo = blocks.FirstOrDefault() as IMyCargoContainer;
                                        if (cargo != null)
                                        {
                                            var inventory = cargo.GetInventory();
                                            if (inventory != null)
                                            {
                                                foreach (var item in ExtraStartLoot)
                                                {
                                                    inventory.AddMaxItems(item.Value, ItensConstants.GetPhysicalObjectBuilder(item.Key));
                                                }
                                                if (ExtendedSurvivalStorage.Instance.StarSystem.Generated &&
                                                    ExtendedSurvivalSettings.Instance.StarSystemConfiguration.CreateDatapadInStartRover)
                                                {
                                                    var stations = ExtendedSurvivalStorage.Instance.StarSystem.GetAllStations();
                                                    if (stations.Any())
                                                    {
                                                        var targetPos = cubeGrid.GetPosition();
                                                        var stationPos = stations.OrderBy(x => Vector3D.Distance(x.Position, targetPos)).FirstOrDefault();
                                                        inventory.AddMaxItems(1f, ItensConstants.GetDatapadObjectBuilder(ItensConstants.DATAPAD_ID, stationPos.Name, stationPos.GetDatabadData()));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (WaterModAPI.Registered)
                            {
                                // Try to avoid spawn at water
                                float naturalGravityInterference;
                                var gridPos = cubeGrid.GetPosition();
                                var foward = cubeGrid.PositionComp.WorldMatrixRef.Forward;
                                Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(gridPos, out naturalGravityInterference);
                                if (naturalGravityInterference > 0)
                                {
                                    var neartPlanet = GetPlanetAtRange(gridPos);
                                    if (neartPlanet != null && WaterModAPI.HasWater(neartPlanet.Entity))
                                    {
                                        float baseMove = 1000;
                                        float extraMove = 100;
                                        var surfacePosition = neartPlanet.SurfaceAtPosition(gridPos);
                                        var baseDistance = Math.Max(Vector3D.Distance(surfacePosition, gridPos), 100);
                                        int i = 0;
                                        Vector3D upAtSurface = Vector3D.Zero;
                                        while (WaterModAPI.IsUnderwater(surfacePosition))
                                        {
                                            gridPos += baseMove * foward;
                                            surfacePosition = neartPlanet.SurfaceAtPosition(gridPos);
                                            upAtSurface = neartPlanet.UpAtPosition(surfacePosition);
                                            gridPos = surfacePosition + (baseDistance * upAtSurface);
                                            i++;
                                            if (i >= 40)
                                                break;
                                        }
                                        if (gridPos != cubeGrid.GetPosition())
                                        {
                                            /* Added a extra move */
                                            gridPos += extraMove * foward;
                                            surfacePosition = neartPlanet.SurfaceAtPosition(gridPos);
                                            upAtSurface = neartPlanet.UpAtPosition(surfacePosition);
                                            gridPos = surfacePosition + (baseDistance * upAtSurface);
                                            /* Set to teleport */
                                            gridEntity.TargetTeleport = MatrixD.CreateWorld(gridPos, foward, upAtSurface);
                                            gridEntity.NeedTeleport = true;
                                        }
                                    }
                                }
                            }
                        }
                        else if (DropContainersOverride.DropContainerPrefabs.Contains(gridEntity.Entity.DisplayName))
                        {
                            gridEntity.Entity.ChangeGridOwnership(0, MyOwnershipShareModeEnum.All);
                            if (gridEntity._blocksByType.ContainsKey(typeof(MyObjectBuilder_Parachute)))
                            {
                                foreach (var parachuteBlock in gridEntity._blocksByType[typeof(MyObjectBuilder_Parachute)])
                                {
                                    var parachuteInventory = parachuteBlock.FatBlock?.GetInventory();
                                    if (parachuteInventory != null)
                                    {
                                        var canvasAmount = parachuteInventory.GetItemAmount(ItensConstants.CANVAS_ID.DefinitionId);
                                        if (canvasAmount == 0)
                                        {
                                            if (gridEntity.Entity.GridSizeEnum == MyCubeSize.Large)
                                            {
                                                parachuteInventory.AddMaxItems(5f, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.CANVAS_ID));
                                            }
                                            else
                                            {
                                                parachuteInventory.AddMaxItems(1f, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.CANVAS_ID));
                                            }
                                        }
                                    }
                                }
                            }
                            if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.CreateDatapadInDropContainers)
                            {
                                if (MyUtils.GetRandomFloat(0, 1) < ExtendedSurvivalSettings.Instance.StarSystemConfiguration.DatapadChanceInDropContainers)
                                {
                                    if (gridEntity._blocksByType.ContainsKey(typeof(MyObjectBuilder_CargoContainer)))
                                    {
                                        var cargo = gridEntity._blocksByType[typeof(MyObjectBuilder_CargoContainer)].FirstOrDefault().FatBlock as IMyCargoContainer;
                                        if (cargo != null)
                                        {
                                            var inventory = cargo.GetInventory();
                                            if (inventory != null)
                                            {
                                                var stations = ExtendedSurvivalStorage.Instance.StarSystem.GetAllStations();
                                                if (stations.Any())
                                                {
                                                    var stationPos = stations.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                    if (gridEntity.Entity.NaturalGravity != Vector3.Zero)
                                                    {
                                                        if (GetRandomDouble() > 0.5d) /* 50% chance */
                                                        {
                                                            var planetInRange = GetPlanetAtRange(gridEntity.Entity.GetPosition());
                                                            if (planetInRange != null)
                                                            {
                                                                var planetMemberData = ExtendedSurvivalStorage.Instance.StarSystem.Members.FirstOrDefault(x => x.EntityId == planetInRange.Entity.EntityId);
                                                                if (planetMemberData != null)
                                                                {
                                                                    stationPos = planetMemberData.Stations.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    inventory.AddMaxItems(1f, ItensConstants.GetDatapadObjectBuilder(ItensConstants.DATAPAD_ID, stationPos.Name, stationPos.GetDatabadData()));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
                var planet = entity as MyPlanet;
                if (planet != null)
                {
                    lock (Planets)
                    {
                        var planetEntity = new PlanetEntity(planet);
                        Planets[planet.EntityId] = planetEntity;
                    }
                    return;
                }
                var voxelMap = entity as IMyVoxelMap;
                if (voxelMap != null)
                {
                    lock (VoxelMaps)
                    {
                        VoxelMaps[voxelMap.EntityId] = voxelMap;
                    }
                    return;
                }
                var handheldGunObj = entity as IMyAutomaticRifleGun;
                if (handheldGunObj != null)
                {
                    if (!HandheldGuns.ContainsKey(handheldGunObj.EntityId))
                    {
                        HandheldGuns[handheldGunObj.EntityId] = new HandheldGunEntity(handheldGunObj);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private static double GetRandomDouble(double max = 1f)
        {
            return MyUtils.GetRandomDouble(0f, max);
        }

        public HandheldGunEntity GetHandheldGun(long id)
        {
            if (HandheldGuns.ContainsKey(id))
                return HandheldGuns[id];
            return null;
        }

        public static PlanetEntity GetPlanetAtRange(Vector3D position)
        {
            return Instance.Planets.Values.OrderBy(x => Vector3D.Distance(position, x.Entity.PositionComp.GetPosition())).FirstOrDefault();
        }

        public static PlanetEntity GetPlanetById(long id)
        {
            if (Instance.Planets.ContainsKey(id))
                return Instance.Planets[id];
            return null;
        }

        public static GridEntity GetGridById(long id)
        {
            if (Instance.Grids.Any(x => x.Entity.EntityId == id))
                return Instance.Grids.FirstOrDefault(x => x.Entity.EntityId == id);
            return null;
        }

        public static MySafeZone GetSafeZoneById(long id)
        {
            if (Instance.SafeZones.Any(x => x.EntityId == id))
                return Instance.SafeZones.FirstOrDefault(x => x.EntityId == id);
            return null;
        }

        public GridEntity FirstGridInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            lock (Grids)
            {
                return Grids.FirstOrDefault(x =>
                    x.Entity != null &&
                    !ignoreList.Contains(x.Entity.EntityId) &&
                    Vector3D.Distance(x.Entity.GetPosition(), rPos) <= maxDistance
                );
            }
        }

        public bool AnyGridInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            return FirstGridInRange(rPos, maxDistance, ignoreList) != null;
        }

        public IMyPlayer FirstPlayerInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            lock (Players)
            {
                return Players.Values.FirstOrDefault(x =>
                    x.Character != null &&
                    !ignoreList.Contains(x.IdentityId) &&
                    Vector3D.Distance(x.Character.GetPosition(), rPos) <= maxDistance
                );
            }
        }

        public bool AnyPlayerInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            return FirstPlayerInRange(rPos, maxDistance, ignoreList) != null;
        }

        public bool AnyInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            return AnyPlayerInRange(rPos, maxDistance, ignoreList) || AnyGridInRange(rPos, maxDistance, ignoreList);
        }

        public IMyPlayer GetClosestPlayer(Vector3D rPos, MyPromoteLevel level = MyPromoteLevel.None)
        {
            double distanceSqd = double.MaxValue;
            IMyPlayer closest = null;

            foreach (var player in Players.Values.Where(x=> x.PromoteLevel >= level))
            {
                if (player?.Character == null || player.Character.IsDead)
                    continue;

                var d = Vector3D.Distance(player.Character.GetPosition(), rPos);
                if (d < distanceSqd)
                {
                    closest = player;
                    distanceSqd = d;
                }
            }

            return closest;
        }

        private void CheckFactions(bool force = false)
        {
            try
            {
                var factions = ExtendedSurvivalStorage.Instance.Factions.ToArray();
                var playerFacIds = MyAPIGateway.Session.Factions.Factions.Where(x => MyAPIGateway.Players.TryGetSteamId(x.Value.FounderId) != 0).Select(x => x.Key).ToArray();
                List<IMyIdentity> identities = new List<IMyIdentity>();
                MyAPIGateway.Players.GetAllIdentites(identities, x => MyAPIGateway.Players.TryGetSteamId(x.IdentityId) != 0);
                for (int i = 0; i < factions.Length; i++)
                {
                    var faction = factions[i];
                    if (faction != null)
                    {
                        var gameFaction = MyAPIGateway.Session.Factions.TryGetFactionById(faction.FactionId);
                        if (gameFaction != null)
                        {
                            if (!faction.FirstCheck)
                            {
                                // Set peace to others neutrals
                                var othersIds = factions.Where(x => x.FactionId != faction.FactionId).Select(x => x.FactionId).ToArray();
                                for (int j = 0; j < othersIds.Length; j++)
                                {   
                                    var targetFaction = MyAPIGateway.Session.Factions.TryGetFactionById(othersIds[j]);
                                    if (targetFaction != null)
                                    {
                                        var reputation = MyAPIGateway.Session.Factions.GetReputationBetweenFactions(gameFaction.FactionId, targetFaction.FactionId);
                                        if (reputation < 0)
                                            MyAPIGateway.Session.Factions.SetReputation(gameFaction.FactionId, targetFaction.FactionId, 0);
                                    }
                                }
                                faction.FirstCheck = true;
                            }
                            // Set peace to player factions not mapped
                            var notMappedPlayerFactions = playerFacIds.Where(x => force || !faction.FactionsMapped.Contains(x)).ToArray();
                            if (notMappedPlayerFactions.Any())
                            {
                                for (int j = 0; j < notMappedPlayerFactions.Length; j++)
                                {
                                    var targetFaction = MyAPIGateway.Session.Factions.TryGetFactionById(notMappedPlayerFactions[j]);
                                    if (targetFaction != null)
                                    {
                                        var reputation = MyAPIGateway.Session.Factions.GetReputationBetweenFactions(gameFaction.FactionId, targetFaction.FactionId);
                                        if (reputation < 0)
                                            MyAPIGateway.Session.Factions.SetReputation(gameFaction.FactionId, targetFaction.FactionId, 0);
                                        faction.FactionsMapped.Add(notMappedPlayerFactions[j]);
                                    }
                                }
                            }
                            // Set peace to players not mapped
                            var notMappedPlayers = identities.Where(x => force || !faction.PlayersMapped.Contains(x.IdentityId)).ToArray();
                            if (notMappedPlayers.Any())
                            {
                                for (int j = 0; j < notMappedPlayers.Length; j++)
                                {
                                    var reputation = MyAPIGateway.Session.Factions.GetReputationBetweenPlayerAndFaction(notMappedPlayers[j].IdentityId, gameFaction.FactionId);
                                    if (reputation < 0)
                                        MyAPIGateway.Session.Factions.SetReputationBetweenPlayerAndFaction(notMappedPlayers[j].IdentityId, gameFaction.FactionId, 0);
                                    faction.PlayersMapped.Add(notMappedPlayers[j].IdentityId);
                                }
                            }
                        }
                    }
                }
                if (force)
                {
                    if (ExtendedSurvivalSettings.Instance.Combat.ForceEnemyToFactions)
                    {
                        var tags = ExtendedSurvivalSettings.Instance.Combat.TargetEnemyFactions.Split(';');
                        for (int i = 0; i < tags.Length; i++)
                        {
                            ForceRepotationToFactionByTag(playerFacIds, identities, tags[i], -1000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ForceRepotationToFactionByTag(long[] playerFacIds, List<IMyIdentity> identities, string targetTag, int targetReputation)
        {
            var SprtFaction = MyAPIGateway.Session.Factions.TryGetFactionByTag(targetTag);
            if (SprtFaction != null)
            {
                for (int j = 0; j < playerFacIds.Length; j++)
                {
                    var reputation = MyAPIGateway.Session.Factions.GetReputationBetweenFactions(playerFacIds[j], SprtFaction.FactionId);
                    if (reputation != targetReputation)
                        MyAPIGateway.Session.Factions.SetReputation(playerFacIds[j], SprtFaction.FactionId, targetReputation);
                }
                for (int j = 0; j < identities.Count; j++)
                {
                    var reputation = MyAPIGateway.Session.Factions.GetReputationBetweenPlayerAndFaction(identities[j].IdentityId, SprtFaction.FactionId);
                    if (reputation != targetReputation)
                        MyAPIGateway.Session.Factions.SetReputationBetweenPlayerAndFaction(identities[j].IdentityId, SprtFaction.FactionId, targetReputation);
                }
            }
        }

        private long _lastCheckMeteorStones;
        private void CheckMeteorStones()
        {
            try
            {
                var timePass = MyExtendedSurvivalTimeManager.Instance.GameTime - _lastCheckMeteorStones;
                _lastCheckMeteorStones = MyExtendedSurvivalTimeManager.Instance.GameTime;
                if (ExtendedSurvivalStorage.Instance != null && ExtendedSurvivalStorage.Instance.StarSystem.Generated)
                {
                    foreach (var stone in ExtendedSurvivalStorage.Instance.MeteorImpact.Stones)
                    {
                        stone.Life -= timePass;
                    }
                    if (ExtendedSurvivalStorage.Instance.MeteorImpact.Stones.Any(x => x.Life <= 0))
                    {
                        var lista = ExtendedSurvivalStorage.Instance.MeteorImpact.Stones.Where(x => x.Life <= 0).ToList();
                        foreach (var stone in lista)
                        {
                            var remove = true;
                            var stoneEntity = VoxelMaps.ContainsKey(stone.EntityId) ? VoxelMaps[stone.EntityId] : null;
                            if (stoneEntity != null)
                            {
                                if (AnyInRange(stoneEntity.PositionComp.GetPosition(), SpaceStationController.SPAWN_DISTANCE))
                                {
                                    remove = false;
                                    stone.Life = ExtendedSurvivalSettings.Instance.MeteorImpact.StoneLifeTime * 1000;
                                }
                            }
                            if (remove)
                            {
                                ExtendedSurvivalStorage.Instance.MeteorImpact.Stones.Remove(stone);
                                if (stoneEntity != null)
                                    stoneEntity.Close();
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

        private void CheckTradeStations()
        {
            try
            {
                if (ExtendedSurvivalStorage.Instance != null && ExtendedSurvivalStorage.Instance.StarSystem.Generated)
                {
                    var stations = ExtendedSurvivalStorage.Instance.StarSystem.GetStations();
                    if (stations.Any())
                    {
                        for (int i = 0; i < stations.Length; i++)
                        {
                            if (stations[i].ComercialTick != ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick)
                            {
                                SpaceStationController.DoBuildShopItens(stations[i]);
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

        private void CheckAllGrids()
        {
            try
            {
                GridEntity[] lista;
                lock (Grids)
                {
                    lista = Grids.Where(x => x.NeedToRecreateWhells).ToArray();
                }
                for (int j = 0; j < lista.Length; j++)
                {
                    var gridEntity = lista[j];
                    var playerId = gridEntity.Entity.BigOwners.FirstOrDefault();
                    gridEntity.NeedToRecreateWhells = false;
                    gridEntity.Entity.Physics.ClearSpeed();
                    if (gridEntity.MotorSuspensions.Any())
                    {
                        for (int i = 0; i < gridEntity.MotorSuspensions.Count; i++)
                        {
                            var motorSuspension = gridEntity.MotorSuspensions[i].FatBlock as IMyMotorSuspension;
                            if (motorSuspension != null)
                            {
                                int c = 0;
                                while (!motorSuspension.IsAttached || c == 10)
                                {
                                    var actions = new List<Sandbox.ModAPI.Interfaces.ITerminalAction>();
                                    motorSuspension.GetActions(actions, (action) => { return action.Id == "Add Top Part"; });
                                    if (actions.Any())
                                    {
                                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                                        {
                                            actions.FirstOrDefault().Apply(motorSuspension);
                                        });
                                    }
                                    else
                                        c = 10;
                                    MyAPIGateway.Parallel.Sleep(25);
                                    c++;
                                }
                                if (motorSuspension.IsAttached)
                                {
                                    motorSuspension.Top.SlimBlock.IncreaseMountLevel(motorSuspension.Top.SlimBlock.MaxIntegrity, playerId);
                                }
                            }
                        }
                    }
                }
                lock (Grids)
                {
                    lista = Grids.Where(x => x.HasBlocksToApplySkin).ToArray();
                }
                for (int i = 0; i < lista.Length; i++)
                {
                    lista[i].ApllySkins();
                }
                if (WaterModAPI.Registered && ExtendedSurvivalSettings.Instance.DisableWaterModFreeIce)
                {
                    /* Need to stop collector from generate ICE, this function break the water solidificator */
                    lock (Grids)
                    {
                        lista = Grids.Where(x => x.HasNotInitilizedCollectors).ToArray();
                    }
                    for (int i = 0; i < lista.Length; i++)
                    {
                        var grid = lista[i];
                        while (grid.NotInitilizedCollectors.Count > 0)
                        {
                            var item = grid.NotInitilizedCollectors[0];
                            DoDisableLoginComponent(item, "WaterCollectorComponent");                            
                            grid.NotInitilizedCollectors.Remove(item);
                        }
                    }
                }
                lock (Grids)
                {
                    lista = Grids.Where(x => x.HasNotInitilizedTreadmill).ToArray();
                }
                for (int i = 0; i < lista.Length; i++)
                {
                    var grid = lista[i];
                    while (grid.NotInitilizedTreadmill.Count > 0)
                    {
                        var item = grid.NotInitilizedTreadmill[0];
                        DoDisableLoginComponent(item, "Treadmill");
                        grid.NotInitilizedTreadmill.Remove(item);
                    }
                }
                lock (Grids)
                {
                    lista = Grids.Where(x => x.NeedTeleport).ToArray();
                }
                for (int i = 0; i < lista.Length; i++)
                {
                    var grid = lista[i];
                    if (!grid.TargetTeleport.HasValue)
                    {
                        var startPos = grid.TargetTeleportPosition;
                        var startUp = Vector3D.Normalize(startPos - Vector3D.One);
                        var startRandomForward = StarSystemController.RandomPerpendicular(startUp);
                        grid.TargetTeleport = MatrixD.CreateWorld(startPos, startRandomForward, startUp);
                    }
                    if (grid.MotorSuspensions.Any())
                    {
                        for (int j = 0; j < grid.MotorSuspensions.Count; j++)
                        {
                            var motorSuspension = grid.MotorSuspensions[j].FatBlock as IMyMotorSuspension;
                            if (motorSuspension.IsAttached)
                            {
                                motorSuspension.TopGrid.Close();
                            }
                        }
                        grid.NeedToRecreateWhells = true;
                    }
                    StarSystemController.InvokeOnGameThread(() =>
                    {
                        grid.Entity.Teleport(grid.TargetTeleport.Value);
                    });
                    grid.NeedTeleport = false;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        public void DoRunDecay()
        {
            try
            {
                GridEntity[] lista;
                lock (Grids)
                {
                    lista = Grids.Where(x => x.NeedToDecay).ToArray();
                }
                for (int i = 0; i < lista.Length; i++)
                {
                    lista[i].Decay();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void DoDisableLoginComponent(IMySlimBlock item, string logicName)
        {
            ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"FatBlock={item.FatBlock} LogicToDisable={logicName}");
            if (item.FatBlock != null)
            {
                var blockLogic = item.FatBlock.GameLogic;
                var compositeLogic = blockLogic as MyCompositeGameLogicComponent;
                if (compositeLogic != null)
                {
                    if (compositeLogic.GetComponents().Any(x => x.GetType().Name.Contains(logicName)))
                    {
                        blockLogic = compositeLogic.GetComponents().FirstOrDefault(x => x.GetType().Name.Contains(logicName));
                        if (blockLogic != null)
                        {
                            var collectorLogicComponent = blockLogic as MyGameLogicComponent;
                            collectorLogicComponent.NeedsUpdate = MyEntityUpdateEnum.NONE;
                            compositeLogic.Remove(collectorLogicComponent);
                        }
                    }
                }
                else if (blockLogic != null && blockLogic.GetType().Name.Contains(logicName))
                {
                    var collectorLogicComponent = blockLogic as MyGameLogicComponent;
                    collectorLogicComponent.NeedsUpdate = MyEntityUpdateEnum.NONE;
                }
                else
                {
                    foreach (var component in item.FatBlock.Components)
                    {
                        if (component.GetType().Name.Contains(logicName))
                        {
                            var collectorLogicComponent = component as MyGameLogicComponent;
                            collectorLogicComponent.NeedsUpdate = MyEntityUpdateEnum.NONE;
                            break;
                        }
                    }
                }
            }
        }

        public bool HasPlanets()
        {
            return Planets.Count > 0;
        }

        public void ClearAllPlanets()
        {
            foreach (var key in Planets.Keys.ToArray())
            {
                Planets[key].Entity.Close();
            }
        }

        public bool NameHasPrefix(string name, params string[] validPrefix)
        {
            foreach (var prefix in validPrefix)
            {
                if (name.StartsWith(prefix) || name.StartsWith("[" + prefix + "]"))
                    return true;
            }
            return false;
        }

        private string GetPlayerDisplayName(long playerId)
        {
            if (Players.ContainsKey(playerId))
                return Players[playerId].DisplayName;
            var lista = new List<IMyIdentity>();
            MyAPIGateway.Players.GetAllIdentites(lista, x => x.IdentityId == playerId);
            if (lista.Any())
                return lista[0].DisplayName;
            return null;
        }

        public bool IsGridNameOk(GridEntity grid)
        {
            var ownerId = grid.Entity.BigOwners.Any() ? grid.Entity.BigOwners[0] : 0;
            var ownerSteamId = MyAPIGateway.Players.TryGetSteamId(ownerId);
            if (ownerSteamId != 0)
            {
                var faction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                var playerName = GetPlayerDisplayName(ownerId);
                var prefixs = new List<string>();
                if (!string.IsNullOrEmpty(playerName))
                    prefixs.Add(playerName);
                if (faction != null)
                    prefixs.Add(faction.Tag);
                return NameHasPrefix(grid.Entity.CustomName, prefixs.ToArray());
            }
            return true;
        }

        private string[] SHAME_NAMES = new string[]
        {
            "Charlotte",
            "Scotch",
            "Downy",
            "Coke",
            "Scrooge McDuck",
            "Una",
            "Bentina Beakley",
            "Quacker",
            "Jelly Bean",
            "Ferdinand",
            "Fenton Crackshell",
            "Jasmine",
            "Budweiser",
            "Runner",
            "Lilac",
            "Foie Gras",
            "Submarine",
            "Bubba",
            "Flapper",
            "Hubert",
            "Plucker",
            "Penny",
            "Daisy Duck",
            "Kennedy",
            "Feathers",
            "Launchpad McQuack",
            "Caesar",
            "Scrooge McDuck",
            "Blubber",
            "Peso",
            "Yolanda",
            "Count Duckula",
            "Webster",
            "Popcorn",
            "Bubbles",
            "Pocoyo",
            "Captain",
            "Cookie",
            "Snowflake",
            "Beatrice",
            "Daphne Duck",
            "Colonel",
            "Coke",
            "Jelly Bean",
            "Submarine",
            "Marigold",
            "Float",
            "Fowl Play",
            "Duckbeak",
            "Della Duck"
        };

        public bool RenameAllPlayerGrids()
        {
            try
            {
                UpdatePlayerList();
                GridEntity[] lista;
                lock (Grids)
                {
                    lista = Grids.Where(x => !IsGridNameOk(x)).ToArray();
                }
                if (lista.Any())
                {
                    for (int i = 0; i < lista.Length; i++)
                    {
                        var grid = lista[i];
                        var ownerId = grid.Entity.BigOwners.Any() ? grid.Entity.BigOwners[0] : 0;
                        var faction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(ownerId);
                        var playerName = GetPlayerDisplayName(ownerId);
                        var prefix = faction != null ? faction.Tag : playerName;
                        if (!string.IsNullOrEmpty(prefix))
                        {
                            var name = SHAME_NAMES.OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                            grid.Entity.CustomName = $"[{prefix}] - {name}";
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return false;
        }

        public class AmmoBasicData
        {
            public float DesiredSpeed { get; set; }
            public float BackkickForce { get; set; }
            public float MaxTrajectory { get; set; }
            public bool IsExplosive { get; set; }
            public float ExplosiveDamageMultiplier { get; set; }
        }

        public interface IAmmoData
        {

            bool IsMissile();

        }

        public class MissileAmmoData : IAmmoData
        {

            public float MissileMass { get; set; }
            public float MissileExplosionRadius { get; set; }
            public float MissileAcceleration { get; set; }
            public float MissileInitialSpeed { get; set; }
            public bool MissileSkipAcceleration { get; set; }
            public float MissileExplosionDamage { get; set; }
            public float MissileHealthPool { get; set; }
            public bool MissileGravityEnabled { get; set; }
            public Vector2 MissileRicochetAngle { get; set; }
            public float MissileRicochetDamage { get; set; }
            public Vector2 MissileRicochetChance { get; set; }

            public bool IsMissile()
            {
                return true;
            }

        }

        public class AmmoData : IAmmoData
        {

            public float ProjectileMassDamage { get; set; }
            public float ProjectileHealthDamage { get; set; }
            public float ProjectileHeadShotDamage { get; set; }
            public float ProjectileHitImpulse { get; set; }

            public bool IsMissile()
            {
                return false;
            }

        }

        public interface IBasicAmmoInfo
        {

            AmmoBasicData BasicData { get; set; }
            IAmmoData GetAmmoData();

        }

        public abstract class BasicAmmoInfo<T> : IBasicAmmoInfo where T : IAmmoData
        {
            public AmmoBasicData BasicData { get; set; }
            public T Data { get; set; }

            public IAmmoData GetAmmoData()
            {
                return Data;
            }
        }

        public class MissileAmmoInfo : BasicAmmoInfo<MissileAmmoData>
        {

        }

        public class AmmoInfo : BasicAmmoInfo<AmmoData>
        {

        }

        public class AmmoMagazineInfo
        {

            public int Capacity { get; set; }
            public MyDefinitionId AmmoDefinitionId { get; set; }
            public string DisplayName { get; set; }
            public float Mass { get; set; }
            public float Volume { get; set; }

            public IBasicAmmoInfo AmmoInfo
            {
                get
                {
                    if (KINECT_AMMOS.ContainsKey(AmmoDefinitionId))
                        return KINECT_AMMOS[AmmoDefinitionId];
                    if (MISSILE_AMMOS.ContainsKey(AmmoDefinitionId))
                        return MISSILE_AMMOS[AmmoDefinitionId];
                    return null;
                }
            }

        }

        public class WeaponBasicData
        {

            public float DeviateShotAngle { get; set; }
            public float DeviateShotAngleAiming { get; set; }
            public int ReloadTime { get; set; }
            public int ShotDelay { get; set; }
            public float ReleaseTimeAfterFire { get; set; }
            public float DamageMultiplier { get; set; } = 1;
            public float RangeMultiplier { get; set; } = 1;
            public int RateOfFire { get; set; }
            public int ShotsInBurst { get; set; }

        }

        public class WeaponInfo
        {

            public MyDefinitionId[] ValidAmmos { get; set; }
            public WeaponBasicData BasicData { get; set; }

        }

        public class WeaponBlockInfo
        {

            public MyDefinitionId BlockId { get; set; }
            public string DisplayName { get; set; }
            public MyDefinitionId WeaponDefinitionId { get; set; }
            public MyDefinitionId AmmoId { get; set; }
            public MyCubeSize CubeSize { get; set; }
            public bool IsTurret { get; set; }
            public float MaxRangeMeters { get; set; }

            public float Dps
            {
                get
                {
                    if (AmmoMagazineInfo.AmmoInfo.GetAmmoData().IsMissile())
                    {
                        var info = AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo;
                        var rateOfFire = Math.Max(Math.Min(WeaponInfo.BasicData.RateOfFire, 500) * 10, Math.Max(WeaponInfo.BasicData.ReloadTime, Math.Max(WeaponInfo.BasicData.ShotDelay, WeaponInfo.BasicData.ReleaseTimeAfterFire)));
                        return ((info.Data.MissileInitialSpeed + info.BasicData.DesiredSpeed) / 2) *
                            (info.BasicData.MaxTrajectory * WeaponInfo.BasicData.RangeMultiplier / 1000f) *
                            info.Data.MissileMass *
                            (1 + (Math.Max(info.Data.MissileExplosionRadius, 1) * Math.Max(info.Data.MissileExplosionDamage, 1) * info.BasicData.ExplosiveDamageMultiplier / 1000)) /
                            (1 + WeaponInfo.BasicData.DeviateShotAngle) *
                            WeaponInfo.BasicData.DamageMultiplier /
                            (rateOfFire / 1000f) *
                            (1 + (WeaponInfo.BasicData.ShotsInBurst / 10)) *
                            (1 + (info.Data.MissileRicochetDamage / 10000)) *
                            (1 + (MaxRangeMeters / 100000));
                    }
                    else
                    {
                        var delayFire = Math.Max(Math.Max(WeaponInfo.BasicData.ReloadTime, Math.Max(WeaponInfo.BasicData.ShotDelay, WeaponInfo.BasicData.ReleaseTimeAfterFire * 10)), 1);
                        var info = AmmoMagazineInfo.AmmoInfo as AmmoInfo;
                        return (((float)WeaponInfo.BasicData.RateOfFire) / 1000f) *
                            (info.BasicData.DesiredSpeed / 100f) *
                            (info.BasicData.MaxTrajectory * WeaponInfo.BasicData.RangeMultiplier / 1000f) *
                            info.Data.ProjectileMassDamage /
                            (1 + WeaponInfo.BasicData.DeviateShotAngle) *
                            WeaponInfo.BasicData.DamageMultiplier /
                            (1 + (delayFire / 10000f)) *
                            (1 + (WeaponInfo.BasicData.ShotsInBurst / 1000)) *
                            (1 + (MaxRangeMeters / 100000));
                    }
                }
            }

            public WeaponInfo WeaponInfo
            {
                get
                {
                    if (WEAPONS.ContainsKey(WeaponDefinitionId))
                        return WEAPONS[WeaponDefinitionId];
                    return null;
                }
            }

            public AmmoMagazineInfo AmmoMagazineInfo
            {
                get
                {
                    if (MAGAZINES.ContainsKey(AmmoId))
                        return MAGAZINES[AmmoId];
                    return null;
                }
            }

        }

        private static bool WeaponsDefsLoaded = false;
        public static List<WeaponBlockInfo> WEAPONS_BLOCKS = new List<WeaponBlockInfo>();
        public static ConcurrentDictionary<MyDefinitionId, WeaponInfo> WEAPONS = new ConcurrentDictionary<MyDefinitionId, WeaponInfo>();
        public static ConcurrentDictionary<MyDefinitionId, AmmoMagazineInfo> MAGAZINES = new ConcurrentDictionary<MyDefinitionId, AmmoMagazineInfo>();
        public static ConcurrentDictionary<MyDefinitionId, AmmoInfo> KINECT_AMMOS = new ConcurrentDictionary<MyDefinitionId, AmmoInfo>();
        public static ConcurrentDictionary<MyDefinitionId, MissileAmmoInfo> MISSILE_AMMOS = new ConcurrentDictionary<MyDefinitionId, MissileAmmoInfo>();

        private static void LoadAmmoDef(MyDefinitionId ammoDefinitionId)
        {
            try
            {
                if (!KINECT_AMMOS.ContainsKey(ammoDefinitionId) && !MISSILE_AMMOS.ContainsKey(ammoDefinitionId))
                {
                    var aDef = MyDefinitionManager.Static.GetAmmoDefinition(ammoDefinitionId);
                    if (aDef != null)
                    {
                        var pAmmoDef = aDef as MyProjectileAmmoDefinition;
                        if (pAmmoDef != null)
                        {
                            KINECT_AMMOS[pAmmoDef.Id] = new AmmoInfo()
                            {
                                BasicData = new AmmoBasicData()
                                {
                                    BackkickForce = pAmmoDef.BackkickForce,
                                    DesiredSpeed = pAmmoDef.DesiredSpeed,
                                    ExplosiveDamageMultiplier = pAmmoDef.ExplosiveDamageMultiplier,
                                    IsExplosive = pAmmoDef.IsExplosive,
                                    MaxTrajectory = pAmmoDef.MaxTrajectory
                                },
                                Data = new AmmoData()
                                {
                                    ProjectileMassDamage = pAmmoDef.ProjectileMassDamage,
                                    ProjectileHitImpulse = pAmmoDef.ProjectileHitImpulse,
                                    ProjectileHealthDamage = pAmmoDef.ProjectileHealthDamage,
                                    ProjectileHeadShotDamage = pAmmoDef.ProjectileHeadShotDamage
                                }
                            };
                        }
                        else
                        {
                            var mAmmoDef = aDef as MyMissileAmmoDefinition;
                            if (mAmmoDef != null)
                            {
                                MISSILE_AMMOS[mAmmoDef.Id] = new MissileAmmoInfo()
                                {
                                    BasicData = new AmmoBasicData()
                                    {
                                        BackkickForce = mAmmoDef.BackkickForce,
                                        DesiredSpeed = mAmmoDef.DesiredSpeed,
                                        ExplosiveDamageMultiplier = mAmmoDef.ExplosiveDamageMultiplier,
                                        IsExplosive = mAmmoDef.IsExplosive,
                                        MaxTrajectory = mAmmoDef.MaxTrajectory
                                    },
                                    Data = new MissileAmmoData()
                                    {
                                        MissileAcceleration = mAmmoDef.MissileAcceleration,
                                        MissileExplosionDamage = mAmmoDef.MissileExplosionDamage,
                                        MissileExplosionRadius = mAmmoDef.MissileExplosionRadius,
                                        MissileGravityEnabled = mAmmoDef.MissileGravityEnabled,
                                        MissileHealthPool = mAmmoDef.MissileHealthPool,
                                        MissileInitialSpeed = mAmmoDef.MissileInitialSpeed,
                                        MissileMass = mAmmoDef.MissileMass,
                                        MissileRicochetAngle = new Vector2(mAmmoDef.MissileMinRicochetAngle, mAmmoDef.MissileMaxRicochetAngle),
                                        MissileRicochetChance = new Vector2(mAmmoDef.MissileMinRicochetProbability, mAmmoDef.MissileMaxRicochetProbability),
                                        MissileRicochetDamage = mAmmoDef.MissileRicochetDamage,
                                        MissileSkipAcceleration = mAmmoDef.MissileSkipAcceleration
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void LoadMagazineDef(MyDefinitionId magazineDefinitionId)
        {
            try
            {
                if (!MAGAZINES.ContainsKey(magazineDefinitionId))
                {
                    var aDef = MyDefinitionManager.Static.GetAmmoMagazineDefinition(magazineDefinitionId);
                    if (aDef != null)
                    {
                        MAGAZINES[aDef.Id] = new AmmoMagazineInfo()
                        {
                            DisplayName = aDef.DisplayNameText,
                            Capacity = aDef.Capacity,
                            Mass = aDef.Mass,
                            Volume = aDef.Volume,
                            AmmoDefinitionId = aDef.AmmoDefinitionId
                        };
                        LoadAmmoDef(aDef.AmmoDefinitionId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void LoadWeaponDef(MyDefinitionId weaponDefinitionId)
        {
            try
            {
                if (!WEAPONS.ContainsKey(weaponDefinitionId))
                {
                    MyWeaponDefinition wDef = null;
                    if (MyDefinitionManager.Static.TryGetWeaponDefinition(weaponDefinitionId, out wDef))
                    {
                        if (wDef != null)
                        {
                            int rateOfFire = 0;
                            int shotsInBurst = 0;
                            if (wDef.WeaponAmmoDatas.Length >= 2)
                            {
                                if (wDef.WeaponAmmoDatas[0] != null)
                                {
                                    rateOfFire = wDef.WeaponAmmoDatas[0].RateOfFire;
                                    shotsInBurst = wDef.WeaponAmmoDatas[0].ShotsInBurst;
                                }
                                if (wDef.WeaponAmmoDatas[1] != null)
                                {
                                    rateOfFire = wDef.WeaponAmmoDatas[1].RateOfFire;
                                    shotsInBurst = wDef.WeaponAmmoDatas[1].ShotsInBurst;
                                }
                            }
                            WEAPONS[weaponDefinitionId] = new WeaponInfo()
                            {
                                BasicData = new WeaponBasicData()
                                {
                                    DeviateShotAngle = wDef.DeviateShotAngle,
                                    DeviateShotAngleAiming = wDef.DeviateShotAngleAiming,
                                    ReloadTime = wDef.ReloadTime,
                                    ShotDelay = wDef.ShotDelay,
                                    ReleaseTimeAfterFire = wDef.ReleaseTimeAfterFire,
                                    DamageMultiplier = wDef.DamageMultiplier,
                                    RangeMultiplier = wDef.RangeMultiplier,
                                    RateOfFire = rateOfFire,
                                    ShotsInBurst = shotsInBurst
                                },
                                ValidAmmos = wDef.AmmoMagazinesId
                            };
                            foreach (var ammoId in wDef.AmmoMagazinesId)
                            {
                                LoadMagazineDef(ammoId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void LoadWeaponsDefs()
        {
            try
            {
                WEAPONS_BLOCKS = new List<WeaponBlockInfo>();
                WEAPONS = new ConcurrentDictionary<MyDefinitionId, WeaponInfo>();
                MAGAZINES = new ConcurrentDictionary<MyDefinitionId, AmmoMagazineInfo>();
                KINECT_AMMOS = new ConcurrentDictionary<MyDefinitionId, AmmoInfo>();
                MISSILE_AMMOS = new ConcurrentDictionary<MyDefinitionId, MissileAmmoInfo>();
                var weaponBlocks = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Public && (x as MyWeaponBlockDefinition) != null).Select(x => x as MyWeaponBlockDefinition);
                foreach (var weaponBlock in weaponBlocks)
                {
                    LoadWeaponDef(weaponBlock.WeaponDefinitionId);
                    if (WEAPONS.ContainsKey(weaponBlock.WeaponDefinitionId))
                    {
                        foreach (var ammoId in WEAPONS[weaponBlock.WeaponDefinitionId].ValidAmmos)
                        {
                            var item = new WeaponBlockInfo()
                            {
                                BlockId = weaponBlock.Id,
                                DisplayName = weaponBlock.DisplayNameText,
                                AmmoId = ammoId,
                                WeaponDefinitionId = weaponBlock.WeaponDefinitionId,
                                CubeSize = weaponBlock.CubeSize
                            };
                            var turretDef = weaponBlock as MyLargeTurretBaseDefinition;
                            if (turretDef != null)
                            {
                                item.IsTurret = true;
                                item.MaxRangeMeters = turretDef.MaxRangeMeters;
                            }
                            WEAPONS_BLOCKS.Add(item);
                        }
                    }
                }
                WeaponsDefsLoaded = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetBlocksDefinitions()
        {
            try
            {
                var sb = new StringBuilder();
                var components = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Public && (x as MyCubeBlockDefinition) != null).Select(x => x as MyCubeBlockDefinition);
                sb.AppendLine($"Valid cube block:");
                var maxIdLenght = components.Max(block => block.Id.ToString().Length);
                var maxDisplayNameLenght = components.Max(block => block.DisplayNameText.Length);
                var cols = new string[]
                {
                    "Id".PadRight(maxIdLenght),
                    "Name".PadRight(maxDisplayNameLenght)
                };
                sb.AppendLine(string.Join(" | ", cols));
                foreach (var item in components.OrderBy(x => x.Id.ToString()))
                {
                    var values = new string[]
                    {
                        $"{item.Id}",
                        $"{item.DisplayNameText}"
                    };
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].PadRight(cols[i].Length);
                    }
                    sb.AppendLine(string.Join(" | ", values));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return null;
        }

        public string GetComponentsDefinitions()
        {
            try
            {
                var sb = new StringBuilder();
                var components = MyDefinitionManager.Static.GetAllDefinitions().Where(x => x.Public && (x as MyComponentDefinition) != null).Select(x => x as MyComponentDefinition);
                sb.AppendLine($"Valid components:");
                var maxIdLenght = components.Max(block => block.Id.SubtypeName.ToString().Length);
                var maxDisplayNameLenght = components.Max(block => block.DisplayNameText.Length);
                var cols = new string[]
                {
                    "Id".PadRight(maxIdLenght),
                    "Name".PadRight(maxDisplayNameLenght)
                };
                sb.AppendLine(string.Join(" | ", cols));
                foreach (var item in components.OrderBy(x=>x.Id.SubtypeName))
                {
                    var values = new string[]
                    {
                        $"{item.Id.SubtypeName}",
                        $"{item.DisplayNameText}"
                    };
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].PadRight(cols[i].Length);
                    }
                    sb.AppendLine(string.Join(" | ", values));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return null;
        }

        public string GetWeaponsDefinitions()
        {
            try
            {
                if (!WeaponsDefsLoaded)
                    LoadWeaponsDefs();
                var blocks = WEAPONS_BLOCKS.GroupBy(x => x.AmmoMagazineInfo.AmmoInfo.GetAmmoData().IsMissile()).ToDictionary(
                    x => x.Key,
                    x => x.AsEnumerable()
                );
                var sb = new StringBuilder();
                if (blocks.ContainsKey(false))
                {
                    sb.AppendLine($"Projectile Weapon Blocks:");
                    var maxIdLenght = blocks[false].Max(block => block.BlockId.ToString().Length);
                    var maxDisplayNameLenght = blocks[false].Max(block => block.DisplayName.Length);
                    var maxDisplayMagLenght = blocks[false].Max(block => block.AmmoMagazineInfo.DisplayName.Length);
                    var cols = new string[]
                    {
                        "Block Id".PadRight(maxIdLenght),
                        "Name".PadRight(maxDisplayNameLenght),
                        "Magazine".PadRight(maxDisplayMagLenght),
                        "Block Size",
                        "Weapon Final Dps",
                        "Mass Damage",
                        "Health Damage",
                        "Head Damage",
                        "Rate Of Fire",
                        "Shots In Burst",
                        "Desired Speed",
                        "Max Trajectory",
                        "Ammo Capacity",
                        "Deviate Shot Angle",
                        "Deviate Shot Aiming",
                        "Reload Time",
                        "Shot Delay",
                        "Release Time",
                        "Damage Multiplier",
                        "Range Multiplier",
                        "Is Turret",
                        "AI Max Range"
                    };
                    sb.AppendLine(string.Join(" | ", cols));
                    foreach (var block in blocks[false].OrderBy(x => x.Dps))
                    {
                        var values = new string[]
                        {
                            $"{block.BlockId}",
                            $"{block.DisplayName}",
                            $"{block.AmmoMagazineInfo.DisplayName}",
                            $"{block.CubeSize}",
                            $"{block.Dps.ToString("#0.00")}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as AmmoInfo).Data.ProjectileMassDamage}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as AmmoInfo).Data.ProjectileHealthDamage}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as AmmoInfo).Data.ProjectileHeadShotDamage}",
                            $"{block.WeaponInfo.BasicData.RateOfFire}",
                            $"{block.WeaponInfo.BasicData.ShotsInBurst}",
                            $"{block.AmmoMagazineInfo.AmmoInfo.BasicData.DesiredSpeed}",
                            $"{block.AmmoMagazineInfo.AmmoInfo.BasicData.MaxTrajectory}",
                            $"{block.AmmoMagazineInfo.Capacity}",
                            $"{block.WeaponInfo.BasicData.DeviateShotAngle}",
                            $"{block.WeaponInfo.BasicData.DeviateShotAngleAiming}",
                            $"{block.WeaponInfo.BasicData.ReloadTime}",
                            $"{block.WeaponInfo.BasicData.ShotDelay}",
                            $"{block.WeaponInfo.BasicData.ReleaseTimeAfterFire}",
                            $"{block.WeaponInfo.BasicData.DamageMultiplier}",
                            $"{block.WeaponInfo.BasicData.RangeMultiplier}",
                            $"{block.IsTurret}",
                            $"{block.MaxRangeMeters}"
                        };
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = values[i].PadRight(cols[i].Length);
                        }
                        sb.AppendLine(string.Join(" | ", values));
                    }
                }
                if (blocks.ContainsKey(true))
                {
                    sb.AppendLine();
                    sb.AppendLine($"Missile Weapon Blocks:");
                    var maxIdLenght = blocks[false].Max(block => block.BlockId.ToString().Length);
                    var maxDisplayNameLenght = blocks[false].Max(block => block.DisplayName.Length);
                    var maxDisplayMagLenght = blocks[false].Max(block => block.AmmoMagazineInfo.DisplayName.Length);
                    var cols = new string[]
                    {
                        "Block Id".PadRight(maxIdLenght),
                        "Name".PadRight(maxDisplayNameLenght),
                        "Magazine".PadRight(maxDisplayMagLenght),
                        "Block Size",
                        "Weapon Final Dps",
                        "Missile Mass",
                        "Explosion Radius",
                        "Explosion Damage",
                        "Explosive Damage Multiplier",
                        "RicochetDamage",
                        "Initial Speed",
                        "Skip Acceleration",
                        "Acceleration",
                        "Rate Of Fire",
                        "Shots In Burst",
                        "Desired Speed",
                        "Max Trajectory",
                        "Ammo Capacity",
                        "Deviate Shot Angle",
                        "Deviate Shot Aiming",
                        "Reload Time",
                        "Shot Delay",
                        "Release Time",
                        "Damage Multiplier",
                        "Range Multiplier",                    
                        "HealthPool",
                        "GravityEnabled",
                        "Is Turret",
                        "AI Max Range"
                    };
                    sb.AppendLine(string.Join(" | ", cols));
                    foreach (var block in blocks[true].OrderBy(x => x.Dps))
                    {
                        var values = new string[]
                        {
                            $"{block.BlockId}",
                            $"{block.DisplayName}",
                            $"{block.AmmoMagazineInfo.DisplayName}",
                            $"{block.CubeSize}",
                            $"{block.Dps.ToString("#0.00")}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileMass}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileExplosionRadius}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileExplosionDamage}",
                            $"{block.AmmoMagazineInfo.AmmoInfo.BasicData.ExplosiveDamageMultiplier}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileRicochetDamage}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileInitialSpeed}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileSkipAcceleration}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileAcceleration}",
                            $"{block.WeaponInfo.BasicData.RateOfFire}",
                            $"{block.WeaponInfo.BasicData.ShotsInBurst}",
                            $"{block.AmmoMagazineInfo.AmmoInfo.BasicData.DesiredSpeed}",
                            $"{block.AmmoMagazineInfo.AmmoInfo.BasicData.MaxTrajectory}",
                            $"{block.AmmoMagazineInfo.Capacity}",
                            $"{block.WeaponInfo.BasicData.DeviateShotAngle}",
                            $"{block.WeaponInfo.BasicData.DeviateShotAngleAiming}",
                            $"{block.WeaponInfo.BasicData.ReloadTime}",
                            $"{block.WeaponInfo.BasicData.ShotDelay}",
                            $"{block.WeaponInfo.BasicData.ReleaseTimeAfterFire}",
                            $"{block.WeaponInfo.BasicData.DamageMultiplier}",
                            $"{block.WeaponInfo.BasicData.RangeMultiplier}",                        
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileHealthPool}",
                            $"{(block.AmmoMagazineInfo.AmmoInfo as MissileAmmoInfo).Data.MissileGravityEnabled}",
                            $"{block.IsTurret}",
                            $"{block.MaxRangeMeters}"
                        };
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = values[i].PadRight(cols[i].Length);
                        }
                        sb.AppendLine(string.Join(" | ", values));
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return null;
        }

    }

}