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

        /// <summary>
        /// Retorna los Documento Creados Para Activos Fijos
        /// </summary>
        /// <returns>Retorna una Lista</returns>
        public List<ETipoDocumento> getAll() {
            return tDao.getAll();            
        }

        /// <summary>
        /// Retorna los  Datos de un Tipo de Documento (Grupo y N° Consecutivo)
        /// </summary>
        /// <param name="tipo">Sigla del Tipo de Documento</param>
        /// <returns>Objeto de  tipo de Documento</returns>
        public ETipoDocumento buscarTipo(string tipo) {
            if (String.IsNullOrWhiteSpace(tipo)) {
                return null;
            }
            return tDao.buscarTipo(tipo, Inicializar.Mes);
        }

        /// <summary>
        /// Actualizar Numero Consecutivo de un Grupo
        /// </summary>
        /// <param name="numero">Numero Consecutivo</param>
        /// <param name="tipo">Tipo de Documento</param>
        public void updateConsecutivo(int numero, string tipo) {
            if (string.IsNullOrEmpty(tipo)) {
                return;            
             }
            tDao.updateConsecutivo(numero, tipo, Inicializar.Mes);
        }
    }
}
