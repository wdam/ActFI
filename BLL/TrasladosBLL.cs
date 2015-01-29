using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class TrasladosBLL
    {
        TrasladosDAO tDao = new TrasladosDAO();
        public string insertar(ETraslados obj) {
           
            if (tDao.insertar(obj) > 0)
            {
                return "Exito";
            }
            else {
                return "Error al Guardar Datos del Traslado";
            }
                            
        }
    }
}
