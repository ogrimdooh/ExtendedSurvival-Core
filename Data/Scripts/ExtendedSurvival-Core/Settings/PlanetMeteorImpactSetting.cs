using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetMeteorImpactSetting
    {

        [XmlElement]
        public bool Enabled { get; set; } = true;

        [XmlElement]
        public float ChanceToSpawn { get; set; } = 0.25f;

        [XmlArray("Stones"), XmlArrayItem("Stone", typeof(MeteorImpactStoneSetting))]
        public List<MeteorImpactStoneSetting> Stones { get; set; } = new List<MeteorImpactStoneSetting>();

    }

}
