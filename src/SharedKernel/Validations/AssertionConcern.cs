using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SharedKernel.DomainEvents;
using SharedKernel.DomainEvents.Events.DomainNotifications;

namespace SharedKernel.Validations
{
    public static class AssertionConcern
    {
        public static bool IsValid(params DomainNotification[] validations)
        {
            var notifycationNotNull = validations.Where(validation => validation != null);
            var domainNotifications = notifycationNotNull as IList<DomainNotification> ?? notifycationNotNull.ToList();
            NotifyAll(domainNotifications);
            return domainNotifications.Count().Equals(0);
        }

        public static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation => { DomainEvent.Raise(validation); });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue.Trim().Length;

            return (length < minimum || length > maximum)
                ? new DomainNotification("AssertArgumentLength", message)
                : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue))
                ? new DomainNotification("AssertArgumentLength", message)
                : null;
        }

        public static DomainNotification AssertNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue))
                ? new DomainNotification("AssertArgumentNotEmpty", message)
                : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {
            return (object1 == null)
                ? new DomainNotification("AssertArgumentNotNull", message)
                : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue)
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            return (value != match)
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 > value2))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }
    }
}