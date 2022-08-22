using Sandbox.Definitions;
using System;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    public static class UniqueEntityIdExtension
    {

        public static T GetDefinition<T>(this UniqueEntityId id) where T : MyDefinitionBase
        {
            try
            {
                var defs = MyDefinitionManager.Static.GetAllDefinitions();
                return defs[id.DefinitionId] as T;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(UniqueEntityIdExtension), ex);
            }
            return null;
        }

    }

}
