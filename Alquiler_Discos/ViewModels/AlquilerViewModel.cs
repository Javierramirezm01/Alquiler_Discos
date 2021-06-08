using Alquiler_Discos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.ViewModels
{
    public class AlquilerViewModel
    {
        public int Id { get; set; }

        public int nroAlquiler { get; set; }
        public DateTime fechaAlquiler { get; set; }
        public double valorAlquiler { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<int> ProductoIds { get; set; }
        public List<DetalleAlquiler> DetallesAlquiler { get; set; }

        public List<Producto> Productos { get; set; }

        

       
    }
}
