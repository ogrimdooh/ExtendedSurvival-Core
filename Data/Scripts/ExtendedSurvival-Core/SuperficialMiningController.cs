﻿using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.ModAPI;
using VRage.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;
using Sandbox.Game;
using Sandbox.ModAPI;
using Sandbox.Definitions;

namespace ExtendedSurvival.Core
{
    public static class SuperficialMiningController
    {

        private static readonly Random rnd = new Random();

        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT = 1.0f;
        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT_SHIPDRILL = 2.5f;
        private static readonly float MAX_DROP_COUNT = 1;
        private static readonly float MAX_DROP_TRY_COUNT = 3;

        private static SuperficialMiningSetting AsteroidMiningSetting = new SuperficialMiningSetting()
        {
            Enabled = true,
            Drops = new List<SuperficialMiningDropSetting>()
            {
                new SuperficialMiningDropSetting()
                {
                    ItemId = OreConstants.ASTEROIDSOIL_ID.DefinitionId,
                    AlowFrac = true,
                    Ammount = new DocumentedVector2(5, 25),
                    Chance = 10,
                    ValidSubType = new List<SuperficialMiningDropValidSubTypeSetting>() 
                    {
                        new SuperficialMiningDropValidSubTypeSetting() { Id = "Stone" }
                    }
                }
            }
        };

        private static void DoExecuteSettings(SuperficialMiningSetting setting, string subtypeId, Dictionary<UniqueEntityId, float> lootAmmount)
        {
            var validDrops = setting.Drops.Where(x => x.ValidSubType.Any(y => y.Id == subtypeId)).ToArray();
            if (validDrops.Any())
            {
                for (int c = 0; c < MAX_DROP_TRY_COUNT; c++)
                {
                    var i = rnd.Next(0, validDrops.Length - 1);
                    if (rnd.Next(1, 101) <= validDrops[i].Chance)
                    {
                        var value = validDrops[i].Ammount.ToVector2().GetRandom();
                        if (!validDrops[i].AlowFrac)
                            value = (int)value;
                        try
                        {
                            var def = MyDefinitionManager.Static.GetPhysicalItemDefinition(validDrops[i].ItemId);
                            if (def != null)
                            {
                                lootAmmount.Add(new UniqueEntityId(validDrops[i].ItemId), value);
                            }
                        }
                        catch (Exception ex)
                        {
                            ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SuperficialMiningController), ex);
                        }
                    }
                    if (lootAmmount.Count >= MAX_DROP_COUNT)
                        break;
                }
            }
        }

        private static Dictionary<UniqueEntityId, float> DoInternalDrill(string typeId, string subtypeId, Vector3D pos, float maxDistance)
        {
            var lootAmmount = new Dictionary<UniqueEntityId, float>();
            if (typeId.Contains("Ore"))
            {
                var platAtRange = ExtendedSurvivalEntityManager.GetPlanetAtRange(pos);
                if (platAtRange != null && platAtRange.Setting != null && platAtRange.Setting.SuperficialMining.Enabled)
                {
                    var planetId = platAtRange.Entity.Generator.EnvironmentDefinition.Id.SubtypeName;
                    var surfaceRange = platAtRange.Entity.GetClosestSurfacePointGlobal(pos);
                    if (Vector3.Distance(pos, surfaceRange) < maxDistance)
                    {
                        DoExecuteSettings(platAtRange.Setting.SuperficialMining, subtypeId, lootAmmount);
                    }
                }
                else
                {
                    var sphere = new BoundingSphereD(pos, maxDistance);
                    var voxels = new List<MyVoxelBase>();
                    MyGamePruningStructure.GetAllVoxelMapsInSphere(ref sphere, voxels);
                    if (voxels.Any())
                    {
                        DoExecuteSettings(AsteroidMiningSetting, subtypeId, lootAmmount);
                    }
                }
            }
            return lootAmmount;
        }

        public static void InitShipDrillCollec()
        {
            // Add event to ship drill
            MyVisualScriptLogicProvider.ShipDrillCollected += (string entityName, long entityId, string gridName, long gridId, string typeId, string subtypeId, float amount) =>
            {
                try
                {
                    var entity = MyAPIGateway.Entities.GetEntityById(entityId);
                    Vector3D pos = entity.GetPosition();
                    var lootAmmount = DoInternalDrill(typeId, subtypeId, pos, MAX_DISTANCE_TO_GENERATE_LOOT_SHIPDRILL);
                    if (lootAmmount.Any())
                    {
                        var inventory = entity.GetInventory();
                        if (inventory != null)
                        {
                            var drill = entity as IMyShipDrill;
                            var grid = drill.CubeGrid as MyCubeGrid;
                            foreach (var i in lootAmmount.Keys)
                            {
                                float amountfinal = (int)lootAmmount[i];
                                if (i.typeId == typeof(MyObjectBuilder_Ore))
                                {
                                    inventory.AddMaxItems(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i));
                                }
                                else
                                {
                                    var targets = grid.Inventories.Where(x => 
                                        x.GetInventory().CanItemsBeAdded((MyFixedPoint)amountfinal, i.DefinitionId) &&
                                        inventory.CanTransferItemTo(x.GetInventory(), i.DefinitionId)
                                    ).ToArray();
                                    if (targets.Any())
                                    {
                                        foreach (var target in targets)
                                        {
                                            var addedAmount = target.GetInventory().AddMaxItems(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i));
                                            amountfinal -= addedAmount;
                                            if (amountfinal <= 0)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SuperficialMiningController), ex);
                }
            };
        }

        public static bool CheckEntityIsAFloatingObject(MyFloatingObject floatingObj)
        {
            try
            {
                if (floatingObj != null)
                {
                    Vector3D upp = floatingObj.WorldMatrix.Up;
                    Vector3D fww = floatingObj.WorldMatrix.Forward;
                    var typeId = floatingObj.Item.Content.TypeId.ToString();
                    var subtypeId = floatingObj.Item.Content.SubtypeId.ToString();
                    Vector3D pos = (floatingObj as IMyEntity).GetPosition();
                    var lootAmmount = DoInternalDrill(typeId, subtypeId, pos, MAX_DISTANCE_TO_GENERATE_LOOT);
                    if (lootAmmount.Any())
                    {
                        foreach (var i in lootAmmount.Keys)
                        {
                            MyFixedPoint amountfinal = (int)lootAmmount[i];
                            MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i)), pos, fww, upp);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(SuperficialMiningController), ex);
            }
            return false;
        }

    }

}