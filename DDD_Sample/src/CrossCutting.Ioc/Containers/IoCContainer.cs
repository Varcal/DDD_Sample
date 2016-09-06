using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharedKernel.DomainEvents.Contracts;

namespace CrossCutting.Ioc.Containers
{
    public class IoCContainer: IContainer
    {
        private readonly IDependencyResolver _resolver;

        public IoCContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public T GetService<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}
