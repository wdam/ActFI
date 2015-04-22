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
        /// <summary>
        /// Retorna una lista de todas las Compañias
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar Compañia
        /// </summary>
        /// <param name="login">Nombre o Sigla de la Compañia</param>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar Compañia
        /// </summary>
        /// <param name="login">Nombre o Sigla de la Compañia</param>
        /// <param name="clave">Clave de la Compañia</param>
        /// <returns></returns>
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

        public EPeriodo getPeriodo(int? codigo) {
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
            }
            return objPer;
        }

        public int guardarPeriodo(string periodo, string accion, int? codigo) {
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "";
            if (accion == "Nuevo") {
                sql = " INSERT INTO periodos (periodo, inicio, activo, codigo ) Values (?periodo, '00','SI', ?codigo) ";                
            }
            else {
                sql = " Update periodos set activo='SI', periodo=?periodo WHERE codigo=?codigo";
            }            

            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.Int16).Value = codigo;
                    cmd.Parameters.Add("?periodo", MySqlDbType.String).Value = periodo;                    
                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }                
            }
            return reg;
        }

        public List<EPeriodo> getPerBloqueado(string bloqueado) {
            
            List<EPeriodo> lstPeriodos = new List<EPeriodo>();
            string sql = "SELECT * FROM bloq_per WHERE bloqueado = '"+bloqueado + "'  AND periodo <> '00' ORDER BY periodo";
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
                            EPeriodo  objPer = new EPeriodo();
                            objPer.periodo = dr.GetString("periodo");
                            objPer.bloqueado = dr.GetChar("bloqueado");
                            lstPeriodos.Add(objPer);
                        }
                        cnx.cerrarConexion();
                    }
                }                
            }
            return lstPeriodos;
        }

        
    }
}
