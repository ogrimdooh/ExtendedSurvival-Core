﻿using Sandbox.ModAPI;
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

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalEntityManager : BaseSessionComponent
    {

        public static Dictionary<UniqueEntityId, float> ExtraStartLoot { get; set; } = new Dictionary<UniqueEntityId, float>();
        public static ExtendedSurvivalEntityManager Instance { get; private set; }

        private static readonly Random rnd = new Random();

        public List<MyPlanet> PlanetsOnLoad { get; private set; } = new List<MyPlanet>();
        public List<IMyCubeGrid> GridsOnLoad { get; private set; } = new List<IMyCubeGrid>();
        public List<GridEntity> Grids { get; private set; } = new List<GridEntity>();
        public List<MySafeZone> SafeZones { get; private set; } = new List<MySafeZone>();
        public ConcurrentDictionary<long, IMyVoxelMap> VoxelMaps { get; private set; } = new ConcurrentDictionary<long, IMyVoxelMap>();
        public ConcurrentDictionary<long, PlanetEntity> Planets { get; private set; } = new ConcurrentDictionary<long, PlanetEntity>();
        public ConcurrentDictionary<long, HandheldGunEntity> HandheldGuns { get; private set; } = new ConcurrentDictionary<long, HandheldGunEntity>();
        public ConcurrentDictionary<long, IMyPlayer> Players { get; private set; } = new ConcurrentDictionary<long, IMyPlayer>();

        private bool inicialLoadComplete = false;

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
        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                canRun = true;
                task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "StartBackground [CheckAllGrids START]");
                    // Loop Task to Control Skins
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
                    // Loop Task to Control Skins
                    while (canRun)
                    {
                        SpaceStationController.DoCycle();
                        CheckTradeStations();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(1000);
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
                    // Loop Task to Control Skins
                    while (canRun)
                    {
                        CheckMeteorStones();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(10000);
                        else
                            break;
                    }
                });
            }
        }

        public override void BeforeStart()
        {
            try
            {
                Instance = this;
                if (MyAPIGateway.Session.IsServer)
                    RegisterWatcher();
                if (!IsServer)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"RegisterSecureMessageHandler EntityCallsMsgHandler");
                    MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
                }
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
                if (netId != ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS)
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
                                syncComponent.CallFromServer(mCommandData.content[2], componentParams);
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
                Players?.Clear();
                Players = null;
                MyVisualScriptLogicProvider.PlayerConnected -= Players_PlayerConnected;
                MyVisualScriptLogicProvider.PlayerDisconnected -= Players_PlayerDisconnected;
                MyEntities.OnEntityAdd -= Entities_OnEntityAdd;
                MyEntities.OnEntityRemove -= Entities_OnEntityRemove;
            }
            base.UnloadData();
        }

        public void Players_PlayerConnected(long playerId)
        {
            var tempPlayers = new List<IMyPlayer>();
            MyAPIGateway.Players.GetPlayers(tempPlayers, (p) => { return p.IdentityId == playerId; });
            if (tempPlayers.Any())
            {
                if (tempPlayers[0].IsValidPlayer())
                {

                    Players[playerId] = tempPlayers[0];
                }
            }
        }

        public void Players_PlayerDisconnected(long playerId)
        {
            if (Players.ContainsKey(playerId))
            {
                Players.Remove(playerId);
            }
        }

        public void UpdatePlayerList()
        {
            Players.Clear();
            var tempPlayers = new List<IMyPlayer>();
            MyAPIGateway.Players.GetPlayers(tempPlayers);

            foreach (var p in tempPlayers)
            {
                if (p?.Character == null || p.Character.IsDead)
                    continue;

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
            inicialLoadComplete = true;

            UpdatePlayerList();

            MyVisualScriptLogicProvider.PlayerConnected += Players_PlayerConnected;
            MyVisualScriptLogicProvider.PlayerDisconnected += Players_PlayerDisconnected;

            MyEntities.OnEntityAdd += Entities_OnEntityAdd;
            MyEntities.OnEntityRemove += Entities_OnEntityRemove;

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
                if (inicialLoadComplete)
                {
                    string entityName = entity.ToString();
                    if (WoodChopController.CheckEntityIsATree(entityName, entity))
                        return;
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
                    if (inicialLoadComplete)
                    {
                        if (cubeGrid.IsRespawnGrid)
                        {
                            var playerId = cubeGrid.BigOwners.FirstOrDefault();
                            if (WaterModAPI.Registered)
                            {
                                // Maybe the wheels are gone xD hahaha
                                gridEntity.NeedToRecreateWhells = true;
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
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (DropContainersOverride.DropContainerPrefabs.Contains(gridEntity.Entity.DisplayName))
                        {
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
                        HandheldGuns[handheldGunObj.EntityId].OnReload += ExtendedSurvivalEntityManager_OnReload;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ExtendedSurvivalEntityManager_OnReload(HandheldGunEntity sender, int currentAmmo, UniqueEntityId magzineId)
        {

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
            return Grids.FirstOrDefault(x => 
                x.Entity != null && 
                !ignoreList.Contains(x.Entity.EntityId) && 
                Vector3D.Distance(x.Entity.GetPosition(), rPos) <= maxDistance
            );
        }

        public bool AnyGridInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            return FirstGridInRange(rPos, maxDistance, ignoreList) != null;
        }

        public IMyPlayer FirstPlayerInRange(Vector3D rPos, float maxDistance, params long[] ignoreList)
        {
            return Players.Values.FirstOrDefault(x => 
                x.Character != null &&
                !ignoreList.Contains(x.IdentityId) &&
                Vector3D.Distance(x.Character.GetPosition(), rPos) <= maxDistance
            );
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

        private long _lastCheckMeteorStones;
        private void CheckMeteorStones()
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

        private void CheckTradeStations()
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

        private void CheckAllGrids()
        {
            try
            {
                GridEntity[] lista;
                lock (Grids)
                {
                    lista = Grids.Where(x => x.HasBlocksToApplySkin).ToArray(); Grids.Where(x => x.HasBlocksToApplySkin).ToArray();
                }
                for (int i = 0; i < lista.Length -1; i++)
                {
                    lista[i].ApllySkins();
                }
                lock (Grids)
                {
                    lista = Grids.Where(x => x.NeedToRecreateWhells).ToArray();
                }
                for (int j = 0; j < lista.Length - 1; j++)
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
                                    MyAPIGateway.Parallel.Sleep(250);
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

    }

}