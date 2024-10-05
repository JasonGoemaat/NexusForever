﻿using Microsoft.Extensions.DependencyInjection;
using NexusForever.Game.Abstract.Event;
using NexusForever.Game.Abstract.Map;
using NexusForever.Game.Event;
using NexusForever.Game.Map.Instance;
using NexusForever.Game.Map.Lock;
using NexusForever.Game.Map.Search;
using NexusForever.Shared;

namespace NexusForever.Game.Map
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGameMap(this IServiceCollection sc)
        {
            sc.AddGameMapInstance();
            sc.AddGameMapSearch();
            sc.AddGameMapLock();

            sc.AddTransient<IPublicEventManager, PublicEventManager>();

            sc.AddSingletonLegacy<IEntityCacheManager, EntityCacheManager>();
            sc.AddSingletonLegacy<IMapIOManager, MapIOManager>();
            sc.AddSingletonLegacy<IMapManager, MapManager>();

            sc.AddTransient<IMapFactory, MapFactory>();
            sc.AddSingleton<IFactoryInterface<IMap>, FactoryInterface<IMap>>();
            sc.AddTransient<IBaseMap, BaseMap>();
        }
    }
}
