using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Mappings;
using YYA.OnionArchitecture.Domain.Entities;

namespace YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, CreateProductDto>();
        }
    }
}
