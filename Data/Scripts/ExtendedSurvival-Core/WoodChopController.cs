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
using Sandbox.Engine.Voxels;

namespace ExtendedSurvival.Core
{

    public static class WoodChopController
    {

        public static void BuildHelpTopics()
        {

        }

        private static readonly Vector2 BASE_WOOD_DROP = new Vector2(140, 240);
        private static readonly Vector2 BASE_LEAF_DROP = new Vector2(40, 80);
        private static readonly Vector2 BASE_TWIG_DROP = new Vector2(30, 60);
        private static readonly Vector2 BASE_BRANCH_DROP = new Vector2(20, 40);
        private static readonly Vector2 BASE_CARBON_DROP = new Vector2(10, 20);

        private static List<TreeDropLoot> TREE_DROPS = new List<TreeDropLoot>();

        private static MyObjectBuilder_PhysicalObject GetTreeDropLootBuilder(TreeDropLoot treeDrop)
        {
            if (treeDrop.IsGas)
                return ItensConstants.GetGasContainerBuilder(new UniqueEntityId(treeDrop.ItemId), treeDrop.GasLevel);
            else
                return ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(treeDrop.ItemId));
        }

        public static void AddTreeDrop(TreeDropLoot treeDrop)
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
                    if (rnd.Next(0, 100) <= TREE_DROPS[i].Chance)
                        lootAmmount.Add(i, TREE_DROPS[i].Ammount.GetRandom());
                }

                double woodamount = BASE_WOOD_DROP.GetRandom();
                double leafamount = BASE_LEAF_DROP.GetRandom();
                double twigamount = BASE_TWIG_DROP.GetRandom();
                double branchamount = BASE_BRANCH_DROP.GetRandom();
                double carbonamount = 0;

                var keys = lootAmmount.Keys.ToArray();
                if (treemodel.Contains("Medium"))
                {
                    woodamount *= 0.75;
                    leafamount *= 0.75;
                    twigamount *= 0.75;
                    branchamount *= 0.75;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowMedium)
                            lootAmmount[i] *= TREE_DROPS[i].MediumReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }
                if (treemodel.Contains("Dead") || treemodel.Contains("Burned"))
                {
                    woodamount *= 0.5;
                    leafamount *= 0;
                    twigamount *= 1.5;
                    branchamount *= 1.25;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowDead)
                            lootAmmount[i] *= TREE_DROPS[i].DeadReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }
                if (treemodel.Contains("Burned"))
                {
                    woodamount *= 0.25;
                    leafamount *= 0;
                    twigamount *= 0.75;
                    branchamount *= 0.5;
                    carbonamount = BASE_CARBON_DROP.GetRandom();
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
                    leafamount *= 0;
                    twigamount *= 1.25;
                    branchamount *= 1.125;
                    foreach (var i in keys)
                    {
                        if (TREE_DROPS[i].AlowDesert)
                            lootAmmount[i] *= TREE_DROPS[i].DesertReduction;
                        else
                            lootAmmount[i] = 0;
                    }
                }

                MyFixedPoint amount = (MyFixedPoint)(woodamount / 5.0);

                Vector3D upp = obj.WorldMatrix.Up;
                Vector3D fww = obj.WorldMatrix.Forward;
                Vector3D rtt = obj.WorldMatrix.Right;
                Vector3D pos = (obj as IMyEntity).GetPosition();

                MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                {

                    foreach (var i in lootAmmount.Keys)
                    {
                        MyFixedPoint amountfinal = (MyFixedPoint)lootAmmount[i];
                        if (TREE_DROPS[i].IsGas || TREE_DROPS[i].ItemId.TypeId == typeof(MyObjectBuilder_ConsumableItem))
                            amountfinal = (int)amountfinal;
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amountfinal, GetTreeDropLootBuilder(TREE_DROPS[i])), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    }

                    if (leafamount > 0)
                    {
                        MyFixedPoint finalleafamount = (MyFixedPoint)(leafamount);
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(finalleafamount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.LEAF_ID)), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    }

                    if (twigamount > 0)
                    {
                        MyFixedPoint finaltwigamount = (MyFixedPoint)(twigamount);
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(finaltwigamount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.TWIG_ID)), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    }

                    if (branchamount > 0)
                    {
                        MyFixedPoint finalbranchamount = (MyFixedPoint)(branchamount);
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(finalbranchamount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.BRANCH_ID)), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
                    }

                    if (carbonamount > 0)
                    {
                        MyFixedPoint finalcarbonamount = (MyFixedPoint)(carbonamount);
                        MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(finalcarbonamount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.CARBON_POWDER_ID)), pos + (upp * 14) + (fww * (0.33 * GetRandon(entityName))) + ((rtt * 0.33 * GetRandon(entityName))), fww, upp);
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