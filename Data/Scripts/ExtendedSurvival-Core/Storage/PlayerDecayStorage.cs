using ProtoBuf;
using System;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlayerDecayStorage
    {

        public ulong SteamId { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastActiveTime { get; set; }        
        public bool ImuneToDecay { get; set; }

        public bool CanDecay
        {
            get
            {
                if (!ImuneToDecay && ExtendedSurvivalSettings.Instance != null && ExtendedSurvivalSettings.Instance.Decay.Enabled)
                {
                    var inactiveMinutes = (long)(DateTime.UtcNow - LastActiveTime).TotalMinutes;
                    return inactiveMinutes > ExtendedSurvivalSettings.Instance.Decay.TimeToDecay;
                }
                return false;
            }
        }

    }

}
