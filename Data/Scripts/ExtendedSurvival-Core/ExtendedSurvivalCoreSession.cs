using Sandbox.ModAPI;
using System;
using System.Text;
using VRage.Game;
using VRage.Game.Components;

namespace ExtendedSurvival
{

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class ExtendedSurvivalCoreSession : BaseSessionComponent
    {

        public HudAPIv2 TextAPI;

        public const ushort NETWORK_ID_DEFINITIONS = 40424;
        public const ushort NETWORK_ID_ENTITYCALLS = 40425;
        public const string CALL_FOR_DEFS = "NEEDDEFS";

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
                Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, CALL_FOR_DEFS);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageToServer(
                    NETWORK_ID_DEFINITIONS,
                    Encoding.Unicode.GetBytes(message)
                );

            }

        }

        private void ClientDefinitionsUpdateServerMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsServer)
                {

                    switch (mCommandData.content[0])
                    {
                        default:
                            Command cmd = new Command(0, CALL_FOR_DEFS);
                            cmd.data = Encoding.Unicode.GetBytes(ExtendedSurvivalSettings.Instance.GetDataToClient());
                            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageTo(
                                NETWORK_ID_DEFINITIONS,
                                Encoding.Unicode.GetBytes(messageToSend),
                                mCommandData.sender
                            );
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ClientDefinitionsUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsClient)
                {
                    var settingsData = Encoding.Unicode.GetString(mCommandData.data);
                    ExtendedSurvivalSettings.ClientLoad(settingsData);
                    CheckDefinitions();
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        public override void LoadData()
        {
            TextAPI = new HudAPIv2();

            if (IsServer)
            {

                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();

            }

            base.LoadData();
        }

        private bool definitionsChecked = false;
        private void CheckDefinitions()
        {
            ExtendedSurvivalLogging.Instance.LogInfo(GetType(), $"CheckDefinitions Called");
            if (!definitionsChecked)
            {

                AssemblerOverride.TryOverride();

                definitionsChecked = true;
            }
        }

        protected override void UnloadData()
        {
            TextAPI.Close();

            base.UnloadData();
        }

        public override void BeforeStart()
        {
            ExtendedSurvivalCoreAPIBackend.BeforeStart();
        }

    }

}
