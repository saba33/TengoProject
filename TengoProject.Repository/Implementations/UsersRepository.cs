using System.Linq.Expressions;
using TengoProject.Domain.Abstracitions;
using TengoProject.Domain.Model;
using TengoProject.Repository.DataContext;

namespace TengoProject.Repository.Implementations
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DatabaseContext context) : base(context)
        {

        }

        public Task<IEnumerable<User>> FindUserAsync(Expression<Func<User, bool>> predicate)
        {
            return this.FindAsync(predicate);
        }
    }
}
