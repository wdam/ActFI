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
    }
}
