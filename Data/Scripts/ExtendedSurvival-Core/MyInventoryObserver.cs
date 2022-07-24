using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival
{

    public class MyInventoryObserver : IDisposable
    {

        public IMyEntity OwnerEntity { get; private set; }
        public MyInventory Inventory { get; private set; }

        public bool Debug { get; set; } = false;
        public bool SpoilEnabled { get; set; } = true;
        public bool ForceSpoil { get; set; } = false;
        public float SpoilMultiplier { get; set; } = 1.0f;

        public event Action<MyInventoryObserver, MyPhysicalInventoryItem, VRage.MyFixedPoint> OnContentsAdded;
        public event Action<MyInventoryObserver, MyPhysicalInventoryItem, VRage.MyFixedPoint> OnContentsRemoved;
        public event Action<MyInventoryObserver, MyPhysicalInventoryItem, VRage.MyFixedPoint> OnContentsChanged;

        private readonly ConcurrentDictionary<uint, MyItemExtraInfo> inventoryExtraInfo = new ConcurrentDictionary<uint, MyItemExtraInfo>();

        private UInt128 _observerId;
        public UInt128 ObserverId
        {
            get
            {
                return _observerId;
            }
        }

        private DateTime deltaTime = DateTime.Now;

        public MyItemExtraInfo GetExtraInfo(uint itemId)
        {
            if (inventoryExtraInfo.ContainsKey(itemId))
                return inventoryExtraInfo[itemId];
            return null;
        }

        public bool HasItem(UniqueEntityId id)
        {
            return Inventory.GetItemAmount(id.DefinitionId) > 0;
        }

        public MyItemExtraInfo GetExtraInfoByItemType(UniqueEntityId entityId)
        {
            if (inventoryExtraInfo.Any(x => x.Value.DefinitionId == entityId))
                return inventoryExtraInfo.FirstOrDefault(x => x.Value.DefinitionId == entityId).Value;
            return null;
        }

        public MyItemExtraInfo[] GetAllExtraInfoByItemType(UniqueEntityId entityId)
        {
            if (inventoryExtraInfo.Any(x => x.Value.DefinitionId == entityId))
                return inventoryExtraInfo.Where(x => x.Value.DefinitionId == entityId).Select(x => x.Value).ToArray();
            return null;
        }

        public MyItemExtraInfo[] GetExtraInfoByItemBuilderType(MyObjectBuilderType typeId, string subtype = "")
        {
            if (inventoryExtraInfo.Any(x => x.Value.DefinitionId.typeId == typeId))
                return inventoryExtraInfo.Where(x => x.Value.DefinitionId.typeId == typeId && (subtype == null || x.Value.DefinitionId.subtypeId.ToString().Contains(subtype))).Select(x => x.Value).ToArray();
            return null;
        }

        public MyItemExtraInfo[] GetExtraInfoByGasId(UniqueEntityId entityId)
        {
            if (inventoryExtraInfo.Any(x => x.Value.IsGasContainer && x.Value.GasDefinitionId == entityId))
                return inventoryExtraInfo.Where(x => x.Value.IsGasContainer && x.Value.GasDefinitionId == entityId).Select(x => x.Value).ToArray();
            return null;
        }

        public MyItemExtraInfo[] GetAllExtraInfo()
        {
            if (inventoryExtraInfo.Any())
                return inventoryExtraInfo.Values.ToArray();
            return null;
        }

        public void ResetConservationTime(uint itemId)
        {
            if (inventoryExtraInfo.ContainsKey(itemId))
                inventoryExtraInfo[itemId].ResetConservationTime();
        }

        public MyInventoryObserver(MyInventory inventory, IMyEntity owner)
        {
            Inventory = inventory;
            OwnerEntity = owner;
            if (OwnerEntity != null && Inventory != null)
            {
                _observerId = new UInt128(OwnerEntity.EntityId, inventory.InventoryIdx);
                foreach (var item in Inventory.GetItems())
                {
                    inventoryExtraInfo[item.ItemId] = new MyItemExtraInfo(item);
                }
                Inventory.InventoryContentChanged += Inventory_InventoryContentChanged;
                MyInventoryObserverProgressController.AddMyInventoryObserver(this);
            }
        }

        private void Inventory_InventoryContentChanged(MyInventoryBase inventory, MyPhysicalInventoryItem item, VRage.MyFixedPoint ammount)
        {
            try
            {
                if (inventoryExtraInfo.ContainsKey(item.ItemId))
                {
                    //WHY KEEN? HOW CAN'T YOU KNOW HOW MUCH AMMOUNT CHANGE IN THE ITEM?
                    if (ammount == 0)
                    {
                        var newAmmount = (float)item.Amount;
                        ammount = (VRage.MyFixedPoint)(newAmmount - inventoryExtraInfo[item.ItemId].LastAmmount);
                    }
                    inventoryExtraInfo[item.ItemId].LastAmmount = (float)item.Amount;
                }
                else
                {
                    //WHY KEEN??? WHHYYYYY???!!!
                    if (ammount == 0)
                        ammount = item.Amount;
                }
                OnContentsChanged?.Invoke(this, item, ammount);
                if (ammount > 0)
                    Inventory_ContentsAdded(item, ammount);
                else if (ammount < 0)
                    Inventory_ContentsRemoved(item, ammount * -1);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected virtual void AfterContentsRemoved(MyPhysicalInventoryItem item, VRage.MyFixedPoint ammount)
        {

        }

        private void Inventory_ContentsRemoved(MyPhysicalInventoryItem item, VRage.MyFixedPoint ammount)
        {
            try
            {
                if (item.Amount <= 0)
                {
                    if (inventoryExtraInfo.ContainsKey(item.ItemId))
                    {
                        inventoryExtraInfo[item.ItemId].RemovedTime = DateTime.Now;
                        inventoryExtraInfo.Remove(item.ItemId);
                    }
                    OnContentsRemoved?.Invoke(this, item, ammount);
                    AfterContentsRemoved(item, ammount);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected virtual void AfterContentsAdded(MyPhysicalInventoryItem item, VRage.MyFixedPoint ammount)
        {

        }

        private void Inventory_ContentsAdded(MyPhysicalInventoryItem item, VRage.MyFixedPoint ammount)
        {
            try
            {
                if (!inventoryExtraInfo.ContainsKey(item.ItemId))
                {
                    inventoryExtraInfo[item.ItemId] = new MyItemExtraInfo(item);
                }
                OnContentsAdded?.Invoke(this, item, ammount);
                AfterContentsAdded(item, ammount);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        public void DoUpdate100()
        {
            try
            {
                var spendTime = DateTime.Now - deltaTime;
                deltaTime = DateTime.Now;
                var lista = inventoryExtraInfo.Where(x => x.Value.NeedUpdate).Select(x => x.Key).ToArray();
                foreach (var key in lista)
                {
                    inventoryExtraInfo[key].DoUpdate(this, spendTime);
                }
                OnAfterUpdate100(spendTime);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected virtual void OnAfterUpdate100(TimeSpan spendTime)
        {

        }

        public void Dispose()
        {
            MyInventoryObserverProgressController.RemoveBlocks(ObserverId);
        }

    }

}
