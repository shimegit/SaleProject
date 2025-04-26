using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SaleServer.DAL;
using SaleServer.Migrations;
using SaleServer.Models;

using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using webapi.Dal;
//using webapi.DTO;
//using webapi.Models;

namespace SaleServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly SaleContext _ordersdContext;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration config, SaleContext ordersdContext, IMapper mapper)
        {
            _config = config;

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._ordersdContext = ordersdContext ?? throw new ArgumentNullException(nameof(_ordersdContext));

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login userLogin)
        {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                
                var token = Generate(user);
                var jsonToken = JsonConvert.SerializeObject(new { token });
                return Ok(jsonToken);
            }
            return NoContent();
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            string role;
            if (user.Roles == "0")
                role = "user";
            else
                role = "admin";
            var claim = new[]
            {
                new Claim("userId",user.UserId.ToString()),
                new Claim(ClaimTypes.Role, role),

            };
            var token = new JwtSecurityToken(
               issuer: _config["Jwt:Issuer"],
               audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(15),
                claims:claim,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private async Task<User> Authenticate(Login userLogin)
        {
            var currentUser = await _ordersdContext.User.Where(user => user.UserName == userLogin.UserName && user.Password == userLogin.Password)
                .FirstOrDefaultAsync();

            return currentUser;
        }
    }
}

