using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IntroMvcDemo.DataAccess.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> FetchAllAsync();

        Task<T> FetchAsync(int id);

        Task<T> FindOneAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T item, int key);

        Task<int> DeleteAsync(T item);

        Task<int> CountAsync();
    }
}
