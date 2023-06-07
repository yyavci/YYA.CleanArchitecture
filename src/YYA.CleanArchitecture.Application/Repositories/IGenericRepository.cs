using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Common;

namespace YYA.CleanArchitecture.Application.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<T> FindById(int id);
        Task<IList<T>> GetAll();
        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression);

        Task<int> Count(Expression<Func<T, bool>> expression);
        Task<int> Count();

        Task<T> Add(T entity);
        Task Update(T entity);
        Task<bool> DeleteById(int id);
        Task<bool> Delete(T entity);
        Task<bool> Delete(Expression<Func<T, bool>> expression);

    }
}
