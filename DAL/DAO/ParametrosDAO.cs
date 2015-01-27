using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Conexion;
using MySql .Data.MySqlClient;

namespace DAL.DAO
{
    public class ParametrosDAO
    {
        public List<EParametros> getParamentro()
        {
            EParametros objPar = null;
            List<EParametros> lista = new List<EParametros>();
            string sql = "SELECT * FROM  afparametros  WHERE codigo = 1";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objPar = mapearObjeto(dr);                            
                            lista.Add(objPar);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        public int actualizar(EParametros parametro) {
            int reg = 0;
            string sql = "UPDATE afparametros SET ctaActivo=?ctaActivo, ctadepreciacion=?ctadepreciacion, ctagastos=?ctagastos, " +
                            "ctamonetaria=?ctamonetaria , ctadepreMon=?ctadepreMon WHERE codigo=?codigo";
            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()){
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = parametro.Codigo;
                    cmd.Parameters.Add("?ctaActivo", MySqlDbType.String).Value = parametro.ctaActivo;
                    cmd.Parameters.Add("?ctadepreciacion", MySqlDbType.String).Value = parametro.ctaDepreciacion;
                    cmd.Parameters.Add("?ctagastos", MySqlDbType.String).Value = parametro.ctaGastos;
                    cmd.Parameters.Add("?ctamonetaria", MySqlDbType.String).Value = parametro.ctaMonetaria;
                    cmd.Parameters.Add("?ctadepreMon", MySqlDbType.String).Value = parametro.ctaDepMonetaria;

                    if (cnx.abrirConexion()) {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
                return reg;
            }        
        }

        public EParametros mapearObjeto(MySqlDataReader fila) {
            EParametros objPar = new EParametros();
            objPar.Codigo = fila.GetString("codigo");
            objPar.ctaActivo = fila.GetString("ctaActivo");
            objPar.ctaDepreciacion = fila.GetString("ctadepreciacion");
            objPar.ctaGastos = fila.GetString("ctagastos");
            objPar.ctaMonetaria = fila.GetString("ctamonetaria");
            objPar.ctaDepMonetaria = fila.GetString("ctadepreMon");
            return objPar;
        }
    }
}
