using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Core
{

    public sealed class AssemblerOverride : BaseIntegrationModRecipesOverride
    {

        public static void TryOverride()
        {
            if (!ExtendedSurvivalCoreSession.IsUsingTechnology())
                new AssemblerOverride().SetDefinitions();
        }

        public const string SurvivalKitLarge = "SurvivalKitLarge";
        public const string SurvivalKit = "SurvivalKit";

        public const string BasicAssembler = "BasicAssembler";
        public const string LargeAssembler = "LargeAssembler";
        public const string LargeAssemblerIndustrial = "LargeAssemblerIndustrial";

        public const string BasicGrinder = "BasicGrinder";

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override List<ComponentCost> GetBlockCost(UniqueEntityId item)
        {
            return new List<ComponentCost>();
        }

        protected override List<UniqueEntityId> GetBlocks()
        {
            var retorno = new List<UniqueEntityId>();
            try
            {
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicAssembler));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), LargeAssembler));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), LargeAssemblerIndustrial));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKit));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKitLarge));
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"GetBlocks [Error]");
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
            return retorno;
        }

        public static void SetUpBasicAssembler(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICASSEMBLER_BOTTLES_BLUEPRINTS);
                if (!assemblerDefinition.BlueprintClasses.Contains(bottlesClass))
                    assemblerDefinition.BlueprintClasses.Add(bottlesClass);
                assemblerDefinition.LoadPostProcess();
            }
        }

        public static void SetUpAssembler(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ASSEMBLER_BOTTLES_BLUEPRINTS);
                if (!assemblerDefinition.BlueprintClasses.Contains(bottlesClass))
                    assemblerDefinition.BlueprintClasses.Add(bottlesClass);
                assemblerDefinition.LoadPostProcess();
            }
        }

        public static void SetUpSurvivalKit(MySurvivalKitDefinition survivalKitDefinition)
        {
            if (survivalKitDefinition != null)
            {
                var refineClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_REFINE_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(refineClass))
                    survivalKitDefinition.BlueprintClasses.Add(refineClass);
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_BOTTLES_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(bottlesClass))
                    survivalKitDefinition.BlueprintClasses.Add(bottlesClass);
                var alchemyClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_ALCHEMY_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(alchemyClass))
                    survivalKitDefinition.BlueprintClasses.Add(alchemyClass);
                survivalKitDefinition.LoadPostProcess();
            }
        }

        protected override void OnAfterSetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {
            base.OnAfterSetComponents(blockDefinition, block);
            if (blockDefinition.Id.SubtypeName != SurvivalKit && blockDefinition.Id.SubtypeName != SurvivalKitLarge)
            {
                var assemblerDefinition = (blockDefinition as MyAssemblerDefinition);
                switch (assemblerDefinition.Id.SubtypeName)
                {
                    case LargeAssembler:
                    case LargeAssemblerIndustrial:
                        SetUpAssembler(assemblerDefinition);
                        break;
                    case BasicAssembler:
                        SetUpBasicAssembler(assemblerDefinition);
                        break;
                }
            }
            else
            {
                SetUpSurvivalKit(blockDefinition as MySurvivalKitDefinition);
            }
        }

    }

}