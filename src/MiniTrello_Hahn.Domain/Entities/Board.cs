using MiniTrello_Hahn.Domain.Common;
using MiniTrello_Hahn.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public List<BoardList> Lists { get; set; } = new();

        public static Board Create(string title)
        {
            var board = new Board
            {
                Id = Guid.NewGuid(),
                Name = title,
            };
            board.AddDomainEvent(new BoardCreatedEvent(board));
            return board;
        }
    }
}
