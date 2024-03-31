using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SeguridadJwt.Models
{
    public class Divisa
    {
        [Key]
        public int DivisaId { get; set; }

        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public bool AplicaSpread { get; set; }
        public int PorcentajeSpread { get; set; }
        public decimal RangoMinimo { get; set; }
        public decimal RangoMaximo { get; set; }
    }
}