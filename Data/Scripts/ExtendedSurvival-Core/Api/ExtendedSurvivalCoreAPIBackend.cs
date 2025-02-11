﻿using System;
using System.Collections.Generic;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Serialization;
using VRage.Game;
using VRage;
using System.IO;
using ProtoBuf;
using VRage.ModAPI;
using Sandbox.Game;
using VRage.ObjectBuilders;
using System.Linq;
using VRage.Utils;
using VRage.Game.ModAPI;
using VRage.Game.Entity;
using Sandbox.ModAPI.Weapons;
using System.Reflection.Metadata.Ecma335;

namespace ExtendedSurvival.Core
{
    //Do not include this file in your project modders
    public class ExtendedSurvivalCoreAPIBackend
    {

        public const int MinVersion = 1;
        public const ushort ModHandlerID = 33275;

        private static readonly Dictionary<string, Delegate> ModAPIMethods = new Dictionary<string, Delegate>()
        {
            ["VerifyVersion"] = new Func<int, string, bool>(VerifyVersion),
            ["AddInventoryObserver"] = new Func<IMyEntity, int, Guid>(AddInventoryObserver),
            ["GetInventoryObserver"] = new Func<IMyEntity, int, Guid>(GetInventoryObserver),
            ["AddItemCategory"] = new Action<string>(AddItemCategory),
            ["AddDefinitionToCategory"] = new Action<MyDefinitionId, string>(AddDefinitionToCategory),
            ["AddItemExtraInfo"] = new Action<string>(AddItemExtraInfo),
            ["AddGasSpoilInfo"] = new Action<string, float, float, long, Func<Guid, bool>>(AddGasSpoilInfo),
            ["HasItemInObserver"] = new Func<Guid, MyDefinitionId, bool>(HasItemInObserver),
            ["HasItemOfCategoryInObserver"] = new Func<Guid, string, bool>(HasItemOfCategoryInObserver),
            ["GetItemAmmountInObserver"] = new Func<Guid, MyDefinitionId, float>(GetItemAmmountInObserver),
            ["DisposeInventoryObserver"] = new Action<Guid>(DisposeInventoryObserver),
            ["GetPlanetAtRange"] = new Func<Vector3D, string>(GetPlanetAtRange),
            ["GetTemperatureInPoint"] = new Func<long, Vector3D, Vector2?>(GetTemperatureInPoint),
            ["GetItemInfoByGasId"] = new Func<Guid, MyDefinitionId, string>(GetItemInfoByGasId),
            ["GetItemInfoByItemId"] = new Func<Guid, uint, string>(GetItemInfoByItemId),
            ["GetItemInfoByItemType"] = new Func<Guid, MyDefinitionId, string>(GetItemInfoByItemType),
            ["GetItemInfoByCategory"] = new Func<Guid, string, string>(GetItemInfoByCategory),
            ["AddTreeDropLoot"] = new Action<string>(AddTreeDropLoot),
            ["GetHandheldGunInfo"] = new Func<long, KeyValuePair<IMyAutomaticRifleGun, string>?>(GetHandheldGunInfo),
            ["AddOnHandheldGunReloadCallback"] = new Func<Action<IMyAutomaticRifleGun, int, MyDefinitionId, IMyInventory>, int, bool>(AddOnHandheldGunReloadCallback),
            ["SetInventoryObserverSpoilStatus"] = new Action<Guid, bool, bool, float>(SetInventoryObserverSpoilStatus),
            ["GetUnderwaterCollectors"] = new Func<long, IMySlimBlock[]>(GetUnderwaterCollectors),
            ["GetOffwaterCollectors"] = new Func<long, IMySlimBlock[]>(GetOffwaterCollectors),
            ["GetWaterSolidificators"] = new Func<long, List<IMySlimBlock>>(GetWaterSolidificators),
            ["GetGridBlocks"] = new Func<long, MyObjectBuilderType, string, List<IMySlimBlock>>(GetGridBlocks),
            ["FindGridBlockById"] = new Func<long, IMySlimBlock>(FindGridBlockById),
            ["RegisterInventoryObserverUpdateCallback"] = new Action<Guid, Action<Guid, MyInventory, IMyEntity, TimeSpan>>(RegisterInventoryObserverUpdateCallback),
            ["RegisterInventoryObserverAfterContentsAddedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsAddedCallback),
            ["RegisterInventoryObserverAfterContentsRemovedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsRemovedCallback),
            ["RegisterInventoryObserverAfterContentsChangedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsChangedCallback),
            ["HasDisassemblyComputer"] = new Func<long, bool>(HasDisassemblyComputer),
            ["HasAdvancedDisassemblyComputer"] = new Func<long, bool>(HasAdvancedDisassemblyComputer),
            ["AddExtraStartLoot"] = new Action<MyDefinitionId, float>(AddExtraStartLoot),
            ["GetGameTime"] = new Func<long>(GetGameTime),
            ["AddItemToShop"] = new Func<string, bool>(AddItemToShop),
            ["ChangeItemRarity"] = new Func<MyDefinitionId, int, bool>(ChangeItemRarity),
            ["MarkAsAllItensLoaded"] = new Action<ulong>(MarkAsAllItensLoaded),
            ["IsMarkAsAllItensLoaded"] = new Func<bool>(IsMarkAsAllItensLoaded),
            ["AddCallBackWhenMarkAsAllItensLoaded"] = new Action<Action>(AddCallBackWhenMarkAsAllItensLoaded),
            ["GetDisableAssemblerDysasemble"] = new Func<bool>(GetDisableAssemblerDysasemble),
            ["IsTradeFaction"] = new Func<string, bool>(IsTradeFaction)
        };

        public static void BeforeStart()
        {
            MyAPIGateway.Utilities.SendModMessage(ModHandlerID, ModAPIMethods);
        }

        public static bool VerifyVersion(int ModAPIVersion, string ModName)
        {
            if (ModAPIVersion < MinVersion)
            {
                return false;
            }
            return true;
        }

        public static long GetGameTime()
        {
            if (MyExtendedSurvivalTimeManager.Instance != null)
                return MyExtendedSurvivalTimeManager.Instance.GameTime;
            return 0;
        }

        public static void AddExtraStartLoot(MyDefinitionId itemType, float ammount)
        {
            var id = new UniqueEntityId(itemType);
            if (!ExtendedSurvivalEntityManager.ExtraStartLoot.Keys.Contains(id))
                ExtendedSurvivalEntityManager.ExtraStartLoot.Add(id, ammount);
            else
                ExtendedSurvivalEntityManager.ExtraStartLoot[id] += ammount;
        }

        public static Guid GetInventoryObserver(IMyEntity entity, int index)
        {
            if (entity != null)
            {
                var observer = MyInventoryObserverProgressController.Get(entity.EntityId, index);
                if (observer != null)
                {
                    return observer.ObserverId.ToGuid();
                }
            }
            return Guid.Empty;
        }

        public static Guid AddInventoryObserver(IMyEntity entity, int index)
        {
            if (entity != null)
            {
                var inventory = entity.GetInventory(index) as MyInventory;
                if (inventory != null)
                {
                    var observer = new MyInventoryObserver(inventory, entity);
                    return observer.ObserverId.ToGuid();
                }
            }
            return Guid.Empty;
        }

        public static void AddItemCategory(string category)
        {
            MyInventoryObserverProgressController.AddCategory(category);
            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(ExtendedSurvivalCoreAPIBackend), $"Registred ItemCategory : {category}");
        }

        public static void AddDefinitionToCategory(MyDefinitionId id, string category)
        {
            MyInventoryObserverProgressController.AddItemToCategory(new UniqueEntityId(id), category);
            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(ExtendedSurvivalCoreAPIBackend), $"Registred Item [{id}] To Category : {category}");
        }

        public static bool ChangeItemRarity(MyDefinitionId id, int rarity)
        {
            return SpaceStationController.ChangeItemRarity(new UniqueEntityId(id), (ItemRarity)rarity);
        }

        public static void MarkAsAllItensLoaded(ulong modId)
        {
            SpaceStationController.MarkAsAllItensLoaded(modId);
        }

        public static bool IsMarkAsAllItensLoaded()
        {
            return SpaceStationController.IsAllLoaded;
        }

        public static bool IsTradeFaction(string faction)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated && ExtendedSurvivalStorage.Instance.Factions.Any())
                return ExtendedSurvivalStorage.Instance.Factions.Any(x => x.Tag == faction);
            return false;
        }

        public static bool GetDisableAssemblerDysasemble()
        {
            return ExtendedSurvivalSettings.Instance.DisableAssemblerDysasemble;
        }

        public static void AddCallBackWhenMarkAsAllItensLoaded(Action action)
        {
            SpaceStationController.OnAllLoaded += action;
        }

        public static bool AddItemToShop(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    var info = MyAPIGateway.Utilities.SerializeFromXML<StationShopItemInfo>(value);
                    return SpaceStationController.AddItemToShop(new UniqueEntityId(info.Id), info.Rarity, info.CanBuy, info.CanSell, info.CanOrder, info.ForceMinimalPrice, info.TargetFactions);
                }
                catch (Exception e)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalCoreAPIBackend), e);
                }
            }
            else
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(ExtendedSurvivalCoreAPIBackend), $"AddItemToShop : value is null");
            }
            return false;
        }

        public static void AddTreeDropLoot(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    var treeDrop = MyAPIGateway.Utilities.SerializeFromXML<TreeDropLoot>(value);
                    WoodChopController.AddTreeDrop(treeDrop);
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(ExtendedSurvivalCoreAPIBackend), $"Registred TreeDrop : {treeDrop.ItemId}");
                }
                catch (Exception e)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalCoreAPIBackend), e);
                }
            }
            else
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(ExtendedSurvivalCoreAPIBackend), $"AddTreeDropLoot : value is null");
            }
        }

        public static void AddItemExtraInfo(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    var itemExtraInfo = MyAPIGateway.Utilities.SerializeFromXML<ItemExtraInfo>(value);
                    MyInventoryObserverProgressController.AddItemExtraInfo(itemExtraInfo);
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(ExtendedSurvivalCoreAPIBackend), $"Registred ItemExtraInfo : {itemExtraInfo.DefinitionId}");
                }
                catch (Exception e)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalCoreAPIBackend), e);
                }
            }
            else
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(ExtendedSurvivalCoreAPIBackend), $"AddItemExtraInfo : value is null");
            }
        }

        public static void AddGasSpoilInfo(string gasSubtypeId, float cicleTime, float decayFactor, long toleranceTime, Func<Guid, bool> checkDelegate)
        {
            MyInventoryObserverProgressController.AddGasSpoilInfo(gasSubtypeId, cicleTime, decayFactor, toleranceTime, checkDelegate);
        }

        public static void DisposeInventoryObserver(Guid observerId)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
                observer.Dispose();
        }

        public static void RegisterInventoryObserverAfterContentsAddedCallback(Guid observerId, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterContentsAdded = callback;
            }
        }

        public static void RegisterInventoryObserverAfterContentsRemovedCallback(Guid observerId, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterContentsRemoved = callback;
            }
        }

        public static void RegisterInventoryObserverAfterContentsChangedCallback(Guid observerId, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterContentsChanged = callback;
            }
        }

        public static void RegisterInventoryObserverUpdateCallback(Guid observerId, Action<Guid, MyInventory, IMyEntity, TimeSpan> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterUpdate = callback;
            }
        }

        public static bool HasItemOfCategoryInObserver(Guid observerId, string category)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                return observer.HasItemOfCategory(category);
            }
            return false;
        }

        public static bool HasItemInObserver(Guid observerId, MyDefinitionId itemId)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                return observer.HasItem(new UniqueEntityId(itemId));
            }
            return false;
        }

        public static float GetItemAmmountInObserver(Guid observerId, MyDefinitionId itemId)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                return (float)observer.Inventory.GetItemAmount(itemId);
            }
            return 0;
        }

        public static string GetPlanetAtRange(Vector3D position)
        {
            var planet = ExtendedSurvivalEntityManager.GetPlanetAtRange(position);
            if (planet != null)
            {
                var planetData = new PlanetInfo()
                {
                    EntityId = planet.Entity.EntityId,
                    Center = planet.Center(),
                    HasSubtypeName = planet.HasSubtypeName,
                    SubtypeName = planet.SubtypeName,
                    HasWater = planet.HasWater(),
                    SettingId = planet.Setting?.Id,
                };
                if (planet.Setting != null)
                {
                    if (planet.Setting.Atmosphere != null)
                    {
                        planetData.Atmosphere = new PlanetAtmosphereInfo()
                        {
                            Enabled = planet.Setting.Atmosphere.Enabled,
                            Breathable = planet.Setting.Atmosphere.Breathable,
                            OxygenDensity = planet.Setting.Atmosphere.OxygenDensity,
                            Density = planet.Setting.Atmosphere.Density,
                            LimitAltitude = planet.Setting.Atmosphere.LimitAltitude,
                            MaxWindSpeed = planet.Setting.Atmosphere.MaxWindSpeed,
                            TemperatureLevel = planet.Setting.Atmosphere.TemperatureLevel,
                            TemperatureRange = planet.Setting.Atmosphere.TemperatureRange.ToVector2(),
                            ToxicLevel = planet.Setting.Atmosphere.ToxicLevel,
                            RadiationLevel = planet.Setting.Atmosphere.RadiationLevel
                        };
                    }
                    if (planet.Setting.Water != null)
                    {
                        planetData.Water = new PlanetWaterInfo()
                        {
                            Enabled = planet.Setting.Water.Enabled,
                            Size = planet.Setting.Water.Size,
                            TemperatureFactor = planet.Setting.Water.TemperatureFactor,
                            RadiationLevel = planet.Setting.Water.RadiationLevel,
                            ToxicLevel = planet.Setting.Water.ToxicLevel
                        };
                    }
                }
                string messageToSend = MyAPIGateway.Utilities.SerializeToXML<PlanetInfo>(planetData);
                return messageToSend;
            }
            return null;
        }

        public static Vector2? GetTemperatureInPoint(long planetId, Vector3D position)
        {
            var planet = ExtendedSurvivalEntityManager.GetPlanetById(planetId);
            if (planet != null)
            {
                float finalTemperature = 0;
                float temperatureFactor = planet.GetTemperatureInPoint(position, out finalTemperature);
                return new Vector2(temperatureFactor, finalTemperature);
            }
            return null;
        }

        public static string GetItemInfoByGasId(Guid observerId, MyDefinitionId gasId)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                var data = observer.GetExtraInfoByGasId(new UniqueEntityId(gasId));
                if (data != null && data.Any())
                {
                    var dataToSend = data.Select(x => new ItemInfo() { ItemId = x.ItemId, ExtraInfo = x.ExtraInfoDefinition }).ToArray();
                    string messageToSend = MyAPIGateway.Utilities.SerializeToXML<ItemInfo[]>(dataToSend);
                    return messageToSend;
                }
            }
            return null;
        }

        public static string GetItemInfoByItemId(Guid observerId, uint itemId)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                var data = observer.GetExtraInfo(itemId);
                if (data != null)
                {
                    var dataToSend = new ItemInfo() { ItemId = itemId, ExtraInfo = data.ExtraInfoDefinition };
                    string messageToSend = MyAPIGateway.Utilities.SerializeToXML<ItemInfo>(dataToSend);
                    return messageToSend;
                }
            }
            return null;
        }

        public static string GetItemInfoByItemType(Guid observerId, MyDefinitionId itemType)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                var data = observer.GetAllExtraInfoByItemType(new UniqueEntityId(itemType));
                if (data != null && data.Any())
                {
                    var dataToSend = data.Select(x => new ItemInfo() { ItemId = x.ItemId, ExtraInfo = x.ExtraInfoDefinition }).ToArray();
                    string messageToSend = MyAPIGateway.Utilities.SerializeToXML<ItemInfo[]>(dataToSend);
                    return messageToSend;
                }
            }
            return null;
        }

        public static string GetItemInfoByCategory(Guid observerId, string category)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                var data = observer.GetExtraInfoByCategory(category);
                if (data != null && data.Any())
                {
                    var dataToSend = data.Select(x => new ItemInfo() { ItemId = x.ItemId, ExtraInfo = x.ExtraInfoDefinition }).ToArray();
                    string messageToSend = MyAPIGateway.Utilities.SerializeToXML<ItemInfo[]>(dataToSend);
                    return messageToSend;
                }
            }
            return null;
        }

        public static bool AddOnHandheldGunReloadCallback(Action<IMyAutomaticRifleGun, int, MyDefinitionId, IMyInventory> callback, int priority)
        {
            if (callback != null)
            {
                ExtendedSurvivalEntityManager.ReloadHandheldGun.Add(new ExtendedSurvivalEntityManager.OnReloadHandheldGun()
                {
                    Action = callback,
                    Priority = priority
                });
                ExtendedSurvivalEntityManager.ReloadHandheldGun.Sort((x, y) => x.Priority.CompareTo(y.Priority) * -1);
                return true;
            }
            return false;
        }
        
        public static KeyValuePair<IMyAutomaticRifleGun, string>? GetHandheldGunInfo(long id)
        {
            var gun = ExtendedSurvivalEntityManager.Instance.GetHandheldGun(id);
            if (gun != null)
            {
                var dataToSend = new HandheldGunInfo() 
                { 
                    EntityId = gun.Entity.EntityId, 
                    CurrentAmmoMagazineId = gun.GetCurrentAmmoMagazineId().DefinitionId,
                    CurrentMagazineAmmunition = gun.CurrentMagazineAmmunition
                };
                string messageToSend = MyAPIGateway.Utilities.SerializeToXML<HandheldGunInfo>(dataToSend);
                return new KeyValuePair<IMyAutomaticRifleGun, string>(gun.Entity, messageToSend);
            }
            return null;
        }

        public static void SetInventoryObserverSpoilStatus(Guid observerId, bool enabled, bool force, float multiplier)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.SpoilEnabled = enabled;
                observer.ForceSpoil = force;
                observer.SpoilMultiplier = multiplier;
            }
        }

        public static IMySlimBlock[] GetUnderwaterCollectors(long gridId)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
                return grid.UnderwaterCollectors;
            return null;
        }

        public static IMySlimBlock[] GetOffwaterCollectors(long gridId)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
                return grid.OffwaterCollectors;
            return null;
        }

        public static List<IMySlimBlock> GetWaterSolidificators(long gridId)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
                return grid.WaterSolidificators;
            return null;
        }

        public static IMySlimBlock FindGridBlockById(long blockId)
        {
            return ExtendedSurvivalEntityManager.Instance.FindGridBlockById(blockId);
        }

        public static List<IMySlimBlock> GetGridBlocks(long gridId, MyObjectBuilderType type, string subType)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
            {
                if (!string.IsNullOrEmpty(subType))
                {
                    var id = new UniqueEntityId(type, subType);
                    if (grid._blocksById.ContainsKey(id))
                        return grid._blocksById[id].ToList();
                }
                else
                {
                    if (grid._blocksByType.ContainsKey(type))
                        return grid._blocksByType[type].ToList();
                }
            }
            return null;
        }

        public static bool HasDisassemblyComputer(long gridId)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
                return grid.HasDisassemblyComputer;
            return false;
        }

        public static bool HasAdvancedDisassemblyComputer(long gridId)
        {
            var grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(gridId);
            if (grid != null)
                return grid.HasAdvancedDisassemblyComputer;
            return false;
        }

    }
}