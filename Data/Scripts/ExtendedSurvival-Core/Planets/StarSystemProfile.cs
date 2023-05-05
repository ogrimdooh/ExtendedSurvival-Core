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

        public struct SystemMember
        {

            public string name;
            public MemberType memberType;
            public string definitionSubtype;
            public bool hasRing;
            public float density;
            public int order;
            public Vector2 moonCount;
            public string[] validMoons;

        }

        public string Name { get; set; }
        public ProfileType Type { get; set; } = ProfileType.Random;
        public ValidPlanetProfile PlanetProfile { get; set; } = ValidPlanetProfile.None;
        public List<SystemMember> Members { get; set; } = new List<SystemMember>();
        public Vector2 TotalMembers { get; set; } = Vector2.Zero;
        public Vector2 DefaultMoonCount { get; set; } = Vector2.Zero;
        public Vector2 DefaultBeltCount { get; set; } = Vector2.Zero;
        public Vector2 DefaultRingCount { get; set; } = Vector2.Zero;
        public float DefaultDensity { get; set; } = 0.75f;
        public float DistanceMultiplier { get; set; } = 1f;
        public bool WithStar { get; set; } = false;
        public bool AllowDuplicate { get; set; } = false;
        public bool VanillaAsteroids { get; set; } = false;
        public int Version { get; set; }

        public StarSystemSetting UpgradeSettings(StarSystemSetting settings)
        {
            if (settings != null)
            {

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
                    Name = member.name,
                    MemberType = (int)member.memberType,
                    DefinitionSubtype = member.definitionSubtype,
                    HasRing = member.hasRing,
                    Density = member.density,
                    Order = member.order,
                    MoonCount = new DocumentedVector2(member.moonCount.X, member.moonCount.Y, StarSystemSetting.TOTALMEMBERS_INFO),
                    ValidMoons = member.validMoons?.Select(x => new ValidMoonEntrySetting() { Id = x }).ToList() ?? new List<ValidMoonEntrySetting>() { }
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
                AllowDuplicate = AllowDuplicate,
                VanillaAsteroids = VanillaAsteroids,
                Version = Version,
                Members = BuildMembersSettings()
            };
        }

    }

}
