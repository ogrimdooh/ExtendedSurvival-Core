using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class StarSystemMapProfile
    {

        public const int PROFILES_VERSION = 1;
        public const string DEFAULT_PROFILE = "RANDOM";

        private static readonly Dictionary<string, StarSystemProfile> SYSTEMS_PROFILES = new Dictionary<string, StarSystemProfile>()
        {
            {
                DEFAULT_PROFILE,
                new StarSystemProfile()
                {
                    Name = DEFAULT_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Random,
                    WithStar = false,
                    VanillaAsteroids = false,
                    TotalMembers = new Vector2(4, 10),
                    DefaultMoonCount = new Vector2(0, 5),
                    DefaultBeltCount = new Vector2(1, 2),
                    DefaultRingCount = new Vector2(0, 2),
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1f,
                    AllowDuplicate = true
                }
            }
        };

        public static string[] Keys()
        {
            return SYSTEMS_PROFILES.Keys.ToArray();
        }

        public static StarSystemProfile Get(string key)
        {
            if (SYSTEMS_PROFILES.ContainsKey(key))
                return SYSTEMS_PROFILES[key];
            return SYSTEMS_PROFILES[DEFAULT_PROFILE];
        }

    }

}
