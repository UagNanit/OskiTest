using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
    public class TestRepository : EntityBaseRepository<Test>, ITestRepository
    {

        public TestRepository(OskiDBContext context) : base (context) { }

      

    }
}