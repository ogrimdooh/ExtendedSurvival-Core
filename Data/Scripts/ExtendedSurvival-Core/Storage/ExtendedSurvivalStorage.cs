using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using System.Xml.Serialization;
using System;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ExtendedSurvivalStorage : BaseSettings
    {

        private const int CURRENT_VERSION = 1;
        private const string FILE_NAME = "ExtendedSurvival.Core.Storage.xml";

        private static ExtendedSurvivalStorage _instance;
        public static ExtendedSurvivalStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        private static bool Validate(ExtendedSurvivalStorage settings)
        {
            var res = true;
            return res;
        }

        private static ExtendedSurvivalStorage Upgrade(ExtendedSurvivalStorage settings)
        {

            return settings;
        }

        public static ExtendedSurvivalStorage Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalStorage(); }, Upgrade);
            return _instance;
        }

        public static void Save()
        {
            try
            {
                Save<ExtendedSurvivalStorage>(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        [XmlElement]
        public StarSystemStorage StarSystem { get; set; } = new StarSystemStorage();

        [XmlArray("Factions"), XmlArrayItem("Faction", typeof(FactionStorage))]
        public List<FactionStorage> Factions { get; set; } = new List<FactionStorage>();

        [XmlArray("PlayersMappedToFactions"), XmlArrayItem("Id", typeof(long))]
        public List<long> PlayersMappedToFactions { get; set; } = new List<long>();

        [XmlArray("FactionsMappedToFactions"), XmlArrayItem("Id", typeof(long))]
        public List<long> FactionsMappedToFactions { get; set; } = new List<long>();

        [XmlArray("Entities"), XmlArrayItem("Entity", typeof(EntityStorage))]
        public List<EntityStorage> Entities { get; set; } = new List<EntityStorage>();

        public FactionStorage GetFaction(long id)
        {
            if (Factions.Any(x => x.FactionId == id))
                return Factions.FirstOrDefault(x => x.FactionId == id);
            var storage = new FactionStorage() { FactionId = id };
            lock (Factions)
            {
                Factions.Add(storage);
            }
            return storage;
        }

        public EntityStorage GetEntity(long id)
        {
            if (Entities.Any(x => x.EntityId == id))
                return Entities.FirstOrDefault(x => x.EntityId == id);
            var storage = new EntityStorage() { EntityId = id };
            lock (Entities)
            {
                Entities.Add(storage);
            }
            return storage;
        }

        public string GetEntityValue(long id, string key)
        {
            return GetEntity(id).GetValue(key);
        }

        public void SetEntityValue(long id, string key, string value)
        {
            GetEntity(id).SetValue(key, value);
        }

        public void RemoveEntity(long id)
        {
            if (Entities.Any(x => x.EntityId == id))
                lock (Entities)
                {
                    Entities.RemoveAll(x => x.EntityId == id);
                }
        }

        public void RemoveFaction(long id)
        {
            if (Factions.Any(x => x.FactionId == id))
                lock (Factions)
                {
                    Factions.RemoveAll(x => x.FactionId == id);
                }
        }

        public ExtendedSurvivalStorage()
        {
            Entities = new List<EntityStorage>();
        }

    }

}
