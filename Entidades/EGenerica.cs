using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    /// <summary>
    /// Clase Generica que representara diferentes tablas de la BD... 
    /// Principalmente tablas que guardan los parametros de SAE
    /// </summary>
    public class EGenerica
    {
        public int longitud { get; set; }
        public int niveles { get; set; }
        public string ccosto { get; set; }
        public string descripcion { get; set; }
    }

    /// <summary>
    /// Clase Encargada de los Tipo de Depreciacion que Manejara la Aplicacion
    /// </summary>
    public class EtipoDepreciacion {
        public string sigla { get; set;}
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }

    /// <summary>
    /// Clase que representa la tabla  de Departamentos y Municipios de SAE
    /// </summary>
    public class EDepartamentos
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
}
