using ProtoBuf;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class AtmosphereSetting
    {

        public const string TEMPERATURE_RANGE_INFO = "X: Minimal. Y: Maxima.";

        [XmlElement]
        public bool Enabled { get; set; }

        [XmlElement]
        public bool Breathable { get; set; }

        [XmlElement]
        public float OxygenDensity { get; set; }

        [XmlElement]
        public float Density { get; set; }

        [XmlElement]
        public float LimitAltitude { get; set; }

        [XmlElement]
        public float MaxWindSpeed { get; set; }

        [XmlElement]
        public int TemperatureLevel { get; set; } = 0;

        [XmlElement]
        public DocumentedVector2 TemperatureRange { get; set; } = new DocumentedVector2(0, 0, TEMPERATURE_RANGE_INFO);

        [XmlElement]
        public float ToxicLevel { get; set; } = 0;

        [XmlElement]
        public float RadiationLevel { get; set; } = 0;
        
        public MyPlanetAtmosphere GetAtmosphere()
        {
            return new MyPlanetAtmosphere()
            {
                Breathable = Breathable,
                Density = Density,
                OxygenDensity = OxygenDensity,
                LimitAltitude = LimitAltitude,
                MaxWindSpeed = MaxWindSpeed
            };
        }

    }

}
