using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EGrupo
    {
        public string sigla { get; set; }
        public string descripcion { get; set; }
        public string metodoDep { get; set; }
        public int valSalvamento { get; set; }
        public int vidaUtil{ get; set; }
        public string ctaActivo { get; set; }
        public string ctaDepreciacion { get; set; }
        public string ctaGastos { get; set; }
        public string ctaPerdida { get; set; }
        public string ctaGanancia { get; set; }
        public string ctaRevalorizar { get; set; }
        public string ctaMantenimiento { get; set; }
        public string ctaCorreccion { get; set; }
        public string estado { get; set; }
        public int consecutivo { get; set; }
    }

    public class ESubgrupo {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int consecutivo { get; set; }
        public string grupo { get; set; }
    }
}
