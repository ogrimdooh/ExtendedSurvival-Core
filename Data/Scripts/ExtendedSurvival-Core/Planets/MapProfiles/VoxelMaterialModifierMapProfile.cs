using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Core
{
    public static class VoxelMaterialModifierMapProfile
    {

        public const string DEFAULT_PROFILE = "DEFAULT";
        public const int PROFILE_VERSION = 11;

        public const string Snow = "Snow";
        public const string Stone = "Stone";
        public const string Iron = "Iron";
        public const string DesertRocks = "DesertRocks";
        public const string MarsRocks = "MarsRocks";
        public const string MoonRocks = "MoonRocks";
        public const string IceEuropa2 = "IceEuropa2";
        public const string AlienRockyMountain = "AlienRockyMountain";
        public const string AlienSnow = "AlienSnow";

        public const string EarthSnowArea = "EarthSnowArea";
        public const string EarthForestArea = "EarthForestArea";
        public const string EarthDesertArea = "EarthDesertArea";
        public const string Mars = "Mars";
        public const string Moon = "Moon";
        public const string Europa = "Europa";
        public const string Titan = "Titan";
        public const string AlienDesertArea = "AlienDesertArea";
        public const string AlienIcelandArea = "AlienIcelandArea";
        public const string AlienForestArea = "AlienForestArea";

        public const string Oi = "Oi";
        public const string Spatat = "Spatat";

        public const string grass01 = "grass01";
        public const string snow01 = "snow01";

        public const float NOCHANGE_VANILLA = 0.25f;
        public const float NOCHANGE_ES = 0.1f;

        private static List<VoxelMaterialModifierProfile.Option> BuildOptions(string stoneReplace, string snowReplace, params string[] ironReplaces)
        {
            var retorno = new List<VoxelMaterialModifierProfile.Option>();
            if (!string.IsNullOrWhiteSpace(stoneReplace))
            {
                retorno.Add(new VoxelMaterialModifierProfile.Option()
                {
                    From = Stone,
                    To = stoneReplace,
                    Default = true
                });
            }
            if (!string.IsNullOrWhiteSpace(snowReplace))
            {
                retorno.Add(new VoxelMaterialModifierProfile.Option()
                {
                    From = Snow,
                    To = snowReplace,
                    Default = true
                });
            }
            foreach (var replace in ironReplaces)
            {
                retorno.Add(new VoxelMaterialModifierProfile.Option()
                {
                    From = Iron,
                    To = replace
                });
            }
            return retorno;
        }

        public static string[] BuildDefaultESOres(params string[] bonus)
        {
            return (new string[] {
                PlanetMapProfile.Aluminum_01,
                PlanetMapProfile.Nickel_01,
                PlanetMapProfile.Zinc_01,
                PlanetMapProfile.Copper_01,
                PlanetMapProfile.Silicon_01,
                PlanetMapProfile.Sulfur_01,
                PlanetMapProfile.Carbon_01,
                PlanetMapProfile.Lead_01,
                PlanetMapProfile.Potassium_01
            }).Concat(bonus).ToArray();
        }

        public static readonly string[] DEFAULT_VANILLA_OPTIONS = new string[] {
            PlanetMapProfile.Nickel_01,
            PlanetMapProfile.Silicon_01,
            PlanetMapProfile.Cobalt_01,
            PlanetMapProfile.Gold_01,
            PlanetMapProfile.Silver_01,
            PlanetMapProfile.Magnesium_01,
            PlanetMapProfile.Ice_01
        };

        public static readonly string[] IGNORE_LIST = new string[] {
            grass01,
            snow01
        };

        public static readonly string[] PLANETS_WITH_STONES = new string[] {
            VanilaMapProfile.DEFAULT_EARTHLIKE,
            VanilaMapProfile.DEFAULT_MARS,
            VanilaMapProfile.DEFAULT_ALIEN,
            VanilaMapProfile.DEFAULT_TITAN,
            VanilaMapProfile.DEFAULT_MOON,
            VanilaMapProfile.DEFAULT_EUROPA,
            ExtendedSurvivalMapProfile.DEFAULT_OI,
            ExtendedSurvivalMapProfile.DEFAULT_SPATAT
        };

        public static readonly Dictionary<string, VoxelMaterialModifierProfile> PROFILES = new Dictionary<string, VoxelMaterialModifierProfile>()
        {
            {
                DEFAULT_PROFILE,
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(null, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Cobalt_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                EarthSnowArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(null, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Cobalt_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                EarthForestArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(null, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Cobalt_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                EarthDesertArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(DesertRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Cobalt_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Mars.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(MarsRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Platinum_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Moon.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(MoonRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Mercury_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Europa.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(IceEuropa2, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Mercury_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Titan.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(MarsRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Mercury_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                AlienDesertArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(AlienRockyMountain, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Uraninite_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                AlienIcelandArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(AlienRockyMountain, AlienSnow,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Uraninite_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                AlienForestArea.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(AlienRockyMountain, AlienSnow,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Uraninite_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Spatat.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(MoonRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Mercury_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            },
            {
                Oi.ToUpper(),
                new VoxelMaterialModifierProfile()
                {
                    Version = PROFILE_VERSION,
                    NoChangeChance = ExtendedSurvivalCoreSession.IsUsingTechnology() ? NOCHANGE_ES : NOCHANGE_VANILLA,
                    Options = BuildOptions(MarsRocks, null,
                        ExtendedSurvivalCoreSession.IsUsingTechnology() ?
                        BuildDefaultESOres(PlanetMapProfile.Uraninite_01) :
                        DEFAULT_VANILLA_OPTIONS
                    )
                }
            }
        };

        public static VoxelMaterialModifierProfile Get(string key)
        {
            key = key.ToUpper();
            if (PROFILES.ContainsKey(key))
                return PROFILES[key];
            return PROFILES[DEFAULT_PROFILE];
        }

    }

}
