using AutoMapper.Models;
using AutoMapper.Repositories;

namespace AutoMapper.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public ClientViewModel GetClient()
        {
            var client = _repository.GetClient();

            return new ClientViewModel()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone
            };
        }
    }
}