using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival
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
            CurrentEntity.CurrentModeChanged += Assembler_CurrentModeChanged;
            CurrentEntity.CurrentStateChanged += Assembler_CurrentStateChanged;
            NeedsUpdate = VRage.ModAPI.MyEntityUpdateEnum.EACH_100TH_FRAME;
            base.OnInit(objectBuilder);
        }

        private void ResetAssemblerMode()
        {
            if (CurrentEntity.Mode != Sandbox.ModAPI.Ingame.MyAssemblerMode.Assembly)
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

    }

}
