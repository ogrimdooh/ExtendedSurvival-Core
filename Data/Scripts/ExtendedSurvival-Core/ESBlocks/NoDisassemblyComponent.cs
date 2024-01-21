using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using System.Text;
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

        "SurvivalKit",
        "SurvivalKitLarge",

        "AQD_SG_BasicAssembler",
        "Furnace",
        "GanymedeBasicAssembler",
        "GanymedeAssembler",

        "SmallBasicGrinder",
        "BasicGrinder",
        "Grinder",
        "GrinderIndustrial",
        "SmallBasicAlchemyBench",
        "BasicAlchemyBench",
        "AlchemyBench",
        "AlchemyBenchIndustrial",

        "BasicBatteryCharger",
        "BatteryCharger",
        "BatteryChargerIndustrial",
        "BasicBatteryCharger",
        "BatteryCharger",
        "BatteryChargerIndustrial",
        "BasicArmory", 
        "Armory", 
        "ArmoryIndustrial",

        "BasicFoodProcessor",
        "FoodProcessor",
        "FoodProcessorIndustrial",
        "BasicSlaughterhouse",
        "Slaughterhouse",
        "SlaughterhouseIndustrial"
    )]
    public class NoDisassemblyComponent : BaseLogicComponent<IMyAssembler>
    {

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            CurrentEntity.CurrentModeChanged += Assembler_CurrentModeChanged;
            CurrentEntity.CurrentStateChanged += Assembler_CurrentStateChanged;
        }

        private void ResetAssemblerMode()
        {
            if (ExtendedSurvivalSettings.Instance.DisableAssemblerDysasemble &&
                CurrentEntity.Mode != Sandbox.ModAPI.Ingame.MyAssemblerMode.Assembly)
            {
                CurrentEntity.Mode = Sandbox.ModAPI.Ingame.MyAssemblerMode.Assembly;
            }
        }

        protected virtual void Assembler_CurrentStateChanged(IMyAssembler obj)
        {
            ResetAssemblerMode();
        }

        protected virtual void Assembler_CurrentModeChanged(IMyAssembler obj)
        {
            ResetAssemblerMode();
        }

        protected override void OnAppendingCustomInfo(StringBuilder sb)
        {
            base.OnAppendingCustomInfo(sb);
            sb.Append("Default disassemble enabled: ").Append(ExtendedSurvivalSettings.Instance.DisableAssemblerDysasemble ? "No" : "Yes").Append('\n');
        }

    }

}
