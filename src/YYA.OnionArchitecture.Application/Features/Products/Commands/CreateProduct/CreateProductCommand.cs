using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Mappings;
using YYA.OnionArchitecture.Application.Repositories;
using YYA.OnionArchitecture.Application.Wrappers;
using YYA.OnionArchitecture.Domain.Entities;

namespace YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct
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
