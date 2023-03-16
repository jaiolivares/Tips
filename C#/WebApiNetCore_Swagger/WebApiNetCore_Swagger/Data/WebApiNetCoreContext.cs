using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiNetCore.Models;

namespace WebApiNetCore.Data
{
    public class WebApiNetCoreContext : DbContext
    {
        public WebApiNetCoreContext(DbContextOptions<WebApiNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiNetCore.Models.Divisa> Divisas { get; set; } = default!;
    }
}