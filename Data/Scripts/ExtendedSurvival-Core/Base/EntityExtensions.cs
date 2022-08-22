using Sandbox.Game.Entities;
using VRage.Game.Components;
using VRage.ModAPI;

namespace ExtendedSurvival.Core
{

    public static class EntityExtensions
    {
        public static T GetAs<T>(this IMyEntity entity) where T : MyGameLogicComponent
        {
            var logic = entity.GameLogic;
            var t = logic as T;
            if (t != null) return t;
            var cmp = logic as MyCompositeGameLogicComponent;
            return cmp?.GetAs<T>();
        }
    }

}