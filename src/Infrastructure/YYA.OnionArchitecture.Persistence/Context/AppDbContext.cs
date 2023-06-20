using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Domain.Entities;

namespace YYA.OnionArchitecture.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            using (var context = this)
            {
                context.Database.EnsureCreated();
                context.Products.Add(new Product() { Id = 1, Name = "Ürün 1", CreatedOnUtc = DateTime.UtcNow, UpdatedOnUtc = DateTime.UtcNow });
                context.SaveChanges();
            }
            */
            //modelBuilder.Entity<Product>().HasData
            //(
            //    new Product() { Id = 1, Name = "Ürün 1", CreatedOnUtc = DateTime.UtcNow, UpdatedOnUtc = DateTime.UtcNow }
            //);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }


    }
}
