using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Auth;
using Shbl.Spt.Ui.Model.Core.Auth.Request;
using Shbl.Spt.Ui.Model.Core.Auth.Response;
using Shbl.Spt.WebApi.Core.Services.Auth;

namespace Shbl.Spt.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterService _registerService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(RegisterService registerService, IUserService userService, IConfiguration configuration)
        {
            _registerService = registerService;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _registerService.ProcessRequest(request);

                var authEndPoint = _configuration["AuthEndPoint"];
                var path = $"{authEndPoint}Token";

                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "password"),
                    new("userName", request.Email),
                    new("password", request.Password)
                });

                return Ok(HttpClientUtility.Post<TokenResponse, ErrorResult>(path, content));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Post([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _userService.GetByUsernameAndPasswordAsync(loginModel.Username, loginModel.Password);
            if (user is null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginModel.Username),
                new Claim(ClaimTypes.Email, loginModel.Username),
                new Claim(JwtRegisteredClaimNames.Sub, loginModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"])),
                    SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
