using FluentValidation;
using MiniTrello_Hahn.Application.Cards.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Boards.Commands
{
    public class CreateCardCommandValidator: AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            When(x => x.createCardDto != null, () =>
            {
                RuleFor(x => x.createCardDto.Title)
                    .NotEmpty().WithMessage("Card title is required.")
                    .MaximumLength(100).WithMessage("Card title must be under 100 characters.");

                RuleFor(x => x.createCardDto.Description)
                    .NotEmpty().WithMessage("Card description is required.")
                    .MaximumLength(500).WithMessage("Card description must be under 500 characters.");

                RuleFor(x => x.createCardDto.ListId)
                .NotEmpty().WithMessage("List ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("The card should be attached to Board List");
            });




        }
    }
}
