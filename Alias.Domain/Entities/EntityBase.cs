using MediatR;
using System;
using System.Collections.Generic;

namespace Alias.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedDt { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime UpdatedDt { get; protected set; }
        public bool IsDeleted { get; set; }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        #region Private fields

        private readonly List<INotification> _domainEvents = new List<INotification>();

        public void TrackAdd(string createdBy, DateTime createdDt)
        {
            CreatedBy = createdBy;
            CreatedDt = createdDt;
        }

        public void TrackEdit(string updatedBy, DateTime updatedDt)
        {
            UpdatedBy = updatedBy;
            UpdatedDt = updatedDt;
        }

        #endregion Private fields
    }
}
