using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival
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
        public bool RotEnabled { get; set; }

        [XmlArray("Planets"), XmlArrayItem("Planet", typeof(PlanetSetting))]
        public List<PlanetSetting> Planets { get; set; } = new List<PlanetSetting>();

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
                Save(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
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

        public PlanetSetting GetPlanetInfo(string id, bool generateWhenNotExists = true)
        {
            if (HasPlanetInfo(id))
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
                    return GeneratePlanetInfo(id, MyUtils.GetRandomInt(10000000, int.MaxValue), 1.0f, id.ToUpper());
            }
            return null;
        }

        public PlanetSetting GeneratePlanetInfo(string id, int seed, float multiplier, string profile, bool force = false, bool generateAll = true)
        {
            if (!HasPlanetInfo(id) || force)
            {
                var settings = PlanetMapProfile.Get(profile).BuildSettings(id, seed, multiplier);
                if (HasPlanetInfo(id))
                {
                    if (!generateAll)
                    {
                        var atSet = Planets.FirstOrDefault(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                        settings.Animal = atSet.Animal;
                        settings.Geothermal = atSet.Geothermal;
                    }
                    Planets.RemoveAll(x => x.Id.ToUpper().Trim() == id.ToUpper().Trim());
                }
                Planets.Add(settings);
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
                        float multiplier = 1.0f;
                        string profile = planet.ToUpper();
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
                                        case "multiplier":
                                            float infomultiplier;
                                            if (float.TryParse(parts[1], out infomultiplier))
                                            {
                                                multiplier = infomultiplier;
                                            }
                                            break;
                                        case "profile":
                                            profile = parts[1].ToUpper().Trim();
                                            break;
                                    }
                                }
                            }
                        }
                        GeneratePlanetInfo(info.Id, seed, multiplier, profile, true, false);
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
            }
            return false;
        }

    }

}
