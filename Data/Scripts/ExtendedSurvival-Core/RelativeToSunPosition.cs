using System;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Utils;
using SpaceEngineers.Game.Entities.Blocks;
using VRage.Game;
using System.Collections.Generic;

namespace ExtendedSurvival.Core
{

    public class RelativeToSunPosition
    {

        private static readonly double HORIZON_ANGLE_FROM_ZENITH_RATIO = Math.Sin(0.35);

        public BoundingSphereD? CurrentTarget { get; private set; }
        public Vector3D TgtPos { get; private set; }
        public Vector3D NormalSun { get; private set; }
        public Vector3D PltTgtDir { get; private set; }
        public Vector3D MirrorDir { get; private set; }
        public Vector3 DownVector { get; private set; }
        public Vector3 RightVector { get; private set; } = Vector3.Zero;

        public void SetTarget(Vector3D target)
        {
            SetTarget(new BoundingSphereD(target, 50));
        }

        public void SetTarget(BoundingSphereD target)
        {
            CurrentTarget = target;
            Update();
        }

        public void ClearTarget()
        {
            CurrentTarget = null;
            Update();
        }

        public void Update()
        {
            var sector = MyAPIGateway.Session.GetSector();
            Vector3 sunDirection;
            Vector3.CreateFromAzimuthAndElevation(sector.Environment.SunAzimuth, sector.Environment.SunElevation, out sunDirection);
            Vector3 correctedDirection = GetCorrectedDirection(sunDirection);
            SetupDirVectors(correctedDirection);
        }

        private Vector3 GetCorrectedDirection(Vector3 direction)
        {
            Vector3 correctedDirection = direction;
            if (!CurrentTarget.HasValue)
                return correctedDirection;
            Vector3D center = CurrentTarget.Value.Center;
            TgtPos = center;
            float naturalGravityInterference;
            Vector3 naturalGravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(center, out naturalGravityInterference);
            if (naturalGravityInterference == 0)
                return correctedDirection;
            Vector3D vector3D1 = -Vector3D.Normalize((Vector3D)naturalGravity);
            Vector3D vector3D2 = Vector3D.Normalize(Vector3D.Cross(vector3D1, (Vector3D)correctedDirection));
            Vector3D vector3D3 = Vector3D.Normalize(Vector3D.Cross(vector3D2, vector3D1));
            MirrorDir = vector3D3;
            PltTgtDir = vector3D1;
            NormalSun = vector3D2;
            double num = vector3D1.Dot(correctedDirection);
            if (num < -HORIZON_ANGLE_FROM_ZENITH_RATIO)
                return (Vector3)Vector3D.Reflect((Vector3D)(-correctedDirection), vector3D3);
            if (num >= HORIZON_ANGLE_FROM_ZENITH_RATIO)
                return correctedDirection;
            MatrixD fromAxisAngle = MatrixD.CreateFromAxisAngle(vector3D2, -Math.Asin(HORIZON_ANGLE_FROM_ZENITH_RATIO));
            return (Vector3)Vector3D.Transform(vector3D3, fromAxisAngle);
        }

        private void SetupDirVectors(Vector3 direction)
        {
            if (!(RightVector == Vector3.Zero))
                return;
            Vector3 m_rightVector;
            direction.CalculatePerpendicularVector(out m_rightVector);
            RightVector = m_rightVector;
            DownVector = MyUtils.Normalize(Vector3.Cross(direction, RightVector));
        }

    }

}