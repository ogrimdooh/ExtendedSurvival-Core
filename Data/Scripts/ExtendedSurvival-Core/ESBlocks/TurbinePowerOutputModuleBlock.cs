using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using SpaceEngineers.Game.Entities.Blocks;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_UpgradeModule), false, "TurbinePowerOutputModule", "EnhancedTurbinePowerOutputModule", "EliteTurbinePowerOutputModule")]
    public class TurbinePowerOutputModuleBlock : BaseLogicComponent<IMyUpgradeModule>
    {

        public Vector3I UpPosition
        {
            get
            {
                return CurrentEntity.Position + (Vector3I)Base6Directions.Directions[(int)CurrentEntity.Orientation.Up];
            }
        }

        public Vector3I DownPosition
        {
            get
            {
                return CurrentEntity.Position + (Vector3I)Base6Directions.Directions[(int)Base6Directions.GetOppositeDirection(CurrentEntity.Orientation.Up)];
            }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {

        }

        public bool IsUpBlockValid(out long blockId)
        {
            blockId = 0;
            var block = GetUpBlock();
            if (block != null && block.FatBlock != null)
            {
                if (block.FatBlock.BlockDefinition.TypeId == typeof(MyObjectBuilder_WindTurbine))
                {
                    blockId = block.FatBlock.EntityId;
                    return true;
                }
            }
            return false;
        }

        public bool IsDownBlockValid(out long blockId)
        {
            blockId = 0;
            var block = GetDownBlock();
            if (block != null && block.FatBlock != null)
            {
                if (block.FatBlock.BlockDefinition.TypeId == typeof(MyObjectBuilder_WindTurbine))
                {
                    blockId = block.FatBlock.EntityId;
                    return true;
                }
            }
            return false;
        }

        protected IMySlimBlock GetUpBlock()
        {
            return CurrentEntity.CubeGrid.GetCubeBlock(UpPosition);
        }

        protected IMySlimBlock GetDownBlock()
        {
            return CurrentEntity.CubeGrid.GetCubeBlock(DownPosition);
        }

    }

}
