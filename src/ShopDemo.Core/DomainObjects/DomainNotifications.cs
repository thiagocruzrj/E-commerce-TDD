using MediatR;
using ShopDemo.Core.Messages;
using System;

namespace ShopDemo.Core.DomainObjects
{
    public class DomainNotifications : Message, INotification
    {
        public DomainNotifications(string key, string value)
        {
            Timestamp = DateTime.Now;
            DomainNotificaionId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificaionId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }
}
