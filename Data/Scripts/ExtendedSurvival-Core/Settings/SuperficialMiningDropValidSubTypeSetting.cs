using ProtoBuf;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SuperficialMiningDropValidSubTypeSetting
    {

        public string Id { get; set; }

    }

}
