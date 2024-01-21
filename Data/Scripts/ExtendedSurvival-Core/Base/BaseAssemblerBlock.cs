using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage;
using VRage.Game.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public abstract class BaseAssemblerBlock : SimpleInventoryLogicComponent<IMyAssembler>
    {

        public MyInventory InputInventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        public MyInventory OutputInventory
        {
            get
            {
                return GetMyInventory(1);
            }
        }

        private MyInventory _inputInventory;
        private MyInventory _outputInventory;
        protected override MyInventory GetMyInventory(int index)
        {
            switch (index)
            {
                case 0:
                    if (_inputInventory == null)
                        _inputInventory = CurrentEntity.InputInventory as MyInventory;
                    return _inputInventory;
                case 1:
                    if (_outputInventory == null)
                        _outputInventory = CurrentEntity.OutputInventory as MyInventory;
                    return _outputInventory;
            }
            return null;
        }

        protected override int GetInventoryCount()
        {
            return 2;
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            CurrentEntity.StartedProducing += CurrentEntity_StartedProducing;
            CurrentEntity.StoppedProducing += CurrentEntity_StoppedProducing;
            CurrentEntity.CurrentProgressChanged += CurrentEntity_CurrentProgressChanged;
            NeedsUpdate = VRage.ModAPI.MyEntityUpdateEnum.EACH_100TH_FRAME;
            base.OnInit(objectBuilder);
            CheckQueue();
        }

        private void CheckQueue()
        {
            try
            {
                if (IsServer)
                {
                    if (CurrentEntity.GetQueue().Count > 0)
                    {
                        foreach (var queue in CurrentEntity.GetQueue())
                        {
                            var blueprint = queue.Blueprint as MyBlueprintDefinitionBase;
                            foreach (var prerequisites in blueprint.Prerequisites)
                            {
                                var amountOnOutput = OutputInventory.GetItemAmount(prerequisites.Id);
                                if (amountOnOutput > 0)
                                {
                                    var requiredAmount = queue.Amount * prerequisites.Amount;
                                    if (amountOnOutput < requiredAmount)
                                    {
                                        requiredAmount = amountOnOutput;
                                    }
                                    var amountAdded = (InputInventory as IMyInventory).AddMaxItems(requiredAmount, ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(prerequisites.Id)));
                                    OutputInventory.RemoveItemsOfType(amountAdded, prerequisites.Id);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected virtual void CurrentEntity_StoppedProducing()
        {
            CheckQueue();
        }

        protected virtual void CurrentEntity_StartedProducing()
        {

        }

        protected virtual void CurrentEntity_CurrentProgressChanged(IMyAssembler obj)
        {

        }

    }

}
