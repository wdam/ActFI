using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMantenimiento
    {
        public int idMto { get; set; }
        public string codActivo { get; set; }
        public string nContrato { get; set; }
        public string fInicio { get; set; }
        public string fVence { get; set; }
        public int nVisitas { get; set; }
        public string proveedor { get; set; }
        public double valor { get; set; }
    }

    public class EDetalleMto : EMantenimiento { 
       
    }
}
