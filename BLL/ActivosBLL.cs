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

        /// <summary>
        /// Retorna una Lista con los Activos a Depreciar
        /// </summary>
        /// <returns></returns>
        public List<EActivos> getDepreciar()
        {           
            return aDao.getAll(Inicializar.Mes);
        }        

        public string insertar(EActivos obj) {
            string validar;
            validar = validarCuentas(obj.ctaActivo, obj.ctaDepreciacion, obj.ctaGastos, obj.ctaPerdida, obj.ctaGanancia);
            if (validar != "Correcto")
            {
                return validar;
            }   
         
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

        /// <summary>
        /// Validacion de Cuentas del Activo
        /// </summary>
        /// <param name="ctaActivo">Cuenta del Activo</param>
        /// <param name="ctaDepreciacion">Cuenta Depreciacion</param>
        /// <param name="ctaGastos">Cuenta Gastos</param>
        /// <param name="ctaPerdida">Cuenta de Perdida</param>
        /// <param name="ctaGanancia">Cuenta de Gananacia</param>
        /// <returns></returns>

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

        /// <summary>
        /// Trasladar Activo
        /// </summary>
        /// <param name="codigo">Codigo del Activo</param>
        /// <param name="area">Area o Ubicacion</param>
        /// <param name="responsable">Responsable del Activo</param>
        /// <returns></returns>
        public int trasladar(string codigo, string area, string responsable) {            
            return aDao.trasladar(codigo,area, responsable);
        }

        /// <summary>
        /// Actualizacion de Valores
        /// </summary>
        /// <param name="valLibro">Valor en Libros</param>
        /// <param name="valDepAjus">Valor Depreciacion Ajustada</param>
        /// <param name="valDeprAcum">Valor Depreciacion Acumulada</param>
        /// <param name="codigo">Codigo del Activo</param>
        public void UpdateValores(double valLibro, double valDepAjus, double valDeprAcum, string codigo){
            if (string.IsNullOrEmpty(codigo)){
                return;
            }           
            aDao.UpdateValores(valLibro, valDepAjus, valDeprAcum, codigo);
        }

        public DataTable informeGeneral() {
            return aDao.informeGeneral();
        }
        /// <summary>
        /// Retorna un Datatable con Datos Filtrado por Ubicacion
        /// </summary>
        /// <param name="codigo">Codigo de Area o Ubicacion</param>
        /// <param name="propiedad">Tipo de Propiedad</param>
        /// <returns></returns>
        public DataTable informeUbicacion(string codigo, string propiedad) {
            return aDao.informeUbicacion(codigo, propiedad);
        }

        /// <summary>
        /// Retorna un Datatable con Valores de Cada Activo
        /// </summary>
        /// <returns></returns>
        public DataTable informeValores() {
            return aDao.informeValores();
        }

        /// <summary>
        /// Retorna Datos Filtrados por Grupo y Subgrupo
        /// </summary>
        /// <param name="grupo">Codigo del Grupo</param>
        /// <param name="subgrupo">Codigo del Subgrupo</param>
        /// <param name="fInicio">Rango de Fecha Inicial</param>
        /// <param name="fFinal">Rango de Fecha Final</param>
        /// <returns></returns>
        public DataTable informeGrupo(string grupo, string subgrupo, string fInicio, string fFinal) {
            if (string.IsNullOrEmpty(grupo) || string.IsNullOrEmpty(subgrupo)) {
                return null;
            }
            if (string.IsNullOrEmpty(fInicio)) {
                return null;
            }
            return aDao.informePorGrupo(grupo, subgrupo, fInicio, fFinal);
        }
    }
}
