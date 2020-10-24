using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Solvro_city.Models;
using Solvro_city.Context;
using Solvro_city.Models.Responses;

namespace Solvro_city.Controllers
{

    /// <summary>
    /// Controller that handles registering and logging in of users
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        /// <summary>
        /// Server configuration
        /// </summary>
        readonly IConfiguration config;
        /// <summary>
        /// User database context
        /// </summary>
        readonly UserContext dbUser;

        /// <summary>
        /// Constructor of controller get injections
        /// </summary>
        /// <param name="config">Server configuration</param>
        /// <param name="userContext">User database context</param>
        public LoginController(IConfiguration config, UserContext userContext)
        {
            this.config = config;
            this.dbUser = userContext;
        }


        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="newUser">New user object, no id should be provided</param>
        /// <returns>If success new user as json</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]User newUser)
        {
            IActionResult response = BadRequest(new Response("No data provided", 400));
            if(newUser == null || String.IsNullOrEmpty(newUser.Email) || String.IsNullOrEmpty(newUser.Password) || newUser.UserId != null)
                return response;
            newUser.Email.ToLower();
            User existingUser = dbUser.Users.SingleOrDefault((user) => user.Email == newUser.Email);
            if(existingUser == null && newUser.Email != String.Empty && newUser.Password != string.Empty)
            {
                dbUser.Users.Add(newUser);
                dbUser.SaveChanges();
                return Json(newUser);
            }
            response = BadRequest(new Response("User already exists", 400));
            return response;
        }

        /// <summary>
        /// Login in user
        /// </summary>
        /// <param name="login">User credentials</param>
        /// <returns>If success JWT token</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = BadRequest();
            if (login == null)
                return response;
            response = Unauthorized();
            User user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken();
                response = Json(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }
        /// <summary>
        /// Check if user credentials match with user in database
        /// </summary>
        /// <param name="loginCredentials">User login credentials</param>
        /// <returns>User logged in or null</returns>
        User AuthenticateUser(User loginCredentials)
        {
            User user = dbUser.Users.SingleOrDefault((user) => user.Email == loginCredentials.Email && user.Password == loginCredentials.Password);
            return user;
        }

        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <returns>JWT token</returns>
        string GenerateJWTToken(/*User userInfo*/)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt.SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            /*var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now..ToString())
            };*/
            var token = new JwtSecurityToken(
                issuer: config["Jwt.Issuer"],
                audience: config["Jwt.Audience"],
                //claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
