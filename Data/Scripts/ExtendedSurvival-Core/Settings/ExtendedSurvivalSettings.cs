using ProtoBuf;
using System;
using System.Collections.Generic;
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

        private const int CURRENT_VERSION = 1;
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
        public bool AutoGenerateStarSystemGps { get; set; } = true;

        [XmlElement]
        public int DropContainerDeployHeight { get; set; } = 1000;

        [XmlArray("Planets"), XmlArrayItem("Planet", typeof(PlanetSetting))]
        public List<PlanetSetting> Planets { get; set; } = new List<PlanetSetting>();

        [XmlArray("VoxelMaterials"), XmlArrayItem("VoxelMaterial", typeof(VoxelMaterialSetting))]
        public List<VoxelMaterialSetting> VoxelMaterials { get; set; } = new List<VoxelMaterialSetting>();

        [XmlArray("StarSystems"), XmlArrayItem("StarSystem", typeof(StarSystemSetting))]
        public List<StarSystemSetting> StarSystems { get; set; } = new List<StarSystemSetting>();
        
        [XmlElement]
        public string IgnorePlanets { get; set; } = "SYSTEMTESTMAP;EARTHLIKEMODEXAMPLE;MARSTUTORIAL;MOONTUTORIAL;EARTHLIKETUTORIAL";

        private static bool Validate(ExtendedSurvivalSettings settings)
        {
            var res = true;
            return res;
        }

        public static ExtendedSurvivalSettings Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); });
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

        public StarSystemSetting GetStarSystemInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasStarSystem(id))
            {
                var settings = StarSystems.FirstOrDefault(x => x.Name.ToUpper().Trim() == id.ToUpper().Trim());
                var starProfile = StarSystemMapProfile.Get(settings.Name);
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
                    return GeneratePlanetInfo(id, MyUtils.GetRandomInt(10000000, int.MaxValue), 1.0f, id.ToUpper(), true);
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

        public PlanetSetting GeneratePlanetInfo(string id, int seed, float deep, string profile, bool force = false, GenerateFlags replaceFlag = GenerateFlags.All, string[] addOres = null, string[] removeOres = null)
        {
            if (!HasPlanetInfo(id) || force)
            {
                var settings = PlanetMapProfile.Get(profile).BuildSettings(id, seed, deep, addOres, removeOres);
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
                        foreach (var item in options)
                        {
                            if (item.Contains("="))
                            {
                                var parts = item.Split('=');
                                if (parts.Length == 2)
                                {
                                    switch (parts[0].ToLower())
                                    {
                                        case "seed":
                                            int infoseed;
                                            if (int.TryParse(parts[1], out infoseed))
                                            {
                                                seed = infoseed;
                                            }
                                            break;
                                        case "deep":
                                            float infodeep;
                                            if (float.TryParse(parts[1], out infodeep))
                                            {
                                                deep = infodeep;
                                            }
                                            break;
                                        case "profile":
                                            profile = parts[1].ToUpper().Trim();
                                            break;
                                        case "add":
                                            addOres = parts[1].ToUpper().Split(',');
                                            break;
                                        case "remove":
                                            removeOres = parts[1].ToUpper().Split(',');
                                            break;
                                    }
                                }
                            }
                        }
                        GeneratePlanetInfo(info.Id, seed, deep, profile, true, GenerateFlags.OreMap, addOres, removeOres);
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
                    case "dayspawn.enabled":
                        bool dayspawn;
                        if (bool.TryParse(value, out dayspawn))
                        {
                            info.Animal.DaySpawn.Enabled = dayspawn;
                            return true;
                        }
                        break;
                    case "nightspawn.enabled":
                        bool nightspawn;
                        if (bool.TryParse(value, out nightspawn))
                        {
                            info.Animal.NightSpawn.Enabled = nightspawn;
                            return true;
                        }
                        break;
                    case "respawnenabled":
                        bool respawnenabled;
                        if (bool.TryParse(value, out respawnenabled))
                        {
                            info.RespawnEnabled = respawnenabled;
                            return true;
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
                case "autogeneratestarsystemgps":
                    bool autogeneratestarsystemgps;
                    if (bool.TryParse(value, out autogeneratestarsystemgps))
                    {
                        AutoGenerateStarSystemGps = autogeneratestarsystemgps;
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
            }
            return false;
        }

    }

}
