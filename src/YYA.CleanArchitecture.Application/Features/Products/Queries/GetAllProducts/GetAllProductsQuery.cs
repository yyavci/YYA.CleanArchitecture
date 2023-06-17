using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Application.Wrappers;

namespace YYA.CleanArchitecture.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<IList<GetAllProductsDto>>>
    {



    }
}
