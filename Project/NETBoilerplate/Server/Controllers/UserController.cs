using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NETBoilerplate.Server.Model;
using NETBoilerplate.Shared;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Auth _auth;
        private readonly IUserService _userService;

        public UserController(IOptionsMonitor<Auth> authSettings, IUserService userService)
        {
            _auth = authSettings.CurrentValue;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            var result = new UserDTO();
            var userResult = _userService.Get(y => y.Email == user.Email && y.Password == user.Password);
            if (userResult == default)
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_auth.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user",
                        JsonConvert.SerializeObject(userResult,
                            new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}))
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_auth.ExpiryMinute)),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenResult = tokenHandler.WriteToken(token);
            result.Token = tokenResult;
            return Ok(await Task.FromResult(result));
        }
    }
}