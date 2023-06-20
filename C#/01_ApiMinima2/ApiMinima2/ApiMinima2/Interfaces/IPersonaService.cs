using ApiMinima2.Entities;

namespace ApiMinima2.Interfaces
{
    public interface IPersonaService
    {
        string AddPersona(Persona persona);
        Persona GetPersona(int id);
    }
}
