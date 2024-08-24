using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class StarSystemController
    {

        public static int SPAWN_DISTANCE = 30000;
        public static float SAFE_DISTANCE = 150;

        public enum GenerationType
        {

            MappedProfile = 0,
            Random = 1

        }

        [Flags]
        public enum GenerationFlags
        {

            None = 0,
            NoStar = 1,
            WithStar = 2,
            NoBelt = 4,
            NoRing = 8,
            NoAsteroids = 16,
            WithAsteroids = 32

        }

        public static readonly Vector2 PLANET_MOON_BUFFER = new Vector2(150f, 300f);
        public static readonly Vector2 GIANTGAS_MOON_BUFFER = new Vector2(450f, 900f);
        public const float KILOMETERS_TO_METERS = 1000f;
        public const float TAU = (float)(Math.PI * 2f);
        public const float SLICE = (float)(Math.PI * 0.5f);
        public const float DEFAULT_INCLINATION = 45f;
        public static readonly Vector2 DEFAULT_PLANETARY_DISTANCE = new Vector2(2500f, 7500f);
        public const float GAS_GIANT_DISTANCE_MULTIPLIER = 2f;

        public static void RecreateStations()
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                CreateStationsToAllPlanets();
                ClearSafeZones();
            }
        }

        public static void CompleteStarSystem(string profile)
        {
            var profileInfo = ExtendedSurvivalSettings.Instance.GetStarSystemInfo(profile, false);
            if (!ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                ExtendedSurvivalStorage.Instance.StarSystem.Name = "Existing System";
                ExtendedSurvivalStorage.Instance.StarSystem.Generated = true;
            }
            var listaToCreateGps = new List<StarSystemMemberStorage>();
            foreach (var planet in ExtendedSurvivalEntityManager.Instance.Planets)
            {
                if (!ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.EntityId == planet.Key))
                {
                    var settings = planet.Value.Setting;
                    if (settings != null)
                    {
                        long ownerId = 0;
                        var order = 0;
                        if (profileInfo != null && profileInfo.Type == (int)StarSystemProfile.ProfileType.Mapped)
                        {
                            if (profileInfo.Members.Any(x => x.Name.ToUpper() == settings.Id.ToUpper()))
                            {
                                order = profileInfo.Members.FirstOrDefault(x => x.Name.ToUpper() == settings.Id.ToUpper()).Order;
                            }
                            else if (profileInfo.Members.Any(x => x.ValidMoons.Any(y => y.Id.ToUpper() == settings.Id.ToUpper())))
                            {
                                var owner = profileInfo.Members.FirstOrDefault(x => x.ValidMoons.Any(y => y.Id.ToUpper() == settings.Id.ToUpper()));
                                var ownerPlanet = ExtendedSurvivalEntityManager.Instance.Planets.Values.FirstOrDefault(x => x.Setting.Id.ToUpper() == owner.Name.ToUpper());
                                if (ownerPlanet != null)
                                {
                                    ownerId = ownerPlanet.Entity.EntityId;
                                }
                            }
                        }
                        var member = new StarSystemMemberStorage()
                        {
                            OwnerId = ownerId,
                            Order = order,
                            EntityId = planet.Key,
                            Name = settings.Id,
                            Position = planet.Value.Entity.PositionComp.GetPosition(),
                            MemberType = (int)StarSystemProfile.MemberType.Planet,
                            ItemType = settings.Type
                        };
                        ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(member);
                        listaToCreateGps.Add(member);
                        try
                        {
                            ExtendedSurvivalEntityManager.Instance.FactionsLocked = true;
                            CreateStationToPlanet(member);
                        }
                        finally
                        {
                            ExtendedSurvivalEntityManager.Instance.FactionsLocked = false;
                        }
                    }
                }
            }
            // Reorder
            int i = 0;
            int p = 0;
            int b = 0;
            foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.OwnerId == 0).OrderBy(x => Vector3D.Distance(Vector3D.Zero, x.Position)))
            {
                member.Order = i;
                int c = 0;
                foreach (var moon in ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.OwnerId == member.EntityId).OrderBy(x => Vector3D.Distance(member.Position, x.Position)))
                {
                    moon.Order = c;
                    if (moon.IsPlanet)
                    {
                        moon.Name = $"{member.Order + 1:00} - Planet {p + 1:00} - Moon {c + 1:00} - {moon.Planet.Setting.Id}";
                        moon.Planet.Entity.AsteroidName = member.Name;
                        c++;
                    }
                    else
                    {
                        moon.Name = $"{member.Order + 1:00} - Planet {p + 1:00} - Ring";
                    }
                }
                if (member.IsPlanet)
                {
                    member.Name = $"{member.Order + 1:00} - Planet {p + 1:00} - {member.Planet.Setting.Id}";
                    member.Planet.Entity.AsteroidName = member.Name;
                    p++;
                }
                else
                {
                    member.Name = $"{member.Order + 1:00} - Asteroid Belt {b + 1:00}";
                    b++;
                }
                i++;
            }
            // Create GPSs
            foreach (var member in listaToCreateGps)
            {
                if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateStarSystemGps)
                {
                    StringBuilder sb = new StringBuilder();
                    DoCompleteInfo(sb, member);
                    MyVisualScriptLogicProvider.AddGPSForAll(member.Name, sb.ToString(), member.Position, Color.MediumPurple);
                }
            }
        }

        public static bool CheckGpsToAllPlayers(bool force = false)
        {
            try
            {
                if (ExtendedSurvivalStorage.Instance.StarSystem.Generated && ExtendedSurvivalEntityManager.Instance != null)
                {
                    if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateStarSystemGps)
                    {
                        ExtendedSurvivalEntityManager.Instance.UpdatePlayerList();
                        long[] activePlayers;
                        lock (ExtendedSurvivalEntityManager.Instance.Players)
                        {
                            activePlayers = ExtendedSurvivalEntityManager.Instance.Players.Keys.ToArray();
                        }
                        foreach (var playerId in activePlayers)
                        {
                            CreateGpsToPlayer(playerId, force);
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
            return false;
        }

        public static bool CreateGpsToPlayer(long playerId, bool force = false)
        {
            try
            {
                if (ExtendedSurvivalStorage.Instance != null && ExtendedSurvivalStorage.Instance.StarSystem.Generated)
                {
                    if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateStarSystemGps)
                    {
                        var playerInteration = ExtendedSurvivalStorage.Instance.StarSystem.GetPlayerInterationStorage(playerId);
                        if (playerInteration != null && (!playerInteration.StartGpsGenerated || force))
                        {
                            foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                            {
                                var posGps = member.Position;
                                if (member.EntityId != 0)
                                {
                                    var Entity = MyAPIGateway.Entities.GetEntityById(member.EntityId);
                                    posGps = Entity?.PositionComp?.WorldAABB.Center ?? member.Position;
                                }
                                StringBuilder sb = new StringBuilder();
                                DoCompleteInfo(sb, member);
                                if (force)
                                    MyVisualScriptLogicProvider.RemoveGPS(member.Name, playerId);
                                MyVisualScriptLogicProvider.AddGPS(member.Name, sb.ToString(), posGps, Color.MediumPurple, playerId: playerId);
                            }
                            playerInteration.StartGpsGenerated = true;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
            return false;
        }

        public static void DeleteNpcFactions()
        {
            try
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = true;
                IEnumerable<string> defFacs = MyDefinitionManager.Static.GetFactionsFromDefinition().Select(x => x.Tag).ToArray();
                if (ExtendedSurvivalStorage.Instance.Factions.Any())
                {
                    defFacs = defFacs.Concat(ExtendedSurvivalStorage.Instance.Factions.Select(x => x.Tag).ToArray());
                }
                var idsToRemove = MyAPIGateway.Session.Factions.Factions.Values.Where(x => x.IsEveryoneNpc() && !defFacs.Contains(x.Tag)).Select(x => x.FactionId).ToArray();
                foreach (var factionId in idsToRemove)
                {
                    MyAPIGateway.Session.Factions.RemoveFaction(factionId);
                }
            }
            finally
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = false;
            }
        }

        public static void ClearSafeZones()
        {
            var idsToStay = ExtendedSurvivalStorage.Instance.StarSystem.GetStations().Select(x => x.SafeZoneEntityId).ToArray();
            var safeZoneToRemove = ExtendedSurvivalEntityManager.Instance.SafeZones.Where(x => !idsToStay.Contains(x.EntityId)).ToArray();
            foreach (var safeZone in safeZoneToRemove)
            {
                if (safeZone != null)
                    safeZone.Close();
            }
        }

        public static void ClearStarSystemMetaData()
        {
            ExtendedSurvivalStorage.Instance.StarSystem.PlayerInterations.Clear();
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Clear();
            ExtendedSurvivalStorage.Instance.StarSystem.Name = "";
            ExtendedSurvivalStorage.Instance.StarSystem.Generated = false;
            ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick = 0;
            ExtendedSurvivalStorage.Instance.StarSystem.ComercialCountdown = 0;
            RemoveAllFactions();
        }

        public static void ClearStarSystem()
        {
            ExtendedSurvivalEntityManager.Instance.ClearAllPlanets();
            foreach (var item in ExtendedSurvivalStorage.Instance.StarSystem.Members)
            {
                if (item.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt)
                {
                    var storage = item.GetAsteroidStorage();
                    for (int i = 0; i < storage.Asteroids.Count; i++)
                    {
                        var asteroid = MyAPIGateway.Entities.GetEntityById(storage.Asteroids[i]);
                        if (asteroid != null)
                        {
                            asteroid.Close();
                        }
                    }
                    storage.Asteroids.Clear();
                    storage.NotSpawnAsteroids.Clear();
                    storage.AsteroidsData.Clear();
                    storage.Modified = true;
                }
                foreach (var station in item.Stations)
                {
                    if (station.StationEntityId != 0)
                    {
                        var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
                        if (entity != null)
                        {
                            entity.Entity.Close();
                            var safeZone = ExtendedSurvivalEntityManager.GetSafeZoneById(station.SafeZoneEntityId);
                            if (safeZone != null)
                                safeZone.Close();
                            station.StationEntityId = 0;
                            station.SafeZoneEntityId = 0;
                        }
                    }
                    if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateTradeStationsGps)
                    {
                        MyVisualScriptLogicProvider.RemoveGPSForAll(station.Name);
                    }
                }
                if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateStarSystemGps)
                {
                    MyVisualScriptLogicProvider.RemoveGPSForAll(item.Name);
                }
            }
            ClearStarSystemMetaData();            
        }

        private static void RemoveAllFactions()
        {
            if (ExtendedSurvivalStorage.Instance.Factions.Any())
            {
                foreach (var faction in ExtendedSurvivalStorage.Instance.Factions)
                {
                    MyAPIGateway.Session.Factions.RemoveFaction(faction.FactionId);
                }
                ExtendedSurvivalStorage.Instance.Factions.Clear();
            }
            var defFacs = MyDefinitionManager.Static.GetFactionsFromDefinition().Select(x => x.Tag).ToArray();
            var idsToRemove = MyAPIGateway.Session.Factions.Factions.Values.Where(x => x.IsEveryoneNpc() && !defFacs.Contains(x.Tag)).Select(x => x.FactionId).ToArray();
            foreach (var factionId in idsToRemove)
            {
                MyAPIGateway.Session.Factions.RemoveFaction(factionId);
            }
        }

        private static MyPlanet AddStarSystemPlanet(
            ref float currentSystemSize, 
            StarSystemSetting profile, 
            PlanetSetting item, 
            SystemMemberSetting member, 
            PlanetSetting lastCreated, 
            double sectorSize, 
            double deviation, 
            double eclipticRotation, 
            int p,
            out double theta,
            out double phi,
            out Vector3D position,
            out float incrementDistance,
            out float maxDistanceKm,
            out float minDistanceKm,
            out float distance,
            out float size
        )
        {
            theta = eclipticRotation + sectorSize * p + (GetRandomDouble() * 2 - 1) * deviation;
            phi = (GetRandomDouble() * 2 - 1) * DEFAULT_INCLINATION;
            minDistanceKm = currentSystemSize;
            incrementDistance = DEFAULT_PLANETARY_DISTANCE.GetRandom() * profile.DistanceMultiplier;
            if (item.Type == (int)PlanetProfile.PlanetType.GiantGas)
            {
                incrementDistance *= GAS_GIANT_DISTANCE_MULTIPLIER;
            }
            if (lastCreated != null && lastCreated.Type == (int)PlanetProfile.PlanetType.GiantGas)
            {
                incrementDistance *= GAS_GIANT_DISTANCE_MULTIPLIER;
            }
            maxDistanceKm = minDistanceKm + incrementDistance;
            distance = Range(minDistanceKm, maxDistanceKm);
            position = GenerateCelestialBodyPosition(theta, phi, distance);
            size = new Vector2(item.SizeRange.X, item.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS * member.SizeMultiplier;
            currentSystemSize = distance + (size / KILOMETERS_TO_METERS);
            MyPlanet planet = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(item.Id, size, new Vector2I(1000000, 10000000).GetRandomInt(), position) as MyPlanet;
            planet.AsteroidName = $"{member.Order + 1:00} - Planet {p + 1:00} - {member.Name}";
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
            {
                Order = member.Order,
                EntityId = planet.EntityId,
                Name = planet.AsteroidName,
                Position = planet.PositionComp.GetPosition(),
                MemberType = (int)StarSystemProfile.MemberType.Planet,
                ItemType = item.Type
            });
            return planet;
        }

        private static MyPlanet AddStarSystemMoon(
            ref double theta,
            ref double phi,
            SystemMemberSetting member,
            PlanetSetting item,
            PlanetSetting moonToCreate,
            Vector3D position,
            float size,
            long ownerId,
            int p,
            int j,
            ref float incrementDistance,
            ref float maxDistanceKm,
            ref float minDistanceKm,
            ref float distance,
            out Vector3D moonPos
        )
        {
            theta = GetRandomDouble() * TAU;
            phi = (GetRandomDouble() * 2 - 1) * SLICE;
            moonPos = position;
            var sizeMultiplier = member.MoonSizeMultiplier.ToVector2().GetRandom();
            var moonDiameter = new Vector2(moonToCreate.SizeRange.X, moonToCreate.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS * sizeMultiplier;
            incrementDistance = item.Type == (int)PlanetProfile.PlanetType.GiantGas ? GIANTGAS_MOON_BUFFER.GetRandom() : PLANET_MOON_BUFFER.GetRandom();
            minDistanceKm = incrementDistance + (((size * 2) + moonDiameter) / KILOMETERS_TO_METERS);
            maxDistanceKm = minDistanceKm + moonDiameter * 5;
            distance = Range(minDistanceKm, minDistanceKm);
            var moonOffset = GenerateCelestialBodyPosition(theta, phi, distance);
            moonPos += moonOffset;
            MyPlanet moon = MyAPIGateway.Session.VoxelMaps.SpawnPlanet(moonToCreate.Id, moonDiameter, new Vector2I(1000000, 10000000).GetRandomInt(), moonPos) as MyPlanet;
            moon.AsteroidName = $"{member.Order + 1:00} - Planet {p + 1:00} - Moon {j + 1:00} - {moonToCreate.Id}";
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(new StarSystemMemberStorage()
            {
                Order = j,
                OwnerId = ownerId,
                EntityId = moon.EntityId,
                Name = moon.AsteroidName,
                Position = moonPos,
                MemberType = (int)StarSystemProfile.MemberType.Planet,
                ItemType = moonToCreate.Type
            });
            return moon;
        }

        private static StarSystemMemberStorage AddRingToPlanet(
            SystemMemberSetting member,
            StarSystemSetting profile,
            PlanetSetting item,
            int order,
            long ownerId,
            int p,
            Vector3D position,
            ref float incrementDistance
        )
        {
            incrementDistance = item.Type == (int)PlanetProfile.PlanetType.GiantGas ? GIANTGAS_MOON_BUFFER.GetRandom() : PLANET_MOON_BUFFER.GetRandom();
            var ringDef = new SystemMemberSetting()
            {
                MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                Density = member.Density > 0 ? member.Density : profile.DefaultDensity,
            };
            Dictionary<int, Vector3D> asteroids = new Dictionary<int, Vector3D>();
            var ringPosition = CreateAsteroidBelt(ringDef, position, incrementDistance, out asteroids);
            var storage = new StarSystemMemberStorage()
            {
                Order = order,
                OwnerId = ownerId,
                EntityId = 0,
                Name = $"{member.Order + 1:00} - Planet {p + 1:00} - Ring",
                Position = ringPosition,
                MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                ItemType = 0
            };
            var asteroidStorage = storage.GetAsteroidStorage();
            asteroidStorage.NotSpawnAsteroids = asteroids.Values.ToList();
            asteroidStorage.AsteroidsData = asteroids.Select(x => new AsteroidStorage()
            {
                Position = x.Value,
                Radius = GetRandomAsteroidRadius(),
                Seed = GetRandomAsteroidSeed(),
                Forward = GetRandomVector(GetRandomDouble(1000) + 1),
                Up = GetRandomVector(GetRandomDouble(1000) + 1)
            }).ToList();
            asteroidStorage.Modified = true;
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(storage);
            return storage;
        }

        private static StarSystemMemberStorage AddBeltToSystem(
            ref float currentSystemSize,
            SystemMemberSetting member,
            StarSystemSetting profile,
            int b
        )
        {
            var minDistKm = currentSystemSize;
            var incDistance = DEFAULT_PLANETARY_DISTANCE.GetRandom();
            var maxDistKm = minDistKm + incDistance;
            float finalDistance = Range(minDistKm, maxDistKm) * profile.DistanceMultiplier;
            currentSystemSize = finalDistance;
            Dictionary<int, Vector3D> asteroids = new Dictionary<int, Vector3D>();
            var beltPosition = CreateAsteroidBelt(member, Vector3D.Zero, currentSystemSize, out asteroids);
            var storage = new StarSystemMemberStorage()
            {
                Order = member.Order,
                EntityId = 0,
                Name = $"{member.Order + 1:00} - " + (!string.IsNullOrWhiteSpace(member.Name) ? $"{member.Name} - " : "") + $"Asteroid Belt {b + 1:00}",
                Position = beltPosition,
                MemberType = (int)StarSystemProfile.MemberType.AsteroidBelt,
                ItemType = 0
            };
            var asteroidStorage = storage.GetAsteroidStorage();
            asteroidStorage.NotSpawnAsteroids = asteroids.Values.ToList();
            asteroidStorage.AsteroidsData = asteroids.Select(x => new AsteroidStorage()
            {
                Position = x.Value,
                Radius = GetRandomAsteroidRadius(),
                Seed = GetRandomAsteroidSeed(),
                Forward = GetRandomVector(GetRandomDouble(1000) + 1),
                Up = GetRandomVector(GetRandomDouble(1000) + 1)
            }).ToList();
            asteroidStorage.Modified = true;
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Add(storage);
            asteroids = null;
            return storage;
        }

        private static bool CreatingStarSysten = false;
        public static bool ComputeNewStarSystem(StarSystemSetting profile, GenerationFlags flags = GenerationFlags.None)
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
                            if (!flags.IsFlagSet(GenerationFlags.NoAsteroids) && (profile.VanillaAsteroids || flags.IsFlagSet(GenerationFlags.WithAsteroids)))
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = profile.DefaultDensity;
                            else
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = 0;
                            MyAPIGateway.Session.SessionSettings.EnableEconomy = profile.VanillaEconomyEnabled;
                            ExtendedSurvivalStorage.Instance.StarSystem.Name = profile.Name;
                            ExtendedSurvivalStorage.Instance.StarSystem.Generated = true;
                            float createdPlanets = 0;
                            bool sunCreated = false;
                            if (!flags.IsFlagSet(GenerationFlags.NoStar) && (profile.WithStar || flags.IsFlagSet(GenerationFlags.WithStar)))
                            {
                                IEnumerable<PlanetSetting> suns = Enumerable.Empty<PlanetSetting>();
                                PlanetSetting sunProfile = null;
                                if (planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Star))
                                {
                                    suns = planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Star);

                                }
                                else if (ExtendedSurvivalSettings.Instance.Planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Star))
                                {
                                    suns = ExtendedSurvivalSettings.Instance.Planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Star);
                                }
                                sunProfile = suns.Any(x => x.Id == profile.StarName) ?
                                    suns.FirstOrDefault(x => x.Id == profile.StarName) :
                                    suns.FirstOrDefault();
                                if (sunProfile != null)
                                {
                                    var pos = Vector3D.Zero;
                                    var size = new Vector2(sunProfile.SizeRange.X, sunProfile.SizeRange.Y).GetRandom() * KILOMETERS_TO_METERS;
                                    MyAPIGateway.Session.VoxelMaps.SpawnPlanet(sunProfile.Id, size, new Vector2I(1000000, 10000000).GetRandomInt(), pos);
                                    createdPlanets = size / KILOMETERS_TO_METERS;
                                    sunCreated = true;
                                }
                            }
                            float currentSystemSize = (createdPlanets + DEFAULT_PLANETARY_DISTANCE.GetRandom()) * profile.DistanceMultiplier;
                            if (!sunCreated && profile.FirstMemberAtCenter)
                            {
                                currentSystemSize = 0;
                            }
                            List<SystemMemberSetting> members = new List<SystemMemberSetting>();
                            switch (generationType)
                            {
                                case StarSystemProfile.ProfileType.Mapped:
                                    members = profile.Members;
                                    if (flags.IsFlagSet(GenerationFlags.NoRing) && members.Any(x => x.HasRing))
                                        foreach (var item in members.Where(x => x.HasRing))
                                        {
                                            item.HasRing = false;
                                        }
                                    if (flags.IsFlagSet(GenerationFlags.NoBelt) && members.Any(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt))
                                    {
                                        members.RemoveAll(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt);
                                    }
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
                                    if (!flags.IsFlagSet(GenerationFlags.NoRing))
                                    {
                                        for (int k = 0; k < ringAmmounts; k++)
                                        {
                                            var index = new Vector2I(0, members.Count - 1).GetRandomInt();
                                            members[index].HasRing = true;
                                        }
                                    }
                                    if (!flags.IsFlagSet(GenerationFlags.NoBelt))
                                    {
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
                            members.Sort((x, y) => { return x.Order.CompareTo(y.Order); });
                            for (int i = 0; i < members.Count; i++)
                            {
                                members[i].Order = i;
                            }
                            foreach (var member in members)
                            {
                                var memberType = (StarSystemProfile.MemberType)member.MemberType;
                                Dictionary<int, Vector3D> asteroids = null;
                                switch (memberType)
                                {
                                    case StarSystemProfile.MemberType.Planet:
                                        var item = planets.FirstOrDefault(x => x.Id.ToUpper() == member.DefinitionSubtype.ToUpper());
                                        if (item == null)
                                        {
                                            item = planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Planet).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                        }
                                        if (item != null)
                                        {
                                            double theta;
                                            double phi;
                                            Vector3D position;
                                            float incrementDistance;
                                            float maxDistanceKm;
                                            float minDistanceKm;
                                            float distance;
                                            float size;
                                            MyPlanet planet = AddStarSystemPlanet(
                                                ref currentSystemSize, 
                                                profile, 
                                                item, 
                                                member, 
                                                lastCreated, 
                                                sectorSize, 
                                                deviation, 
                                                eclipticRotation, 
                                                p,
                                                out theta,
                                                out phi,
                                                out position,
                                                out incrementDistance,
                                                out maxDistanceKm,
                                                out minDistanceKm,
                                                out distance,
                                                out size
                                            );
                                            lastCreated = item;
                                            var generatedMoons = new List<PlanetSetting>();
                                            if (planets.Any(x => x.Type == (int)PlanetProfile.PlanetType.Moon))
                                            {
                                                var moonsToGenerate = new Vector2I((int)member.MoonCount.X, (int)member.MoonCount.Y).GetRandomInt();
                                                if (moonsToGenerate > 0)
                                                {
                                                    var validMoons = generationType == StarSystemProfile.ProfileType.Random ? planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon).ToList() : planets.ToList();
                                                    if (validMoons.Any())
                                                    {
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
                                                            var moonToCreate = validMoons.Where(x => member.ValidMoons.Any(c => c.Id.ToUpper() == x.Id.ToUpper())).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                            if (moonToCreate == null)
                                                            {
                                                                moonToCreate = validMoons.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                            }
                                                            Vector3D moonPos;
                                                            MyPlanet moon = AddStarSystemMoon(
                                                                ref theta,
                                                                ref phi,
                                                                member,
                                                                item,
                                                                moonToCreate,
                                                                position,
                                                                size,
                                                                planet.EntityId,
                                                                p,
                                                                j,
                                                                ref incrementDistance,
                                                                ref maxDistanceKm,
                                                                ref minDistanceKm,
                                                                ref distance,
                                                                out moonPos
                                                            );
                                                            generatedMoons.Add(moonToCreate);
                                                            validMoons.Remove(moonToCreate);
                                                        }
                                                    }
                                                }
                                            }
                                            if (member.HasRing)
                                            {
                                                AddRingToPlanet(
                                                    member, 
                                                    profile, 
                                                    item, 
                                                    generatedMoons.Count, 
                                                    planet.EntityId, 
                                                    p, 
                                                    position, 
                                                    ref incrementDistance
                                                );
                                            }
                                        }
                                        p++;
                                        break;
                                    case StarSystemProfile.MemberType.AsteroidBelt:
                                        AddBeltToSystem(
                                            ref currentSystemSize,
                                            member,
                                            profile,
                                            b
                                        );
                                        b++;
                                        break;
                                }
                            }

                            // Try to move stations to generated planets
                            CreateStationsToAllPlanets();

                            if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateStarSystemGps)
                            {
                                foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                                {
                                    var posGps = member.Position;
                                    if (member.EntityId != 0)
                                    {
                                        var Entity = MyAPIGateway.Entities.GetEntityById(member.EntityId);
                                        posGps = Entity?.PositionComp?.WorldAABB.Center ?? member.Position;
                                    }
                                    StringBuilder sb = new StringBuilder();
                                    DoCompleteInfo(sb, member);
                                    MyVisualScriptLogicProvider.AddGPSForAll(member.Name, sb.ToString(), posGps, Color.MediumPurple);
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

        private static int GetRandomAsteroidSeed()
        {
            return AsteroidSeed.GetRandomInt();
        }

        private static float GetRandomAsteroidRadius()
        {
            return Range(600, 1800);
        }

        public static bool DoChangePveZone(long planetId, List<string> optionsPve)
        {
            if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
            {
                if (ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.EntityId == planetId))
                {
                    var member = ExtendedSurvivalStorage.Instance.StarSystem.Members.FirstOrDefault(x => x.EntityId == planetId);
                    foreach (var option in optionsPve)
                    {
                        if (option == "remove" && member.HasPveArea)
                        {
                            member.HasPveArea = false;
                        }
                        else if (option == "create" && !member.HasPveArea)
                        {
                            member.HasPveArea = true;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        private static void DoCompleteInfo(StringBuilder sb, StarSystemMemberStorage member)
        {
            if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AddAllInfoToStarSystemGps)
            {
                switch ((StarSystemProfile.MemberType)member.MemberType)
                {
                    case StarSystemProfile.MemberType.Planet:
                        var planet = ExtendedSurvivalEntityManager.GetPlanetById(member.EntityId);
                        if (planet != null && planet.Setting != null)
                        {
                            sb.AppendLine("Basic Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Respawn Enabled: {0}", planet.Setting.RespawnEnabled ? "Yes" : "No"));
                            sb.AppendLine(string.Format("Type: {0}", ((PlanetProfile.PlanetType)planet.Setting.Type).ToString()));
                            sb.AppendLine(string.Format("Size: {0}", (planet.Entity.AverageRadius * 2).ToString("#0.00")));
                            sb.AppendLine(string.Format("Gravity Force: {0}g", planet.Setting.Gravity.SurfaceGravity.ToString("#0.00")));
                            sb.AppendLine(string.Format("Gravity Power: {0}x", planet.Setting.Gravity.GravityFalloffPower));
                            sb.AppendLine(string.Format("Ores: {0}", string.Join(",", planet.Setting.OreMap.Select(x => x.Type.Split('_')[0]).Distinct())));
                            if (member.StationsGenerated)
                            {
                                sb.AppendLine(string.Format("Total Stations: {0}", member.Stations.Count));
                            }
                            sb.AppendLine("");
                            sb.AppendLine("Atmosphere Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Enabled: {0}", planet.Entity.HasAtmosphere ? "Yes" : "No"));
                            if (planet.Entity.HasAtmosphere)
                            {
                                sb.AppendLine(string.Format("Altitude: {0}", planet.Entity.AtmosphereAltitude.ToString("#0.00")));
                                sb.AppendLine(string.Format("Max Wind Speed: {0}", planet.Setting.Atmosphere.MaxWindSpeed.ToString("#0.00")));
                                sb.AppendLine(string.Format("Density: {0}", planet.Setting.Atmosphere.Density.ToString("P2")));
                                sb.AppendLine(string.Format("Oxygen Density: {0}", planet.Setting.Atmosphere.OxygenDensity.ToString("P2")));
                                sb.AppendLine(string.Format("Toxicity: {0}", planet.Setting.Atmosphere.ToxicLevel.ToString("P2")));
                                sb.AppendLine(string.Format("Radiation: {0}", planet.Setting.Atmosphere.RadiationLevel.ToString("P2")));
                                sb.AppendLine(string.Format("Temperature Range: {0}ºC - {1}ºC", planet.Setting.Atmosphere.TemperatureRange.X, planet.Setting.Atmosphere.TemperatureRange.Y));
                            }
                            sb.AppendLine("");
                            sb.AppendLine("Geothermal Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Enabled: {0}", planet.Setting.Geothermal.Enabled ? "Yes" : "No"));
                            if (planet.Setting.Geothermal.Enabled)
                            {
                                sb.AppendLine(string.Format("Start Depth: {0}", planet.Setting.Geothermal.Start.ToString("#0.00")));
                                sb.AppendLine(string.Format("Increment Depth Size: {0}", planet.Setting.Geothermal.RowSize.ToString("#0.00")));
                                sb.AppendLine(string.Format("Base Power: {0}", planet.Setting.Geothermal.Power.ToString("#0.00")));
                                sb.AppendLine(string.Format("Increment Power: {0}", planet.Setting.Geothermal.Increment.ToString("#0.00")));
                                sb.AppendLine(string.Format("Max Power: {0}", planet.Setting.Geothermal.MaxPower.ToString("#0.00")));
                            }
                            sb.AppendLine("");
                            sb.AppendLine("Water Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Enabled: {0}", planet.Setting.Water.Enabled ? "Yes" : "No"));
                            if (planet.Setting.Water.Enabled)
                            {
                                sb.AppendLine(string.Format("Default Size: {0}", planet.Setting.Water.Size));
                                sb.AppendLine(string.Format("Temperature Factor: {0}", planet.Setting.Water.TemperatureFactor));
                                sb.AppendLine(string.Format("Toxicity: {0}", planet.Setting.Water.ToxicLevel.ToString("P2")));
                                sb.AppendLine(string.Format("Radiation: {0}", planet.Setting.Water.RadiationLevel.ToString("P2")));
                            }
                            sb.AppendLine("");
                            sb.AppendLine("Superficial Mining Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Enabled: {0}", planet.Setting.SuperficialMining.Enabled ? "Yes" : "No"));
                            if (planet.Setting.SuperficialMining.Enabled)
                            {
                                foreach (var item in planet.Setting.SuperficialMining.Drops)
                                {
                                    var defId = item.ItemId.GetId();
                                    if (defId.HasValue)
                                    {
                                        var id = new UniqueEntityId(defId.Value);
                                        try
                                        {
                                            var def = MyDefinitionManager.Static.GetPhysicalItemDefinition(id.DefinitionId);
                                            if (def != null)
                                            {
                                                sb.AppendLine(string.Format(
                                                    "{0} chance to get {1}-{2} of {3}",
                                                    (item.Chance / 100).ToString("P2"),
                                                    item.Ammount.X,
                                                    item.Ammount.Y,
                                                    def.DisplayNameText
                                                ));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                                        }
                                    }
                                }
                            }
                            sb.AppendLine("");
                            sb.AppendLine("Animal Data:");
                            sb.AppendLine("");
                            sb.AppendLine(string.Format("Day Spawn Enabled: {0}", planet.Setting.Animal.DaySpawn.Enabled ? "Yes" : "No"));
                            sb.AppendLine(string.Format("Night Spawn Enabled: {0}", planet.Setting.Animal.NightSpawn.Enabled ? "Yes" : "No"));
                            if (planet.Setting.Animal.DaySpawn.Enabled || planet.Setting.Animal.NightSpawn.Enabled)
                            {
                                sb.AppendLine(string.Format("Animals: {0}", string.Join(",", planet.Setting.Animal.Animals.Select(x => x.Id.Split('_')[0]))));
                            }
                        }
                        break;
                    case StarSystemProfile.MemberType.AsteroidBelt:
                        sb.AppendLine("Basic Data:");
                        sb.AppendLine(string.Format("Total Asteroids: {0}", member.GetAsteroidStorage().AsteroidsData.Count));
                        if (member.StationsGenerated)
                        {
                            sb.AppendLine(string.Format("Total Stations: {0}", member.Stations.Count));
                        }
                        break;
                }
            }
        }

        public static void DoCycle()
        {
            try
            {
                if (ExtendedSurvivalEntityManager.Instance != null)
                {
                    var query = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.GetAsteroidStorage().NotSpawnAsteroids.Any()).ToArray();
                    {
                        if (query.Any())
                        {
                            foreach (var member in query)
                            {
                                var storage = member.GetAsteroidStorage();
                                var asteroidsQuery = storage.NotSpawnAsteroids.Where(x => ExtendedSurvivalEntityManager.Instance.AnyPlayerInRange(x, SPAWN_DISTANCE));
                                if (asteroidsQuery.Any())
                                {
                                    var asteroidsToSpawn = asteroidsQuery.ToArray();
                                    foreach (var pos in asteroidsToSpawn)
                                    {
                                        var data = storage.AsteroidsData.FirstOrDefault(x => x.Position == pos);
                                        if (data != null)
                                        {
                                            data.Id = CreateAsteroid(pos, data.Radius, data.Seed, data.Forward, data.Up);
                                            storage.Asteroids.Add(data.Id);
                                            storage.NotSpawnAsteroids.Remove(pos);
                                            storage.Modified = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        private static void CheckFactionsCreated()
        {
            try
            {
                if (!ExtendedSurvivalStorage.Instance.Factions.Any())
                {
                    var factionTypes = Enum.GetValues(typeof(FactionType)).Cast<FactionType>().ToList();
                    if (!ExtendedSurvivalCoreSession.IsUsingStatsAndEffects())
                    {
                        factionTypes.Remove(FactionType.Farming);
                        factionTypes.Remove(FactionType.Livestock);
                    }
                    var factionToGenerate = ExtendedSurvivalSettings.Instance.TradeStations.TradeFactionsAmount.ToVector2I().GetRandomInt();
                    var f = 0;
                    int i = 0;
                    while (i < factionToGenerate)
                    {

                        var tag = "";
                        var name = "";
                        do
                        {
                            name = SpaceStationController.GetFactionName(factionTypes[f], out tag);
                        }
                        while (MyAPIGateway.Session.Factions.FactionTagExists(tag));

                        var desc = SpaceStationController.GetFactionDesc(factionTypes[f]) + Environment.NewLine + $"Operation type: {factionTypes[f]}.";

                        for (int c = 0; c < 10; c++)
                        {

                            MyAPIGateway.Session.Factions.CreateNPCFaction(tag, name, desc, "");

                            int p = 0;
                            while (!MyAPIGateway.Session.Factions.FactionTagExists(tag) && p < 30)
                            {
                                MyAPIGateway.Parallel.Sleep(100);
                                p++;
                            }

                            if (MyAPIGateway.Session.Factions.FactionTagExists(tag))
                                break;

                        }

                        if (MyAPIGateway.Session.Factions.FactionTagExists(tag))
                        {
                            var faction = MyAPIGateway.Session.Factions.TryGetFactionByTag(tag);
                            DoResetFactionBalance(faction);
                            var factionStore = ExtendedSurvivalStorage.Instance.GetFaction(faction.FactionId);
                            factionStore.FactionType = (int)factionTypes[f];
                            factionStore.Name = name;
                            factionStore.Tag = tag;
                            f++;
                            if (f >= factionTypes.Count)
                                f = 0;
                            i++;
                        }
                    }
                    DoResetAnyNpcBalance();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        public static void DoResetAllFactionBalance()
        {
            try
            {
                if (!ExtendedSurvivalStorage.Instance.Factions.Any())
                {
                    foreach (var item in ExtendedSurvivalStorage.Instance.Factions)
                    {
                        var faction = MyAPIGateway.Session.Factions.TryGetFactionById(item.FactionId);
                        if (faction != null)
                        {
                            DoResetFactionBalance(faction);
                        }
                    }
                    DoResetAnyNpcBalance();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        private static void DoResetAnyNpcBalance()
        {
            List<IMyIdentity> identities = new List<IMyIdentity>();
            MyAPIGateway.Players.GetAllIdentites(identities, (x) => { return MyAPIGateway.Players.TryGetSteamId(x.IdentityId) == 0; });
            foreach (var item in identities)
            {
                MyAPIGateway.Players.RequestChangeBalance(item.IdentityId, long.MaxValue / 2);
            }
        }

        private static void DoResetFactionBalance(IMyFaction faction)
        {
            InvokeOnGameThread(() => {
                faction.RequestChangeBalance(long.MaxValue / 2);
                if (faction.Members.Any())
                {
                    foreach (var item in faction.Members)
                    {
                        MyAPIGateway.Players.RequestChangeBalance(item.Key, long.MaxValue / 2);
                    }
                }
            });
        }

        private static void RemoveStationFromPlanet(StarSystemMemberStorage member)
        {
            if (member.StationsGenerated)
            {
                foreach (var station in member.Stations)
                {
                    if (station.StationEntityId != 0)
                    {
                        var entity = ExtendedSurvivalEntityManager.GetGridById(station.StationEntityId);
                        if (entity != null)
                        {
                            entity.Entity.Close();
                            var safeZone = ExtendedSurvivalEntityManager.GetSafeZoneById(station.SafeZoneEntityId);
                            if (safeZone != null)
                                safeZone.Close();
                            station.StationEntityId = 0;
                            station.SafeZoneEntityId = 0;
                        }
                    }
                    if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateTradeStationsGps)
                    {
                        MyVisualScriptLogicProvider.RemoveGPSForAll(station.Name);
                    }
                }
                member.Stations.Clear();
                member.StationsGenerated = false;
            }
        }

        private static void DoCreateStationOnPlanet(StarSystemMemberStorage member, List<SpaceStationController.StationLevel> staSizes)
        {
            try
            {
                var validItem = new int[]
                {
                    (int)PlanetProfile.PlanetType.Moon,
                    (int)PlanetProfile.PlanetType.Planet
                };

                if (!validItem.Contains(member.ItemType))
                    return;

                var planet = ExtendedSurvivalEntityManager.GetPlanetById(member.EntityId);
                if (planet != null)
                {
                    var targetCoords = new List<Vector3D>
                                        {
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Up * 5),
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Down * 5),
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Left * 5),
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Right * 5),
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Forward * 5),
                                            planet.Entity.PositionComp.GetPosition() + (planet.Entity.WorldMatrix.Backward * 5)
                                        };

                    var totalToGenerate = new Vector2I(3, 6).GetRandomInt();
                    while (targetCoords.Count > totalToGenerate)
                    {
                        targetCoords.Remove(targetCoords.OrderBy(x => GetRandomDouble()).FirstOrDefault());
                    }

                    foreach (var targetPos in targetCoords)
                    {

                        var minStaCount = ExtendedSurvivalStorage.Instance.Factions.Min(x => x.Stations.Count);
                        var factionIds = ExtendedSurvivalStorage.Instance.Factions.Where(x => x.Stations.Count == minStaCount).Select(x => x.FactionId).ToList();
                        var targetFaction = factionIds.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                        var factionData = ExtendedSurvivalStorage.Instance.GetFaction(targetFaction);

                        var staType = factionData.FactionType == (int)FactionType.Miner ?
                            SpaceStationController.StationType.MiningStation :
                            SpaceStationController.StationType.Outpost;

                        if (MyUtils.GetRandomFloat(0, 1) <= 0.4f)
                        {
                            staType = SpaceStationController.StationType.OrbitalStation;
                        }

                        var prefabName = SpaceStationController.VALID_PREFABS[staType].OrderBy(x => GetRandomDouble()).FirstOrDefault();

                        var surfacePos = planet.Entity.GetClosestSurfacePointGlobal(targetPos);
                        var surfaceUpPos = planet.UpAtPosition(surfacePos);
                        var surfaceRandomForward = RandomPerpendicular(surfaceUpPos);

                        if (prefabName.swapUpToFoward)
                        {
                            var tmpF = surfaceRandomForward;
                            surfaceRandomForward = surfaceUpPos;
                            surfaceUpPos = tmpF;
                        }

                        var staSize = staSizes.OrderBy(x => GetRandomDouble()).FirstOrDefault();

                        if (staType == SpaceStationController.StationType.OrbitalStation)
                        {

                            float naturalGravityInterference;
                            do
                            {
                                surfacePos += surfaceUpPos * 50;
                                Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(surfacePos, out naturalGravityInterference);
                            } while (naturalGravityInterference != 0);

                            surfacePos += surfaceUpPos * 100;

                            /* no orbital station are small */
                            if (staSize == SpaceStationController.StationLevel.Small)
                                staSize = SpaceStationController.StationLevel.Medium;

                        }

                        var stationName = "";
                        do
                        {
                            stationName = $"{factionData.Tag} - {SpaceStationController.STATION_TYPE_NAME[staType]}: {SpaceStationController.GetStationName()}";
                        } while (ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.Stations.Any(y => y.Name == stationName)));

                        var staStored = new StarSystemMemberStationStorage()
                        {
                            Id = MyUtils.GetRandomLong(),
                            Name = stationName,
                            FactionId = targetFaction,
                            Position = surfacePos,
                            Up = surfaceUpPos,
                            Foward = surfaceRandomForward,
                            StationType = (int)staType,
                            StationLevel = (int)staSize,
                            WithAtmosphere = planet.Setting.Atmosphere.Enabled &&
                                planet.Setting.Atmosphere.Density > 0 &&
                                planet.Setting.Atmosphere.LimitAltitude >= 1,
                            LowAtmosphereDensity = planet.Setting.Atmosphere.Enabled &&
                                planet.Setting.Atmosphere.Density <= 0.5 &&
                                planet.Setting.Atmosphere.LimitAltitude >= 1,
                            StationEntityId = 0,
                            PrefabName = prefabName.name,
                            PrefabUpIncrement = prefabName.upIncrement,
                            ComercialTick = 0,
                            FirstContact = false
                        };
                        member.Stations.Add(staStored);
                        factionData.Stations.Add(staStored.Id);

                        if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateTradeStationsGps)
                        {
                            MyVisualScriptLogicProvider.AddGPSForAll(staStored.Name, $"Station size: {staSize}.", surfacePos, Color.DarkOrange);
                        }

                    }

                    member.StationsGenerated = true;

                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        private static void DoCreateStationOnAsteroidBelt(StarSystemMemberStorage member, List<SpaceStationController.StationLevel> staSizes)
        {
            try
            {
                var storage = member.GetAsteroidStorage();
                if (storage.AsteroidsData.Any())
                {
                    var minStations = (int)Math.Max(storage.AsteroidsData.Count / 1000f, 4f);
                    var maxStations = (int)Math.Max(storage.AsteroidsData.Count / 500f, 8f);
                    var totalToGenerate = new Vector2I(minStations, maxStations).GetRandomInt();
                    var fraction = storage.AsteroidsData.Count / totalToGenerate;
                    var targetCoords = new List<Vector3D>();
                    var validCoords = storage.AsteroidsData.Select(x => x.Position).ToArray();
                    for (int i = 0; i < totalToGenerate; i++)
                    {
                        var targetIndex = i * fraction;
                        if (targetIndex >= 0 && targetIndex < validCoords.Length)
                        {
                            var stationTarget = validCoords[targetIndex];
                            var targetData = storage.AsteroidsData.FirstOrDefault(x => x.Position == stationTarget);
                            if (targetData != null)
                            {
                                var targetOrientations = new List<Vector3D>
                                {
                                    stationTarget + (MatrixD.Identity.Up * (targetData.Radius + SAFE_DISTANCE)),
                                    stationTarget + (MatrixD.Identity.Down * (targetData.Radius + SAFE_DISTANCE)),
                                    stationTarget + (MatrixD.Identity.Left * (targetData.Radius + SAFE_DISTANCE)),
                                    stationTarget + (MatrixD.Identity.Right * (targetData.Radius + SAFE_DISTANCE)),
                                    stationTarget + (MatrixD.Identity.Forward * (targetData.Radius + SAFE_DISTANCE)),
                                    stationTarget + (MatrixD.Identity.Backward * (targetData.Radius + SAFE_DISTANCE))
                                };
                                var stationPos = targetOrientations[new Vector2I(0, 5).GetRandomInt()];
                                var stationUp = Vector3D.Normalize(stationPos - Vector3D.One);
                                var stationRandomForward = RandomPerpendicular(stationUp);
                                var staSize = staSizes.OrderBy(x => GetRandomDouble()).FirstOrDefault();

                                var minStaCount = ExtendedSurvivalStorage.Instance.Factions.Min(x => x.Stations.Count);
                                var factionIds = ExtendedSurvivalStorage.Instance.Factions.Where(x => x.Stations.Count == minStaCount).Select(x => x.FactionId).ToList();
                                var targetFaction = factionIds.OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                var factionData = ExtendedSurvivalStorage.Instance.GetFaction(targetFaction);
                                var staType = SpaceStationController.StationType.SpaceStation;

                                var prefabName = SpaceStationController.VALID_PREFABS[staType].OrderBy(x => GetRandomDouble()).FirstOrDefault();

                                var stationName = "";
                                do
                                {
                                    stationName = $"{factionData.Tag} - {SpaceStationController.STATION_TYPE_NAME[staType]}: {SpaceStationController.GetStationName()}";
                                } while (ExtendedSurvivalStorage.Instance.StarSystem.Members.Any(x => x.Stations.Any(y => y.Name == stationName)));

                                var staStored = new StarSystemMemberStationStorage()
                                {
                                    Id = MyUtils.GetRandomLong(),
                                    Name = stationName,
                                    FactionId = targetFaction,
                                    Position = stationPos,
                                    Up = stationUp,
                                    Foward = stationRandomForward,
                                    StationType = (int)staType,
                                    StationLevel = (int)staSize,
                                    WithAtmosphere = false,
                                    LowAtmosphereDensity = false,
                                    StationEntityId = 0,
                                    PrefabName = prefabName.name,
                                    PrefabUpIncrement = prefabName.upIncrement,
                                    ComercialTick = 0,
                                    FirstContact = false
                                };
                                member.Stations.Add(staStored);
                                factionData.Stations.Add(staStored.Id);

                                if (ExtendedSurvivalSettings.Instance.StarSystemConfiguration.AutoGenerateTradeStationsGps)
                                {
                                    MyVisualScriptLogicProvider.AddGPSForAll(staStored.Name, $"Station size: {staSize}.", stationPos, Color.DarkOrange);
                                }
                            }
                        }
                    }

                    member.StationsGenerated = true;

                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        public static void ClearAsteroidsThatCanBeRemoved()
        {
            try
            {
                if (ExtendedSurvivalStorage.Instance.StarSystem.Generated &&
                    ExtendedSurvivalEntityManager.Instance != null &&
                    ExtendedSurvivalEntityManager.Instance.InicialLoadComplete)
                {
                    var query = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt);
                    if (query.Any())
                    {
                        foreach (var member in query)
                        {
                            var storage = member.GetAsteroidStorage();
                            if (storage.Asteroids.Any())
                            {
                                List<long> itensToRemove = new List<long>();
                                for (int i = 0; i < storage.Asteroids.Count; i++)
                                {
                                    var asteroidData = storage.AsteroidsData.FirstOrDefault(x => x.Id == storage.Asteroids[i]);
                                    if (asteroidData != null)
                                    {
                                        var noOneAround = !ExtendedSurvivalEntityManager.Instance.AnyInRange(asteroidData.Position, SPAWN_DISTANCE);
                                        if (noOneAround || !asteroidData.Changed)
                                        {
                                            VRage.ModAPI.IMyEntity asteroid = null;
                                            lock (storage.Asteroids)
                                            {
                                                InvokeOnGameThread(() =>
                                                {
                                                    asteroid = MyAPIGateway.Entities.GetEntityById(storage.Asteroids[i]);
                                                });
                                            }
                                            var voxel = (asteroid as MyVoxelBase);
                                            if (asteroid != null && voxel != null)
                                            {
                                                if (!asteroidData.Changed && voxel.ContentChanged)
                                                    asteroidData.Changed = true;
                                                if (noOneAround && !asteroidData.Changed)
                                                {
                                                    itensToRemove.Add(asteroid.EntityId);
                                                    asteroid.Close();
                                                    asteroidData.Id = 0;
                                                    storage.NotSpawnAsteroids.Add(asteroidData.Position);
                                                    storage.Modified = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        itensToRemove.Add(storage.Asteroids[i]);
                                    }
                                }
                                if (itensToRemove.Any())
                                {
                                    storage.Asteroids.RemoveAll(x => itensToRemove.Contains(x));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
            }
        }

        public static void RecreateAsteroids(bool newSeed = true)
        {
            try
            {
                if (ExtendedSurvivalStorage.Instance.StarSystem.Generated)
                {
                    var query = ExtendedSurvivalStorage.Instance.StarSystem.Members.Where(x => x.MemberType == (int)StarSystemProfile.MemberType.AsteroidBelt);
                    if (query.Any())
                    {
                        foreach (var member in query)
                        {
                            var storage = member.GetAsteroidStorage();
                            if (storage.Asteroids.Any())
                            {
                                for (int i = 0; i < storage.Asteroids.Count; i++)
                                {
                                    var asteroid = MyAPIGateway.Entities.GetEntityById(storage.Asteroids[i]);
                                    if (asteroid != null)
                                    {
                                        asteroid.Close();
                                    }   
                                }
                            }
                            storage.Asteroids.Clear();
                            foreach (var item in storage.AsteroidsData)
                            {
                                item.Id = 0;
                                if (newSeed)
                                {
                                    item.Seed = GetRandomAsteroidSeed();
                                    item.Radius = GetRandomAsteroidRadius();
                                    item.Forward = GetRandomVector(GetRandomDouble(1000) + 1);
                                    item.Up = GetRandomVector(GetRandomDouble(1000) + 1);
                                }
                                item.Changed = false;
                            }
                            storage.NotSpawnAsteroids = storage.AsteroidsData.Select(x => x.Position).ToList();
                            storage.Modified = true;
                        }
                    }
                }
            }
            finally
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = false;
            }
        }

        public static void RecreateFactions()
        {
            try
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = true;
                try
                {

                    foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                    {
                        RemoveStationFromPlanet(member);
                    }

                    RemoveAllFactions();

                    CheckFactionsCreated();

                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                }
            }
            finally
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = false;
            }
        }

        private static void CreateStationToPlanet(StarSystemMemberStorage member)
        {
            CheckFactionsCreated();

            if (!ExtendedSurvivalStorage.Instance.Factions.Any())
                return;

            RemoveStationFromPlanet(member);

            var validTypes = new int[] {
                (int)StarSystemProfile.MemberType.Planet,
                (int)StarSystemProfile.MemberType.AsteroidBelt
            };

            var staSizes = Enum.GetValues(typeof(SpaceStationController.StationLevel)).Cast<SpaceStationController.StationLevel>().ToList();
            if (validTypes.Contains(member.MemberType))
            {
                switch ((StarSystemProfile.MemberType)member.MemberType)
                {
                    case StarSystemProfile.MemberType.Planet:
                        DoCreateStationOnPlanet(member, staSizes);
                        break;
                    case StarSystemProfile.MemberType.AsteroidBelt:
                        DoCreateStationOnAsteroidBelt(member, staSizes);
                        break;
                }
            }
        }

        private static void CreateStationsToAllPlanets()
        {
            try
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = true;
                try
                {

                    foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                    {
                        CreateStationToPlanet(member);
                    }

                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                }
            }
            finally
            {
                ExtendedSurvivalEntityManager.Instance.FactionsLocked = false;
            }
        }

        public static Vector3D RandomPerpendicular(Vector3D referenceDir)
        {

            var refDir = Vector3D.Normalize(referenceDir);
            return Vector3D.Normalize(MyUtils.GetRandomPerpendicularVector(ref refDir));

        }

        private static Vector3D CreateAsteroidBelt(SystemMemberSetting asteroidSystem, Vector3D centerPosition, float orbitDistance, out Dictionary<int, Vector3D> asteroids)
        {
            asteroids = new Dictionary<int, Vector3D>();

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

                Vector3D asteroidPosition = centerPosition + asteroidOffset;

                asteroids.Add(i, asteroidPosition);

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

        public static void InvokeOnGameThread(Action action, bool wait = true)
        {
            int maxWait = 100;
            bool isExecuting = true;
            MyAPIGateway.Utilities.InvokeOnGameThread(() =>
            {
                try
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                    }
                }
                finally
                {
                    isExecuting = false;
                }
            });
            int c = 0;
            while (wait && isExecuting && c < maxWait)
            {
                if (MyAPIGateway.Parallel != null)
                    MyAPIGateway.Parallel.Sleep(25);
                c++;
            }
        }

        private static readonly Vector2I AsteroidSeed = new Vector2I(int.MinValue, int.MaxValue);
        private static long CreateAsteroid(Vector3D position, float radius, int seed = 0, Vector3? forward = null, Vector3? up = null)
        {
            long id = 0;
            InvokeOnGameThread(() => {
                var voxelMaps = MyAPIGateway.Session.VoxelMaps;
                if (forward == null)
                    forward = GetRandomVector(GetRandomDouble(1000) + 1);
                if (up == null)
                    up = GetRandomVector(GetRandomDouble(1000) + 1);
                MatrixD matrix = MatrixD.CreateWorld(position, forward.Value, up.Value);
                var asteroid = voxelMaps.CreateProceduralVoxelMap(seed == 0 ? AsteroidSeed.GetRandomInt() : seed, radius, matrix);
                id = asteroid.EntityId;
            });
            return id;
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