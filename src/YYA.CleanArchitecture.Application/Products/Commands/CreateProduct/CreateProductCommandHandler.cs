using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Application.Wrappers;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<CreateProductDto>>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ServiceResponse<CreateProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product entity = mapper.Map<Product>(request);

            entity = await productRepository.Add(entity);

            var response = mapper.Map<CreateProductDto>(entity);

            return new ServiceResponse<CreateProductDto>(response);

        }
    }
}
