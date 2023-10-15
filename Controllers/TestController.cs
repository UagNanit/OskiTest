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
    [ApiController]
    public class TestController: ControllerBase
    {
       
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

        /// <summary>
        /// Get information about user.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns></returns>
        [Route("user/{id}")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public ActionResult<UserViewModel> GetUserData(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(id);

            if (user == null)
            {
                return BadRequest(new { id = "user do not exist" });
            }

            var ut = userTestRepository.AllIncluding(t => t.UserId == user.Id);
            var t = testRepository.AllIncluding(s => ut.Any(u => u.TestId == s.Id)).ToList();
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


        /// <summary>
        /// Get test questions and answers variants.
        /// </summary>
        /// <param name="id">Test ID</param>
        /// <returns></returns>
        [Route("test/{id}")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public ActionResult<List<QuestionsViewModel>> GetTestData(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var questions = questionRepository.AllIncluding(x => x.TestId == id).Select(x =>
            new QuestionsViewModel { Id = x.Id, TextQuestion = x.TextQuestion, Answers = answerRepository.AllIncluding(a => a.QuestionId == x.Id).Select(s => 
            new AnswerViewModel { Id = s.Id, TextAnswer = s.TextAnswer, QuestionId = s.QuestionId } ).ToList()
            }).ToList();

            if (questions == null)
            {
                return BadRequest(new { id = "Id do not exist" });
            }

            return questions;
        }

        /// <summary>
        /// The method accepts the user's answers to the test and returns the result.
        /// And writes the result to the database.
        /// </summary>
        /// <param name="model">User answers to the test</param>
        /// <returns></returns>
        [Route("useranswers")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult PostUserAnswers([FromBody] UserAnswersViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            int res = 0;

            

            return Ok(new { Score = "" });
        }
    }
}