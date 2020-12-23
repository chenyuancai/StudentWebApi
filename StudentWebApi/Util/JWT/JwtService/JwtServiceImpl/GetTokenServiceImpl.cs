using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentWebApi.JWT.JwtService.JwtServiceImpl
{
    public class GetTokenServiceImpl : IGetTokenService
    {
        private IConfiguration _configuration { get; }
        public GetTokenServiceImpl(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string Token(string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(this._configuration["JWT:SecurityKey"]);
            var expiresAt = DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,this._configuration["JWT:audience"]),
                    new Claim(JwtClaimTypes.Issuer,this._configuration["JWT:issuer"]),
                    new Claim(JwtClaimTypes.Name,name),
                    new Claim(JwtClaimTypes.Role,role),

                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
