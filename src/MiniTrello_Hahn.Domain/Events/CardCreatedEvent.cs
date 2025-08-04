using MiniTrello_Hahn.Domain.Common;
using MiniTrello_Hahn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Events
{
    public class CardCreatedEvent:DomainEvent
    {
        public Card Card { get; }


        public CardCreatedEvent(Card card)
        {
            Card = card;
        }

    }
}
