using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Conexion;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.DAO
{
    public class MovimientoDAO
    {
        public int insertar(EMovimientos obj)
        {
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "INSERT INTO afmovimientos (idMovimiento, documento, tipodoc,periodo," +
                        " fecha, tipoMov, descripcion, codActivo, valor, estado, ccosto, nitc)  " +
                        " VALUES (null, ?documento, ?tipodoc, ?periodo, ?fecha, ?tipoMov,"+
                        " ?descripcion, ?codActivo, ?valor, ?estado, ?ccosto, ?nitc)";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?documento", MySqlDbType.String).Value = obj.documento;
                    cmd.Parameters.Add("?tipodoc", MySqlDbType.String).Value = obj.tipoDoc;
                    cmd.Parameters.Add("?periodo", MySqlDbType.String).Value = obj.periodo;
                    cmd.Parameters.Add("?fecha", MySqlDbType.DateTime).Value = obj.fecha;
                    cmd.Parameters.Add("?tipoMov", MySqlDbType.String).Value = obj.tipoMov;
                    cmd.Parameters.Add("?codActivo", MySqlDbType.String).Value = obj.codActivo;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;                 
                    cmd.Parameters.Add("?valor", MySqlDbType.String).Value = obj.valor;
                    cmd.Parameters.Add("?estado", MySqlDbType.String).Value = obj.estado;
                    cmd.Parameters.Add("?ccosto", MySqlDbType.String).Value = obj.cCosto;
                    cmd.Parameters.Add("?nitc", MySqlDbType.String).Value = obj.nit;

                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return reg;
        }
               
        /// <summary>
        /// Obtener Todos los Movimientos Dependiendo de los filtros
        /// </summary>
        /// <param name="tipo">Tipo de Documento</param>
        /// <param name="activo">Codigo del Activo</param>
        /// <param name="perInicial">Periodo Inicial</param>
        /// <param name="perFinal">Periodo Final</param>
        /// <returns></returns>
        public DataTable getAll(string tipo, string activo, string perInicial, string perFinal)
        {
            string sql = "";
            string tipodoc = "";
            string codigo = "";
            if (tipo != "Todos") {
                tipodoc = "AND tipodoc ='" + tipo + "'";
            }
            if (activo != "Todos") {
                codigo = "AND codActivo = '" + activo + "'";
            }

             sql =" SELECT documento, tipodoc, periodo, fecha, codActivo as codigo, af.nombre,  "+
                  " af.grupo, af.subgrupo, af.ccosto, aa.nombre  AS areaLoc FROM afmovimientos am " +
                  " INNER JOIN afactivos af ON am.codActivo=af.codigo INNER JOIN afarea aa "+
                  " ON af.AreaLoc=aa.codigo WHERE am.periodo BETWEEN '" + perInicial + "'"+
                  " AND '" + perFinal + "' " + tipodoc + " " + codigo + " ORDER BY tipodoc,documento";            
            return  consultar(sql);
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

        //protected EMovimientos mapearObjeto(MySqlDataReader fila)
        //{
        //    EMovimientos mov = new EMovimientos();
        //    mov.idMovimiento = fila.GetInt32("idMovimiento");
        //    mov.documento = fila.GetString("documento");
        //    mov.tipoDoc = fila.GetString("tipodoc");
        //    mov.periodo = fila.GetString("periodo");
        //    mov.fecha = fila.GetDateTime("fecha");
        //    mov.tipoMov = fila.GetString("tipoMov");
        //    return mov;
        //}
    }
}
