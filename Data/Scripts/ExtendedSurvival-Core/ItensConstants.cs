using Sandbox.Common.ObjectBuilders.Definitions;
using System.Collections.Concurrent;
using VRage.Game;
using VRage.ObjectBuilders;

namespace ExtendedSurvival
{

    public static class ItensConstants
    {

        private static ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base> BUILDERS_CACHE = new ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base>();

        public static T GetBuilder<T>(UniqueEntityId id, bool cache = true) where T : MyObjectBuilder_Base
        {
            if (cache && BUILDERS_CACHE.ContainsKey(id))
                return BUILDERS_CACHE[id] as T;
            var builder = MyObjectBuilderSerializer.CreateNewObject(id.DefinitionId) as T;
            BUILDERS_CACHE[id] = builder;
            return builder as T;
        }

        public static MyObjectBuilder_PhysicalObject GetPhysicalObjectBuilder(UniqueEntityId id)
        {
            return GetBuilder<MyObjectBuilder_PhysicalObject>(id);
        }

        public static MyObjectBuilder_GasContainerObject GetGasContainerBuilder(UniqueEntityId id, float gasLevel = 0)
        {
            var builder = GetBuilder<MyObjectBuilder_GasContainerObject>(id, false);
            builder.GasLevel = gasLevel;
            return builder;
        }

    }

}
