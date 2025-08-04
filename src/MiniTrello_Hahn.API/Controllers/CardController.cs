using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniTrello_Hahn.Application.Boards.Commands;
using MiniTrello_Hahn.Application.Cards.Commands;

namespace MiniTrello_Hahn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController: ControllerBase
    {
        private IMediator _mediator;
        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardCommand command)
        {
            var boardId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateCard), new { id = boardId }, null);
        }
    }
}
