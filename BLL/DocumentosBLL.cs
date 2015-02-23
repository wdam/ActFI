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

        public List<EDocumentos> getDocumentos() {
            TipoDocumentoDAO tDao = new TipoDocumentoDAO();
            List<ETipoDocumento> tipodoc = tDao.getAll();
            string tipo = "";
            foreach (var item in tipodoc)
            {
                tipo +=  "'"+item.tipoDoc + "'," ;
            }
            tipo = tipo.Substring(0, tipo.Length - 1);
            return dDao.getAll(BLL.Inicializar.Mes, tipo);
        }

        public void modificarCuentas(int codigo, string tipo) {
            dDao.modificarCuenta(codigo, tipo, BLL.Inicializar.Mes);
        }

        public void eliminarDocumento(int codigo, string tipo) {
            dDao.eliminarDocumento(codigo, tipo, BLL.Inicializar.Mes);
        }

        public int insertar(EDocumentos objDoc) {
            CuentasDAO cDao = new CuentasDAO();
            if (cDao.buscar(objDoc.codigo, "Auxiliar") == null) {
                return 0;
            }
            return  dDao.insert(BLL.Inicializar.Mes, objDoc);
        }

        public void insertObservacion(int documento, string tipo, string observacion) {
            if (string.IsNullOrWhiteSpace(tipo)) {
                return;
            }
            dDao.insertObservacion(documento, tipo, observacion, Inicializar.Mes);
        }
    }
}
