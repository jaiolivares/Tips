using BasicSecurityASP.Models;

namespace BasicSecurityASP.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> users =
        [
            new User() { Email = "admin@prueba.cl", Password = "1234" }, // Authorize desde Swagger: Basic YWRtaW5AcHJ1ZWJhLmNsOjEyMzQ=
            new User() { Email = "visita@prueba.cl", Password = "4321" }
        ];

        public bool IsUser(string email, string password)
        {
            return users.Where(x => x.Email == email && x.Password == password).Any();
        }
    }
}