using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYA.OnionArchitecture.Application.Features.Auth.Commands.Login;
using YYA.OnionArchitecture.Application.Features.Products.Queries.GetAllProducts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
