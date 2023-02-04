using System;
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

namespace ExtendedSurvival.Core
{
    //Do not include this file in your project modders
    public class ExtendedSurvivalCoreAPIBackend
    {

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class ItemExtraDefinitionAmmountInfo
        {

            [ProtoMember(1)]
            public SerializableDefinitionId DefinitionId { get; set; }

            [ProtoMember(2)]
            public float Ammount { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class ItemExtraCustomAttributeInfo
        {

            [ProtoMember(1)]
            public string Key { get; set; }

            [ProtoMember(2)]
            public string Value { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class ItemExtraInfo
        {

            [ProtoMember(1)]
            public SerializableDefinitionId DefinitionId { get; set; }

            [ProtoMember(2)]
            public bool NeedUpdate { get; set; }

            [ProtoMember(3)]
            public bool NeedConservation { get; set; }

            [ProtoMember(4)]
            public bool RemoveWhenSpoil { get; set; }

            [ProtoMember(5)]
            public float RemoveAmmount { get; set; }

            [ProtoMember(6)]
            public bool AddNewItemWhenSpoil { get; set; }

            [ProtoMember(7)]
            public long StartConservationTime { get; set; } = 0;

            [ProtoMember(8)]
            public List<ItemExtraDefinitionAmmountInfo> AddDefinitionId { get; set; } = new List<ItemExtraDefinitionAmmountInfo>();

            [ProtoMember(9)]
            public List<ItemExtraCustomAttributeInfo> CustomAttributes { get; set; } = new List<ItemExtraCustomAttributeInfo>();

            public string GetCustomAttributes(string key)
            {
                if (CustomAttributes.Any(x => x.Key == key))
                    return CustomAttributes.FirstOrDefault(x => x.Key == key).Value;
                return null;
            }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class ItemInfo
        {

            [ProtoMember(1)]
            public uint ItemId { get; set; }

            [ProtoMember(2)]
            public ItemExtraInfo ExtraInfo { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class PlanetInfo
        {

            [ProtoMember(1)]
            public long EntityId { get; set; }

            [ProtoMember(2)]
            public bool HasSubtypeName { get; set; }

            [ProtoMember(3)]
            public string SubtypeName { get; set; }

            [ProtoMember(4)]
            public string SettingId { get; set; }
            
            [ProtoMember(5)]
            public Vector3D Center { get; set; }

            [ProtoMember(6)]
            public bool HasWater { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class TreeDropLoot
        {

            [ProtoMember(1)]
            public SerializableDefinitionId ItemId { get; set; }

            [ProtoMember(2)]
            public Vector2 Ammount { get; set; }

            [ProtoMember(3)]
            public float Chance { get; set; }

            [ProtoMember(4)]
            public bool AlowMedium { get; set; } = true;

            [ProtoMember(5)]
            public bool AlowDead { get; set; } = false;

            [ProtoMember(6)]
            public bool AlowDesert { get; set; } = true;

            [ProtoMember(7)]
            public bool IsGas { get; set; } = false;

            [ProtoMember(8)]
            public float GasLevel { get; set; } = 0.3f;

            [ProtoMember(9)]
            public float MediumReduction { get; set; } = 0.75f;

            [ProtoMember(10)]
            public float DeadReduction { get; set; } = 0.75f;

            [ProtoMember(11)]
            public float DesertReduction { get; set; } = 0.75f;

            public TreeDropLoot()
            {

            }

            public TreeDropLoot(SerializableDefinitionId itemId, Vector2 ammount, float chance)
            {
                ItemId = itemId;
                Ammount = ammount;
                Chance = chance;
            }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class HandheldGunInfo
        {

            [ProtoMember(1)]
            public long EntityId { get; set; }

            [ProtoMember(2)]
            public SerializableDefinitionId CurrentAmmoMagazineId { get; set; }

        }

        public const int MinVersion = 1;
        public const ushort ModHandlerID = 33275;

        private static readonly Dictionary<string, Delegate> ModAPIMethods = new Dictionary<string, Delegate>()
        {
            ["VerifyVersion"] = new Func<int, string, bool>(VerifyVersion),
            ["AddInventoryObserver"] = new Func<IMyEntity, int, Guid>(AddInventoryObserver),
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
            ["GetHandheldGunInfo"] = new Func<long, string>(GetHandheldGunInfo),
            ["SetInventoryObserverSpoilStatus"] = new Action<Guid, bool, bool, float>(SetInventoryObserverSpoilStatus),
            ["GetUnderwaterCollectors"] = new Func<long, IMySlimBlock[]>(GetUnderwaterCollectors),
            ["GetOffwaterCollectors"] = new Func<long, IMySlimBlock[]>(GetOffwaterCollectors),
            ["GetWaterSolidificators"] = new Func<long, List<IMySlimBlock>>(GetWaterSolidificators),
            ["RegisterInventoryObserverUpdateCallback"] = new Action<Guid, Action<Guid, MyInventory, IMyEntity, TimeSpan>>(RegisterInventoryObserverUpdateCallback),
            ["RegisterInventoryObserverAfterContentsAddedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsAddedCallback),
            ["RegisterInventoryObserverAfterContentsRemovedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsRemovedCallback),
            ["RegisterInventoryObserverAfterContentsChangedCallback"] = new Action<Guid, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint>>(RegisterInventoryObserverAfterContentsChangedCallback),
            ["HasDisassemblyComputer"] = new Func<long, bool>(HasDisassemblyComputer),
            ["HasAdvancedDisassemblyComputer"] = new Func<long, bool>(HasAdvancedDisassemblyComputer),
            ["AddExtraStartLoot"] = new Action<MyDefinitionId, float>(AddExtraStartLoot)
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

        public static void AddExtraStartLoot(MyDefinitionId itemType, float ammount)
        {
            var id = new UniqueEntityId(itemType);
            if (!ExtendedSurvivalEntityManager.ExtraStartLoot.Keys.Contains(id))
                ExtendedSurvivalEntityManager.ExtraStartLoot.Add(id, ammount);
            else
                ExtendedSurvivalEntityManager.ExtraStartLoot[id] += ammount;
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
                observer.OnAfterContentsAdded += callback;
            }
        }

        public static void RegisterInventoryObserverAfterContentsRemovedCallback(Guid observerId, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterContentsRemoved += callback;
            }
        }

        public static void RegisterInventoryObserverAfterContentsChangedCallback(Guid observerId, Action<Guid, MyInventory, MyPhysicalInventoryItem, MyFixedPoint> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterContentsChanged += callback;
            }
        }

        public static void RegisterInventoryObserverUpdateCallback(Guid observerId, Action<Guid, MyInventory, IMyEntity, TimeSpan> callback)
        {
            var observer = MyInventoryObserverProgressController.GetById(observerId.ToUInt128());
            if (observer != null)
            {
                observer.OnAfterUpdate += callback;
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
                    SettingId = planet.Setting?.Id
                };
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

        public static string GetHandheldGunInfo(long id)
        {
            var gun = ExtendedSurvivalEntityManager.Instance.GetHandheldGun(id);
            if (gun != null)
            {
                var dataToSend = new HandheldGunInfo() { EntityId = gun.Entity.EntityId, CurrentAmmoMagazineId = gun.GetCurrentAmmoMagazineId().DefinitionId };
                string messageToSend = MyAPIGateway.Utilities.SerializeToXML<HandheldGunInfo>(dataToSend);
                return messageToSend;
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