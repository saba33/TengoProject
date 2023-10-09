using System.Linq.Expressions;

namespace TengoProject.Domain.Abstracitions
{
    public interface IGenericReoisitory<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
