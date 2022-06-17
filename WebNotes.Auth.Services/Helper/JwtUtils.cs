using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebNotes.Auth.Domain.Auth;
using WebNotes.Auth.Domain.Interfaces.Helper;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Services.Helper
{
    public class JwtUtils : IJwtUtils
    {

        private readonly IConfiguration _configuration;

        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AuthToken> GenerateJwtToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            JwtSecurityToken token = new(
                expires: DateTime.Now.AddMinutes(50),
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssuer"],
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new AuthToken()
            {
                Token = tokenHandler.WriteToken(token),
                Expires = token.ValidTo
            };
        }

        public string? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            try
            {
                ClaimsPrincipal validToken = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return validToken.Identity!.Name;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
