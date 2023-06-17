using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Application.Wrappers;

namespace YYA.CleanArchitecture.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<IList<GetAllProductsDto>>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<IList<GetAllProductsDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException($"{nameof(request)} cannot be null!");

            var entities = await productRepository.GetAll();

            var response = mapper.Map<IList<GetAllProductsDto>>(entities);

            return new ServiceResponse<IList<GetAllProductsDto>>(response);

        }

    }
}
