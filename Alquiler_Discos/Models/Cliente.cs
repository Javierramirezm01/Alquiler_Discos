using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string TemaInteres { get; set; }
        public string Estado { get; set; }
        public int NroDNI { get; set; }



    }
}
