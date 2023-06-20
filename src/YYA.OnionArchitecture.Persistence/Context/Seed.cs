using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Domain.Entities;

namespace YYA.OnionArchitecture.Persistence.Context
{
    public class Seed
    {
        public void SeedData(AppDbContext context) 
        {
            context.Products.Add(new Product() 
            {
                Id = 1,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                Name = "Ürün 1"
            });

            context.Products.Add(new Product()
            {
                Id = 2,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                Name = "Ürün 2"
            });


            context.SaveChanges();
        }

    }
}
