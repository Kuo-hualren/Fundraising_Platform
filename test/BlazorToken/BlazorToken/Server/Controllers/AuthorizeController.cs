using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorToken.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToken(string userName)
        {
            var key = "2022/09/28 IThome 鐵人賽";
            var claims = new List<Claim>
            {
                // 使用者名稱
                new (JwtRegisteredClaimNames.Sub,userName),
                // Token Id
                new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "發行者",
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(securityToken));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUserInfo()
        {
            return Ok("取得使用者資料");
        }
    }
}
