using Alquiler_Discos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
           
        }

        public DbSet<Cd> cds { get; set; }
        public DbSet<Alquiler> alquilers { get; set; }
        public DbSet<DetalleAlquiler> detalleAlquilers { get; set; }

    }
}
