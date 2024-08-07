using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class FloatingObjectSettings
    {

        [XmlElement]
        public DocumentedDefinitionId ItemId { get; set; }

        public long RemoveAfter { get; set; }

    }

}
