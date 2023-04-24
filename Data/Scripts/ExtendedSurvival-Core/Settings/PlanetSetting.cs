using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetSetting
    {

        public const string SIZERANGE_INFO = "X: Min Size. Y: Max Size.";

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public bool RespawnEnabled { get; set; } = false;

        [XmlElement]
        public int Seed { get; set; }

        [XmlElement]
        public int Version { get; set; } = 0;

        [XmlElement]
        public float Multiplier { get; set; } = 1.0f;

        [XmlElement]
        public float DeepMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public int Type { get; set; } = 0;

        [XmlElement]
        public string AddedOres { get; set; }

        [XmlElement]
        public string RemovedOres { get; set; }

        [XmlElement]
        public DocumentedVector2 SizeRange { get; set; } = new DocumentedVector2(0, 0, SIZERANGE_INFO);

        [XmlElement]
        public AtmosphereSetting Atmosphere { get; set; } = new AtmosphereSetting();

        [XmlElement]
        public GeothermalSetting Geothermal { get; set; } = new GeothermalSetting();

        [XmlElement]
        public GravitySetting Gravity { get; set; } = new GravitySetting();

        [XmlElement]
        public WaterSetting Water { get; set; } = new WaterSetting();

        [XmlElement]
        public PlanetAnimalSetting Animal { get; set; } = new PlanetAnimalSetting();

        [XmlArray("OreMap"), XmlArrayItem("Ore", typeof(PlanetOreMapEntrySetting))]
        public List<PlanetOreMapEntrySetting> OreMap { get; set; } = new List<PlanetOreMapEntrySetting>();

        public MyPlanetOreMapping[] GetOreMap()
        {
            return OreMap.Select(x => x.GetDefinition()).ToArray();
        }

    }

}
