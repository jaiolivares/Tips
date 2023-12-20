using AutoMapper;
using AutoMapper.Models;
using AutoMapper.Repositories;

namespace AutoMapper.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ClientViewModel GetClient()
        {
            var client = _repository.GetClient();

            return _mapper.Map<ClientViewModel>(client);

            //Mapeo manual que fue reemplaado por AutoMapper
            //return new ClientViewModel()
            //{
            //    Id = client.Id,
            //    FirstName = client.FirstName,
            //    LastName = client.LastName,
            //    Email = client.Email,
            //    Phone = client.Phone
            //};
        }
    }
}