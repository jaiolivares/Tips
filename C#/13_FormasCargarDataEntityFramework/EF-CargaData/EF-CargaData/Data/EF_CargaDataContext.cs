using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_CargaData.Entidades;

namespace EF_CargaData.Data
{
    public class EF_CargaDataContext : DbContext
    {
        public EF_CargaDataContext(DbContextOptions<EF_CargaDataContext> options)
            : base(options)
        {
        }

        public DbSet<EF_CargaData.Entidades.Pelicula> Peliculas { get; set; } = default!;
    }
}