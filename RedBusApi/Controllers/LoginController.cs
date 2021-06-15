using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RedBusApi.Model;
using RedBusApi.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RedBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config=null;
        

        public LoginController(IConfiguration config)
        {
            _config = config;
           
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Person login)
        {
            IActionResult response = Unauthorized();
            //var user = AuthenticateUser(login);
            PersonRepository repo = new PersonRepository();
            var user = repo.VerifyGuest(login);
            Credential cred;
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                cred = new Credential()
                {
                    PersonId = user.PersonId,
                    PersonName= user.PersonName,
                    PersonPasswd= user.PersonPasswd,
                    Role= user.Role,
                    TokenCode= tokenString
                };
               
                response = Ok( cred );
            }
            else
            {
                response= Unauthorized("wrong credentials");
            }
            return response;
        }


        /*[AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Person login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }*/

        private string GenerateJSONWebToken(Person userInfo)//only called when user is present
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.Role,userInfo.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       /* private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserId == 1 && login.Password == "pass1")
            {
                user = new UserModel { UserId = 1, Password = "pass1", EmailId = "any1@gmail.com" };
            }
            else if (login.UserId == 2 && login.Password == "pass2")
            {
                user = new UserModel { UserId = 2, Password = "pass2", EmailId = "any2@gmail.com" };
            }
            return user;
        }*/
    }
}