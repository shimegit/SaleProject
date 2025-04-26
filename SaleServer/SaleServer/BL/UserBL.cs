using Microsoft.IdentityModel.Tokens;
using Orders.Dal;
using SaleServer.DTO;
using SaleServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaleServer.BL
{
    public class UserBL : IuserBL
    {
        private readonly IuserDal _userDAL;
        private readonly IConfiguration _config;

        public UserBL(IuserDal userDAL, IConfiguration config)
        {
            this._userDAL = userDAL ?? throw new ArgumentNullException(nameof(userDAL));
            this._config=config ?? throw new ArgumentNullException(nameof(userDAL));
        }
        public async Task<User> AddUser(User user)
        {
            return await _userDAL.AddUserDal(user);
        }

        public string GenerateUser(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Surname,user.UserName),
                new Claim(ClaimTypes.HomePhone,user.phone),
                new Claim(ClaimTypes.Email,user.email),
                new Claim(ClaimTypes.StreetAddress,user.address),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public async Task<User> Authenticate(User userLogin)
        {
            return await _userDAL.AuthenticateDal(userLogin);
        }
    }
}

