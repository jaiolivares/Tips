using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SeguridadJwt.Data;
using SeguridadJwt.Models;
using SeguridadJwt.Models.Common;
using SeguridadJwt.Models.Request;
using SeguridadJwt.Models.Response;
using SeguridadJwt.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SeguridadJwt.Services
{
    public class UserService : IUserService
    {
        private readonly SeguridadJwtContext _context;
        private readonly AppSettings _appSettings;

        public UserService(SeguridadJwtContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public UserResponse? Auth(AuthRequest model)
        {
            UserResponse userResponse = new();

            string spassword = Encrypt.GetSha256(model.Password);

            var usuario = _context.Usuario.Where(x => x.Email == model.Email && x.Password == spassword).FirstOrDefault();

            if (usuario == null)
                return null;

            userResponse.Email = usuario.Email;
            userResponse.Token = GetToken(usuario);

            return userResponse;
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new(ClaimTypes.Email, usuario.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}