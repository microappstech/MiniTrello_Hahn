using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Boards.Commands
{
    public class CreateBoardCommandValidator: AbstractValidator<CreateBoardCommand>
    {
        public CreateBoardCommandValidator()
        {
            RuleFor(x => x.dtoBoard.Name)
                .NotEmpty().WithMessage("Board name is required.")
                .MaximumLength(100).WithMessage("Board name must be under 100 characters.");
            
        }
    }
}
