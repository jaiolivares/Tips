using SeguridadJwt.Models.Request;
using SeguridadJwt.Models.Response;

namespace SeguridadJwt.Services
{
    public interface IUserService
    {
        UserResponse? Auth(AuthRequest model);
    }
}