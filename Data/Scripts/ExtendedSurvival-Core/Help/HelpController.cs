using Sandbox.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    public static class HelpController
    {

        public const string BASE_TOPIC_TYPE = "ExtendedSurvival.Core";

        public class HelpTopic
        {

            public UniqueNameId NameId { get; set; }
            public Guid Id
            {
                get
                {
                    return NameId.GetUniqueId().Id;
                }
            }

            public string Title { get; set; }

            public ConcurrentDictionary<Guid, HelpEntry> Entries { get; set; } = new ConcurrentDictionary<Guid, HelpEntry>();

        }

        public class HelpEntry
        {

            public UniqueNameId NameId { get; set; }
            public Guid Id
            {
                get
                {
                    return NameId.GetUniqueId().Id;
                }
            }

            public int Order { get; set; }
            public int Indentation { get; set; } 
            public string Title { get; set; }
            public ConcurrentDictionary<int, HelpPage> Pages { get; set; } = new ConcurrentDictionary<int, HelpPage>();

        }

        public class HelpPage
        {

            public int Order { get; set; }
            public string Text { get; set; }
            public string Texture { get; set; }

        }

        private static readonly ConcurrentDictionary<Guid, HelpTopic> HELP_TOPICS = new ConcurrentDictionary<Guid, HelpTopic>();
        private static readonly ConcurrentBag<Action> LOAD_ACTIONS = new ConcurrentBag<Action>();
        private static bool Loaded = false;

        public static void AddLoadAction(Action action)
        {
            LOAD_ACTIONS.Add(action);
        }

        public static void AddTopic(UniqueNameId id, string title)
        {
            if (!HELP_TOPICS.ContainsKey(id.UniqueId.Id))
                HELP_TOPICS[id.UniqueId.Id] = new HelpTopic()
                {
                    NameId = id,
                    Title = title
                };
        }

        public static void AddEntry(UniqueNameId topicId, UniqueNameId id, string title, int indentation)
        {
            if (HELP_TOPICS.ContainsKey(topicId.UniqueId.Id))
            {
                if (!HELP_TOPICS[topicId.UniqueId.Id].Entries.ContainsKey(id.UniqueId.Id))
                {
                    var order = HELP_TOPICS[topicId.UniqueId.Id].Entries.Any() ? HELP_TOPICS[topicId.UniqueId.Id].Entries.Max(x => x.Value.Order) + 1 : 0;
                    HELP_TOPICS[topicId.UniqueId.Id].Entries[id.UniqueId.Id] = new HelpEntry()
                    {
                        NameId = id,
                        Title = title,
                        Indentation = indentation,
                        Order = order
                    };
                }
            }
        }

        public static void AddPage(UniqueNameId topicId, UniqueNameId entryId, string text, string texture = null)
        {
            if (HELP_TOPICS.ContainsKey(topicId.UniqueId.Id))
            {
                if (HELP_TOPICS[topicId.UniqueId.Id].Entries.ContainsKey(entryId.UniqueId.Id))
                {
                    var order = HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages.Any() ? HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages.Keys.Max() + 1 : 0;
                    HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages[order] = new HelpPage()
                    {
                        Order = order,
                        Text = text,
                        Texture = texture
                    };
                }
            }
        }

        private static void DoLoad()
        {
            foreach (var action in LOAD_ACTIONS)
            {
                action?.Invoke();
            }
            Loaded = true;
        }

        public static IDictionary<Guid, string> GetHelpTopics()
        {
            if (!Loaded)
                DoLoad();
            return HELP_TOPICS.ToDictionary(x => x.Key, x => x.Value.Title);
        }

        public static IDictionary<Guid, VRage.MyTuple<string, int, int, int>> GetHelpTopicEntries(Guid idTopic)
        {
            if (HELP_TOPICS.ContainsKey(idTopic))
            {
                return HELP_TOPICS[idTopic].Entries.ToDictionary(
                    x => x.Key, 
                    x => new VRage.MyTuple<string, int, int, int>(x.Value.Title, x.Value.Order, x.Value.Indentation, x.Value.Pages.Count)
                );
            }
            return new Dictionary<Guid, VRage.MyTuple<string, int, int, int>>();
        }

        public static VRage.MyTuple<string, string>? GetHelpEntryPageData(Guid idTopic, Guid idEntry, int page)
        {
            if (HELP_TOPICS.ContainsKey(idTopic))
            {
                if (HELP_TOPICS[idTopic].Entries.ContainsKey(idEntry))
                {
                    var entry = HELP_TOPICS[idTopic].Entries[idEntry];
                    if (entry.Pages.ContainsKey(page))
                    {
                        return new VRage.MyTuple<string, string>(entry.Pages[page].Text, entry.Pages[page].Texture);
                    }
                }
            }
            return null;
        }

        private static string BuildTextureName(MyDefinitionId id)
        {
            return $"{id.TypeId.ToString().Replace("MyObjectBuilder_", "")}{id.SubtypeId.String}";
        }

        public static void LoadDefinitionHelpEntryPages<T, K>(T definition, UniqueNameId topicId, UniqueNameId entryId) 
            where T : SimpleDefinition
            where K : MyPhysicalItemDefinition
        {
            var itemDef = DefinitionUtils.TryGetDefinition<K>(definition.Id.DefinitionId);
            if (itemDef != null)
            {
                AddPage(
                    topicId,
                    entryId,
                    definition.GetHelpDescription(),
                    BuildTextureName(definition.Id.DefinitionId)
                );
                var factoring = definition as ISimpleFactoringDefinition;
                if (factoring != null)
                {
                    var sb = new StringBuilder();
                    int i = 1;
                    foreach (var recipe in factoring.GetRecipesDefinition())
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            sb.AppendLine(LanguageProvider.GetEntry(LanguageEntries.TERMS_RECIPE) + " " + i.ToString("00"));
                            sb.AppendLine(string.Format("{0}: {1}s", LanguageProvider.GetEntry(LanguageEntries.TERMS_PRODUCTIONTIME), recipe.ProductionTime.ToString("#0.00")));
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_INGREDIENTS)}:");
                            foreach (var ingredient in recipeDef.Prerequisites)
                            {
                                var ingredientDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(ingredient.Id);
                                if (ingredientDef != null)
                                {
                                    sb.AppendLine(string.Format("- {0} {1}", ingredient.Amount, ingredientDef.DisplayNameText));
                                }
                            }
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_RESULTS)}:");
                            foreach (var result in recipeDef.Results)
                            {
                                var resultDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(result.Id);
                                if (resultDef != null)
                                {
                                    sb.AppendLine(string.Format("- {0} {1}", result.Amount, resultDef.DisplayNameText));
                                }
                            }
                            var assemblers = new List<MyAssemblerDefinition>();
                            var refineries = new List<MyRefineryDefinition>();
                            var gasGenerators = new List<MyOxygenGeneratorDefinition>();
                            PhysicalItemDefinitionOverride.RecoverBlueprintUse(recipeDef, ref assemblers, ref refineries, ref gasGenerators);
                            if (assemblers.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CRAFTAT)}:");
                                foreach (var item in assemblers)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            else if (refineries.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_REFINEAT)}:");
                                foreach (var item in refineries)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            else if (gasGenerators.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CONSUMEAT)}:");
                                foreach (var item in gasGenerators)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            AddPage(
                                topicId,
                                entryId,
                                sb.ToString(),
                                BuildTextureName(definition.Id.DefinitionId)
                            );
                            i++;
                        }
                    }
                }
            }
        }

    }

}
