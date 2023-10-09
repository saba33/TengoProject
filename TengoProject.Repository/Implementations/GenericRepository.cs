using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TengoProject.Domain.Abstracitions;
using TengoProject.Repository.DataContext;

namespace TengoProject.Repository.Implementations
{
    public class GenericRepository<T> : IGenericReoisitory<T> where T : class
    {
        private readonly DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _databaseContext.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task Add(T entity)
        {
            await _databaseContext.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _databaseContext.Set<T>().FindAsync(id);
        }


        public void Update(T entity)
        {
            _databaseContext.Update(entity);
        }
    }
}
