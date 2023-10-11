using System;
using OskiTest.Services.Abstraction;
using OskiTest.Models.ViewModels;
using OskiTest.Data.Abstract;
using OskiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace OskiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        IAuthService authService;
        IUserRepository userRepository;
        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(u => u.Email == model.Email, u => u.Role);

            if (user == null) {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid) {
                return BadRequest(new { password = "invalid password" });
            }

            return authService.GetAuthData(user);
        }

        /// <summary>
        /// Registration method to add a new user .
        /// </summary>
        /// <param name="model">Registration information</param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public ActionResult<AuthData> Post([FromBody]RegisterViewModel model)
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

        /// <summary>
        /// Get information about user.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns></returns>
        [Route("auth/{id}")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public ActionResult<UserViewModel> GetUserData(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(id);

            if (user == null)
            {
                return BadRequest(new { username = "user do not exist" });
            }

            UserViewModel userViewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                IsAdmin = userRepository.isAdmin(user.Id),
                TestId = user.Tests.Select(t => t.Id).ToList()
              
                
            };

            return userViewModel;
        }
    }
}