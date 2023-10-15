using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
#pragma warning disable CS1591
    public class AnswerRepository : EntityBaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(OskiDBContext context) : base (context) { }

    }
}