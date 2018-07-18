namespace JWTAuthServer.Services
{
    public interface ITokenGenerator
    {
        string GetJwtToken(string userId);
    }
}
