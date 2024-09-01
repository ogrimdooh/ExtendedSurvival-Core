using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class PlanetMapAnimalsProfile
    {

        public const string Wolf = "Wolf";
        public const string deer_bot = "deer_bot";
        public const string deerbuck_bot = "deerbuck_bot";
        public const string Horse_Bot = "Horse_Bot";
        public const string Cow_Bot = "Cow_Bot";
        public const string Sheep_Bot = "Sheep_Bot";
        public const string SpaceSpiderBrown = "SpaceSpiderBrown";
        public const string SpaceSpiderBlack = "SpaceSpiderBlack";
        public const string SpaceSpider = "SpaceSpider";
        public const string SpaceSpiderGreen = "SpaceSpiderGreen";

        public const string Creature3 = "Creature3";
        public const string ExplodingCreature = "ExplodingCreature";
        public const string Alien_Beast = "Alien_Beast";
        public const string LavaPup = "LavaPup";

        public static readonly Dictionary<string, string> ValidAnimals = new Dictionary<string, string>()
        {
            { "wolf", Wolf },
            { "deer_bot", deer_bot },
            { "deerbuck_bot", deerbuck_bot },
            { "horse_bot", Horse_Bot },
            { "cow_bot", Cow_Bot },
            { "sheep_bot", Sheep_Bot },
            { "spacespiderbrown", SpaceSpiderBrown },
            { "spacespiderblack", SpaceSpiderBlack },
            { "spacespider", SpaceSpider },
            { "spacespidergreen", SpaceSpiderGreen },
            { "creature3", Creature3 },
            { "explodingcreature", ExplodingCreature },
            { "alien_beast", Alien_Beast },
            { "lavapup", LavaPup }
        };

        private static PlanetProfile.AnimalInfo? _DEFAULT_EARTH;
        public static PlanetProfile.AnimalInfo DEFAULT_EARTH
        {
            get
            {
                if (!_DEFAULT_EARTH.HasValue)
                {
                    var animals = new List<string>() { Wolf };
                    if (ExtendedSurvivalCoreSession.IsUsingEarthLikeAnimals())
                    {
                        animals.Add(deer_bot);
                        animals.Add(deerbuck_bot);
                        animals.Add(Horse_Bot);
                        animals.Add(Cow_Bot);
                        animals.Add(Sheep_Bot);
                    }
                    _DEFAULT_EARTH = new PlanetProfile.AnimalInfo()
                    {
                        types = animals.ToArray(),
                        day = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(1200000, 1800000),
                            spawnDist = new Vector2I(300, 400),
                            waveCount = new Vector2I(1, 2)
                        },
                        night = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(600000, 900000),
                            spawnDist = new Vector2I(250, 350),
                            waveCount = new Vector2I(2, 3)
                        }
                    };
                }
                return _DEFAULT_EARTH.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_WOLF;
        public static PlanetProfile.AnimalInfo DEFAULT_WOLF
        {
            get
            {
                if (!_DEFAULT_WOLF.HasValue)
                {
                    _DEFAULT_WOLF = new PlanetProfile.AnimalInfo()
                    {
                        types = new string[] { Wolf },
                        day = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(1200000, 1800000),
                            spawnDist = new Vector2I(300, 400),
                            waveCount = new Vector2I(1, 2)
                        },
                        night = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(600000, 900000),
                            spawnDist = new Vector2I(250, 350),
                            waveCount = new Vector2I(2, 3)
                        }
                    };
                }
                return _DEFAULT_WOLF.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_SPIDERS_01;
        public static PlanetProfile.AnimalInfo DEFAULT_SPIDERS_01
        {
            get
            {
                if (!_DEFAULT_SPIDERS_01.HasValue)
                {
                    var animals = new List<string>() { SpaceSpiderBrown, SpaceSpiderBlack };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Creature3);
                        animals.Add(Alien_Beast);
                    }
                    _DEFAULT_SPIDERS_01 = new PlanetProfile.AnimalInfo()
                    {
                        types = animals.ToArray(),
                        day = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(1200000, 1800000),
                            spawnDist = new Vector2I(300, 400),
                            waveCount = new Vector2I(1, 2)
                        },
                        night = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(600000, 900000),
                            spawnDist = new Vector2I(250, 350),
                            waveCount = new Vector2I(2, 3)
                        }
                    };
                }
                return _DEFAULT_SPIDERS_01.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_SPIDERS_02;
        public static PlanetProfile.AnimalInfo DEFAULT_SPIDERS_02
        {
            get
            {
                if (!_DEFAULT_SPIDERS_02.HasValue)
                {
                    var animals = new List<string>() { SpaceSpider, SpaceSpiderGreen };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(ExplodingCreature);
                        animals.Add(LavaPup);
                    }
                    _DEFAULT_SPIDERS_02 = new PlanetProfile.AnimalInfo()
                    {
                        types = animals.ToArray(),
                        day = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(1200000, 1800000),
                            spawnDist = new Vector2I(300, 400),
                            waveCount = new Vector2I(1, 2)
                        },
                        night = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(600000, 900000),
                            spawnDist = new Vector2I(250, 350),
                            waveCount = new Vector2I(2, 3)
                        }
                    };
                }
                return _DEFAULT_SPIDERS_02.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_SPIDERS_03;
        public static PlanetProfile.AnimalInfo DEFAULT_SPIDERS_03
        {
            get
            {
                if (!_DEFAULT_SPIDERS_03.HasValue)
                {
                    var animals = new List<string>() { SpaceSpider, SpaceSpiderGreen, SpaceSpiderBrown, SpaceSpiderBlack };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Creature3);
                        animals.Add(Alien_Beast);
                        animals.Add(ExplodingCreature);
                        animals.Add(LavaPup);
                    }
                    _DEFAULT_SPIDERS_03 = new PlanetProfile.AnimalInfo()
                    {
                        types = new string[] { SpaceSpider, SpaceSpiderGreen, SpaceSpiderBrown, SpaceSpiderBlack },
                        day = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(1200000, 1800000),
                            spawnDist = new Vector2I(300, 400),
                            waveCount = new Vector2I(1, 2)
                        },
                        night = new PlanetProfile.AnimalSpawnInfo()
                        {
                            enabled = true,
                            spawnDelay = new Vector2I(600000, 900000),
                            spawnDist = new Vector2I(250, 350),
                            waveCount = new Vector2I(2, 3)
                        }
                    };
                }
                return _DEFAULT_SPIDERS_03.Value;
            }
        }

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
