using Sandbox.ModAPI;
using System;
using VRage.Utils;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    public abstract class BaseSettings
    {

        protected delegate bool BaseSettings_Validade<T>(T settings) where T : BaseSettings;
        protected delegate T BaseSettings_Create<T>() where T : BaseSettings;

        [XmlElement]
        public int Version { get; set; }

        protected static T Load<T>(string fileName, int currentVersion, BaseSettings_Validade<T> validade, BaseSettings_Create<T> create) where T : BaseSettings
        {
            var world = false;
            T settings = null;
            try
            {
                if (MyAPIGateway.Utilities.FileExistsInWorldStorage(fileName, typeof(T)))
                {
                    world = true;
                    using (var reader = MyAPIGateway.Utilities.ReadFileInWorldStorage(fileName, typeof(T)))
                    {
                        settings = GetData<T>(reader.ReadToEnd());
                        MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from world file.");
                    }
                }
                else if (MyAPIGateway.Utilities.FileExistsInLocalStorage(fileName, typeof(T)))
                {
                    using (var reader = MyAPIGateway.Utilities.ReadFileInLocalStorage(fileName, typeof(T)))
                    {
                        settings = GetData<T>(reader.ReadToEnd());
                        MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from local storage.");
                    }
                }

                if (settings != null)
                {
                    var adjusted = false;
                    if (settings.Version < currentVersion)
                    {
                        MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Settings have old version: {0} update to {1}", settings.Version, currentVersion));

                        adjusted = true;
                        settings.Version = currentVersion;
                    }
                    adjusted = adjusted || !validade(settings);
                    if (adjusted) Save<T>(settings, fileName, world);
                }
                else
                {
                    settings = create();
                    settings.Version = currentVersion;
                    validade(settings);
                    Save<T>(settings, fileName, world);
                }
                settings.OnAfterLoad();
            }
            catch (Exception ex)
            {
                MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Exception while loading: {0}", ex.Message));
            }

            return settings;
        }

        protected virtual void OnAfterLoad()
        {

        }

        protected static T GetData<T>(string data) where T : BaseSettings
        {
            return MyAPIGateway.Utilities.SerializeFromXML<T>(data);
        }

        protected static string GetData<T>(T settings) where T : BaseSettings
        {
            return MyAPIGateway.Utilities.SerializeToXML(settings);
        }

        protected static void Save<T>(T settings, string fileName, bool world) where T : BaseSettings
        {
            if (world)
            {
                using (var writer = MyAPIGateway.Utilities.WriteFileInWorldStorage(fileName, typeof(ExtendedSurvivalSettings)))
                {
                    writer.Write(GetData<T>(settings));
                }
            }
            else
            {
                using (var writer = MyAPIGateway.Utilities.WriteFileInLocalStorage(fileName, typeof(ExtendedSurvivalSettings)))
                {
                    writer.Write(GetData<T>(settings));
                }
            }
        }

    }

}
