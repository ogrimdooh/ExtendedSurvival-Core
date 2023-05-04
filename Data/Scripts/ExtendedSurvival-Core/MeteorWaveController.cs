using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Game.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Core
{
    public static class MeteorWaveController
    {

        private static readonly double HORIZON_ANGLE_FROM_ZENITH_RATIO = Math.Sin(0.35);
        private static readonly int WAVES_IN_SHOWER = 1;
        private static readonly double METEOR_BLUR_KOEF = 2.5;

        private static Vector3D m_tgtPos;
        private static Vector3D m_normalSun;
        private static Vector3D m_pltTgtDir;
        private static Vector3D m_mirrorDir;
        private static BoundingSphereD? m_currentTarget;
        private static Vector3 m_downVector;
        private static Vector3 m_rightVector = Vector3.Zero;
        private static int m_meteorcount;
        private static int m_waveCounter;
        private static List<MyEntity> m_meteorList = new List<MyEntity>();
        private static List<MyEntity> m_tmpEntityList = new List<MyEntity>();
        private static List<BoundingSphereD> m_targetList = new List<BoundingSphereD>();
        private static List<MyCubeGrid> m_tmpHitGroup = new List<MyCubeGrid>();
        private static int m_lastTargetCount;
        private static Vector3D m_meteorHitPos;

        private static Vector3 GetCorrectedDirection(Vector3 direction)
        {
            Vector3 correctedDirection = direction;
            if (!m_currentTarget.HasValue)
                return correctedDirection;
            Vector3D center = m_currentTarget.Value.Center;
            m_tgtPos = center;
            float naturalGravityInterference;
            Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(center, out naturalGravityInterference);
            if (naturalGravityInterference == 0)
                return correctedDirection;
            Vector3D vector3D1 = -Vector3D.Normalize((Vector3D)naturalGravity);
            Vector3D vector3D2 = Vector3D.Normalize(Vector3D.Cross(vector3D1, (Vector3D)correctedDirection));
            Vector3D vector3D3 = Vector3D.Normalize(Vector3D.Cross(vector3D2, vector3D1));
            m_mirrorDir = vector3D3;
            m_pltTgtDir = vector3D1;
            m_normalSun = vector3D2;
            double num = vector3D1.Dot(correctedDirection);
            if (num < -HORIZON_ANGLE_FROM_ZENITH_RATIO)
                return (Vector3)Vector3D.Reflect((Vector3D)(-correctedDirection), vector3D3);
            if (num >= HORIZON_ANGLE_FROM_ZENITH_RATIO)
                return correctedDirection;
            MatrixD fromAxisAngle = MatrixD.CreateFromAxisAngle(vector3D2, -Math.Asin(HORIZON_ANGLE_FROM_ZENITH_RATIO));
            return (Vector3)Vector3D.Transform(vector3D3, fromAxisAngle);
        }

        private static void SetupDirVectors(Vector3 direction)
        {
            if (!(m_rightVector == Vector3.Zero))
                return;
            direction.CalculatePerpendicularVector(out m_rightVector);
            m_downVector = MyUtils.Normalize(Vector3.Cross(direction, m_rightVector));
        }

        private static void ClearMeteorList() => m_meteorList.Clear();

        public static void CallMeteorWave(BoundingSphereD target)
        {
            m_currentTarget = target;
            ++m_waveCounter;
            ClearMeteorList();
            if (m_targetList.Count == 0)
            {
                GetTargets();
                if (m_targetList.Count == 0)
                {
                    m_waveCounter = WAVES_IN_SHOWER + 1;
                    return;
                }
            }
            m_currentTarget = new BoundingSphereD?(m_targetList.ElementAt<BoundingSphereD>(MyUtils.GetRandomInt(m_targetList.Count - 1)));
            m_targetList.Remove(m_currentTarget.Value);
            m_meteorcount = (int)(Math.Pow(m_currentTarget.Value.Radius, 2.0) * Math.PI / 6000.0);
            m_meteorcount /= MyAPIGateway.Session.EnvironmentHostility == MyEnvironmentHostilityEnum.CATACLYSM || MyAPIGateway.Session.EnvironmentHostility == MyEnvironmentHostilityEnum.CATACLYSM_UNREAL ? 1 : 8;
            m_meteorcount = MathHelper.Clamp(m_meteorcount, 1, 30);
            CheckTargetValid();
            if (m_waveCounter < 0)
                return;
            StartWave();
        }

        private static void CheckTargetValid()
        {
            if (!m_currentTarget.HasValue)
                return;
            m_tmpEntityList.Clear();
            BoundingSphereD boundingSphere = m_currentTarget.Value;
            m_tmpEntityList = MyEntities.GetEntitiesInSphere(ref boundingSphere);
            if (m_tmpEntityList.OfType<MyCubeGrid>().ToList<MyCubeGrid>().Count == 0)
                m_waveCounter = -1;
            m_tmpEntityList.Clear();
        }

        private static void GetTargets()
        {
            List<MyCubeGrid> list = MyEntities.GetEntities().OfType<MyCubeGrid>().ToList<MyCubeGrid>();
            for (int index = 0; index < list.Count; ++index)
            {
                if ((list[index].Max - list[index].Min + Vector3I.One).Size < 16)
                {
                    list.RemoveAt(index);
                    --index;
                }
            }
            while (list.Count > 0)
            {
                MyCubeGrid myCubeGrid1 = list[MyUtils.GetRandomInt(list.Count - 1)];
                m_tmpHitGroup.Add(myCubeGrid1);
                list.Remove(myCubeGrid1);
                BoundingSphereD worldVolume = myCubeGrid1.PositionComp.WorldVolume;
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    foreach (MyCubeGrid myCubeGrid2 in m_tmpHitGroup)
                        worldVolume.Include(myCubeGrid2.PositionComp.WorldVolume);
                    m_tmpHitGroup.Clear();
                    worldVolume.Radius += 10.0;
                    for (int index = 0; index < list.Count; ++index)
                    {
                        if (list[index].PositionComp.WorldVolume.Intersects(worldVolume))
                        {
                            flag = true;
                            m_tmpHitGroup.Add(list[index]);
                            list.RemoveAt(index);
                            --index;
                        }
                    }
                }
                worldVolume.Radius += 150.0;
                m_targetList.Add(worldVolume);
            }
            m_lastTargetCount = m_targetList.Count;
        }

        private static void StartWave()
        {
            if (!m_currentTarget.HasValue)
                return;
            var sector = MyAPIGateway.Session.GetSector();
            Vector3 sunDirection;
            Vector3.CreateFromAzimuthAndElevation(sector.Environment.SunAzimuth, sector.Environment.SunElevation, out sunDirection);
            Vector3 correctedDirection = GetCorrectedDirection(sunDirection);
            SetupDirVectors(correctedDirection);
            float randomFloat1 = MyUtils.GetRandomFloat((float)Math.Min(2, m_meteorcount - 3), (float)(m_meteorcount + 3));
            Vector3 circleNormalized1 = MyUtils.GetRandomVector3CircleNormalized();
            float randomFloat2 = MyUtils.GetRandomFloat(0.0f, 1f);
            Vector3D vector3D1 = (Vector3D)(circleNormalized1.X * m_rightVector + circleNormalized1.Z * m_downVector);
            Vector3D vector3D2 = m_currentTarget.Value.Center + Math.Pow((double)randomFloat2, 0.699999988079071) * m_currentTarget.Value.Radius * vector3D1 * METEOR_BLUR_KOEF;
            float naturalGravityInterference;
            Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(vector3D2, out naturalGravityInterference);
            Vector3D vector3D3 = -Vector3D.Normalize((Vector3D)naturalGravity);
            if (vector3D3 != Vector3D.Zero)
            {
                IHitInfo nullable;
                MyAPIGateway.Physics.CastRay(vector3D2 + vector3D3 * 3000.0, vector3D2, out nullable, 15);
                if (nullable != null)
                    vector3D2 = nullable.Position;
            }
            m_meteorHitPos = vector3D2;
            for (int index = 0; (double)index < (double)randomFloat1; ++index)
            {
                Vector3 circleNormalized2 = MyUtils.GetRandomVector3CircleNormalized();
                float randomFloat3 = MyUtils.GetRandomFloat(0.0f, 1f);
                Vector3D vector3D4 = (Vector3D)(circleNormalized2.X * m_rightVector + circleNormalized2.Z * m_downVector);
                vector3D2 += Math.Pow((double)randomFloat3, 0.699999988079071) * m_currentTarget.Value.Radius * vector3D4;
                Vector3 vector3 = correctedDirection * (float)(2000 + 100 * index);
                Vector3 circleNormalized3 = MyUtils.GetRandomVector3CircleNormalized();
                Vector3D vector3D5 = (Vector3D)(circleNormalized3.X * m_rightVector + circleNormalized3.Z * m_downVector);
                Vector3D position = vector3D2 + vector3 + Math.Tan((double)MyUtils.GetRandomFloat(0.0f, 0.1745329f)) * vector3D5;
                m_meteorList.Add(MyMeteor.SpawnRandom(position, Vector3.Normalize(vector3D2 - position)));
            }
            m_rightVector = Vector3.Zero;
        }

    }

}