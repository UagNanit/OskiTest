using System;
using OskiTest.Services.Abstraction;
using OskiTest.Models.ViewModels;
using OskiTest.Data.Abstract;
using OskiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OskiTest.Data.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace OskiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        IAuthService authService;
        IUserRepository userRepository;
        ITestRepository testRepository;
        IUserTestRepository userTestRepository;
        public AuthController(IAuthService authService, IUserRepository userRepository, IUserTestRepository userTestRepository, ITestRepository testRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
            this.testRepository = testRepository;
            this.userTestRepository = userTestRepository;


        }

        /// <summary>
        /// Login method to authenticate a user with a specified login account.
        /// </summary>
        /// <param name="model">Login information</param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public ActionResult<AuthData> Post([FromBody]LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = userRepository.GetSingle(u => u.Email == model.Email, u => u.Role);

                if (user == null)
                {
                    return BadRequest(new { email = "no user with this email" });
                }

                var passwordValid = authService.VerifyPassword(model.Password, user.Password);
                if (!passwordValid)
                {
                    return BadRequest(new { password = "invalid password" });
                }

                return authService.GetAuthData(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }

        /// <summary>
        /// Registration method to add a new user .
        /// </summary>
        /// <param name="model">Registration information</param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<AuthData> Post([FromBody]RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var emailUniq = userRepository.isEmailUniq(model.Email);
                if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
                var usernameUniq = userRepository.IsUsernameUniq(model.Username);
                if (!usernameUniq) return BadRequest(new { username = "user with this name already exists" });

                var id = Guid.NewGuid().ToString();
                var userTemp = new User
                {
                    Id = id,
                    UserName = model.Username,
                    Email = model.Email,
                    Password = authService.HashPassword(model.Password),
                    RoleId = "2",

                };
                userRepository.Add(userTemp);
                userRepository.Commit();

                var user = userRepository.GetSingle(u => u.Email == model.Email, u => u.Role);

                return authService.GetAuthData(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }
    }
}