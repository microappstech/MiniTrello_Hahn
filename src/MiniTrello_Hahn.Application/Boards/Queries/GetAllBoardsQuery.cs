using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using MiniTrello_Hahn.Application.DTOs;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Boards.Queries
{
    
    public record GetAllBoardsQuery : IRequest<IEnumerable<BoardDto>>;
}
