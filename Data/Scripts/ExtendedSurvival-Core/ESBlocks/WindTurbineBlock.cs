using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using SpaceEngineers.Game.Entities.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_WindTurbine), false, "LargeBlockWindTurbine", "LargeBlockWindTurbineStackable", "LargeBlockWindTurbineReskin")]
    public class WindTurbineBlock : BaseLogicComponent<IMyPowerProducer>
    {

        private int maxModules;
        private List<IMyUpgradeModule> connectedModules = new List<IMyUpgradeModule>();

        protected MyResourceSourceComponent _sourceComp;
        protected MyResourceSourceComponent SourceComp
        {
            get
            {
                if (_sourceComp == null)
                    _sourceComp = CurrentEntity.Components.Get<MyResourceSourceComponent>();
                return _sourceComp;
            }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            maxModules = CurrentEntity.BlockDefinition.SubtypeId == "LargeBlockWindTurbineStackable" ? 2 : 1;
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
            if (IsClient)
            {
                RequestPower();
            }
        }

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            if (IsServer)
            {
                var oldValue = SourceComp.MaxOutput;
                SourceComp.SetMaxOutput(GetMaxPowerOutput());
                if (oldValue != SourceComp.MaxOutput)
                {
                    SendPowerToClient();
                    (CurrentEntity as IMyTerminalBlock).RefreshCustomInfo();
                }
            }
        }

        protected void SendPowerToClient(params ulong[] clientIds)
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.Debug)
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"SendPowerToClient: POWER={SourceComp.MaxOutput}");
                SendCallServer(
                    clientIds, 
                    "UpdatePower", 
                    new Dictionary<string, string>() 
                    { 
                        { "POWER", SourceComp.MaxOutput.ToString() },
                        { "MODULES", connectedModules.Count.ToString() },
                        { "MODIFIER", GetModuleModifier().ToString() }
                    }
                );
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected void RequestPower()
        {
            try
            {
                SendCallClient(MyAPIGateway.Session.Player.SteamUserId, "RequestPower", new Dictionary<string, string>() { });
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        public override void CallFromClient(ulong caller, string method, CommandExtraParams extraParams)
        {
            base.CallFromClient(caller, method, extraParams);
            try
            {
                if (ExtendedSurvivalSettings.Instance.Debug)
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"CallFromClient: caller={caller} - method={method}");
                switch (method)
                {
                    case "RequestPower":
                        SendPowerToClient(caller);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        private int _modules = 0;
        private float _modifier = 1;
        public override void CallFromServer(string method, CommandExtraParams extraParams)
        {
            base.CallFromServer(method, extraParams);
            try
            {
                switch (method)
                {
                    case "UpdatePower":
                        var power = float.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == "POWER")?.data);
                        _modules = int.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == "MODULES")?.data);
                        _modifier = float.Parse(extraParams.extraParams.FirstOrDefault(x => x.id == "MODIFIER")?.data);
                        SourceComp.SetMaxOutput(power);
                        (CurrentEntity as IMyTerminalBlock).RefreshCustomInfo();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(GetType(), ex);
            }
        }

        public void AddNewModule(IMyUpgradeModule module)
        {
            if (connectedModules.Count < maxModules)
            {
                connectedModules.Add(module);
            }
        }

        public void RemoveAllModules()
        {
            connectedModules.Clear();
        }

        public int GetTotalModules()
        {
            if (IsServer)
                return connectedModules.Count;
            return _modules;
        }

        public float GetModuleModifier()
        {
            if (IsClient)
                return _modifier;
            if (!connectedModules.Any())
                return 1;
            float m = 0;
            foreach (var item in connectedModules)
            {
                var definition = DefinitionUtils.TryGetDefinition<MyUpgradeModuleDefinition>(item.BlockDefinition);
                if (definition != null && definition.Upgrades.Length > 0)
                    m += definition.Upgrades[0].Modifier;
            }
            return m;
        }

        protected float GetMaxPowerOutput()
        {
            var baseValue = (BlockDefinition as MyWindTurbineDefinition).MaxPowerOutput;
            baseValue *= GetModuleModifier();
            return baseValue;
        }

        protected override void OnAppendingCustomInfo(StringBuilder sb)
        {
            base.OnAppendingCustomInfo(sb);
            sb.Append("Modules: ").Append(GetTotalModules()).Append('\n');
            sb.Append("Modifier: ").Append(GetModuleModifier()).Append('\n');
        }

    }

}
