using Microsoft.AspNetCore.Http;
using TengoProject.Services.Models.RequestModels;
using TengoProject.Services.Models.ResponseModels;

namespace TengoProject.Services.Abstraction
{
    public interface ICrmService
    {
        Task<RegisterResponse> RegisterUserAsync(UserDto user);
        Task<LoginResponse> LoginUser(LoginRequestDto request);
        Task<Dictionary<byte[], byte[]>> GetHashandSalt(string mail);
        Task<UploadImageResponse> UploadImageAsync(IFormFile file);
        Task<GetAllImagesResponse> GetAllImagesAsync();
        Task<GetOneImageResponse> GetImageByIdASync(int id);
        Task<RemoveImageResponse> RemoveImageAsync(int id);
    }
}
