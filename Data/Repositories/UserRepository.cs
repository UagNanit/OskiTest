using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
#pragma warning disable CS1591
    public class UserRepository : EntityBaseRepository<User>, IUserRepository {

        public UserRepository (OskiDBContext context) : base (context) { }

        public bool isEmailUniq (string email) {
            var user = GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq (string username) {
            var user = GetSingle(u => u.UserName == username);
            return user == null;
        }

        public bool isAdmin(string id)
        {
            var user = GetSingle(u => u.Id == id, u=>u.Role);
            return user.Role.RoleName == "admin";
        }

    }
}