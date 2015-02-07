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
    }
}
