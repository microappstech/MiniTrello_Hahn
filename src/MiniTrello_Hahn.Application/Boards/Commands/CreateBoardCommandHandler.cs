using AutoMapper;
using MediatR;
using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTrello_Hahn.Domain.Entities;

namespace MiniTrello_Hahn.Application.Boards.Commands
{
    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBoardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = Board.Create(request.dtoBoard.Name);
            await _unitOfWork.Boards.AddAsync(board);
            await _unitOfWork.SaveAsync();
            return board.Id;
        }
    }
}
