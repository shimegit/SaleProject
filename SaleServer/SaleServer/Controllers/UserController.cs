using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleServer.BL;
using SaleServer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SaleServer.DTO;
using AutoMapper;


namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserBL _iuser;
        private readonly IMapper _mapper;

        public UserController(IuserBL iuser, IMapper mapper)
        {
            this._iuser = iuser ?? throw new ArgumentNullException(nameof(iuser));
            this._mapper= mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDTO user)
        {
            User user1 = _mapper.Map<User>(user);

            if (user.UserName == null || user.Address == null || user.Phone == null ||

                user.Email == null || user.Password==null)
            {

                return NotFound("Details are missing");

            }
            else
            {
                user1.Roles = "0";
                var newUser = await _iuser.AddUser(user1);
                UserDTO registered = _mapper.Map<UserDTO>(newUser);
                return Ok(registered);
            }

        }
    }
}