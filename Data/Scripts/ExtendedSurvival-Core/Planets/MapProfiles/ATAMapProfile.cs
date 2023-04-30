using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ATAMapProfile
    {

        public const ulong ATA_MODID = 1697074695;
        public const ulong ATA_STARS_MODID = 1557881032;

        public static readonly ulong[] ATA_MOD_IDS = new ulong[] { ATA_MODID, ATA_STARS_MODID };

        public const string ATA_00_SUN = "ATA 00 SUN";
        public const string ATA_01_MERCURY = "ATA 01 MERCURY";
        public const string ATA_02_VENUS = "ATA 02 VENUS";
        public const string ATA_03_EARTH = "ATA 03 EARTH";
        public const string ATA_03_MOON = "ATA 03.MOON";
        public const string ATA_04_MARS = "ATA 04 MARS";
        public const string ATA_05_JUPITER = "ATA 05 JUPITER";
        public const string ATA_05_CALLISTO = "ATA 05....CALLISTO";
        public const string ATA_05_GANYMEDE = "ATA 05...GANYMEDE";
        public const string ATA_05_EUROPA = "ATA 05..EUROPA";
        public const string ATA_05_IO = "ATA 05.IO";
        public const string ATA_06_SATURN = "ATA 06 SATURN";
        public const string ATA_06_IAPETUS = "ATA 06.......IAPETUS";
        public const string ATA_06_TITAN = "ATA 06......TITAN";
        public const string ATA_06_RHEA = "ATA 06.....RHEA";
        public const string ATA_06_DIONE = "ATA 06....DIONE";
        public const string ATA_06_TETHYS = "ATA 06...TETHYS";
        public const string ATA_06_ENCELADUS = "ATA 06..ENCELADUS";
        public const string ATA_06_MIMAS = "ATA 06.MIMAS";
        public const string ATA_07_URANUS = "ATA 07 URANUS";
        public const string ATA_07_OBREON = "ATA 07.....OBREON";
        public const string ATA_07_TITANIA = "ATA 07....TITANIA";
        public const string ATA_07_UMBRIEL = "ATA 07...UMBRIEL";
        public const string ATA_07_ARIEL = "ATA 07..ARIEL";
        public const string ATA_07_MIRANDA = "ATA 07.MIRANDA";
        public const string ATA_08_NEPTUNE = "ATA 08 NEPTUNE";
        public const string ATA_08_TRITON = "ATA 08.TRITON";
        public const string ATA_09_PLUTO = "ATA 09 PLUTO";
        public const string ATA_09_CHARON = "ATA 09.CHARON";

        public const string ATA_STAR_002 = "S 002Kº M DXCANCRI - RED";
        public const string ATA_STAR_TEST = "S TEST";
        public const string ATA_STAR_147 = "S 147Kº X SAGUITARIUSA - BLACK";
        public const string ATA_STAR_057 = "S 057Kº W VELORUM - MAGENTA";
        public const string ATA_STAR_029 = "S 029Kº O ALNITAK - BLUE";
        public const string ATA_STAR_022 = "S 022Kº B BELLATRIX - CYAN";
        public const string ATA_STAR_010 = "S 010Kº A VEGA - WHITE";
        public const string ATA_STAR_007 = "S 007Kº F DRACONIS - GREEN";
        public const string ATA_STAR_005 = "S 005Kº G TAUCETI - YELLOW";
        public const string ATA_STAR_003 = "S 003Kº K LACAILLE - ORANGE";

        // Ore maps

        public static readonly List<PlanetProfile.OreMapInfo> ATA_01_MERCURY_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01
                },
                new string[]
                {
                     PlanetMapProfile.Tungsten_01
                },
                multiplierUncommon: 2f
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_02_VENUS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01,
                    PlanetMapProfile.Sulfur_01
                },
                new string[]
                {
                     PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                     PlanetMapProfile.Potassium_01
                },
                new string[]
                {
                     PlanetMapProfile.Iridium_01
                },
                multiplierUncommon: 2f
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_03_EARTH_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Silicon_01,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Potassium_01
                },
                new string[]
                {
                    PlanetMapProfile.Cobalt_01
                },
                multiplierCommon: 0.5f,
                multiplierLegendary: 1.25f
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_03_MOON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_04_MARS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfur_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                new string[]
                {
                     PlanetMapProfile.Iridium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Magnesium_01,
                    PlanetMapProfile.Cobalt_01,
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_05_CALLISTO_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                     PlanetMapProfile.Plutonium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_05_GANYMEDE_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                     PlanetMapProfile.Plutonium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_05_EUROPA_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                     PlanetMapProfile.Plutonium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_05_IO_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                     PlanetMapProfile.Plutonium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_IAPETUS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Zinc_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Iridium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_TITAN_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Silicon_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_RHEA_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Beryllium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_DIONE_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_TETHYS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_ENCELADUS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_06_MIMAS_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_07_OBREON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Copper_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_07_TITANIA_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_07_UMBRIEL_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Tungsten_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_07_ARIEL_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Aluminum_01,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Mercury_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_07_MIRANDA_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Tungsten_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_08_TRITON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Aluminum_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Beryllium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_09_PLUTO_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01
                },
                new string[]
                {
                    PlanetMapProfile.Carbon_01,
                    PlanetMapProfile.Potassium_01
                },
                new string[]
                {
                    PlanetMapProfile.Uraninite_01
                },
                new string[]
                {
                     PlanetMapProfile.Titanium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        public static readonly List<PlanetProfile.OreMapInfo> ATA_09_CHARON_ORES =
            ExtendedSurvivalCoreSession.IsUsingTechnology() ?
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Copper_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Gold_01
                },
                new string[]
                {
                    PlanetMapProfile.Lithium_01
                },
                new string[]
                {
                    PlanetMapProfile.Titanium_01
                }
            ) :
            PlanetMapProfile.BuildOreMap(
                new string[]
                {
                    PlanetMapProfile.Iron_02,
                    PlanetMapProfile.Nickel_01,
                    PlanetMapProfile.Silicon_01
                },
                null,
                new string[]
                {
                    PlanetMapProfile.Gold_01,
                    PlanetMapProfile.Silver_01,
                    PlanetMapProfile.Platinum_01,
                    PlanetMapProfile.Uraninite_01
                },
                null
            );

        // Stars

        public static readonly PlanetProfile ATA_STAR_PROFILE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_STARS_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.1f, rowSizeMultiplier: 0.25f, powerMultiplier: 5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 170, 1000, 2.5f, 5f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 1250, 5600),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(120, 120),
            Type = PlanetProfile.PlanetType.Star
        };

        public static readonly PlanetProfile ATA_SUN_PROFILE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.1f, rowSizeMultiplier: 0.25f, powerMultiplier: 5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 170, 1000, 2.5f, 5f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 1250, 5600),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(40, 40),
            Type = PlanetProfile.PlanetType.Star
        };

        //Planets
        public static readonly PlanetProfile ATA_01_MERCURY_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.5f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 15, 5, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.38f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 120, 360),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 50),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 4,
            Ores = ATA_01_MERCURY_ORES
        };

        public static readonly PlanetProfile ATA_02_VENUS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1f, rowSizeMultiplier: 0.5f, powerMultiplier: 0.75f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 380, 5, 0.5f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(0.9f, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 420, 980),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(55, 75),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 4,
            Ores = ATA_02_VENUS_ORES
        };

        public static readonly PlanetProfile ATA_03_EARTH_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = true,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 372, 5, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 4),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.025f, -0.4f, 0, 0),
            SizeRange = new Vector2(60, 80),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 6,
            Ores = ATA_03_EARTH_ORES
        };

        public static readonly PlanetProfile ATA_03_MOON_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.25f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(35, 45),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_03_MOON_ORES
        };

        public static readonly PlanetProfile ATA_04_MARS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_SPIDERS_02,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 1.5f, rowSizeMultiplier: 1.25f, powerMultiplier: 0.5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 80, 2, 0.25f, 0f),
            Gravity = PlanetMapProfile.GetGravity(0.38f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(50, 70),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 4,
            Ores = ATA_04_MARS_ORES
        };

        public static readonly PlanetProfile ATA_05_JUPITER_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.75f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 580, 5, 0.5f, 0.75f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(120, 120),
            Type = PlanetProfile.PlanetType.GiantGas,
            MaxGroupSize = 2,
            StartBreak = 3
        };

        public static readonly PlanetProfile ATA_05_CALLISTO_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.126f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(40, 50),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_05_CALLISTO_ORES
        };

        public static readonly PlanetProfile ATA_05_GANYMEDE_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.134f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(45, 55),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_05_GANYMEDE_ORES
        };

        public static readonly PlanetProfile ATA_05_EUROPA_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.134f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 40),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_05_EUROPA_ORES
        };

        public static readonly PlanetProfile ATA_05_IO_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.183f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 40),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_05_IO_ORES
        };

        public static readonly PlanetProfile ATA_06_SATURN_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 580, 5, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(120, 120),
            Type = PlanetProfile.PlanetType.GiantGas,
            MaxGroupSize = 2,
            StartBreak = 3
        };

        public static readonly PlanetProfile ATA_06_IAPETUS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1215f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_IAPETUS_ORES
        };

        public static readonly PlanetProfile ATA_06_TITAN_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.138f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            Type = PlanetProfile.PlanetType.Moon,
            SizeRange = new Vector2(35, 55),
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_TITAN_ORES
        };

        public static readonly PlanetProfile ATA_06_RHEA_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1269f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_RHEA_ORES
        };

        public static readonly PlanetProfile ATA_06_DIONE_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1236f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_DIONE_ORES
        };

        public static readonly PlanetProfile ATA_06_TETHYS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1148f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_TETHYS_ORES
        };

        public static readonly PlanetProfile ATA_06_ENCELADUS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1113f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_ENCELADUS_ORES
        };

        public static readonly PlanetProfile ATA_06_MIMAS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.10648f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_06_MIMAS_ORES
        };

        public static readonly PlanetProfile ATA_07_URANUS_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 350, 5, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(120, 120),
            Type = PlanetProfile.PlanetType.GiantGas,
            MaxGroupSize = 2,
            StartBreak = 3
        };

        public static readonly PlanetProfile ATA_07_OBREON_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1387f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_07_OBREON_ORES
        };

        public static readonly PlanetProfile ATA_07_TITANIA_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1387f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_07_TITANIA_ORES
        };

        public static readonly PlanetProfile ATA_07_UMBRIEL_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1235f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_07_UMBRIEL_ORES
        };

        public static readonly PlanetProfile ATA_07_ARIEL_PROFILE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.127f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_07_ARIEL_ORES
        };

        public static readonly PlanetProfile ATA_07_MIRANDA_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.108f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_07_MIRANDA_ORES
        };

        public static readonly PlanetProfile ATA_08_NEPTUNE_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 350, 5, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(25f, 10f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(120, 120),
            Type = PlanetProfile.PlanetType.GiantGas,
            MaxGroupSize = 2,
            StartBreak = 3
        };
        public static readonly PlanetProfile ATA_08_TRITON_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.1387f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(35, 50),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_08_TRITON_ORES
        };
        public static readonly PlanetProfile ATA_09_PLUTO_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0f, 10, 5, 0.15f, 0.05f),
            Gravity = PlanetMapProfile.GetGravity(0.6f, 2),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Planet,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_09_PLUTO_ORES
        };
        public static readonly PlanetProfile ATA_09_CHARON_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(false),
            Atmosphere = PlanetMapProfile.GetAtmosphere(false),
            Gravity = PlanetMapProfile.GetGravity(0.3f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(15, 25),
            Type = PlanetProfile.PlanetType.Moon,
            MaxGroupSize = 2,
            StartBreak = 2,
            Ores = ATA_09_CHARON_ORES
        };

    }

}
