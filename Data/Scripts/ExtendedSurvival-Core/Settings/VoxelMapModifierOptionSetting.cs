using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMapModifierOptionSetting
    {

        [XmlElement]
        public string IdFrom { get; set; }

        [XmlElement]
        public string IdTo { get; set; }

        [XmlElement]
        public bool Default { get; set; }

    }

}
