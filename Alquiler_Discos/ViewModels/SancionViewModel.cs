using Alquiler_Discos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.ViewModels
{
    public class SancionViewModel
    {
        public int Id { get; set; }
        public string TipoSancion { get; set; }
        public int NroDiasSancion { get; set; }
        public int ClienteId { get; set; }
        public Cliente nombre { get; set; }

        //Propiedad de clave foránea
        public int AlquilerId { get; set; }
        //Propiedad de navegación
        public Alquiler Alquiler { get; set; }
    }
}

