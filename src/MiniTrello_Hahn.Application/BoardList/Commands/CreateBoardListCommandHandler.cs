using AutoMapper;
using MediatR;
using MiniTrello_Hahn.Application.Boards.Commands;
using MiniTrello_Hahn.Domain.Entities;
using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.BoardList.Commands
{
    public class CreateBoardListCommandHandler : IRequestHandler<CreateBoardListCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBoardListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateBoardListCommand request, CancellationToken cancellationToken)
        {
            var boardList = MiniTrello_Hahn.Domain.Entities.BoardList.Create(request.dtoCreateBoardList.Title, request.dtoCreateBoardList.BoardId);

            await _unitOfWork.BoardLists.AddAsync(boardList);
            await _unitOfWork.SaveAsync();
            return boardList.Id;
        }
    }
}
