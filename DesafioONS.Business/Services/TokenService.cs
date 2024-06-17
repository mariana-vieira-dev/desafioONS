using DesafioONS.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioONS.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();            

            if (string.IsNullOrEmpty(_configuration["Jwt:Key"]))
                throw new ArgumentException("Jwt:Key is missing in configuration");

            if (string.IsNullOrEmpty(_configuration["Jwt:Issuer"]))
                throw new ArgumentException("Jwt:Issuer is missing in configuration");

            if (string.IsNullOrEmpty(_configuration["Jwt:Audience"]))
                throw new ArgumentException("Jwt:Audience is missing in configuration");

            if (string.IsNullOrEmpty(_configuration["Jwt:ExpireMinutes"]))
                throw new ArgumentException("Jwt:ExpireMinutes is missing in configuration");

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Login),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
