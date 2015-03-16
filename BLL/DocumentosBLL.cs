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

        /// <summary>
        /// Retorna una lista Con un Documento Especifico
        /// </summary>
        /// <param name="codigo">Codigo O Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>        
        /// <returns></returns>
        public List<EDocumentos> buscarDocumento(int codigo, string tipo) {
            if (codigo == 0 || string.IsNullOrWhiteSpace(tipo)) {
                return null;
            }
            return dDao.buscarDocumento(codigo, tipo, BLL.Inicializar.Mes);
        }

        /// <summary>
        /// Verificar si existe un Documento Contable
        /// </summary>
        /// <param name="codigo">Codigo O Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>        
        /// <returns></returns>
        public int verificar(int codigo, string tipo)
        {
            if (codigo == 0 || string.IsNullOrWhiteSpace(tipo))
            {
                return 0;
            }
            return dDao.verificar(codigo, tipo, BLL.Inicializar.Mes);
        }


        /// <summary>
        /// Retorna una lista con los Documentos Contable en Sistema
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Proceso que resta el valor en la respectiva cuenta contable de un Documento especifico
        /// Utilizado en el Editar Documentos
        /// </summary>
        /// <param name="codigo">Codigo o Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>
        public void modificarCuentas(int codigo, string tipo) {
            dDao.modificarCuenta(codigo, tipo, BLL.Inicializar.Mes);
        }

        /// <summary>
        /// Elimar Documento Contable
        /// </summary>
        /// <param name="codigo">Codigo o Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>
        public void eliminarDocumento(int codigo, string tipo) {
            dDao.eliminarDocumento(codigo, tipo, BLL.Inicializar.Mes);
        }

        /// <summary>
        /// Guardar Documento Contable
        /// </summary>
        /// <param name="objDoc"></param>
        /// <returns></returns>
        public int insertar(EDocumentos objDoc) {
            CuentasDAO cDao = new CuentasDAO();
            if (cDao.buscar(objDoc.codigo, "Auxiliar") == null) {
                return 0;
            }
            return  dDao.insert(BLL.Inicializar.Mes, objDoc);
        }

        /// <summary>
        /// Guardar Observacion del Documento
        /// </summary>
        /// <param name="documento">Codigo o Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>
        /// <param name="observacion">Cadena de Caracteres (Observacion Realizada)</param>
        public void insertObservacion(int documento, string tipo, string observacion) {
            if (string.IsNullOrWhiteSpace(tipo)) {
                return;
            }
            dDao.insertObservacion(documento, tipo, observacion, Inicializar.Mes);
        }

        /// <summary>
        /// Obtiene una Observacion Realizada
        /// </summary>
        /// <param name="documento">Codigo o Numero de Documento Contable</param>
        /// <param name="tipo">Tipo de Documento</param>
        /// <returns></returns>
        public string getObservacion(string documento, string tipo)
        {
            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(tipo)) {
                return ""; 
            }
            return dDao.getObservacion(Convert.ToInt32(documento), tipo, Inicializar.Mes);
        }
    }
}
