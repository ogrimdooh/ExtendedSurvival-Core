using Sandbox.Common.ObjectBuilders;
using VRage.Game.Components;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, 
        "BasicAssembler", 
        "LargeAssembler", 
        "LargeAssemblerIndustrial", 
        "AdvancedAssembler", 
        "AdvancedAssemblerIndustrial", 
        "GanymedeBasicAssembler",
        "GanymedeAssembler"
    )]
    public class AssemblerBlock : BaseAssemblerBlock
    {
       
    }

}
