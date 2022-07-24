﻿using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using VRage.Game.Entity;
using VRage.Game.ModAPI;

namespace ExtendedSurvival
{

    public sealed class MyItemExtraInfo
    {

        public uint ItemId { get; set; }
        public UniqueEntityId DefinitionId { get; set; }
        public TimeSpan ConservationTime { get; set; } = TimeSpan.Zero;
        public bool NeedUpdate { get; set; } = false;
        public bool NeedConservation { get; set; } = false;
        public DateTime? RemovedTime { get; set; }
        public bool IsGasContainer { get; set; }
        public UniqueEntityId GasDefinitionId { get; set; }
        public float LastAmmount { get; set; }
        public List<string> Categories { get; set; } = new List<string>();

        public ExtendedSurvivalCoreAPIBackend.ItemExtraInfo ExtraInfoDefinition
        {
            get
            {
                return GetExtraInfoDefinition();
            }
        }

        public MyItemExtraInfo(MyPhysicalInventoryItem item)
        {
            ItemId = item.ItemId;
            LastAmmount = (float)item.Amount;
            DefinitionId = new UniqueEntityId(item.Content.GetObjectId());
            Categories = MyInventoryObserverProgressController.GetCategories(DefinitionId);
            var gasContainer = item.Content as MyObjectBuilder_GasContainerObject;
            if (gasContainer != null)
            {
                IsGasContainer = true;
                var physicalItem = MyDefinitionManager.Static.GetPhysicalItemDefinition(gasContainer) as MyOxygenContainerDefinition;
                GasDefinitionId = new UniqueEntityId(physicalItem.StoredGasId);
            }
            LoadExtraInfoDefinition();
        }

        private bool HasExtraInfoDefinition()
        {
            return MyInventoryObserverProgressController.HasItemExtraInfo(DefinitionId);
        }

        private ExtendedSurvivalCoreAPIBackend.ItemExtraInfo GetExtraInfoDefinition()
        {
            if (HasExtraInfoDefinition())
                return MyInventoryObserverProgressController.GetItemExtraInfo(DefinitionId);
            return null;
        }

        private void LoadExtraInfoDefinition()
        {
            if (HasExtraInfoDefinition())
            {
                var extraInfo = GetExtraInfoDefinition();
                ConservationTime = extraInfo.StartConservationTime;
                NeedUpdate = extraInfo.NeedUpdate;
                NeedConservation = extraInfo.NeedConservation;
            }
        }

        public void ResetConservationTime()
        {
            if (NeedConservation && HasExtraInfoDefinition())
            {
                var extraInfo = GetExtraInfoDefinition();
                ConservationTime = extraInfo.StartConservationTime;
            }
        }

        private void DoSpoilRoutine(MyInventoryObserver observer)
        {
            MyAPIGateway.Utilities.InvokeOnGameThread(() =>
            {
                var extraInfo = GetExtraInfoDefinition();
                if (extraInfo.RemoveWhenSpoil)
                {
                    try
                    {
                        var item = (observer.Inventory as IMyInventory).GetItemByID(ItemId);
                        if (item != null)
                        {
                            observer.Inventory.Remove(item, (VRage.MyFixedPoint)extraInfo.RemoveAmmount);
                        }
                    }
                    catch (Exception ex)
                    {
                        ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
                    }
                }
                if (extraInfo.AddNewItemWhenSpoil)
                {
                    try
                    {
                        foreach (var item in extraInfo.AddDefinitionId)
                        {
                            var id = new UniqueEntityId(item.DefinitionId.TypeId, item.DefinitionId.SubtypeId);
                            (observer.Inventory as IMyInventory).AddMaxItems(item.Ammount, ItensConstants.GetPhysicalObjectBuilder(id));
                        }
                    }
                    catch (Exception ex)
                    {
                        ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
                    }
                }
                ConservationTime = extraInfo.StartConservationTime;
            });
        }

        public void DoUpdate(MyInventoryObserver observer, TimeSpan spendTime)
        {
            if (NeedUpdate)
            {
                if (NeedConservation && observer.SpoilEnabled && (ExtendedSurvivalSettings.Instance.RotEnabled || observer.ForceSpoil))
                {
                    if (ConservationTime > spendTime)
                        ConservationTime = new TimeSpan(ConservationTime.Ticks - (long)(spendTime.Ticks * observer.SpoilMultiplier));
                    else
                        ConservationTime = TimeSpan.Zero;
                    if (observer.Debug)
                        ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"MyItemExtraInfo DoUpdate {DefinitionId} {ConservationTime}");
                    if (ConservationTime == TimeSpan.Zero)
                        DoSpoilRoutine(observer);
                }
                if (IsGasContainer && MyInventoryObserverProgressController.HasGasSpoilInfo(GasDefinitionId.subtypeId.String))
                {
                    var spoilInfo = MyInventoryObserverProgressController.GetGasSpoilInfo(GasDefinitionId.subtypeId.String);
                    if (spoilInfo.CanDecay == null || spoilInfo.CanDecay.Invoke(observer.ObserverId.ToGuid()))
                    {
                        ConservationTime = new TimeSpan(ConservationTime.Ticks + spendTime.Ticks);
                        if (ConservationTime.TotalMilliseconds >= spoilInfo.CicleTime)
                        {
                            ConservationTime = TimeSpan.Zero;
                            var gasContainer = observer.Inventory.GetItemByID(ItemId).Value.Content as MyObjectBuilder_GasContainerObject;
                            if (gasContainer != null)
                            {
                                gasContainer.GasLevel -= spoilInfo.DecayFactor;
                                if (gasContainer.GasLevel <= 0)
                                {
                                    gasContainer.GasLevel = 0;
                                    DoSpoilRoutine(observer);
                                }
                                if (observer.Debug)
                                    ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"MyItemExtraInfo DoUpdate {DefinitionId} GasLevel={gasContainer.GasLevel}");
                            }
                        }
                    }
                }
            }
        }

    }

}
