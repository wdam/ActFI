using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;
using DAL.Conexion;
using System.Data;


namespace BLL
{
    public class TerceroBLL
    {
        
        
        public List<ETerceros> getAll() {                        
                TerceroDAO tdao = new TerceroDAO();
                return tdao.getAll();                              
        }

        public DataTable getTodos() {
            TerceroDAO tDao = new TerceroDAO();
            return tDao.getTodos();
        }

        public ETerceros buscar(string codigo) {
            if (string.IsNullOrWhiteSpace(codigo)) {
                return null;
            } 
            TerceroDAO tdao = new TerceroDAO();
            return tdao.buscar(codigo);
        }

        public ETerceros buscarTercero(string codigo) {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return null;
            }
            TerceroDAO tdao = new TerceroDAO();
            return tdao.buscarTercero(codigo);
        }

        public List<ETerceros> buscar(string campo, string dato) {
            if (campo == "Nombre")
            {
                campo = "nombre";
            }
            else {
                campo = "nit";
            }
            TerceroDAO tDao = new TerceroDAO();
            return tDao.getPorFiltro(campo, dato);
        }

        public List<ETerceros> getTipo(string tipo) {
            if (string.IsNullOrEmpty(tipo)) {
                return null;
            }
            TerceroDAO tDao = new TerceroDAO();
            return tDao.getPorTipo(tipo);
        }

        public string insert(ETerceros obj) {
            TerceroDAO tDao = new TerceroDAO();
            if (string.IsNullOrWhiteSpace(obj.nit)) {
                return "Nit o Cedula Esta  Vacia";
            }

            if (string.IsNullOrWhiteSpace(obj.nit)) {
                return "Falta el Nombre ";
            }

            if (tDao.insertar(obj) > 0) {
                return "Exito"; // Datos Guardados 
            }
            else
            {
                return "Error al Guardar los Datos";
            }
        }

        public string actualizar(ETerceros obj)
        {
            TerceroDAO tDao = new TerceroDAO();
            if (string.IsNullOrWhiteSpace(obj.nit))
            {
                return "Nit o Cedula Esta  Vacia";
            }

            if (string.IsNullOrWhiteSpace(obj.nit))
            {
                return "Falta el Nombre ";
            }

            if (tDao.actualizar(obj) > 0)
            {
                return "Exito"; // Datos Guardados 
            }
            else
            {
                return "Error al modificar los Datos";
            }
        }
    }
}
