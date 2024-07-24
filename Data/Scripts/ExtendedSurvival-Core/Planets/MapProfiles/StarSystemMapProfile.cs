using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class StarSystemMapProfile
    {

        public const int PROFILES_VERSION = 2;
        public const string DEFAULT_PROFILE = "RANDOM";
        public const string VANILLA_PROFILE = "VANILLA";
        public const string EXTENDEDSURVIVAL_PROFILE = "ES";
        public const string EXTENDEDSURVIVAL_COMPLETE_PROFILE = "VANILLAES";
        public const string ATA_PROFILE = "ATA";
        public const string ALKURAH_PROFILE = "ALKURAH";
        public const string ALKURAH_PROFILEV2 = "ALKURAHV2";
        public const string ESSERVER_PROFILE = "ESSERVER";

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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            Name = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            Order = 0,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            {
                                VanilaMapProfile.DEFAULT_MOON 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_TRITON,
                            Name = VanilaMapProfile.DEFAULT_TRITON,
                            Order = 1
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_MARS,
                            Name = VanilaMapProfile.DEFAULT_MARS,
                            Order = 2,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            {
                                VanilaMapProfile.DEFAULT_EUROPA 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Kuiper Belt",
                            Order = 3,
                            Density = 0.65f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_ALIEN,
                            Name = VanilaMapProfile.DEFAULT_ALIEN,
                            Order = 4,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_TITAN
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_PERTAM,
                            Name = VanilaMapProfile.DEFAULT_PERTAM,
                            Order = 5
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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Order = 0,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Order = 1,
                            HasRing = true
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Order = 2,
                            MoonCount = new Vector2(2, 2),
                            ValidMoons = new string[] 
                            { 
                                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS, 
                                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Arcaris Belt",
                            Order = 3,
                            Density = 0.85f                            
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Order = 4,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Order = 0,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Order = 1,
                            HasRing = true
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            Name = VanilaMapProfile.DEFAULT_EARTHLIKE,
                            Order = 2,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_MOON
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_TRITON,
                            Name = VanilaMapProfile.DEFAULT_TRITON,
                            Order = 3
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Order = 4,
                            MoonCount = new Vector2(2, 2),
                            ValidMoons = new string[] 
                            { 
                                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS, 
                                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Arcaris Belt",
                            Order = 5,
                            Density = 0.85f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_MARS,
                            Name = VanilaMapProfile.DEFAULT_MARS,
                            Order = 6,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            { 
                                VanilaMapProfile.DEFAULT_EUROPA 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Order = 7,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] { ExtendedSurvivalMapProfile.DEFAULT_OI }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_ALIEN,
                            Name = VanilaMapProfile.DEFAULT_ALIEN,
                            Order = 8,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] { VanilaMapProfile.DEFAULT_TITAN }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_PERTAM,
                            Name = VanilaMapProfile.DEFAULT_PERTAM,
                            Order = 9
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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_01_MERCURY,
                            Name = ATAMapProfile.ATA_01_MERCURY,
                            Order = 0
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_02_VENUS,
                            Name = ATAMapProfile.ATA_02_VENUS,
                            Order = 1
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_03_EARTH,
                            Name = ATAMapProfile.ATA_03_EARTH,
                            Order = 2,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[] 
                            { 
                                ATAMapProfile.ATA_03_MOON 
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_04_MARS,
                            Name = ATAMapProfile.ATA_04_MARS,
                            Order = 3
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Kuiper Belt",
                            Order = 4,
                            Density = 0.65f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_05_JUPITER,
                            Name = ATAMapProfile.ATA_05_JUPITER,
                            Order = 5,
                            MoonCount = new Vector2(4, 4),
                            ValidMoons = new string[] 
                            { 
                                ATAMapProfile.ATA_05_CALLISTO,
                                ATAMapProfile.ATA_05_EUROPA,
                                ATAMapProfile.ATA_05_GANYMEDE,
                                ATAMapProfile.ATA_05_IO
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_06_SATURN,
                            Name = ATAMapProfile.ATA_06_SATURN,
                            Order = 6,
                            HasRing = true,
                            MoonCount = new Vector2(7, 7),
                            ValidMoons = new string[]
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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_07_URANUS,
                            Name = ATAMapProfile.ATA_07_URANUS,
                            Order = 7,
                            MoonCount = new Vector2(5, 5),
                            ValidMoons = new string[]
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
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_08_NEPTUNE,
                            Name = ATAMapProfile.ATA_08_NEPTUNE,
                            Order = 8,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                ATAMapProfile.ATA_08_TRITON
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ATAMapProfile.ATA_09_PLUTO,
                            Name = ATAMapProfile.ATA_09_PLUTO,
                            Order = 9,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                ATAMapProfile.ATA_09_CHARON
                            }
                        }
                    }
                }
            },
            {
                ESSERVER_PROFILE,
                new StarSystemProfile()
                {
                    Name = ESSERVER_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = true,
                    VanillaAsteroids = false,
                    DefaultDensity = 0.75f,
                    DistanceMultiplier = 1.25f,
                    AllowDuplicate = false,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.None,
                    StarName = BalmungMapProfile.DEFAULT_BLACKHOLE,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ElindisMapProfile.DEFAULT_PYKE,
                            Name = ElindisMapProfile.DEFAULT_PYKE,
                            Order = 0,
                            MoonCount = Vector2.Zero
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_ENITOR,
                            Order = 1,
                            HasRing = true
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_DOVER,
                            Order = 2,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_EREMUS_NUBIS,
                            Order = 3,
                            MoonCount = new Vector2(2, 2),
                            ValidMoons = new string[]
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_GLEDIUS_NUBIS,
                                ExtendedSurvivalMapProfile.DEFAULT_CAPUTALIS_NUBIS
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Arcaris Belt",
                            Order = 4,
                            Density = 0.85f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = RheaLiciousMapProfile.DEFAULT_MILA,
                            Name = RheaLiciousMapProfile.DEFAULT_MILA,
                            Order = 5,
                            MoonCount = new Vector2(2, 2),
                            ValidMoons = new string[]
                            {
                                MLTModsMapProfile.DEFAULT_SEDONIA,
                                CaptainArthurMapProfile.DEFAULT_CRAIT
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Name = ExtendedSurvivalMapProfile.DEFAULT_TOTHT,
                            Order = 6,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_OI
                            }
                        }
                    }
                }
            },
            {
                ALKURAH_PROFILE,
                new StarSystemProfile()
                {
                    Name = ALKURAH_PROFILE,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = false,
                    VanillaAsteroids = true,
                    DefaultDensity = 0.15f,
                    DistanceMultiplier = 1.25f,
                    AllowDuplicate = false,
                    FirstMemberAtCenter = true,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.None,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = MajorJonMapProfile.DEFAULT_LUMA,
                            Name = MajorJonMapProfile.DEFAULT_LUMA,
                            Order = 0,
                            MoonCount = new Vector2(3, 3),
                            ValidMoons = new string[]
                            {
                                MajorJonMapProfile.DEFAULT_KIMI,
                                MajorJonMapProfile.DEFAULT_QUN,
                                MajorJonMapProfile.DEFAULT_TOHIL
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "Alkurah Belt",
                            Order = 1,
                            Density = 0.85f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = MajorJonMapProfile.DEFAULT_TEALWM,
                            Name = MajorJonMapProfile.DEFAULT_TEAL,
                            Order = 2,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                MajorJonMapProfile.DEFAULT_TRELAN
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = MajorJonMapProfile.DEFAULT_SATREUS,
                            Name = MajorJonMapProfile.DEFAULT_SATREUS,
                            Order = 3,
                            HasRing = true
                        }
                    }
                }
            },
            {
                ALKURAH_PROFILEV2,
                new StarSystemProfile()
                {
                    Name = ALKURAH_PROFILEV2,
                    Version = PROFILES_VERSION,
                    Type = StarSystemProfile.ProfileType.Mapped,
                    WithStar = false,
                    VanillaAsteroids = true,
                    DefaultDensity = 0.15f,
                    DistanceMultiplier = 1.25f,
                    AllowDuplicate = false,
                    FirstMemberAtCenter = true,
                    PlanetProfile = StarSystemProfile.ValidPlanetProfile.None,
                    Members = new List<StarSystemProfile.SystemMember>()
                    {
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = MajorJonMapProfile.DEFAULT_LUMA,
                            Name = "LUMA",
                            Order = 0,
                            SizeMultiplier = 1.5f,
                            MoonCount = new Vector2(4, 4),
                            ValidMoons = new string[]
                            {
                                MajorJonMapProfile.DEFAULT_KIMI,
                                MajorJonMapProfile.DEFAULT_QUN,
                                InfiniteMapProfile.DEFAULT_PENUMBRA,
                                ExtendedSurvivalMapProfile.DEFAULT_OI
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.AsteroidBelt,
                            Name = "ALKURAH BELT",
                            Order = 1,
                            Density = 0.85f
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = SamMapProfile.DEFAULT_HELIOSTERRAFORMEDWM,
                            Name = "HELIOS",
                            Order = 2,
                            HasRing = true,
                            Density = 0.85f,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                ExtendedSurvivalMapProfile.DEFAULT_SPATAT
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_TRITON,
                            Name = VanilaMapProfile.DEFAULT_TRITON,
                            Order = 3,
                            MoonCount = new Vector2(1, 1),
                            ValidMoons = new string[]
                            {
                                VanilaMapProfile.DEFAULT_MOON
                            }
                        },
                        new StarSystemProfile.SystemMember()
                        {
                            MemberType = StarSystemProfile.MemberType.Planet,
                            DefinitionSubtype = VanilaMapProfile.DEFAULT_PERTAM,
                            Name = VanilaMapProfile.DEFAULT_PERTAM,
                            Order = 4
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
