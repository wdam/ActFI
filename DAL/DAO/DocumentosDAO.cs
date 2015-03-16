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
        public int insert(string periodo, EDocumentos objDoc) {
            int nReg = 0; // Numero de registros afectados
            string sql = "INSERT INTO documentos" + periodo + " (item, doc, tipodoc, periodo, dia, centro, descri, debito, " +
                         " credito, codigo, base, diasv, fechaven, nit, cheque, modulo ) " +
                         " VALUES ( ?item, ?doc, ?tipodoc, ?periodo, ?dia, ?centro, ?descri, ?debito, ?credito, " +
                         " ?codigo, ?base, ?diasv,  ?fechaven,?nit,?cheque,?modulo)";

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
                        cmd.Parameters.Add("?descri", MySqlDbType.String).Value = objDoc.descripcion;
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
            if (nReg > 0) {
                ActualizarCuenta(objDoc.codigo, objDoc.debito, objDoc.credito,  periodo);
            }
            return nReg;
        }

          public List<EDocumentos> getAll(string mes , string filtro) {
            List<EDocumentos> lstDocumentos = new List<EDocumentos>();
            EDocumentos objDoc = null;
            string sql;
            if (filtro == "Todos")
            {
                sql = "SELECT * FROM documentos"+mes+" WHERE  tipodoc in ('AF')";
            }
            else {
                sql = " SELECT d.doc, d.tipodoc, CONCAT(d.dia, '/',d.periodo) fecha, d.nit, CONCAT(t.nombre,' ',t.apellidos) AS nombre, " +
                      " IF(SUM(d.debito)=0,SUM(d.credito),SUM(d.debito)) AS debito FROM documentos" + mes + "  " +
                      " d INNER JOIN  terceros t ON d.nit= t.nit WHERE  tipodoc in ("+filtro+") GROUP BY tipodoc, doc ORDER BY tipodoc,doc ";
            }

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion()) {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read()) {
                            objDoc = mapearObj(dr);
                            lstDocumentos.Add(objDoc);
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return lstDocumentos;
        }

        public List<EDocumentos> buscarDocumento(int documento, string tipo, string  periodo){
            List<EDocumentos> lstDocumentos = new List<EDocumentos>();
            EDocumentos objDoc = null;            
            string sql = "SELECT * FROM documentos" + periodo + "  WHERE  tipodoc='" + tipo + "' AND doc='" + documento + "' ORDER BY item";                            
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
                            objDoc = mapearObjeto(dr);
                            lstDocumentos.Add(objDoc);
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return lstDocumentos;
        }


        public int verificar(int documento, string tipo, string periodo)
        {
            int nReg = 0;
            string sql = "SELECT * FROM documentos" + periodo + "  WHERE  tipodoc='" + tipo + "' AND doc='" + documento + "' LIMIT 1";
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
                        if (dr.HasRows == true){
                            nReg = 1;
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }
       
        public void modificarCuenta(int documento, string tipo, string periodo)
        { 
            List<EDocumentos> lstDoc = buscarDocumento(documento, tipo, periodo);
            double suma = 0;
            string debito = "debito"+periodo;
            string credito = "credito"+periodo;
            string saldo = "saldo"+periodo;
            string sql;
            int reg = 0;
            if (lstDoc.Count > 0) {
                using (conexion cnx = new conexion())
                {
                    cnx.cadena = Configuracion.Instanciar.conexionBD();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {                       
                        cmd.Connection = cnx.getConexion();
                        if (cnx.abrirConexion())
                        {
                            foreach (var item in lstDoc)
                            {
                                suma = item.debito - item.credito;
                                sql = "UPDATE selpuc SET saldo=saldo - " + suma + ", " + saldo + "=" + saldo + " - " + suma + ", " +
                                     debito + "=" + debito + " - " + item.debito + ", " +
                                     credito + "=" + credito + " - " + item.credito + " " +
                                    " WHERE codigo='" + item.codigo + "'";
                                cmd.CommandText = sql;
                                reg = cmd.ExecuteNonQuery();                               
                            }                          
                            cnx.cerrarConexion();
                        }
                    }
                }                         
            }            
        }

        public int eliminarDocumento(int documento, string tipo, string periodo)
        {
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "DELETE FROM documentos" + periodo + "  WHERE  tipodoc='" + tipo + "' AND doc='" + documento + "'  ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();                   
                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }               
            }
            return reg;
        }

        private void ActualizarCuenta(string cuenta, double dto, double cto, string periodo ){
            double suma = 0;
            string debito = "debito" + periodo;
            string credito = "credito" + periodo;
            string saldo = "saldo" + periodo;
            string sql;
            int nReg = 0;
            suma = dto - cto;
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        sql = "UPDATE selpuc SET saldo=saldo +  ?suma , " + saldo + "=" + saldo + " +  ?suma , " +
                                 debito + "=" + debito + " + ?dto , " +
                                 credito + "=" + credito + " + ?cto "  +
                                " WHERE codigo='" + cuenta + "'";

                        cmd.Parameters.Add("?suma", MySqlDbType.Double).Value = suma;
                        cmd.Parameters.Add("?dto", MySqlDbType.Double).Value = dto;
                        cmd.Parameters.Add("?cto", MySqlDbType.Double).Value = cto;

                            cmd.CommandText = sql;
                            nReg=cmd.ExecuteNonQuery();                        
                        cnx.cerrarConexion();
                    }
                }
            }  
        }

        protected EDocumentos mapearObjeto(MySqlDataReader fila)
        {
            EDocumentos doc = new EDocumentos();
            doc.baseD = fila.GetDouble("base");
            doc.centro = (fila.GetString("centro") != "0") ? fila.GetString("centro") : "";
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

        protected EDocumentos mapearObj(MySqlDataReader fila)
        {
            EDocumentos doc = new EDocumentos();
            doc.debito = fila.GetDouble("debito");
            doc.fecha = fila.GetString("fecha");
            doc.documento = fila.GetInt32("doc");
            doc.nit = fila.GetString("nit");
            doc.modulo = fila.GetString("nombre");
            doc.tipo = fila.GetString("tipodoc");
            return doc;
        }


        public void insertObservacion(int documento, string tipo, string observacion, string periodo) {
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        string sql = "REPLACE INTO obsdocumentos"+periodo+" SET doc=?doc, tipodoc=?tipo , comentario=?observ ";
                        cmd.Parameters.Add("?doc", MySqlDbType.Int32).Value = documento;
                        cmd.Parameters.Add("?tipo", MySqlDbType.String).Value = tipo;
                        cmd.Parameters.Add("?observ", MySqlDbType.String).Value = observacion;

                        cmd.CommandText = sql;
                        int nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
        }

        public string getObservacion(int documento, string tipo, string periodo) {
            string Observacion="";
            string sql = "SELECT * FROM obsdocumentos" + periodo + "  WHERE  tipodoc='" + tipo + "' AND doc='" + documento + "' ";
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
                            Observacion = dr.GetString("comentario");                            
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return Observacion;            
        }
    }
   
}
