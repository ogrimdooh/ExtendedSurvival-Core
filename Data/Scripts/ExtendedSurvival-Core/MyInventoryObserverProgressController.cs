using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Components;

namespace ExtendedSurvival
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class MyInventoryObserverProgressController : BaseSessionComponent
    {

        public class GasSpoilInfo
        {

            public float CicleTime { get; set; }
            public float DecayFactor { get; set; }
            public Func<Guid, bool> CanDecay { get; set; }

        }

        private static readonly Dictionary<string, GasSpoilInfo> MyGasSpoilInfos = new Dictionary<string, GasSpoilInfo>();
        private static readonly Dictionary<string, List<UniqueEntityId>> MyItemCategories = new Dictionary<string, List<UniqueEntityId>>();
        private static readonly Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPIBackend.ItemExtraInfo> MyItemExtraInfo = new Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPIBackend.ItemExtraInfo>();
        private static readonly Dictionary<UInt128, MyInventoryObserver> MyInventoryObservers = new Dictionary<UInt128, MyInventoryObserver>();

        public static MyInventoryObserverProgressController Instance { get; private set; }

        public static MyInventoryObserver GetById(UInt128 uuid)
        {
            if (MyInventoryObservers.ContainsKey(uuid))
                return MyInventoryObservers[uuid];
            return null;
        }

        public static void AddGasSpoilInfo(string gasSubtypeId, float cicleTime, float decayFactor, Func<Guid, bool> checkDelegate)
        {
            if (!MyGasSpoilInfos.ContainsKey(gasSubtypeId))
                MyGasSpoilInfos.Add(gasSubtypeId, new GasSpoilInfo() { CicleTime = cicleTime, DecayFactor = decayFactor, CanDecay = checkDelegate });
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

        public static void AddItemExtraInfo(ExtendedSurvivalCoreAPIBackend.ItemExtraInfo extraInfo)
        {
            var id = new UniqueEntityId(extraInfo.DefinitionId.TypeId, extraInfo.DefinitionId.SubtypeName);
            if (!MyItemExtraInfo.ContainsKey(id))
                MyItemExtraInfo.Add(id, extraInfo);
        }

        public static bool HasItemExtraInfo(UniqueEntityId id)
        {
            return MyItemExtraInfo.ContainsKey(id);
        }

        public static ExtendedSurvivalCoreAPIBackend.ItemExtraInfo GetItemExtraInfo(UniqueEntityId id)
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

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                Instance = this;
                var task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"StartBackground [DoUpdateCicle START]");
                    // Loop Task to Control Skins
                    while (true)
                    {
                        DoUpdateCicle();
                        MyAPIGateway.Parallel.Sleep(1000);
                    }
                });
            }
        }

        protected void DoUpdateCicle()
        {
            if (MyAPIGateway.Session.IsServer)
            {
                try
                {
                    var needToDelete = new List<UInt128>();
                    var keys = MyInventoryObservers.Keys.ToArray();
                    for (int i = 0; i < keys.Length; i++)
                    {
                        var item = MyInventoryObservers[keys[i]];
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
                    ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
                }
            }
        }
    }

}
