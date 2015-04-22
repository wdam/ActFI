using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class CentroCostoBLL
    {

        /// <summary>
        /// Obtiene un Centro de Costo
        /// </summary>
        /// <param name="codigo">Codigo del C. Costo</param>
        /// <returns></returns>
        public ECentroCosto buscar(string codigo) {

            if (string.IsNullOrEmpty(codigo)) {
                return null;
            }
            CentroCostoDAO CDao = new CentroCostoDAO();
            return CDao.buscar(codigo);
        }

        /// <summary>
        /// Devuelve una lista Completa de los Centro de Costos
        /// </summary>
        /// <returns></returns>
        public List<ECentroCosto> getAll() {
            CentroCostoDAO CDao = new CentroCostoDAO();
            return CDao.getAll();
        }
    }
}
