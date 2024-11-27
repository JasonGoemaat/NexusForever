using NexusForever.Shared;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusForever.WorldServer.Api
{
    public sealed class ApiManager : Singleton<ApiManager>, IApiManager
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        private readonly ConcurrentQueue<PendingAction> pendingActions = new();

        public ApiManager()
        {
        }

        /// <summary>
        /// Run an action during ApiManager.Update()
        /// </summary>
        /// <param name="action">The action to run</param>
        /// <returns>A task that will complete when the action finishes</returns>
        public Task Run(Action action)
        {
            PendingAction pendingAction = new PendingAction(action);
            pendingActions.Enqueue(pendingAction);
            return pendingAction.Wait();
        }

        public void Update(double lastTick)
        {
            // pull all pending actions at this point in time, more actions can continue
            // to queue while these are running but won't be processed until Update()
            // is called again
            List<PendingAction> pending = new List<PendingAction>();
            PendingAction pa = null;
            while (pendingActions.TryDequeue(out pa)) {
                pending.Add(pa);
            }

            var tasks = pending.Select(pa => pa.Run()).ToArray();
            Task.WaitAll(tasks);
        }
    }
}
