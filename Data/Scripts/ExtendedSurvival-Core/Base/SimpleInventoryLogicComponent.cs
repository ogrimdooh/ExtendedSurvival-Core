using Sandbox.Game;
using System;
using VRage.Game.ModAPI;

namespace ExtendedSurvival
{
    public abstract class SimpleInventoryLogicComponent<T> : BaseInventoryLogicComponent<T> where T : IMyCubeBlock
    {

        protected override Guid CreateNewObserver(int index)
        {
            return ExtendedSurvivalCoreAPIBackend.AddInventoryObserver(CurrentEntity, index);
        }

    }

}
