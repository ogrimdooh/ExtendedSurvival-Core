using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class PlanetMapAnimalsProfile
    {

        public enum AnimalTimeToSpawn
        {

            All = 0,
            DayOnly = 1,
            NightOnly = 2

        }

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

        public const string Stone_Monster = "Stone_Monster";
        public const string Big_Stone_Monster = "Big_Stone_Monster";

        public const string Space_spider_worm = "Space_spider_worm";
        public const string Space_spider_hugeworm = "Space_spider_hugeworm";

        public const string SpaceSmallSpider = "SpaceSmallSpider";
        public const string SpaceSmallSpider_Green = "SpaceSmallSpider_Green";
        public const string SpaceSmallSpider_Brown = "SpaceSmallSpider_Brown";
        public const string SpaceSmallSpider_Black = "SpaceSmallSpider_Black";

        public const string DesertWolf = "DesertWolf";
        public const string DesertWolfPuppy = "DesertWolfPuppy";

        public struct AnimalDataInfo
        {
            public string Id;
            public bool IsAgressive;
            public AnimalTimeToSpawn TimeToSpawn;

            public AnimalDataInfo(string id, bool isAgressive, AnimalTimeToSpawn timeToSpawn)
            {
                Id = id;
                IsAgressive = isAgressive;
                TimeToSpawn = timeToSpawn;
            }
        }
        
        public static readonly Dictionary<string, AnimalDataInfo> ValidAnimals = new Dictionary<string, AnimalDataInfo>()
        {
            { 
                "wolf", 
                new AnimalDataInfo(Wolf, true, AnimalTimeToSpawn.NightOnly) 
            },
            { 
                "deer_bot", 
                new AnimalDataInfo(deer_bot, false, AnimalTimeToSpawn.All) 
            },
            { 
                "deerbuck_bot", 
                new AnimalDataInfo(deerbuck_bot, false, AnimalTimeToSpawn.All) 
            },
            { 
                "horse_bot", 
                new AnimalDataInfo(Horse_Bot, false, AnimalTimeToSpawn.DayOnly) 
            },
            { 
                "cow_bot", 
                new AnimalDataInfo(Cow_Bot, false, AnimalTimeToSpawn.DayOnly) 
            },
            { 
                "sheep_bot", 
                new AnimalDataInfo(Sheep_Bot, false, AnimalTimeToSpawn.DayOnly) 
            },
            { 
                "spacespiderbrown", 
                new AnimalDataInfo(SpaceSpiderBrown, true, AnimalTimeToSpawn.NightOnly) 
            },
            { 
                "spacespiderblack", 
                new AnimalDataInfo(SpaceSpiderBlack, true, AnimalTimeToSpawn.NightOnly) 
            },
            { 
                "spacespider", 
                new AnimalDataInfo(SpaceSpider, true, AnimalTimeToSpawn.All) 
            },
            { 
                "spacespidergreen", 
                new AnimalDataInfo(SpaceSpiderGreen, true, AnimalTimeToSpawn.DayOnly) 
            },
            { 
                "creature3", 
                new AnimalDataInfo(Creature3, true, AnimalTimeToSpawn.NightOnly) 
            },
            { 
                "explodingcreature", 
                new AnimalDataInfo(ExplodingCreature, true, AnimalTimeToSpawn.All) 
            },
            { 
                "alien_beast", 
                new AnimalDataInfo(Alien_Beast, true, AnimalTimeToSpawn.NightOnly) 
            },
            { 
                "lavapup", 
                new AnimalDataInfo(LavaPup, true, AnimalTimeToSpawn.DayOnly) 
            },
            { 
                "stone_monster", 
                new AnimalDataInfo(Stone_Monster, true, AnimalTimeToSpawn.All) 
            },
            { 
                "big_stone_monster", 
                new AnimalDataInfo(Big_Stone_Monster, true, AnimalTimeToSpawn.NightOnly) 
            },
            {
                "space_spider_worm",
                new AnimalDataInfo(Space_spider_worm, true, AnimalTimeToSpawn.All)
            },
            {
                "space_spider_hugeworm",
                new AnimalDataInfo(Space_spider_hugeworm, true, AnimalTimeToSpawn.NightOnly)
            },
            {
                "spacesmallspider_brown",
                new AnimalDataInfo(SpaceSmallSpider_Brown, true, AnimalTimeToSpawn.NightOnly)
            },
            {
                "spacesmallspider_black",
                new AnimalDataInfo(SpaceSmallSpider_Black, true, AnimalTimeToSpawn.NightOnly)
            },
            {
                "spacesmallspider",
                new AnimalDataInfo(SpaceSmallSpider, true, AnimalTimeToSpawn.All)
            },
            {
                "spacesmallspider_green",
                new AnimalDataInfo(SpaceSmallSpider_Green, true, AnimalTimeToSpawn.DayOnly)
            },
            {
                "desertwolf",
                new AnimalDataInfo(DesertWolf, true, AnimalTimeToSpawn.NightOnly)
            },
            {
                "desertwolfpuppy",
                new AnimalDataInfo(DesertWolfPuppy, true, AnimalTimeToSpawn.NightOnly)
            }
        };

        private static PlanetProfile.AnimalInfo BuildAnimalInfo(Dictionary<string, string[]> animals)
        {
            return new PlanetProfile.AnimalInfo()
            {
                types = animals.Select(x =>
                                        new PlanetProfile.AnimalEntryInfo()
                                        {
                                            id = x.Key,
                                            timeToSpawn = ValidAnimals[x.Key.ToLower()].TimeToSpawn,
                                            biomes = x.Value
                                        }
                                    ).ToArray(),
                day = new PlanetProfile.AnimalSpawnInfo()
                {
                    enabled = true,
                    huntCycleCountDownMultiplier = 1,
                    spawnCreatureAmountMultiplier = 1,
                    spawnCreatureDistanceMultiplier = 1
                },
                night = new PlanetProfile.AnimalSpawnInfo()
                {
                    enabled = true,
                    huntCycleCountDownMultiplier = 1,
                    spawnCreatureAmountMultiplier = 1,
                    spawnCreatureDistanceMultiplier = 1
                }
            };
        }

        // Empty

        public static readonly PlanetProfile.AnimalInfo DEFAULT_NO_ANIMALS = new PlanetProfile.AnimalInfo()
        {
            types = new PlanetProfile.AnimalEntryInfo[] { },
            day = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                huntCycleCountDownMultiplier = 1,
                spawnCreatureAmountMultiplier = 1,
                spawnCreatureDistanceMultiplier = 1
            },
            night = new PlanetProfile.AnimalSpawnInfo()
            {
                enabled = false,
                huntCycleCountDownMultiplier = 1,
                spawnCreatureAmountMultiplier = 1,
                spawnCreatureDistanceMultiplier = 1
            }
        };

        // Vanilla

        private static PlanetProfile.AnimalInfo? _DEFAULT_EARTH;
        public static PlanetProfile.AnimalInfo DEFAULT_EARTH
        {
            get
            {
                if (!_DEFAULT_EARTH.HasValue)
                {
                    var animals = new Dictionary<string, string[]>() 
                    { 
                        { 
                            Wolf, 
                            new string[] {
                                PlanetProfile.BiomeTypes.Forest,
                                PlanetProfile.BiomeTypes.Savanna
                            } 
                        } 
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingEarthLikeAnimals())
                    {
                        animals.Add(deer_bot, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(deerbuck_bot, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Horse_Bot, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Cow_Bot, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Sheep_Bot, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingDesertWolves())
                    {
                        animals.Add(DesertWolf, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(DesertWolfPuppy, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Savanna });
                    }
                    _DEFAULT_EARTH = BuildAnimalInfo(animals);
                }
                return _DEFAULT_EARTH.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_ALIEN;
        public static PlanetProfile.AnimalInfo DEFAULT_ALIEN
        {
            get
            {
                if (!_DEFAULT_ALIEN.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpider,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        },
                        {
                            SpaceSpiderGreen,
                            new string[] {
                                PlanetProfile.BiomeTypes.Forest
                            }
                        },
                        {
                            SpaceSpiderBrown,
                            new string[] {
                                PlanetProfile.BiomeTypes.Savanna
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Cliff,
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Creature3, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Alien_Beast, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(ExplodingCreature, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(LavaPup, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider, new string[] { PlanetProfile.BiomeTypes.Tundra });
                        animals.Add(SpaceSmallSpider_Green, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(SpaceSmallSpider_Brown, new string[] { PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Cliff, PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_ALIEN = BuildAnimalInfo(animals);
                }
                return _DEFAULT_ALIEN.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_MARS;
        public static PlanetProfile.AnimalInfo DEFAULT_MARS
        {
            get
            {
                if (!_DEFAULT_MARS.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpider,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(ExplodingCreature, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(LavaPup, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider, new string[] { PlanetProfile.BiomeTypes.Tundra });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_MARS = BuildAnimalInfo(animals);
                }
                return _DEFAULT_MARS.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_PERTAM;
        public static PlanetProfile.AnimalInfo DEFAULT_PERTAM
        {
            get
            {
                if (!_DEFAULT_PERTAM.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpiderBrown,
                            new string[] {
                                PlanetProfile.BiomeTypes.Savanna
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Cliff,
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Alien_Beast, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider_Brown, new string[] { PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Cliff, PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_PERTAM = BuildAnimalInfo(animals);
                }
                return _DEFAULT_PERTAM.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_TRITON;
        public static PlanetProfile.AnimalInfo DEFAULT_TRITON
        {
            get
            {
                if (!_DEFAULT_TRITON.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            Wolf,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        }
                    };
                    _DEFAULT_TRITON = BuildAnimalInfo(animals);
                }
                return _DEFAULT_TRITON.Value;
            }
        }

        // Extended Survival

        private static PlanetProfile.AnimalInfo? _DEFAULT_OI;
        public static PlanetProfile.AnimalInfo DEFAULT_OI
        {
            get
            {
                if (!_DEFAULT_OI.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpider,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(ExplodingCreature, new string[] { PlanetProfile.BiomeTypes.Volcanic });
                        animals.Add(LavaPup, new string[] { PlanetProfile.BiomeTypes.Volcanic });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert, PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider, new string[] { PlanetProfile.BiomeTypes.Tundra });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_OI = BuildAnimalInfo(animals);
                }
                return _DEFAULT_OI.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_ENITOR;
        public static PlanetProfile.AnimalInfo DEFAULT_ENITOR
        {
            get
            {
                if (!_DEFAULT_ENITOR.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpider,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        },
                        {
                            SpaceSpiderGreen,
                            new string[] {
                                PlanetProfile.BiomeTypes.Forest
                            }
                        },
                        {
                            SpaceSpiderBrown,
                            new string[] {
                                PlanetProfile.BiomeTypes.Savanna
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Cliff,
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Creature3, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Alien_Beast, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(ExplodingCreature, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(LavaPup, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider, new string[] { PlanetProfile.BiomeTypes.Tundra });
                        animals.Add(SpaceSmallSpider_Green, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(SpaceSmallSpider_Brown, new string[] { PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Cliff, PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_ENITOR = BuildAnimalInfo(animals);
                }
                return _DEFAULT_ENITOR.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_EREMUS_NUBIS;
        public static PlanetProfile.AnimalInfo DEFAULT_EREMUS_NUBIS
        {
            get
            {
                if (!_DEFAULT_EREMUS_NUBIS.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpider,
                            new string[] {
                                PlanetProfile.BiomeTypes.Tundra
                            }
                        },
                        {
                            SpaceSpiderBrown,
                            new string[] {
                                PlanetProfile.BiomeTypes.Savanna
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Creature3, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(Alien_Beast, new string[] { PlanetProfile.BiomeTypes.Forest, PlanetProfile.BiomeTypes.Savanna });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider, new string[] { PlanetProfile.BiomeTypes.Tundra });
                        animals.Add(SpaceSmallSpider_Brown, new string[] { PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_EREMUS_NUBIS = BuildAnimalInfo(animals);
                }
                return _DEFAULT_EREMUS_NUBIS.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_DOVER;
        public static PlanetProfile.AnimalInfo DEFAULT_DOVER
        {
            get
            {
                if (!_DEFAULT_DOVER.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            Wolf,
                            new string[] {
                                PlanetProfile.BiomeTypes.Forest
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingEarthLikeAnimals())
                    {
                        animals.Add(deer_bot, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(deerbuck_bot, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(Horse_Bot, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(Cow_Bot, new string[] { PlanetProfile.BiomeTypes.Forest });
                        animals.Add(Sheep_Bot, new string[] { PlanetProfile.BiomeTypes.Forest });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingDesertWolves())
                    {
                        animals.Add(DesertWolf, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(DesertWolfPuppy, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_DOVER = BuildAnimalInfo(animals);
                }
                return _DEFAULT_DOVER.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_TOTHT;
        public static PlanetProfile.AnimalInfo DEFAULT_TOTHT
        {
            get
            {
                if (!_DEFAULT_TOTHT.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpiderBrown,
                            new string[] {
                                PlanetProfile.BiomeTypes.Savanna
                            }
                        },
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Cliff,
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingAlienAnimals())
                    {
                        animals.Add(Alien_Beast, new string[] { PlanetProfile.BiomeTypes.Savanna });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Cliff });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider_Brown, new string[] { PlanetProfile.BiomeTypes.Savanna });
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Cliff, PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_TOTHT = BuildAnimalInfo(animals);
                }
                return _DEFAULT_TOTHT.Value;
            }
        }

        private static PlanetProfile.AnimalInfo? _DEFAULT_CAPUTALIS_NUBIS;
        public static PlanetProfile.AnimalInfo DEFAULT_CAPUTALIS_NUBIS
        {
            get
            {
                if (!_DEFAULT_CAPUTALIS_NUBIS.HasValue)
                {
                    var animals = new Dictionary<string, string[]>()
                    {
                        {
                            SpaceSpiderBlack,
                            new string[] {
                                PlanetProfile.BiomeTypes.Desert
                            }
                        }
                    };
                    if (ExtendedSurvivalCoreSession.IsUsingMartinTheMonster() || ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingMartinRevenge())
                    {
                        animals.Add(Big_Stone_Monster, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSandWorm())
                    {
                        animals.Add(Space_spider_worm, new string[] { PlanetProfile.BiomeTypes.Desert });
                        animals.Add(Space_spider_hugeworm, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    if (ExtendedSurvivalCoreSession.IsUsingSmallSpider())
                    {
                        animals.Add(SpaceSmallSpider_Black, new string[] { PlanetProfile.BiomeTypes.Desert });
                    }
                    _DEFAULT_CAPUTALIS_NUBIS = BuildAnimalInfo(animals);
                }
                return _DEFAULT_CAPUTALIS_NUBIS.Value;
            }
        }

        // Others

    }

}
