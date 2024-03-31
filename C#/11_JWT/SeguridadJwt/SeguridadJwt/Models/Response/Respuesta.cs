namespace SeguridadJwt.Models.Response
{
    public class Respuesta
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public UserResponse Data { get; internal set; }
    }
}