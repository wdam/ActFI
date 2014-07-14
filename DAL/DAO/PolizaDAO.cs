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
    public class PolizaDAO
    {
        public int insertar(EPolizas obj) {
            int nReg = 0;
            string sql = " INSERT INTO afpolizas (idPoliza, codActivo, nPoliza, fechaInicio, fechaVence, " +
                " responsable, telefono, deducible, valor, empresa )  VALUES (NUll, ?codActivo, ?nPoliza,  " +
                " ?fechaInicio, ?fechaVence , ?responsable, ?telefono, ?deducible, ?valor, ?empresa)";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codActivo", MySqlDbType.VarChar).Value = obj.codActivo;
                    cmd.Parameters.Add("?nPoliza", MySqlDbType.String).Value = obj.nPoliza;
                    cmd.Parameters.Add("?fechaInicio", MySqlDbType.Date).Value = obj.fechaInicio;
                    cmd.Parameters.Add("?fechaVence", MySqlDbType.Date).Value = obj.fechaVence;                   
                    cmd.Parameters.Add("?empresa", MySqlDbType.String).Value = obj.empresa;
                    cmd.Parameters.Add("?responsable", MySqlDbType.String).Value = obj.responsable;
                    cmd.Parameters.Add("?telefono", MySqlDbType.String).Value = obj.telefono;
                    cmd.Parameters.Add("?deducible", MySqlDbType.Double).Value = obj.deducible;
                    cmd.Parameters.Add("?valor", MySqlDbType.Double).Value = obj.valor;                  

                    if (cnx.abrirConexion())
                    {
                        nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }

        public EPolizas buscar(string codigo) {
            EPolizas obj = null;
            string sql = "SELECT * FROM afpolizas WHERE codActivo=?codigo";
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
                            obj = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return obj;
        }

        protected EPolizas mapearObjeto(MySqlDataReader fila)
        {
            EPolizas poliza = new EPolizas { 
                idPoliza = fila.GetInt32("idPoliza"),
                codActivo = fila.GetString("codActivo"),
                nPoliza = fila.GetString("nPoliza"),
                empresa = fila.GetString("empresa"),
                fechaInicio = fila.GetString("fechaInicio"),
                fechaVence = fila.GetString("fechaVence"),
                responsable = fila.GetString("responsable"),
                telefono = fila.GetString("telefono"),
                deducible = fila.GetDouble("deducible"),
                valor = fila.GetDouble("valor")
            };           
            return poliza;
        }
    }
}
