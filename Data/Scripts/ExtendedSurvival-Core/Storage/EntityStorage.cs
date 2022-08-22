using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class EntityStorage
    {

        [XmlElement]
        public long EntityId { get; set; }

        [ProtoMember(1), XmlArray("Storage"), XmlArrayItem("Entry", typeof(EntityStorageValue))]
        public List<EntityStorageValue> Values;

        public string GetValue(string key)
        {
            if (Values.Any(x => x.Key == key))
                return Values.FirstOrDefault(x => x.Key == key).Value;
            return null;
        }

        public void SetValue(string key, string value)
        {
            EntityStorageValue entry = null;
            if (Values.Any(x => x.Key == key))
            {
                entry = Values.FirstOrDefault(x => x.Key == key);
                lock (Values)
                {
                    entry.Value = value;
                }
            }
            else
            {
                entry = new EntityStorageValue() { Key = key, Value = value };
                lock (Values)
                {
                    Values.Add(entry);
                }
            }
        }

        public EntityStorage()
        {
            Values = new List<EntityStorageValue>();
        }

    }

}
