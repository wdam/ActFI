using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;
using DAL.Conexion;
using System.Data;

namespace DAL.DAO
{
    public class TerceroDAO
    {
        public List<ETerceros> getAll()
        {
            ETerceros objTercero = null;
            List<ETerceros> lista = new List<ETerceros>();
            string sql = "SELECT nit,TRIM(CONCAT(nombre,' ',apellidos)) AS nombres FROM terceros ORDER BY nombres Limit 60";            
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
                            objTercero = mapearObjeto(dr);
                            lista.Add(objTercero);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }            
        }

        public List<ETerceros> getPorFiltro(string campo, string dato) {
            ETerceros objTercero = null;
            List<ETerceros> lista = new List<ETerceros>();
            string sql = "SELECT nit, TRIM(CONCAT(nombre,' ',apellidos)) AS nombres FROM terceros WHERE " + campo + " LIKE '%" + dato + "%'";
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
                            objTercero = mapearObjeto(dr);
                            lista.Add(objTercero);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            } 
        }

        public List<ETerceros> getPorTipo(string tipo)
        {
            ETerceros objTercero = null;
            List<ETerceros> lista = new List<ETerceros>();
            string sql = "SELECT nit,TRIM(CONCAT(apellidos,' ',nombre))AS nombres FROM terceros WHERE tipo='"+ tipo +"' ORDER BY nombres";
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
                            objTercero = mapearObjeto(dr);
                            lista.Add(objTercero);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        public ETerceros buscar(string codigo)
        {
            ETerceros objTercero = null;
            string sql = "SELECT nit, TRIM(CONCAT(nombre,' ',apellidos)) AS nombres FROM terceros WHERE nit=?codigo";
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
                            objTercero = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objTercero;
            }
        }

        public DataTable getTodos() {
            DataTable dt = new DataTable();
            string sql = "SELECT nit,TRIM(CONCAT(nombre,' ',apellidos)) AS nombres FROM terceros ORDER BY nombres ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlDataAdapter DA = new MySqlDataAdapter(sql, cnx.getConexion()))
                {
                    if (cnx.abrirConexion())
                    {
                        DA.Fill(dt);
                        cnx.cerrarConexion();
                        return dt;
                    }
                    return null;
                }
            }                        
        }

        private ETerceros mapearObjeto(MySql.Data.MySqlClient.MySqlDataReader fila)
        {
            ETerceros tercero = new ETerceros();
            tercero.nit = fila.GetString("nit");
            tercero.nombre = fila.GetString("nombres");
            return tercero;
        }

        public int insertar(ETerceros ter) {
            int reg = 0; // Obtener el numero de registros afectados 
            string sql = "INSERT INTO terceros (nit, dv, nombre, apellidos, tipo, persona, dir, pais, dept, " +
                            "mun, telefono, celular, fax, correo, cta_banco1, cbanco) " +
                            " VALUES ( ?nit, ?dv, ?nombre, ?apellidos, ?tipo, ?persona, ?dir, ?pais, ?dept, " +
                            " ?mun, ?telefono, ?celular, ?fax, ?correo, ?ctabanco1, ?cbanco)";

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                 cmd.Parameters .Add("?nit",  MySqlDbType.String).Value = ter.nit;
                 cmd.Parameters.Add("?dv", MySqlDbType.String).Value = "8";
                 cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = ter.nombre;
                 cmd.Parameters.Add("?apellidos", MySqlDbType.String).Value = ter.apellidos;
                 cmd.Parameters.Add("?tipo", MySqlDbType.String).Value = ter.tipo;
                 cmd.Parameters.Add("?persona", MySqlDbType.String).Value = ter.persona;
                 cmd.Parameters.Add("?dir", MySqlDbType.String).Value = ter.direccion;
                 cmd.Parameters.Add("?pais", MySqlDbType.String).Value = ter.pais;
                 cmd.Parameters.Add("?dept", MySqlDbType.String).Value = ter.departamento;
                 cmd.Parameters.Add("?mun", MySqlDbType.String).Value = ter.municipio;
                 cmd.Parameters.Add("?telefono", MySqlDbType.String).Value = ter.telefono;
                 cmd.Parameters.Add("?celular", MySqlDbType.String).Value = ter.celular;
                 cmd.Parameters.Add("?fax", MySqlDbType.String).Value = ter.Fax;
                 cmd.Parameters.Add("?correo", MySqlDbType.String).Value = ter.email;
                 cmd.Parameters.Add("?ctabanco1", MySqlDbType.String).Value = ter.cuenta;
                 cmd.Parameters.Add("?cbanco", MySqlDbType.String).Value = ter.banco;

                 if (cnx.abrirConexion()) {                    
                     reg = cmd.ExecuteNonQuery();
                     cnx.cerrarConexion();
                 }
               }
                return reg;
            }            
        }
    }
}