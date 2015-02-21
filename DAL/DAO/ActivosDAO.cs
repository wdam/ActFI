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
                return lista;
            }
        }

        public List<EActivos> getAll(string tipo) {
            EActivos objActivo = null;
            List<EActivos> lista = new List<EActivos>();
            string sql = "SELECT * FROM afactivos WHERE  valLibros   > valSalvamento";


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
                            objActivo = mapearObjeto(dr);
                            lista.Add(objActivo);
                        }
                        cnx.cerrarConexion();
                    }
                }             
            }
            return lista;
        }

        public int insertar(EActivos act) {
            int reg=0;
            string sql = "INSERT INTO afactivos (codigo, nombre, descripcion, numSerie, referecia, tipo, " +
                            " vidaUtil, propiedad, fechaCompra, AreaLoc, responsable, proveedor, ccosto, " +
                            " estado, valComercial, valSalvamento, valLibros, valMejoras, valHistorico, " +
                            "depajustada, depAcumulada, ctaActivo, ctadepreciacion, ctagastos, " +
                            "ctamonetaria, ctadepreMon, Adep) VALUES  " +
                            "(?codigo, ?nombre, ?descripcion, ?numSerie, ?referecia, ?tipo, " +
                            " ?vidaUtil, ?propiedad, ?fechaCompra, ?AreaLoc, ?responsable, ?proveedor, ?ccosto, " +
                            " ?estado, ?valComercial, ?valSalvamento, ?valLibros, ?valMejoras, ?valHistorico, " +
                            " ?depajustada, ?depAcumulada, ?ctaActivo, ?ctadepreciacion, ?ctagastos, " +
                            "?ctamonetaria, ?ctadepreMon, ?Adep)";

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = act.codigo;
                    cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = act.nombre;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = act.descripcion;
                    cmd.Parameters.Add("?numSerie", MySqlDbType.String).Value = act.numSerie;
                    cmd.Parameters.Add("?referecia", MySqlDbType.String).Value = act.referencia;
                    cmd.Parameters.Add("?tipo", MySqlDbType.String).Value = act.tipo;
                    cmd.Parameters.Add("vidaUtil", MySqlDbType.String).Value = act.vidaUtil;

                    cmd.Parameters.Add("?propiedad", MySqlDbType.String).Value = act.propiedad;
                    cmd.Parameters.Add("?fechaCompra", MySqlDbType.DateTime).Value = act.fecha;
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
                    cmd.Parameters.Add("?ctamonetaria", MySqlDbType.String).Value = act.ctaMonetaria;
                    cmd.Parameters.Add("?ctadepreMon", MySqlDbType.String).Value = act.ctaDepMonetaria;
                    cmd.Parameters.Add("?Adep", MySqlDbType.String).Value = "2";

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
            string sql = "UPDATE afactivos SET nombre=?nombre, descripcion=?descripcion, numSerie=?numSerie, referecia=?referecia, " +
                            " propiedad=?propiedad, ccosto=?ccosto, valComercial=?valComercial, valSalvamento=?valSalvamento," +
                            " valLibros=?valLibros, ctaActivo=?ctaActivo, ctadepreciacion=?ctadepreciacion, " +
                            " ctagastos=?ctagastos, ctamonetaria=?ctamonetaria, ctadepreMon=?ctadepreMon WHERE codigo=?codigo ";
                           

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
                   
                    cmd.Parameters.Add("?valComercial", MySqlDbType.Double).Value = act.valComercial;
                    cmd.Parameters.Add("?valSalvamento", MySqlDbType.Double).Value = act.valSalvamento;
                    cmd.Parameters.Add("?valLibros", MySqlDbType.Double).Value = act.valLibros;
                    cmd.Parameters.Add("?ctaActivo", MySqlDbType.String).Value = act.ctaActivo;
                    cmd.Parameters.Add("?ctadepreciacion", MySqlDbType.String).Value = act.ctaDepreciacion;
                    cmd.Parameters.Add("?ctagastos", MySqlDbType.String).Value = act.ctaGastos;
                    cmd.Parameters.Add("?ctamonetaria", MySqlDbType.String).Value = act.ctaMonetaria;
                    cmd.Parameters.Add("?ctadepreMon", MySqlDbType.String).Value = act.ctaDepMonetaria;
                    

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

        protected EActivos mapearObjeto(MySqlDataReader fila)
        {
            EActivos act = new EActivos();
            act.codigo   = fila.GetString("codigo");
            act.nombre = fila.GetString("nombre");
            act.descripcion = fila.GetString("descripcion");            
            act.numSerie = fila.GetString("numSerie") ?? "NO";
            act.referencia = fila.GetString("referecia") ?? "NO";
            act.vidaUtil = fila.GetInt32("vidaUtil");
            act.tipo = fila.GetString("tipo");

            act.propiedad = fila.GetString("propiedad");
            act.fecha = fila.GetDateTime("fechaCompra");
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
            act.ctaMonetaria = fila.GetString("ctamonetaria");
            act.ctaDepMonetaria = fila.GetString("ctadepreMon");
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
