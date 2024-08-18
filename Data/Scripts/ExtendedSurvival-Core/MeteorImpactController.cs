using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.ModAPI;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Game.ModAPI;
using VRage.Utils;
using Sandbox.Definitions;
using VRage.Voxels;
using Sandbox.Game.Entities;
using VRage.Game.Entity;

namespace ExtendedSurvival.Core
{
    public static class MeteorImpactController
    {

        public const int MAX_SPAWN_ALTITUDE = 3;

        public static void CheckEntityCanGenerateStone(IMyMeteor meteor)
        {
            if (ExtendedSurvivalSettings.Instance.MeteorImpact.Enabled)
            {
                meteor.OnMarkForClose += MeteorImpactHandler;
            }
        }

        private static void MeteorImpactHandler(IMyEntity meteor)
        {
            meteor.OnMarkForClose -= MeteorImpactHandler;
            var position = meteor.GetPosition();
            var planet = ExtendedSurvivalEntityManager.GetPlanetAtRange(position);
            if (planet != null)
            {

                Vector3D surfacePoint = planet.Entity.GetClosestSurfacePointGlobal(position);
                float altitudeSqr = (float)Vector3D.DistanceSquared(position, surfacePoint);
                float naturalGravityInterference;
                Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(position, out naturalGravityInterference);

                if (naturalGravityInterference == 0)
                    return;

                float maxSpawnAltitudeSqr = (float)Math.Pow(MAX_SPAWN_ALTITUDE, 2);

                if (naturalGravity.LengthSquared() > 0 && altitudeSqr > maxSpawnAltitudeSqr)
                    return;

                List<IMyPlayer> players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(
                    players, 
                    player => !player.IsBot && Vector3D.DistanceSquared(player.GetPosition(), meteor.GetPosition()) < Math.Pow(ExtendedSurvivalSettings.Instance.MeteorImpact.DistanceToSpawn, 2)
                );
                if (players.Count == 0) 
                    return;

                TryToSpawn(meteor, planet);

            }
        }

        public static byte[] ReadAllBytes(System.IO.BinaryReader reader)
        {
            reader.BaseStream.Position = 0;
            return reader.ReadBytes((int)reader.BaseStream.Length);
        }

        private static void TryToSpawn(IMyEntity meteor, PlanetEntity planet)
        {            
            if (planet.Setting.MeteorImpact.Stones.Any() &&
                planet.Setting.MeteorImpact.Stones.Sum(x => x.ChanceToSpawn) == 1 &&
                MyUtils.GetRandomFloat(0, 1) <= planet.Setting.MeteorImpact.ChanceToSpawn)
            {
                var keyToUse = nameof(MeteorImpactStoneSetting) + "_" + planet.Setting.Id;
                RandomChanceController.RegisterChance(keyToUse, planet.Setting.MeteorImpact.Stones, x => x.ChanceToSpawn);
                MeteorImpactStoneSetting item = null;
                if (RandomChanceController.TryGetRandom(keyToUse, out item))
                {
                    MyPositionAndOrientation transform = new MyPositionAndOrientation(meteor.WorldMatrix);
                    var voxelMaps = MyAPIGateway.Session.VoxelMaps;
                    var maps = MyDefinitionManager.Static.GetVoxelMapStorageDefinitions();
                    if (maps.Any(x=>x.Id.SubtypeName == item.GroupId))
                    {
                        var map = maps.FirstOrDefault(x => x.Id.SubtypeName == item.GroupId);
                        var reader = MyAPIGateway.Utilities.ReadBinaryFileInGameContent(map.StorageFile);
                        var voxelMap = voxelMaps.CreateStorage(ReadAllBytes(reader));
                        // Change ore if needed
                        var modifiers = MyDefinitionManager.Static.GetAllDefinitions<MyVoxelMaterialModifierDefinition>();
                        if (modifiers != null && modifiers.Any(x => x.Id.SubtypeName == item.ModifierId))
                        {
                            var modifier = modifiers.FirstOrDefault(x => x.Id.SubtypeName == item.ModifierId);
                            var chance = MyUtils.GetRandomFloat(0, 1);
                            var change = modifier.Options.Sample(chance);
                            var opr = new MaterialModifier(change);
                            Vector3I voxelRangeMin = Vector3I.Zero;
                            Vector3I voxelRangeMax = voxelMap.Size;
                            try
                            {
                                voxelMap.PinAndExecute(() => {
                                    voxelMap.ExecuteOperationFast(ref opr, MyStorageDataTypeFlags.Material, ref voxelRangeMin, ref voxelRangeMax, true);
                                });
                            }
                            catch (Exception ex)
                            {
                                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(MeteorImpactController), ex);
                            }
                        }
                        // Create stone
                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                        {
                            string storageName = string.Format("{0}_{1}_{2}", item.GroupId, meteor.EntityId, MyUtils.GetRandomInt(int.MaxValue));
                            var stone = voxelMaps.CreateVoxelMap(storageName, voxelMap, meteor.GetPosition(), MyUtils.GetRandomLong());
                            stone.Synchronized = true;
                            stone.Save = true;
                            var matrix = transform.GetMatrix();
                            stone.PositionComp.SetWorldMatrix(ref matrix);

                            MyEntities.RaiseEntityCreated((MyEntity)stone);

                            ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(MeteorImpactController), $"Boulder has been created at a meteor impact!");

                            ExtendedSurvivalStorage.Instance.MeteorImpact.Stones.Add(new MeteorStoneStorage()
                            {
                                EntityId = stone.EntityId,
                                Life = ExtendedSurvivalSettings.Instance.MeteorImpact.StoneLifeTime * 1000
                            });
                        });
                    }
                }
            }
        }

        public struct MaterialModifier : IVoxelOperator
        {

            public VoxelMapChange Change { get; set; }

            public MaterialModifier(VoxelMapChange change)
            {
                Change = change;
            }

            public VoxelOperatorFlags Flags => VoxelOperatorFlags.ReadWrite;

            public void Op(ref Vector3I position, MyStorageDataTypeEnum dataType, ref byte inOutContent)
            {
                if (dataType == MyStorageDataTypeEnum.Material)
                {
                    if (Change.Changes.ContainsKey(inOutContent))
                        inOutContent = Change.Changes[inOutContent];
                }
            }

        }

    }

}