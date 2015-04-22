using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;

namespace BLL
{
    public class UsuarioBLL
    {
        /// <summary>
        /// Buscar Usuario 
        /// </summary>
        /// <param name="login">Login o Nombre de Usuario</param>
        /// <param name="clave">Clave de Usuario</param>
        /// <returns></returns>
        public EUsuario buscar(string login, string clave) {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(clave))
            {
                return null; 
            }
            UsuarioDAO uDao = new UsuarioDAO();
            return uDao.buscar(login, clave);
        }                       
    }
}
