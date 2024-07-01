using System.ComponentModel.DataAnnotations;

namespace EF_CargaData.Entidades
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}