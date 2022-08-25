using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SystemMemberSetting
    {

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public int MemberType { get; set; }

        [XmlElement]
        public string DefinitionSubtype { get; set; }

        [XmlElement]
        public bool HasRing { get; set; }

        [XmlElement]
        public float Density { get; set; }

        [XmlElement]
        public int Order { get; set; }

        [XmlElement]
        public DocumentedVector2 MoonCount { get; set; } = new DocumentedVector2(0, 0, StarSystemSetting.TOTALMEMBERS_INFO);

        [XmlArray("ValidMoons"), XmlArrayItem("ValidMoon", typeof(ValidMoonEntrySetting))]
        public List<ValidMoonEntrySetting> ValidMoons { get; set; } = new List<ValidMoonEntrySetting>();

    }

}
