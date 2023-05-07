using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemMemberStationStorage
    {

        [XmlIgnore]
        public bool IsSpawning { get; set; } = false;

        [XmlElement]
        public long Id { get; set; }
        
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public Vector3D Position { get; set; }

        [XmlElement]
        public Vector3 Up { get; set; }

        [XmlElement]
        public Vector3 Foward { get; set; }

        [XmlElement]
        public string PrefabName { get; set; }

        [XmlElement]
        public float PrefabUpIncrement { get; set; }

        [XmlElement]
        public long FactionId { get; set; }

        [XmlElement]
        public long StationEntityId { get; set; }

        [XmlElement]
        public long SafeZoneEntityId { get; set; }

        [XmlElement]
        public int StationType { get; set; }

        [XmlElement]
        public int StationLevel { get; set; }

        [XmlElement]
        public bool HasAtmosphere { get; set; }

        [XmlElement]
        public long ComercialTick { get; set; }

        [XmlElement]
        public bool FirstContact { get; set; }

        [XmlArray("ShopItems"), XmlArrayItem("Item", typeof(StarSystemStationShopItemStorage))]
        public List<StarSystemStationShopItemStorage> ShopItems { get; set; } = new List<StarSystemStationShopItemStorage>();

    }

}
