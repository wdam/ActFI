using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ETraslados
    {
        public int idTraslado { get; set; }
        public string activo { get; set; }
        public string areaAnt { get; set; }
        public string respAnt { get; set; }
        public DateTime fecha { get; set; }
        public string nuevaArea { get; set; }
        public string nuevoResp { get; set; }
        public string observacion { get; set; }
    }
}
