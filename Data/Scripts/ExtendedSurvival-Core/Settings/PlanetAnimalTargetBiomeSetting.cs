using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalTargetBiomeSetting
    {

        [XmlElement]
        public string Id { get; set; }

    }

}
