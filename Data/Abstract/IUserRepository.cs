using OskiTest.Models;
using System.Security.Claims;

namespace OskiTest.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsUsernameUniq(string username);
        bool isEmailUniq(string email);
        bool isAdmin(string id);
    }
}