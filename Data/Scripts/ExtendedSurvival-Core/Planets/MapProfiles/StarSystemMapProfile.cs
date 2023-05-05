using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class StarSystemMapProfile
    {

        public const int PROFILES_VERSION = 1;
        public const string DEFAULT_PROFILE = "RANDOM";
        public const string VANILLA_PROFILE = "VANILLA";
        public const string EXTENDEDSURVIVAL_PROFILE = "ES";
        public const string EXTENDEDSURVIVAL_COMPLETE_PROFILE = "VANILLAES";
        public const string ATA_PROFILE = "ATA";

        public static readonly Dictionary<string, StarSystemProfile> SYSTEMS_PROFILES = new Dictionary<string, StarSystemProfile>()
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
            },
            {
                VANILLA_PROFILE,
                new StarSystemProfile()
                {
                    Name = VANILLA_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = false,
                    VanillaAsteroids = false,
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1f,
                    AllowDuplicate = false,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.Vanilla,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            name = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            order = 0,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            {
                                VanilaMapProfile.DEFAULT_MOON 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_TRITON,
                            name = VanilaMapProfile.DEFAULT_TRITON,
                            order = 1
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_MARS,
                            name = VanilaMapProfile.DEFAULT_MARS,
                            order = 2,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            {
                                VanilaMapProfile.DEFAULT_EUROPA 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.AsteroidBelt,
                            name = "Kuiper Belt",
                            order = 3,
                            density = 0.65f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_ALIEN,
                            name = VanilaMapProfile.DEFAULT_ALIEN,
                            order = 4,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_TITAN
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_PERTAM,
                            name = VanilaMapProfile.DEFAULT_PERTAM,
                            order = 5
                        }
                    }
                }
            },
            {
                EXTENDEDSURVIVAL_PROFILE,
                new StarSystemProfile()
                {
                    Name = EXTENDEDSURVIVAL_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = false,
                    VanillaAsteroids = false,
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1.25f,
                    AllowDuplicate = false,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.ExtendedSurvival,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            name = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            order = 0,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            name = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            order = 1,
                            hasRing = true
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            name = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            order = 2,
                            moonCount = new Vector2(2, 2),
                            validMoons = new string[] 
                            { 
                                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS, 
                                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.AsteroidBelt,
                            name = "Arcaris Belt",
                            order = 3,
                            density = 0.85f                            
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            name = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            order = 4,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            { 
                                ExtendedSurvivalMapProfile.DEFAULT_OI 
                            }
                        }
                    }
                }
            },
            {
                EXTENDEDSURVIVAL_COMPLETE_PROFILE,
                new StarSystemProfile()
                {
                    Name = EXTENDEDSURVIVAL_COMPLETE_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = false,
                    VanillaAsteroids = false,
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1f,
                    AllowDuplicate = false,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.ExtendedSurvival | StarSystemProfile.ValidPlanetProfile.Vanilla,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            name = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            order = 0,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            name = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            order = 1,
                            hasRing = true
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            name = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            order = 2,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_MOON
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_TRITON,
                            name = VanilaMapProfile.DEFAULT_TRITON,
                            order = 3
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            name = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            order = 4,
                            moonCount = new Vector2(2, 2),
                            validMoons = new string[] 
                            { 
                                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS, 
                                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.AsteroidBelt,
                            name = "Arcaris Belt",
                            order = 5,
                            density = 0.85f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_MARS,
                            name = VanilaMapProfile.DEFAULT_MARS,
                            order = 6,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_EUROPA 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            name = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            order = 7,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] { ExtendedSurvivalMapProfile.DEFAULT_OI }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_ALIEN,
                            name = VanilaMapProfile.DEFAULT_ALIEN,
                            order = 8,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] { VanilaMapProfile.DEFAULT_TITAN }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = VanilaMapProfile.DEFAULT_PERTAM,
                            name = VanilaMapProfile.DEFAULT_PERTAM,
                            order = 9
                        }
                    }
                }
            },
            {
                ATA_PROFILE,
                new StarSystemProfile()
                {
                    Name = ATA_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = true,
                    VanillaAsteroids = false,
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1.25f,
                    AllowDuplicate = false,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.ATA,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_01_MERCURY,
                            name = ATAMapProfile.ATA_01_MERCURY,
                            order = 0
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_02_VENUS,
                            name = ATAMapProfile.ATA_02_VENUS,
                            order = 1
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_03_EARTH,
                            name = ATAMapProfile.ATA_03_EARTH,
                            order = 2,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[] 
                            { 
                                ATAMapProfile.ATA_03_MOON 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_04_MARS,
                            name = ATAMapProfile.ATA_04_MARS,
                            order = 3
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.AsteroidBelt,
                            name = "Kuiper Belt",
                            order = 4,
                            density = 0.65f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_05_JUPITER,
                            name = ATAMapProfile.ATA_05_JUPITER,
                            order = 5,
                            moonCount = new Vector2(4, 4),
                            validMoons = new string[] 
                            { 
                                ATAMapProfile.ATA_05_CALLISTO,
                                ATAMapProfile.ATA_05_EUROPA,
                                ATAMapProfile.ATA_05_GANYMEDE,
                                ATAMapProfile.ATA_05_IO
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_06_SATURN,
                            name = ATAMapProfile.ATA_06_SATURN,
                            order = 6,
                            hasRing = true,
                            moonCount = new Vector2(7, 7),
                            validMoons = new string[]
                            {
                                ATAMapProfile.ATA_06_DIONE,
                                ATAMapProfile.ATA_06_ENCELADUS,
                                ATAMapProfile.ATA_06_IAPETUS,
                                ATAMapProfile.ATA_06_MIMAS,
                                ATAMapProfile.ATA_06_RHEA,
                                ATAMapProfile.ATA_06_TETHYS,
                                ATAMapProfile.ATA_06_TITAN
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_07_URANUS,
                            name = ATAMapProfile.ATA_07_URANUS,
                            order = 7,
                            moonCount = new Vector2(5, 5),
                            validMoons = new string[]
                            {
                                ATAMapProfile.ATA_07_ARIEL,
                                ATAMapProfile.ATA_07_MIRANDA,
                                ATAMapProfile.ATA_07_OBREON,
                                ATAMapProfile.ATA_07_TITANIA,
                                ATAMapProfile.ATA_07_UMBRIEL
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_08_NEPTUNE,
                            name = ATAMapProfile.ATA_08_NEPTUNE,
                            order = 8,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[]
                            {
                                ATAMapProfile.ATA_08_TRITON
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            memberType = StarSystemProfile.MemberType.Planet,
                            definitionSubtype = ATAMapProfile.ATA_09_PLUTO,
                            name = ATAMapProfile.ATA_09_PLUTO,
                            order = 9,
                            moonCount = new Vector2(1, 1),
                            validMoons = new string[]
                            {
                                ATAMapProfile.ATA_09_CHARON
                            }
                        }
                    }
                }
            }
        };

        public static string[] Keys()
        {
            return SYSTEMS_PROFILES.Keys.ToArray();
        }

        public static StarSystemProfile Get(string key, bool nullIfNotFound = false)
        {
            if (SYSTEMS_PROFILES.ContainsKey(key))
                return SYSTEMS_PROFILES[key];
            return nullIfNotFound ? null : SYSTEMS_PROFILES[DEFAULT_PROFILE];
        }

    }

}
