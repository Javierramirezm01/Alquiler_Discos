﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alquiler_Discos.ViewModels
{
    public class CdViewModel
    {
        public int Id { get; set; }

        public string codigoTitulo { get; set; }

        public string condicion { get; set; }
        public string ubicacion { get; set; }
        public string estado { get; set; }
    }
}
