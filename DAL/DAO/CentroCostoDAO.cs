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
    public class CentroCostoDAO
    {
        public List<ECentroCosto> getAll()
        {
            ECentroCosto objCentro = null;
            List<ECentroCosto> lista = new List<ECentroCosto>();
            string sql = "SELECT * FROM centrocostos ORDER BY centro";
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
                            objCentro = mapearObjeto(dr);
                            lista.Add(objCentro);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;   
            }
        }

        public ECentroCosto buscar(string codigo)
        {
            ECentroCosto objCentro = null;
            string sql = "SELECT * FROM centrocostos WHERE centro=?codigo";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = codigo;
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objCentro = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objCentro;
            }
        }

        protected ECentroCosto mapearObjeto(MySqlDataReader fila) {
            ECentroCosto centro = new ECentroCosto { 
                Codigo = fila.GetString("centro"),
                Nombre = fila.GetString("nombre"),
                Presupuesto = fila.GetDouble("pres"),
                Nivel = fila.GetString("nivel"),       
            };
            
            return centro;
        }
    }
}
