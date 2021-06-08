using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        public int nroAlquiler { get; set; }
        public DateTime fechaAlquiler { get; set; }
        public double valorAlquiler { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
       
    }
}
