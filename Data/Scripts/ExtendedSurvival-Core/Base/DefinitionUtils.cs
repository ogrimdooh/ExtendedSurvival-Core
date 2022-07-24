using Sandbox.Definitions;
using System;
using System.Linq;
using VRage.Game;
using VRage.Utils;

namespace ExtendedSurvival
{
    public static class DefinitionUtils
    {

        public static MyBlueprintDefinitionBase TryGetBlueprintDefinition(string bluePrintName)
        {
            try
            {
                var definitionID = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), bluePrintName);
                return MyDefinitionManager.Static.GetBlueprintDefinition(definitionID);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

        public static T TryGetDefinition<T>(string subtype) where T : MyDefinitionBase
        {
            try
            {
                var lista = MyDefinitionManager.Static.GetDefinitionsOfType<T>();
                var subtypehash = MyStringHash.Get(subtype);
                return lista.FirstOrDefault(x => x.Id.SubtypeId == subtypehash);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

        public static T TryGetDefinition<T>(MyDefinitionId id) where T : MyDefinitionBase
        {
            try
            {
                return MyDefinitionManager.Static.GetDefinition(id) as T;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

        public static bool IsDefinitionExists(MyDefinitionId id)
        {
            try
            {
                return MyDefinitionManager.Static.GetAllDefinitions().Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
                return false;
            }
        }

        public static T TryGetDefinitionBySubType<T>(string subtype) where T : MyDefinitionBase
        {
            try
            {
                return MyDefinitionManager.Static.GetAllDefinitions<T>().FirstOrDefault(x => x.Id.SubtypeName == subtype);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

        public static MyBlockVariantGroup GetBlockVariantGroup(string subtype)
        {
            try
            {
                var query = MyDefinitionManager.Static.GetBlockVariantGroupDefinitions();
                if (query.Any(x => x.Key == subtype))
                    return query.FirstOrDefault(x => x.Key == subtype).Value;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

        public static MySpawnGroupDefinition GetSpawnGroup(string subtype)
        {
            try
            {
                var query = MyDefinitionManager.Static.GetSpawnGroupDefinitions();
                if (query.Any(x => x.Id.SubtypeName == subtype))
                    return query.FirstOrDefault(x => x.Id.SubtypeName == subtype);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
            return null;
        }

    }

}