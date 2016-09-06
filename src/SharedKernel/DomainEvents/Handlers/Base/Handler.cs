using System;
using System.Collections.Generic;
using SharedKernel.DomainEvents.Contracts;

namespace SharedKernel.DomainEvents.Handlers.Base
{
    public abstract class Handler<T> : IDisposable where T : IDomainEvent
    {
        public abstract void Handle(T args);

        public virtual IEnumerable<T> Notify()
        {
            return null;
        }

        public virtual bool HasNotification()
        {
            return false;
        }

        public abstract void Dispose();
    }
}
