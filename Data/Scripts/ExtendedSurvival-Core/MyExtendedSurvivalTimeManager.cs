using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;

namespace ExtendedSurvival.Core
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class MyExtendedSurvivalTimeManager : BaseSessionComponent
    {

        private const int TIME_INTERVAL = 25;

        public static MyExtendedSurvivalTimeManager Instance { get; private set; }

        public long GameTime { get; private set; } = 0;


        private int frameCounter = 0;
        private bool canRun;
        private ParallelTasks.Task task;
        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                Instance = this;
                canRun = true;
                task = MyAPIGateway.Parallel.StartBackground(() =>
                {
                    ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"StartBackground [DoUpdateCicle START]");
                    // Loop Task to Control Game Time (MS)
                    while (canRun)
                    {
                        if (MyAPIGateway.Parallel != null)
                            MyAPIGateway.Parallel.Sleep(TIME_INTERVAL);
                        else
                            break;
                        if (frameCounter != MyAPIGateway.Session.GameplayFrameCounter)
                        {
                            frameCounter = MyAPIGateway.Session.GameplayFrameCounter;
                            GameTime += TIME_INTERVAL;
                        }
                    }
                });
            }
        }

        protected override void UnloadData()
        {
            base.UnloadData();
            canRun = false;
            task.Wait();
        }

    }

}
