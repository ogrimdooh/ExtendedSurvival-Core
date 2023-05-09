using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ExtendedSurvivalSettings : BaseSettings
    {

        private const int CURRENT_VERSION = 2;
        private const string FILE_NAME = "ExtendedSurvival.Core.Settings.xml";

        private static ExtendedSurvivalSettings _instance;
        public static ExtendedSurvivalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        [XmlElement]
        public bool Debug { get; set; } = false;

        [XmlElement]
        public bool DinamicWoodGridEnabled { get; set; } = false;

        [XmlElement]
        public bool DinamicStoneGridEnabled { get; set; } = false;

        [XmlElement]
        public bool DinamicConcreteGridEnabled { get; set; } = false;

        [XmlElement]
        public bool RotEnabled { get; set; } = true;

        [XmlElement]
        public bool DisableWaterModFreeIce { get; set; } = true;

        [XmlElement]
        public bool RespawnSpacePodEnabled { get; set; } = false;

        [XmlElement]
        public int PlanetDeployAltitude { get; set; } = 6;

        [XmlElement]
        public int MoonDeployAltitude { get; set; } = 6;

        [XmlElement]
        public int DropContainerDeployHeight { get; set; } = 1000;

        [XmlElement]
        public TradeStationSetting TradeStations { get; set; } = new TradeStationSetting();

        [XmlElement]
        public MeteorImpactSetting MeteorImpact { get; set; } = new MeteorImpactSetting();

        [XmlArray("Planets"), XmlArrayItem("Planet", typeof(PlanetSetting))]
        public List<PlanetSetting> Planets { get; set; } = new List<PlanetSetting>();

        [XmlArray("VoxelMaterials"), XmlArrayItem("VoxelMaterial", typeof(VoxelMaterialSetting))]
        public List<VoxelMaterialSetting> VoxelMaterials { get; set; } = new List<VoxelMaterialSetting>();

        [XmlArray("MaterialModifiers"), XmlArrayItem("MaterialModifier", typeof(VoxelMaterialModifierSetting))]
        public List<VoxelMaterialModifierSetting> MaterialModifiers { get; set; } = new List<VoxelMaterialModifierSetting>();

        [XmlElement]
        public StarSystemGlobalSetting StarSystemConfiguration { get; set; } = new StarSystemGlobalSetting();

        [XmlArray("StarSystems"), XmlArrayItem("StarSystem", typeof(StarSystemSetting))]
        public List<StarSystemSetting> StarSystems { get; set; } = new List<StarSystemSetting>();
        
        [XmlElement]
        public string IgnorePlanets { get; set; } = "SYSTEMTESTMAP;EARTHLIKEMODEXAMPLE;MARSTUTORIAL;MOONTUTORIAL;EARTHLIKETUTORIAL";

        private static bool Validate(ExtendedSurvivalSettings settings)
        {
            var res = true;
            return res;
        }

        private static ExtendedSurvivalSettings Upgrade(ExtendedSurvivalSettings settings)
        {
            if (settings.Version < 2)
            {
                var keys = StarSystemMapProfile.SYSTEMS_PROFILES.Keys.Select(x => x.ToUpper()).ToArray();
                settings.StarSystems.RemoveAll(x => keys.Contains(x.Name.ToUpper()));
            }
            return settings;
        }

        public static ExtendedSurvivalSettings Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); }, Upgrade);
            return _instance;
        }

        public static void ClientLoad(string data)
        {
            _instance = GetData<ExtendedSurvivalSettings>(data);
        }

        public string GetDataToClient()
        {
            return GetData(this);
        }

        public static void Save()
        {
            try
            {
                Save<ExtendedSurvivalSettings>(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        public ExtendedSurvivalSettings()
        {

        }

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();

        }

        public bool HasPlanetInfo(string id)
        {
            return Planets.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool HasMaterialModifierInfo(string id)
        {
            return MaterialModifiers.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool PlanetUsingTecnologyForFirstTime(string id)
        {
            return ExtendedSurvivalCoreSession.IsUsingTechnology() && Planets.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim() && !x.UsingTechnology);
        }

        public bool VoxelUsingTecnologyForFirstTime(string id)
        {
            return ExtendedSurvivalCoreSession.IsUsingTechnology() && VoxelMaterials.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim() && !x.UsingTechnology);
        }

        public bool HasStarSystem(string id)
        {
            return StarSystems.Any(x => x.Name.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public VoxelMaterialModifierSetting GetMaterialModifierInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasMaterialModifierInfo(id))
            {
                var settings = MaterialModifiers.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                var starProfile = VoxelMaterialModifierMapProfile.Get(settings.Id);
                if (starProfile != null)
                    settings = starProfile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                var starProfile = VoxelMaterialModifierMapProfile.Get(id);
                if (starProfile != null)
                {
                    var settings = starProfile.BuildSettings(id);
                    MaterialModifiers.Add(settings);
                    return settings;
                }
            }
            return null;
        }

        public StarSystemSetting GetStarSystemInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasStarSystem(id))
            {
                var settings = StarSystems.FirstOrDefault(x => x.Name.ToUpper().Trim() == id.ToUpper().Trim());
                var starProfile = StarSystemMapProfile.Get(settings.Name, true);
                if (starProfile != null)
                    settings = starProfile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                var starProfile = StarSystemMapProfile.Get(id);
                if (starProfile != null)
                {
                    var settings = starProfile.BuildSettings();
                    StarSystems.Add(settings);
                    return settings;
                }
            }
            return null;
        }

        public PlanetSetting GetPlanetInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasPlanetInfo(id) && !PlanetUsingTecnologyForFirstTime(id))
            {
                var settings = Planets.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                if (!IgnorePlanets.Split(';').Contains(id.ToUpper()))
                {
                    var profile = PlanetMapProfile.Get(id.ToUpper());
                    if (profile != null && profile.Version > settings.Version)
                        settings = profile.UpgradeSettings(settings);
                }
                return settings;
            }
            else if (generateWhenNotExists)
            {
                if (!IgnorePlanets.Split(';').Contains(id.ToUpper()))
                    return GeneratePlanetInfo(id, MyUtils.GetRandomInt(10000000, int.MaxValue), 1.0f, id.ToUpper(), true, GenerateFlags.All,
                        null, null, false, null, null);
            }
            return null;
        }

        [Flags]
        public enum GenerateFlags
        {

            None = 0,
            Atmosphere = 1 << 1,
            Geothermal = 1 << 2,
            Gravity = 1 << 3,
            Water = 1 << 4,
            Animal = 1 << 5,
            OreMap = 1 << 6,
            All = Atmosphere | Geothermal | Gravity | Water | Animal | OreMap

        }

        public PlanetSetting GeneratePlanetInfo(string id, int seed, float deep, string profile, bool force, 
            GenerateFlags replaceFlag, string[] addOres, string[] removeOres,  bool clearOresBeforeAdd, string targetColor, 
            Vector2I? colorInfluence)
        {
            if (!HasPlanetInfo(id) || force)
            {
                var settings = PlanetMapProfile.Get(profile).BuildSettings(id, seed, deep, addOres, removeOres, clearOresBeforeAdd, 
                    targetColor, colorInfluence);
                if (HasPlanetInfo(id))
                {
                    var atSet = Planets.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                    if ((GenerateFlags.Atmosphere & replaceFlag) != 0)
                    {
                        atSet.Atmosphere = settings.Atmosphere;
                    }
                    if ((GenerateFlags.Geothermal & replaceFlag) != 0)
                    {
                        atSet.Geothermal = settings.Geothermal;
                    }
                    if ((GenerateFlags.Gravity & replaceFlag) != 0)
                    {
                        atSet.Gravity = settings.Gravity;
                    }
                    if ((GenerateFlags.Animal & replaceFlag) != 0)
                    {
                        atSet.Animal = settings.Animal;
                    }
                    if ((GenerateFlags.Water & replaceFlag) != 0)
                    {
                        atSet.Water = settings.Water;
                    }
                    if ((GenerateFlags.OreMap & replaceFlag) != 0)
                    {
                        atSet.Seed = settings.Seed;
                        atSet.ClearOresBeforeAdd = settings.ClearOresBeforeAdd;
                        atSet.TargetColor = settings.TargetColor;
                        atSet.UseColorInfluence = settings.UseColorInfluence;
                        atSet.ColorInfluence = settings.ColorInfluence;
                        atSet.DeepMultiplier = settings.DeepMultiplier;
                        atSet.AddedOres = settings.AddedOres;
                        atSet.RemovedOres = settings.RemovedOres;
                        atSet.OreMap = settings.OreMap;
                    }
                }
                else
                {
                    Planets.Add(settings);
                }
                return settings;
            }
            return GetPlanetInfo(id, false);
        }

        public bool ProcessPlanetGravityInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Gravity = copyProfile.BuildGravitySetting();
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "surfacegravity":
                                    float surfacegravity = 0;
                                    if (float.TryParse(options[1], out surfacegravity))
                                    {
                                        info.Gravity.SurfaceGravity = surfacegravity;
                                    }
                                    break;
                                case "gravityfalloffpower":
                                    float gravityfalloffpower = 0;
                                    if (float.TryParse(options[1], out gravityfalloffpower))
                                    {
                                        info.Gravity.GravityFalloffPower = gravityfalloffpower;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetAtmosphereInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Atmosphere = copyProfile.BuildAtmosphereSetting();
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.Atmosphere.Enabled = enabled;
                                    }
                                    break;
                                case "breathable":
                                    bool breathable = false;
                                    if (bool.TryParse(options[1], out breathable))
                                    {
                                        info.Atmosphere.Breathable = breathable;
                                    }
                                    break;
                                case "oxygendensity":
                                    float oxygendensity = 0;
                                    if (float.TryParse(options[1], out oxygendensity) && oxygendensity >= 0 && oxygendensity <= 1)
                                    {
                                        info.Atmosphere.OxygenDensity = oxygendensity;
                                    }
                                    break;
                                case "density":
                                    float density = 0;
                                    if (float.TryParse(options[1], out density) && density >= 0 && density <= 1)
                                    {
                                        info.Atmosphere.Density = density;
                                    }
                                    break;
                                case "limitaltitude":
                                    float limitaltitude = 0;
                                    if (float.TryParse(options[1], out limitaltitude))
                                    {
                                        info.Atmosphere.LimitAltitude = limitaltitude;
                                    }
                                    break;
                                case "maxwindspeed":
                                    float maxwindspeed = 0;
                                    if (float.TryParse(options[1], out maxwindspeed))
                                    {
                                        info.Atmosphere.MaxWindSpeed = maxwindspeed;
                                    }
                                    break;
                                case "temperaturelevel":
                                    int temperaturelevel = 0;
                                    if (int.TryParse(options[1], out temperaturelevel) && 
                                        temperaturelevel >= 0 && temperaturelevel <= 4)
                                    {
                                        info.Atmosphere.TemperatureLevel = temperaturelevel;
                                    }
                                    break;
                                case "temperaturerange":
                                    var temperaturerange = options[1].Split('|');
                                    if (temperaturerange.Length >= 2)
                                    {
                                        float temperaturerange_from = 0;
                                        float temperaturerange_to = 0;
                                        if (float.TryParse(temperaturerange[0], out temperaturerange_from) &&
                                            float.TryParse(temperaturerange[1], out temperaturerange_to))
                                        {
                                            if (temperaturerange_from <= temperaturerange_to)
                                            {
                                                info.Atmosphere.TemperatureRange.X = temperaturerange_from;
                                                info.Atmosphere.TemperatureRange.Y = temperaturerange_to;
                                            }
                                        }
                                    }
                                    break;
                                case "toxiclevel":
                                    float toxiclevel = 0;
                                    if (float.TryParse(options[1], out toxiclevel))
                                    {
                                        info.Atmosphere.ToxicLevel = toxiclevel;
                                    }
                                    break;
                                case "radiationlevel":
                                    float radiationlevel = 0;
                                    if (float.TryParse(options[1], out radiationlevel))
                                    {
                                        info.Atmosphere.RadiationLevel = radiationlevel;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetAnimalsInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Animal = copyProfile.BuildAnimalsSetting();
                            }
                        }
                        break;
                    case "add":
                        if (PlanetMapAnimalsProfile.ValidAnimals.ContainsKey(options[0]))
                        {
                            var targetBodToAdd = PlanetMapAnimalsProfile.ValidAnimals[options[0]];
                            if (!info.Animal.Animals.Any(x => x.Id == targetBodToAdd))
                            {
                                info.Animal.Animals.Add(new PlanetAnimalEntrySetting() { Id = targetBodToAdd });
                            }
                        }
                        break;
                    case "remove":
                        if (PlanetMapAnimalsProfile.ValidAnimals.ContainsKey(options[0]))
                        {
                            var targetBodToRemove = PlanetMapAnimalsProfile.ValidAnimals[options[0]];
                            if (info.Animal.Animals.Any(x => x.Id == targetBodToRemove))
                            {
                                info.Animal.Animals.RemoveAll(x => x.Id == targetBodToRemove);
                            }
                        }
                        break;
                    case "clear":
                        info.Animal.Animals.Clear();
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "dayspawn.enabled":
                                    bool dayspawnenabled = false;
                                    if (bool.TryParse(options[1], out dayspawnenabled))
                                    {
                                        info.Animal.DaySpawn.Enabled = dayspawnenabled;
                                    }
                                    break;
                                case "dayspawn.spawndelay":
                                    var dayspawnspawndelay = options[1].Split('|');
                                    if (dayspawnspawndelay.Length >= 2)
                                    {
                                        int dayspawnspawndelay_from = 0;
                                        int dayspawnspawndelay_to = 0;
                                        if (int.TryParse(dayspawnspawndelay[0], out dayspawnspawndelay_from) &&
                                            int.TryParse(dayspawnspawndelay[1], out dayspawnspawndelay_to))
                                        {
                                            if (dayspawnspawndelay_from <= dayspawnspawndelay_to)
                                            {
                                                info.Animal.DaySpawn.SpawnDelay = new Vector2I(dayspawnspawndelay_from, dayspawnspawndelay_to);
                                            }
                                        }
                                    }
                                    break;
                                case "dayspawn.spawndist":
                                    var dayspawnspawndist = options[1].Split('|');
                                    if (dayspawnspawndist.Length >= 2)
                                    {
                                        int dayspawnspawndist_from = 0;
                                        int dayspawnspawndist_to = 0;
                                        if (int.TryParse(dayspawnspawndist[0], out dayspawnspawndist_from) &&
                                            int.TryParse(dayspawnspawndist[1], out dayspawnspawndist_to))
                                        {
                                            if (dayspawnspawndist_from <= dayspawnspawndist_to)
                                            {
                                                info.Animal.DaySpawn.SpawnDist = new Vector2I(dayspawnspawndist_from, dayspawnspawndist_to);
                                            }
                                        }
                                    }
                                    break;
                                case "dayspawn.wavecount":
                                    var dayspawnwavecount = options[1].Split('|');
                                    if (dayspawnwavecount.Length >= 2)
                                    {
                                        int dayspawnwavecount_from = 0;
                                        int dayspawnwavecount_to = 0;
                                        if (int.TryParse(dayspawnwavecount[0], out dayspawnwavecount_from) &&
                                            int.TryParse(dayspawnwavecount[1], out dayspawnwavecount_to))
                                        {
                                            if (dayspawnwavecount_from <= dayspawnwavecount_to)
                                            {
                                                info.Animal.DaySpawn.WaveCount = new Vector2I(dayspawnwavecount_from, dayspawnwavecount_to);
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.enabled":
                                    bool nightspawnenabled = false;
                                    if (bool.TryParse(options[1], out nightspawnenabled))
                                    {
                                        info.Animal.NightSpawn.Enabled = nightspawnenabled;
                                    }
                                    break;
                                case "nightspawn.spawndelay":
                                    var nightspawnspawndelay = options[1].Split('|');
                                    if (nightspawnspawndelay.Length >= 2)
                                    {
                                        int nightspawnspawndelay_from = 0;
                                        int nightspawnspawndelay_to = 0;
                                        if (int.TryParse(nightspawnspawndelay[0], out nightspawnspawndelay_from) &&
                                            int.TryParse(nightspawnspawndelay[1], out nightspawnspawndelay_to))
                                        {
                                            if (nightspawnspawndelay_from <= nightspawnspawndelay_to)
                                            {
                                                info.Animal.NightSpawn.SpawnDelay = new Vector2I(nightspawnspawndelay_from, nightspawnspawndelay_to);
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.spawndist":
                                    var nightspawnspawndist = options[1].Split('|');
                                    if (nightspawnspawndist.Length >= 2)
                                    {
                                        int nightspawnspawndist_from = 0;
                                        int nightspawnspawndist_to = 0;
                                        if (int.TryParse(nightspawnspawndist[0], out nightspawnspawndist_from) &&
                                            int.TryParse(nightspawnspawndist[1], out nightspawnspawndist_to))
                                        {
                                            if (nightspawnspawndist_from <= nightspawnspawndist_to)
                                            {
                                                info.Animal.NightSpawn.SpawnDist = new Vector2I(nightspawnspawndist_from, nightspawnspawndist_to);
                                            }
                                        }
                                    }
                                    break;
                                case "nightspawn.wavecount":
                                    var nightspawnwavecount = options[1].Split('|');
                                    if (nightspawnwavecount.Length >= 2)
                                    {
                                        int nightspawnwavecount_from = 0;
                                        int nightspawnwavecount_to = 0;
                                        if (int.TryParse(nightspawnwavecount[0], out nightspawnwavecount_from) &&
                                            int.TryParse(nightspawnwavecount[1], out nightspawnwavecount_to))
                                        {
                                            if (nightspawnwavecount_from <= nightspawnwavecount_to)
                                            {
                                                info.Animal.NightSpawn.WaveCount = new Vector2I(nightspawnwavecount_from, nightspawnwavecount_to);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetWaterInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "copy":
                        if (options.Any())
                        {
                            string profile = options[0].ToUpper();
                            var copyProfile = PlanetMapProfile.Get(profile);
                            if (copyProfile != null)
                            {
                                info.Water = copyProfile.BuildWaterSetting();
                            }
                        }
                        break;
                    case "set":
                        if (options.Count() == 2)
                        {
                            switch (options[0].ToLower())
                            {
                                case "enabled":
                                    bool enabled = false;
                                    if (bool.TryParse(options[1], out enabled))
                                    {
                                        info.Water.Enabled = enabled;
                                    }
                                    break;
                                case "size":
                                    float size = 0;
                                    if (float.TryParse(options[1], out size))
                                    {
                                        info.Water.Size = size;
                                    }
                                    break;
                                case "temperaturefactor":
                                    float temperaturefactor = 0;
                                    if (float.TryParse(options[1], out temperaturefactor))
                                    {
                                        info.Water.TemperatureFactor = temperaturefactor;
                                    }
                                    break;
                                case "toxiclevel":
                                    float toxiclevel = 0;
                                    if (float.TryParse(options[1], out toxiclevel))
                                    {
                                        info.Water.ToxicLevel = toxiclevel;
                                    }
                                    break;
                                case "radiationlevel":
                                    float radiationlevel = 0;
                                    if (float.TryParse(options[1], out radiationlevel))
                                    {
                                        info.Water.RadiationLevel = radiationlevel;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public bool ProcessPlanetThermalInfo(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "generate":
                        float startMultiplier = 1;
                        float rowMultiplier = 1;
                        float powerMultiplier = 1;
                        string profile = planet.ToUpper();
                        foreach (var item in options)
                        {
                            if (item.Contains("="))
                            {
                                var parts = item.Split('=');
                                if (parts.Length == 2)
                                {
                                    float infomultiplier;
                                    switch (parts[0].ToLower())
                                    {
                                        case "startmultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                startMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "rowmultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                rowMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "powermultiplier":
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                powerMultiplier = infomultiplier;
                                            }
                                            break;
                                        case "profile":
                                            profile = parts[1].ToUpper().Trim();
                                            break;
                                    }
                                }
                            }
                        }
                        info.Geothermal = PlanetMapProfile.Get(profile).BuildGeothermalSetting(startMultiplier, rowMultiplier, powerMultiplier);
                        return true;
                }
            }
            return false;
        }

        public bool ProcessPlanetOreMap(string planet, string name, params string[] options)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "generate":
                        int seed = MyUtils.GetRandomInt(10000000, int.MaxValue);
                        float deep = 1.0f;
                        string profile = planet.ToUpper();
                        string[] addOres = new string[0];
                        string[] removeOres = new string[0];
                        bool clearOresBeforeAdd = false;
                        string targetColor = null;
                        Vector2I? colorInfluence = null;
                        foreach (var item in options)
                        {
                            var parts = item.Split('=');
                            switch (parts[0].ToLower())
                            {
                                case "seed":
                                    if (parts.Length >= 2)
                                    {
                                        int infoseed;
                                        if (int.TryParse(parts[1], out infoseed))
                                        {
                                            seed = infoseed;
                                        }
                                    }
                                    break;
                                case "deep":
                                    if (parts.Length >= 2)
                                    {
                                        float infodeep;
                                        if (float.TryParse(parts[1], out infodeep))
                                        {
                                            deep = infodeep;
                                        }
                                    }
                                    break;
                                case "profile":
                                    if (parts.Length >= 2)
                                        profile = parts[1].ToUpper().Trim();
                                    break;
                                case "add":
                                    if (parts.Length >= 2)
                                        addOres = parts[1].ToUpper().Split(',');
                                    break;
                                case "remove":
                                    if (parts.Length >= 2)
                                        removeOres = parts[1].ToUpper().Split(',');
                                    break;
                                case "clear":
                                    clearOresBeforeAdd = true;
                                    break;
                                case "targetcolor":
                                    if (parts.Length >= 2)
                                    {
                                        try
                                        {
                                            string colorcode = parts[1];
                                            colorcode = colorcode.TrimStart('#');
                                            Color col;
                                            if (colorcode.Length == 6)
                                            {
                                                col = new Color(
                                                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                                                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                                                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber),
                                                    255
                                                );
                                                targetColor = parts[1];
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                                        }
                                    }
                                    break;
                                case "colorinfluence":
                                    if (parts.Length >= 2)
                                    {
                                        var influenceRange = parts[1].ToUpper().Split('|');
                                        if (influenceRange.Length >= 2)
                                        {
                                            int influenceFrom, influenceTo;
                                            if (int.TryParse(influenceRange[0], out influenceFrom) &&
                                                int.TryParse(influenceRange[1], out influenceTo))
                                            {
                                                if (influenceFrom <= influenceTo &&
                                                    influenceFrom >= 0 && influenceTo >= 0 &&
                                                    influenceFrom <= 255 && influenceTo <= 255)
                                                {
                                                    colorInfluence = new Vector2I(influenceFrom, influenceTo);
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        GeneratePlanetInfo(info.Id, seed, deep, profile, true, GenerateFlags.OreMap, addOres, removeOres, 
                            clearOresBeforeAdd, targetColor, colorInfluence);
                        return true;
                }
            }
            return false;
        }

        public bool SetPlanetConfigValue(string planet, string name, string value)
        {
            var info = GetPlanetInfo(planet, false);
            if (info != null)
            {
                switch (name)
                {
                    case "respawnenabled":
                        bool respawnenabled;
                        if (bool.TryParse(value, out respawnenabled))
                        {
                            info.RespawnEnabled = respawnenabled;
                            return true;
                        }
                        break;
                    case "type":
                        int type;
                        if (int.TryParse(value, out type))
                        {
                            int[] validValues = new int[] { 0, 1, 2, 4 };
                            if (validValues.Contains(type))
                            {
                                info.Type = type;
                                return true;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        public VoxelMaterialSetting GetVoxelInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasVoxelInfo(id) && !VoxelUsingTecnologyForFirstTime(id))
            {
                var settings = VoxelMaterials.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                var profile = VoxelMaterialMapProfile.Get(id.ToUpper());
                if (profile != null && profile.Version > settings.Version)
                    settings = profile.UpgradeSettings(settings);
                return settings;
            }
            else if (generateWhenNotExists)
            {
                return GenerateVoxelInfo(id, true);
            }
            return null;
        }

        public VoxelMaterialSetting GenerateVoxelInfo(string id, bool force = false)
        {
            if (!HasVoxelInfo(id) || force)
            {
                var settings = VoxelMaterialMapProfile.Get(id.ToUpper()).BuildSettings(id);
                if (HasVoxelInfo(id))
                    VoxelMaterials.RemoveAll(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                VoxelMaterials.Add(settings);
                return settings;
            }
            return GetVoxelInfo(id, false);
        }

        public bool HasVoxelInfo(string id)
        {
            return VoxelMaterials.Any(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
        }

        public bool SetVoxelConfigValue(string voxel, string name, string value)
        {
            var info = GetVoxelInfo(voxel, false);
            if (info != null)
            {
                switch (name)
                {
                    case "minedoreratio":
                        float minedoreratio;
                        if (float.TryParse(value, out minedoreratio))
                        {
                            info.MinedOreRatio = minedoreratio;
                            return true;
                        }
                        break;
                    case "spawnsfrommeteorites":
                        bool spawnsfrommeteorites;
                        if (bool.TryParse(value, out spawnsfrommeteorites))
                        {
                            info.SpawnsFromMeteorites = spawnsfrommeteorites;
                            return true;
                        }
                        break;
                    case "spawnsinasteroids":
                        bool spawnsinasteroids;
                        if (bool.TryParse(value, out spawnsinasteroids))
                        {
                            info.SpawnsInAsteroids = spawnsinasteroids;
                            return true;
                        }
                        break;
                    case "asteroidspawnprobabilitymultiplier":
                        int asteroidspawnprobabilitymultiplier;
                        if (int.TryParse(value, out asteroidspawnprobabilitymultiplier))
                        {
                            info.AsteroidSpawnProbabilityMultiplier = asteroidspawnprobabilitymultiplier;
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        public bool SetConfigValue(string name, string value)
        {
            switch (name)
            {
                case "rotenabled":
                    bool rotfoodenabled;
                    if (bool.TryParse(value, out rotfoodenabled))
                    {
                        RotEnabled = rotfoodenabled;
                        return true;
                    }
                    break;
                case "dinamicwoodgridenabled":
                    bool dinamicwoodgridenabled;
                    if (bool.TryParse(value, out dinamicwoodgridenabled))
                    {
                        DinamicWoodGridEnabled = dinamicwoodgridenabled;
                        return true;
                    }
                    break;
                case "dinamicstonegridenabled":
                    bool dinamicstonegridenabled;
                    if (bool.TryParse(value, out dinamicstonegridenabled))
                    {
                        DinamicStoneGridEnabled = dinamicstonegridenabled;
                        return true;
                    }
                    break;
                case "dinamicconcretegridenabled":
                    bool dinamicconcretegridenabled;
                    if (bool.TryParse(value, out dinamicconcretegridenabled))
                    {
                        DinamicConcreteGridEnabled = dinamicconcretegridenabled;
                        return true;
                    }
                    break;
                case "respawnspacepodenabled":
                    bool respawnspacepodenabled;
                    if (bool.TryParse(value, out respawnspacepodenabled))
                    {
                        RespawnSpacePodEnabled = respawnspacepodenabled;
                        return true;
                    }
                    break;
                case "disablewatermodfreeice":
                    bool disablewatermodfreeice;
                    if (bool.TryParse(value, out disablewatermodfreeice))
                    {
                        DisableWaterModFreeIce = disablewatermodfreeice;
                        return true;
                    }
                    break;
                case "starsystemconfiguration.autogeneratestarsystemgps":
                    bool starsystemconfigurationautogeneratestarsystemgps;
                    if (bool.TryParse(value, out starsystemconfigurationautogeneratestarsystemgps))
                    {
                        StarSystemConfiguration.AutoGenerateStarSystemGps = starsystemconfigurationautogeneratestarsystemgps;
                        return true;
                    }
                    break;
                case "dropcontainerdeployheight":
                    int dropcontainerdeployheight;
                    if (int.TryParse(value, out dropcontainerdeployheight))
                    {
                        DropContainerDeployHeight = Math.Min(Math.Max(dropcontainerdeployheight, 200), 2000);
                        return true;
                    }
                    break;
                case "planetdeployaltitude":
                    int planetdeployaltitude;
                    if (int.TryParse(value, out planetdeployaltitude))
                    {
                        PlanetDeployAltitude = Math.Min(Math.Max(planetdeployaltitude, 5), 2000);
                        return true;
                    }
                    break;
                case "moondeployaltitude":
                    int moondeployaltitude;
                    if (int.TryParse(value, out moondeployaltitude))
                    {
                        MoonDeployAltitude = Math.Min(Math.Max(moondeployaltitude, 5), 1500);
                        return true;
                    }
                    break;
            }
            return false;
        }

    }

}
