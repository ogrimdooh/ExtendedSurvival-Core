using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class StarSystemController
    {

        [Flags]
        public enum StarSystemProfile
        {

            None = 0,
            Vanilla = 1,
            ExtendedSurvival = 2,
            ATA = 4

        }

        public enum GenerationType
        {

            MappedProfile = 0,
            Random = 1

        }

        public static readonly Vector2 PLANET_MOON_BUFFER = new Vector2(150f, 300f);
        public static readonly Vector2 GIANTGAS_MOON_BUFFER = new Vector2(2000f, 2500f);
        public const float KILOMETERS_TO_METERS = 1000f;
        public const float TAU = (float)(Math.PI * 2f);
        public const float SLICE = (float)(Math.PI * 0.5f);
        public const float DEFAULT_INCLINATION = 45f;
        public static readonly Vector2 DEFAULT_PLANETARY_DISTANCE = new Vector2(1500f, 7500f);
        public const float GAS_GIANT_DISTANCE_MULTIPLIER = 2f;

        public static bool ComputeNewStarSystem(StarSystemProfile profile, GenerationType generationType, bool withStar, int itensAmmount, bool allowDuplicated, float distanceMultiplier)
        {
            if (!ExtendedSurvivalEntityManager.Instance.HasPlanets())
            {
                switch (generationType)
                {
                    case GenerationType.MappedProfile:
                        var profiles = profile.GetFlags();
                        if (profiles.Count(x => x != StarSystemProfile.None) != 1)
                            return false;
                        break;
                    case GenerationType.Random:

                        break;
                }
                var planets = new List<PlanetSetting>();
                if (profile == StarSystemProfile.None)
                {
                    planets = ExtendedSurvivalSettings.Instance.Planets.OrderBy(x => x.Order).ToList();
                }
                else
                {
                    foreach (StarSystemProfile flag in profile.GetFlags())
                    {
                        switch (flag)
                        {
                            case StarSystemProfile.Vanilla:
                                planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                    PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.Vanila
                                ).OrderBy(x => x.Order));
                                break;
                            case StarSystemProfile.ExtendedSurvival:
                                planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                    PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.ExtendedSurvival
                                ).OrderBy(x => x.Order));
                                break;
                            case StarSystemProfile.ATA:
                                planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                    PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.OtherMod &&
                                    PlanetMapProfile.Get(x.Id.ToUpper()).OriginId == ATAMapProfile.ATA_MODID
                                ).OrderBy(x => x.Order));
                                break;
                        }
                    }
                }                
                if (planets.Any())
                {
                    var createdPlanets = new Dictionary<string, float>();
                    if (withStar)
                    {
                        PlanetSetting sunProfile = null;
                        if (planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Star))
                        {
                            sunProfile = planets.FirstOrDefault(x => x.Type == (int)PlanetProfile.PlanetType.Star);

                        }
                        else if (ExtendedSurvivalSettings.Instance.Planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Star))
                        {
                            sunProfile = ExtendedSurvivalSettings.Instance.Planets.FirstOrDefault(x => x.Type == (int)PlanetProfile.PlanetType.Star);
                        }
                        if (sunProfile != null)
                        {
                            var pos = Vector3D.Zero;
                            var size = new Vector2(sunProfile.SizeRange.X, sunProfile.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS;
                            MyAPIGateway.Session.VoxelMaps.SpawnPlanet(sunProfile.Id, size, new Vector2I(1000000, 10000000).GetRandomInt(), pos);
                            createdPlanets.Add(sunProfile.Id, size / KILOMETERS_TO_METERS);
                        }
                    }
                    int sectors = 0;
                    double sectorSize = 0;
                    double deviation = 0;
                    double eclipticRotation = 0;
                    float currentSystemSize = createdPlanets.Any() ? createdPlanets.FirstOrDefault().Value + DEFAULT_PLANETARY_DISTANCE.GetRandom() : 0;
                    IQueryable<PlanetSetting> query = null;
                    switch (generationType)
                    {
                        case GenerationType.MappedProfile:
                            query = planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Planet || x.Type == (int)PlanetProfile.PlanetType.GiantGas).OrderBy(x => x.Order).AsQueryable();
                            sectors = query.Count();
                            break;
                        case GenerationType.Random:
                            query = planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Planet || x.Type == (int)PlanetProfile.PlanetType.GiantGas).OrderBy(x => GetRandomDouble()).Take(itensAmmount).AsQueryable();
                            var lista = query.ToList();
                            if (lista.Count < itensAmmount && allowDuplicated)
                            {
                                while (lista.Count < itensAmmount)
                                {
                                    lista.Add(query.FirstOrDefault());
                                }
                            }
                            if (lista.Any(x => !x.RespawnEnabled))
                            {
                                var index = new Vector2I(0, lista.Count - 1).GetRandomInt();
                                lista[index] = planets.Where(x => x.RespawnEnabled && x.Type == (int)PlanetProfile.PlanetType.Planet).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                            }
                            sectors = lista.Count;
                            query = lista.AsQueryable();
                            break;
                    }
                    sectorSize = TAU / sectors;
                    deviation = 0.25f * sectorSize;
                    eclipticRotation = GetRandomDouble() * TAU;
                    int i = 0;
                    PlanetSetting lastCreated = null;
                    foreach (var item in query)
                    {
                        var theta = eclipticRotation + sectorSize * i + (GetRandomDouble() * 2 - 1) * deviation;
                        var phi = (GetRandomDouble() * 2 - 1) * DEFAULT_INCLINATION;
                        var minDistanceKm = currentSystemSize;
                        var incrementDistance = DEFAULT_PLANETARY_DISTANCE.GetRandom();
                        if (item.Type == (int)PlanetProfile.PlanetType.GiantGas)
                        {
                            incrementDistance *= GAS_GIANT_DISTANCE_MULTIPLIER;
                        }
                        if (lastCreated != null && lastCreated.Type == (int)PlanetProfile.PlanetType.GiantGas)
                        {
                            incrementDistance *= GAS_GIANT_DISTANCE_MULTIPLIER;
                        }
                        var maxDistanceKm = minDistanceKm + incrementDistance;
                        float distance = Range(minDistanceKm, maxDistanceKm);
                        var position = GenerateCelestialBodyPosition(theta, phi, distance);
                        var size = new Vector2(item.SizeRange.X, item.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS;
                        currentSystemSize = distance + (size / KILOMETERS_TO_METERS);
                        var planet = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(item.Id, size, new Vector2I(1000000, 10000000).GetRandomInt(), position) as MyPlanet;
                        planet.AsteroidName = $"{item.Id} - Planet {i + 1}";                        
                        createdPlanets.Add(item.Id, size / KILOMETERS_TO_METERS);
                        lastCreated = item;
                        if (planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Moon))
                        {
                            var moonsToGenerate = new Vector2I((int)item.MoonCount.X, (int)item.MoonCount.Y).GetRandomInt();
                            if (moonsToGenerate > 0)
                            {
                                var validMoons = planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon).ToList();
                                if (validMoons.Any())
                                {
                                    var generatedMoons = new List<PlanetSetting>();
                                    for (int j = 0; j < moonsToGenerate; j++)
                                    {
                                        if (validMoons.Count == 0)
                                        {
                                            if (allowDuplicated)
                                            {
                                                validMoons.AddRange(generatedMoons);
                                                generatedMoons.Clear();
                                            }
                                            else
                                                break;
                                        }
                                        var moonToCreate = validMoons.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon && x.Parents.Any(c => c.Id.ToUpper() == item.Id.ToUpper())).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                        if (moonToCreate == null)
                                        {
                                            moonToCreate = validMoons.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon && x.Parents.Any(c => c.Id.ToUpper() == item.Id.ToUpper())).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                        }
                                        theta = GetRandomDouble() * TAU;
                                        phi = (GetRandomDouble() * 2 - 1) * SLICE;
                                        var moonPos = position;
                                        var moonDiameter = new Vector2(moonToCreate.SizeRange.X, moonToCreate.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS;
                                        incrementDistance = item.Type == (int)PlanetProfile.PlanetType.GiantGas ? GIANTGAS_MOON_BUFFER.GetRandom() : PLANET_MOON_BUFFER.GetRandom();
                                        minDistanceKm = incrementDistance + (((size * 2) + moonDiameter) / KILOMETERS_TO_METERS);
                                        maxDistanceKm = minDistanceKm + moonDiameter * 5;
                                        distance = Range(minDistanceKm, minDistanceKm);
                                        var moonOffset = GenerateCelestialBodyPosition(theta, phi, distance);
                                        moonPos += moonOffset;
                                        var moon = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(moonToCreate.Id, moonDiameter, new Vector2I(1000000, 10000000).GetRandomInt(), moonPos) as MyPlanet;
                                        moon.AsteroidName = $"{item.Id} - Moon {j + 1} of Planet {i + 1}";
                                        generatedMoons.Add(moonToCreate);
                                        validMoons.Remove(moonToCreate);
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
            }
            return false;
        }

        private static Vector3D GenerateCelestialBodyPosition(double theta, double phi, float distanceKm)
        {
            float distance = distanceKm * KILOMETERS_TO_METERS;
            double xyPlanarDistance = Math.Cos(phi) * distance;
            double x = Math.Cos(theta) * xyPlanarDistance;
            double y = Math.Sin(theta) * xyPlanarDistance;
            double z = Math.Sin(phi) * distance;
            Vector3D result = new Vector3D(x, y, z);
            return result;
        }

        private static float Range(float min, float max)
        {
            return (float)(GetRandomDouble() * (max - min) + min);
        }

        private static double GetRandomDouble()
        {
            return MyUtils.GetRandomDouble(0f, 1f);
        }

    }

}