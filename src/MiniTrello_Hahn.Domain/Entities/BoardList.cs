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
    public class BoardList:BaseEntity
    {
        public string Title { get; set; }
        public Guid BoardId { get; set; }
        [ForeignKey("BoardId")]
        public Board Board { get; set; }
        public List<Card> Cards { get; set; } = new();
        public static BoardList Create(string title, Guid boardId)
        {
            var boardList = new BoardList
            {
                Id = Guid.NewGuid(),
                Title = title,
                BoardId = boardId
            };
            boardList.AddDomainEvent(new BoardListCreatedEvent(boardList));
            return boardList;
        }
    }
}
