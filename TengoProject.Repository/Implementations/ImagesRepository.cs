using TengoProject.Domain.Abstracitions;
using TengoProject.Domain.Model;
using TengoProject.Repository.DataContext;

namespace TengoProject.Repository.Implementations
{
    public class ImagesRepository : GenericRepository<Image>, IImagesRepository
    {
        public ImagesRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
