using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class PolizaBLL
    {
        PolizaDAO pDao = new PolizaDAO();
        public string insertar(EPolizas obj) {
            if (string.IsNullOrEmpty(obj.codActivo)) {
                return "El codigo del Activo no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.nPoliza)) {
                return "Falta el Numero de Poliza";
            }

            if (pDao.insertar(obj) > 0)
            {
                return "Exito";
            }
            else {
                return "Error Al Guardar datos de la Poliza de Seguros";
            }
        }
    }
}
