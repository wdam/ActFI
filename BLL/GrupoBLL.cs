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

        public string guardarSubgrupo(ESubgrupo objSubgrupo, string operacion)
        {
            if (objSubgrupo.codigo.ToString().Length < 0)
            {
                return "El codigo no puede ser vacio";
            }

            if (string.IsNullOrEmpty(objSubgrupo.descripcion))
            {
                return "La Descripcion del subgrupo no puede ser vacio";
            }

            if (gDao.guardarSubgrupo(objSubgrupo, operacion) > 0)
            {
                return "Exito";
            }
            else
            {
                return "Error al Guardar datos del Subgrupo";
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

        public ESubgrupo buscarSubgrupo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return null;
            }
            return gDao.buscarSubgrupo(codigo);
        }

        public List<ESubgrupo> getSubgrupo(string grupo) {
            if (string.IsNullOrWhiteSpace(grupo))
            {
                return null;
            }
            return gDao.getSubgrupo(grupo);
        }
    }
}
