using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
#pragma warning disable CS1591
    public class UserTestRepository : EntityBaseRepository<UserTest>, IUserTestRepository
    {

        public UserTestRepository(OskiDBContext context) : base (context) { }

      

    }
}