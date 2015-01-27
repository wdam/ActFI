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
    public class DocumentosDAO
    {
        public int insert(string tabla, EDocumentos objDoc) {
            int nReg = 0; // Numero de registros afectados
            string sql = "INSERT INTO " + tabla +  " (item, doc, tipodoc, periodo, dia, centro, desc, debito, " +
                         " credito, codigo, base, diasv,?fechaven,?nit,?cheque,?modulo ) " +
                         " VALUES ( ?item, ?doc, ?tipodoc, ?periodo, ?dia, ?centro, ?desc, ?debito, ?credito, "+
                         " ?codigo, ?base, ?diasv,  ?fechaven,?nit,?cheque,?modulo";

            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        cmd.Parameters.Add("?item", MySqlDbType.String).Value = objDoc.item;
                        cmd.Parameters.Add("?doc", MySqlDbType.Int32).Value = objDoc.documento;
                        cmd.Parameters.Add("tipodoc", MySqlDbType.String).Value = objDoc.tipo;
                        cmd.Parameters.Add("?periodo", MySqlDbType.String).Value = objDoc.periodo;
                        cmd.Parameters.Add("?dia", MySqlDbType.String).Value = objDoc.dia;
                        cmd.Parameters.Add("?centro", MySqlDbType.String).Value = objDoc.centro;
                        cmd.Parameters.Add("?desc", MySqlDbType.String).Value = objDoc.descripcion;
                        cmd.Parameters.Add("?debito", MySqlDbType.Double).Value = objDoc.debito;
                        cmd.Parameters.Add("?credito", MySqlDbType.Double).Value = objDoc.credito;
                        cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = objDoc.codigo;
                        cmd.Parameters.Add("?base", MySqlDbType.Double).Value = objDoc.baseD;
                        cmd.Parameters.Add("?diasv", MySqlDbType.Int16).Value = objDoc.diasv;
                        cmd.Parameters.Add("?fechaven", MySqlDbType.String).Value = objDoc.fecha;
                        cmd.Parameters.Add("?nit", MySqlDbType.String).Value = objDoc.nit;
                        cmd.Parameters.Add("?cheque", MySqlDbType.String).Value = objDoc.cheque;
                        cmd.Parameters.Add("?modulo", MySqlDbType.String).Value = objDoc.modulo;

                        nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }

        public List<EDocumentos> getAll(string mes , string filtro) {
            List<EDocumentos> lstDocumentos = new List<EDocumentos>();
            EDocumentos objDoc = null;
            string sql;
            if (filtro == "Todos")
            {
                sql = "SELECT * FROM documentos"+mes+" WHERE  tipodoc in ('FB')";
            }
            else {
                sql = "SELECT * FROM documentos" + mes + " WHERE tipodoc = '" + filtro + "'";
            }

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion()) {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read()) {
                            objDoc = mapearObjeto(dr);
                            lstDocumentos.Add(objDoc);
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return lstDocumentos;
        }

        protected EDocumentos mapearObjeto(MySqlDataReader fila) {
            EDocumentos doc = new EDocumentos();
            doc.baseD = fila.GetString("base");
            doc.centro = fila.GetString("centro");
            doc.cheque = fila.GetString("cheque");
            doc.codigo = fila.GetString("codigo");
            doc.credito = fila.GetDouble("credito");
            doc.debito = fila.GetDouble("debito");
            doc.descripcion = fila.GetString("descri");
            doc.dia = fila.GetString("dia");
            doc.diasv = fila.GetInt16("diasv");
            doc.documento = fila.GetInt32("doc");
            doc.fecha = fila.GetString("fechaven");
            doc.item = fila.GetInt16("item");
            doc.modulo = fila.GetString("modulo");
            doc.nit = fila.GetString("nit");
            doc.periodo = fila.GetString("periodo");
            doc.tipo = fila.GetString("tipodoc");            
            return doc;
        }
    }

    
}
