using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
