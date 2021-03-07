using Alquiler_Discos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Cd> cds { get; set; }
<<<<<<< HEAD

        public DbSet<Cliente> clientes { get; set; }

=======
        public DbSet<Cliente> clientes { get; set; }
>>>>>>> 08e52d83d077c42a502c8c861dace5bd15c01358
        public DbSet<Alquiler> alquilers { get; set; }

        public DbSet<DetalleAlquiler> detalleAlquilers { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 08e52d83d077c42a502c8c861dace5bd15c01358
        public DbSet<Sancion> sancions { get; set; }
    }


}
