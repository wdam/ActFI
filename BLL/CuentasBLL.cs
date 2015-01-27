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
            return CDao.buscar(codigo);
        }

        public string validarCuentas(EParametros parametro){
            ECuentas cta = null;
            CuentasDAO cDao = new CuentasDAO();
            cta = cDao.buscar(parametro.ctaActivo);
            if (cta == null)
            {
                return "La Cuenta de Activos No Existe";
            }

            cta = cDao.buscar(parametro.ctaDepreciacion);
            if (cta == null)
            {
                return "La Cuenta de Depreciacion No Existe";
            }

            cta = cDao.buscar(parametro.ctaGastos);
            if (cta == null)
            {
                return "La Cuenta de Gastos No Existe";
            }

            cta = cDao.buscar(parametro.ctaMonetaria);
            if (cta == null)
            {
                return "La Cuenta Correccion Monetaria No   Existe";
            }

            cta = cDao.buscar(parametro.ctaDepMonetaria);
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
