using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public abstract class BaseInventoryLogicComponent<T> : BaseLogicComponent<T> where T : IMyCubeBlock
    {

        protected abstract MyInventory GetMyInventory(int index);
        protected abstract Guid CreateNewObserver(int index);
        protected abstract int GetInventoryCount();

        protected Dictionary<int, Guid> inventoryObservers = new Dictionary<int, Guid>();

        public Guid GetObserver(int index = 0)
        {
            if (inventoryObservers.ContainsKey(index))
                return inventoryObservers[index];
            return Guid.Empty;
        }

        public bool HasObserver()
        {
            return inventoryObservers.Any();
        }

        protected void TryCreateObserver()
        {
            if (MyAPIGateway.Session.IsServer)
            {
                if (!HasObserver())
                {
                    if (GetInventoryCount() > 0)
                    {
                        for (int i = 0; i < GetInventoryCount(); i++)
                        {
                            var inventory = GetMyInventory(i);
                            if (inventory != null)
                            {
                                var id = CreateNewObserver(i);
                                if (id != Guid.Empty)
                                    inventoryObservers.Add(i, id);
                            }
                        }
                    }
                }
            }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            TryCreateObserver();
        }

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            TryCreateObserver();
        }

    }

}
