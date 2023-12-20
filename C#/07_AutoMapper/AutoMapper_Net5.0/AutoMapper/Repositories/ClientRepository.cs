using AutoMapper.Models;

namespace AutoMapper.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Client GetClient()
        {
            return new Client
            {
                Id = 1,
                FirstName = "javier",
                LastName = "olivares",
                Email = "mail@mail.com",
                Phone = 990838929,
                Address = new Address
                {
                    Street = "Laguna del inca",
                    City = "Santiago",
                    Country = "Chile",
                    Number = 920
                }
            };
        }
    }
}