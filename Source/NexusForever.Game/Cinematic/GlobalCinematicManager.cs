﻿using NexusForever.Game.Abstract.Cinematic;
using NexusForever.Shared;

namespace NexusForever.Game.Cinematic
{
    public class GlobalCinematicManager : Singleton<GlobalCinematicManager>, IGlobalCinematicManager
    {
        /// <summary>
        /// Id to be assigned to the next Cinematic.
        /// </summary>
        public uint NextCinematicId => nextCinematicId++;

        private uint nextCinematicId = 1073743000;

        public GlobalCinematicManager()
        {
        }

        /// <summary>
        /// Initialises the <see cref="GlobalCinematicManager"/>.
        /// </summary>
        public void Initialise()
        {
            // Deliberately left empty
        }
    }
}
