using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class TipoDocumentoBLL
    {
        TipoDocumentoDAO tipoDao = new TipoDocumentoDAO();

        public List<ETipoDocumento> getAll() {
            return tipoDao.getAll();            
        }
    }
}
