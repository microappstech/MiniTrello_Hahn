using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniTrello_Hahn.Application.BoardList.Commands;
using MiniTrello_Hahn.Application.BoardList.Queries;
using MiniTrello_Hahn.Application.Boards.Commands;
using MiniTrello_Hahn.Application.Boards.Queries;

namespace MiniTrello_Hahn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardListController: ControllerBase
    {
        private IMediator _mediator;
        public BoardListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoardList([FromBody] CreateBoardListCommand command)
        {
            var boardListId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateBoardList), new { id = boardListId }, null);
        }
        [HttpGet]
        public async Task<IActionResult> GetBoardLists()
        {
            IEnumerable<Application.DTOs.BoardListDto>? boardLists = await _mediator.Send(new GetAllBoardListsQuery());
            return Ok(boardLists);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardList(Guid id)
        {

            return Ok();
        }

    }
}
