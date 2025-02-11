﻿using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Components;

namespace ExtendedSurvival.Core
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class MyInventoryObserverProgressController : BaseSessionComponent
    {

        public class GasSpoilInfo
        {

            public float CicleTime { get; set; }
            public float DecayFactor { get; set; }
            public long ToleranceTime { get; set; }
            public Func<Guid, bool> CanDecay { get; set; }

        }

        private static readonly Dictionary<string, GasSpoilInfo> MyGasSpoilInfos = new Dictionary<string, GasSpoilInfo>();
        private static readonly Dictionary<string, List<UniqueEntityId>> MyItemCategories = new Dictionary<string, List<UniqueEntityId>>();
        private static readonly Dictionary<UniqueEntityId, ItemExtraInfo> MyItemExtraInfo = new Dictionary<UniqueEntityId, ItemExtraInfo>();
        private static readonly Dictionary<UInt128, MyInventoryObserver> MyInventoryObservers = new Dictionary<UInt128, MyInventoryObserver>();

        public static MyInventoryObserverProgressController Instance { get; private set; }

        public static MyInventoryObserver Get(long entityId, int index)
        {
            return MyInventoryObservers.Values.FirstOrDefault(x => x.OwnerEntity.EntityId == entityId && x.Inventory.InventoryIdx == index);
        }

        public static MyInventoryObserver GetById(UInt128 uuid)
        {
            if (MyInventoryObservers.ContainsKey(uuid))
                return MyInventoryObservers[uuid];
            return null;
        }

        public static void AddGasSpoilInfo(string gasSubtypeId, float cicleTime, float decayFactor, long toleranceTime, Func<Guid, bool> checkDelegate)
        {
            if (!MyGasSpoilInfos.ContainsKey(gasSubtypeId))
                MyGasSpoilInfos.Add(gasSubtypeId, new GasSpoilInfo() { 
                    CicleTime = cicleTime, 
                    DecayFactor = decayFactor, 
                    CanDecay = checkDelegate,
                    ToleranceTime = toleranceTime
                });
        }

        public static bool HasGasSpoilInfo(string gasSubtypeId)
        {
            return MyGasSpoilInfos.ContainsKey(gasSubtypeId);
        }

        public static GasSpoilInfo GetGasSpoilInfo(string gasSubtypeId)
        {
            if (HasGasSpoilInfo(gasSubtypeId))
                return MyGasSpoilInfos[gasSubtypeId];
            return null;
        }

        public static void AddItemExtraInfo(ItemExtraInfo extraInfo)
        {
            var id = new UniqueEntityId(extraInfo.DefinitionId.TypeId, extraInfo.DefinitionId.SubtypeName);
            if (!MyItemExtraInfo.ContainsKey(id))
            {
                MyItemExtraInfo.Add(id, extraInfo);
                if (MyInventoryObservers.Values.Any(x => x.HasItem(id)))
                {
                    foreach (var item in MyInventoryObservers.Values.Where(x => x.HasItem(id)))
                    {
                        item.RefreshItemExtraInfo(id);
                    }
                }
            }
        }

        public static bool HasItemExtraInfo(UniqueEntityId id)
        {
            return MyItemExtraInfo.ContainsKey(id);
        }

        public static ItemExtraInfo GetItemExtraInfo(UniqueEntityId id)
        {
            if (HasItemExtraInfo(id))
                return MyItemExtraInfo[id];
            return null;
        }

        public static void AddCategory(string category)
        {
            if (!MyItemCategories.ContainsKey(category))
                MyItemCategories.Add(category, new List<UniqueEntityId>());
        }

        public static void AddItemToCategory(UniqueEntityId id, string category)
        {
            if (MyItemCategories.ContainsKey(category) && !MyItemCategories[category].Any(x => x == id))
                MyItemCategories[category].Add(id);
        }

        public static List<string> GetCategories(UniqueEntityId id)
        {
            return MyItemCategories.Where(x => x.Value.Contains(id)).Select(x => x.Key).ToList();
        }

        public static void AddMyInventoryObserver(MyInventoryObserver block)
        {
            var station = ExtendedSurvivalStorage.Instance.StarSystem.GetByCargoId(block.OwnerEntity.EntityId);
            if (station != null)
            {
                block.SpoilEnabled = false;
            }
            lock (MyInventoryObservers)
            {
                if (!MyInventoryObservers.ContainsKey(block.ObserverId))
                    MyInventoryObservers.Add(block.ObserverId, block);
            }
        }

        public static void RemoveBlocks(params UInt128[] keys)
        {
            lock (MyInventoryObservers)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (MyInventoryObservers.ContainsKey(keys[i]))
                        MyInventoryObservers.Remove(keys[i]);
                }
            }
        }

        protected bool canRun;
        protected ParallelTasks.Task task;
        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                Instance = this;
                canRun = true;
                task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"StartBackground [DoUpdateCicle START]");
                    // Loop Task to Control Skins
                    while (canRun)
                    {
                        DoUpdateCicle();
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(1000);
                        else
                            break;
                    }
                });
            }
        }

        protected override void UnloadData()
        {
            base.UnloadData();
            canRun = false;
            task.Wait();
        }

        protected void DoUpdateCicle()
        {
            if (MyAPIGateway.Session != null && MyAPIGateway.Session.IsServer)
            {
                try
                {
                    var needToDelete = new List<UInt128>();
                    UInt128[] keys;
                    lock (MyInventoryObservers)
                    {
                        keys = MyInventoryObservers.Keys.ToArray();
                    }
                    for (int i = 0; i < keys.Length; i++)
                    {
                        var item = MyInventoryObservers.ContainsKey(keys[i]) ? MyInventoryObservers[keys[i]] : null;
                        if (item != null && !item.OwnerEntity.Closed)
                        {
                            item.DoUpdate100();
                        }
                        else
                            needToDelete.Add(keys[i]);
                    }
                    if (needToDelete.Count > 0)
                        RemoveBlocks(needToDelete.ToArray());
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
            }
        }
    }

}
