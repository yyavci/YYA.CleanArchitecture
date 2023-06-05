using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Entities;

namespace YYA.CleanArchitecture.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
            (
                new Product() { Id = 1, Name = "Ürün 1", CreatedOnUtc = DateTime.UtcNow, UpdatedOnUtc = DateTime.UtcNow }
            );


            base.OnModelCreating(modelBuilder);
        }


    }
}
