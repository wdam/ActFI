using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using Entidades;

namespace BLL
{
    public class ParametrosBLL
    {
        public List<EParametros> getParametros() {
            ParametrosDAO PDao = new ParametrosDAO();
            return PDao.getParamentro();
        }

        public string Actualizar(EParametros parametro) {

            CuentasBLL bllCuenta = new CuentasBLL();

            string validar = bllCuenta.validarCuentas(parametro);
            if (validar != "Correcto") {
                return validar;
            }

            ParametrosDAO pDao = new ParametrosDAO();
            if (pDao.actualizar(parametro) > 0)
            {
                return "Exito";  // Guardo Correctamente
            }
            else
            {
                return "Error al Guardar Parametros";
            }
        }
    }
}
