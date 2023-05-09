using ObjectBuilders.SafeZone;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Multiplayer;
using Sandbox.Game.Screens.Helpers;
using Sandbox.Game.World;
using Sandbox.ModAPI;
using SpaceEngineers.Game.Entities.Blocks.SafeZone;
using SpaceEngineers.Game.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Factions.Definitions;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.ObjectBuilders.Definitions.Factions;
using VRage.ObjectBuilders;
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
                    MyVisualScriptLogicProvider.RemoveGPSForAll(station.Name);
                }
                if (ExtendedSurvivalSettings.Instance.AutoGenerateStarSystemGps)
                {
                    MyVisualScriptLogicProvider.RemoveGPSForAll(item.Name);
                }
            }
            ExtendedSurvivalStorage.Instance.StarSystem.Members.Clear();
            ExtendedSurvivalStorage.Instance.StarSystem.Name = "";
            ExtendedSurvivalStorage.Instance.StarSystem.Generated = false;
            ExtendedSurvivalStorage.Instance.StarSystem.ComercialTick = 0;
            ExtendedSurvivalStorage.Instance.StarSystem.ComercialCountdown = 0;
            foreach (var faction in ExtendedSurvivalStorage.Instance.Factions)
            {
                MyAPIGateway.Session.Factions.RemoveFaction(faction.FactionId);
            }
            ExtendedSurvivalStorage.Instance.Factions.Clear();
            ExtendedSurvivalStorage.Instance.PlayersMappedToFactions.Clear();
            ExtendedSurvivalStorage.Instance.FactionsMappedToFactions.Clear();
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
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = 0.35f;
                            else
                                MyAPIGateway.Session.SessionSettings.ProceduralDensity = 0;
                            ExtendedSurvivalStorage.Instance.StarSystem.Name = profile.Name;
                            ExtendedSurvivalStorage.Instance.StarSystem.Generated = true;
                            float createdPlanets = 0;
                            if (!flags.IsFlagSet(GenerationFlags.NoStar) && (profile.WithStar || flags.IsFlagSet(GenerationFlags.WithStar)))
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
                            foreach (var member in members)
                            {
                                var memberType = (StarSystemProfile.MemberType)member.MemberType;
                                List<long> asteroids = null;
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
                                            planet.AsteroidName = $"Planet {p + 1} - {member.Name}";
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
                                                    var validMoons = generationType == StarSystemProfile.ProfileType.Random ? planets.Where(x => x.Type == (int)PlanetProfile.PlanetType.Moon).ToList() : planets.ToList();
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
                                                            var moonToCreate = validMoons.Where(x => member.ValidMoons.Any(c => c.Id.ToUpper() == x.Id.ToUpper())).OrderBy(x => GetRandomDouble()).FirstOrDefault();
                                                            if (moonToCreate == null)
                                                            {
                                                                moonToCreate = validMoons.OrderBy(x => GetRandomDouble()).FirstOrDefault();
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
                                                            moon.AsteroidName = $"Planet {p + 1} - Moon {j + 1} - {moonToCreate.Id}";
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

                            // Try to move stations to generated planets
                            MyAPIGateway.Parallel.StartBackground(() =>
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
                                        var factionToGenerate = ExtendedSurvivalSettings.Instance.TradeFactionsAmount.ToVector2I().GetRandomInt();
                                        var f = 0;
                                        for (int i = 0; i < factionToGenerate; i++)
                                        {
                                            var tag = "";
                                            var name = "";
                                            do
                                            {
                                                name = SpaceStationController.GetFactionName(factionTypes[f], out tag);
                                            }
                                            while (MyAPIGateway.Session.Factions.FactionTagExists(tag));
                                            var desc = SpaceStationController.GetFactionDesc(factionTypes[f]) + Environment.NewLine + $"Operation type: {factionTypes[f]}.";

                                            MyAPIGateway.Session.Factions.CreateNPCFaction(tag, name, desc, "");
                                            while (!MyAPIGateway.Session.Factions.FactionTagExists(tag))
                                                MyAPIGateway.Parallel.Sleep(100);

                                            var faction = MyAPIGateway.Session.Factions.TryGetFactionByTag(tag);
                                            faction.RequestChangeBalance(long.MaxValue);
                                            var factionStore = ExtendedSurvivalStorage.Instance.GetFaction(faction.FactionId);
                                            factionStore.FactionType = (int)factionTypes[f];
                                            factionStore.Name = name;
                                            factionStore.Tag = tag;
                                            f++;
                                            if (f >= factionTypes.Count)
                                                f = 0;
                                        }
                                        // Set peace to all in the system
                                        var ids = MyAPIGateway.Session.Factions.Factions.Keys.Where(x => ExtendedSurvivalStorage.Instance.Factions.Any(y => y.FactionId == x)).ToArray();
                                        var playerFacIds = MyAPIGateway.Session.Factions.Factions.Where(x => MyAPIGateway.Players.TryGetSteamId(x.Value.FounderId) != 0).Select(x => x.Key).ToArray();
                                        List<IMyIdentity> identities = new List<IMyIdentity>();
                                        MyAPIGateway.Players.GetAllIdentites(identities, x => MyAPIGateway.Players.TryGetSteamId(x.IdentityId) != 0);
                                        for (int i = 0; i < ids.Length; i++)
                                        {
                                            for (int j = 0; j < ids.Length; j++)
                                            {
                                                if (i != j)
                                                {
                                                    MyAPIGateway.Session.Factions.SetReputation(i, j, 1000);
                                                }
                                            }
                                            foreach (var pId in playerFacIds)
                                            {
                                                MyAPIGateway.Session.Factions.SetReputation(i, pId, 1000);
                                            }
                                            foreach (var player in identities)
                                            {
                                                MyAPIGateway.Session.Factions.SetReputationBetweenPlayerAndFaction(player.IdentityId, i, 1000);
                                            }
                                        }
                                        ExtendedSurvivalStorage.Instance.PlayersMappedToFactions.Clear();
                                        ExtendedSurvivalStorage.Instance.PlayersMappedToFactions.AddRange(identities.Select(x => x.IdentityId));
                                        ExtendedSurvivalStorage.Instance.FactionsMappedToFactions.Clear();
                                        ExtendedSurvivalStorage.Instance.FactionsMappedToFactions.AddRange(playerFacIds);
                                    }

                                    var staSizes = Enum.GetValues(typeof(SpaceStationController.StationLevel)).Cast<SpaceStationController.StationLevel>().ToList();
                                    foreach (var member in ExtendedSurvivalStorage.Instance.StarSystem.Members)
                                    {
                                        if (member.MemberType == (int)StarSystemProfile.MemberType.Planet)
                                        {
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

                                                var totalToGenerate = new Vector2I(1, 6).GetRandomInt();
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

                                                    if (staType == SpaceStationController.StationType.OrbitalStation)
                                                    {

                                                        float naturalGravityInterference;
                                                        do
                                                        {
                                                            surfacePos += surfaceUpPos * 50;
                                                            Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(surfacePos, out naturalGravityInterference);
                                                        } while (naturalGravityInterference != 0);

                                                    }

                                                    var staSize = staSizes.OrderBy(x => GetRandomDouble()).FirstOrDefault();

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
                                                        HasAtmosphere = planet.Setting.Atmosphere.Enabled && planet.Setting.Atmosphere.Density > 0,
                                                        StationEntityId = 0,
                                                        PrefabName = prefabName.name,
                                                        PrefabUpIncrement = prefabName.upIncrement,
                                                        ComercialTick = 0,
                                                        FirstContact = false
                                                    };
                                                    member.Stations.Add(staStored);
                                                    factionData.Stations.Add(staStored.Id);

                                                    MyVisualScriptLogicProvider.AddGPSForAll(staStored.Name, $"Station size: {staSize}.", surfacePos, Color.Yellow);

                                                }

                                            }
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(StarSystemController), ex);
                                }

                            });

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

        public static Vector3D RandomPerpendicular(Vector3D referenceDir)
        {

            var refDir = Vector3D.Normalize(referenceDir);
            return Vector3D.Normalize(MyUtils.GetRandomPerpendicularVector(ref refDir));

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