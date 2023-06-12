using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YYA.CleanArchitecture.Application.Products.Commands.CreateProduct;
using YYA.CleanArchitecture.Application.Products.Queries.GetAllProducts;

namespace YYA.CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMediator mediator;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }


        [Route("GetAll")]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("GetAll information log.");

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
