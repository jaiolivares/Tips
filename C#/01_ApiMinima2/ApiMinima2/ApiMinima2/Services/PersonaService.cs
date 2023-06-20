using ApiMinima2.Entities;
using ApiMinima2.Interfaces;

namespace ApiMinima2.Services
{
    public class PersonaService : IPersonaService
    {
        private List<Persona> personas = new List<Persona>();

        public string AddPersona(Persona persona)
        {
            string respuesta = "Añadido OK";

            try
            {
                personas.Add(persona);
            }
            catch (Exception e)
            {
                respuesta = "Error: " + e.Message;
            }

            return respuesta;
        }

        public Persona GetPersona(int id)
        {
            var persona = new Persona();

            try
            {
                persona = personas.Find(x => x.Id == id);

                if (persona == null)
                {
                    throw new ApplicationException("No se encuentran personas con este ID");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Algo salió mal: " + e.Message);
            }

            return persona;
        }
    }
}