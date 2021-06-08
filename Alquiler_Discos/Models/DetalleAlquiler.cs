using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class DetalleAlquiler
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int ProductoId { get; set; }
        public Alquiler Alquiler { get; set; }
        public Producto Producto { get; set; }
    }

    
}
