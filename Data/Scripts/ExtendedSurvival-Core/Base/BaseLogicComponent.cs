using Sandbox.Definitions;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public interface IMySyncDataComponent
    {

        void CallFromServer(string method, CommandExtraParams extraParams);

    }

    public abstract class BaseLogicComponent<T> : MyGameLogicComponent, IMySyncDataComponent where T : IMyCubeBlock
    {

        public bool IsServer
        {
            get
            {
                return MyAPIGateway.Multiplayer.IsServer;
            }
        }

        public bool IsClient
        {
            get
            {
                return !IsServer;
            }
        }

        public bool IsDedicated
        {
            get
            {
                return MyAPIGateway.Utilities.IsDedicated;
            }
        }

        private bool _IsInit;
        protected bool IsInit
        {
            get
            {
                return _IsInit;
            }
        }

        private T _Entity;
        public T CurrentEntity
        {
            get
            {
                return _Entity;
            }
        }

        public float CurrentPower
        {
            get
            {
                return CurrentEntity.ResourceSink.CurrentInputByType(MyResourceDistributorComponent.ElectricityId);
            }
        }

        public float RequiredPower
        {
            get
            {
                return CurrentEntity.ResourceSink.RequiredInputByType(MyResourceDistributorComponent.ElectricityId);
            }
        }

        public bool IsPowered
        {
            get
            {
                return CurrentPower == RequiredPower;
            }
        }

        private GridEntity _grid;
        protected GridEntity Grid
        {
            get
            {
                if (_grid == null || _grid.Entity.EntityId != CurrentEntity.CubeGrid.EntityId)
                    _grid = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(CurrentEntity.CubeGrid.EntityId);
                return _grid;
            }
        }

        private MyCubeBlockDefinition _blockDefinition;
        protected MyCubeBlockDefinition BlockDefinition
        {
            get
            {
                if (_blockDefinition == null)
                    _blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(CurrentEntity.BlockDefinition);
                return _blockDefinition;
            }
        }

        protected abstract void OnInit(MyObjectBuilder_EntityBase objectBuilder);

        protected virtual void OnUpdateAfterSimulation100()
        {

        }

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), "Init");
            _Entity = (T)Entity;
            DoInit(objectBuilder);
        }

        public override void UpdateAfterSimulation100()
        {
            base.UpdateAfterSimulation100();
            try
            {
                OnUpdateAfterSimulation100();
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void DoInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            if (_IsInit) return;
            var terminalBlock = CurrentEntity as IMyTerminalBlock;
            if (terminalBlock != null)
            {
                terminalBlock.AppendingCustomInfo += TerminalBlock_AppendingCustomInfo;
            }
            OnInit(objectBuilder);
            _IsInit = true;
        }

        protected virtual void OnAppendingCustomInfo(StringBuilder sb)
        {

        }

        private void TerminalBlock_AppendingCustomInfo(IMyTerminalBlock block, StringBuilder sb)
        {
            sb.Append('-', 30).Append('\n');
            sb.Append("Extended Survival Information").Append('\n');
            sb.Append('-', 30).Append('\n');
            sb.Append("Startup: ").Append(_IsInit ? "Initialized" : "Pending").Append('\n');
            OnAppendingCustomInfo(sb);
            sb.Append('-', 30).Append('\n');
        }

        protected void StoreValue(string key, string value)
        {
            Guid guidKey;
            if (Guid.TryParse(key, out guidKey))
            {
                if (CurrentEntity.Storage == null)
                    CurrentEntity.Storage = new MyModStorageComponent();
                if (!CurrentEntity.Storage.ContainsKey(guidKey))
                    CurrentEntity.Storage.Add(guidKey, value);
                else
                    CurrentEntity.Storage.SetValue(guidKey, value);
            }
        }

        protected string GetValue(string key)
        {
            Guid guidKey;
            if (Guid.TryParse(key, out guidKey))
            {
                if (CurrentEntity.Storage == null)
                    CurrentEntity.Storage = new MyModStorageComponent();
                if (CurrentEntity.Storage.ContainsKey(guidKey))
                    return CurrentEntity.Storage.GetValue(guidKey);
            }
            return "";
        }

        protected void SendCallServer(string method, Dictionary<string, string> extraParams)
        {
            var cmd = new Command(0, CurrentEntity.EntityId.ToString(), GetType().Name, method);
            var extraData = new CommandExtraParams() { extraParams = extraParams.Select(x => new CommandExtraParam() { id = x.Key, data = x.Value }).ToArray() };
            string extraDataToSend = MyAPIGateway.Utilities.SerializeToXML<CommandExtraParams>(extraData);
            cmd.data = Encoding.Unicode.GetBytes(extraDataToSend);
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageToOthers(
                ExtendedSurvivalCoreSession.NETWORK_ID_ENTITYCALLS,
                Encoding.Unicode.GetBytes(messageToSend)
            );
        }

        public virtual void CallFromServer(string method, CommandExtraParams extraParams)
        {

        }

    }

}
