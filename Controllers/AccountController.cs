using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Api.Model.DTO;
using UserService.Api.Repositories;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _repo;

        
        public AccountController(IConfiguration config,IUserRepository repo)
        {
            _config = config;
            _repo = repo;
        }

        /// <summary>
        /// Validate user from request with db.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Authenticate(UserDTO userDTO)
        {
            if(!_repo.UserExists(userDTO.EmailId )) {
                return BadRequest("User not found.");
            }
            return Ok(GenerateToken(userDTO)); 
        }

        /// <summary>
        /// Token generation for authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateToken(UserDTO user)
        {
            //create key
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //create payload/claims
            var claims = new[]{
                          new Claim(ClaimTypes.Name, user.EmailId),
                          new Claim("custom","custom")
            };

            //create creds
            var creds = new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);
            
            //create token
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(1)
                );

            //write token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


    }
}
