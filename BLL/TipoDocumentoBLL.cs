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
        TipoDocumentoDAO tDao = new TipoDocumentoDAO();

        public List<ETipoDocumento> getAll() {
            return tDao.getAll();            
        }

        public ETipoDocumento buscarTipo(string tipo) {
            if (String.IsNullOrWhiteSpace(tipo)) {
                return null;
            }
            return tDao.buscarTipo(tipo, Inicializar.Mes);
        }
    }
}
