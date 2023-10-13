using OskiTest.Data.Abstract;
using OskiTest.Models;



namespace OskiTest.Data.Repositories {
    public class QuestionRepository : EntityBaseRepository<Question>, IQuestionRepository
    {

        public QuestionRepository(OskiDBContext context) : base (context) { }

      

    }
}