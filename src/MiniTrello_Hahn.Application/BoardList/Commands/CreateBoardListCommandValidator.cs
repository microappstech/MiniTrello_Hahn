using FluentValidation;
using MiniTrello_Hahn.Application.Boards.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.BoardList.Commands
{
    public class CreateBoardListCommandValidator : AbstractValidator<CreateBoardListCommand>
    {
        public CreateBoardListCommandValidator()
        {
            RuleFor(x => x.dtoCreateBoardList.Title)
                .NotEmpty().WithMessage("Each item iin the board should have title.")
                .MaximumLength(100).WithMessage("Board name must be under 100 characters.");
            RuleFor(x => x.dtoCreateBoardList.BoardId)
                .NotEmpty().WithMessage("Board ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Board ID cannot be an empty GUID.");

        }
    }
}
