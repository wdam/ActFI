using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Clase Generica que representara diferentes tablas de la BD... 
    public class EGenerica
    {
        public int longitud { get; set; }
        public int niveles { get; set; }
        public string ccosto { get; set; }
        public string descripcion { get; set; }
    }

    public class EtipoDepreciacion {
        public string sigla { get; set;}
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
