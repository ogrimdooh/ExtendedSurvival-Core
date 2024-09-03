using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetBiomeVoxelMaterialSetting
    {

        [XmlElement]
        public string Id { get; set; }

    }

}
