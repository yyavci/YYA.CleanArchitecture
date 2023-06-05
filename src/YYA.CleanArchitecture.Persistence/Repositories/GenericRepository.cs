using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Common;
using YYA.CleanArchitecture.Domain.Repositories;
using YYA.CleanArchitecture.Persistence.Context;

namespace YYA.CleanArchitecture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> FindById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);   
        }

        public async Task<IList<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
    }
}
