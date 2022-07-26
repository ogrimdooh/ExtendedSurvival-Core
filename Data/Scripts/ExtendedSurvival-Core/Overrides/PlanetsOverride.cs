using Sandbox.Definitions;
using System;
using System.Linq;
using VRage.Game;

namespace ExtendedSurvival
{

    public class PlanetsOverride
    {

        public static void SetDefinitions()
        {
            var planets = MyDefinitionManager.Static.GetPlanetsGeneratorsDefinitions();
            foreach (var definition in planets)
            {
                try
                {
                    var info = ExtendedSurvivalSettings.Instance.GetPlanetInfo(definition.Id.SubtypeName);
                    if (info != null)
                    {
                        definition.OreMappings = info.GetOreMap();
                        definition.AnimalSpawnInfo = info.Animal.GetDaySpawnDefinition();
                        definition.NightAnimalSpawnInfo = info.Animal.GetNightSpawnDefinition();
                        definition.DefaultSurfaceTemperature = (MyTemperatureLevel)info.Atmosphere.TemperatureLevel;
                        definition.HasAtmosphere = info.Atmosphere.Enabled;
                        definition.Atmosphere = info.Atmosphere.GetAtmosphere();
                        definition.GravityFalloffPower = info.Gravity.GravityFalloffPower;
                        definition.SurfaceGravity = info.Gravity.SurfaceGravity;
                        definition.Postprocess();
                        ExtendedSurvivalLogging.Instance.LogInfo(typeof(PlanetsOverride), $"Override planet definition : {definition.Id.SubtypeName}");
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalLogging.Instance.LogError(typeof(PlanetsOverride), ex);
                }
            }
        }

    }

}