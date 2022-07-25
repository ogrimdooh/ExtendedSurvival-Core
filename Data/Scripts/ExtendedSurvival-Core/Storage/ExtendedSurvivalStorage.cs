using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using System.Xml.Serialization;
using System;

namespace ExtendedSurvival
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

        public static ExtendedSurvivalStorage Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalStorage(); });
            return _instance;
        }

        public static void Save()
        {
            try
            {
                Save(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        [ProtoMember(1), XmlArray("Entities"), XmlArrayItem("Entity", typeof(EntityStorage))]
        public List<EntityStorage> Entities;

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

        public ExtendedSurvivalStorage()
        {
            Entities = new List<EntityStorage>();
        }

    }

}
