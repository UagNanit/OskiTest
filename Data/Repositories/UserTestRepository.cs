using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
    public class UserTestRepository : EntityBaseRepository<UserTest>, IUserTestRepository
    {

        public UserTestRepository(OskiDBContext context) : base (context) { }

      

    }
}