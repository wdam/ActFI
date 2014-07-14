using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidades;
using DAL.Conexion;
namespace DAL.DAO
{
    public class CuentasDAO
    {
        public List<ECuentas> getAll()
        {
            ECuentas objCuenta = null;
            List<ECuentas> lista = new List<ECuentas>();
            string sql = "SELECT * FROM selpuc ORDER BY codigo";
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
                            objCuenta = mapearObjeto(dr);
                            lista.Add(objCuenta);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        public ECuentas buscar(string codigo, string nivel)
        {
            string cond = "";
            if (nivel == "Auxiliar")
            {
                cond = "  AND nivel='Auxiliar'";
            }
            ECuentas objCuenta = null;
            string sql = "SELECT codigo, descripcion, naturaleza, nivel, tipo FROM  selpuc WHERE codigo =?codigo "+cond+"";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = codigo;
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objCuenta = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objCuenta;
            }
        }

        protected ECuentas mapearObjeto(MySqlDataReader fila) {
            ECuentas cuenta = new ECuentas { 
                codigo = fila.GetString("codigo"),
                descripcion = fila.GetString("descripcion"),
                naturaleza= fila.GetString("naturaleza"),
                nivel = fila.GetString("nivel"),
                tipo = fila.GetString("tipo")                 
            };
            
            return cuenta;
        }

        public int verificarAuxiliares() {
            int nReg=0;
            string sql = "SELECT COUNT(*) as nDato FROM selpuc WHERE nivel='Auxiliar' ";
            using (conexion cnx = new conexion()) { 
                 cnx.cadena = Configuracion.Instanciar.conexionBD();
                 using (MySqlCommand cmd = new MySqlCommand())
                 {
                     cmd.CommandText = sql;
                     cmd.Connection = cnx.getConexion();
                     if (cnx.abrirConexion()) {
                         MySqlDataReader dr = cmd.ExecuteReader();
                         if (dr.HasRows == true)
                         {
                             dr.Read();
                             nReg = dr.GetInt16("nDato");
                         }
                         cnx.cerrarConexion();
                     }                    
                 }                
            }
            return nReg;            
        }
    }
}
