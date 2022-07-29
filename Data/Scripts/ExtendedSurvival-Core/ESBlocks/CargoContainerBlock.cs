using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;

namespace ExtendedSurvival
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), false, "SmallBlockSmallContainer", "SmallBlockMediumContainer", "SmallBlockLargeContainer", "LargeBlockSmallContainer", "LargeBlockLargeContainer", "LargeBlockLargeIndustrialContainer")]
    public class CargoContainerBlock : SimpleInventoryLogicComponent<IMyCargoContainer>
    {

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        private MyInventory _inventory;
        protected override MyInventory GetMyInventory(int index)
        {
            if (_inventory == null)
                _inventory = CurrentEntity.GetInventory() as MyInventory;
            return _inventory;
        }

        protected override int GetInventoryCount()
        {
            return 1;
        }

    }

}
