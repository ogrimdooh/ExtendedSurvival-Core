using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Screens.Helpers;
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

        public static void ClearStarSystem()
        {
            ExtendedSurvivalEntityManager.Instance.ClearAllPlanets();
            foreach (var item in ExtendedSurvivalStorage.Instance.StarSystem.Members)
            {
                if (item.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt)
                {
                    for (int i = 0; i < item.Asteroids.Count; i++)
                    {
                        var asteroid = MyAPIGateway.Entities.GetEntityById(item.Asteroids[i]);
                        if (asteroid != null)
                        {
                            asteroid.Close();
                        }
                    }
                }
                if (ExtendedSurvivalSettings.Instance.AutoGenerateStarSystemGps)
                {
                    MyVisualScriptLogicProvider.RemoveGPSForAll(item.Name);
                }
            }
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Clear();
            ExtendedSurvivalStorage.Instance.StarSystem.Name = "";
            ExtendedSurvivalStorage.Instance.StarSystem.Generated = false;
        }

        private static bool CreatingStarSysten = false;
        public static bool ComputeNewStarSystem(StarSystemSetting profile)
        {
            if (!CreatingStarSysten)
            {
                CreatingStarSysten = true;
                try
                {
                    if (!ExtendedSurvivalEntityManager.Instance.HasPlanets() && !ExtendedSurvivalStorage.Instance.StarSystem.Generated)
                    {
                        var generationType = (StarSystemProfile.ProfileType)profile.Type;
                        var planetProfileType = (StarSystemProfile.ValidPlanetProfile)profile.PlanetProfile;
                        switch (generationType)
                        {
                            case StarSystemProfile.ProfileType.Mapped:
                                var profiles = planetProfileType.GetFlags();
                                if (profiles.Count(x => x != StarSystemProfile.ValidPlanetProfile.None) != 1)
                                    return false;
                                break;
                            case StarSystemProfile.ProfileType.Random:

                                break;
                        }
                        var planets = new List<PlanetSetting>();
                        if (planetProfileType == StarSystemProfile.ValidPlanetProfile.None)
                        {
                            planets = ExtendedSurvivalSettings.Instance.Planets.ToList();
                        }
                        else
                        {
                            foreach (StarSystemProfile.ValidPlanetProfile flag in planetProfileType.GetFlags())
                            {
                                switch (flag)
                                {
                                    case StarSystemProfile.ValidPlanetProfile.Vanilla:
                                        planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                            PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.Vanila
                                        ));
                                        break;
                                    case StarSystemProfile.ValidPlanetProfile.ExtendedSurvival:
                                        planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                            PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.ExtendedSurvival
                                        ));
                                        break;
                                    case StarSystemProfile.ValidPlanetProfile.ATA:
                                        planets.AddRange(ExtendedSurvivalSettings.Instance.Planets.Where(x =>
                                            PlanetMapProfile.Get(x.Id.ToUpper()).Origin == PlanetProfile.PlanetOrigin.OtherMod &&
                                            PlanetMapProfile.Get(x.Id.ToUpper()).OriginId == ATAMapProfile.ATA_MODID
                                        ));
                                        break;
                                }
                            }
                        }
                        if (planets.Any())
                        {
                            if (profile.VanillaAsteroids)
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = 0.35f;
                            else
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = 0;
                            ExtendedSurvivalStorage.Instance.StarSystem.Name = profile.Name;
                            ExtendedSurvivalStorage.Instance.StarSystem.Generated = true;
                            float createdPlanets = 0;
                            if (profile.WithStar)
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
                                    createdPlanets = size / KILOMETERS_TO_METERS;
                                }
                            }
                            float currentSystemSize = createdPlanets > 0 ? createdPlanets + DEFAULT_PLANETARY_DISTANCE.GetRandom() : 0;
                            List<SystemMemberSetting> members = new List<SystemMemberSetting>();
                            switch (generationType)
                            {
                                case StarSystemProfile.ProfileType.Mapped:
                                    members = profile.Members;
                                    break;
                                case StarSystemProfile.ProfileType.Random:
                                    int itensAmmount = new Vector2I((int)profile.TotalMembers.X, (int)profile.TotalMembers.Y).GetRandomInt();
                                    int beltsAmmount = new Vector2I((int)profile.DefaultBeltCount.X, (int)profile.DefaultBeltCount.Y).GetRandomInt();
                                    int ringAmmounts = new Vector2I((int)profile.DefaultRingCount.X, (int)profile.DefaultRingCount.Y).GetRandomInt();
                                    for (int k = 0; k < itensAmmount - beltsAmmount; k++)
                                    {
                                        var memberPlanet = planets.Where(x =>
                                                (x.Type == (int)PlanetProfile.PlanetType.Planet || x.Type == (int)PlanetProfile.PlanetType.GiantGas) &&
                                                (!members.Any(y => y.DefinitionSubtype.ToUpper() == x.Id.ToUpper())) &&
                                                (k > 0 || x.RespawnEnabled)
                                            ).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                        if (memberPlanet == null)
                                        {
                                            if (!profile.AllowDuplicate)
                                                break;
                                            memberPlanet = planets.Where(x =>
                                                    (x.Type == (int)PlanetProfile.PlanetType.Planet || x.Type == (int)PlanetProfile.PlanetType.GiantGas) &&
                                                    (k > 0 || x.RespawnEnabled)
                                                ).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                        }
                                        members.Add(new SystemMemberSetting()
                                        {
                                            Name = memberPlanet.Id,
                                            MemberType = (int)StarSystemProfile.MemberType.Planet,
                                            DefinitionSubtype = memberPlanet.Id,
                                            Order = k,
                                            MoonCount = new DocumentedVector2(profile.DefaultMoonCount.X, profile.DefaultMoonCount.Y, StarSystemSetting.TOTALMEMBERS_INFO)
                                        });
                                    }
                                    for (int k = 0; k < ringAmmounts; k++)
                                    {
                                        var index = new Vector2I(0, members.Count - 1).GetRandomInt();
                                        members[index].HasRing = true;
                                    }
                                    for (int k = 0; k < beltsAmmount; k++)
                                    {
                                        var index = new Vector2I(0, members.Count - 1).GetRandomInt();
                                        members.Insert(index, new SystemMemberSetting()
                                        {
                                            MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                                            Order = index,
                                            Density = profile.DefaultDensity
                                        });
                                    }
                                    break;
                            }
                            int sectors = members.Count;
                            double sectorSize = TAU / sectors;
                            double deviation = 0.25f * sectorSize;
                            double eclipticRotation = GetRandomDouble() * TAU;
                            int p = 0;
                            int b = 0;
                            PlanetSetting lastCreated = null;
                            foreach (var member in members)
                            {
                                var memberType = (StarSystemProfile.MemberType)member.MemberType;
                                List<long> asteroids = null;
                                switch (memberType)
                                {
                                    case StarSystemProfile.MemberType.Planet:
                                        var item = planets.FirstOrDefault(x => x.Id.ToUpper() == member.DefinitionSubtype.ToUpper());
                                        var theta = eclipticRotation + sectorSize * p + (GetRandomDouble() * 2 - 1) * deviation;
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
                                        MyPlanet planet = null;
                                        planet = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(item.Id, size, new Vector2I(1000000, 10000000).GetRandomInt(), position) as MyPlanet;
                                        planet.AsteroidName = $"{member.Name} - Planet {p + 1}";
                                        ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
                                        {
                                            EntityId = planet.EntityId,
                                            Name = planet.AsteroidName,
                                            Position = position,
                                            MemberType = (int)StarSystemProfile.MemberType.Planet,
                                            ItemType = item.Type
                                        });
                                        lastCreated = item;
                                        if (planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Moon))
                                        {
                                            var moonsToGenerate = new Vector2I((int)member.MoonCount.X, (int)member.MoonCount.Y).GetRandomInt();
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
                                                            if (profile.AllowDuplicate)
                                                            {
                                                                validMoons.AddRange(generatedMoons);
                                                                generatedMoons.Clear();
                                                            }
                                                            else
                                                                break;
                                                        }
                                                        var moonToCreate = validMoons.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon && member.ValidMoons.Any(c => c.Id.ToUpper() == x.Id.ToUpper())).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                        if (moonToCreate == null)
                                                        {
                                                            moonToCreate = validMoons.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon).OrderBy(x => GetRandomDouble()).FirstOrDefault();
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
                                                        MyPlanet moon = null;
                                                        moon = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(moonToCreate.Id, moonDiameter, new Vector2I(1000000, 10000000).GetRandomInt(), moonPos) as MyPlanet;
                                                        moon.AsteroidName = $"{moonToCreate.Id} - Moon {j + 1} of Planet {member.Name}";
                                                        ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
                                                        {
                                                            EntityId = moon.EntityId,
                                                            Name = moon.AsteroidName,
                                                            Position = moonPos,
                                                            MemberType = (int)StarSystemProfile.MemberType.Planet,
                                                            ItemType = moonToCreate.Type
                                                        });
                                                        generatedMoons.Add(moonToCreate);
                                                        validMoons.Remove(moonToCreate);
                                                    }
                                                }
                                            }
                                        }
                                        if (member.HasRing)
                                        {
                                            incrementDistance = item.Type == (int)PlanetProfile.PlanetType.GiantGas ? GIANTGAS_MOON_BUFFER.GetRandom() : PLANET_MOON_BUFFER.GetRandom();
                                            var ringDef = new SystemMemberSetting()
                                            {
                                                MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                                                Density = profile.DefaultDensity
                                            };
                                            var ringPosition = CreateAsteroidBelt(ringDef, position, incrementDistance, out asteroids);
                                            ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
                                            {
                                                EntityId = 0,
                                                Name = $"Ring of Planet {member.Name}",
                                                Position = ringPosition,
                                                MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                                                ItemType = 0,
                                                Asteroids = asteroids
                                            });
                                            asteroids = null;
                                        }
                                        p++;
                                        break;
                                    case StarSystemProfile.MemberType.AsteroidBelt:
                                        var minDistKm = currentSystemSize;
                                        var incDistance = DEFAULT_PLANETARY_DISTANCE.GetRandom();
                                        var maxDistKm = minDistKm + incDistance;
                                        float finalDistance = Range(minDistKm, maxDistKm);
                                        currentSystemSize = finalDistance;
                                        var beltPosition = CreateAsteroidBelt(member, Vector3D.Zero, currentSystemSize, out asteroids);
                                        ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
                                        {
                                            EntityId = 0,
                                            Name = (!string.IsNullOrWhiteSpace(member.Name) ? $"{member.Name} - " : "") + $"Asteroid Belt {p + 1}",
                                            Position = beltPosition,
                                            MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                                            ItemType = 0,
                                            Asteroids = asteroids
                                        });
                                        asteroids = null;
                                        b++;
                                        break;
                                }
                            }
                            if (ExtendedSurvivalSettings.Instance.AutoGenerateStarSystemGps)
                            {
                                foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                                {
                                    var posGps = member.Position;
                                    if (member.EntityId != 0)
                                    {
                                        var Entity = MyAPIGateway.Entities.GetEntityById(member.EntityId);
                                        posGps = Entity?.PositionComp?.WorldAABB.Center ?? member.Position;
                                    }
                                    MyVisualScriptLogicProvider.AddGPSForAll(member.Name, "", posGps, Color.White);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                }
                finally
                {
                    CreatingStarSysten = false;
                }
            }
            return false;
        }

        private static Vector3D CreateAsteroidBelt(SystemMemberSetting asteroidSystem, Vector3D centerPosition, float orbitDistance, out List<long> asteroids)
        {
            asteroids = new List<long>();

            float density = Math.Min(Math.Max(0, asteroidSystem.Density), 1);

            float mappedSkip = GetMappedValue(1 - density, 0, 1, 0.45f, 0.7f);
            float mappedDensity = GetMappedValue(density, 0, 1, 0.3f, 0.85f);

            float asteroidAdjacencyDistance = (1 / mappedDensity) * KILOMETERS_TO_METERS;

            orbitDistance *= KILOMETERS_TO_METERS;
            float orbitCircumference = GetCircumference(orbitDistance);
            int asteroidQuantity = (int)Math.Floor(orbitCircumference / asteroidAdjacencyDistance);
            float angleIncrement = (float)Math.PI * 2 / asteroidQuantity;
            float rotationOffset = Range(0, (float)Math.PI * 2);
            float positionVariation = 1.5f * asteroidAdjacencyDistance;
            Vector3D beltPositionCaptured = Vector3D.Zero;

            for (int i = 0, end = asteroidQuantity; i < end; i++)
            {
                if (GetRandomDouble() < mappedSkip) { continue; }

                float angle = angleIncrement * i * rotationOffset;
                float x = (float)Math.Cos(angle) * orbitDistance;
                float y = (float)Math.Sin(angle) * orbitDistance;
                float z = 0;

                x += Range(-1, 1) * positionVariation;
                y += Range(-1, 1) * positionVariation;
                z += Range(-1, 1) * positionVariation * 0.1f;

                Vector3 asteroidOffset = new Vector3(x, y, z);

                float asteroidRadius = Range(500, 1500);
                Vector3D asteroidPosition = centerPosition + asteroidOffset;

                var asteroid = CreateAsteroid(asteroidPosition, asteroidRadius);
                asteroids.Add(asteroid);

                if (beltPositionCaptured != Vector3D.Zero) { continue; }

                beltPositionCaptured = asteroidPosition;
            }

            return beltPositionCaptured;
        }

        private static float GetCircumference(float radius)
        {
            return (float)Math.PI * 2 * radius;
        }

        public static float GetMappedValue(float value, float inMin, float inMax, float outMin, float outMax)
        {
            float inRange = inMax - inMin;
            float outRange = outMax - outMin;

            float inPosition = value - inMin;
            float percent = inPosition / inRange;

            return outRange * percent + outMin;
        }

        private static int AsteroidSeed = new Vector2I(1000000, 10000000).GetRandomInt();
        private static long CreateAsteroid(Vector3D position, float radius)
        {
            var voxelMaps = MyAPIGateway.Session.VoxelMaps;
            Vector3 forward = GetRandomVector(GetRandomDouble(1000) + 1);
            Vector3 up = GetRandomVector(GetRandomDouble(1000) + 1);
            MatrixD matrix = MatrixD.CreateWorld(position, forward, up);
            return voxelMaps.CreateProceduralVoxelMap(++AsteroidSeed, radius, matrix).EntityId;
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

        public static Vector3D GetRandomVector(double length = 1)
        {
            double x = GetRandomDouble();
            double y = GetRandomDouble();
            double z = GetRandomDouble();
            Vector3D unitDirection = new Vector3D(x, y, z);
            unitDirection.Normalize();
            unitDirection *= length;
            return unitDirection;
        }

        private static double GetRandomDouble(double max = 1f)
        {
            return MyUtils.GetRandomDouble(0f, max);
        }

    }

}