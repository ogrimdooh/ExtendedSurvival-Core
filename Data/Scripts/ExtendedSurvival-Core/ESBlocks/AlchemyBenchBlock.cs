using Sandbox.Common.ObjectBuilders;
using VRage.Game.Components;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, "BasicAlchemyBench", "AlchemyBench", "AlchemyBenchIndustrial")]
    public class AlchemyBenchBlock : BaseAssemblerBlock
    {

        public static string BASIC_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_BASIC);
            }
        }

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_ALCHEMYBENCH);
            }
        }

        public static string INDUSTRIAL_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_INDUSTRIAL);
            }
        }

        public static string GetFullDescription()
        {
            return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_DESCRIPTION);
        }

    }

}
