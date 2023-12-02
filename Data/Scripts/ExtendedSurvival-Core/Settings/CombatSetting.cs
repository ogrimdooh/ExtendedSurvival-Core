using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class CombatSetting 
    {

        [XmlElement]
        public bool NoGrindFunctionalGrids { get; set; } = false;

    }

}
