using System.ComponentModel.DataAnnotations;

namespace TengoProject.Services.Models.RequestModels
{
    public class LoginRequestDto
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
