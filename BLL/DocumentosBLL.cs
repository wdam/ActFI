using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class DocumentosBLL
    {
        DocumentosDAO dDao = new DocumentosDAO();

        public List<EDocumentos> buscarDocumento(int codigo, string tipo) {
            if (codigo == 0 || string.IsNullOrWhiteSpace(tipo)) {
                return null;
            }
            return dDao.buscarDocumento(codigo, tipo, BLL.Inicializar.Mes);
        }

        public void ModificarCuentas(int codigo, string tipo) {
            dDao.modificarCuenta(codigo, tipo, BLL.Inicializar.Mes);
        }
    }
}
