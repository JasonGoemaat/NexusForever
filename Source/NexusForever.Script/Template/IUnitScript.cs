﻿using NexusForever.Game.Abstract.Combat;
using NexusForever.Game.Abstract.Entity;

namespace NexusForever.Script.Template
{
    public interface IUnitScript : IWorldEntityScript
    {
        /// <summary>
        /// Invoked when a new <see cref="IHostileEntity"/> is added to the threat list.
        /// </summary>
        void OnThreatAddTarget(IHostileEntity hostile)
        {
        }

        /// <summary>
        /// Invoked when an existing <see cref="IHostileEntity"/> is removed from the threat list.
        /// </summary>
        void OnThreatRemoveTarget(IHostileEntity hostile)
        {
        }

        /// <summary>
        /// Invoked when an existing <see cref="IHostileEntity"/> is update on the threat list.
        /// </summary>
        void OnThreatChange(IHostileEntity hostile)
        {
        }

        /// <summary>
        /// Invoked when <see cref="IUnitEntity"/> is killed.
        /// </summary>
        void OnDeath()
        {
        }
    }
}
