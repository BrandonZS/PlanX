using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace PlanXBackend.Logica
{
    public class GeneradorToken
    {



        private const string SecretKey = "ghghghghghghtynbfghinghsdgfhjiwi"; // Debe ser secreta y segura
        private const int ExpirationMinutes = 30; // Duración del token
        public static string GenerateToken(string email)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
                // Agrega aquí más claims si lo necesitas
            }),
                Expires = DateTime.UtcNow.AddMinutes(ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

