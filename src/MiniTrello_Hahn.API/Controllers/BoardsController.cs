using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniTrello_Hahn.Application.Boards.Commands;
using MiniTrello_Hahn.Application.Boards.Queries;

namespace MiniTrello_Hahn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private IMediator _mediator;
        public BoardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardCommand command)
        {
            var boardId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateBoard), new { id = boardId }, null);
        }
        [HttpGet]
        public async Task<IActionResult> GetBoards()
        {
            var boards = await _mediator.Send(new GetAllBoardsQuery());
            return Ok(boards);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(Guid id)
        {

            return Ok();
        }
    }
}
