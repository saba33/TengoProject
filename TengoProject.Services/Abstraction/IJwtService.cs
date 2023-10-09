namespace TengoProject.Services.Abstraction
{
    public interface IJwtService
    {
        string GenerateToken(string userId);
    }
}
