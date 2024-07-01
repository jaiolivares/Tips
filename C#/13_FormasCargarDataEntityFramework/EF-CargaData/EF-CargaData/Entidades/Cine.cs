using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace EF_CargaData.Entidades
{
    public class Cine
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
    }
}