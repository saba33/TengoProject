using System.Linq.Expressions;
using TengoProject.Domain.Model;

namespace TengoProject.Domain.Abstracitions
{
    public interface IUsersRepository : IGenericReoisitory<User>
    {
        Task<IEnumerable<User>> FindUserAsync(Expression<Func<User, bool>> predicate);
    }
}
