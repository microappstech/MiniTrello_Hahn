using AutoMapper;
using MediatR;
using MiniTrello_Hahn.Application.Boards.Queries;
using MiniTrello_Hahn.Application.DTOs;
using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.BoardList.Queries
{
    public class GetAllBoardListsQueryHandler : IRequestHandler<GetAllBoardListsQuery, IEnumerable<BoardListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBoardListsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BoardListDto>> Handle(GetAllBoardListsQuery request, CancellationToken cancellationToken)
        {
            var boardLists = await _unitOfWork.BoardLists.GetAllAsync();
            return _mapper.Map<IEnumerable<BoardListDto>>(boardLists);
        }
    }
}
