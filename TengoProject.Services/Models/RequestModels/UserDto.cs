using TengoProject.Services.Infrastructure.Attributes;

namespace TengoProject.Services.Models.RequestModels
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailValidator(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
