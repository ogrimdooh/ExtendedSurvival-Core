using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public class PlanetProfile
    {

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

            public int ammount;
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
            public bool useRangeTemperature;

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
        public float ColorInfluence { get; set; }
        public int Version { get; set; }
        public int MaxGroupSize { get; set; } = 0;
        public int StartBreak { get; set; } = 0;
        public Vector2 SizeRange { get; set; } = new Vector2(30, 60);
        public PlanetType Type { get; set; } = PlanetType.Planet;
        public List<string> ParentPlanet { get; set; } = new List<string>();
        public Vector2I MoonCount { get; set; } = Vector2I.Zero;
        public int Order { get; set; }

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
                TemperatureRange = new DocumentedVector2(Temperature.temperatureRange.X, Temperature.temperatureRange.Y, AtmosphereSetting.TEMPERATURE_RANGE_INFO),
                UseRangeTemperature = Temperature.useRangeTemperature
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

        private List<PlanetOreMapEntrySetting> BuildOresMappings(int seed, float multiplier)
        {
            Random rand = new Random(seed);
            var map = new List<PlanetOreMapEntrySetting>();
            if (Ores.Any())
            {
                var finalores = Ores.Select(x => new OreMapInfo() { ammount = Math.Max((int)(x.ammount * multiplier), 1), type = x.type, start = x.start, depth = x.depth }).ToArray();
                var totalEntries = (byte)Math.Min(finalores.Sum(x => x.ammount), 255);
                byte intervalo = (byte)(255 / totalEntries);
                byte value = 0;
                var count = new Dictionary<string, int>();
                var oresKeys = finalores.Select(x => x.type).Distinct().ToList();
                foreach (var item in oresKeys)
                {
                    count.Add(item, 0);
                }
                var keyIndex = 0;
                var internalCount = 0;
                var incrementBreak = oresKeys.Count;
                var doInitialBreak = false;
                for (int i = 0; i < totalEntries; i++)
                {
                    value += intervalo;
                    var type = oresKeys[keyIndex];
                    count[type]++;
                    var info = finalores.FirstOrDefault(x => x.type == type);
                    if (count[type] >= info.ammount)
                        oresKeys.Remove(type);
                    map.Add(new PlanetOreMapEntrySetting()
                    {
                        Value = value,
                        Type = type,
                        Start = rand.Next(info.start.X, info.start.Y),
                        Depth = rand.Next(info.depth.X, info.depth.Y),
                        ColorInfluence = ColorInfluence,
                        TargetColor = TargetColor
                    });
                    if (oresKeys.Count == 0)
                        break;
                    if (!oresKeys.Any(x => x == type) || internalCount >= MaxGroupSize || i < StartBreak)
                    {
                        if (i >= StartBreak && !doInitialBreak)
                        {
                            doInitialBreak = true;
                            keyIndex = 0;
                        }
                        else
                        {
                            keyIndex++;
                        }
                        internalCount = 0;
                    }
                    else
                        internalCount++;
                    if (keyIndex >= oresKeys.Count)
                        keyIndex = 0;
                }
            }
            return map;
        }

        public PlanetSetting UpgradeSettings(PlanetSetting settings)
        {
            if (settings != null)
            {
                if (settings.Version < 6)
                {
                    settings.RespawnEnabled = RespawnEnabled;
                }
                if (settings.Version < 7)
                {
                    if (Origin == PlanetOrigin.OtherMod && ATAMapProfile.ATA_MOD_IDS.Contains(OriginId))
                    {
                        settings = BuildSettings(settings.Id, settings.Seed, settings.Multiplier);
                    }
                    else
                    {
                        settings.Type = (int)Type;
                        settings.Order = Order;
                        settings.MoonCount = new DocumentedVector2(MoonCount.X, MoonCount.Y, PlanetSetting.MOONCOUNT_INFO);
                        settings.SizeRange = new DocumentedVector2(SizeRange.X, SizeRange.Y, PlanetSetting.SIZERANGE_INFO);
                        settings.Parents = GetParents();
                    }
                }
                settings.Version = Version;
            }
            return settings;
        }

        public List<PlanetParentEntrySetting> GetParents()
        {
            return ParentPlanet.Select(x => new PlanetParentEntrySetting() { Id = x }).ToList();
        }

        public PlanetSetting BuildSettings(string id, int seed, float multiplier)
        {
            return new PlanetSetting()
            {
                Id = id,
                UsingTechnology = ExtendedSurvivalCoreSession.IsUsingTechnology(),
                RespawnEnabled = RespawnEnabled,
                Seed = seed,
                Multiplier = multiplier,
                Version = Version,
                Type = (int)Type,
                Order = Order,
                MoonCount = new DocumentedVector2(MoonCount.X, MoonCount.Y, PlanetSetting.MOONCOUNT_INFO),
                SizeRange = new DocumentedVector2(SizeRange.X, SizeRange.Y, PlanetSetting.SIZERANGE_INFO),
                Parents = GetParents(),
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
                OreMap = BuildOresMappings(seed, multiplier)
            };
        }

    }

}
