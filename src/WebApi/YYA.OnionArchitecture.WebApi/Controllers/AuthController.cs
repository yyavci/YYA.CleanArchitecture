using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYA.OnionArchitecture.Application.Features.Products.Queries.GetAllProducts;
using YYA.OnionArchitecture.Middleware.Authentication;

namespace YYA.OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }


        [Route("Authenticate")]
        [HttpPost()]
        public IActionResult Authenticate(string email , string password)
        {

            //TODO validate email & pass from db
            var token = authService.GenerateJwtToken(email);
            return Ok(token);

        }


    }
}
