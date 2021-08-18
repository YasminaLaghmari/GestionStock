using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serviceUser;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly IUserService _userClient;

        public UserController(IUserService serviceUser,
            Microsoft.Extensions.Configuration.IConfiguration config, IUserService context)
        {
            _serviceUser = serviceUser;
            
            _config = config;
            _userClient = context;
        }
        
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserModel userResource)
        {
            
            var user = await _serviceUser.Authenticate(userResource.Username, userResource.Password);
            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Username null" });
     
            }
            var user = new User();
            user.Id = userResource.Id;
            user.FirstName = userResource.FirstName;
            user.Username = userResource.Username;
            user.LastName = userResource.LastName;
            

            string rolll="user";
            if (userResource.IsAdmin == true)
            {
                rolll = "Admin";
            }
            if (userResource.isAgent == true)
            {
                rolll = "Agent";
            }
            if (userResource.isManager == true)
            {
                rolll = "Manager";
            }
            if (userResource.isUser == true)
            {
                rolll = "User";
            }



            var userSave = await _serviceUser.Create(user, userResource.Password);
            //send tocken 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            //var user = new User();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name, user.Id.ToString()),
                     // new Claim("role",rolll)Pour les roles 
                     new Claim("role", rolll)

                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet]
        public async Task<IEnumerable<User>> getAllUser()
        {
              return await _userClient.GetAll();
            
        }
        [HttpDelete]
        public void DeleteUser(int id)
        {
               _userClient.Delete(id);
        }
        [HttpPost]
        public void UpdateUser(UserModel userResource, string password)
        {
            var user = new User();
            user.Id = userResource.Id;
            user.FirstName = userResource.FirstName;
            user.Username = userResource.Username;
            user.LastName = userResource.LastName;
            _userClient.Update(user,password);
        }
        


    }
}
