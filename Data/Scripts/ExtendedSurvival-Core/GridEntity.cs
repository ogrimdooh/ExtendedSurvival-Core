using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;
using VRage.Utils;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Cube;
using VRageMath;
using VRage.Game.Components;
using System.Collections.Concurrent;
using VRage.ObjectBuilders;
using Sandbox.Common.ObjectBuilders;
using VRage.Game;
using System;
using Sandbox.Game.GameSystems;
using SpaceEngineers.Game.Entities.Blocks;
using SpaceEngineers.Game.ModAPI;

namespace ExtendedSurvival.Core
{

    public class GridEntity : EntityBase<IMyCubeGrid>
    {
        private readonly string[] TURBINEMODULES_SUBTYPES = new string[] { "TurbinePowerOutputModule", "EnhancedTurbinePowerOutputModule", "EliteTurbinePowerOutputModule" };

        private readonly string[] TREADMILL_SUBTYPES = new string[] { "Eikester_Treadmill_SB", "Eikester_Treadmill" };

        private readonly string[] DISASSEMBLYCOMPUTER_SUBTYPES = new string[] { "DisassemblyComputer", "SmallDisassemblyComputer" };

        private readonly string[] ADVANCEDDISASSEMBLYCOMPUTER_SUBTYPES = new string[] { "AdvancedDisassemblyComputer", "SmallAdvancedDisassemblyComputer" };

        private List<IMySlimBlock> _allBlocks;

        public ConcurrentDictionary<MyObjectBuilderType, List<IMySlimBlock>> _blocksByType { get; private set; }
        public ConcurrentDictionary<UniqueEntityId, List<IMySlimBlock>> _blocksById { get; private set; }

        private ConcurrentDictionary<long, ThermalSourceBlock> _thermalSources = new ConcurrentDictionary<long, ThermalSourceBlock>();
        private ConcurrentDictionary<long, ThermalOutputBlock> _thermalOutputs = new ConcurrentDictionary<long, ThermalOutputBlock>();
        
        private ConcurrentDictionary<long, long[]> _thermalConnections = new ConcurrentDictionary<long, long[]>();

        private List<IMySlimBlock> _notInitilizedCollectorsBlocks;
        private List<IMySlimBlock> _notInitilizedTreadmillBlocks;

        public PlanetEntity PlanetAtRange
        {
            get
            {
                return ExtendedSurvivalEntityManager.Instance.Planets.Values.OrderBy(x => Vector3D.Distance(Entity.PositionComp.GetPosition(), x.Entity.PositionComp.GetPosition())).FirstOrDefault();
            }
        }

        public IMySlimBlock[] UnderwaterCollectors
        {
            get
            {
                if (WaterModAPI.Registered && PlanetAtRange.HasWater() && _blocksByType.ContainsKey(typeof(MyObjectBuilder_Collector)))
                {
                    return _blocksByType[typeof(MyObjectBuilder_Collector)].Where(x=> x.FatBlock != null && WaterModAPI.IsUnderwater(x.FatBlock.GetPosition())).ToArray();
                }
                return new IMySlimBlock[] { };
            }
        }

        public IMySlimBlock[] OffwaterCollectors
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_Collector)))
                {
                    var underwater = UnderwaterCollectors;
                    return _blocksByType[typeof(MyObjectBuilder_Collector)].Where(x => !underwater.Any(y => y == x)).ToArray();
                }
                return new IMySlimBlock[] { };
            }
        }

        public List<IMySlimBlock> Collectors
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_Collector)))
                    return _blocksByType[typeof(MyObjectBuilder_Collector)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> NotInitilizedCollectors
        {
            get
            {
                return _notInitilizedCollectorsBlocks;
            }
        }

        public List<IMySlimBlock> NotInitilizedTreadmill
        {
            get
            {
                return _notInitilizedTreadmillBlocks;
            }
        }

        public List<IMySlimBlock> MotorSuspensions
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_MotorSuspension)))
                    return _blocksByType[typeof(MyObjectBuilder_MotorSuspension)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> LargeGatlingTurrets
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_LargeGatlingTurret)))
                    return _blocksByType[typeof(MyObjectBuilder_LargeGatlingTurret)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> LargeMissileTurrets
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_LargeMissileTurret)))
                    return _blocksByType[typeof(MyObjectBuilder_LargeMissileTurret)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> InteriorTurrets
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_InteriorTurret)))
                    return _blocksByType[typeof(MyObjectBuilder_InteriorTurret)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> SmallMissileLaunchers
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_SmallMissileLauncher)))
                    return _blocksByType[typeof(MyObjectBuilder_SmallMissileLauncher)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> SmallMissileLauncherReloads
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_SmallMissileLauncherReload)))
                    return _blocksByType[typeof(MyObjectBuilder_SmallMissileLauncherReload)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> SmallGatlingGuns
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_SmallGatlingGun)))
                    return _blocksByType[typeof(MyObjectBuilder_SmallGatlingGun)];
                return new List<IMySlimBlock>();
            }
        }

        public bool HasAnyGun
        {
            get
            {
                return SmallGatlingGuns.Any() || SmallMissileLauncherReloads.Any() || SmallMissileLaunchers.Any();
            }
        }

        public bool HasAnyTurret
        {
            get
            {
                return InteriorTurrets.Any() || LargeMissileTurrets.Any() || LargeGatlingTurrets.Any();
            }
        }

        public bool HasWeapon
        {
            get
            {
                return HasAnyGun || HasAnyTurret;
            }
        }

        public bool AnyWeaponIsFunctional
        {
            get
            {
                return HasWeapon && AllWeapons.Any(x => x.FatBlock?.IsFunctional ?? false);
            }
        }

        public IEnumerable<IMySlimBlock> AllTurrets
        {
            get
            {
                return InteriorTurrets.Concat(LargeMissileTurrets).Concat(LargeGatlingTurrets);
            }
        }

        public IEnumerable<IMySlimBlock> AllGuns
        {
            get
            {
                return SmallGatlingGuns.Concat(SmallMissileLauncherReloads).Concat(SmallMissileLaunchers);
            }
        }

        public IEnumerable<IMySlimBlock> AllWeapons
        {
            get
            {
                return AllGuns.Concat(AllTurrets);
            }
        }

        public List<IMySlimBlock> WaterSolidificators
        {
            get
            {
                try
                {
                    var type = typeof(MyObjectBuilder_OxygenGenerator);
                    var id = new UniqueEntityId(type, "WaterSolidificator");
                    var id2 = new UniqueEntityId(type, "LargeWaterSolidificator");
                    if (_blocksById.ContainsKey(id) || _blocksById.ContainsKey(id2))
                        return _blocksByType[type].Where(x => x.BlockDefinition.Id.SubtypeName == "WaterSolidificator" || x.BlockDefinition.Id.SubtypeName == "LargeWaterSolidificator").ToList();
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] WaterSolidificator : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> TurbinePowerOutputModules
        {
            get
            {
                try
                {
                    var id = new UniqueEntityId(typeof(MyObjectBuilder_UpgradeModule), "TurbinePowerOutputModule");
                    if (_blocksById.ContainsKey(id))
                        return _blocksById[id];
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] TurbinePowerOutputModule : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> EnhancedTurbinePowerOutputModules
        {
            get
            {
                try
                {
                    var id = new UniqueEntityId(typeof(MyObjectBuilder_UpgradeModule), "EnhancedTurbinePowerOutputModule");
                    if (_blocksById.ContainsKey(id))
                        return _blocksById[id];
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] EnhancedTurbinePowerOutputModule : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> EliteTurbinePowerOutputModules
        {
            get
            {
                try
                {
                    var id = new UniqueEntityId(typeof(MyObjectBuilder_UpgradeModule), "EliteTurbinePowerOutputModule");
                    if (_blocksById.ContainsKey(id))
                        return _blocksById[id];
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] EliteTurbinePowerOutputModule : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> WindTurbines
        {
            get
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_WindTurbine)))
                    return _blocksByType[typeof(MyObjectBuilder_WindTurbine)];
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> ThermalSources
        {
            get
            {
                try
                {
                    var id = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), "ThermalSource");
                    if (_blocksById.ContainsKey(id))
                        return _blocksById[id];
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] EliteTurbinePowerOutputModule : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public List<IMySlimBlock> ThermalOutputs
        {
            get
            {
                try
                {
                    var id = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), "ThermalOutput");
                    if (_blocksById.ContainsKey(id))
                        return _blocksById[id];
                }
                catch (KeyNotFoundException)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), "[Id] EliteTurbinePowerOutputModule : Not Found");
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
                }
                return new List<IMySlimBlock>();
            }
        }

        public bool NeedToRecreateWhells { get; set; } = false;
        public bool NeedTeleport { get; set; } = false;
        public Vector3D TargetTeleportPosition { get; set; }
        public MatrixD? TargetTeleport { get; set; }

        private List<IMySlimBlock> _woodBlocks;
        public bool HasWoodBlocks 
        { 
            get 
            {
                return !ExtendedSurvivalSettings.Instance.DinamicWoodGridEnabled && _woodBlocks.Any(); 
            } 
        }

        private List<IMySlimBlock> _stoneBlocks;
        public bool HasStoneBlocks 
        { 
            get 
            { 
                return !ExtendedSurvivalSettings.Instance.DinamicStoneGridEnabled && _stoneBlocks.Any(); 
            } 
        }

        private List<IMySlimBlock> _concreteBlocks;
        public bool HasConcreteBlocks
        { 
            get 
            {
                return !ExtendedSurvivalSettings.Instance.DinamicConcreteGridEnabled && _concreteBlocks.Any();
            } 
        }

        public bool HasBlocksToApplySkin
        { 
            get
            { 
                return _woodBlocks.Any() || _stoneBlocks.Any() || _concreteBlocks.Any(); 
            }
        }

        public bool HasSkinedBlocks 
        {
            get 
            { 
                return HasWoodBlocks || HasStoneBlocks || HasConcreteBlocks; 
            } 
        }

        public bool HasCollectors 
        { 
            get 
            { 
                return Collectors.Any(); 
            } 
        }

        public bool HasNotInitilizedCollectors 
        {
            get 
            { 
                return NotInitilizedCollectors.Any(); 
            } 
        }

        public bool HasNotInitilizedTreadmill
        {
            get
            { 
                return NotInitilizedTreadmill.Any(); 
            } 
        }

        public bool HasDisassemblyComputer 
        {
            get
            {
                var type = typeof(MyObjectBuilder_TerminalBlock);
                return _blocksByType.ContainsKey(type) && _blocksByType[type].Any(x => DISASSEMBLYCOMPUTER_SUBTYPES.Contains(x.BlockDefinition.Id.SubtypeName));
            } 
        }

        public bool HasAdvancedDisassemblyComputer
        {
            get
            {
                var type = typeof(MyObjectBuilder_TerminalBlock);
                return _blocksByType.ContainsKey(type) && _blocksByType[type].Any(x => ADVANCEDDISASSEMBLYCOMPUTER_SUBTYPES.Contains(x.BlockDefinition.Id.SubtypeName));
            }
        }

        public int AllBlocksCount
        {
            get
            {
                return _allBlocks.Count;
            }
        }

        public int WoodBlocksCount
        {
            get
            {
                return HasWoodBlocks ? _woodBlocks.Count : 0;
            }
        }

        public int StoneBlocksCount
        {
            get
            {
                return HasStoneBlocks ? _stoneBlocks.Count : 0;
            }
        }

        public int ConcreteBlocksCount
        {
            get
            {
                return HasConcreteBlocks ? _concreteBlocks.Count : 0;
            }
        }

        public int SkinedBlocksCount
        {
            get
            {
                return WoodBlocksCount + StoneBlocksCount + ConcreteBlocksCount;
            }
        }

        public long? OwnerId
        {
            get
            {
                return Entity.BigOwners.Any() ? (long?)Entity.BigOwners.FirstOrDefault() : null;
            }
        }

        public bool NeedToDecay
        {
            get
            {
                if (ExtendedSurvivalSettings.Instance.Decay.Enabled && OwnerId.HasValue)
                {
                    var steamId = MyAPIGateway.Players.TryGetSteamId(OwnerId.Value);
                    return ExtendedSurvivalStorage.Instance.Decay.Players.Any(x => x.SteamId == steamId && x.CanDecay);
                }
                return false;
            }
        }

        public GridEntity(IMyCubeGrid entity) : base(entity)
        {
            if (Closed)
                return;
            LoadBlocks();
            ApllySkins();
            CheckThermalConnections();
            Entity.OnBlockAdded += Entity_OnBlockAdded;
            Entity.OnBlockRemoved += Entity_OnBlockRemoved;
            Entity.OnIsStaticChanged += Entity_OnIsStaticChanged;
            CheckGridStartIsStatic();
        }

        public void ReloadThermalBlocks()
        {
            _thermalSources.Clear();
            var allThermalSources = ThermalSources;
            foreach (var item in allThermalSources)
            {
                var sourceLogib = GetGameLogic(item, typeof(ThermalSourceBlock).Name);
                if (sourceLogib != null)
                    RegisterThermalSource(sourceLogib as ThermalSourceBlock);
            }
            _thermalOutputs.Clear();
            var allThermalOutputs = ThermalOutputs;
            foreach (var item in allThermalOutputs)
            {
                var outputLogib = GetGameLogic(item, typeof(ThermalOutputBlock).Name);
                if (outputLogib != null)
                    RegisterThermalOutput(outputLogib as ThermalOutputBlock);
            }
        }

        public void ReloadGridBlocks()
        {
            LoadBlocks(false);
            ReloadThermalBlocks();
            CheckThermalConnections();
        }

        private MyEntityComponentBase GetGameLogic(IMySlimBlock block, string name)
        {
            var blockLogic = block.FatBlock?.GameLogic;
            if (blockLogic != null)
            {
                var compositeLogic = blockLogic as MyCompositeGameLogicComponent;
                if (compositeLogic != null)
                {
                    blockLogic = compositeLogic.GetComponents().FirstOrDefault(x => x.GetType().Name.Contains(name));
                }
            }
            return blockLogic;
        }

        private void CheckGridStartIsStatic()
        {
            if (!Entity.IsStatic && SkinedBlocksCount == 1 && AllBlocksCount == 1)
                Entity.Close();
        }

        public void ApllySkins()
        {
            CheckSkinAtBlocks(_woodBlocks, SkinHelper.WOOD_SKIN);
            CheckSkinAtBlocks(_stoneBlocks, SkinHelper.CONCRETE_SKIN);
            CheckSkinAtBlocks(_concreteBlocks, SkinHelper.CONCRETE_SKIN);
        }

        private void DisableBlocksThatCanRevertDecay()
        {
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_EventControllerBlock)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_EventControllerBlock)])
                {
                    var fatBlock = block.FatBlock as IMyEventControllerBlock;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_MyProgrammableBlock)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_MyProgrammableBlock)])
                {
                    var fatBlock = block.FatBlock as IMyProgrammableBlock;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_TimerBlock)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_TimerBlock)])
                {
                    var fatBlock = block.FatBlock as IMyTimerBlock;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_SensorBlock)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_SensorBlock)])
                {
                    var fatBlock = block.FatBlock as IMySensorBlock;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_ShipWelder)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_ShipWelder)])
                {
                    var fatBlock = block.FatBlock as IMyShipWelder;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
            if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_OreDetector)))
                foreach (var block in _blocksByType[typeof(MyObjectBuilder_OreDetector)])
                {
                    var fatBlock = block.FatBlock as IMyOreDetector;
                    if (fatBlock != null)
                        fatBlock.Enabled = false;
                }
        }

        public void Decay()
        {
            if (NeedToDecay)
            {
                if (!ExtendedSurvivalSettings.Instance.Decay.IgnoreGridProtection)
                {
                    if (ExtendedSurvivalCoreSession.Static.IsPveZone(Entity.GetPosition()))
                        return;
                }
                DisableBlocksThatCanRevertDecay();
                var totalBlocks = _allBlocks.Count;
                var isAllRustSkin = _allBlocks.All(x => DecaySystemController.IsRustSkin(x.SkinSubtypeId));
                var isAllHeavyRustSkin = _allBlocks.All(x => x.SkinSubtypeId == DecaySystemController.HeavyRustHash);
                var neededBlocks = (int)(totalBlocks * ExtendedSurvivalSettings.Instance.Decay.BlockPercentCycle);
                if (neededBlocks == 0)
                    neededBlocks = totalBlocks;
                var newNeed = (int)(neededBlocks * ExtendedSurvivalSettings.Instance.Decay.NewBlocksPercent);
                var armorNeed = (int)(neededBlocks * ExtendedSurvivalSettings.Instance.Decay.ArmorPercentBlock);
                var gettedBlocks = new List<Vector3I>();
                var ignoreNewForArmors = false;
                while (neededBlocks > 0)
                {
                    IMySlimBlock target = null;
                    if (armorNeed > 0)
                    {
                        if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_CubeBlock)))
                        {
                            target = _blocksByType[typeof(MyObjectBuilder_CubeBlock)].Where(x =>
                                (
                                    newNeed == 0 || ignoreNewForArmors ||
                                    (
                                        (
                                            (!isAllRustSkin && !isAllHeavyRustSkin && !DecaySystemController.IsRustSkin(x.SkinSubtypeId)) ||
                                            (isAllRustSkin && !isAllHeavyRustSkin && x.SkinSubtypeId != DecaySystemController.HeavyRustHash)
                                        )
                                    )
                                ) &&
                                !gettedBlocks.Contains(x.Position)
                            ).OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                        }
                    }
                    else
                    {
                        if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_ShipWelder)))
                        {
                            target = _blocksByType[typeof(MyObjectBuilder_ShipWelder)].Where(x =>
                                (
                                    newNeed == 0 || 
                                    (
                                        (
                                            (!isAllRustSkin && !isAllHeavyRustSkin && !DecaySystemController.IsRustSkin(x.SkinSubtypeId)) ||
                                            (isAllRustSkin && !isAllHeavyRustSkin && x.SkinSubtypeId != DecaySystemController.HeavyRustHash)
                                        )
                                    )
                                ) &&
                                !gettedBlocks.Contains(x.Position)
                            ).OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                        }
                        if (target == null)
                        {
                            target = _allBlocks.Where(x =>
                                    (
                                        newNeed == 0 ||
                                        (
                                            (
                                                (!isAllRustSkin && !isAllHeavyRustSkin && !DecaySystemController.IsRustSkin(x.SkinSubtypeId)) ||
                                                (isAllRustSkin && !isAllHeavyRustSkin && x.SkinSubtypeId != DecaySystemController.HeavyRustHash)
                                            )
                                        )
                                    ) &&
                                    !gettedBlocks.Contains(x.Position)
                                ).OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                        }
                    }
                    if (target == null)
                    {
                        if (newNeed > 0)
                        {
                            if (armorNeed > 0 && !ignoreNewForArmors)
                            {
                                ignoreNewForArmors = true;
                            }
                            else
                            {
                                newNeed = 0;
                            }
                        }
                        else if (armorNeed > 0)
                        {
                            armorNeed = 0;
                        }
                        else
                        {
                            neededBlocks = 0;
                        }
                    }
                    else
                    {
                        gettedBlocks.Add(target.Position);
                        ApplyDecay(target);
                        if (newNeed > 0)
                            newNeed--;
                        if (armorNeed > 0)
                            armorNeed--;
                        neededBlocks--;
                    }
                }
            }
        }

        private void ApplyDecay(IMySlimBlock block)
        {
            if (block != null)
            {
                DecaySystemController.MarkBlockToRust(block, Entity as MyCubeGrid);
            }
        }

        private void CheckSkinAtBlocks(List<IMySlimBlock> blocks, MyStringHash skin)
        {
            if (blocks.Any(x => x.SkinSubtypeId != skin))
                ReplaceSkin(skin, blocks.Where(x => x.SkinSubtypeId != skin).ToArray());
        }

        private void Entity_OnIsStaticChanged(IMyCubeGrid entity, bool isStatic)
        {
            if (!isStatic && HasSkinedBlocks)
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"OnIsStaticChanged to {isStatic} and HasSkinedBlocks = {HasSkinedBlocks}");
                Entity.IsStatic = true;
            }
        }

        private void Entity_OnBlockRemoved(IMySlimBlock obj)
        {
            /* SKIN GROUPS */
            if (_woodBlocks.Contains(obj))
                _woodBlocks.Remove(obj);
            else if (_stoneBlocks.Contains(obj))
                _stoneBlocks.Remove(obj);
            else if (_concreteBlocks.Contains(obj))
                _concreteBlocks.Remove(obj);
            /* GROUPS BLOCKS */
            var uniqueId = new UniqueEntityId(obj.BlockDefinition.Id);
            if (_blocksById.ContainsKey(uniqueId) && _blocksById[uniqueId].Contains(obj))
            {
                _blocksById[uniqueId].Remove(obj);
            }
            if (_blocksByType.ContainsKey(uniqueId.typeId) && _blocksByType[uniqueId.typeId].Contains(obj))
            {
                _blocksByType[uniqueId.typeId].Remove(obj);
            }
            /* NOT INITIALIZED */
            if (_notInitilizedCollectorsBlocks.Contains(obj))
                _notInitilizedCollectorsBlocks.Remove(obj);
            else if (_notInitilizedTreadmillBlocks.Contains(obj))
                _notInitilizedTreadmillBlocks.Remove(obj);
            /* ALL BLOCKS */
            if (_allBlocks.Contains(obj))
                _allBlocks.Remove(obj);
            /* OTHER CHECKS */
            if (obj.FatBlock != null)
            {
                RemoveThermalSource(obj.FatBlock.EntityId);
                RemoveThermalOutput(obj.FatBlock.EntityId);
            }
            CheckThermalConnections();
        }

        private void Entity_OnBlockAdded(IMySlimBlock obj)
        {
            /* SKIN GROUPS */
            if (obj.BlockDefinition.Id.SubtypeId.ToString().Contains("WoodPlank"))
            {
                if (!ExtendedSurvivalSettings.Instance.DinamicWoodGridEnabled && !CheckAddedBlock(obj))
                    return;
                _woodBlocks.Add(obj);
                ReplaceSkin(SkinHelper.WOOD_SKIN, obj);
            }
            else if (obj.BlockDefinition.Id.SubtypeId.ToString().Contains("StoneBrick"))
            {
                if (!ExtendedSurvivalSettings.Instance.DinamicStoneGridEnabled && !CheckAddedBlock(obj))
                    return;
                _stoneBlocks.Add(obj);
                ReplaceSkin(SkinHelper.CONCRETE_SKIN, obj);
            }
            else if (obj.BlockDefinition.Id.SubtypeId.ToString().Contains("Concrete"))
            {
                if (!ExtendedSurvivalSettings.Instance.DinamicConcreteGridEnabled && !CheckAddedBlock(obj))
                    return;
                _concreteBlocks.Add(obj);
                ReplaceSkin(SkinHelper.CONCRETE_SKIN, obj);
            }
            /* GROUPS BLOCKS */
            var uniqueId = new UniqueEntityId(obj.BlockDefinition.Id);
            if (!_blocksById.ContainsKey(uniqueId))
                _blocksById[uniqueId] = new List<IMySlimBlock>();
            _blocksById[uniqueId].Add(obj);
            if (!_blocksByType.ContainsKey(uniqueId.typeId))
                _blocksByType[uniqueId.typeId] = new List<IMySlimBlock>();
            _blocksByType[uniqueId.typeId].Add(obj);
            /* NOT INITIALIZED */
            if (uniqueId.typeId == typeof(MyObjectBuilder_Collector))
                _notInitilizedCollectorsBlocks.Add(obj);
            if (uniqueId.typeId == typeof(MyObjectBuilder_Cockpit) && TREADMILL_SUBTYPES.Contains(uniqueId.subtypeId.String))
                _notInitilizedTreadmillBlocks.Add(obj);         
            /* ALL BLOCKS */
            _allBlocks.Add(obj);
            CheckThermalConnections();
        }

        private bool CheckAddedBlock(IMySlimBlock obj)
        {
            if (!Entity.IsStatic)
            {
                obj.OnDestroy();
                Entity.RemoveBlock(obj, false);
                return false;
            }
            return true;
        }

        private static void ReplaceSkin(MyStringHash skin, params IMySlimBlock[] blocks)
        {
            foreach (var slimblock in blocks)
            {
                var grid = (slimblock.CubeGrid as MyCubeGrid);
                grid.ChangeColorAndSkin(grid.GetCubeBlock(slimblock.Position), null, skin);
            }
        }

        private void LoadBlocks(bool start = true)
        {
            _allBlocks = GetBlocks(false);
            _woodBlocks = _allBlocks.Where(x => x.BlockDefinition.Id.SubtypeId.ToString().Contains("WoodPlank")).ToList();
            _stoneBlocks = _allBlocks.Where(x => x.BlockDefinition.Id.SubtypeId.ToString().Contains("StoneBrick")).ToList();
            _concreteBlocks = _allBlocks.Where(x => x.BlockDefinition.Id.SubtypeId.ToString().Contains("Concrete")).ToList();
            _blocksByType = new ConcurrentDictionary<MyObjectBuilderType, List<IMySlimBlock>>();
            var blocksByType = _allBlocks.GroupBy(x => x.BlockDefinition.Id.TypeId).ToDictionary((x) => { return x.Key; });
            foreach (var key in blocksByType.Keys)
            {
                _blocksByType[key] = blocksByType[key].ToList();
                
            }
            _blocksById = new ConcurrentDictionary<UniqueEntityId, List<IMySlimBlock>>();
            var blocksById = _allBlocks.GroupBy(x => new UniqueEntityId(x.BlockDefinition.Id)).ToDictionary((x) => { return x.Key; });
            foreach (var key in blocksById.Keys)
            {
                _blocksById[key] = blocksById[key].ToList();
            }
            if (start)
            {
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_Collector)))
                {
                    _notInitilizedCollectorsBlocks = _blocksByType[typeof(MyObjectBuilder_Collector)].ToList();
                }
                else
                {
                    _notInitilizedCollectorsBlocks = new List<IMySlimBlock>();
                }
                if (_blocksByType.ContainsKey(typeof(MyObjectBuilder_Cockpit)))
                {
                    _notInitilizedTreadmillBlocks = _blocksByType[typeof(MyObjectBuilder_Cockpit)].Where(x => TREADMILL_SUBTYPES.Contains(x.BlockDefinition.Id.SubtypeName)).ToList();
                }
                else
                {
                    _notInitilizedTreadmillBlocks = new List<IMySlimBlock>();
                }
            }
        }

        private List<IMySlimBlock> GetBlocks(bool useSubGrids)
        {
            var result = new List<IMySlimBlock>();
            if (useSubGrids)
            {
                var gridGroup = new List<IMyCubeGrid>();
                MyAPIGateway.GridGroups.GetGroup(Entity, GridLinkTypeEnum.Logical, gridGroup);
                foreach (var grid in gridGroup)
                {
                    grid.GetBlocks(result);
                }
            }
            else
            {
                Entity.GetBlocks(result);
            }
            return result;
        }

        public void RegisterThermalSource(ThermalSourceBlock thermalSource)
        {
            if (!_thermalSources.ContainsKey(thermalSource.CurrentEntity.EntityId))
            {
                _thermalSources[thermalSource.CurrentEntity.EntityId] = thermalSource;
                CheckThermalConnections();
            }
        }

        protected void RemoveThermalSource(long entityId)
        {
            if (_thermalSources.ContainsKey(entityId))
                _thermalSources.Remove(entityId);
        }

        public void RegisterThermalOutput(ThermalOutputBlock thermalOutput)
        {
            if (!_thermalOutputs.ContainsKey(thermalOutput.CurrentEntity.EntityId))
            {
                _thermalOutputs[thermalOutput.CurrentEntity.EntityId] = thermalOutput;
                CheckThermalConnections();
            }
        }

        public long[] GetThermalOutputConnections(long entityId)
        {
            if (_thermalConnections.ContainsKey(entityId))
                return _thermalConnections[entityId];
            return new long[] { };
        }

        public long[] GetThermalSourceConnections(long entityId)
        {
            return _thermalConnections.Where(x => x.Value.Any(y => y == entityId)).Select(x => x.Key).ToArray();
        }

        public float GetMaxThermalOutput(long entityId)
        {
            var retorno = 0f;
            var outputconnections = GetThermalOutputConnections(entityId);
            if (outputconnections.Any())
            {
                foreach (var item in outputconnections)
                {
                    if (_thermalSources.ContainsKey(item))
                    {
                        var totalSubConnections = Math.Max(GetThermalSourceConnections(item).Length, 1);
                        retorno += _thermalSources[item].FinalProduction / totalSubConnections;
                    }                    
                }
            }
            return retorno;
        }

        public void CheckThermalConnections()
        {
            var allOutputs = ThermalOutputs;
            if (allOutputs.Count > 0)
            {
                var allSources = ThermalSources;
                foreach (var output in allOutputs)
                {
                    var connections = new List<long>();
                    var conveyorOutput = (output.FatBlock as IMyCargoContainer);
                    foreach (var source in allSources)
                    {
                        var conveyorSource = (source.FatBlock as IMyCargoContainer);
                        if (conveyorOutput.GetInventory().CanTransferItemTo(conveyorSource.GetInventory(), OreConstants.ICE_ID.DefinitionId))
                            connections.Add(source.FatBlock.EntityId);
                    }
                    _thermalConnections[output.FatBlock.EntityId] = connections.ToArray();
                }
            }
        }

        protected void RemoveThermalOutput(long entityId)
        {
            if (_thermalOutputs.ContainsKey(entityId))
                _thermalOutputs.Remove(entityId);
        }

    }

}