using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace recenziiBack.Services
{
    public class JWTservice
    {
        private readonly IConfiguration _configuration;

        public JWTservice(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
            };

            var token = new JwtSecurityToken(
                issuer : "http://localhost:32772",
                audience : "http://localhost:32772",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(90),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

