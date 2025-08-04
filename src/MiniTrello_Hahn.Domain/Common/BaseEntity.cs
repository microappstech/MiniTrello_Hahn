using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        private List<object> _domainEvents;
        public IReadOnlyCollection<object> DomainEvents => _domainEvents?.AsReadOnly();

        protected void AddDomainEvent(object domainEvent)
        {
            _domainEvents ??= new List<object>();
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()=>
            _domainEvents?.Clear();
    }
}
