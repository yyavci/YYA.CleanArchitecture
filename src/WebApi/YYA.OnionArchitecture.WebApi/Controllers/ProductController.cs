using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct;
using YYA.OnionArchitecture.Application.Features.Products.Queries.GetAllProducts;

namespace YYA.OnionArchitecture.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [Route("GetAll")]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();

            return Ok(await mediator.Send(query));
            
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }


    }
}
