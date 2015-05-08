using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ValidacionesBLL:IDisposable
    {
        public bool esUsuarioValido(string usuario)
        {
            return usuario.Trim().Length > 5 && usuario.Trim().Length < 10;            
        }

        public bool esIdentificacionValida(string cedula)
        {
            return cedula.Trim().Length >= 7 && cedula.Trim().Length <= 14;
        }

        public bool noEstaVacio(string dato)
        {
            return dato.Trim().Length > 0;
        }

        public bool esEmailValido(string email)
        {
            System.Text.RegularExpressions.Regex emailRegex = new System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$");
            System.Text.RegularExpressions.Match emailMatch = emailRegex.Match(email);
            return emailMatch.Success;
        }

        public bool esPasswordValida(string clave)
        {           
            return clave.Trim().Length >= 4;
        }

        public bool esTelefonoValido(string telefono)
        {           
            return telefono.Trim().Length >= 6 && telefono.Trim().Length <= 12;
        }

        public bool esCodigoValido(string codigo)
        {
            return codigo.Trim().Length > 5 && codigo.Trim().Length < 10;            
        }

        public bool esCodigoAreaValida(string codigo)
        {           
            return codigo.Trim().Length == 4;
        }

        public bool esValorValido(string valor) { 
            try 
	        {	        
		       return Convert.ToDouble(valor) > 0;
            }
	       catch (Exception)
	        {
                return false;    
	        }
        }

        #region Implementacion de IDisposable
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }
            }
            this.disposed = true;
        }
        #endregion  
    }
}
