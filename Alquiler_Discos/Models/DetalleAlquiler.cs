using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class DetalleAlquiler
    {
        public int Id { get; set; }

        public string item { get; set; }
        public int diasPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }

        public int CdId { get; set; }
        public Cd Cd { get; set; }

        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
    }

    
}
