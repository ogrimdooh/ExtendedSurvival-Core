using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.ModAPI;
using VRage.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;
using Sandbox.ModAPI;

namespace ExtendedSurvival.Core
{

    public static class WoodChopController
    {

        private static readonly float BASE_WOOD_DROP = 200.0f;

        private static List<ExtendedSurvivalCoreAPIBackend.TreeDropLoot> TREE_DROPS = new List<ExtendedSurvivalCoreAPIBackend.TreeDropLoot>();

        private static MyObjectBuilder_PhysicalObject GetTreeDropLootBuilder(ExtendedSurvivalCoreAPIBackend.TreeDropLoot treeDrop)
        {
            if (treeDrop.IsGas)
                return ItensConstants.GetGasContainerBuilder(new UniqueEntityId(treeDrop.ItemId), treeDrop.GasLevel);
            else
                return ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(treeDrop.ItemId));
        }

        public static void AddTreeDrop(ExtendedSurvivalCoreAPIBackend.TreeDropLoot treeDrop)
        {
            if (!TREE_DROPS.Any(x => x.ItemId.TypeId == treeDrop.ItemId.TypeId && x.ItemId.SubtypeId == treeDrop.ItemId.SubtypeId))
                TREE_DROPS.Add(treeDrop);
        }

        private static readonly Random rnd = new Random();

        private static int GetRandon(string key)
        {
            return (((((byte)(key[rnd.Next(1, key.Length)])) + 128) % 6) - 3);
        }

        public static bool CheckEntityIsATree(string entityName, MyEntity obj)
        {
            if (entityName.StartsWith("MyDebrisTr"))
            {

                string treemodel = (obj as IMyEntity).Model.AssetName;

                var lootAmmount = new Dictionary<int, double>();

                for (int i = 0; i < TREE_DROPS.Count; i++)
                {
                    if (rnd.Next(1, 101) <= TREE_DROPS[i].Chance)
                        lootAmmount.Add(i, TREE_DROPS[i].Ammount);
                }

                double woodamount = BASE_WOOD_DROP;

                var keys = lootAmmount.Keys.ToArray();
                if (treemodel.Contains("Medium"))
                {
                    woodamount *= 0.75;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowMedium)
                            lootAmmount[i] *= TREE_DROPS[i].MediumReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }
                if (treemodel.Contains("Dead"))
                {
                    woodamount *= 0.75;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowDead)
                            lootAmmount[i] *= TREE_DROPS[i].DeadReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }
                if (treemodel.Contains("Desert"))
                {
                    woodamount *= 0.75;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowDesert)
                            lootAmmount[i] *= TREE_DROPS[i].DesertReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }

                MyFixedPoint amount = (int)(woodamount / 5.0);

                Vector3D upp = obj.WorldMatrix.Up;
                Vector3D fww = obj.WorldMatrix.Forward;
                Vector3D rtt = obj.WorldMatrix.Right;
                Vector3D pos = (obj as IMyEntity).GetPosition();

                MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                {

                    foreach (var i in lootAmmount.Keys)
                    {
                        MyFixedPoint amountfinal = (int)lootAmmount[i];
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amountfinal, GetTreeDropLootBuilder(TREE_DROPS[i])), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    }

                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.WOODLOG_ID)), pos + (upp * 13) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.WOODLOG_ID)), pos + (upp * 12) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.WOODLOG_ID)), pos + (upp * 11) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.WOODLOG_ID)), pos + (upp * 10) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.WOODLOG_ID)), pos + (upp * 09), fww, upp);

                });
                
                return true;

            }
            return false;
        }

    }

}