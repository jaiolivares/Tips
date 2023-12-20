using AutoMapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var client = _clientService.GetClient();
            return View(client);
        }
    }
}