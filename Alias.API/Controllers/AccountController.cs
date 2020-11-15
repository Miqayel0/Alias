using Alias.Application.Account.Commands.Login;
using Alias.Application.Account.Commands.Register;
using Alias.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alias.WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
