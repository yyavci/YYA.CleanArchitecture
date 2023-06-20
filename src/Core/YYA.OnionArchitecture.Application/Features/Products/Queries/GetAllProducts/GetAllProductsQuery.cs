using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Repositories;
using YYA.OnionArchitecture.Application.Wrappers;

namespace YYA.OnionArchitecture.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<IList<GetAllProductsDto>>>
    {



    }
}
