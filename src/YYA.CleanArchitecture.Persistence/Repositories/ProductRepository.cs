using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Entities;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Persistence.Context;

namespace YYA.CleanArchitecture.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext): base(dbContext)
        {

        }
    }
}
