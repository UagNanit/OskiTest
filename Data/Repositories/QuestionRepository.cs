using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
#pragma warning disable CS1591
    public class QuestionRepository : EntityBaseRepository<Question>, IQuestionRepository
    {

        public QuestionRepository(OskiDBContext context) : base (context) { }

      

    }
}