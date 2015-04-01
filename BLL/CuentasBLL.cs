using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class CuentasBLL
    {
        public List<ECuentas> getAll() {
            CuentasDAO CDao = new CuentasDAO();
            return CDao.getAll();        
        }

        public ECuentas buscar(string codigo) {
            if (string.IsNullOrWhiteSpace(codigo)) {
                return null;
            }
            CuentasDAO CDao = new CuentasDAO();
            return CDao.buscar(codigo,"");
        }

        public ECuentas buscar(string codigo, string nivel)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return null;
            }
            CuentasDAO CDao = new CuentasDAO();
            return CDao.buscar(codigo, nivel);
        }

        public string validarCuentas(EParametros parametro){
            ECuentas cta = null;
            CuentasDAO cDao = new CuentasDAO();
            cta = cDao.buscar(parametro.ctaCaja, "");
            if (cta == null)
            {
                return "La Cuenta de Caja No Existe";
            }

            cta = cDao.buscar(parametro.ctaIVA, "");
            if (cta == null)
            {
                return "La Cuenta de I.V.A no Existe";
            }

            cta = cDao.buscar(parametro.ctaBanco,"");
            if (cta == null)
            {
                return "La Cuenta de Bancos No Existe";
            }

            cta = cDao.buscar(parametro.ctaProveedor,"");
            if (cta == null)
            {
                return "La Cuenta de Proveedores No Existe";
            }

            cta = cDao.buscar(parametro.ctaDepMonetaria,"");
            if (cta == null)
            {
                return "La Cuenta de Depreciacion de la Correccion Monetaria No Existe";
            }

            return "Correcto";
        }

        public int validarAuxiliares() {
            CuentasDAO cDao = new CuentasDAO();
            return  cDao.verificarAuxiliares();
        }
    }
}
