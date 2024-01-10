using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Core
{
    public static class DecaySystemController
    {

        public static MyStringHash RustHash { get; private set; }
        public static MyStringHash HeavyRustHash { get; private set; }

        static DecaySystemController()
        {

            RustHash = MyStringHash.GetOrCompute("Rusty_Armor");
            HeavyRustHash = MyStringHash.GetOrCompute("Heavy_Rust_Armor");

        }

        public static bool CreatePlayerInfoIfNotExits(long playerId, out ulong outSteamId)
        {
            var steamId = MyAPIGateway.Players.TryGetSteamId(playerId);
            outSteamId = steamId;
            try
            {
                if (steamId != 0)
                {
                    if (!ExtendedSurvivalStorage.Instance.Decay.Players.Any(x => x.SteamId == steamId))
                    {
                        List<IMyIdentity> identities = new List<IMyIdentity>();
                        MyAPIGateway.Players.GetAllIdentites(identities, x => x.IdentityId == playerId);
                        if (identities.Any())
                        {
                            ExtendedSurvivalStorage.Instance.Decay.Players.Add(new PlayerDecayStorage()
                            {
                                DisplayName = identities[0].DisplayName,
                                ImuneToDecay = false,
                                LastActiveTime = DateTime.UtcNow,
                                SteamId = steamId
                            });
                        }
                        return true;
                    }
                    else
                    {
                        if (ExtendedSurvivalStorage.Instance.Decay.Players.Count(x => x.SteamId == steamId) > 1)
                        {
                            var itemToSave = ExtendedSurvivalStorage.Instance.Decay.Players.Where(x => x.SteamId == steamId).OrderByDescending(x => x.LastActiveTime).FirstOrDefault();
                            ExtendedSurvivalStorage.Instance.Decay.Players.RemoveAll(x => x.SteamId == steamId && x != itemToSave);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
            }
            return false;
        }

        public static void RegisterPlayerAction(long playerId)
        {
            try
            {
                ulong steamId = 0;
                if (!CreatePlayerInfoIfNotExits(playerId, out steamId))
                {
                    var info = ExtendedSurvivalStorage.Instance.Decay.Get(steamId);
                    info.LastActiveTime = DateTime.UtcNow;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
            }
        }

        public static void DoCycle()
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.Decay.Enabled)
                {
                    ExtendedSurvivalEntityManager.Instance.DoRunDecay();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
            }
        }

    }

}