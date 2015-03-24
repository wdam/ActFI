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
    public class DepreciacionDAO
    {
        public int insertar(List<EDepreciacion> lstDepre) { 
            int nReg=0;
            string sql = "INSERT INTO afdepreciacion (documento, codigo, periodo, valLibros, depreciacion, depAcumulada )" +
                                          " VALUES  (?documento, ?codigo, ?periodo, ?valLibros, ?depreciacion, ?depAcumulada)";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                cnx.getConexion();
                if (cnx.abrirConexion())
                { 
                    foreach (EDepreciacion item in lstDepre)
                {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                            cmd.CommandText = sql;
                            cmd.Connection = cnx.getConexion();                                                                                             
                            cmd.Parameters.Add("?documento", MySqlDbType.String).Value = item.documento;
                            cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = item.codigo;
                            cmd.Parameters.Add("?periodo", MySqlDbType.String).Value = item.periodo;
                            cmd.Parameters.Add("?valLibros", MySqlDbType.Double).Value = item.valLibros;
                            cmd.Parameters.Add("?depreciacion", MySqlDbType.Double).Value = item.depreciacion;
                            cmd.Parameters.Add("?depAcumulada", MySqlDbType.Double).Value = item.depAcumulada;
                            nReg += cmd.ExecuteNonQuery();
                        }                       
                        
                 }
                    cnx.cerrarConexion();
                }
            }
            return nReg;
        }
    }
}
