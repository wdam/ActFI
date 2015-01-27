using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IActivos: ICentro, ICuenta
    {
        
        void buscarProveedor(string nit);
    }
}
