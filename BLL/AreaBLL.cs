using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
   public class AreaBLL
    {
       ValidacionesBLL Val = new ValidacionesBLL();
       public string insertar(EArea area) {
           if (!Val.esCodigoAreaValida(area.codigo)) { 
                return "Codigo del Area Incorrecto.. ";
           }

           if (!Val.noEstaVacio(area.nombre)) {
               return "Ingrese el Nombre del Area.. ";
           }

           AreaDAO aDao = new AreaDAO();
           if (aDao.insertar(area) > 0)
           {
               return "Exito"; // Datos Guardados Correctamente
           }
           else {
               return "Error al Guardar Los Datos";
           }
       }

       public string actualizar(EArea area) {
           if (!Val.esCodigoAreaValida(area.codigo))
           {
               return "Codigo del Area Incorrecto.. ";
           }

           if (!Val.noEstaVacio(area.nombre))
           {
               return "Ingrese el Nombre del Area.. ";
           }

           AreaDAO aDao = new AreaDAO();
           if (aDao.actualizar(area) > 0)
           {
               return "Exito"; // Datos Actualizados Correctamente
           }
           else
           {
               return "Error al Actualizar Los Datos";
           }
       }

       public List<EArea> getAll() {
           AreaDAO aDao = new AreaDAO();
           return aDao.getAll();
       }

       public EArea buscar(string codigo) {
           if (string.IsNullOrWhiteSpace(codigo)) {
               return null;
           }
           AreaDAO aDao = new AreaDAO();
           return aDao.buscar(codigo);
       }

    }
}
