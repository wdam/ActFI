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
            string sql = " INSERT INTO afpolizas (idPoliza, codActivo, nPoliza, fechaInicio, fechaVence " +
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
                    cmd.Parameters.Add("?fechaInicio", MySqlDbType.String).Value = obj.fechaInicio;
                    cmd.Parameters.Add("?fechaVence", MySqlDbType.String).Value = obj.fechaVence;                   
                    cmd.Parameters.Add("?empresa", MySqlDbType.String).Value = obj.responsable;
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
    }
}
