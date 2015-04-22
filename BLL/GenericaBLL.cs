using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class GenericaBLL
    {
        public bool verificarCCosto() {
            GenericaDAO GDao = new GenericaDAO();
            EGenerica obj = GDao.verificarCCosto();
            if (obj != null)
            {
                if (obj.ccosto == "S") {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Obtiene una lista de los Departamentos
        /// </summary>
        /// <returns>Lista</returns>
        public List<EDepartamentos> getDepartamentos() {
            DepartamentoDAO dDao = new DepartamentoDAO();
            return dDao.getDepartamentos();
        }
        /// <summary>
        /// Obtiene Una lista de Municipios por Departamentos
        /// </summary>
        /// <param name="codigo">Codigo del Departamento</param>
        /// <returns></returns>
        public List<EDepartamentos> getMunicipio(string codigo) {
            if (string.IsNullOrEmpty(codigo)) {
                return null;
            }
            DepartamentoDAO dDao = new DepartamentoDAO();
            return dDao.getMunicipios(codigo);
        }
    }
}
