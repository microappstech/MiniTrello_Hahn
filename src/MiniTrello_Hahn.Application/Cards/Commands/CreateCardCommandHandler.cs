using AutoMapper;
using MediatR;
using MiniTrello_Hahn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTrello_Hahn.Domain.Entities;

namespace MiniTrello_Hahn.Application.Cards.Commands
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = Card.Create(request.createCardDto.Title, request.createCardDto.Description, request.createCardDto.ListId);
            await _unitOfWork.Cards.AddAsync(card);
            await _unitOfWork.SaveAsync();
            return card.Id;
        }
    }
}
