using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SuperficialMiningSetting
    {

        [XmlElement]
        public bool Enabled { get; set; } = false;

        [XmlArray("Drops"), XmlArrayItem("Drop", typeof(SuperficialMiningDropSetting))]
        public List<SuperficialMiningDropSetting> Drops { get; set; } = new List<SuperficialMiningDropSetting>();

    }

}
