using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Core
{
    public static class PlanetOreMapProfile
    {

        public enum PlanetOreMapFace
        {

            Front = 0,
            Back = 1,
            Left = 2,
            Right = 3,
            Top = 4,
            Bottom = 5

        }

        public class PlanetOreMapInfo
        {

            public ConcurrentDictionary<PlanetOreMapFace, ConcurrentDictionary<byte, long>> FaceInfo { get; set; } = new ConcurrentDictionary<PlanetOreMapFace, ConcurrentDictionary<byte, long>>();

            public ConcurrentDictionary<byte, long> AllInfo = new ConcurrentDictionary<byte, long>();

            public void ProcessAllInfo()
            {
                AllInfo.Clear();
                foreach (var k in FaceInfo.Keys)
                {
                    foreach (var v in FaceInfo[k])
                    {
                        if (AllInfo.ContainsKey(v.Key))
                            AllInfo[v.Key] += v.Value;
                        else
                            AllInfo[v.Key] = v.Value;
                    }
                }
                foreach (var k in AllInfo.Keys)
                {
                    AllInfo[k] /= FaceInfo.Count(x => x.Value.ContainsKey(k));
                }
                var fivePercent = (int)(AllInfo.Count * 0.05f);
                var firstToRemove = AllInfo.OrderBy(x => x.Value).Select(x => x.Key).Take(fivePercent).ToArray();
                foreach (var k in firstToRemove)
                {
                    if (AllInfo.ContainsKey(k))
                        AllInfo.Remove(k);
                }
                var lastToRemove = AllInfo.OrderBy(x => x.Value).Select(x => x.Key).Take(fivePercent).ToArray();
                foreach (var k in lastToRemove)
                {
                    if (AllInfo.ContainsKey(k))
                        AllInfo.Remove(k);
                }
            }

        }

        public static ConcurrentDictionary<string, PlanetOreMapInfo> PLANET_OREMAP_INFO = new ConcurrentDictionary<string, PlanetOreMapInfo>();

    }

}
