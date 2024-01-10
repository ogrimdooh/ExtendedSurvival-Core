using Sandbox.ModAPI;
using System;
using System.IO;
using VRage.Utils;

namespace ExtendedSurvival.Core
{
    public sealed class ExtendedSurvivalCoreLogging
    {

        public enum LogLevel
        {
            Info = 0,
            Warning = 1,
            Error = 2,
            Fatal = 3,
            StackTrace = 3
        }

        private const string FILE_NAME = "{0}.log";

        private static ExtendedSurvivalCoreLogging _instance;
        public static ExtendedSurvivalCoreLogging Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        public bool IsValid 
        { 
            get
            {
                return _writer != null;
            }
        }

        private TextWriter _writer;

        private static string GetFileName()
        {
            return string.Format(FILE_NAME, GetTimeString().Replace(" ", "").Replace(":", "").Replace("-", ""));
        }

        public static ExtendedSurvivalCoreLogging Load()
        {
            _instance = new ExtendedSurvivalCoreLogging();
            _instance.Load(GetFileName());
            return _instance;
        }

        private void Load(string fileName)
        {
            var world = true;
            try
            {
                if (world)
                {
                    _writer = MyAPIGateway.Utilities.WriteFileInWorldStorage(fileName, typeof(ExtendedSurvivalCoreLogging));
                }
                else
                {
                    _writer = MyAPIGateway.Utilities.WriteFileInLocalStorage(fileName, typeof(ExtendedSurvivalCoreLogging));
                }
            }
            catch (Exception ex)
            {
                MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Exception while loading: {0}", ex.Message));
            }
        }

        private static string GetTimeString(bool complete = true)
        {
            if (complete)
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void Log(LogLevel level, string message)
        {
            if (IsValid)
                lock (_writer)
                {
                    _writer.WriteLine($"{GetTimeString()} [{level}] - {message}");
                    _writer.Flush();
                }
            MyLog.Default.WriteLineAndConsole($"ExtendedSurvival [{level}] - {message}");
        }

        public void LogError(Type caller, Exception ex, bool fatal = false)
        {
            Log(fatal ? LogLevel.Fatal : LogLevel.Error, $"{caller?.Name}: {ex.Message}");
            Log(LogLevel.StackTrace, $"{ex.StackTrace}");
        }

        public void LogError<T>(Exception ex, bool fatal = false)
        {
            LogError(typeof(T), ex, fatal);
        }

        public void LogWarning(Type caller, string message)
        {
            Log(LogLevel.Warning, $"{caller?.Name}: {message}");
        }

        public void LogWarning<T>(string message)
        {
            LogWarning(typeof(T), message);
        }

        public void LogInfo(Type caller, string message)
        {
            Log(LogLevel.Info, $"{caller?.Name}: {message}");
        }

        public void LogInfo<T>(string message)
        {
            LogInfo(typeof(T), message);
        }

        public void Close()
        {
            if (IsValid)
            {
                _writer.Flush();
                _writer.Close();
                _writer = null;
            }
        }

    }

}
