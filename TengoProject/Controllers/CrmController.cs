using Microsoft.AspNetCore.Mvc;
using TengoProject.Services.Abstraction;
using TengoProject.Services.Models.RequestModels;
using TengoProject.Services.Models.ResponseModels;

namespace TengoProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrmController : ControllerBase
    {
        private readonly ICrmService _crmSercive;
        public CrmController(ICrmService crmServices)
        {
            _crmSercive = crmServices;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginRequestDto request)
        {
            var result = await _crmSercive.LoginUser(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterResponse>> RegisterAsync(UserDto request)
        {
            var result = await _crmSercive.RegisterUserAsync(request);
            return Ok(result);
        }

        [HttpPost("UploadImage")]
        public async Task<ActionResult<UploadImageResponse>> UploadImageAsync(IFormFile file)
        {
            return await _crmSercive.UploadImageAsync(file);
        }

        [HttpGet("GetImageById")]
        public async Task<ActionResult<GetOneImageResponse>> GetImageByIdAsync(int id)
        {
            return await _crmSercive.GetImageByIdASync(id);
        }

        [HttpGet("GetAllImages")]
        public async Task<ActionResult<GetAllImagesResponse>> GetAllImagesAsync()
        {
            return await _crmSercive.GetAllImagesAsync();
        }

        [HttpGet("RemoveImage")]
        public async Task<ActionResult<RemoveImageResponse>> GetImageById(int id)
        {
            return await _crmSercive.RemoveImageAsync(id);
        }
    }
}

