using System.ComponentModel.DataAnnotations;

namespace EF_CargaData.Entidades
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterUrl { get; set; }
        public List<Genero> Generos { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}