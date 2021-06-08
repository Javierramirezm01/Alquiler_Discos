using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Sancion
    {
        public int Id { get; set; }
        public int NroDiasSancion { get; set; }
        public DateTime fechaSancion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //Propiedad de clave foránea
        public int AlquilerId { get; set; }
        //Propiedad de navegación
        public Alquiler Alquiler { get; set; }


    }
}
