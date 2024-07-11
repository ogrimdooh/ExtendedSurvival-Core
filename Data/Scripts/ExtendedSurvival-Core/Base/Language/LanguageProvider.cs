using Sandbox.ModAPI;
using System.Collections.Generic;
using VRage;

namespace ExtendedSurvival.Core
{

    public static class LanguageProvider
    {

        static LanguageProvider()
        {
            /* Add Languages Templates */
            AddTemplate(new EnglishLanguageTemplate());
            AddTemplate(new GermanLanguageTemplate());
            AddTemplate(new RussianLanguageTemplate());
        }

        public const MyLanguagesEnum DEFAULT_LANGUAGE = MyLanguagesEnum.English;

        public static MyLanguagesEnum CurrentLanguage
        {
            get
            {
                return MyAPIGateway.Session.Config.Language;
            }
        }

        public static BaseLanguageTemplate CurrentTemplate
        {
            get
            {
                if (_templates.ContainsKey(CurrentLanguage))
                    return _templates[CurrentLanguage];
                return DefaultTemplate;
            }
        }

        public static BaseLanguageTemplate DefaultTemplate
        {
            get
            {
                if (_templates.ContainsKey(DEFAULT_LANGUAGE))
                    return _templates[DEFAULT_LANGUAGE];
                return null;
            }
        }

        private static readonly Dictionary<MyLanguagesEnum, BaseLanguageTemplate> _templates = new Dictionary<MyLanguagesEnum, BaseLanguageTemplate>();

        public static void AddTemplate<T>(T template) where T : BaseLanguageTemplate
        {
            if (_templates.ContainsKey(template.TargetLanguage))
                _templates[template.TargetLanguage] = template;
            else
                _templates.Add(template.TargetLanguage, template);
        }

        public static string GetEntry(string key)
        {
            string entryData = null;
            if (CurrentTemplate != null)
                entryData = CurrentTemplate.GetEntry(key);
            else
                ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(LanguageProvider), $"CurrentTemplate not found.");
            if (string.IsNullOrWhiteSpace(entryData))
            {
                if (DefaultTemplate != null)
                    entryData = DefaultTemplate.GetEntry(key);
                else
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(typeof(LanguageProvider), $"DefaultTemplate not found.");
            }
            return entryData;
        }

    }

}
