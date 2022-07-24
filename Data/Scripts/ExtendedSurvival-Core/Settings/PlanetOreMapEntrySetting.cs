using ProtoBuf;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetOreMapEntrySetting
    {

        [XmlElement]
        public byte Value { get; set; }

        [XmlElement]
        public string Type { get; set; }

        [XmlElement]
        public float Start { get; set; }

        [XmlElement]
        public float Depth { get; set; }

        [XmlElement]
        public string TargetColor { get; set; }

        [XmlElement]
        public float ColorInfluence { get; set; }

        public MyPlanetOreMapping GetDefinition()
        {
            return new MyPlanetOreMapping()
            {
                Value = Value,
                Type = Type,
                Start = Start,
                Depth = Depth,
                TargetColor = TargetColor,
                ColorInfluence = ColorInfluence
            };
        }

    }

}
