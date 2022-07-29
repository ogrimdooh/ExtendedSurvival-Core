using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game.Components;

namespace ExtendedSurvival
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Cockpit), false, "LargeBlockCockpitSeat", "SmallBlockCockpit", "BuggyCockpit", "LargeBlockCockpitIndustrial", "SmallBlockCockpitIndustrial", "DBSmallBlockFighterCockpit", "CockpitOpen", "OpenCockpitLarge", "OpenCockpitSmall", "PassengerSeatLarge", "PassengerSeatSmall", "PassengerSeatSmallNew", "PassengerSeatSmallOffset", "PassengerBench", "RoverCockpit", "SmallBlockStandingCockpit", "LargeBlockStandingCockpit", "LargeBlockCockpit")]
    public class CockpitBlock : SimpleInventoryLogicComponent<IMyCockpit>
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
