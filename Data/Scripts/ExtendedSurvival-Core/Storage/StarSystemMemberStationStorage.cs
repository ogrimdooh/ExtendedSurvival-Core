using ProtoBuf;
using System;
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
        public long CargoContainerEntityId { get; set; }

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

        [XmlArray("ShopPrefabs"), XmlArrayItem("Prefab", typeof(StarSystemStationShopPrefabStorage))]
        public List<StarSystemStationShopPrefabStorage> ShopPrefabs { get; set; } = new List<StarSystemStationShopPrefabStorage>();
        
        public string GetDatabadData()
        {
            return "Some Merchant keeps bragging about some really good deals at a station he has been visiting but would not spill the details. " + Environment.NewLine +
                "However, I happened to 'stumble' on his navigation computer during my maintenance shift and this position kept popping up. Go see if there is any truth in what that merchant said." + Environment.NewLine + Environment.NewLine +
                $"GPS:{Name.Replace(":", "")}:{Position.X}:{Position.Y}:{Position.Z}:#FF75C9F1:";
        }

    }

}
