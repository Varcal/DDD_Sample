using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace CrossCutting.Ioc.Configurations
{
    public class SimpleInjectorInitializer
    {
        private static Container _container;

        public static void Initialize()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle(true);

            InitializeContainer(_container);

            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _container.RegisterMvcIntegratedFilterProvider();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
            _container.Verify();
        }

        private static void InitializeContainer(Container container)
        {
            Bootstraper.RegisterServices(container);
        }
    }
}
