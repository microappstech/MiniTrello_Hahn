using MiniTrello_Hahn.Domain.Common;
using MiniTrello_Hahn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Events
{
    public class BoardListCreatedEvent : DomainEvent
    {
        public BoardList BoardList { get; }


        public BoardListCreatedEvent(BoardList boardList)
        {
            BoardList = boardList;
        }

    }
}
