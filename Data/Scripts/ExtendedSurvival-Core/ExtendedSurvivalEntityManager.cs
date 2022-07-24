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

namespace ExtendedSurvival
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalEntityManager : BaseSessionComponent
    {

        public static ExtendedSurvivalEntityManager Instance { get; private set; }

        private static readonly Random rnd = new Random();

        public List<MyPlanet> PlanetsOnLoad { get; private set; } = new List<MyPlanet>();
        public List<IMyCubeGrid> GridsOnLoad { get; private set; } = new List<IMyCubeGrid>();
        public List<GridEntity> Grids { get; private set; } = new List<GridEntity>();
        public List<PlanetEntity> Planets { get; private set; } = new List<PlanetEntity>();
        public ConcurrentDictionary<long, IMyPlayer> Players { get; private set; } = new ConcurrentDictionary<long, IMyPlayer>();

        private bool inicialLoadComplete = false;

        public GridEntity GetGridByUuid(long uuid)
        {
            return Grids.FirstOrDefault(x => x.Entity.EntityId == uuid);
        }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                var task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalLogging.Instance.LogInfo(GetType(), "StartBackground [CheckAllGrids START]");
                    // Loop Task to Control Skins
                    while (true)
                    {
                        CheckAllGrids();
                        MyAPIGateway.Parallel.Sleep(250);
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
                    ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"RegisterSecureMessageHandler EntityCallsMsgHandler");
                    MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
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
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected override void UnloadData()
        {
            if (MyAPIGateway.Session.IsServer)
            {
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
            UpdatePlayerList();
        }

        public void Players_PlayerDisconnected(long playerId)
        {
            UpdatePlayerList();
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
                    Players[p.IdentityId] = p;
            }
        }

        public void RegisterWatcher()
        {

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
            if (planet != null && Planets.Any(x => x.Entity == planet))
            {
                lock (Planets)
                {
                    Planets.RemoveAll(x => x.Entity == planet);
                }
                return;
            }
        }

        private void Entities_OnEntityAdd(MyEntity entity)
        {
            var cubeGrid = entity as IMyCubeGrid;
            if (cubeGrid != null)
            {
                var gridEntity = new GridEntity(cubeGrid);
                lock (Grids)
                {
                    Grids.Add(gridEntity);
                }
                if (inicialLoadComplete && cubeGrid.IsRespawnGrid)
                {
                    var playerId = cubeGrid.BigOwners.FirstOrDefault();
                    if (WaterAPI.Registered)
                    {
                        // Maybe the wheels are gone xD hahaha
                        gridEntity.NeedToRecreateWhells = true;                        
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
                    Planets.Add(planetEntity);
                }
                return;
            }
        }

        public static PlanetEntity GetPlanetAtRange(Vector3D position)
        {
            return Instance.Planets.OrderBy(x => Vector3D.Distance(position, x.Entity.PositionComp.GetPosition())).FirstOrDefault();
        }

        public static PlanetEntity GetPlanetById(long id)
        {
            return Instance.Planets.FirstOrDefault(x => x.Entity.EntityId == id);
        }

        public IMyPlayer GetClosestPlayer(Vector3D rPos)
        {
            double distanceSqd = double.MaxValue;
            IMyPlayer closest = null;

            foreach (var player in Players.Values)
            {
                if (player?.Character == null || player.Character.IsDead)
                    continue;

                var d = Vector3D.DistanceSquared(player.Character.PositionComp.WorldAABB.Center, rPos);
                if (d < distanceSqd)
                {
                    closest = player;
                    distanceSqd = d;
                }
            }

            return closest;
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
                if (WaterAPI.Registered)
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
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void DoDisableLoginComponent(IMySlimBlock item, string logicName)
        {
            ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"FatBlock={item.FatBlock} LogicToDisable={logicName}");
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

    }

}