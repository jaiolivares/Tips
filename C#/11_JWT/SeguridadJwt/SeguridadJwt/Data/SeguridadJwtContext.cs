using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeguridadJwt.Models;

namespace SeguridadJwt.Data
{
    public class SeguridadJwtContext : DbContext
    {
        public SeguridadJwtContext(DbContextOptions<SeguridadJwtContext> options)
            : base(options)
        {
        }

        public DbSet<SeguridadJwt.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<SeguridadJwt.Models.Divisa> Divisas { get; set; } = default!;
    }
}