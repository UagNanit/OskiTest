using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
#pragma warning disable CS1591
    public class TestRepository : EntityBaseRepository<Test>, ITestRepository
    {

        public TestRepository(OskiDBContext context) : base (context) { }

      

    }
}