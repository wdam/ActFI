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

        public DataTable tablaDepreciacion(string codigo, string perInicial, string perFinal) {
            string condicion = "";
            if (perInicial != "Todos") {
                condicion = " AND periodo BETWEEN '" + perInicial + "' AND '" + perFinal + "'";
            }
            string sql = " SELECT d.codigo, af.nombre, af.ccosto, af.fechaCompra AS fecha, " +
                " af.valComercial, d.periodo, d.valLibros, d.depreciacion AS depajustada, " +
                " d.depAcumulada FROM afdepreciacion d INNER JOIN afactivos " +
                " af ON d.codigo = af.codigo WHERE d.codigo='"+codigo+"' "+condicion+" ORDER BY periodo ";

            return consultar(sql);
        }

        public DataTable activosPorDepreciar() {
            string sql = " SELECT af.codigo, af.fechamaxDep, MAX(d.fecha) AS fecha, " +
                " af.valComercial, af.valLibros, af.valSalvamento, af.depAcumulada, " +
                " TIMESTAMPDIFF(MONTH,MAX(d.fecha),af.fechamaxDep ) meses " +
                " FROM afactivos af  INNER JOIN afdepreciacion d ON af.codigo = d.codigo " +
                " GROUP BY codigo  HAVING meses > 0";

            return consultar(sql);
        }

        private DataTable consultar(string sql)
        {
            DataTable dt = null;
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                        dt = new DataTable();
                        DA.Fill(dt);
                        cnx.cerrarConexion();
                    }
                }
            }
            return dt;
        }
    }
}
