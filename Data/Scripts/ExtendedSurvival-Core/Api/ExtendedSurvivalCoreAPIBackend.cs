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

namespace ExtendedSurvival
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

        public const int MinVersion = 1;
        public const ushort ModHandlerID = 33275;

        private static readonly Dictionary<string, Delegate> ModAPIMethods = new Dictionary<string, Delegate>()
        {
            ["VerifyVersion"] = new Func<int, string, bool>(VerifyVersion),
            ["AddInventoryObserver"] = new Func<IMyEntity, int, Guid>(AddInventoryObserver),
            ["AddItemCategory"] = new Action<string>(AddItemCategory),
            ["AddDefinitionToCategory"] = new Action<MyDefinitionId, string>(AddDefinitionToCategory),
            ["AddItemExtraInfo"] = new Action<string>(AddItemExtraInfo),
            ["AddGasSpoilInfo"] = new Action<string, float, float, Func<Guid, bool>>(AddGasSpoilInfo)
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
        }

        public static void AddDefinitionToCategory(MyDefinitionId id, string category)
        {
            MyInventoryObserverProgressController.AddItemToCategory(new UniqueEntityId(id), category);
        }

        public static void AddItemExtraInfo(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    var itemExtraInfo = MyAPIGateway.Utilities.SerializeFromXML<ItemExtraInfo>(value);

                }
                catch (Exception e)
                {
                    MyLog.Default.WriteLine("NanobotAPI: " + e);
                }
            }
        }

        public static void AddGasSpoilInfo(string gasSubtypeId, float cicleTime, float decayFactor, Func<Guid, bool> checkDelegate)
        {
            MyInventoryObserverProgressController.AddGasSpoilInfo(gasSubtypeId, cicleTime, decayFactor, checkDelegate);
        }

    }
}