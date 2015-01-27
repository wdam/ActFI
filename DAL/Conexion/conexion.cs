using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL.Conexion
{
    public class conexion:IDisposable
    {


        private MySqlConnection cnx { get; set; }

        public string cadena { get; set; }
     
        public MySqlConnection getConexion() {

            if (cnx == null) {
                cnx = new MySqlConnection(cadena);
            }
            return cnx;
        }

        public bool abrirConexion() {
            if (cnx.State == System.Data.ConnectionState.Closed) {
                cnx.Open();              
                return true;              
            }
            return false;
        }

        public  void cerrarConexion(){
            cnx.Close();
        }

        //Destructor de la Clase
        ~conexion()
        {
            this.Dispose(false);
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
            if (!this.disposed) {
                if (disposing) {
                    
                }
            }
            this.disposed = true;
        }
        #endregion  
    }
}
