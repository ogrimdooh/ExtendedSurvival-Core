﻿using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public class PlanetProfile
    {

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

        public bool RespawnEnabled { get; set; }
        public PlanetOrigin Origin { get; set; }
        public ulong OriginId { get; set; }
        public AnimalInfo Animal { get; set; }
        public GeothermalInfo Geothermal { get; set; }
        public AtmosphereInfo Atmosphere { get; set; }
        public TemperatureInfo Temperature { get; set; }
        public GravityInfo Gravity { get; set; }
        public WaterInfo Water { get; set; }
        public List<OreMapInfo> Ores { get; set; } = new List<OreMapInfo>();
        public string TargetColor { get; set; }
        public Vector2I ColorInfluence { get; set; } = Vector2I.Zero;
        public int Version { get; set; }
        public int MaxGroupSize { get; set; } = 0;
        public int StartBreak { get; set; } = 0;
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

        private List<PlanetOreMapEntrySetting> BuildOresMappings(int seed, float multiplier, float deep, string[] addOres = null, string[] removeOres = null)
        {
            var maxEntries = 220;
            var maxFinalEntries = 30;

            Random rand = new Random(seed);
            var map = new List<PlanetOreMapEntrySetting>();
            var calcOres = Ores.ToList();
            if (removeOres != null && removeOres.Length > 0)
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
            if (calcOres.Any())
            {

                var oresByRarity = calcOres.GroupBy(x => x.rarity).ToDictionary(x => x.Key, y => y.ToList());
                // add common start entries
                if (oresByRarity.ContainsKey(OreRarity.Common))
                {
                    int i = 0;
                    foreach (var ore in oresByRarity[OreRarity.Common])
                    {
                        map.Add(new PlanetOreMapEntrySetting()
                        {
                            Value = (byte)(maxEntries + (i * (maxFinalEntries / oresByRarity[OreRarity.Common].Count))),
                            Type = ore.type,
                            Start = new Vector2I(ore.start.X, ore.start.Y).GetRandom() * deep,
                            Depth = new Vector2I(ore.depth.X, ore.depth.Y).GetRandom() * deep,
                            ColorInfluence = ColorInfluence.GetRandom(),
                            TargetColor = TargetColor
                        });
                        i++;
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
                            });
                        }
                    }
                }

                // add 4 entries to each common ore
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
                            });
                        }
                    }
                }

                // add 4 entries to each common ore
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
                                ColorInfluence = ColorInfluence.GetRandom(),
                                TargetColor = TargetColor
                            });
                        }
                    }
                }

                // set the indexes
                var commnAmount = (oresByRarity.ContainsKey(OreRarity.Common) ? oresByRarity[OreRarity.Common].Count : 0) + 1;
                var amountNotIndexed = map.Count(x => x.Value == 0);
                if (amountNotIndexed > 0)
                {
                    var fractionValue = (maxEntries - commnAmount) / amountNotIndexed;
                    var startValue = fractionValue;
                    foreach (var item in map)
                    {
                        if (item.Value == 0)
                        {
                            item.Value = (byte)startValue;
                            startValue += fractionValue;
                        }
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
                    settings = BuildSettings(settings.Id, settings.Seed, settings.Multiplier, settings.DeepMultiplier, settings.AddedOres?.Split(','), settings.RemovedOres?.Split(','));
                } else if (settings.Version <= 9)
                {
                    var tmpSettings = BuildSettings(settings.Id, settings.Seed, settings.Multiplier, settings.DeepMultiplier, settings.AddedOres?.Split(','), settings.RemovedOres?.Split(','));
                    settings.OreMap = tmpSettings.OreMap;
                }
                settings.Version = Version;
            }
            return settings;
        }

        public PlanetSetting BuildSettings(string id, int seed, float multiplier, float deep, string[] addOres = null, string[] removeOres = null)
        {
            var validOresToAdd = PlanetMapProfile.FilterValidOres(addOres);
            var validOresToRemove = PlanetMapProfile.FilterValidOres(removeOres);
            return new PlanetSetting()
            {
                Id = id,
                UsingTechnology = ExtendedSurvivalCoreSession.IsUsingTechnology(),
                RespawnEnabled = RespawnEnabled,
                Seed = seed,
                Multiplier = multiplier,
                DeepMultiplier = deep,
                AddedOres = string.Join(",", validOresToAdd),
                RemovedOres = string.Join(",", validOresToRemove),
                Version = Version,
                Type = (int)Type,
                SizeRange = new DocumentedVector2(SizeRange.X, SizeRange.Y, PlanetSetting.SIZERANGE_INFO),
                Geothermal = BuildGeothermalSetting(),
                Atmosphere = BuildAtmosphereSetting(),
                Water = BuildWaterSetting(),
                Gravity = BuildGravitySetting(),
                Animal = new PlanetAnimalSetting()
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
                },
                OreMap = BuildOresMappings(seed, multiplier, deep, PlanetMapProfile.GetValidOreKeys(validOresToAdd), PlanetMapProfile.GetValidOreKeys(validOresToRemove))
            };
        }

    }

}
