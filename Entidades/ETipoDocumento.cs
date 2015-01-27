using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ETipoDocumento
    {
        public string tipoDoc { get; set; }
        public string grupo { get; set; }
        public string descripcion { get; set; }        
        public int inicio { get; set; }
        public int actual { get; set; }
    }
}
