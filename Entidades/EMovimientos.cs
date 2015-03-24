using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMovimientos
    {
        public int idMovimiento { get; set; }
        public string documento { get; set; }
        public string tipoDoc { get; set; }
        public string periodo { get;  set; }
        public DateTime fecha { get; set; }
        public string tipoMov { get; set; }
        public string descripcion { get; set; }
        public string codActivo { get; set; }
        public double valor { get; set; }
        public string estado { get; set; }
        public string cCosto { get; set; }
        public string nit { get; set; }
    }
}
