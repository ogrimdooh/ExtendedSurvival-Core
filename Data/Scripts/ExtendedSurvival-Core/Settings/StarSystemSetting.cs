using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StarSystemSetting
    {

        public const string TOTALMEMBERS_INFO = "X: Min Ammount. Y: Max Ammount.";

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int Type { get; set; }

        [XmlElement]
        public int PlanetProfile { get; set; }

        [XmlArray("Members"), XmlArrayItem("Member", typeof(SystemMemberSetting))]
        public List<SystemMemberSetting> Members { get; set; } = new List<SystemMemberSetting>();

        [XmlElement]
        public DocumentedVector2 TotalMembers { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultMoonCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultBeltCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public DocumentedVector2 DefaultRingCount { get; set; } = new DocumentedVector2(0, 0, TOTALMEMBERS_INFO);

        [XmlElement]
        public float DefaultDensity { get; set; } = 0.75f;

        [XmlElement]
        public float DistanceMultiplier { get; set; } = 1f;

        [XmlElement]
        public bool WithStar { get; set; } = false;

        [XmlElement]
        public bool AllowDuplicate { get; set; } = false;

        [XmlElement]
        public bool VanillaAsteroids { get; set; } = false;

        [XmlElement]
        public int Version { get; set; } = 0;

    }

}
