using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetBiomeSetting
    {

        [XmlElement]
        public string Id { get; set; }

        [XmlArray("VoxelMaterials"), XmlArrayItem("VoxelMaterial", typeof(PlanetBiomeVoxelMaterialSetting))]
        public List<PlanetBiomeVoxelMaterialSetting> VoxelMaterials { get; set; } = new List<PlanetBiomeVoxelMaterialSetting>();

    }

}
