using IntroMvcDemo.Common;
using IntroMvcDemo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IntroMvcDemo.DataAccess
{
    public class DataRepository<T>
        : IDataRepository<T>
        where T : class
    {
        protected DbContext DataContext { get; set; }

        public DataRepository(DbContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public async Task<IEnumerable<T>> FetchAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public async Task<T> FetchAsync(int id)
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> expression)
        {
            return await DataContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await DataContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> AddAsync(T item)
        {
            DataContext.Set<T>().Add(item);
            await DataContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item, int key)
        {
            Arg.IsNotNull(() => item);

            T existing = await DataContext.Set<T>().FindAsync(key);
            if (existing != null)
            {
                DataContext.Entry(existing).CurrentValues.SetValues(item);
                await DataContext.SaveChangesAsync();
            }

            return existing;
        }

        public async Task<int> DeleteAsync(T item)
        {
            DataContext.Set<T>().Remove(item);
            return await DataContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await DataContext.Set<T>().CountAsync();
        }
    }
}
