using OskiTest.Models;
using System.Security.Claims;

namespace OskiTest.Data.Abstract
{
#pragma warning disable CS1591
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsUsernameUniq(string username);
        bool isEmailUniq(string email);
        bool isAdmin(string id);
    }
}