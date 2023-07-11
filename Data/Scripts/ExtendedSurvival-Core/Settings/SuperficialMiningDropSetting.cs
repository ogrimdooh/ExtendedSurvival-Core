using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SuperficialMiningDropSetting
    {

        public const string AMMOUNT_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public SerializableDefinitionId ItemId { get; set; }

        [XmlElement]
        public DocumentedVector2 Ammount { get; set; } = new DocumentedVector2(0, 0, AMMOUNT_RANGE_INFO);

        [XmlElement]
        public float Chance { get; set; }

        [XmlElement]
        public bool AlowFrac { get; set; }

        [XmlArray("ValidSubTypes"), XmlArrayItem("Type", typeof(SuperficialMiningDropValidSubTypeSetting))]
        public List<SuperficialMiningDropValidSubTypeSetting> ValidSubType { get; set; } = new List<SuperficialMiningDropValidSubTypeSetting>();

    }

}
