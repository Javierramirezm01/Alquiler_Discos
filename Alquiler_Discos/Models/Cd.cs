using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Cd
    {
        public int Id { get; set; }

        public string codigoTitulo { get; set; }

        public string  condicion { get; set; }
        public string  ubicacion { get; set; }
        public bool estado { get; set; } 

    }
}
