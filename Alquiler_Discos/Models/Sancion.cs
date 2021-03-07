using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Sancion
    {
        public int Id { get; set; }
        public string TipoSancion { get; set; }
        public int NroDiasSancion { get; set; }

        //Propiedad de clave foránea
        public int ClienteId { get; set; }
        //Propiedad de navegación
        public Cliente Cliente { get; set; }


        //Propiedad de clave foránea
        public int AlquilerId { get; set; }
        //Propiedad de navegación
        public Alquiler Alquiler { get; set; }


    }
}
