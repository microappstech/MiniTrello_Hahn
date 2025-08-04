using MiniTrello_Hahn.Domain.Common;
using MiniTrello_Hahn.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Entities
{
    public class Card:BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Guid ListId { get; set; }
        [ForeignKey("ListId")]
        public BoardList BoardList { get; set; }
        public static Card Create(string title, string description, Guid ListId)
        {
            var card = new Card
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                ListId = ListId
            };
            card.AddDomainEvent(new CardCreatedEvent(card));
            return card;
        }
    }
}
