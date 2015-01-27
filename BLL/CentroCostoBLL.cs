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
        public ECentroCosto buscar(string codigo) {

            if (string.IsNullOrEmpty(codigo)) {
                return null;
            }
            CentroCostoDAO CDao = new CentroCostoDAO();
            return CDao.buscar(codigo);
        }

        public List<ECentroCosto> getAll() {
            CentroCostoDAO CDao = new CentroCostoDAO();
            return CDao.getAll();
        }
    }
}
