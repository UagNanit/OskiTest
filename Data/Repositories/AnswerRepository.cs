using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
    public class AnswerRepository : EntityBaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(OskiDBContext context) : base (context) { }

    }
}