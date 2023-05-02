using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Core
{
    public class VoxelMaterialModifierProfile
    {

        public struct Option
        {
            
            public string From { get; set; }
            public string To { get; set; }
            public bool Default { get; set; }

        }

        public int Version { get; set; }
        public float NoChangeChance { get; set; }
        public List<Option> Options { get; set; } = new List<Option>();

        public VoxelMaterialModifierSetting UpgradeSettings(VoxelMaterialModifierSetting settings)
        {
            if (settings != null)
            {

                settings.Version = Version;
            }
            return settings;
        }

        private List<VoxelMapModifierOptionSetting> BuildOptionSettings()
        {
            return Options.Select(x => new VoxelMapModifierOptionSetting() { 
                IdFrom = x.From,
                IdTo = x.To,
                Default = x.Default
            }).ToList();
        }

        public VoxelMaterialModifierSetting BuildSettings(string id)
        {
            return new VoxelMaterialModifierSetting()
            {
                Id = id,
                UsingTechnology = ExtendedSurvivalCoreSession.IsUsingTechnology(),
                Version = Version,
                NoChangeChance = NoChangeChance,
                Options = BuildOptionSettings()
            };
        }

    }

}
