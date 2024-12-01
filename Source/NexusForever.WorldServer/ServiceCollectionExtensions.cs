﻿using Microsoft.Extensions.DependencyInjection;
using NexusForever.Shared;
using NexusForever.WorldServer.Api;
using NexusForever.WorldServer.Command;

namespace NexusForever.WorldServer
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWorld(this IServiceCollection sc)
        {
            sc.AddSingletonLegacy<ICommandManager, CommandManager>();
            sc.AddSingletonLegacy<IApiManager, ApiManager>();
            sc.AddSingletonLegacy<ILoginQueueManager, LoginQueueManager>();
        }
    }
}
