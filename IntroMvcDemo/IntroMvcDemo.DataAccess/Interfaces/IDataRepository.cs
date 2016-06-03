using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IntroMvcDemo.DataAccess.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> FetchAllAsync();

        Task<IEnumerable<T>> FetchAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T> FetchAsync(int id);

        Task<T> FindOneAsync(Expression<Func<T, bool>> expression);

        Task<T> FindOneAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T item, int key);

        Task<int> DeleteAsync(T item);

        Task<int> CountAsync();
    }
}
