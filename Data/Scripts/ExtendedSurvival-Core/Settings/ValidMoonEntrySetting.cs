using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ValidMoonEntrySetting
    {

        [XmlElement]
        public string Id { get; set; }

    }

}
