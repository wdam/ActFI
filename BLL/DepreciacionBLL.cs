using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
   
    public class DepreciacionBLL
    {
        DepreciacionDAO dDao = new DepreciacionDAO();
        public void insertar(List<EDepreciacion> lstDep) {
            if (lstDep.Count == 0) {
                return;
            }
            dDao.insertar(lstDep);
        }
    }
}
