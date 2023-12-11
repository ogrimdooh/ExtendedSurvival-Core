using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public class PlanetProfile
    {

        public enum OreGroupType
        {

            LargeGroup = 0,
            SmallGroup = 1,
            LargeGroupShortSpace = 2,
            SmallGroupShortSpace = 3,
            Concentrated = 4

        }

        public enum OreRarity
        {

            None = 0,
            Common = 1,
            Uncommon = 2,
            Rare = 3,
            Epic = 4

        }

        public enum PlanetType
        {

            Planet = 0,
            Moon = 1,
            GiantGas = 2,
            Star = 4

        }

        public enum PlanetOrigin
        {

            NotDefined = 0,
            Vanila = 1,
            ExtendedSurvival = 2,
            OtherMod = 3

        }

        public struct OreMapInfo
        {

            public OreRarity rarity;
            public string type;
            public Vector2I start;
            public Vector2I depth;

        }

        public struct AnimalInfo
        {

            public string[] types;
            public AnimalSpawnInfo day;
            public AnimalSpawnInfo night;

        }

        public struct AnimalSpawnInfo
        {

            public bool enabled;
            public Vector2I spawnDelay;
            public Vector2I spawnDist;
            public Vector2I waveCount;

        }

        public struct GeothermalInfo
        {

            public bool enabled;
            public Vector2I start;
            public Vector2I rowSize;
            public Vector2 power;
            public Vector2 maxPower;
            public Vector2 increment;

        }

        public struct AtmosphereInfo
        {

            public bool enabled;
            public bool breathable;
            public float oxygenDensity;
            public float density;
            public float limitAltitude;
            public float maxWindSpeed;
            public float toxicLevel;
            public float radiationLevel;

        }

        public struct TemperatureInfo
        {

            public MyTemperatureLevel temperatureLevel;
            public Vector2 temperatureRange;

        }

        public struct GravityInfo
        {

            public float gravityFalloffPower;
            public float surfaceGravity;

        }

        public struct WaterInfo
        {

            public bool enabled;
            public float size;
            public float temperatureFactor;
            public float toxicLevel;
            public float radiationLevel;

        }

        public struct MeteorStonesInfo
        {

            public string groupId;
            public string modifierId;
            public float chanceToSpawn;

        }

        public struct MeteorImpactInfo
        {

            public bool enabled;
            public float chanceToSpawn;
            public MeteorStonesInfo[] stones;

        }

        public struct SuperficialMiningDropInfo
        {

            public UniqueEntityId itemId;
            public Vector2 ammount;
            public float chance;
            public bool alowFrac;
            public string[] validSubType;

        }

        public struct SuperficialMiningInfo
        {

            public bool enabled;
            public SuperficialMiningDropInfo[] drops;

        }

        public bool RespawnEnabled { get; set; }
        public PlanetOrigin Origin { get; set; }
        public ulong OriginId { get; set; }
        public AnimalInfo Animal { get; set; }
        public GeothermalInfo Geothermal { get; set; }
        public AtmosphereInfo Atmosphere { get; set; }
        public TemperatureInfo Temperature { get; set; }
        public GravityInfo Gravity { get; set; }
        public WaterInfo Water { get; set; }
        public MeteorImpactInfo MeteorImpact { get; set; }
        public SuperficialMiningInfo SuperficialMining { get; set; }
        public List<OreMapInfo> Ores { get; set; } = new List<OreMapInfo>();
        public string TargetColor { get; set; }
        public Vector2I ColorInfluence { get; set; } = Vector2I.Zero;
        public int Version { get; set; }
        public OreGroupType GroupType { get; set; } = OreGroupType.LargeGroup;
        public float OreMultiplier { get; set; } = 1.0f;
        public Vector2 SizeRange { get; set; } = new Vector2(30, 60);
        public PlanetType Type { get; set; } = PlanetType.Planet;

        public GravitySetting BuildGravitySetting()
        {
            return new GravitySetting()
            {
                SurfaceGravity = Gravity.surfaceGravity,
                GravityFalloffPower = Gravity.gravityFalloffPower
            };
        }

        public WaterSetting BuildWaterSetting()
        {
            return new WaterSetting()
            {
                Enabled = Water.enabled,
                Size = Water.size,
                TemperatureFactor = Water.temperatureFactor,
                ToxicLevel = Water.toxicLevel,
                RadiationLevel = Water.radiationLevel
            };
        }

        public AtmosphereSetting BuildAtmosphereSetting()
        {
            return new AtmosphereSetting()
            {
                Enabled = Atmosphere.enabled,
                Breathable = Atmosphere.breathable,
                OxygenDensity = Atmosphere.oxygenDensity,
                Density = Atmosphere.density,
                LimitAltitude = Atmosphere.limitAltitude,
                MaxWindSpeed = Atmosphere.maxWindSpeed,
                ToxicLevel = Atmosphere.toxicLevel,
                RadiationLevel = Atmosphere.radiationLevel,
                TemperatureLevel = (int)Temperature.temperatureLevel,
                TemperatureRange = new DocumentedVector2(Temperature.temperatureRange.X, Temperature.temperatureRange.Y, AtmosphereSetting.TEMPERATURE_RANGE_INFO)
            };
        }

        public GeothermalSetting BuildGeothermalSetting(float startMultiplier = 1, float rowMultiplier = 1, float powerMultiplier = 1)
        {
            if (Geothermal.enabled)
            {
                return new GeothermalSetting() 
                { 
                    Enabled = true,
                    Start = (float)Math.Round(Geothermal.start.GetRandom() * startMultiplier, 2),
                    RowSize = (float)Math.Round(Geothermal.rowSize.GetRandom() * rowMultiplier, 2),
                    Power = (float)Math.Round(Geothermal.power.GetRandom() * powerMultiplier, 2),
                    Increment = (float)Math.Round(Geothermal.increment.GetRandom() * powerMultiplier, 2),
                    MaxPower = (float)Math.Round(Geothermal.maxPower.GetRandom() * powerMultiplier, 2)
                };
            }
            else
                return new GeothermalSetting() { Enabled = false };
        }

        public PlanetMeteorImpactSetting BuildMeteorImpactSetting()
        {
            return new PlanetMeteorImpactSetting()
            {
                Enabled = MeteorImpact.enabled,
                ChanceToSpawn = MeteorImpact.chanceToSpawn,
                Stones = MeteorImpact.stones?.Select(x => new MeteorImpactStoneSetting()
                {
                    GroupId = x.groupId,
                    ModifierId = x.modifierId,
                    ChanceToSpawn = x.chanceToSpawn
                }).ToList() ?? new List<MeteorImpactStoneSetting>()
            };
        }

        public SuperficialMiningSetting BuildSuperficialMiningSetting(string name)
        {
            try
            {
                if (SuperficialMining.drops != null && SuperficialMining.drops.Any())
                {
                    return new SuperficialMiningSetting()
                    {
                        Enabled = SuperficialMining.enabled,
                        Drops = SuperficialMining.drops.Select(x => new SuperficialMiningDropSetting()
                        {
                            ItemId = x.itemId.DefinitionId,
                            Ammount = new DocumentedVector2(x.ammount.X, x.ammount.Y, SuperficialMiningDropSetting.AMMOUNT_RANGE_INFO),
                            AlowFrac = x.alowFrac,
                            Chance = x.chance,
                            ValidSubType = x.validSubType.Select(y => new SuperficialMiningDropValidSubTypeSetting() { Id = y }).ToList()
                        }).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Not manage to build Superficial Mining on planet {name}.");
            return new SuperficialMiningSetting() { Enabled = false };
        }

        private List<PlanetOreMapEntrySetting> BuildOresMappings(int seed, float deep, string[] addOres, string[] removeOres, 
            bool clearOresBeforeAdd, string targetColor, Vector2I? colorInfluence, OreGroupType groupType = OreGroupType.LargeGroup)
        {
            var maxEntries = 220;
            var maxFinalEntries = 30;
            var maxEntryId = 250;

            Random rand = new Random(seed);
            var map = new List<PlanetOreMapEntrySetting>();
            var calcOres = Ores.ToList();
            if (clearOresBeforeAdd)
            {
                calcOres.Clear();
            }
            else if (removeOres != null && removeOres.Length > 0)
            {
                calcOres.RemoveAll(x => removeOres.Contains(x.type));
            }
            if (addOres != null && addOres.Length > 0)
            {
                foreach (var ore in addOres)
                {
                    calcOres.Add(PlanetMapProfile.GetOreMap(ore));
                }
            }

            var colorToUse = TargetColor;
            if (!string.IsNullOrWhiteSpace(targetColor))
            {
                if (targetColor == "NULL")
                    colorToUse = "";
                else
                    colorToUse = targetColor;
            }

            var influenceToUse = colorInfluence.HasValue ? colorInfluence.Value : ColorInfluence;
            
            if (calcOres.Any())
            {

                var limit = 12;
                if (groupType == OreGroupType.LargeGroupShortSpace || groupType == OreGroupType.SmallGroupShortSpace)
                    limit = 11;

                if (calcOres.Count < limit && groupType != OreGroupType.Concentrated)
                {
                    int i = 0;
                    while (calcOres.Count < limit)
                    {
                        calcOres.Add(PlanetMapProfile.GetOreMap(calcOres[i].type));
                        i++;
                        if (i >= calcOres.Count)
                            i = 0;
                    }
                }
                if (calcOres.Count > 12)
                {
                    while (calcOres.Count > limit)
                    {
                        calcOres.RemoveAt(calcOres.Count - 1);
                    }
                }

                var oresByRarity = calcOres.GroupBy(x => x.rarity).ToDictionary(x => x.Key, y => y.ToList());
                // add common start entries
                if (oresByRarity.ContainsKey(OreRarity.Common) && groupType != OreGroupType.Concentrated)
                {
                    var oresToStart = oresByRarity[OreRarity.Common].Distinct();
                    int i = 0;
                    foreach (var ore in oresToStart)
                    {
                        map.Add(new PlanetOreMapEntrySetting()
                        {
                            Value = (byte)(maxEntries + (i * (maxFinalEntries / oresToStart.Count()))),
                            Type = ore.type,
                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                            ColorInfluence = influenceToUse.GetRandom(),
                            TargetColor = colorToUse
                        });
                        i++;
                    }
                }

                switch (groupType)
                {
                    case OreGroupType.LargeGroup:
                    case OreGroupType.LargeGroupShortSpace:

                        // add 2 entries to each common ore
                        if (oresByRarity.ContainsKey(OreRarity.Common))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Common])
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        // add 2 entries to each uncommon ore
                        if (oresByRarity.ContainsKey(OreRarity.Uncommon))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Uncommon])
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        // add 2 entries to each common ore
                        if (oresByRarity.ContainsKey(OreRarity.Common))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Common])
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        // add 4 entries to each Rare ore
                        if (oresByRarity.ContainsKey(OreRarity.Rare))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Rare])
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        // add 2 entries to each uncommon ore
                        if (oresByRarity.ContainsKey(OreRarity.Uncommon))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Uncommon])
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        // add 4 entries to each epic ore
                        if (oresByRarity.ContainsKey(OreRarity.Epic))
                        {
                            foreach (var ore in oresByRarity[OreRarity.Epic])
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                            }
                        }

                        break;
                    case OreGroupType.SmallGroup:
                    case OreGroupType.SmallGroupShortSpace:

                        // add 4 entries to each common ore
                        if (oresByRarity.ContainsKey(OreRarity.Common))
                        {
                            var c = 0;
                            foreach (var ore in calcOres.OrderBy(x => $"{(int)x.rarity}_{calcOres.IndexOf(x)}"))
                            {
                                for (int i = 0; i < (c < 4 ? 6 : (c < 8 ? 5 : (c < 9 ? 4 : 3))); i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = 0,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                }
                                c++;
                            }
                        }

                        break;
                    case OreGroupType.Concentrated:

                        var epicAmount = 2 * OreMultiplier;
                        var rareAmount = 2 * OreMultiplier;
                        var uncommonAmount = 3 * OreMultiplier;
                        var commonAmount = 3 * OreMultiplier;

                        /* Add 2 Epic and 3 Rare at start */
                        byte beginEpicRagePart1 = 20;
                        if (oresByRarity.ContainsKey(OreRarity.Rare) || oresByRarity.ContainsKey(OreRarity.Epic))
                        {
                            if (oresByRarity.ContainsKey(OreRarity.Rare))
                            {
                                foreach (var ore in oresByRarity[OreRarity.Rare])
                                {
                                    for (int i = 0; i < rareAmount; i++)
                                    {
                                        if (map.Count >= maxEntries)
                                            break;
                                        map.Add(new PlanetOreMapEntrySetting()
                                        {
                                            Value = beginEpicRagePart1,
                                            Type = ore.type,
                                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                            ColorInfluence = influenceToUse.GetRandom(),
                                            TargetColor = colorToUse
                                        });
                                        beginEpicRagePart1++;
                                    }
                                    beginEpicRagePart1 += 5;
                                }
                            }
                            if (oresByRarity.ContainsKey(OreRarity.Epic))
                            {
                                foreach (var ore in oresByRarity[OreRarity.Epic])
                                {
                                    for (int i = 0; i < epicAmount; i++)
                                    {
                                        if (map.Count >= maxEntries)
                                            break;
                                        map.Add(new PlanetOreMapEntrySetting()
                                        {
                                            Value = beginEpicRagePart1,
                                            Type = ore.type,
                                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                            ColorInfluence = influenceToUse.GetRandom(),
                                            TargetColor = colorToUse
                                        });
                                        beginEpicRagePart1++;
                                    }
                                    beginEpicRagePart1 += 5;
                                }
                            }
                        }

                        /* Add 4 each Common */
                        byte beginCommon = 50;
                        byte beginInc = 10;
                        if (oresByRarity.ContainsKey(OreRarity.Common))
                        {
                            byte c = 0;
                            foreach (var ore in oresByRarity[OreRarity.Common])
                            {
                                byte id = (byte)(beginCommon + (beginInc * c));
                                for (int i = 1; i <= commonAmount; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = id,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                    id++;
                                }
                                c++;
                            }
                        }

                        /* Add 3 each Uncommon */
                        byte beginUncommon = 150;
                        if (oresByRarity.ContainsKey(OreRarity.Uncommon))
                        {
                            byte c = 0;
                            foreach (var ore in oresByRarity[OreRarity.Uncommon])
                            {
                                byte id = (byte)(beginUncommon + (beginInc * c));
                                for (int i = 1; i <= uncommonAmount; i++)
                                {
                                    if (map.Count >= maxEntries)
                                        break;
                                    map.Add(new PlanetOreMapEntrySetting()
                                    {
                                        Value = id,
                                        Type = ore.type,
                                        Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                        Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                        ColorInfluence = influenceToUse.GetRandom(),
                                        TargetColor = colorToUse
                                    });
                                    id++;
                                }
                                c++;
                            }
                        }

                        /* Add 2 Epic / 3 Rare at end */
                        byte beginEpicRagePart2 = 220;
                        if (oresByRarity.ContainsKey(OreRarity.Rare) || oresByRarity.ContainsKey(OreRarity.Epic))
                        {
                            if (oresByRarity.ContainsKey(OreRarity.Rare))
                            {
                                foreach (var ore in oresByRarity[OreRarity.Rare])
                                {
                                    for (int i = 0; i < rareAmount; i++)
                                    {
                                        if (map.Count >= maxEntries)
                                            break;
                                        map.Add(new PlanetOreMapEntrySetting()
                                        {
                                            Value = beginEpicRagePart2,
                                            Type = ore.type,
                                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                            ColorInfluence = influenceToUse.GetRandom(),
                                            TargetColor = colorToUse
                                        });
                                        beginEpicRagePart2++;
                                    }
                                }
                                beginEpicRagePart2 += 5;
                            }
                            if (oresByRarity.ContainsKey(OreRarity.Epic))
                            {
                                foreach (var ore in oresByRarity[OreRarity.Epic])
                                {
                                    for (int i = 0; i < epicAmount; i++)
                                    {
                                        if (map.Count >= maxEntries)
                                            break;
                                        map.Add(new PlanetOreMapEntrySetting()
                                        {
                                            Value = beginEpicRagePart2,
                                            Type = ore.type,
                                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                                            ColorInfluence = influenceToUse.GetRandom(),
                                            TargetColor = colorToUse
                                        });
                                        beginEpicRagePart2++;
                                    }
                                }
                                beginEpicRagePart2 += 5;
                            }
                        }

                        break;
                }

                if (groupType != OreGroupType.Concentrated)
                {

                    // Add to max 55 entries
                    while (map.Count(x => x.Value == 0) < 55)
                    {
                        var ore = calcOres.OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                        if (map.Count >= maxEntries)
                            break;
                        map.Add(new PlanetOreMapEntrySetting()
                        {
                            Value = 0,
                            Type = ore.type,
                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                            ColorInfluence = influenceToUse.GetRandom(),
                            TargetColor = colorToUse
                        });
                    }

                    // Remove if over 55
                    while (map.Count(x => x.Value == 0) > 55)
                    {
                        map.RemoveAt(map.Count - 1);
                    }

                    // set the indexes
                    var commnAmount = (oresByRarity.ContainsKey(OreRarity.Common) ? oresByRarity[OreRarity.Common].Count : 0) + 1;
                    var amountNotIndexed = map.Count(x => x.Value == 0);
                    if (amountNotIndexed > 0)
                    {
                        var fractionValue = maxEntries / amountNotIndexed;
                        var startValue = fractionValue;
                        switch (groupType)
                        {
                            case OreGroupType.LargeGroup:
                            case OreGroupType.SmallGroup:
                                foreach (var item in map)
                                {
                                    if (item.Value == 0)
                                    {
                                        item.Value = (byte)startValue;
                                        startValue += fractionValue;
                                    }
                                }
                                break;
                            case OreGroupType.LargeGroupShortSpace:
                            case OreGroupType.SmallGroupShortSpace:
                                int comulativeIncrement = 0;
                                var internalFrac = fractionValue / 2;
                                var lastOre = map.FirstOrDefault().Type;
                                foreach (var item in map)
                                {
                                    if (item.Value == 0)
                                    {
                                        item.Value = (byte)startValue;
                                        if (lastOre == item.Type)
                                        {
                                            comulativeIncrement += internalFrac;
                                            startValue += internalFrac;
                                        }
                                        else
                                        {
                                            startValue += comulativeIncrement;
                                            comulativeIncrement = 0;
                                        }
                                        lastOre = item.Type;
                                    }
                                }
                                break;
                        }
                    }

                }
                else
                {
                    /* Remove ids acima do maximo */
                    while (map.Any(x => x.Value > maxEntryId))
                    {
                        var itemToRemove = map.Where(x => x.Value > maxEntryId).First();
                        map.Remove(itemToRemove);
                    }
                    /* Remove ids duplicados */
                    while (map.GroupBy(x => x.Value).Any(x => x.Count() > 1))
                    {
                        var itemToRemove = map.GroupBy(x => x.Value).Where(x => x.Count() > 1).First().First();
                        map.Remove(itemToRemove);
                    }
                }

            }
            return map;
        }

        public PlanetSetting UpgradeSettings(PlanetSetting settings)
        {
            if (settings != null)
            {                
                if (settings.Version <= 8)
                {
                    settings = BuildSettings(settings.Id, settings.Seed, settings.DeepMultiplier, settings.AddedOres?.Split(','), 
                        settings.RemovedOres?.Split(','), settings.ClearOresBeforeAdd, settings.TargetColor,
                        settings.UseColorInfluence ? (Vector2I?)settings.ColorInfluence.ToVector2I() : null,
                        (OreGroupType)settings.OreGroupType);
                }
                else if (settings.Version <= 13)
                {
                    var tmpSettings = BuildSettings(settings.Id, settings.Seed, settings.DeepMultiplier, settings.AddedOres?.Split(','), 
                        settings.RemovedOres?.Split(','), settings.ClearOresBeforeAdd, settings.TargetColor,
                        settings.UseColorInfluence ? (Vector2I?)settings.ColorInfluence.ToVector2I() : null,
                        (OreGroupType)settings.OreGroupType);
                    settings.OreMap = tmpSettings.OreMap;
                    settings.OreGroupType = tmpSettings.OreGroupType;
                }
                if (settings.Version <= 12)
                {
                    settings.MeteorImpact = BuildMeteorImpactSetting();
                }
                if (settings.Version <= 14)
                {
                    settings.SuperficialMining = BuildSuperficialMiningSetting(settings.Id);
                }
                if (settings.Version <= 15)
                {
                    var tmpSettings = BuildSettings(settings.Id, settings.Seed, settings.DeepMultiplier, settings.AddedOres?.Split(','), 
                        settings.RemovedOres?.Split(','), settings.ClearOresBeforeAdd, settings.TargetColor,
                        settings.UseColorInfluence ? (Vector2I?)settings.ColorInfluence.ToVector2I() : null,
                        GroupType);
                    settings.OreMap = tmpSettings.OreMap;
                    settings.OreGroupType = tmpSettings.OreGroupType;
                }
                settings.Version = Version;
            }
            return settings;
        }

        public PlanetAnimalSetting BuildAnimalsSetting()
        {
            return new PlanetAnimalSetting()
            {
                Animals = Animal.types.Select(x => new PlanetAnimalEntrySetting() { Id = x }).ToList(),
                DaySpawn = new PlanetAnimalSpawnSetting()
                {
                    Enabled = Animal.day.enabled,
                    SpawnDelay = Animal.day.spawnDelay,
                    SpawnDist = Animal.day.spawnDist,
                    WaveCount = Animal.day.waveCount
                },
                NightSpawn = new PlanetAnimalSpawnSetting()
                {
                    Enabled = Animal.night.enabled,
                    SpawnDelay = Animal.night.spawnDelay,
                    SpawnDist = Animal.night.spawnDist,
                    WaveCount = Animal.night.waveCount
                }
            };
        }

        public PlanetSetting BuildSettings(string id, int seed, float deep, string[] addOres, string[] removeOres, bool clearOresBeforeAdd, 
            string targetColor, Vector2I? colorInfluence, OreGroupType? groupType)
        {
            var validOresToAdd = PlanetMapProfile.FilterValidOres(addOres);
            var validOresToRemove = PlanetMapProfile.FilterValidOres(removeOres);
            return new PlanetSetting()
            {
                Id = id,
                UsingTechnology = ExtendedSurvivalCoreSession.IsUsingTechnology(),
                RespawnEnabled = RespawnEnabled,
                Seed = seed,
                DeepMultiplier = deep,
                AddedOres = string.Join(",", validOresToAdd),
                RemovedOres = string.Join(",", validOresToRemove),
                ClearOresBeforeAdd = clearOresBeforeAdd,
                UseColorInfluence = colorInfluence.HasValue,
                ColorInfluence = colorInfluence.HasValue ? 
                    new DocumentedVector2(colorInfluence.Value.X, colorInfluence.Value.Y, PlanetSetting.INFLUENCERANGE_INFO) :
                    new DocumentedVector2(0, 0, PlanetSetting.INFLUENCERANGE_INFO),
                TargetColor = targetColor,
                Version = Version,
                Type = (int)Type,
                SizeRange = new DocumentedVector2(SizeRange.X, SizeRange.Y, PlanetSetting.SIZERANGE_INFO),
                Geothermal = BuildGeothermalSetting(),
                Atmosphere = BuildAtmosphereSetting(),
                Water = BuildWaterSetting(),
                Gravity = BuildGravitySetting(),
                Animal = BuildAnimalsSetting(),
                MeteorImpact = BuildMeteorImpactSetting(),
                SuperficialMining = BuildSuperficialMiningSetting(id),
                OreGroupType = (int)(groupType.HasValue ? groupType.Value : GroupType),
                OreMap = BuildOresMappings(
                    seed, 
                    deep, 
                    PlanetMapProfile.GetValidOreKeys(validOresToAdd), 
                    PlanetMapProfile.GetValidOreKeys(validOresToRemove), 
                    clearOresBeforeAdd, 
                    targetColor, 
                    colorInfluence,
                    groupType.HasValue ? groupType.Value : GroupType
                )
            };
        }

    }

}
