using Alias.Application.Permissions;
using Alias.Application.Roles.Commands.AddClaimToRole;
using Alias.Application.Roles.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alias.WebAPI.Controllers
{
    public class RoleController : BaseController
    {
        [Authorize(Policy = Permission.Roles.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize(Policy = Permission.Roles.Edit)]
        [HttpPost]
        public async Task<IActionResult> AddClaimToRole([FromBody] AddClaimToRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
