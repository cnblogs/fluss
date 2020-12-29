using System.Collections.Generic;

namespace Cnblogs.Fluss.Domain.Abstractions
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }

        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _events.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _events.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _events.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _events.Clear();
        }

        public virtual bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);
        }
    }
}