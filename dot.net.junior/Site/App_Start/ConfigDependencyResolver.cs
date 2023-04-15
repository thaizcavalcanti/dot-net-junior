using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Site
{
    public class ConfigDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public ConfigDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}