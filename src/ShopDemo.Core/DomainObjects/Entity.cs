using ShopDemo.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private List<Event> _notifications;
        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

        public void AddEvents(Event evento)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(evento);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void CleanEvents()
        {
            _notifications?.Clear();
        }
    }
}
