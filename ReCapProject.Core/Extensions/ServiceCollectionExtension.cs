using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollections, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollections);
            }

            return ServiceTool.Create(serviceCollections);
        }
    }
}
