using MediatR;
using MiniTrello_Hahn.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.BoardList.Queries
{
    public record GetAllBoardListsQuery : IRequest<IEnumerable<BoardListDto>>;
}
