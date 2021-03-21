using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquiler_Discos.Models;

namespace Alquiler_Discos.ViewModels
{
    public class DetalleAlquilerViewModel
    {
        public int Id { get; set; }

        public string item { get; set; }
        public string diasPrestamo { get; set; }
        public string fechaDevolucion { get; set; }

        public int CdId { get; set; }
        public Cd Cd { get; set; }

        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
    }
}