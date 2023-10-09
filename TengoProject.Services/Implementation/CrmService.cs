using Microsoft.AspNetCore.Http;
using TengoProject.Domain.Abstracitions;
using TengoProject.Domain.Model;
using TengoProject.Services.Abstraction;
using TengoProject.Services.Models.RequestModels;
using TengoProject.Services.Models.ResponseModels;

namespace TengoProject.Services.Implementation
{
    public class CrmService : ICrmService
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUnitOfWork _unit;
        private readonly IJwtService _jwtService;
        public CrmService(IPasswordHasher hasher, IUnitOfWork unit, IJwtService jwtService)
        {
            _hasher = hasher;
            _unit = unit;
            _jwtService = jwtService;
        }

        public async Task<GetAllImagesResponse> GetAllImagesAsync()
        {
            var result = await _unit.Images.GetAllAsync();
            var response = new GetAllImagesResponse
            {
                Images = result.ToList(),
                Message = "Images Images succesfully returned",
                StatusCode = StatusCodes.Status200OK
            };
            return response;
        }

        public async Task<Dictionary<byte[], byte[]>> GetHashandSalt(string mail)
        {
            byte[] passHash;
            byte[] passSalt;
            var result = new Dictionary<byte[], byte[]>();
            var user = (await _unit.Users.FindAsync(p => p.Equals(mail))).FirstOrDefault();

            if (user != null)
            {
                passHash = user.PasswordHash;
                passSalt = user.PasswordSalt;
                result.Add(passHash, passSalt);
                return result;
            }

            return result;
        }

        public async Task<GetOneImageResponse> GetImageByIdASync(int id)
        {
            var result = await _unit.Images.GetById(id);
            return new GetOneImageResponse
            {
                Image = result,
                Message = "Image succesfully returned",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<LoginResponse> LoginUser(LoginRequestDto request)
        {
            var user = (await _unit.Users.FindAsync(u => u.Email == request.Mail))
                .FirstOrDefault();

            if (user == null)
            {
                return new LoginResponse { StatusCode = StatusCodes.Status400BadRequest, Token = null, Message = "მეილი ან პაროლი არასწორია გთხოვთ გადაამოწმოთ" };
            }

            if (!_hasher.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponse { StatusCode = StatusCodes.Status400BadRequest, Token = null, Message = "მეილი ან პაროლი არასწორია გთხოვთ გადაამოწმოთ" };
            }

            var token = _jwtService.GenerateToken(user.Id.ToString());

            return new LoginResponse
            {
                Token = token,
                Message = "ტოკენი წარმატებით დაგენერირდა",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<RegisterResponse> RegisterUserAsync(UserDto request)
        {
            _hasher.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                LastName = request.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _unit.Users.Add(user);
            _unit.Save();
            return new RegisterResponse
            {
                Message = "Registration was Sucessfull",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<RemoveImageResponse> RemoveImageAsync(int id)
        {
            var result = await GetImageByIdASync(id);
            _unit.Images.Delete(result.Image);
            return new RemoveImageResponse { Id = id };
        }

        public async Task<UploadImageResponse> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new UploadImageResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "ivalid File!"
                };

            }
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    var image = new Image
                    {
                        Title = "Image Name",
                        ImageData = imageData
                    };

                    await _unit.Images.Add(image);
                    _unit.Save();

                    return new UploadImageResponse { StatusCode = StatusCodes.Status200OK, Message = "image Uploaded" };
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
