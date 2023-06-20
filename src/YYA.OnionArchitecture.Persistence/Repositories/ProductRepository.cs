using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Domain.Entities;
using YYA.OnionArchitecture.Application.Repositories;
using YYA.OnionArchitecture.Persistence.Context;

namespace YYA.OnionArchitecture.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(AppDbContext dbContext): base(dbContext)
        {

        }
    }
}
