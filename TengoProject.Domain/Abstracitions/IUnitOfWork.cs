namespace TengoProject.Domain.Abstracitions
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        IImagesRepository Images { get; }
        int Save();
    }
}
