﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EActivos
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string referencia { get; set; }
        public string numSerie { get; set; }
        public string tipo { get; set; }

        public string vidaUtil { get; set; }
        public string propiedad { get; set; }
        public DateTime fecha { get; set; }
        public string area { get; set; }
        public string responsable { get; set; }
        public string proveedor { get; set; }
        public string centrocosto { get; set; }

        public string estado { get; set; }
        public double valSalvamento { get; set; }
        public double valComercial { get; set; }
        public double valLibros { get; set; }
        public double valMejoras { get; set; }
        public double valHistorico { get; set; }
        public double depAjustada { get; set; }
        public double depAcumulada { get; set; }

        public string ctaActivo { get; set; }
        public string ctaGastos { get; set; }
        public string ctaDepreciacion { get; set; }
        public string ctaMonetaria { get; set; }
        public string ctaDepMonetaria { get; set; }
    }
}