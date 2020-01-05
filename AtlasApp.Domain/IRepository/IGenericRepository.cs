using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtlasApp.Domain.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(string id);

        Task Update(T model);

        Task Create(T model);

        Task Delete(string id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Query(Expression<Func<T, bool>> filter);
    }
}