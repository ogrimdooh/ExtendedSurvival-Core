using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Core
{
    public sealed class DescriptionBlocksOverride : BaseModIntegrationOverride
    {

        public static void TryOverride()
        {
            new DescriptionBlocksOverride().SetDefinitions();
        }

        public struct BlockDescriptionInfo
        {

            public string Name;
            public string Description;

        }

        public static readonly UniqueEntityId BASIC_GRINDER_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "BasicGrinder");
        public static readonly UniqueEntityId GRINDER_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "Grinder");
        public static readonly UniqueEntityId INDUSTRIAL_GRINDER_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "GrinderIndustrial");
        public static readonly UniqueEntityId BASIC_ALCHEMYBENCH_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "BasicAlchemyBench");
        public static readonly UniqueEntityId ALCHEMYBENCH_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "AlchemyBench");
        public static readonly UniqueEntityId INDUSTRIAL_ALCHEMYBENCH_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "AlchemyBenchIndustrial");

        public static readonly Dictionary<UniqueEntityId, BlockDescriptionInfo> BLOCKS_DESCRIPTIONS = new Dictionary<UniqueEntityId, BlockDescriptionInfo>()
        {
            {
                BASIC_GRINDER_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = GrinderBlock.BASIC_BLOCK_NAME,
                    Description = GrinderBlock.GetFullDescription()
                }
            },
            {
                GRINDER_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = GrinderBlock.BLOCK_NAME,
                    Description = GrinderBlock.GetFullDescription()
                }
            },
            {
                INDUSTRIAL_GRINDER_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = GrinderBlock.INDUSTRIAL_BLOCK_NAME,
                    Description = GrinderBlock.GetFullDescription()
                }
            },
            {
                BASIC_ALCHEMYBENCH_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = LaboratoryBlock.BASIC_BLOCK_NAME,
                    Description = LaboratoryBlock.GetFullDescription()
                }
            },
            {
                ALCHEMYBENCH_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = LaboratoryBlock.BLOCK_NAME,
                    Description = LaboratoryBlock.GetFullDescription()
                }
            },
            {
                INDUSTRIAL_ALCHEMYBENCH_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = LaboratoryBlock.INDUSTRIAL_BLOCK_NAME,
                    Description = LaboratoryBlock.GetFullDescription()
                }
            }
        };

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override void OnSetDefinitions()
        {
            foreach (var block in GetBlocks())
            {
                var blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(block.DefinitionId);
                if (blockDefinition != null)
                {
                    blockDefinition.DisplayNameEnum = null;
                    blockDefinition.DisplayNameString = BLOCKS_DESCRIPTIONS[block].Name;
                    blockDefinition.DescriptionEnum = null;
                    blockDefinition.DescriptionString = BLOCKS_DESCRIPTIONS[block].Description;
                }
                else
                    ExtendedSurvivalCoreLogging.Instance.LogWarning(GetType(), $"Override block not found. ID=[{block}]");
            }
        }

        private IEnumerable<UniqueEntityId> GetBlocks()
        {
            return BLOCKS_DESCRIPTIONS.Keys;
        }

    }

}