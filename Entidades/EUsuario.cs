using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EUsuario
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string login { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
        public string estado { get; set; }
    }
}
