using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SeguridadJwt.Data;
using SeguridadJwt.Models.Response;
using System.Security.Claims;

namespace SeguridadJwt.Services
{
    public class TokenService : ITokenService
    {
        private readonly SeguridadJwtContext _context;

        public TokenService(SeguridadJwtContext context)
        {
            _context = context;
        }

        public dynamic ValidarToken(ClaimsIdentity identity)
        {
            Respuesta respuesta = new() { };

            try
            {
                if (identity.Claims.Any())
                {
                    respuesta = new()
                    {
                        Exitoso = false,
                        Mensaje = "Verifica si estás enviando un token válido",
                        Data = null
                    };
                }
                var id = identity.Claims.FirstOrDefault(x => x.Type == "NameIdentifier");

                //var usuario = _context.Usuario.Where(x => x.Email == model.Email && x.Password == spassword).FirstOrDefault();

                respuesta = new()
                {
                    Exitoso = true,
                    Mensaje = "",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                respuesta = new()
                {
                    Exitoso = false,
                    Mensaje = "Catch: " + ex,
                    Data = null
                };
            }

            return respuesta;
        }
    }
}