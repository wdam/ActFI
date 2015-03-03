using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class GrupoBLL
    {
        GrupoDAO gDao = new GrupoDAO();
        public string insertar(EGrupo objGrupo, string operacion) {
            if (objGrupo.sigla.ToString().Length < 0) {
                return "La Sigla no puede ser vacia";
            }

            if (string.IsNullOrEmpty(objGrupo.descripcion)) {
                return "La Descripcion del Grupo no puede ser vacia";
            }

            if (gDao.insertar(objGrupo, operacion) > 0)
            {
                return "Exito";
            }
            else {
                return "Error al Guardar datos del Grupo";
            }
        }

        public List<EGrupo> getAll(string estado) {
            if (string.IsNullOrWhiteSpace(estado))
            {
                return null;
            }
           return  gDao.getAll(estado);
        }

        public EGrupo buscar(string codigo) {
            if (string.IsNullOrEmpty(codigo)) {
                return null;
            }
            return gDao.buscar(codigo);
        }
    }
}
