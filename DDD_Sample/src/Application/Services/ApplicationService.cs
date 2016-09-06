using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.UnitOfWork;
using SharedKernel.DomainEvents;
using SharedKernel.DomainEvents.Events.DomainNotifications;
using SharedKernel.DomainEvents.Handlers.Base;

namespace Application.Services
{
    public abstract class ApplicationService
    {
        private readonly Handler<DomainNotification> _notifications;
        private readonly IUnitOfWork _uow;

        protected ApplicationService(IUnitOfWork uow)
        {
            _notifications = DomainEvent.Container.GetService<Handler<DomainNotification>>();
            _uow = uow;
        }

        public void BeginTran()
        {
            _uow.BeginTran();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public void RollBack()
        {
            _uow.Rollback();
        }

        public bool Save()
        {
            if (_notifications.HasNotification())
                return false;

            _uow.Save();
            return true;
        }
    }
}
