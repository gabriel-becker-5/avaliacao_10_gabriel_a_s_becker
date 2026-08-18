using _02_Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _02_Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _chave;

        public TokenService(IConfiguration config)
            => _chave = config["Jwt:Secret"];

        public string GerarToken(string usuario)
        {
            List<Claim> claims = [];

            var claimName = new Claim(JwtRegisteredClaimNames.Name, usuario);
            claims.Add(claimName);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chave));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}