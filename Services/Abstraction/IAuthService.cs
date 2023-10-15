using OskiTest.Models.ViewModels;
using OskiTest.Models;


namespace OskiTest.Services.Abstraction
{
    #pragma warning disable CS1591
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthData GetAuthData(User user);
    }
}