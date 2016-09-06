using Infra.Data.Contexts;
using SimpleInjector;

namespace CrossCutting.Ioc.Configurations
{
    class Bootstraper
    {
        internal static void RegisterServices(Container container)
        {

            #region Application Services

            #endregion

            #region Domain Services

            #endregion

            #region Repositories

            #endregion

            #region Contexts
            container.Register<EfContext>(Lifestyle.Scoped);
            container.Register<AdoContext>(Lifestyle.Scoped);
            #endregion
        }
    }
}
