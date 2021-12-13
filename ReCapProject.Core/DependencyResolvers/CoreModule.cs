using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.CrossCuttingConcerns.Caching;
using ReCapProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using ReCapProject.Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReCapProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
