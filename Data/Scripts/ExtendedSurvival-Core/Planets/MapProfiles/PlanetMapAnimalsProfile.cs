using Sandbox.ModAPI;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class PlanetMapAnimalsProfile
    {

        public static readonly PlanetProfile.AnimalInfo DEFAULT_EARTH = new PlanetProfile.AnimalInfo()
        {
            types = MyAPIGateway.Session.Mods.Any(x => PlanetMapProfile.EARTHLIKE_ANIMALS_MODID == x.PublishedFileId) ? new string[] { "Wolf", "deer_bot", "deerbuck_bot", "Horse_Bot", "Cow_Bot", "Sheep_Bot" } : new string[] { "Wolf" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(2, 4)
            }
        };

        public static readonly PlanetProfile.AnimalInfo DEFAULT_WOLF = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "Wolf" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(2, 4)
            }
        };

        public static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_01 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpiderBrown", "SpaceSpiderBlack" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        public static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_02 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpider", "SpaceSpiderGreen" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        public static readonly PlanetProfile.AnimalInfo DEFAULT_SPIDERS_03 = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { "SpaceSpider", "SpaceSpiderGreen", "SpaceSpiderBrown", "SpaceSpiderBlack" },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(120000, 160000),
                spawnDist = new Vector2I(300, 400),
                waveCount = new Vector2I(1, 2)
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = true,
                spawnDelay = new Vector2I(60000, 120000),
                spawnDist = new Vector2I(250, 350),
                waveCount = new Vector2I(4, 8)
            }
        };

        public static readonly PlanetProfile.AnimalInfo DEFAULT_NO_ANIMALS = new PlanetProfile.AnimalInfo()
        {
            types = new string[] { },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                spawnDelay = Vector2I.Zero,
                spawnDist = Vector2I.Zero,
                waveCount = Vector2I.Zero
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                spawnDelay = Vector2I.Zero,
                spawnDist = Vector2I.Zero,
                waveCount = Vector2I.Zero
            }
        };

    }

}
