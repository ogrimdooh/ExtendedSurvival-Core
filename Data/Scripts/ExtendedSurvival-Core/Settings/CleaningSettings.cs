using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class CleaningSettings
    {
        
        public int CleaningCycleTime { get; set; } = 5000;

        public bool FloatingObjectsLoaded { get; set; } = false;

        [XmlArray("FloatingObjects"), XmlArrayItem("Entry", typeof(FloatingObjectSettings))]
        public List<FloatingObjectSettings> FloatingObjects { get; set; } = new List<FloatingObjectSettings>();

    }

}
