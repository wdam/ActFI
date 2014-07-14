using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;
using DAL.Conexion;

namespace DAL.DAO
{
    public class UsuarioDAO
    {
        public List<EUsuario> getAll()
        {
            EUsuario objUser = null;
            List<EUsuario> lista = new List<EUsuario>();
            string sql = "SELECT * FROM USUARIOS ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objUser = mapearObjeto(dr);
                            lista.Add(objUser);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        public EUsuario buscar(string login, string passw)
        {
            EUsuario objUser = null;
            string sql = "SELECT * FROM USUARIOS WHERE LOGIN=?login AND PASSW=?clave AND estado='activo'";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?login", MySqlDbType.String).Value = login;
                    cmd.Parameters.Add("?clave", MySqlDbType.String).Value = passw;
                    
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objUser = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objUser;
            }
        }
        
        protected EUsuario mapearObjeto(MySqlDataReader fila) {
            EUsuario user = new EUsuario{
                nombre = fila.GetString("nombres"),
                apellidos = fila.GetString("Apellidos"),
                login = fila.GetString("login"),
                clave = fila.GetString("passw"),
                rol = fila.GetString("rol"),
                estado = fila.GetString("estado")
            };           
            return user;
        }
    }
}
