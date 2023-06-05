using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Domain.Common;

namespace YYA.CleanArchitecture.Domain.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task<IList<T>> GetAll();
        Task<T> FindById(int id);
        

    }
}
