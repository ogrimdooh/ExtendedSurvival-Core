using ProtoBuf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRageMath;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class AsteroidGroupStorage : BaseSettings
    {

        private const bool USE_JSON_TO_SAVE = false;

        private const int CURRENT_VERSION = 1;
        private const string FILE_NAME = "ExtendedSurvival.Core.Storage.Asteroids.{0}.xml";
        private const string JSON_FILE_NAME = "ExtendedSurvival.Core.Storage.Asteroids.{0}.json";

        private static readonly ConcurrentDictionary<long, AsteroidGroupStorage> FILES = new ConcurrentDictionary<long, AsteroidGroupStorage>();

        private static bool Validate(AsteroidGroupStorage settings)
        {
            var res = true;
            return res;
        }

        private static AsteroidGroupStorage Upgrade(AsteroidGroupStorage settings)
        {

            return settings;
        }

        private static string GetFileName(long id, bool json)
        {
            if (json)
                return string.Format(JSON_FILE_NAME, id);
            return string.Format(FILE_NAME, id);
        }

        public static AsteroidGroupStorage Get(long id)
        {
            if (FILES.ContainsKey(id))
                return FILES[id];
            return Load(id);
        }

        public static AsteroidGroupStorage Load(long id)
        {
            var _instance = Load(GetFileName(id, true), CURRENT_VERSION, Validate, () => { return new AsteroidGroupStorage(); }, Upgrade, true, false);
            if (_instance == null)
                _instance = Load(GetFileName(id, false), CURRENT_VERSION, Validate, () => { return new AsteroidGroupStorage(); }, Upgrade);
            if (_instance != null)
            {
                _instance.OwnerId = id;
                _instance.CheckModified = true;
                FILES[id] = _instance;
            }
            return _instance;
        }

        public static void SaveAll()
        {
            foreach (var item in FILES)
            {
                item.Value.Save();
            }
        }

        public void Save()
        {
            try
            {
                Save<AsteroidGroupStorage>(this, GetFileName(OwnerId, USE_JSON_TO_SAVE), true, USE_JSON_TO_SAVE);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        [XmlElement]
        public long OwnerId { get; set; }

        [XmlArray("Asteroids"), XmlArrayItem("Id", typeof(long))]
        public List<long> Asteroids { get; set; } = new List<long>();

        [XmlArray("AsteroidsData"), XmlArrayItem("Asteroid", typeof(AsteroidStorage))]
        public List<AsteroidStorage> AsteroidsData { get; set; } = new List<AsteroidStorage>();

        [XmlArray("NotSpawnAsteroids"), XmlArrayItem("Pos", typeof(Vector3D))]
        public List<Vector3D> NotSpawnAsteroids { get; set; } = new List<Vector3D>();

    }

}
