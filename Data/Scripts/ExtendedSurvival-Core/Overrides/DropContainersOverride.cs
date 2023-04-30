using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System.Collections.Concurrent;
using System.Linq;

namespace ExtendedSurvival.Core
{
    public sealed class DropContainersOverride : BaseModIntegrationOverride
    {

        public const string DEFAULT_PARACHUTE_NAME = "TARGET_PARACHUTE";

        public static readonly ConcurrentBag<string> DropContainerPrefabs = new ConcurrentBag<string>();

        public static void TryOverride()
        {
            new DropContainersOverride().SetDefinitions();
        }

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override void OnSetDefinitions()
        {
            var defs = MyDefinitionManager.Static.GetDropContainerDefinitions();
            foreach (var key in defs.Keys)
            {
                foreach (var cubeGrid in defs[key].Prefab.CubeGrids)
                {
                    var query = cubeGrid.CubeBlocks.Where(x => x.TypeId == typeof(MyObjectBuilder_Parachute));
                    if (query.Any())
                    {
                        DropContainerPrefabs.Add(cubeGrid.DisplayName);
                    foreach (var parachute in query)
                    {
                            var parachuteDef = (parachute as MyObjectBuilder_Parachute);
                            if (parachuteDef != null)
                            {
                                parachuteDef.AutoDeploy = true;
                                parachuteDef.DeployHeight = ExtendedSurvivalSettings.Instance.DropContainerDeployHeight;
                                parachuteDef.Name = DEFAULT_PARACHUTE_NAME;
                            }
                        }
                    }
                }
            }
        }
    }

}