﻿using System;
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
    public class ActivosDAO
    {
        public List<EActivos> getAll() {
            EActivos objActivo = null;
            List<EActivos> lista = new List<EActivos>();
            string sql = "SELECT ac.codigo, ac.nombre, ac.descripcion, ar.nombre AS areaLoc, ac.estado, " +
                " ac.valComercial, ac.valLibros, ac.depajustada,  ac.proveedor, " +
                " ac.propiedad, ac.vidaUtil, ac.responsable FROM afactivos ac " +
                " INNER JOIN afarea ar ON ac.areaLoc = ar.codigo ";                

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) { 
                     cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read()) {
                            objActivo = mapear(dr);
                            lista.Add(objActivo);
                        }
                        cnx.cerrarConexion();
                    }
                }               
            }
            return lista;
        }

        public List<EActivos> getAll(string periodo) {
         
            List<EActivos> lista = new List<EActivos>();
            string sql = " SELECT af.codigo, af.valComercial, af.valSalvamento, af.depAcumulada,  "+
                  " af.ctadepreciacion, af.ctagastos , af.vidaUtil, af.valLibros FROM afactivos af WHERE  " +
                  "  af.codigo NOT IN  (SELECT codigo FROM afdepreciacion WHERE periodo='" + periodo + "') " +
                  " AND af.valLibros > af.valSalvamento AND af.propiedad='PROPIO' AND af.metodoDep <>'NDP'";
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
                            EActivos act = new EActivos();
                            act.codigo = dr.GetString("codigo");                        
                            act.vidaUtil = dr.GetInt32("vidaUtil");
                           // act.grupo = dr.GetString("grupo");
                            act.valComercial = dr.GetDouble("valComercial");
                            act.valSalvamento = dr.GetDouble("valSalvamento");
                            act.valLibros = dr.GetDouble("valLibros");                            
                            act.depAcumulada = dr.GetDouble("depAcumulada");                          
                            act.ctaDepreciacion = dr.GetString("ctadepreciacion");
                            act.ctaGastos = dr.GetString("ctagastos");
                           
                            lista.Add(act);
                        }
                        cnx.cerrarConexion();
                    }
                }             
            }
            return lista;
        }

        public int insertar(EActivos act) {
            int reg=0;
            string sql = "INSERT INTO afactivos (codigo, nombre, descripcion,marca, modelo,  numSerie, referencia, " +
                            " vidaUtil, propiedad, fechaCompra, areaLoc, responsable, proveedor, ccosto, " +
                            " estado, valComercial, valSalvamento, valLibros, valMejoras, valHistorico, " +
                            "depajustada, depAcumulada, grupo, subgrupo, ctaActivo, ctadepreciacion, ctagastos, " +
                            "ctaPerdida, ctaGanancia, ctaMantenimiento, metodoDep, fechamaxDep, mantenimiento, poliza, nFactura)   " +
                            " VALUES (?codigo, ?nombre, ?descripcion, ?marca, ?modelo, ?numSerie, ?referencia, " +
                            " ?vidaUtil, ?propiedad, ?fechaCompra, ?areaLoc, ?responsable, ?proveedor, ?ccosto, " +
                            " ?estado, ?valComercial, ?valSalvamento, ?valLibros, ?valMejoras, ?valHistorico, " +
                            " ?depajustada, ?depAcumulada, ?grupo, ?subgrupo, ?ctaActivo, ?ctadepreciacion, ?ctagastos, " +
                            "?ctaPerdida, ?ctaGanancia, ?ctaMantenimiento, ?metodoDep, ?fechamaxDep, ?mantenimiento, ?poliza, ?nFactura)";

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = act.codigo;
                    cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = act.nombre;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = act.descripcion;
                    cmd.Parameters.Add("?marca", MySqlDbType.String).Value = act.marca;
                    cmd.Parameters.Add("?modelo", MySqlDbType.String).Value = act.modelo;
                    cmd.Parameters.Add("?numSerie", MySqlDbType.String).Value = act.numSerie;
                    cmd.Parameters.Add("?referencia", MySqlDbType.String).Value = act.referencia;
                    cmd.Parameters.Add("?grupo", MySqlDbType.String).Value = act.grupo;
                    cmd.Parameters.Add("?subgrupo", MySqlDbType.String).Value = act.subGrupo;
                    cmd.Parameters.Add("?vidaUtil", MySqlDbType.Int32).Value = act.vidaUtil;
                    cmd.Parameters.Add("?metodoDep", MySqlDbType.VarChar).Value = act.metodoDep;

                    cmd.Parameters.Add("?propiedad", MySqlDbType.String).Value = act.propiedad;
                    cmd.Parameters.Add("?fechaCompra", MySqlDbType.Date).Value = act.fecha;
                    cmd.Parameters.Add("?areaLoc", MySqlDbType.String).Value = act.area;
                    cmd.Parameters.Add("?responsable", MySqlDbType.String).Value = act.responsable;
                    cmd.Parameters.Add("?proveedor", MySqlDbType.String).Value = act.proveedor;
                    cmd.Parameters.Add("?ccosto", MySqlDbType.String).Value = act.centrocosto;
                    cmd.Parameters.Add("?estado", MySqlDbType.String).Value = act.estado;

                    cmd.Parameters.Add("?valComercial", MySqlDbType.Double).Value = act.valComercial;
                    cmd.Parameters.Add("?valSalvamento", MySqlDbType.Double).Value = act.valSalvamento;
                    cmd.Parameters.Add("?valLibros", MySqlDbType.Double).Value = act.valLibros;
                    cmd.Parameters.Add("?valMejoras", MySqlDbType.Double).Value = act.valMejoras;
                    cmd.Parameters.Add("?valHistorico", MySqlDbType.Double).Value = act.valHistorico;
                    cmd.Parameters.Add("?depajustada", MySqlDbType.Double).Value = act.depAjustada;
                    cmd.Parameters.Add("?depAcumulada", MySqlDbType.Double).Value = act.depAcumulada;

                    cmd.Parameters.Add("?ctaActivo", MySqlDbType.String).Value = act.ctaActivo;
                    cmd.Parameters.Add("?ctadepreciacion", MySqlDbType.String).Value = act.ctaDepreciacion;
                    cmd.Parameters.Add("?ctagastos", MySqlDbType.String).Value = act.ctaGastos;
                    cmd.Parameters.Add("?ctaPerdida", MySqlDbType.String).Value = act.ctaPerdida;
                    cmd.Parameters.Add("?ctaGanancia", MySqlDbType.String).Value = act.ctaGanancia;
                    cmd.Parameters.Add("?ctaMantenimiento", MySqlDbType.String).Value = act.ctaMantenimiento;

                    cmd.Parameters.Add("?fechamaxDep", MySqlDbType.Date).Value = act.fechaDep;
                    cmd.Parameters.Add("?mantenimiento", MySqlDbType.String).Value = act.mantenimiento;
                    cmd.Parameters.Add("?poliza", MySqlDbType.String).Value = act.poliza;
                    cmd.Parameters.Add("?nFactura", MySqlDbType.String).Value = act.nFactura;
                    
                    if (cnx.abrirConexion()) {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
                return reg;
            }
        }

        public EActivos buscar(string codigo) {
            EActivos objAct = null;
            string sql = "SELECT * FROM afactivos WHERE codigo=?codigo";
            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = codigo;
                    if (cnx.abrirConexion()) {
                        MySqlDataReader  dr= cmd.ExecuteReader();
                        if (dr.HasRows == true ) {
                            dr.Read();
                            objAct = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return objAct;
            }
        }

        public int trasladar(string codigo, string area, string responsable) { 
            int reg = 0;
            string sql = "UPDATE afactivos SET areaLoc=?area, responsable=?responsable WHERE codigo=?codigo";
            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = codigo;
                    cmd.Parameters.Add("?area", MySqlDbType.String).Value = area;
                    cmd.Parameters.Add("?responsable", MySqlDbType.String).Value = responsable;

                    if (cnx.abrirConexion()) {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
                return reg;
            }            
        }

        public int actualizar(EActivos act) {
            int reg = 0;
            string sql = "UPDATE afactivos SET nombre=?nombre, descripcion=?descripcion, numSerie=?numSerie, " +
                       "  referencia=?referencia, propiedad=?propiedad, ccosto=?ccosto, valComercial=?valComercial, " +
                       " valSalvamento=?valSalvamento, ctaActivo=?ctaActivo, ctadepreciacion=?ctadepreciacion, " +
                       " ctagastos=?ctagastos, ctaPerdida=?ctaPerdida, ctaGanancia=?ctaGanancia, " +
                       " ctaMantenimiento=?ctaMantenimiento, estado=?estado WHERE codigo=?codigo ";
                           

            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = act.codigo;
                    cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = act.nombre;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = act.descripcion;
                    cmd.Parameters.Add("?numSerie", MySqlDbType.String).Value = act.numSerie;
                    cmd.Parameters.Add("?referencia", MySqlDbType.String).Value = act.referencia;                   
                    cmd.Parameters.Add("?propiedad", MySqlDbType.String).Value = act.propiedad;                   
                    cmd.Parameters.Add("?ccosto", MySqlDbType.String).Value = act.centrocosto;
                    cmd.Parameters.Add("?estado", MySqlDbType.String).Value = act.estado;
                   
                    cmd.Parameters.Add("?valComercial", MySqlDbType.Double).Value = act.valComercial;
                    cmd.Parameters.Add("?valSalvamento", MySqlDbType.Double).Value = act.valSalvamento;
                    
                    cmd.Parameters.Add("?ctaActivo", MySqlDbType.String).Value = act.ctaActivo;
                    cmd.Parameters.Add("?ctadepreciacion", MySqlDbType.String).Value = act.ctaDepreciacion;
                    cmd.Parameters.Add("?ctagastos", MySqlDbType.String).Value = act.ctaGastos;
                    cmd.Parameters.Add("?ctaPerdida", MySqlDbType.String).Value = act.ctaPerdida;
                    cmd.Parameters.Add("?ctaGanancia", MySqlDbType.String).Value = act.ctaGanancia;
                    cmd.Parameters.Add("?ctaMantenimiento", MySqlDbType.String).Value = act.ctaMantenimiento;
                    
                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }

                }               
            }
            return reg;
        }

        public int UpdateValores(double valLibro, double valDepAjus, double valDeprAcum, string codigo)
        {
            int nReg = 0;
            string sql = "UPDATE afactivos SET valLibros = ?valLibros, depAcumulada = ?depAcumulada, " +
                         " depajustada = ?depajustada  WHERE codigo =?codigo ";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = codigo;
                    cmd.Parameters.Add("?valLibros", MySqlDbType.Double).Value = valLibro;
                    cmd.Parameters.Add("?depajustada", MySqlDbType.Double).Value = valDepAjus;
                    cmd.Parameters.Add("?depAcumulada", MySqlDbType.Double).Value = valDeprAcum;                                       
                    if (cnx.abrirConexion())
                    {
                        nReg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return nReg;
        }


        #region Proceso para Informes

        public DataTable informeBasico(string codigo) { 
          string sql = "SELECT af.codigo, af.nombre, af.descripcion, af.marca, af.modelo, af.numSerie, "+
                        " IFNULL(CONCAT(af.ccosto, ' ', cc.nombre),'NO DEFINIDO') ccosto, "+
                        " af.estado, af.ctaActivo, af.ctaActivo, af.ctaDepreciacion, af.ctaGastos, "+
                        " af.valComercial, af.valLibros, af.depAcumulada, af.depajustada, af.vidaUtil, " +
                        " af.fechaCompra as fecha, af.propiedad, af.numSerie, af.referencia, af.valSalvamento, af.valMejoras, " +
                        " CONCAT(af.AreaLoc, ' ',aa.nombre) AS areaLoc, CONCAT(af.proveedor,' ',tt.nombre)  "+
                        " AS proveedor , CONCAT(af.responsable,' ', t.nombre) responsable, af.valHistorico " +
                        " FROM afactivos af INNER JOIN afarea aa  ON af.areaLoc = aa.codigo "+
                        " INNER JOIN terceros t ON  af.responsable  = t.nit  INNER JOIN terceros tt ON  af.proveedor=tt.nit "+
                        " LEFT JOIN centrocostos cc ON af.ccosto = cc.centro WHERE af.codigo='"+codigo+"'";
          return consultar(sql); 
        }

        public DataTable informePorGrupo(string grupo, string subgrupo, string fInicio, string fFinal) {
            string condG = "";
            string condSub = "";
            string condF = "";

            if (grupo != "Todos") {
                condG = " AND af.grupo='" + grupo + "'";
            }
            if (subgrupo != "Todos") {
                condSub = " AND af.subgrupo = '"+subgrupo+"'";
            }

            if (fInicio != "Todos") {
                condF = " AND af.fechaCompra  BETWEEN '" + fInicio + "' AND '" + fFinal + "' ";
            }

            string sql = "SELECT  af.codigo, af.nombre, af.fechaCompra As fecha, af.ctaActivo, af.valComercial, "+
                    " af.valLibros, af.depAcumulada, af.grupo, g.descripcion AS referencia, "+
                    " af.subgrupo, s.descripcion AS numSerie FROM afactivos af INNER JOIN "+
                    " afgrupo g ON af.grupo = g.sigla INNER JOIN afsubgrupo s ON af.subgrupo = s.codigo" +
                    " WHERE  af.ctaActivo<>'' " + condG + " " + condSub + " "+condF+"";
            return consultar(sql); 
        }

        
        public DataTable informeGeneral(string filtro) {
            string cond = "";
            if (filtro != "TODOS")
            {
                cond = " WHERE af.propiedad='" + filtro + "'";
            }
            string sql = " SELECT af.codigo, af.nombre, af.numSerie, af.propiedad, af.fechaCompra AS fecha, " +
               " af.estado,  CONCAT(t.nit, ' ', t.nombre,' ', t.apellidos) responsable , " +
               " af.valComercial, af.valLibros, af.depAcumulada, af.valMejoras  FROM " +
               " afactivos af INNER JOIN terceros t ON af.responsable = t.nit "+cond+"";           
           return consultar(sql);            
        }

        public DataTable informeGeneral(string filtro, string agrupar)
        {
            string sql = ""; 
            if (agrupar == "responsable")
            {
                sql = " SELECT af.codigo, af.nombre, af.numSerie, af.propiedad, af.estado, af.ccosto, " +
                        "CONCAT(af.areaLoc,' ', aa.nombre)AS  areaLoc, " +
                        " af.fechaCompra AS fecha, CONCAT(t.nombre,' ', t.apellidos) AS documento,  " +
                        " t.nit AS responsable,  af.valComercial, af.valLibros, af.depAcumulada, af.valMejoras" +
                        " FROM  afactivos af INNER JOIN terceros t ON af.responsable = t.nit " +
                        " INNER JOIN afarea aa ON af.areaLoc = aa.codigo  ";
            }
            else { 
                sql =" SELECT af.codigo, af.nombre, af.numSerie, af.propiedad, af.estado,"+
                     " af.fechaCompra AS fecha, CONCAT(af.areaLoc,' ', aa.nombre)AS  areaLoc, "+
                     " af.ccosto, cc.nombre AS documento, af.responsable, af.valComercial, af.valLibros, " +
                     " af.depAcumulada, af.valMejoras FROM  afactivos af INNER JOIN "+
                     " centrocostos cc ON af.ccosto = cc.centro INNER JOIN afarea aa ON af.areaLoc = aa.codigo ";
            }

            if (filtro != "TODOS") {
                sql += "WHERE af.propiedad='" + filtro + "'";
            }

            return consultar(sql);    
        }

        public DataTable informeValores() {
            string sql = "SELECT codigo, nombre, fechaCompra As fecha, valComercial, valLibros, "+
                " valSalvamento, depAcumulada FROM afactivos WHERE estado<>'BAJA' ";
            return consultar(sql);            
       }

        public DataTable informeUbicacion(string codigo, string propiedad) {
            string area ="";
            string filtroP = ""; // filtro de Propiedad
            if (codigo !=""){
               area = " AND af.areaLoc = '"+codigo+"'";
            }
            if (propiedad != "Todos") {
                filtroP = "AND propiedad='" + propiedad + "'";
            }
            string sql = " SELECT af.codigo, af.nombre, af.numSerie, af.propiedad,  af.fechaCompra AS fecha, " +
                 " af.estado,  CONCAT(t.nit, ' ', t.nombre,' ', t.apellidos) responsable,  " +
                 " af.areaLoc, a.nombre AS referencia FROM  afactivos af INNER JOIN terceros " +
                 " t ON af.responsable = t.nit INNER JOIN afarea a ON af.areaLoc = a.codigo WHERE estado <> 'BAJA' "+area +""+filtroP+"";
            DataTable dt = consultar(sql);
            return dt;
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
        #endregion
        protected EActivos mapearObjeto(MySqlDataReader fila)
        {
            EActivos act = new EActivos();
            act.codigo   = fila.GetString("codigo");
            act.nombre = fila.GetString("nombre");
            act.descripcion = fila.GetString("descripcion");
            act.marca = fila.GetString("marca");
            act.modelo = fila.GetString("modelo");    
            act.numSerie = fila.GetString("numSerie") ?? "NO";
            act.referencia = fila.GetString("referencia") ?? "NO";
            act.vidaUtil = fila.GetInt32("vidaUtil");
            act.grupo = fila.GetString("grupo");
            act.subGrupo = fila.GetString("subgrupo");
            act.metodoDep = fila.GetString("metodoDep");

            act.propiedad = fila.GetString("propiedad");
            act.fecha = fila.GetString("fechaCompra");
            act.area = fila.GetString("areaLoc");
            act.responsable = fila.GetString("responsable");
            act.proveedor = fila.GetString("proveedor");
            act.centrocosto = fila.GetString("ccosto");
            act.estado = fila.GetString("estado");

            act.valComercial = fila.GetDouble("valComercial");
            act.valSalvamento = fila.GetDouble("valSalvamento");
            act.valLibros = fila.GetDouble("valLibros");
            act.valMejoras = fila.GetDouble("valMejoras");
            act.valHistorico = fila.GetDouble("valHistorico");
            act.depAjustada = fila.GetDouble("depajustada");
            act.depAcumulada = fila.GetDouble("depAcumulada");

            act.ctaActivo = fila.GetString("ctaActivo");
            act.ctaDepreciacion = fila.GetString("ctadepreciacion");
            act.ctaGastos = fila.GetString("ctagastos");
            act.ctaGanancia = fila.GetString("ctaGanancia");
            act.ctaMantenimiento = fila.GetString("ctaPerdida");
            act.ctaPerdida = fila.GetString("ctaMantenimiento");

            act.fechaDep = fila.GetString("fechamaxDep");
            act.mantenimiento = fila.GetString("mantenimiento");
            act.poliza = fila.GetString("poliza");
            act.nFactura = fila.GetString("nFactura");
            return act;
        }

        protected EActivos mapear(MySqlDataReader fila){
            EActivos act = new EActivos();
            act.codigo = fila.GetString("codigo");
            act.nombre = fila.GetString("nombre");
            act.descripcion = fila.GetString("descripcion");
            act.vidaUtil = fila.GetInt32("vidaUtil");
            
            act.propiedad = fila.GetString("propiedad");
            act.area = fila.GetString("areaLoc");
            act.responsable = fila.GetString("responsable");
            act.proveedor = fila.GetString("proveedor");            
            act.estado = fila.GetString("estado");

            act.valComercial = fila.GetDouble("valComercial");            
            act.valLibros = fila.GetDouble("valLibros");
            act.depAjustada = fila.GetDouble("depajustada");
            return act;
        }
    }
}
