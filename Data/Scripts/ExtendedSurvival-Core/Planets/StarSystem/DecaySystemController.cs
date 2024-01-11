using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Cube;
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

        private static Queue<Action> _damageQueue = new Queue<Action>();
        private static Queue<Action> _paintQueue = new Queue<Action>();

        public static bool IsRustSkin(MyStringHash skin)
        {
            return skin == RustHash || skin == HeavyRustHash;
        }

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

        public static void MarkBlockToRust(IMySlimBlock block, MyCubeGrid gridInternal)
        {
            if (block.SkinSubtypeId == HeavyRustHash)
            {
                _damageQueue.Enqueue(() => DamageBlock(block, gridInternal));
            }
            else
            {
                _paintQueue.Enqueue(() => RustBlockPaint(block, gridInternal));
            }
        }

        private static void ShareBlock(IMySlimBlock block)
        {
            if (block.FatBlock != null)
            {
                var cubeBlock = block.FatBlock as MyCubeBlock;
                if (cubeBlock != null)
                {
                    cubeBlock.ChangeOwner(cubeBlock.OwnerId, VRage.Game.MyOwnershipShareModeEnum.All);
                }
            }
        }

        private static void DamageBlock(IMySlimBlock block, MyCubeGrid gridInternal)
        {
            if (block.IsFullyDismounted)
            {
                gridInternal.RazeBlock(block.Position);
            }
            else
            {
                block?.DecreaseMountLevel(ExtendedSurvivalSettings.Instance.Decay.RustDamage, null, true);
                ShareBlock(block);
            }
        }

        private static void RustBlockPaint(IMySlimBlock block, MyCubeGrid gridInternal)
        {
            MyCube myCube;
            gridInternal.TryGetCube(block.Position, out myCube);
            if (myCube == null)
                return;

            if (block.SkinSubtypeId == RustHash)
            {
                gridInternal.ChangeColorAndSkin(myCube.CubeBlock, skinSubtypeId: HeavyRustHash);
            }
            else
            {
                gridInternal.ChangeColorAndSkin(myCube.CubeBlock, skinSubtypeId: RustHash);
            }
            ShareBlock(block);
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

        public static void ProcessPaint()
        {
            if (_paintQueue.Count == 0)
                return;
            for (int i = 0; i < ExtendedSurvivalSettings.Instance.Decay.MaxBlockEachCycle; i++)
            {
                Action action;
                if (!_paintQueue.TryDequeue(out action))
                    return;

                SafeInvoke(action);
            }
        }

        public static void ProcessDamage()
        {
            if (_damageQueue.Count == 0)
                return;
            for (int i = 0; i < ExtendedSurvivalSettings.Instance.Decay.MaxBlockEachCycle; i++)
            {
                Action action;
                if (!_damageQueue.TryDequeue(out action))
                    return;

                SafeInvoke(action);
            }
        }

        private static void SafeInvoke(Action action)
        {
            try
            {
                //action();
                MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
                    }
                });
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
            }
        }

        public static void DoCycle(bool isDamageCycle)
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.Decay.Enabled)
                {
                    if (isDamageCycle)
                    {
                        ProcessPaint();
                        ProcessDamage();
                    }
                    else
                    {
                        ExtendedSurvivalEntityManager.Instance.DoRunDecay();
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(DecaySystemController), ex);
            }
        }

    }

}