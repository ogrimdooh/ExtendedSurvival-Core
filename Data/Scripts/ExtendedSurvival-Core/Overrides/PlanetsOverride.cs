using Sandbox.Definitions;
using Sandbox.Game.WorldEnvironment.Definitions;
using Sandbox.Game.WorldEnvironment.ObjectBuilders;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VRage.Game;
using VRage.Utils;

namespace ExtendedSurvival.Core
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

        private static void CheckGeothermalDefinitions(PlanetSetting info, MyPlanetGeneratorDefinition definition)
        {
            // Create a surface layer
            if (!definition.DefaultSurfaceMaterial.HasLayers)
            {
                definition.DefaultSurfaceMaterial.Layers = new MyPlanetMaterialLayer[]
                {
                    new MyPlanetMaterialLayer()
                    {
                        Material = definition.DefaultSurfaceMaterial.Material,
                        Depth = definition.DefaultSurfaceMaterial.MaxDepth
                    }
                };
            }
            // Create a stone layer
            if (definition.DefaultSubSurfaceMaterial == null)
                definition.DefaultSubSurfaceMaterial = new MyPlanetMaterialDefinition()
                {
                    Material = VoxelMaterialMapProfile.Stone
                };
            definition.DefaultSurfaceMaterial.MaxDepth = info.Geothermal.Start;
            var maxDepth = definition.DefaultSurfaceMaterial.Layers.Sum(x => x.Depth);
            definition.DefaultSurfaceMaterial.Layers = definition.DefaultSurfaceMaterial.Layers.Append(new MyPlanetMaterialLayer()
            {
                Material = definition.DefaultSubSurfaceMaterial.Material,
                Depth = definition.DefaultSurfaceMaterial.MaxDepth - maxDepth
            }).ToArray();
            foreach (var group in definition.MaterialGroups)
            {
                foreach (var rule in group.MaterialRules)
                {
                    maxDepth = rule.Layers.Sum(x => x.Depth);
                    rule.Layers = rule.Layers.Append(new MyPlanetMaterialLayer()
                    {
                        Material = definition.DefaultSubSurfaceMaterial.Material,
                        Depth = definition.DefaultSurfaceMaterial.MaxDepth - maxDepth
                    }).ToArray();
                }
            }
            // Create a lava layer
            definition.DefaultSubSurfaceMaterial.Material = VoxelMaterialMapProfile.LavaSoil_01;
        }

        public static void DoApplyPlanetDefinitionChanges(MyPlanetGeneratorDefinition definition,
            Dictionary<string, string> materialsToRemove, Dictionary<string, string> materialsToRemoveIfOver128, 
            Dictionary<string, float> materialsToChangeDepth, Dictionary<string, float> materialsToAddDirty)
        {
            // Check over 128
            foreach (var k in materialsToRemoveIfOver128.Keys)
            {
                MyVoxelMaterialDefinition voxel;
                if (MyDefinitionManager.Static.TryGetVoxelMaterialDefinition(k, out voxel))
                {
                    if (voxel.Index >= 128)
                    {
                        materialsToRemove.Add(k, materialsToRemoveIfOver128[k]);
                    }
                }
            }
            // Set Groups
            foreach (var group in definition.MaterialGroups)
            {
                if (materialsToChangeDepth != null && materialsToChangeDepth.Any())
                {
                    foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToChangeDepth.ContainsKey(y.Material))))
                    {
                        rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer()
                        {
                            Material = x.Material,
                            Depth = materialsToChangeDepth.ContainsKey(x.Material) ? materialsToChangeDepth[x.Material] : x.Depth
                        }).ToArray();
                    }
                }
                if (materialsToAddDirty != null && materialsToAddDirty.Any())
                {
                    foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToAddDirty.ContainsKey(y.Material))))
                    {
                        var material = rule.Layers.FirstOrDefault(y => materialsToAddDirty.ContainsKey(y.Material)).Material;
                        rule.Layers = rule.Layers.Append(new MyPlanetMaterialLayer()
                        {
                            Material = VoxelMaterialMapProfile.DirtySoil_01,
                            Depth = materialsToAddDirty[material]
                        }).ToArray();
                    }
                }
                if (materialsToRemove != null && materialsToRemove.Any())
                {
                    foreach (var rule in group.MaterialRules.Where(x => x.Layers.Any(y => materialsToRemove.ContainsKey(y.Material))))
                    {
                        rule.Layers = rule.Layers.Select(x => new MyPlanetMaterialLayer()
                        {
                            Material = materialsToRemove.ContainsKey(x.Material) ? materialsToRemove[x.Material] : x.Material,
                            Depth = x.Depth
                        }).ToArray();
                    }
                }
            }
            if (materialsToRemove != null && materialsToRemove.Any())
            {
                // Weather
                foreach (var weather in definition.WeatherGenerators.Where(x => materialsToRemove.ContainsKey(x.Voxel)))
                {
                    weather.Voxel = materialsToRemove[weather.Voxel];
                }
            }
        }

        private static void CheckCustomPlanetsDefinitions(MyPlanetGeneratorDefinition definition)
        {
            switch (definition.Id.SubtypeName.ToUpper())
            {
                case VanilaMapProfile.DEFAULT_MOON:
                    ApplyMoonSettings(definition);
                    break;
                case VanilaMapProfile.DEFAULT_EUROPA:
                    ApplyEuropaSettings(definition);
                    break;
                case VanilaMapProfile.DEFAULT_MARS:
                    ApplyMarsSettings(definition);
                    break;
                case GHOSTXVMapProfile.DEFAULT_AVALAN:
                    GHOSTXVMapProfile.ApplyAvalanSettings(definition);
                    break;
                case GHOSTXVMapProfile.DEFAULT_NYOTA:
                    GHOSTXVMapProfile.ApplyNyotaSettings(definition);
                    break;
                case AlmiranteOrlocProfile.DEFAULT_OBJECT85:
                    AlmiranteOrlocProfile.ApplyObject85Settings(definition);
                    break;
                case SamMapProfile.DEFAULT_HELIOSTERRAFORMED:
                case SamMapProfile.DEFAULT_HELIOSTERRAFORMEDWM:
                    SamMapProfile.ApplyHeliosTerraformedSettings(definition);
                    break;
            }
        }

        private const string RespawnPlanetPod = "RespawnPlanetPod";
        private const string RespawnMoonPod = "RespawnMoonPod";
        private const string RespawnSpacePod = "RespawnSpacePod";

        public const string ESSimpleRespawnPlanetPod = "ESSimpleRespawnPlanetPod";
        public const string ESSimpleSpaceRespawnPod = "ESSimpleSpaceRespawnPod";
        public const string ESRespawnPlanetPod = "ESRespawnPlanetPod";
        public const string ESSpaceRespawnPod = "ESSpaceRespawnPod";

        public const string ESRespawnPlanetPodHeavy = "ESRespawnPlanetPodHeavy";

        public const string ESRespawnPlanetLargePod = "ESRespawnPlanetLargePod";
        public const string ESSimpleRespawnPlanetLargePod = "ESSimpleRespawnPlanetLargePod";

        public const string ESRespawnPlanetLiftedLargePod = "ESRespawnPlanetLiftedLargePod";
        public const string ESSimpleRespawnPlanetLiftedLargePod = "ESSimpleRespawnPlanetLiftedLargePod";

        private static string[] VALID_RESPAWN_SHIPS = new string[] { ESSimpleRespawnPlanetPod, ESSimpleRespawnPlanetPod, ESSimpleSpaceRespawnPod };
        private static string[] TECH_VALID_RESPAWN_SHIPS = new string[] { ESRespawnPlanetPod, ESRespawnPlanetPod, ESSpaceRespawnPod };

        private static string[] TECH_VALID_RESPAWN_HEAVY_SHIPS = new string[] { ESRespawnPlanetPodHeavy, ESRespawnPlanetPodHeavy, ESSpaceRespawnPod };

        private static string[] VALID_RESPAWN_LARGE_SHIPS = new string[] { ESSimpleRespawnPlanetLargePod, ESSimpleRespawnPlanetLargePod, ESSimpleSpaceRespawnPod };
        private static string[] TECH_VALID_RESPAWN_LARGE_SHIPS = new string[] { ESRespawnPlanetLargePod, ESRespawnPlanetLargePod, ESSpaceRespawnPod };

        private static string[] VALID_RESPAWN_LIFTED_LARGE_SHIPS = new string[] { ESSimpleRespawnPlanetLiftedLargePod, ESSimpleRespawnPlanetLiftedLargePod, ESSimpleSpaceRespawnPod };
        private static string[] TECH_VALID_RESPAWN_LIFTED_LARGE_SHIPS = new string[] { ESRespawnPlanetLiftedLargePod, ESRespawnPlanetLiftedLargePod, ESSpaceRespawnPod };

        // Need to disable EMM start ships to avoid no valid starts
        private static string[] TARGET_RESPAWN_SHIPS_TO_DISABLE = new string[] { "Range_Runner_Respawncar", "Little_Bird_Respawnship", "Ibis_Respawnship", "M3_Miner_Respawnship" };

        public const ulong ZLIFTEDWHEELSUSPENSION_MOD_ID = 2727185097;

        public static void SetDefinitions()
        {
            // Override Planets
            var respawnPlanets = new List<string>();
            var planets = MyDefinitionManager.Static.GetPlanetsGeneratorsDefinitions();
            foreach (var definition in planets)
            {
                try
                {
                    var info = ExtendedSurvivalSettings.Instance.GetPlanetInfo(definition.Id.SubtypeName);
                    if (info != null)
                    {
                        if (info.RespawnEnabled)
                            respawnPlanets.Add(definition.Id.SubtypeName);
                        definition.OreMappings = info.GetOreMap();
                        definition.AnimalSpawnInfo = info.Animal.GetDaySpawnDefinition();
                        definition.NightAnimalSpawnInfo = info.Animal.GetNightSpawnDefinition();
                        definition.DefaultSurfaceTemperature = (MyTemperatureLevel)info.Atmosphere.TemperatureLevel;
                        definition.HasAtmosphere = info.Atmosphere.Enabled;
                        definition.Atmosphere = info.Atmosphere.GetAtmosphere();
                        definition.GravityFalloffPower = info.Gravity.GravityFalloffPower;
                        definition.SurfaceGravity = info.Gravity.SurfaceGravity;                        
                        CheckCustomPlanetsDefinitions(definition);
                        if (info.Geothermal.Enabled)
                        {
                            CheckGeothermalDefinitions(info, definition);
                        }
                        definition.Postprocess();
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(PlanetsOverride), $"Override planet definition : {definition.Id.SubtypeName}");
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(PlanetsOverride), ex);
                }
            }
            // Override VoxelMaterialModifierDefinition
            var modifiers = MyDefinitionManager.Static.GetAllDefinitions<MyVoxelMaterialModifierDefinition>();
            if (modifiers != null && modifiers.Any())
            {
                foreach (var modifier in modifiers)
                {
                    if (VoxelMaterialModifierMapProfile.IGNORE_LIST.Contains(modifier.Id.SubtypeName))
                        continue;
                    var info = ExtendedSurvivalSettings.Instance.GetMaterialModifierInfo(modifier.Id.SubtypeName);
                    if (info != null)
                    {
                        var options = info.BuildOptions();
                        modifier.Options = new MyDiscreteSampler<VoxelMapChange>(((IEnumerable<MyVoxelMapModifierOption>)options).Select<MyVoxelMapModifierOption, VoxelMapChange>((Func<MyVoxelMapModifierOption, VoxelMapChange>)(x => new VoxelMapChange()
                        {
                            Changes = x.Changes == null ? (Dictionary<byte, byte>)null : ((IEnumerable<MyVoxelMapModifierChange>)x.Changes).ToDictionary<MyVoxelMapModifierChange, byte, byte>((Func<MyVoxelMapModifierChange, byte>)(y => MyDefinitionManager.Static.GetVoxelMaterialDefinition(y.From).Index), (Func<MyVoxelMapModifierChange, byte>)(y => MyDefinitionManager.Static.GetVoxelMaterialDefinition(y.To).Index))
                        })), ((IEnumerable<MyVoxelMapModifierOption>)options).Select<MyVoxelMapModifierOption, float>((Func<MyVoxelMapModifierOption, float>)(x => x.Chance)));
                    }
                }
            }
            // Override Start Ships
            var validShips = ExtendedSurvivalCoreSession.IsUsingTechnology() ? TECH_VALID_RESPAWN_SHIPS : VALID_RESPAWN_SHIPS;
            if (ExtendedSurvivalSettings.Instance.RespawnLargePodEnabled)
            {
                if (MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == ZLIFTEDWHEELSUSPENSION_MOD_ID))
                {
                    validShips = ExtendedSurvivalCoreSession.IsUsingTechnology() ? TECH_VALID_RESPAWN_LIFTED_LARGE_SHIPS : VALID_RESPAWN_LIFTED_LARGE_SHIPS;
                }
                else
                {
                    validShips = ExtendedSurvivalCoreSession.IsUsingTechnology() ? TECH_VALID_RESPAWN_LARGE_SHIPS : VALID_RESPAWN_LARGE_SHIPS;
                }
            }
            var minPlanetDeployAltitude = 125;
            if (ExtendedSurvivalSettings.Instance.RespawnHeavyPodEnabled && ExtendedSurvivalCoreSession.IsUsingTechnology() && ExtendedSurvivalCoreSession.IsUsingStatsAndEffects())
            {
                validShips = TECH_VALID_RESPAWN_HEAVY_SHIPS;
                minPlanetDeployAltitude = 250;
            }
            var planetShip = MyDefinitionManager.Static.GetRespawnShipDefinition(RespawnPlanetPod);
            if (planetShip != null)
            {
                planetShip.PlanetDeployAltitude = Math.Max(minPlanetDeployAltitude, ExtendedSurvivalSettings.Instance.PlanetDeployAltitude);
                planetShip.Prefab = MyDefinitionManager.Static.GetPrefabDefinition(validShips[0]);
                planetShip.PlanetTypes = respawnPlanets.ToArray();
                planetShip.Icons = new string[] { GetCustomIcon(planetShip.Context, validShips[0]) };
                planetShip.Postprocess();
            }
            var moonShip = MyDefinitionManager.Static.GetRespawnShipDefinition(RespawnMoonPod);
            if (moonShip != null)
            {
                moonShip.PlanetDeployAltitude = Math.Max(minPlanetDeployAltitude, ExtendedSurvivalSettings.Instance.MoonDeployAltitude);
                moonShip.Prefab = MyDefinitionManager.Static.GetPrefabDefinition(validShips[1]);
                moonShip.PlanetTypes = respawnPlanets.ToArray();
                moonShip.Icons = new string[] { GetCustomIcon(planetShip.Context, validShips[1]) };
                moonShip.Postprocess();
            }
            var spaceShip = MyDefinitionManager.Static.GetRespawnShipDefinition(RespawnSpacePod);
            if (spaceShip != null)
            {
                spaceShip.Prefab = MyDefinitionManager.Static.GetPrefabDefinition(validShips[2]);
                spaceShip.UseForSpace = ExtendedSurvivalSettings.Instance.RespawnSpacePodEnabled;
                spaceShip.Icons = new string[] { GetCustomIcon(planetShip.Context, validShips[2]) };
                spaceShip.Postprocess();
            }
            foreach (var item in TARGET_RESPAWN_SHIPS_TO_DISABLE)
            {
                var spaceShipToDisable = MyDefinitionManager.Static.GetRespawnShipDefinition(item);
                if (spaceShipToDisable != null)
                {
                    spaceShipToDisable.UseForSpace = false;
                    spaceShipToDisable.PlanetTypes = new string[] { };
                    spaceShipToDisable.Postprocess();
                }
            }
            // Check star system saved info
            var defaultStarProfiles = StarSystemMapProfile.Keys();
            foreach (var starProfileKey in defaultStarProfiles)
            {
                ExtendedSurvivalSettings.Instance.GetStarSystemInfo(starProfileKey);
            }
        }

        private static readonly Dictionary<string, BaseIntegrationModRecipesOverride.ExternalModCustomIcon> Blocks_CustomIcon = new Dictionary<string, BaseIntegrationModRecipesOverride.ExternalModCustomIcon>()
        {
            { ESSimpleRespawnPlanetPod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESSimpleRespawnPlanetPod.png", false) },
            { ESSimpleSpaceRespawnPod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESSimpleRespawnSpacePod.png", false) },
            { ESRespawnPlanetPod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESSimpleRespawnPlanetPod.png", false) },
            { ESSpaceRespawnPod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnSpacePod.png", false) },
            { ESRespawnPlanetLargePod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnPlanetLargePod.png", false)  },
            { ESSimpleRespawnPlanetLargePod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnPlanetLargePod.png", false) },
            { ESRespawnPlanetLiftedLargePod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnPlanetLargePod.png", false)  },
            { ESSimpleRespawnPlanetLiftedLargePod, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnPlanetLargePod.png", false) },
            { ESRespawnPlanetPodHeavy, new BaseIntegrationModRecipesOverride.ExternalModCustomIcon("Textures\\GUI\\Icons\\RespawnShips\\ESRespawnPlanetPodHeavy.png", false) }
        };

        private static string GetCustomIcon(MyModContext baseContext, string key)
        {
            if (Blocks_CustomIcon.ContainsKey(key))
            {
                var icon = Blocks_CustomIcon[key].Icon;
                if (Blocks_CustomIcon[key].SamePath)
                {
                    icon = System.IO.Path.Combine(baseContext.ModPath, icon);
                }
                else
                {
                    icon = System.IO.Path.Combine(BaseIntegrationModRecipesOverride.GetESCoreContext().ModPath, icon);
                }
                return icon;
            }
            return null;
        }

    }

}