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
    public class ActivosDAO
    {
        public List<EActivos> getAll() {
            EActivos objActivo = null;
            List<EActivos> lista = new List<EActivos>();
            string sql = "SELECT ac.codigo, ac.nombre, ac.descripcion, ar.nombre AS AreaLoc, ac.estado, " +
                " ac.valComercial, ac.valLibros, ac.depajustada,  ac.proveedor, " +
                " ac.propiedad, ac.vidaUtil, ac.responsable FROM afactivos ac " +
                " INNER JOIN afarea ar ON ac.AreaLoc = ar.codigo ";                

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
            string sql = " SELECT af.codigo, af.valComercial, af.valSalvamento, af.depAcumulada, af.tipo, "+
                  " af.ctadepreciacion, af.ctagastos , af.vidaUtil, af.valLibros FROM afactivos af WHERE  " +
                  "  af.codigo NOT IN  (SELECT codigo FROM afdepreciacion WHERE periodo='" + periodo + "') " +
                  " AND af.valLibros > af.valSalvamento AND af.propiedad='PROPIO'";
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
                            act.grupo = dr.GetString("grupo");
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
            string sql = "INSERT INTO afactivos (codigo, nombre, descripcion,marca, modelo,  numSerie, referecia, " +
                            " vidaUtil, propiedad, fechaCompra, AreaLoc, responsable, proveedor, ccosto, " +
                            " estado, valComercial, valSalvamento, valLibros, valMejoras, valHistorico, " +
                            "depajustada, depAcumulada, grupo, subgrupo, ctaActivo, ctadepreciacion, ctagastos, " +
                            "ctaPerdida, ctaGanancia, ctaMantenimiento, metodoDep, fechamaxDep, mantenimiento, poliza, nFactura)   " +
                            " VALUES (?codigo, ?nombre, ?descripcion, ?marca, ?modelo, ?numSerie, ?referecia, " +
                            " ?vidaUtil, ?propiedad, ?fechaCompra, ?AreaLoc, ?responsable, ?proveedor, ?ccosto, " +
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
                    cmd.Parameters.Add("?referecia", MySqlDbType.String).Value = act.referencia;
                    cmd.Parameters.Add("?grupo", MySqlDbType.String).Value = act.grupo;
                    cmd.Parameters.Add("?subgrupo", MySqlDbType.String).Value = act.subGrupo;
                    cmd.Parameters.Add("?vidaUtil", MySqlDbType.Int32).Value = act.vidaUtil;
                    cmd.Parameters.Add("?metodoDep", MySqlDbType.VarChar).Value = act.metodoDep;

                    cmd.Parameters.Add("?propiedad", MySqlDbType.String).Value = act.propiedad;
                    cmd.Parameters.Add("?fechaCompra", MySqlDbType.String).Value = act.fecha;
                    cmd.Parameters.Add("?AreaLoc", MySqlDbType.String).Value = act.area;
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

                    cmd.Parameters.Add("?fechamaxDep", MySqlDbType.VarChar).Value = act.fechaDep;
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
            string sql = "UPDATE afactivos SET AreaLoc=?area, responsable=?responsable WHERE codigo=?codigo";
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
                       "  referecia=?referecia, propiedad=?propiedad, ccosto=?ccosto, valComercial=?valComercial, " +
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
                    cmd.Parameters.Add("?referecia", MySqlDbType.String).Value = act.referencia;                   
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

        public DataTable informeGeneral() {
            string sql = " SELECT af.codigo, af.nombre, af.numSerie, af.propiedad, af.fechaCompra AS fecha, " +
               " af.estado,  CONCAT(t.nit, ' ', t.nombre,' ', t.apellidos) responsable FROM " +
               " afactivos af INNER JOIN terceros t ON af.responsable = t.nit";           
            DataTable dt = consultar(sql);
            return dt;
        }

        public DataTable informeUbicacion(string codigo) {
            string area ="";
            if (codigo !=""){
               area = " WHERE af.AreaLoc = '"+codigo+"'";
            }
            string sql = " SELECT af.codigo, af.nombre, af.numSerie, af.propiedad, af.fechaCompra AS fecha, " +
                 " af.estado,  CONCAT(t.nit, ' ', t.nombre,' ', t.apellidos) responsable,  " +
                 " af.AreaLoc as area, a.nombre AS referencia FROM  afactivos af INNER JOIN terceros " +
                 " t ON af.responsable = t.nit INNER JOIN afarea a ON af.AreaLoc = a.codigo "+area+"";
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

        protected EActivos mapearObjeto(MySqlDataReader fila)
        {
            EActivos act = new EActivos();
            act.codigo   = fila.GetString("codigo");
            act.nombre = fila.GetString("nombre");
            act.descripcion = fila.GetString("descripcion");
            act.marca = fila.GetString("marca");
            act.modelo = fila.GetString("modelo");    
            act.numSerie = fila.GetString("numSerie") ?? "NO";
            act.referencia = fila.GetString("referecia") ?? "NO";
            act.vidaUtil = fila.GetInt32("vidaUtil");
            act.grupo = fila.GetString("grupo");
            act.subGrupo = fila.GetString("subgrupo");
            act.metodoDep = fila.GetString("metodoDep");

            act.propiedad = fila.GetString("propiedad");
            act.fecha = fila.GetString("fechaCompra");
            act.area = fila.GetString("AreaLoc");
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
            act.area = fila.GetString("AreaLoc");
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
