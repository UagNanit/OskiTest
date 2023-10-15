using System;
using OskiTest.Services.Abstraction;
using OskiTest.Models.ViewModels;
using OskiTest.Data.Abstract;
using OskiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OskiTest.Data.Repositories;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using OskiTest.Services;

namespace OskiTest.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TestController: ControllerBase
    {
#pragma warning disable CS1591

        IUserRepository userRepository;
        ITestRepository testRepository;
        IUserTestRepository userTestRepository;
        IQuestionRepository questionRepository;
        IAnswerRepository answerRepository;

        public TestController( IUserRepository userRepository, IUserTestRepository userTestRepository, ITestRepository testRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
           
            this.userRepository = userRepository;
            this.testRepository = testRepository;
            this.userTestRepository = userTestRepository;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }
#pragma warning restore CS1591

        /// <summary>
        /// Get information about user.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns></returns>
        /// <response code="200">Successful execution</response>
        /// <response code="400">Error API</response>
        [Route("user/{id}")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserViewModel> GetUserData(string id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = userRepository.GetSingle(id);

                if (user == null)
                {
                    return BadRequest(new { id = "user do not exist" });
                }

                var ut = userTestRepository.AllIncluding(t => t.UserId == user.Id);
                var t = testRepository.AllIncluding(s => ut.Any(u => u.TestId == s.Id));
                var vtm = t.Join(ut, u => u.Id, c => c.TestId, (u, c) => new TestViewModel
                {
                    Id = u.Id,
                    TestName = u.TestName,
                    Description = u.Description,
                    TestScore = c.TestScore
                }).ToList();

                UserViewModel userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Tests = vtm
                };

                return userViewModel;

            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }


        /// <summary>
        /// Get test questions and answers variants.
        /// </summary>
        /// <param name="id">Test ID</param>
        /// <returns></returns>
        /// <response code="200">Successful execution</response>
        /// <response code="400">Error API</response>
        [Route("test/{id}")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(typeof(QuestionsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<QuestionsViewModel>> GetTestData(string id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var questions = questionRepository.AllIncluding(x => x.TestId == id).Select(x =>
                new QuestionsViewModel
                {
                    Id = x.Id,
                    TextQuestion = x.TextQuestion,
                    Answers = answerRepository.AllIncluding(a => a.QuestionId == x.Id).Select(s =>
                new AnswerViewModel { Id = s.Id, TextAnswer = s.TextAnswer, QuestionId = s.QuestionId }).ToList()
                }).ToList();

                if (questions == null)
                {
                    return BadRequest(new { id = "Id do not exist" });
                }

                return questions;
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }

        /// <summary>
        /// Method accepts the user answers to the test and returns the result.
        /// And writes the result to the database.
        /// </summary>
        /// <param name="model">User answers to the test</param>
        /// <returns></returns>
        /// <response code="200">Successful execution</response>
        /// <response code="400">Error API</response>
        [Route("useranswers")]
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult PostUserAnswers([FromBody] UserAnswersViewModel model)
        {
            try {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var questions = questionRepository.AllIncluding(x => x.TestId == model.TestId);
                var res = questions.Where(q => model.Answers.Any(m => m.QuestionId == q.Id && m.AnswerId == q.CorrectAnswerId)).Count();

                var userTest = userTestRepository.GetSingle(s => s.UserId == model.UserId && s.TestId == model.TestId);
                if (userTest.TestScore == -1) {
                    userTest.TestScore = res;
                    userTestRepository.Update(userTest);
                    userTestRepository.Commit();
                    return Ok(new { Score = res });
                }
                return BadRequest();

            } catch  (Exception ex)  { return BadRequest(ex.Message); };
        }
    }
}