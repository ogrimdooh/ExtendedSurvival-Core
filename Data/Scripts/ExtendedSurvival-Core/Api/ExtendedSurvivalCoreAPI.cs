using ProtoBuf;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival
{

    public class ExtendedSurvivalCoreAPI
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
            public TimeSpan StartConservationTime { get; set; } = TimeSpan.Zero;

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

            private MyPlanet entity;
            public MyPlanet Entity 
            { 
                get
                {
                    if (entity == null)
                        entity = MyAPIGateway.Entities.GetEntityById(EntityId) as MyPlanet;
                    return entity;
                }
            }

        }

        private static ExtendedSurvivalCoreAPI instance;

        public static string ModName = "";
        public const ushort ModHandlerID = 33275;
        public const int ModAPIVersion = 1;

        public static bool Registered { get; private set; } = false;

        private static Dictionary<string, Delegate> ModAPIMethods;

        private static Func<int, string, bool> _VerifyVersion;
        private static Func<IMyEntity, int, Guid> _AddInventoryObserver;
        private static Action<Guid> _DisposeInventoryObserver;
        private static Action<string> _AddItemCategory;
        private static Action<MyDefinitionId, string> _AddDefinitionToCategory;
        private static Action<string> _AddItemExtraInfo;
        private static Action<string, float, float, Func<Guid, bool>> _AddGasSpoilInfo;
        private static Func<Guid, MyDefinitionId, bool> _HasItemInObserver;
        private static Func<Guid, MyDefinitionId, float> _GetItemAmmountInObserver;
        private static Func<Vector3D, string> _GetPlanetAtRange;
        private static Func<long, Vector3D, Vector2?> _GetTemperatureInPoint;
        private static Func<Guid, MyDefinitionId, string> _GetItemInfoByGasId;

        /// <summary>
        /// Returns true if the version is compatibile with the API Backend, this is automatically called
        /// </summary>
        public static bool VerifyVersion(int Version, string ModName)
        {
            return _VerifyVersion?.Invoke(Version, ModName) ?? false;
        }

        /// <summary>
        /// Returns the state by Block EntityId
        /// </summary>
        public static Guid AddInventoryObserver(IMyEntity entity, int index)
        {
            var observerId = _AddInventoryObserver?.Invoke(entity, index);
            return observerId.HasValue ? observerId.Value : Guid.Empty;
        }

        /// <summary>
        /// Add a item category
        /// </summary>
        /// <param name="category"></param>
        public static void AddItemCategory(string category)
        {
            _AddItemCategory?.Invoke(category);
        }

        /// <summary>
        /// Add item definition id to category
        /// </summary>
        public static void AddDefinitionToCategory(MyDefinitionId id, string category)
        {
            _AddDefinitionToCategory?.Invoke(id, category);
        }

        /// <summary>
        /// Add item extra info
        /// </summary>
        public static void AddItemExtraInfo(ItemExtraInfo info)
        {
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<ItemExtraInfo>(info);
            _AddItemExtraInfo?.Invoke(messageToSend);
        }

        /// <summary>
        /// Add gas item extra info
        /// </summary>
        public static void AddGasSpoilInfo(string gasSubtypeId, float cicleTime, float decayFactor, Func<Guid, bool> checkDelegate)
        {
            _AddGasSpoilInfo.Invoke(gasSubtypeId, cicleTime, decayFactor, checkDelegate);
        }

        /// <summary>
        /// Check if exist a item in the observer
        /// </summary>
        public static bool HasItemInObserver(Guid observerId, MyDefinitionId itemId)
        {
            var exits = _HasItemInObserver?.Invoke(observerId, itemId);
            return exits.HasValue ? exits.Value : false;
        }

        /// <summary>
        /// Get de ammount of item type in the observer
        /// </summary>
        public static float GetItemAmmountInObserver(Guid observerId, MyDefinitionId itemId)
        {
            var ammount = _GetItemAmmountInObserver?.Invoke(observerId, itemId);
            return ammount.HasValue ? ammount.Value : 0;
        }

        /// <summary>
        /// Destroy the observer with id informed
        /// </summary>
        public static void DisposeInventoryObserver(Guid observerId)
        {
            _DisposeInventoryObserver?.Invoke(observerId);
        }

        /// <summary>
        /// Get information of closest planet of a position
        /// </summary>
        public static PlanetInfo GetPlanetAtRange(Vector3D position)
        {
            var data = _GetPlanetAtRange?.Invoke(position);
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    var planetInfo = MyAPIGateway.Utilities.SerializeFromXML<PlanetInfo>(data);
                    return planetInfo;
                }
                catch (Exception e)
                {
                    MyLog.Default.WriteLine("Extended Survival Core API: " + e);
                }
            }
            return null;
        }

        /// <summary>
        /// Get the temperature at position
        /// </summary>
        public static Vector2? GetTemperatureInPoint(long planetId, Vector3D position)
        {
            var temperature = _GetTemperatureInPoint?.Invoke(planetId, position);
            return temperature;
        }

        /// <summary>
        /// Get a list of itens based in gas Id
        /// </summary>
        public static ItemInfo[] GetItemInfoByGasId(Guid observerId, MyDefinitionId gasId)
        {
            var data = _GetItemInfoByGasId?.Invoke(observerId, gasId);
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    var itemInfo = MyAPIGateway.Utilities.SerializeFromXML<ItemInfo[]>(data);
                    return itemInfo;
                }
                catch (Exception e)
                {
                    MyLog.Default.WriteLine("Extended Survival Core API: " + e);
                }
            }
            return null;
        }

        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void Unregister()
        {
            if (instance != null)
            {
                instance.DoUnregister();
            }
        }

        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void DoUnregister()
        {
            MyAPIGateway.Utilities.UnregisterMessageHandler(ModHandlerID, ModHandler);
            Registered = false;
            instance = null;
            m_onRegisteredAction = null;
        }

        private Action m_onRegisteredAction;

        /// <summary>
        /// Create a Extended Survival Core API Instance. Please only create one per mod. 
        /// </summary>
        /// <param name="onRegisteredAction">Callback once the Extended Survival Core API is active. You can Instantiate Extended Survival Core API objects in this Action</param>
        public ExtendedSurvivalCoreAPI(Action onRegisteredAction = null)
        {
            if (instance != null)
            {
                return;
            }
            instance = this;
            m_onRegisteredAction = onRegisteredAction;
            MyAPIGateway.Utilities.RegisterMessageHandler(ModHandlerID, ModHandler);
            if (ModName == "")
            {
                if (MyAPIGateway.Utilities.GamePaths.ModScopeName.Contains("_"))
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName.Split('_')[1];
                else
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName;
            }
        }

        private void ModHandler(object obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj is Dictionary<string, Delegate>)
            {
                ModAPIMethods = (Dictionary<string, Delegate>)obj;
                _VerifyVersion = (Func<int, string, bool>)ModAPIMethods["VerifyVersion"];

                Registered = VerifyVersion(ModAPIVersion, ModName);

                MyLog.Default.WriteLine("Registering Extended Survival Core API for Mod '" + ModName + "'");

                if (Registered)
                {
                    try
                    {
                        _AddInventoryObserver = (Func<IMyEntity, int, Guid>)ModAPIMethods["AddInventoryObserver"];
                        _AddItemCategory = (Action<string>)ModAPIMethods["AddItemCategory"];
                        _AddDefinitionToCategory = (Action<MyDefinitionId, string>)ModAPIMethods["AddDefinitionToCategory"];
                        _AddItemExtraInfo = (Action<string>)ModAPIMethods["AddItemExtraInfo"];
                        _AddGasSpoilInfo = (Action<string, float, float, Func<Guid, bool>>)ModAPIMethods["AddGasSpoilInfo"];
                        _HasItemInObserver = (Func<Guid, MyDefinitionId, bool>)ModAPIMethods["HasItemInObserver"];
                        _GetItemAmmountInObserver = (Func<Guid, MyDefinitionId, float>)ModAPIMethods["GetItemAmmountInObserver"];
                        _DisposeInventoryObserver = (Action<Guid>)ModAPIMethods["DisposeInventoryObserver"];
                        _GetPlanetAtRange = (Func<Vector3D, string>)ModAPIMethods["GetPlanetAtRange"];
                        _GetTemperatureInPoint = (Func<long, Vector3D, Vector2?>)ModAPIMethods["GetTemperatureInPoint"];
                        _GetItemInfoByGasId = (Func<Guid, MyDefinitionId, string>)ModAPIMethods["GetItemInfoByGasId"];

                        if (m_onRegisteredAction != null)
                            m_onRegisteredAction();
                    }
                    catch (Exception e)
                    {
                        MyAPIGateway.Utilities.ShowMessage("Extended Survival Core", "Mod '" + ModName + "' encountered an error when registering the Extended Survival Core API, see log for more info.");
                        MyLog.Default.WriteLine("Extended Survival Core API: " + e);
                    }
                }
            }
        }

    }

}