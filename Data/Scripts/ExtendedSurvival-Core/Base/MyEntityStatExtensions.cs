using Sandbox.Game.Entities;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class MyEntityStatExtensions
    {

        public static Vector4 GetValues(this MyEntityStat stat, float w = 0)
        {
            return new Vector4(stat.MinValue, stat.MaxValue, stat.Value, w);
        }

    }

}