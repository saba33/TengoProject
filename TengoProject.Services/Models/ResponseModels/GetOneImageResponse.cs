using TengoProject.Domain.Model;

namespace TengoProject.Services.Models.ResponseModels
{
    public class GetOneImageResponse : BaseResponse
    {
        public Image Image { get; set; }
    }
}
