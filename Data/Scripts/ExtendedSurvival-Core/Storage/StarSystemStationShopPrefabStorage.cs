using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemStationShopPrefabStorage
    {
        
        [XmlElement]
        public string PrefabName { get; set; }

        [XmlElement]
        public float Price { get; set; }

    }

}
