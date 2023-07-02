using MediatR;
using Microsoft.AspNetCore.Mvc;
using YYA.OnionArchitecture.Application.Features.Auth.Commands.Login;

namespace YYA.OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [Route("Login")]
        [HttpPost()]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            return Ok(await mediator.Send(command));

        }


    }
}
