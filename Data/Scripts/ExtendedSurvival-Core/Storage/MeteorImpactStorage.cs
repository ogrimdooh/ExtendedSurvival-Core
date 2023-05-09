using System.Collections.Generic;
using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MeteorImpactStorage
    {

        [XmlArray("Stones"), XmlArrayItem("Stone", typeof(MeteorStoneStorage))]
        public List<MeteorStoneStorage> Stones { get; set; } = new List<MeteorStoneStorage>();

    }

}
