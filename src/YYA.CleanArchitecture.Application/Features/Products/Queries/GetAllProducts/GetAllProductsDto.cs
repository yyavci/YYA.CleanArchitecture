using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Mappings;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetAllProductsDto>();
        }
    }
}
