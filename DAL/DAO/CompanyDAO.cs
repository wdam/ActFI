using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Conexion;
using MySql.Data.MySqlClient;

namespace DAL.DAO
{
    public class CompanyDAO
    {

        public List<ECompany> getAll()
        {
            ECompany objComp = null;
            List<ECompany> lista = new List<ECompany>();
            string sql = "SELECT * FROM companias ORDER BY codigo";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objComp = mapearObjeto(dr);
                            lista.Add(objComp);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        public ECompany buscar(string login)
        {
            ECompany objComp = null;
            string sql = "SELECT * FROM companias WHERE login='" + login + "'";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
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
                            objComp = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objComp;
            }
        }

        public ECompany buscar(string login, string clave) {
            ECompany objComp = null;
            string sql = "SELECT * FROM companias WHERE login='" + login + "' AND clave='"+clave+"'";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
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
                            objComp = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objComp;
            }
        }

        public ECompany mapearObjeto(MySqlDataReader fila) {
            ECompany obj = new ECompany();
            obj.codigo = fila.GetInt16("codigo");
            obj.departamento = fila.GetString("dpto");
            obj.descripcion = fila.GetString("descripcion");
            obj.direccion = fila.GetString("direccion");
            obj.login = fila.GetString("login");
            obj.municipio = fila.GetString("mun");
            obj.nit = fila.GetString("nit");
            obj.tipo = fila.GetString("tipo");
            return obj;
        }

        public EPeriodo getPeriodo(int codigo) {
            EPeriodo objPer = null;
            string sql = "SELECT * FROM periodos WHERE codigo=" + codigo + "";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
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
                            objPer = new EPeriodo();
                            objPer.activo = dr.GetString("activo");
                            objPer.codigo = dr.GetInt16("codigo");
                            objPer.inicio = dr.GetString("inicio");
                            objPer.periodo = dr.GetString("periodo");
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objPer;
            }
        }

        
    }
}
