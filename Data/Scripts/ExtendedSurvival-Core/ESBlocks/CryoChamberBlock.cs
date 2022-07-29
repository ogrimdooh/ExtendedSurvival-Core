using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game.Components;

namespace ExtendedSurvival
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CryoChamber), false, "LargeBlockCryoChamber", "SmallBlockCryoChamber")]
    public class CryoChamberBlock : SimpleInventoryLogicComponent<IMyCryoChamber>
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
