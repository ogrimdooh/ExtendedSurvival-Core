using Sandbox.Common.ObjectBuilders;
using VRage.Game.Components;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false,
        "SmallBasicGrinder", 
        "BasicGrinder", 
        "Grinder", 
        "GrinderIndustrial"
    )]
    public class GrinderBlock : BaseAssemblerBlock
    {

        public static string BASIC_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_GRINDER_BASIC);
            }
        }

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_GRINDER);
            }
        }

        public static string INDUSTRIAL_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_GRINDER_INDUSTRIAL);
            }
        }

        public static string GetFullDescription()
        {
            return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_GRINDER_DESCRIPTION);
        }

    }

}