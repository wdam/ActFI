using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entidades;
using MySql.Data.MySqlClient;

namespace DAL.DAO
{
    public class TrasladosDAO
    {
        public int insertar(ETraslados objT) {
            int nReg = 0;
            string sql = "INSERT INTO aftraslados (idTraslado, codActivo, areaAnt, responAnt, fecha,  " +
                         " nuevaArea, nuevoResp, observacion) VALUES (NULL,?codActivo, ?areaAnt, ?responAnt,  " +
                         " ?fecha, ?nuevaArea, ?nuevoResp, ?observacion )";

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    
                    cmd.Parameters.Add("?codActivo", MySqlDbType.String).Value = objT.activo;
                    cmd.Parameters.Add("?areaAnt", MySqlDbType.String).Value = objT.areaAnt;
                    cmd.Parameters.Add("?responAnt", MySqlDbType.String).Value = objT.respAnt;
                    cmd.Parameters.Add("?fecha", MySqlDbType.Timestamp).Value = objT.fecha;
                    cmd.Parameters.Add("?nuevaArea", MySqlDbType.String).Value = objT.nuevaArea;
                    cmd.Parameters.Add("?nuevoResp", MySqlDbType.String).Value = objT.nuevoResp;
                    cmd.Parameters.Add("?observacion", MySqlDbType.String).Value = objT.observacion;

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
