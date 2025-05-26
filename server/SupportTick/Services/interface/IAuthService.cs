namespace SupportTick.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email);

    }
}
