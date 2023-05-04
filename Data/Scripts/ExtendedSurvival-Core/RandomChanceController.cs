using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Utils;
using System.Collections.Concurrent;

namespace ExtendedSurvival.Core
{
    public static class RandomChanceController
    {

        public struct ChanceItem
        {

            public float From { get; set; }
            public float To { get; set; }
            public object Target { get; set; }
            public Type TargetType { get; set; }

            public ChanceItem(float from, float to, object target, Type targetType)
            {
                From = from;
                To = to;
                Target = target;
                TargetType = targetType;
            }

        }

        private static readonly ConcurrentDictionary<string, List<ChanceItem>> CACHE_CHANCES = new ConcurrentDictionary<string, List<ChanceItem>>();

        public static bool RegisterChance<T>(string key, IEnumerable<T> list, Func<T, float> getChance)
        {
            if (!CACHE_CHANCES.ContainsKey(key) && list != null && list.Any() && list.Sum(x => getChance(x)) == 1)
            {
                CACHE_CHANCES[key] = new List<ChanceItem>();
                float from = 0;
                float to = 0;
                foreach (var item in list)
                {
                    to += getChance(item);
                    CACHE_CHANCES[key].Add(new ChanceItem(from, to, item, typeof(T)));
                    from += to;
                }
                return true;
            }
            return false;
        }

        public static bool TryGetRandom<T>(string key, out T item)
        {
            item = default(T);
            if (CACHE_CHANCES.ContainsKey(key))
            {
                var chance = MyUtils.GetRandomFloat(0, 1);
                var query = CACHE_CHANCES[key].Where(x => chance >= x.From && chance <= x.To);
                if (query.Any())
                {
                    var target = query.FirstOrDefault();
                    if (target.TargetType == typeof(T))
                    {
                        item = (T)target.Target;
                        return true;
                    }
                }
            }
            return false;
        }

    }

}