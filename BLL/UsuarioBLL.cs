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
