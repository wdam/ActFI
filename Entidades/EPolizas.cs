using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPolizas
    {

        public int idPoliza { get; set; } // Numero Generado Automaticamente
        public string codActivo {get; set;}
        public string nPoliza { get; set; }
        public string fechaInicio { get; set; }
        public string fechaVence { get; set; }
        public string empresa { get; set; }
        public string responsable { get; set; } // Agente de Contacto
        public string telefono { get; set; }  // Telefono de Contacto
        public double deducible { get; set; } 
        public double valor { get; set; } // Valor asegurado
    }
}
