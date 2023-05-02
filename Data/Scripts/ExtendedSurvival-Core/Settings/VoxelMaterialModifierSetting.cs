using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class VoxelMaterialModifierSetting
    {

        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public int Version { get; set; }

        [XmlElement]
        public bool UsingTechnology { get; set; } = false;

        [XmlElement]
        public float NoChangeChance { get; set; }

        [XmlArray("Options"), XmlArrayItem("Option", typeof(VoxelMapModifierOptionSetting))]
        public List<VoxelMapModifierOptionSetting> Options { get; set; } = new List<VoxelMapModifierOptionSetting>();

        public MyVoxelMapModifierOption[] BuildOptions()
        {
            var lista = new List<MyVoxelMapModifierOption>();
            if (NoChangeChance < 0)
                NoChangeChance = 0;
            if (NoChangeChance > 0)
            {
                lista.Add(new MyVoxelMapModifierOption()
                {
                    Chance = NoChangeChance,
                    Changes = Options.Where(x => x.Default).Select(x => new MyVoxelMapModifierChange() { 
                        From = x.IdFrom,
                        To = x.IdTo
                    }).ToArray()
                });
            }
            if (Options.Any(x => !x.Default))
            {
                var changeToUse = 1 - NoChangeChance;
                var changeOfItem = changeToUse / Options.Count(x => !x.Default);
                foreach (var item in Options.Where(x => !x.Default))
                {
                    var listaChanges = Options.Where(x => x.Default).Select(x => new MyVoxelMapModifierChange()
                    {
                        From = x.IdFrom,
                        To = x.IdTo
                    }).ToList();
                    listaChanges.Add(new MyVoxelMapModifierChange() { 
                        From = PlanetMapProfile.Iron_01,
                        To = item.IdTo
                    });
                    listaChanges.Add(new MyVoxelMapModifierChange()
                    {
                        From = PlanetMapProfile.Iron_02,
                        To = item.IdTo
                    });
                    lista.Add(new MyVoxelMapModifierOption()
                    {
                        Chance = changeOfItem,
                        Changes = listaChanges.ToArray()
                    });
                }
            }
            return lista.ToArray();
        }

    }

}
