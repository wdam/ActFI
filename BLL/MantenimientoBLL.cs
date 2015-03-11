using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class MantenimientoBLL
    {
        MantenimientoDAO mDao = new MantenimientoDAO();
        public string insertar(EMantenimiento obj)
        {
            if (string.IsNullOrEmpty(obj.codActivo))
            {
                return "El codigo del Activo no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.nContrato))
            {
                return "Falta el Numero de Contrato";
            }

            if (mDao.insertar(obj) > 0)
            {
                return "Exito";
            }
            else
            {
                return "Error Al Guardar datos del Contrato de Mantenimiento";
            }
        }
    }
}
