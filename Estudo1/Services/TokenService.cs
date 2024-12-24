using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.IdentityModel.Tokens;

namespace Estudo1.Services;

public static class TokenService
{
    public static string GenerateToken(int id, string email)
    {
        // converter para um array de bytes
        var key = Encoding.ASCII.GetBytes(Settings.Secret);


        var tokenHandler = new JwtSecurityTokenHandler();
        
        // configs dele
        var configs = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), // chave
                SecurityAlgorithms.HmacSha256Signature),//metodo de criptografia    
            // payload e mais
            Subject = new ClaimsIdentity([
                // new Claim(ClaimTypes.Name, name),// mapeia para o Identity
                //User.Identity.Name (tem outros tipos prontos)
                new Claim(ClaimTypes.Name, id.ToString()),// improvidado
                new Claim(ClaimTypes.Email, email),
            ])
        };
        
        
        var token = tokenHandler.CreateToken(configs);// pode mexer e pegar infos
        
        return tokenHandler.WriteToken(token);// converte para string
    }
}