using ProtoBuf;
using System.Xml;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ValidHuntAnimalSetting
    {

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public bool IsAgressive { get; set; }

    }

}
