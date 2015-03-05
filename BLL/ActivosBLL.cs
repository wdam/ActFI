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
    public class ActivosBLL
    {
        ActivosDAO aDao = new ActivosDAO();
        public List<EActivos> getActivos() {           
            return aDao.getAll();
        }

        public List<EActivos> getActivos(string tipo)
        {           
            return aDao.getAll(Inicializar.Mes);
        }        

        public string insertar(EActivos obj) {        
          
            //string validar = bllCuenta.validarCuentas(parametro);
            //if (validar != "Correcto")
            //{
            //    return validar;
            //}
         
            if (aDao.insertar(obj) > 0)
            {
                return "Exito"; //Datos Guardados Correctamente
            }
            else {
                return "Error al Guardar los Datos del Activo";
            }
        }

        public string actualizar(EActivos obj) {
            string validar;
            validar = validarCuentas(obj.ctaActivo, obj.ctaDepreciacion, obj.ctaGastos, obj.ctaPerdida, obj.ctaGanancia);                                                 
               
            if (validar !="Correcto"){
                 return validar;
            }           
            if (aDao.actualizar(obj) > 0)
            {
                return "Exito";// Datos Actualizados Correctamente
            }
            else
            {
                return "Error al Actualizar los Datos";
            }
        }

        private string validarCuentas(string ctaActivo, string ctaDepreciacion, string ctaGastos, string ctaPerdida, string ctaGanancia)
        {
            ECuentas cta = null;
            CuentasDAO cDao = new CuentasDAO();

            cta = cDao.buscar(ctaActivo,"");
            if (cta == null)
            {
                return "La Cuenta de Activos No Existe";
            }

            cta = cDao.buscar(ctaDepreciacion,"");
            if (cta == null)
            {
                return "La Cuenta de Depreciacion No Existe";
            }

            cta = cDao.buscar(ctaGastos,"");
            if (cta == null)
            {
                return "La Cuenta de Gastos No Existe";
            }

            cta = cDao.buscar(ctaGanancia,"");
            if (cta == null)
            {
                return "La Cuenta de Ganancias  No   Existe";
            }

            cta = cDao.buscar(ctaPerdida,"");
            if (cta == null)
            {
                return "La Cuenta de Perdida No Existe";
            }
            return "Correcto";
        }

        public EActivos buscar(string codigo) {
            if (string.IsNullOrEmpty(codigo)) {
                return null;
            }          
            return aDao.buscar(codigo);
        }

        public int trasladar(string codigo, string area, string responsable) {            
            return aDao.trasladar(codigo,area, responsable);
        }

        public void UpdateValores(double valLibro, double valDepAjus, double valDeprAcum, string codigo){
            if (string.IsNullOrEmpty(codigo)){
                return;
            }           
            aDao.UpdateValores(valLibro, valDepAjus, valDeprAcum, codigo);
        }

        public DataTable informeGeneral() {
            return aDao.informeGeneral();
        }
    }
}
