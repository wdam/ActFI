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
    }
}
