using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using MySql.Data.MySqlClient;
using Entidades;

namespace DAL.DAO
{
    public class TipoDocumentoDAO
    {
        public List<ETipoDocumento> getAll()
        {
            ETipoDocumento objTipo = null;           
            List<ETipoDocumento> lista = new List<ETipoDocumento>();           
            string sql = "SELECT tipodoc, grupo, descripcion FROM tipdoc WHERE grupo = 'AF' ";                
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objTipo = new ETipoDocumento();
                            objTipo.tipoDoc = dr.GetString("tipodoc");
                            objTipo.grupo = dr.GetString("grupo");
                            objTipo.descripcion = dr.GetString("descripcion");                            
                            lista.Add(objTipo);
                        }
                        cnx.cerrarConexion();
                    }
                }             
            }
            return lista;
        }

        public ETipoDocumento buscarTipo(string tipo, string periodo) {
            ETipoDocumento objTipo = null;
            string sql = "SELECT tipodoc, grupo, descripcion , (actual"+periodo+" + 1) actual FROM tipdoc WHERE tipodoc='" + tipo + "' AND grupo ='AF' ORDER BY tipodoc";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();                    
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objTipo = new ETipoDocumento();
                            objTipo.tipoDoc = dr.GetString("tipodoc");
                            objTipo.grupo = dr.GetString("grupo");
                            objTipo.descripcion = dr.GetString("descripcion");
                            objTipo.actual = dr.GetInt16("actual");
                        }
                        cnx.cerrarConexion();
                    }
                }                
            }
            return objTipo;           
        }

        public int updateConsecutivo(int actual, string tipodoc, string periodo) {            
            int nReg = 0;
            string sql = " Update tipdoc set actual" + periodo + "=?actual WHERE tipodoc=?tipodoc AND actual" +periodo+ "<?actual  ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        cmd.Parameters.Add("?actual", MySqlDbType.Int32).Value = actual;
                        cmd.Parameters.Add("?tipodoc", MySqlDbType.String).Value = tipodoc;                        
                        cmd.CommandText = sql;
                        nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }



        public int insertar(ETipoDocumento obj)
        {

            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "INSERT INTO tipdoc (tipodoc, grupo, descripcion, inicio01, actual01) VALUES (?tipodoc, ?grupo, ?descripcion, 0, 0)";

            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?tipodoc", MySqlDbType.String).Value = obj.tipoDoc;
                    cmd.Parameters.Add("?grupo", MySqlDbType.String).Value = obj.grupo;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;

                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return reg;
        }

        public int actualizar(ETipoDocumento obj, string periodo)
        {
            int nReg = 0;
            string sql = " Update tipdoc set actual" + periodo + "=?actual, " +
                    " descripcion=?descripcion WHERE tipodoc=?tipodoc  ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        cmd.Parameters.Add("?tipodoc", MySqlDbType.String).Value = obj.tipoDoc;                        
                        cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;
                        cmd.Parameters.Add("?actual", MySqlDbType.Int16).Value = obj.actual;
                        cmd.CommandText = sql;
                        nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }
    }
}
