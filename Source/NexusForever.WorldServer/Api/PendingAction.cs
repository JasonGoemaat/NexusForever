using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NexusForever.WorldServer.Api
{
    internal class PendingAction
    {
        private readonly Action _action;
        private readonly SemaphoreSlim _semaphore;

        public PendingAction(Action action)
        {
            _action = action;
            _semaphore = new SemaphoreSlim(0, 1);
        }

        /// <summary>
        /// Called for a task that will complete when the action has run
        /// </summary>
        /// <returns></returns>
        public Task Wait()
        {
            return _semaphore.WaitAsync();
        }

        /// <summary>
        /// Run the Action from ApiManager.Update() and release the semaphore so that
        /// the api request task will complete.
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            // actually run the action
            await Task.Run(_action);

            // release the semaphore so the task the api gets from Wait() will return
            _semaphore.Release();
        }
    }
}
