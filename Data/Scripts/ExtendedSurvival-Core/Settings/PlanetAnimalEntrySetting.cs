using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetAnimalEntrySetting
    {

        [XmlElement]
        public string Id { get; set; }

    }

}
