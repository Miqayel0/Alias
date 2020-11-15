using Alias.Application.Games.Commands.Create;
using Alias.Application.Games.Queries.AddPage;
using Alias.Application.Games.Queries.Create;
using Alias.Application.Games.Queries.MarkeWord;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alias.WebAPI.Controllers
{
    public class GameController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CreateGameResult>> Create([FromBody] CreateGameCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPage([FromBody] AddPageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> MarkWord([FromBody] MarkeWordCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
