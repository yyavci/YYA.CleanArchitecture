using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Common;
using YYA.CleanArchitecture.Application.Repositories;
using YYA.CleanArchitecture.Persistence.Context;
using System.Linq.Expressions;

namespace YYA.CleanArchitecture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> FindById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().Where(expression).CountAsync();
        }

        public async Task<int> Count()
        {
            return await dbContext.Set<T>().CountAsync();
        }


        public async Task<T> Add(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }




        public async Task Update(T entity)
        {
            dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }



        public async Task<bool> DeleteById(int id)
        {
            var dbEntity = await dbContext.Set<T>().FindAsync(id);

            if (dbEntity == null)
                return false;

            dbContext.Set<T>().Remove(dbEntity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            var dbEntity = await dbContext.Set<T>().FindAsync(entity);
            if (dbEntity == null)
                return false;

            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var entities = await dbContext.Set<T>().Where(expression).ToListAsync();
            dbContext.Set<T>().RemoveRange(entities);
            await dbContext.SaveChangesAsync();

            return true;
        }


    }
}
