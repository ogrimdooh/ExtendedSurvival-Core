using Sandbox.Game;
using Sandbox.Game.Entities.Character;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class HuntingSystemController
    {

        private static ConcurrentDictionary<ulong, long> _playerHuntCountDown = new ConcurrentDictionary<ulong, long>();

        private static long lastCycle = 0;

        private static long GetSpendTime()
        {
            return MyExtendedSurvivalTimeManager.Instance.GameTime - lastCycle;
        }

        private static void RefreshCycleTime()
        {
            lastCycle = MyExtendedSurvivalTimeManager.Instance.GameTime;
        }

        private static void DoProcessCountDown()
        {
            var spendTime = GetSpendTime();
            RefreshCycleTime();
            var keys = _playerHuntCountDown.Keys.ToArray();
            foreach (var k in keys)
            {
                _playerHuntCountDown[k] -= spendTime;
                if (_playerHuntCountDown[k] <= 0)
                    _playerHuntCountDown.Remove(k);
            }
        }

        private static bool IsPlayerInCountDown(long playerId, out ulong steamId)
        {
            steamId = MyAPIGateway.Players.TryGetSteamId(playerId);
            return _playerHuntCountDown.ContainsKey(steamId) && _playerHuntCountDown[steamId] > 0;
        }

        private static void AddPlayerToCountDown(ulong steamId, long time)
        {
            lock(_playerHuntCountDown)
            {
                if (!_playerHuntCountDown.ContainsKey(steamId))
                    _playerHuntCountDown[steamId] = 0;
                _playerHuntCountDown[steamId] += time;
            }
        }

        private static void DoHunt(Vector3D pos, ulong steamId, PlanetEntity planet, IEnumerable<PlanetAnimalEntrySetting> animals, PlanetAnimalSpawnSetting animalSettings, PlanetMapAnimalsProfile.AnimalTimeToSpawn timeToSpawn)
        {
            var material = planet.GetMaterialAt(pos);
            if (material == null)
                return;

            var biome = planet.Setting.Biomes.FirstOrDefault(x => x.VoxelMaterials.Any(y => y.Id == material.Id.SubtypeName));
            if (biome == null)
                return;

            animals = animals.Where(x =>
                (x.TimeToSpawn == 0 || x.TimeToSpawn == (int)timeToSpawn) &&
                (!x.Biomes.Any() || x.Biomes.Any(y => y.Id == biome.Id))
            );
            if (!animals.Any())
                return;
            var validAnimals = ExtendedSurvivalSettings.Instance.Hunting.Animals.Where(x => animals.Any(y => y.Id == x.Id));
            if (!validAnimals.Any())
                return;

            // Try to spawn
            if (MyUtils.GetRandomFloat() < ExtendedSurvivalSettings.Instance.Hunting.HuntCycleSpawnChance)
            {
                // Get the spawn amount
                var totalCreatures = (int)(ExtendedSurvivalSettings.Instance.Hunting.SpawnCreatureAmount.ToVector2I().GetRandom() * animalSettings.SpawnCreatureAmountMultiplier);
                if (totalCreatures > 0)
                {
                    // Add player countdown
                    var playerTime = (long)(ExtendedSurvivalSettings.Instance.Hunting.HuntCycleCountDownMinutes.ToVector2().GetRandom() * animalSettings.HuntCycleCountDownMultiplier * 60 * 1000);
                    AddPlayerToCountDown(steamId, playerTime);
                    // Get if is a agressive creature
                    var isAgressive = MyUtils.GetRandomFloat() < ExtendedSurvivalSettings.Instance.Hunting.HuntCycleAgressiveCreatureChance;
                    if (!validAnimals.Any(x => x.IsAgressive == isAgressive))
                        isAgressive = !isAgressive;
                    // Start to spawn creatures
                    for (int i = 0; i < totalCreatures; i++)
                    {

                        // Get total creatures in region
                        var rangeBots = ExtendedSurvivalEntityManager.Instance.AllBotInRange(pos, ExtendedSurvivalSettings.Instance.Hunting.CreatureHuntRegionCheckRange);
                        var totalBots = rangeBots.Count;

                        // Check if has max creatures in range
                        if (totalBots >= ExtendedSurvivalSettings.Instance.Hunting.MaxCreaturesInHuntRegion)
                            break;

                        var animalToSpawn = validAnimals.Where(x => x.IsAgressive == isAgressive).OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                        if (animalToSpawn != null)
                        {

                            var animalPlanetDef = animals.FirstOrDefault(x => x.Id == animalToSpawn.Id);
                            if (animalPlanetDef != null)
                            {

                                // Calc spawn distance
                                var distanceToSpawn = ExtendedSurvivalSettings.Instance.Hunting.SpawnCreatureDistance.ToVector2().GetRandom() * animalSettings.SpawnCreatureDistanceMultiplier;

                                // Get spawn point
                                var spawnPos = planet.GetRandomSurfacePosition(pos, distanceToSpawn);

                                if (spawnPos.HasValue)
                                {
                                    // Create the bot in the surface
                                    MyVisualScriptLogicProvider.SpawnBot(animalToSpawn.Id, spawnPos.Value);
                                    MyAPIGateway.Parallel.Sleep(100); // Let some time to create a creature in MyEntities
                                }

                            }

                        }

                    }
                }
            }
        }

        public static bool Ready { get; private set; } = false;
        public static void Init()
        {
            RefreshCycleTime();
            Ready = true;
        }

        public static void LoadData()
        {
            _playerHuntCountDown.Clear();
            foreach (var player in ExtendedSurvivalStorage.Instance.HuntSystem.Players)
            {
                if (player.CountDownTimer > 0)
                    _playerHuntCountDown[player.SteamId] = player.CountDownTimer;
            }
        }

        public static void SaveData()
        {
            foreach (var k in _playerHuntCountDown.Keys)
            {
                PlayerHuntStorage phs = new PlayerHuntStorage() { SteamId = k };
                if (ExtendedSurvivalStorage.Instance.HuntSystem.Players.Any(x => x.SteamId == k))
                {
                    phs = ExtendedSurvivalStorage.Instance.HuntSystem.Players.FirstOrDefault(x => x.SteamId == k);
                }
                else
                {
                    ExtendedSurvivalStorage.Instance.HuntSystem.Players.Add(phs);
                }
                phs.CountDownTimer = _playerHuntCountDown[k];
            }
            foreach (var player in ExtendedSurvivalStorage.Instance.HuntSystem.Players)
            {
                if (!_playerHuntCountDown.ContainsKey(player.SteamId))
                    player.CountDownTimer = 0;
            }
        }

        public static void Unload()
        {

        }

        public static void DoCycle()
        {
            try
            {
                if (!Ready)
                    return;
                if (ExtendedSurvivalSettings.Instance == null || MyExtendedSurvivalTimeManager.Instance == null)
                    return;
                DoProcessCountDown();
                var players = ExtendedSurvivalEntityManager.Instance.Players.Keys.ToArray();
                foreach (var playerId in players)
                {
                    if (ExtendedSurvivalEntityManager.Instance.Players.ContainsKey(playerId))
                    {
                        // Check player is on CountDown
                        ulong steamId = 0;
                        if (IsPlayerInCountDown(playerId, out steamId))
                            continue;
                        // Get player Character
                        var player = ExtendedSurvivalEntityManager.Instance.Players[playerId];
                        if (player?.Character != null && player.IsValidPlayer())
                        {
                            // Check if player is out of the cockpit
                            if (player.Character.Parent == null)
                            {
                                // Check if player is away from large grids
                                var pos = player.GetPosition();

                                // Check if is in gravity
                                float naturalGravityInterference;
                                Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(pos, out naturalGravityInterference);
                                if (naturalGravityInterference == 0)
                                    continue;

                                // Check if has planet config
                                var planet = ExtendedSurvivalEntityManager.GetPlanetAtRange(pos);
                                if (planet == null && planet.Setting != null)
                                    continue;

                                // Check if time of day has spawn enabled
                                var isNight = planet.IsThereNight(ref pos);
                                var animalSettings = isNight ? planet.Setting.Animal.NightSpawn : planet.Setting.Animal.DaySpawn;
                                if (animalSettings == null || !animalSettings.Enabled)
                                    continue;

                                // Check player altitude
                                Vector3D surfacePoint = planet.Entity.GetClosestSurfacePointGlobal(pos);
                                float altitudeSqr = (float)Math.Abs(Vector3D.Distance(pos, surfacePoint));
                                if (altitudeSqr > ExtendedSurvivalSettings.Instance.Hunting.MaxPlayerAltitudeToSpawn)
                                    continue;

                                if (!ExtendedSurvivalEntityManager.Instance.AnyGridInRange(
                                    pos, 
                                    ExtendedSurvivalSettings.Instance.Hunting.MinDistanceFromLargeOrShipGrids, 
                                    (g) => {
                                        return g.Entity.GridSizeEnum == MyCubeSize.Large ||
                                            g.Entity.IsStatic ||
                                            g.Thrusters.Any();
                                    }
                                ))
                                {
                                    // Calc the region ThreatLevel
                                    var grids = ExtendedSurvivalEntityManager.Instance.AllGridsInRange(
                                        pos,
                                        ExtendedSurvivalSettings.Instance.Hunting.RoverThreatLevelCheckRange,
                                        (g) => {
                                            return g.Entity.GridSizeEnum == MyCubeSize.Small &&
                                                !g.Thrusters.Any();
                                        }
                                    );
                                    var totalRegionThreatLevel = grids.Sum(x => x.ThreatLevel);
                                    var areaPlayers = ExtendedSurvivalEntityManager.Instance.AllPlayerInRange(
                                        pos,
                                        ExtendedSurvivalSettings.Instance.Hunting.RoverThreatLevelCheckRange
                                    );
                                    if (areaPlayers.Any())
                                    {
                                        // Check if the region ThreatLevel is fine to Hunt
                                        totalRegionThreatLevel /= areaPlayers.Count();
                                        if (totalRegionThreatLevel < ExtendedSurvivalSettings.Instance.Hunting.MaxRegionThreatLevelByPlayer)
                                        {
                                            DoHunt(
                                                pos, 
                                                steamId, 
                                                planet, 
                                                planet.Setting.Animal.Animals, 
                                                animalSettings, 
                                                isNight ? PlanetMapAnimalsProfile.AnimalTimeToSpawn.NightOnly : PlanetMapAnimalsProfile.AnimalTimeToSpawn.DayOnly
                                            );
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
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(HuntingSystemController), ex);
            }
        }

        internal static void DoInhibitorCycle()
        {
            try
            {
                if (!Ready)
                    return;
                if (ExtendedSurvivalSettings.Instance == null || MyExtendedSurvivalTimeManager.Instance == null)
                    return;
                if (!ExtendedSurvivalSettings.Instance.Hunting.CreatureCombat.HasInhibitorEnabled())
                    return;

                var players = ExtendedSurvivalEntityManager.Instance.Players.Keys.ToArray();
                foreach (var playerId in players)
                {
                    if (ExtendedSurvivalEntityManager.Instance.Players.ContainsKey(playerId))
                    {
                        var player = ExtendedSurvivalEntityManager.Instance.Players[playerId];
                        if (player?.Character != null && player.IsValidPlayer())
                        {
                            var pos = player.GetPosition();
                            if (ExtendedSurvivalEntityManager.Instance.AnyBotInRange(pos, ExtendedSurvivalSettings.Instance.Hunting.CreatureCombat.GetInhibitorArea()))
                            {
                                MyAPIGateway.Utilities.InvokeOnGameThread(() => 
                                {
                                    if (ExtendedSurvivalSettings.Instance.Hunting.CreatureCombat.DisableDampingAroundCreatures)
                                    {
                                        if (player.Character.EnabledDamping)
                                            player.Character.SwitchDamping();
                                    }
                                    if (ExtendedSurvivalSettings.Instance.Hunting.CreatureCombat.DisableThrustsAroundCreatures)
                                    {
                                        if (player.Character.EnabledThrusts)
                                            player.Character.SwitchThrusts();
                                    }
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(HuntingSystemController), ex);
            }
        }
    }

}
