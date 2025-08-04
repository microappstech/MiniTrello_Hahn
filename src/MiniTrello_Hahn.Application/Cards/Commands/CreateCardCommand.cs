using MediatR;
using MiniTrello_Hahn.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Cards.Commands
{
    public record CreateCardCommand(DTOs.CreateCardDto createCardDto) : IRequest<Guid>;
   
    
}
