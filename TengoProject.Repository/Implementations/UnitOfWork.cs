using TengoProject.Domain.Abstracitions;
using TengoProject.Repository.DataContext;

namespace TengoProject.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dataContext;

        public IUsersRepository Users { get; }
        public IImagesRepository Images { get; }
        public UnitOfWork(DatabaseContext dataContext, IUsersRepository CrmRepository, IImagesRepository images)
        {
            _dataContext = dataContext;
            Users = CrmRepository;
            Images = images;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return _dataContext.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataContext.Dispose();
            }
        }
    }
}
