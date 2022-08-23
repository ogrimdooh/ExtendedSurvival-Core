using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlanetParentEntrySetting
    {

        [XmlElement]
        public string Id { get; set; }

    }

}
