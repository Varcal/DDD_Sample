using Infra.Data.Contexts;
using Infra.Data.UnitOfWork;
using SharedKernel.DomainEvents.Events.DomainNotifications;
using SharedKernel.DomainEvents.Handlers.Base;
using SharedKernel.DomainEvents.Handlers.DomainNotifications;
using SimpleInjector;

namespace CrossCutting.Ioc.Configurations
{
    internal class Bootstraper
    {
        internal static void RegisterServices(Container container)
        {

            #region Application Services

            #endregion

            #region Domain Services

            #endregion

            #region Domain Events
            container.Register<Handler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            #endregion

            #region Repositories
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            #endregion

            #region Contexts
            container.Register<EfContext>(Lifestyle.Scoped);
            container.Register<AdoContext>(Lifestyle.Scoped);
            #endregion
        }
    }
}
