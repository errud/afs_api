using AfrikSokoApi.Models;
using local = AfrikSoko_BLL.LocalModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AfrikSoko_BLL.LocalModels;

namespace AfrikSokoApi.Services
{
    public class TokenService
    {
        private readonly string _issuer, _audience, _secret;

        public TokenService(IConfiguration config)
        {
            _issuer = config.GetSection("tokenValidation").GetSection("issuer").Value;
            _audience = config.GetSection("tokenValidation").GetSection("audience").Value;
            _secret = config.GetSection("tokenValidation").GetSection("secret").Value;
        }

        public string GenerateJWT(AppUser user)
        {
            if (user.Email is null)
            {
                throw new ArgumentNullException();
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //User Info

            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Surname, user.NickName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: myClaims,
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(1)
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
