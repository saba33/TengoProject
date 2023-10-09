using TengoProject.Domain.Model;

namespace TengoProject.Services.Models.ResponseModels
{
    public class GetAllImagesResponse : BaseResponse
    {
        public List<Image> Images { get; set; }
    }
}
