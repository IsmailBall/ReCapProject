using Castle.DynamicProxy;
using ReCapProject.Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Ioc;

namespace ReCapProject.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
