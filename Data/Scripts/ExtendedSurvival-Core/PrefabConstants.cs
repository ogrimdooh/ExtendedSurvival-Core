using System.Collections.Generic;
using System.Linq;
using VRage.Utils;
using VRageMath;
using System.Collections.Concurrent;
using VRage.ObjectBuilders;
using Sandbox.Common.ObjectBuilders;
using VRage.Game;
using System;
using Sandbox.Definitions;

namespace ExtendedSurvival.Core
{
    public static class PrefabConstants
    {

        public class PrefabInfo
        {

            public float ThreatLevel { get; set; }
            public Vector2 PowerOutput { get; set; }
            public int TotalPowerBlocks { get; set; }
            public int TotalTurretsBlocks { get; set; }
            public int TotalGunBlocks { get; set; }
            public int TotalShieldBlocks { get; set; }
            public int TotalThrustersBlocks { get; set; }
            public int TotalCargoBlocks { get; set; }
            public int TotalProductionBlocks { get; set; }
            public int TotalJumpDrivesBlocks { get; set; }
            public int TotalGravityBlocks { get; set; }
            public int TotalMecanicalBlocks { get; set; }
            public int TotalToolsBlocks { get; set; }
            public int TotalMedicalBlocks { get; set; }
            public int TotalNanoBotsBlocks { get; set; }
            public int TotalAntennasBlocks { get; set; }
            public int TotalBeaconsBlocks { get; set; }
            public int TotalControllersBlocks { get; set; }
            public int BlocksCount { get; set; }
            public int PCU { get; set; }
            public float MaxRange { get; set; }
            public float MaxBulletTragetory { get; set; }
            public bool IsStatic { get; set; }
            public bool LargeGrid { get; set; }

        }

        private static ConcurrentDictionary<string, PrefabInfo> PREFAB_INFO = new ConcurrentDictionary<string, PrefabInfo>();

        public static PrefabInfo GetPrefabInfo(MyPrefabDefinition prefab)
        {
            var key = prefab.Id.SubtypeName;
            if (!PREFAB_INFO.ContainsKey(key))
                PREFAB_INFO[key] = DoCalcPrefabInfo(prefab);
            return PREFAB_INFO[key];
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetBlocksByType(MyObjectBuilder_CubeGrid grid, MyObjectBuilderType type)
        {
            return grid.CubeBlocks.Where(x => x.TypeId == type);
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetAntennas(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_RadioAntenna)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_LaserAntenna))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetBeacons(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Beacon));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetContainers(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_CargoContainer));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetControllers(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Cockpit)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_RemoteControl))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetGravity(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_GravityGenerator));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetGuns(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_SmallGatlingGun)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_SmallMissileLauncher))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_SmallMissileLauncherReload))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetGyros(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Gyro));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetJumpDrives(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_JumpDrive));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetMedical(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_MedicalRoom)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_SurvivalKit))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetParachutes(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Parachute));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetProduction(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Assembler)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_OxygenGenerator))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetProjectors(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Projector));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetPower(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Reactor)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_BatteryBlock))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_HydrogenEngine))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_SolarPanel))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_WindTurbine))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetSeats(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Cockpit));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetStores(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_VendingMachine));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetThrusters(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Thrust));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetTools(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Drill)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_ShipWelder))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_ShipGrinder))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetTurrets(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_InteriorTurret)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_LargeGatlingTurret))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_LargeMissileTurret))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetTurretControllers(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_TurretControlBlock));
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetMechanical(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_MotorAdvancedRotor)).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_MotorRotor))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_PistonBase))
                ).Concat(
                    GetBlocksByType(grid, typeof(MyObjectBuilder_MotorAdvancedStator))
                );
        }

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetNanoBots(MyObjectBuilder_CubeGrid grid)
        {
            var validSubTypes = new string[] {
                    "SELtdSmallNanobotBuildAndRepairSystem",
                    "SELtdLargeNanobotBuildAndRepairSystem"
                };
            return GetBlocksByType(grid, typeof(MyObjectBuilder_ShipWelder)).Where(x => validSubTypes.Contains(x.SubtypeName));
        }

        public const string LargeShipSmallShieldGeneratorBase = "LargeShipSmallShieldGeneratorBase";
        public const string LargeShipLargeShieldGeneratorBase = "LargeShipLargeShieldGeneratorBase";
        public const string SmallShipSmallShieldGeneratorBase = "SmallShipSmallShieldGeneratorBase";
        public const string SmallShipMicroShieldGeneratorBase = "SmallShipMicroShieldGeneratorBase";

        public static readonly string[] ShieldsSubTypes = new string[]
        {
            LargeShipSmallShieldGeneratorBase,
            LargeShipLargeShieldGeneratorBase,
            SmallShipSmallShieldGeneratorBase,
            SmallShipMicroShieldGeneratorBase
        };

        private static IEnumerable<MyObjectBuilder_CubeBlock> GetShields(MyObjectBuilder_CubeGrid grid)
        {
            return GetBlocksByType(grid, typeof(MyObjectBuilder_Refinery)).Where(x => ShieldsSubTypes.Contains(x.SubtypeName));
        }

        private static float GetTargetValueFromBlockList(IEnumerable<MyObjectBuilder_CubeBlock> blockList, float threatValue, float modMultiplier = 2, bool scanInventory = false)
        {

            float result = 0;

            foreach (var block in blockList)
            {

                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(new MyDefinitionId(block.TypeId, block.SubtypeId));

                if (def == null || block.IntegrityPercent < def.CriticalIntegrityRatio)
                    continue;

                var value = threatValue * (!def.Context.IsBaseGame ? modMultiplier : 1);

                if (scanInventory && block.ComponentContainer?.Components != null)
                {

                    var hasInventory = block.ComponentContainer.Components.Any(x => x.TypeId == "MyInventoryBase");
                    if (hasInventory)
                    {

                        var inventory = block.ComponentContainer.Components.FirstOrDefault(x => x.TypeId == "MyInventoryBase").Component as MyObjectBuilder_Inventory;

                        if (inventory?.Items != null && inventory.Items.Any())
                        {

                            var inventoryModifier = (inventory.Items.Count / 100) + 1;

                            if (inventoryModifier > 1)
                                value *= inventoryModifier;

                        }
                    }

                }

                result += value;

            }

            return result;

        }

        private static Vector2 GridPowerOutput(IEnumerable<MyObjectBuilder_CubeBlock> blockList)
        {

            var result = Vector2.Zero;

            foreach (var block in blockList)
            {

                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(new MyDefinitionId(block.TypeId, block.SubtypeId)) as MyPowerProducerDefinition;

                if (def == null || block.IntegrityPercent < def.CriticalIntegrityRatio)
                    continue;
                
                result.X += 0.1f;
                result.Y += def.MaxPowerOutput;

            }

            return result;

        }

        private static int CalcPCU(IEnumerable<MyObjectBuilder_CubeBlock> blockList)
        {
            int pcu = 0;
            foreach (var block in blockList)
            {

                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(new MyDefinitionId(block.TypeId, block.SubtypeId));

                if (def == null)
                    continue;

                pcu += def.PCU;

            }
            return pcu;
        }

        private static float GetMaxRange(IEnumerable<MyObjectBuilder_CubeBlock> blockList, float min = 0)
        {
            float mRange = min;
            foreach (var block in blockList)
            {

                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(new MyDefinitionId(block.TypeId, block.SubtypeId)) as MyLargeTurretBaseDefinition;

                if (def == null)
                    continue;

                if (def.MaxRangeMeters > mRange)
                    mRange = def.MaxRangeMeters;

            }
            return mRange;
        }

        private static float GetMaxBulletTragetory(IEnumerable<MyObjectBuilder_CubeBlock> blockList)
        {
            float mTragetory = 0;
            foreach (var block in blockList)
            {

                var def = MyDefinitionManager.Static.GetCubeBlockDefinition(new MyDefinitionId(block.TypeId, block.SubtypeId)) as MyWeaponBlockDefinition;

                if (def == null)
                    continue;

                var wDef = MyDefinitionManager.Static.GetWeaponDefinition(def.WeaponDefinitionId);

                if (wDef == null)
                    continue;

                foreach (var ammoId in wDef.AmmoMagazinesId)
                {

                    var amDef = MyDefinitionManager.Static.GetAmmoMagazineDefinition(ammoId);

                    if (amDef == null)
                        continue;

                    var aDef = MyDefinitionManager.Static.GetAmmoDefinition(amDef.AmmoDefinitionId);

                    if (aDef == null)
                        continue;

                    if (aDef.MaxTrajectory > mTragetory)
                        mTragetory = aDef.MaxTrajectory;

                }

            }
            return mTragetory;
        }

        private static PrefabInfo DoCalcPrefabInfo(MyPrefabDefinition prefab)
        {
            PrefabInfo info = new PrefabInfo();

            try
            {
                if (prefab?.CubeGrids == null || !prefab.CubeGrids.Any())
                    return info;

                foreach (var grid in prefab.CubeGrids)
                {

                    float threatLevel = 0;

                    var antennasBlocks = GetAntennas(grid);
                    var beaconsBlocks = GetBeacons(grid);
                    var containersBlocks = GetContainers(grid);
                    var controllersBlocks = GetControllers(grid);
                    var gravityBlocks = GetGravity(grid);
                    var gunsBlocks = GetGuns(grid);
                    var jumpDrivesBlocks = GetJumpDrives(grid);
                    var mechanicalBlocks = GetMechanical(grid);
                    var medicalBlocks = GetMedical(grid);
                    var nanoBotsBlocks = GetNanoBots(grid);
                    var productionBlocks = GetProduction(grid);
                    var powerBlocks = GetPower(grid);
                    var shieldsBlocks = GetShields(grid);
                    var thrustersBlocks = GetThrusters(grid);
                    var toolsBlocks = GetTools(grid);
                    var turretsBlocks = GetTurrets(grid);
                    threatLevel += GetTargetValueFromBlockList(antennasBlocks, 4, 2);
                    threatLevel += GetTargetValueFromBlockList(beaconsBlocks, 3, 2);
                    threatLevel += GetTargetValueFromBlockList(containersBlocks, 0.5f, 2, true);
                    threatLevel += GetTargetValueFromBlockList(controllersBlocks, 0.5f, 2);
                    threatLevel += GetTargetValueFromBlockList(gravityBlocks, 2, 4, true);
                    threatLevel += GetTargetValueFromBlockList(gunsBlocks, 5, 4, true);
                    threatLevel += GetTargetValueFromBlockList(jumpDrivesBlocks, 10, 2);
                    threatLevel += GetTargetValueFromBlockList(mechanicalBlocks, 1, 2);
                    threatLevel += GetTargetValueFromBlockList(medicalBlocks, 10, 2);
                    threatLevel += GetTargetValueFromBlockList(nanoBotsBlocks, 15, 2);
                    threatLevel += GetTargetValueFromBlockList(productionBlocks, 2, 2, true);
                    threatLevel += GetTargetValueFromBlockList(powerBlocks, 0.5f, 2, true);
                    threatLevel += GetTargetValueFromBlockList(shieldsBlocks, 15, 2);
                    threatLevel += GetTargetValueFromBlockList(thrustersBlocks, 1, 2);
                    threatLevel += GetTargetValueFromBlockList(toolsBlocks, 2, 2, true);
                    threatLevel += GetTargetValueFromBlockList(turretsBlocks, 7.5f, 4, true);
                    info.TotalAntennasBlocks += antennasBlocks.Count();
                    info.TotalBeaconsBlocks += beaconsBlocks.Count();
                    info.TotalCargoBlocks += containersBlocks.Count();
                    info.TotalControllersBlocks += controllersBlocks.Count();
                    info.TotalGravityBlocks += gravityBlocks.Count();
                    info.TotalGunBlocks += gunsBlocks.Count();
                    info.TotalJumpDrivesBlocks += jumpDrivesBlocks.Count();
                    info.TotalMecanicalBlocks += mechanicalBlocks.Count();
                    info.TotalMedicalBlocks += medicalBlocks.Count();
                    info.TotalNanoBotsBlocks += nanoBotsBlocks.Count();
                    info.TotalProductionBlocks += productionBlocks.Count();
                    info.TotalPowerBlocks += powerBlocks.Count();
                    info.TotalShieldBlocks += shieldsBlocks.Count();
                    info.TotalThrustersBlocks += thrustersBlocks.Count();
                    info.TotalToolsBlocks += toolsBlocks.Count();
                    info.TotalTurretsBlocks += turretsBlocks.Count();
                    info.BlocksCount += grid.CubeBlocks.Count;
                    info.PCU += CalcPCU(grid.CubeBlocks);
                    if (gunsBlocks.Any() && info.MaxRange == 0)
                        info.MaxRange = 1000;
                    info.MaxRange = GetMaxRange(turretsBlocks, info.MaxRange);
                    info.MaxBulletTragetory = GetMaxBulletTragetory(turretsBlocks.Concat(gunsBlocks));

                    //Factor Power
                    var powerOutput = GridPowerOutput(powerBlocks);
                    threatLevel += powerOutput.X > 0 ? powerOutput.Y / 10 : 0;

                    //Factor Total Block Count
                    threatLevel += grid.CubeBlocks.Count / 100;

                    var min = grid.CubeBlocks.Min(x => x.Min.X + x.Min.Y + x.Min.Z);
                    var max = grid.CubeBlocks.Max(x => x.Min.X + x.Min.Y + x.Min.Z);

                    //Factor Grid Box Size
                    threatLevel += (float)Math.Abs(min - max) / 4f;

                    //Factor Static/Dynamic
                    if (grid.IsStatic)
                    {
                        info.IsStatic = true;
                        threatLevel *= 0.75f;
                    }

                    //Factor Cube Size
                    if (grid.GridSizeEnum == MyCubeSize.Large)
                    {
                        info.LargeGrid = true;
                        threatLevel *= 2.5f;
                    }
                    else
                        threatLevel *= 0.5f;

                    threatLevel *= 0.70f;

                    info.ThreatLevel += threatLevel;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(PrefabConstants), ex);
            }

            return info;
        }

    }

}