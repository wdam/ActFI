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
    public  class MantenimientoDAO
    {
        public int insertar(EMantenimiento obj)
        {
            int nReg = 0;
            string sql = " INSERT INTO afmantenimiento (codActivo, nContrato, fInicio, fVence, " +
                " nVisitas, proveedor, valor)  VALUES (?codActivo, ?nContrato,  " +
                " ?fInicio, ?fVence , ?nVisitas, ?proveedor,  ?valor)";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codActivo", MySqlDbType.VarChar).Value = obj.codActivo;
                    cmd.Parameters.Add("?nContrato", MySqlDbType.String).Value = obj.nContrato;
                    cmd.Parameters.Add("?fInicio", MySqlDbType.Date).Value = obj.fInicio;
                    cmd.Parameters.Add("?fVence", MySqlDbType.Date).Value = obj.fVence;
                    cmd.Parameters.Add("?nVisitas", MySqlDbType.Int16).Value = obj.nVisitas;
                    cmd.Parameters.Add("?proveedor", MySqlDbType.String).Value = obj.proveedor;
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

        public EMantenimiento buscar(string codigo) {
            EMantenimiento obj = null;
            string sql = "SELECT * FROM afmantenimiento WHERE codActivo=?codigo";
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

        protected EMantenimiento mapearObjeto(MySqlDataReader fila)
        {
            EMantenimiento objMto = new EMantenimiento();
            objMto.idMto = fila.GetInt32("idMto");
            objMto.codActivo = fila.GetString("codActivo");
            objMto.nContrato = fila.GetString("nContrato");
            objMto.fInicio = fila.GetString("fInicio");
            objMto.fVence = fila.GetString("fVence");
            objMto.nVisitas = fila.GetInt16("nVisitas");
            objMto.proveedor = fila.GetString("proveedor");
            objMto.valor = fila.GetDouble("valor");           
            return objMto;
        }
    }
}
