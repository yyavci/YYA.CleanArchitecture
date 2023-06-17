using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Mappings;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Application.Wrappers;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<CreateProductDto>>, IMapFrom<Product>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductCommand, Product>();
        }




    }
}
