using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Linq;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public class PlanetEntity : EntityBase<MyPlanet>
    {

        private RelativeToSunPosition relativeToSunPosition = new RelativeToSunPosition();

        public static MyTemperatureLevel TemperatureToLevel(float temperature)
        {
            if (temperature <= 0)
                return MyTemperatureLevel.ExtremeFreeze;
            if (temperature <= 10)
                return MyTemperatureLevel.Freeze;
            if (temperature <= 35)
                return MyTemperatureLevel.Cozy;
            return temperature <= 55 ? MyTemperatureLevel.Hot : MyTemperatureLevel.ExtremeHot;
        }

        public static Vector2 LevelToTemperature(MyTemperatureLevel level)
        {
            switch (level)
            {
                case MyTemperatureLevel.ExtremeFreeze:
                    return new Vector2(-50, 0);
                case MyTemperatureLevel.Freeze:
                    return new Vector2(0, 10);
                case MyTemperatureLevel.Cozy:
                    return new Vector2(10, 35);
                case MyTemperatureLevel.Hot:
                    return new Vector2(35, 55);
                case MyTemperatureLevel.ExtremeHot:
                    return new Vector2(55, 100);
                default:
                    return new Vector2(10, 35);
            }
        }

        public string SubtypeName { get; private set; }

        public bool HasSubtypeName
        {
            get
            {
                return !string.IsNullOrEmpty(SubtypeName);
            }
        }

        private PlanetSetting _setting;
        public PlanetSetting Setting
        {
            get
            {
                if (_setting == null && HasSubtypeName)
                    _setting = ExtendedSurvivalSettings.Instance.GetPlanetInfo(SubtypeName, false);
                return _setting;
            }
        }

        public PlanetEntity(MyPlanet entity)
            : base(entity)
        {
            if (!string.IsNullOrEmpty(entity.Generator.Id.SubtypeName))
            {
                SubtypeName = entity.Generator.Id.SubtypeName;
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"SubtypeName is null at planet Name:{entity.Name}");
        }

        public Vector3D Center()
        {
            return Entity?.PositionComp?.WorldAABB.Center ?? Vector3D.Zero;
        }

        public bool HasWater()
        {
            return WaterModAPI.Registered && WaterModAPI.HasWater(Entity);
        }

        public bool IsUnderWater(Vector3D coords, out float depth)
        {
            depth = 0;
            if (HasWater() && WaterModAPI.IsUnderwater(coords))
            {
                depth = WaterModAPI.GetDepth(coords).Value * -1;
                return depth > 1.5f;
            }
            return false;
        }

        public Vector3D SurfaceAtPosition(Vector3D coords)
        {
            return Entity?.GetClosestSurfacePointGlobal(coords) ?? Vector3D.Zero;
        }

        public Vector3D UpAtPosition(Vector3D coords)
        {
            return Vector3D.Normalize(coords - Center());
        }
        /*
        private Vector3 CalculateSunDirection()
        {
            var m_speed = 60f * MyAPIGateway.Session.SessionSettings.SunRotationIntervalMinutes;
            var ElapsedGameTime = MyAPIGateway.Session.GameDateTime - new DateTime(2081, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Vector3 sunDirection = Vector3.Transform(this.m_baseSunDirection, Matrix.CreateFromAxisAngle(this.m_sunRotationAxis, (double)m_speed > 0.0 ? 6.283186f * ((float)ElapsedGameTime.TotalSeconds / m_speed) : 0.0f));
            double num = (double)sunDirection.Normalize();
            return sunDirection;
        }
        */
        public float GetTemperatureInPoint(Vector3D worldPoint, out float temperatureValue)
        {
            temperatureValue = 0;
            try
            {
                Vector2 temperatureRange = new Vector2(0, 45);
                if (Setting != null)
                    temperatureRange = new Vector2(Setting.Atmosphere.TemperatureRange.X, Setting.Atmosphere.TemperatureRange.Y);
                float airInPoint = Entity.GetAirDensity(worldPoint);
                float airSaturation = MathHelper.Saturate(airInPoint / 0.6f);
                float distanceFromSurface = (float)Vector3D.Distance(Entity.PositionComp.GetPosition(), worldPoint) / Entity.AverageRadius;
                float sunLightMultiplier = Vector3.Dot(Vector3.Normalize(worldPoint - Entity.PositionComp.GetPosition()), ExtendedSurvivalCoreSession.Static.SunDirectionNormalized);
                if (sunLightMultiplier < 0)
                    sunLightMultiplier = 0;
                MyTemperatureLevel level = MyTemperatureLevel.Cozy;
                if (Setting != null)
                    level = (MyTemperatureLevel)Setting.Atmosphere.TemperatureLevel;
                var weatherComponent = MyAPIGateway.Session.WeatherEffects;
                var defaultTemperatureAtPoint = LevelToTemperature(level);
                float temperatureAtSun = MathHelper.Lerp(defaultTemperatureAtPoint.X, defaultTemperatureAtPoint.Y, sunLightMultiplier);
                float temperatureInPoint;
                if (distanceFromSurface < 1.0)
                {
                    float distanceFactor = 0.8f;
                    float distanceSaturation = MathHelper.Saturate(distanceFromSurface / distanceFactor);
                    temperatureInPoint = MathHelper.Lerp(temperatureRange.Y, temperatureAtSun, distanceSaturation);
                }
                else
                    temperatureInPoint = MathHelper.Lerp(temperatureRange.X, temperatureAtSun, airSaturation);
                if (temperatureInPoint < temperatureRange.X)
                    temperatureInPoint = temperatureRange.X;
                if (temperatureInPoint > temperatureRange.Y)
                    temperatureInPoint = temperatureRange.Y;
                // Biome
                var closeSurfacePoint = Entity.GetClosestSurfacePointGlobal(worldPoint);
                var surfaceMaterial = Entity.GetMaterialAt(ref closeSurfacePoint);
                if (surfaceMaterial != null)
                {
                    var surfaceType = surfaceMaterial.Id.SubtypeName.ToUpper();                    
                    var isSnow = surfaceType.Contains("SNOW") ||
                        surfaceType.Contains("ICE");
                    var tempChangeFactor = Math.Abs(temperatureInPoint / 4);
                    var temperatureModifier = 0f;
                    var forceMultiplier = 1f;
                    if (isSnow)
                    {
                        temperatureModifier = 0.6f;
                    }
                    else
                    {
                        var isMountain = surfaceType.Contains("ROCK") ||
                            surfaceType.Contains("STONE") ||
                            surfaceType.Contains("MOUNTAIN");
                        if (isMountain)
                        {
                            temperatureModifier = 0.85f;
                        }
                        else
                        {
                            var isDesert = surfaceType.Contains("SAND");
                            if (isDesert)
                            {
                                temperatureModifier = 1.25f;
                            }
                            else
                            {
                                var isOld = surfaceType.Contains("OLD");
                                if (isOld)
                                {
                                    temperatureModifier = 1.05f;
                                }
                            }
                        }
                    }
                    if (temperatureModifier > 1)
                    {
                        temperatureInPoint += (tempChangeFactor * (temperatureModifier - 1)) * forceMultiplier;
                    }
                    else if (temperatureModifier > 0)
                    {
                        temperatureInPoint -= (tempChangeFactor * (1 - temperatureModifier)) * forceMultiplier;
                    }
                }
                // Underground
                if (Entity.IsUnderGround(worldPoint))
                {
                    var distanceToSurface = Vector3D.Distance(worldPoint, closeSurfacePoint);
                    var tempChangeFactor = Math.Abs(temperatureInPoint / 2);
                    var temperatureModifier = 0f;
                    var forceMultiplier = 1f;
                    
                    if (temperatureModifier > 1)
                    {
                        temperatureInPoint += (tempChangeFactor * (temperatureModifier - 1)) * forceMultiplier;
                    }
                    else if (temperatureModifier > 0)
                    {
                        temperatureInPoint -= (tempChangeFactor * (1 - temperatureModifier)) * forceMultiplier;
                    }
                }
                // Weather
                var wName = weatherComponent.GetWeather(worldPoint);
                MyWeatherEffectDefinition weatherEffect = MyDefinitionManager.Static.GetWeatherEffect(wName);
                if (weatherEffect != null)
                {
                    var forceMultiplier = wName.Contains("Heavy") ? 2.0f : 1.0f;
                    var tempChangeFactor = Math.Abs(temperatureInPoint / 2);
                    var weatherChangeFactor = weatherComponent.GetTemperatureMultiplier(worldPoint);
                    if (weatherEffect.TemperatureModifier > 1)
                    {
                        temperatureInPoint += (tempChangeFactor * (weatherChangeFactor - 1)) * forceMultiplier;
                    }
                    else
                    {
                        temperatureInPoint -= (tempChangeFactor * (1 - weatherChangeFactor)) * forceMultiplier;
                    }
                }
                // UnderWater
                float depth = 0;
                if (Setting != null && Setting.Water.Enabled && IsUnderWater(worldPoint, out depth))
                {
                    temperatureInPoint += (depth / 10) * Setting.Water.TemperatureFactor;
                }
                temperatureValue = temperatureInPoint;
                var maxTemperature = temperatureRange.Y - temperatureRange.X;
                return (temperatureValue - temperatureRange.X) / maxTemperature;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return 0;
        }

    }

}