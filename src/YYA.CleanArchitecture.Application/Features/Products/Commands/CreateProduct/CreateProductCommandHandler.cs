using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Extensions;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Application.Wrappers;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<CreateProductDto>>
    {
        private readonly IValidator<CreateProductCommand> validator;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IValidator<CreateProductCommand> validator,IMapper mapper, IProductRepository productRepository)
        {
            this.validator = validator;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ServiceResponse<CreateProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentNullException($"{nameof(request)} cannot be null!");

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult != null && !validationResult.IsValid)
                return new ServiceResponse<CreateProductDto>().Fail(validationResult.ValidationErrors());

            Product entity = mapper.Map<Product>(request);

            entity = await productRepository.Add(entity);

            var response = mapper.Map<CreateProductDto>(entity);

            return new ServiceResponse<CreateProductDto>(response);

        }
    }
}
