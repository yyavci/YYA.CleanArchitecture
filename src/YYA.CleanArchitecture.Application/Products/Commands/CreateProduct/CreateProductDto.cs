using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Mappings;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Application.Products.Commands.CreateProduct
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
