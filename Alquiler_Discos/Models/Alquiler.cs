using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        public string nroAlquiler { get; set; }
        public string fechaAlquiler { get; set; }
        public string valorAlquiler { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        
    }
}
