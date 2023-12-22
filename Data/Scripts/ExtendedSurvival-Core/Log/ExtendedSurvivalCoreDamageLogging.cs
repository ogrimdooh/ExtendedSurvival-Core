using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public sealed class ExtendedSurvivalCoreDamageLogging
    {

        public struct DamageToLogInfo
        {

            public long attackerId;
            public long ownerId;
            public string gridName;
            public Vector3D position;
            public MyDamageInformationExtensions.DamageType damageType;
            public float amount;
            public DateTime time;

        }

        private const string FILE_NAME = "ExtendedSurvival.Damage.Logging.{0}.log";

        private static ExtendedSurvivalCoreDamageLogging _instance;
        public static ExtendedSurvivalCoreDamageLogging Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        public bool IsValid 
        { 
            get
            {
                return _writer != null;
            }
        }

        private TextWriter _writer;

        public static ExtendedSurvivalCoreDamageLogging Load()
        {
            _instance = new ExtendedSurvivalCoreDamageLogging();
            _instance.Load(string.Format(FILE_NAME, GetTimeString().Replace(' ', '_').Replace(':', '-')));
            return _instance;
        }

        private void Load(string fileName)
        {
            var world = true;
            try
            {
                if (world)
                {
                    _writer = MyAPIGateway.Utilities.WriteFileInWorldStorage(fileName, typeof(ExtendedSurvivalCoreDamageLogging));
                }
                else
                {
                    _writer = MyAPIGateway.Utilities.WriteFileInLocalStorage(fileName, typeof(ExtendedSurvivalCoreDamageLogging));
                }
            }
            catch (Exception ex)
            {
                MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Exception while loading: {0}", ex.Message));
            }
        }

        private static string GetTimeString()
        {
            return GetTimeString(DateTime.Now);
        }

        private static string GetTimeString(DateTime time)
        {
            return time.ToString("dd-MM-yyyy HH:mm:ss ffff");
        }

        public void Log(DamageToLogInfo info)
        {
            if (IsValid)
            {
                List<IMyPlayer> players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(players, (x) => { return x.IdentityId == info.attackerId || x.IdentityId == info.ownerId; });
                var attacker = players.FirstOrDefault(x => x.IdentityId == info.attackerId);
                var owner = players.FirstOrDefault(x => x.IdentityId == info.ownerId);
                if (attacker != null && owner != null)
                {
                    var attackerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(info.attackerId);
                    var ownerFaction = MyAPIGateway.Session.Factions.TryGetPlayerFaction(info.ownerId);
                    int reputation = -1000;
                    if (attackerFaction != null && ownerFaction != null)
                    {
                        reputation = MyAPIGateway.Session.Factions.GetReputationBetweenFactions(attackerFaction.FactionId, ownerFaction.FactionId);
                    }
                    else if (attackerFaction != null && ownerFaction == null)
                    {
                        reputation = MyAPIGateway.Session.Factions.GetReputationBetweenPlayerAndFaction(info.ownerId, attackerFaction.FactionId);
                    }
                    else if (attackerFaction == null && ownerFaction != null)
                    {
                        reputation = MyAPIGateway.Session.Factions.GetReputationBetweenPlayerAndFaction(info.attackerId, ownerFaction.FactionId);
                    }
                    string attackerInfo = $"[{info.attackerId}] {attacker.DisplayName}";
                    if (attackerFaction != null)
                        attackerInfo += $" - {attackerFaction.Tag}";
                    string ownerInfo = $"[{info.ownerId}] {owner.DisplayName}";
                    if (ownerFaction != null)
                        ownerInfo += $" - {ownerFaction.Tag}";
                    string positionInfo = $"X:{info.position.X} - Y:{info.position.Y} - Z:{info.position.Z}";
                    float naturalGravityInterference;
                    Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(info.position, out naturalGravityInterference);
                    if (naturalGravityInterference > 0)
                    {
                        var neartPlanet = ExtendedSurvivalEntityManager.GetPlanetAtRange(info.position);
                        if (neartPlanet != null)
                        {
                            positionInfo += $" IN {neartPlanet.Entity.AsteroidName}";
                        }
                    }
                    lock (_writer)
                    {
                        _writer.WriteLine($"{GetTimeString(info.time)} : {attackerInfo} WITH REPUTATION {reputation} ATTACK {ownerInfo} GRIDNAME {info.gridName} CAUSING {info.amount} ({info.damageType}) AT {positionInfo}");
                        _writer.Flush();
                    }
                }
            }
        }

        public void Close()
        {
            if (IsValid)
            {
                _writer.Flush();
                _writer.Close();
            }
        }

    }

}
