using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;
using System.Data;

namespace BLL
{
   
    public class DepreciacionBLL
    {
        DepreciacionDAO dDao = new DepreciacionDAO();

        /// <summary>
        /// Guarda las lista de todos los activos Depreciados
        /// </summary>
        /// <param name="lstDep"></param>
        public void insertar(List<EDepreciacion> lstDep) {
            if (lstDep.Count == 0) {
                return;
            }
            dDao.insertar(lstDep);
        }
       
        /// <summary>
        /// Retorna la Tabla de Depreciacion
        /// </summary>
        /// <param name="codigo">Codigo del Activo</param>
        /// <param name="perInicio">Periodo Inicial</param>
        /// <param name="perFinal">Periodo Final</param>
        /// <returns></returns>       
        public DataTable tablaDepreciacion(string codigo, string perInicio, string perFinal) {
            if (string.IsNullOrWhiteSpace(codigo)) {
                return null;
            }
            if (string.IsNullOrEmpty(perFinal) || string.IsNullOrEmpty(perInicio))
            {
                return null;
            }
            return dDao.tablaDepreciacion(codigo, perInicio, perFinal);
        }
    }
}
