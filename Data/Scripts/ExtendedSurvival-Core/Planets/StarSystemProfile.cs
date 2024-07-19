using System;
using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public class StarSystemProfile
    {

        [Flags]
        public enum ValidPlanetProfile
        {

            None = 0,

            Vanilla = 1 << 1,
            ExtendedSurvival = 1 << 2,
            ATA = 1 << 3,

            All = Vanilla | ExtendedSurvival | ATA

        }

        public enum ProfileType
        {

            Random = 0,
            Mapped = 1

        }

        public enum MemberType
        {

            Planet = 0,
            AsteroidBelt = 1

        }

        public class SystemMember
        {

            public string Name { get; set; }
            public MemberType MemberType { get; set; }
            public string DefinitionSubtype { get; set; }
            public bool HasRing { get; set; }
            public float Density { get; set; }
            public int Order { get; set; }
            public Vector2 MoonCount { get; set; }
            public string[] ValidMoons { get; set; }
            public float SizeMultiplier { get; set; } = 1.0f;
            public Vector2 MoonSizeMultiplier { get; set; } = Vector2.One;

        }

        public string Name { get; set; }
        public ProfileType Type { get; set; } = ProfileType.Random;
        public ValidPlanetProfile PlanetProfile { get; set; } = ValidPlanetProfile.None;
        public string StarName { get; set; }
        public List<SystemMember> Members { get; set; } = new List<SystemMember>();
        public Vector2 TotalMembers { get; set; } = Vector2.Zero;
        public Vector2 DefaultMoonCount { get; set; } = Vector2.Zero;
        public Vector2 DefaultBeltCount { get; set; } = Vector2.Zero;
        public Vector2 DefaultRingCount { get; set; } = Vector2.Zero;
        public float DefaultDensity { get; set; } = 0.75f;
        public float DistanceMultiplier { get; set; } = 1f;
        public bool WithStar { get; set; } = false;
        public bool FirstMemberAtCenter { get; set; } = false;
        public bool AllowDuplicate { get; set; } = false;
        public bool VanillaAsteroids { get; set; } = false;
        public int Version { get; set; }

        public StarSystemSetting UpgradeSettings(StarSystemSetting settings)
        {
            if (settings != null)
            {
                if (settings.Version <= 2)
                {
                    settings.Members = BuildMembersSettings();
                }
                settings.Version = Version;
            }
            return settings;
        }

        public List<SystemMemberSetting> BuildMembersSettings()
        {
            var members = new List<SystemMemberSetting>();
            foreach (var member in Members)
            {
                members.Add(new SystemMemberSetting()
                {
                    Name = member.Name,
                    MemberType = (int)member.MemberType,
                    DefinitionSubtype = member.DefinitionSubtype,
                    HasRing = member.HasRing,
                    Density = member.Density,
                    Order = member.Order,
                    SizeMultiplier = member.SizeMultiplier > 0 ? Math.Max(member.SizeMultiplier, 0.25f) : 1f,
                    MoonCount = new DocumentedVector2(member.MoonCount.X, member.MoonCount.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                    ValidMoons = member.ValidMoons?.Select(x => new ValidMoonEntrySetting() { Id = x }).ToList() ?? new List<ValidMoonEntrySetting>() { },
                    MoonSizeMultiplier = member.MoonSizeMultiplier != Vector2.Zero ?
                        new DocumentedVector2(Math.Max(member.MoonSizeMultiplier.X, 0.25f), Math.Max(member.MoonSizeMultiplier.Y, 0.25f), StarSystemSetting.SIZEMULTIPLIER_INFO) :
                        new DocumentedVector2(1f, 1f, StarSystemSetting.SIZEMULTIPLIER_INFO),
                });
            }
            return members;
        }

        public StarSystemSetting BuildSettings()
        {
            return new StarSystemSetting()
            {
                Name = Name,
                Type = (int)Type,
                PlanetProfile = (int)PlanetProfile,
                TotalMembers = new DocumentedVector2(TotalMembers.X, TotalMembers.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                DefaultMoonCount = new DocumentedVector2(DefaultMoonCount.X, DefaultMoonCount.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                DefaultBeltCount = new DocumentedVector2(DefaultBeltCount.X, DefaultBeltCount.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                DefaultRingCount = new DocumentedVector2(DefaultRingCount.X, DefaultRingCount.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                DefaultDensity = DefaultDensity,
                DistanceMultiplier = DistanceMultiplier,
                WithStar = WithStar,
                FirstMemberAtCenter = FirstMemberAtCenter,
                AllowDuplicate = AllowDuplicate,
                VanillaAsteroids = VanillaAsteroids,
                Version = Version,
                StarName = StarName,
                Members = BuildMembersSettings()
            };
        }

    }

}
