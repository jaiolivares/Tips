using SeguridadJwt.Models.Request;
using SeguridadJwt.Models.Response;
using System.Security.Claims;

namespace SeguridadJwt.Services
{
    public interface ITokenService
    {
        dynamic ValidarToken(ClaimsIdentity identity);
    }
}