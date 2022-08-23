using System.Collections.Generic;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class ATAMapProfile
    {

        public const ulong ATA_MODID = 1697074695;

        public const string ATA_00_SUN = "ATA 00 SUN";
        public const string ATA_01_MERCURY = "ATA 01 MERCURY";
        public const string ATA_02_VENUS = "ATA 02 VENUS";
        public const string ATA_03_EARTH = "ATA 03 EARTH";
        public const string ATA_03_MOON = "ATA 03.MOON";
        public const string ATA_04_MARS = "ATA 04 Mars";
        public const string ATA_05_JUPITER = "ATA 05 Jupiter";
        public const string ATA_05_CALLISTO = "ATA 05....Callisto";
        public const string ATA_05_GANYMEDE = "ATA 05...Ganymede";
        public const string ATA_05_EUROPA = "ATA 05..Europa";
        public const string ATA_05_IO = "ATA 05.Io";
        public const string ATA_06_SATURN = "ATA 06 Saturn";
        public const string ATA_06_IAPETUS = "ATA 06.......Iapetus";
        public const string ATA_06_TITAN = "ATA 06......Titan";
        public const string ATA_06_RHEA = "ATA 06.....Rhea";
        public const string ATA_06_DIONE = "ATA 06....Dione";
        public const string ATA_06_TETHYS = "ATA 06...Tethys";
        public const string ATA_06_ENCELADUS = "ATA 06..Enceladus";
        public const string ATA_06_MIMAS = "ATA 06.Mimas";
        public const string ATA_07_URANUS = "ATA 07 Uranus";
        public const string ATA_07_OBREON = "ATA 07.....Obreon";
        public const string ATA_07_TITANIA = "ATA 07....Titania";
        public const string ATA_07_UMBRIEL = "ATA 07...Umbriel";
        public const string ATA_07_ARIEL = "ATA 07..Ariel";
        public const string ATA_07_MIRANDA = "ATA 07.Miranda";
        public const string ATA_08_NEPTUNE = "ATA 08 Neptune";
        public const string ATA_08_TRITON = "ATA 08.Triton";
        public const string ATA_09_PLUTO = "ATA 09 Pluto";
        public const string ATA_09_CHARON = "ATA 09.Charon";

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
                null,
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
                    PlanetMapProfile.Sulfor_01
                },
                new string[]
                {
                     PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                     PlanetMapProfile.Potassium_01
                },
                null,
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
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.Lead_01,
                    PlanetMapProfile.Sulfor_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Cobalt_01
                },
                null
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
                null
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
                    PlanetMapProfile.Silicon_01
                },
                new string[]
                {
                    PlanetMapProfile.StoneIce_01,
                    PlanetMapProfile.Sulfor_01,
                    PlanetMapProfile.Carbon_01
                },
                new string[]
                {
                    PlanetMapProfile.Potassium_01,
                    PlanetMapProfile.Platinum_01
                },
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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
                null
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

        // Planets
        public static readonly PlanetProfile ATA_00_SUN_PROFILE = new PlanetProfile()
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.1f, rowSizeMultiplier: 0.25f, powerMultiplier: 5f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 170, 1000, 2.5f, 5f),
            Gravity = PlanetMapProfile.GetGravity(28f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 1250, 5600, true),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(750, 1000),
            Type = PlanetProfile.PlanetType.Star
        };

        public static readonly PlanetProfile ATA_01_MERCURY_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            Animal = PlanetMapAnimalsProfile.DEFAULT_NO_ANIMALS,
            Geothermal = PlanetMapProfile.GetGeothermal(true, depthMultiplier: 0.5f, rowSizeMultiplier: 0.5f, powerMultiplier: 1.25f),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, false, 1f, 0, 15, 5, 0.25f, 0.15f),
            Gravity = PlanetMapProfile.GetGravity(0.38f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 120, 360, true),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 45),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 1,
            MaxGroupSize = 5,
            StartBreak = 3,
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
            Gravity = PlanetMapProfile.GetGravity(0.9f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeHot, 420, 980, true),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(80, 100),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 2,
            MaxGroupSize = 5,
            StartBreak = 3,
            Ores = ATA_02_VENUS_ORES
        };

        public static readonly PlanetProfile ATA_03_EARTH_PROFILE = new PlanetProfile() 
        {
            Origin = PlanetProfile.PlanetOrigin.OtherMod,
            OriginId = ATA_MODID,
            Version = PlanetMapProfile.PROFILE_VERSION,
            RespawnEnabled = false,
            Animal = PlanetMapAnimalsProfile.DEFAULT_EARTH,
            Geothermal = PlanetMapProfile.GetGeothermal(true),
            Atmosphere = PlanetMapProfile.GetAtmosphere(true, true, 1, 0.9f, 372, 5, 0, 0),
            Gravity = PlanetMapProfile.GetGravity(1, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Cozy, 0, 45),
            Water = PlanetMapProfile.GetWater(true, 1.025f, -0.4f, 0, 0),
            SizeRange = new Vector2(100, 120),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(1, 1),
            Order = 3,
            MaxGroupSize = 5,
            StartBreak = 5,
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
            Gravity = PlanetMapProfile.GetGravity(0.25f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(30, 50),
            Type = PlanetProfile.PlanetType.Moon,
            ParentPlanet = new List<string>() { ATA_03_EARTH },
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(0.38f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.Freeze, -10, 10),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(70, 90),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(0, 0),
            Order = 4,
            MaxGroupSize = 5,
            StartBreak = 5,
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
            Gravity = PlanetMapProfile.GetGravity(1.25f, 1.3f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(450, 550),
            Type = PlanetProfile.PlanetType.GiantGas,
            MoonCount = new Vector2I(4, 4),
            Order = 5,
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_05_JUPITER },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_05_JUPITER },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_05_JUPITER },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_05_JUPITER },
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(1.05f, 1.6f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(350, 450),
            Type = PlanetProfile.PlanetType.GiantGas,
            MoonCount = new Vector2I(7, 7),
            Order = PlanetMapProfile.PROFILE_VERSION,
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(0.1228f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(20, 30),
            Type = PlanetProfile.PlanetType.Moon,
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            SizeRange = new Vector2(40, 60),
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_06_SATURN },
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(1f, 1.7f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(400, 500),
            Type = PlanetProfile.PlanetType.GiantGas,
            MoonCount = new Vector2I(5, 5),
            Order = 7,
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_07_URANUS },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_07_URANUS },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_07_URANUS },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_07_URANUS },
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_07_URANUS },
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(1f, 1.8f),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(250, 350),
            Type = PlanetProfile.PlanetType.GiantGas,
            MoonCount = new Vector2I(1, 1),
            Order = 8,
            MaxGroupSize = 5,
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
            SizeRange = new Vector2(25, 45),
            Type = PlanetProfile.PlanetType.Moon,
            ParentPlanet = new List<string>() { ATA_08_NEPTUNE },
            MaxGroupSize = 5,
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
            Gravity = PlanetMapProfile.GetGravity(0.6f, 1),
            Temperature = PlanetMapProfile.GetTemperature(VRage.Game.MyTemperatureLevel.ExtremeFreeze, -50, 0),
            Water = PlanetMapProfile.GetWater(false),
            SizeRange = new Vector2(25, 35),
            Type = PlanetProfile.PlanetType.Planet,
            MoonCount = new Vector2I(1, 1),
            Order = 5,
            MaxGroupSize = 5,
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
            ParentPlanet = new List<string>() { ATA_09_PLUTO },
            MaxGroupSize = 5,
            StartBreak = 2,
            Ores = ATA_09_CHARON_ORES
        };

    }

}
