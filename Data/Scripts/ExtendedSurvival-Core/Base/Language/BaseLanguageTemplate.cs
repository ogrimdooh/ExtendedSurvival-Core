using System.Collections.Generic;
using VRage;

namespace ExtendedSurvival.Core
{

    public abstract class BaseLanguageTemplate
    {

        public MyLanguagesEnum TargetLanguage { get; private set; }

        private readonly Dictionary<string, string> _entries = new Dictionary<string, string>();

        protected abstract void DoLoadEntries();

        public BaseLanguageTemplate(MyLanguagesEnum targetLanguage)
        {
            TargetLanguage = targetLanguage;
            DoLoadEntries();
        }

        protected void AddEntry(string key, string value)
        {
            if (_entries.ContainsKey(key))
                _entries[key] = value;
            else
                _entries.Add(key, value);
        }

        public string GetEntry(string key)
        {
            if (_entries.ContainsKey(key))
                return _entries[key];
            ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"LanguageTemplate: entry {key} not found.");
            return null;
        }

    }

}
