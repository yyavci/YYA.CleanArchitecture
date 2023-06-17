using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYA.CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using YYA.CleanArchitecture.Application.Products.Queries.GetAllProducts;

namespace YYA.CleanArchitecture.WebApi.Controllers
{
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
