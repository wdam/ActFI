using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDepreciacion
    {
        public int idDere { get; set; }
        public string documento { get; set; }
        public string codigo { get; set; }
        public string periodo { get; set; }
        public double valLibros { get; set; } // Valor en Libros
        public double depreciacion { get; set; }
        public double depAcumulada { get; set; }
        public DateTime fecha { get; set; }
    }
}
