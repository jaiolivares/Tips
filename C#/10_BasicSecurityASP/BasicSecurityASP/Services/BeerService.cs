using BasicSecurityASP.Models;
using System.Text.Json;

namespace BasicSecurityASP.Services
{
    public class BeerService : IBeerService
    {
        private string path = @"C:\000_DEV\GIT\jaiolivares\Tips\C#\10_JWT\BasicSecurityASP\BasicSecurityASP\beers.json";

        public async Task<List<Beer>> Get()
        {
            string content = await File.ReadAllTextAsync(path);
            var beers = JsonSerializer.Deserialize<List<Beer>>(content);
            return beers;
        }
    }
}