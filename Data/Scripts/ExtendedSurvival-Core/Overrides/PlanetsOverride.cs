﻿using Sandbox.Definitions;
using System;
using System.Linq;
using VRage.Game;

namespace ExtendedSurvival
{

    public class PlanetsOverride
    {

        private static void ApplyMoonSettings(MyPlanetGeneratorDefinition definition)
        {
            string[] materialsToRemove = new string[] { VoxelMaterialMapProfile.Ice };
            definition.SurfaceMaterialTable = definition.SurfaceMaterialTable.Where(x => !materialsToRemove.Contains(x.Material)).ToArray();
            foreach (var group in definition.MaterialGroups)
            {
                foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToRemove.Contains(y.Material))))
                {
                    rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer()
                    {
                        Material = materialsToRemove.Contains(x.Material) ? VoxelMaterialMapProfile.AlienSnow : x.Material,
                        Depth = x.Depth
                    }).ToArray();
                }
            }
        }

        private static void ApplyEuropaSettings(MyPlanetGeneratorDefinition definition)
        {
            string[] materialsToRemove = new string[] { VoxelMaterialMapProfile.Ice, VoxelMaterialMapProfile.Ice_01 };
            definition.DefaultSurfaceMaterial.Material = VoxelMaterialMapProfile.IceEuropa2;
            definition.DefaultSubSurfaceMaterial.Material = VoxelMaterialMapProfile.IceEuropa2;
            definition.SurfaceMaterialTable = definition.SurfaceMaterialTable.Where(x => !materialsToRemove.Contains(x.Material)).ToArray();
            foreach (var group in definition.MaterialGroups)
            {
                foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToRemove.Contains(y.Material))))
                {
                    rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer()
                    {
                        Material = materialsToRemove.Contains(x.Material) ? VoxelMaterialMapProfile.AlienSnow : x.Material,
                        Depth = x.Depth
                    }).ToArray();
                }
            }
        }

        private static void ApplyMarsSettings(MyPlanetGeneratorDefinition definition)
        {
            string[] materialsToRemove = new string[] { VoxelMaterialMapProfile.Snow };
            foreach (var group in definition.MaterialGroups)
            {
                foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y=> materialsToRemove.Contains(y.Material))))
                {
                    rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer() 
                    { 
                        Material = materialsToRemove.Contains(x.Material) ? VoxelMaterialMapProfile.AlienSnow : x.Material,
                        Depth = x.Depth
                    }).ToArray();
                }
            }
        }

        private static void CheckCustomPlanetsDefinitions(MyPlanetGeneratorDefinition definition)
        {
            switch (definition.Id.SubtypeName.ToUpper())
            {
                case PlanetMapProfile.DEFAULT_MOON:
                    ApplyMoonSettings(definition);
                    break;
                case PlanetMapProfile.DEFAULT_EUROPA:
                    ApplyEuropaSettings(definition);
                    break;
                case PlanetMapProfile.DEFAULT_MARS:
                    ApplyMarsSettings(definition);
                    break;
            }
        }

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
                        CheckCustomPlanetsDefinitions(definition);
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