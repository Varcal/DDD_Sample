using System.Collections.Generic;
using SharedKernel.DomainEvents.Events.DomainNotifications;
using SharedKernel.DomainEvents.Handlers.Base;

namespace SharedKernel.DomainEvents.Handlers.DomainNotifications
{
    public class DomainNotificationHandler: Handler<DomainNotification>
    {

        private IList<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public override void Handle(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public override void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        public override bool HasNotification()
        {
            return GetValue().Count > 0;
        }

        public override IEnumerable<DomainNotification> Notify()
        {
            return GetValue();
        }

        private IList<DomainNotification> GetValue()
        {
            return _notifications;
        }

    }
}
