using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;
using System.Data;

namespace BLL
{
    public class MovimientoBLL
    {
        MovimientoDAO mDao = new MovimientoDAO();
        public string insertar(EMovimientos obj) {
            if (string.IsNullOrEmpty(obj.documento)) {
                return "Numero de Documento Incorrecto";
            }

            if (mDao.insertar(obj) > 0)
            {
                return "Exito";
            }
            else
            {
                return "Error al Guardar Movimiento";
            }
        }

        /// <summary>
        /// Obtener Todos los Movimientos Dependiendo de los filtros
        /// </summary>
        /// <param name="tipo">Tipo de Documento</param>
        /// <param name="activo">Codigo del Activo</param>
        /// <param name="perInicial">Periodo Inicial</param>
        /// <param name="perFinal">Periodo Final</param>
        /// <returns></returns>
        public DataTable getAll(string tipo, string activo, string perInicial, string perFinal) {
            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(activo) ) {
                return null;
            }
            return mDao.getAll(tipo, activo, perInicial, perFinal);
        }
    }
}
