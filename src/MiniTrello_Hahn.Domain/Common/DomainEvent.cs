using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Common
{
    public class DomainEvent:IDomainEvent
    {
        public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
    }
}
