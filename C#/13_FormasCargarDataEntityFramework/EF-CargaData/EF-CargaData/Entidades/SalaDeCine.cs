﻿namespace EF_CargaData.Entidades
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}