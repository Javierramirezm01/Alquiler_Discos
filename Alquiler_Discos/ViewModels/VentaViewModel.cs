using Alquiler_Discos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.ViewModels
{
    public class VentaViewModel
    {
        public int Id { get; set; }
        public string CodigoVenta { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public double ValorVenta { get; set; }
        public List <int> ProductoIds { get; set; }
        public List <DetalleVenta> DetallesVentas { get; set; }
        public List<Producto> Productos { get; set; }


    }
}
