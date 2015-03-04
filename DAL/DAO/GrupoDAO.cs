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
    public class GrupoDAO
    {
        public int insertar(EGrupo obj, string operacion){ 
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "";
            if (operacion == "Nuevo") {
                sql = "INSERT INTO afgrupo (sigla, descripcion, metodoDep, valSalvamento, vidaUtil ," +
                       " ctaActivo, ctaDepreciacion, ctaGastos, ctaPerdida, ctaGanancia, ctaRevalorizar, " +
                       " ctaMantenimiento, ctaCorreccion, estado) VALUES (?sigla, ?descripcion, ?metodoDep, " +
                       " ?valSalvamento, ?vidaUtil, ?ctaActivo, ?ctaDepreciacion, ?ctaGastos, ?ctaPerdida," +
                       " ?ctaGanancia, ?ctaRevalorizar, ?ctaMantenimiento, ?ctaCorreccion, ?estado ) ";
            }
            else if (operacion == "Editar") {
                sql = "UPDATE afgrupo SET  descripcion=?descripcion, metodoDep=?metodoDep, "+
                       "valSalvamento=?valSalvamento, vidaUtil=?vidaUtil , ctaActivo=?ctaActivo," +
                       " ctaDepreciacion=?ctaDepreciacion, ctaGastos=?ctaGastos, ctaPerdida=?ctaPerdida, "+
                       " ctaGanancia=?ctaGanancia, ctaRevalorizar=?ctaRevalorizar,ctaMantenimiento=?ctaMantenimiento," +
                       "  ctaCorreccion=?ctaCorreccion, estado=?estado WHERE sigla=?sigla ";
            }
             
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?sigla", MySqlDbType.String).Value = obj.sigla;
                    cmd.Parameters.Add("?descripcion",MySqlDbType.String).Value = obj.descripcion;
                    cmd.Parameters.Add("?metodoDep", MySqlDbType.String).Value = obj.metodoDep;
                    cmd.Parameters.Add("?valSalvamento", MySqlDbType.Int16).Value = obj.valSalvamento;
                    cmd.Parameters.Add("?vidaUtil", MySqlDbType.Int32).Value = obj.vidaUtil;
                    cmd.Parameters.Add("?ctaActivo", MySqlDbType.String).Value = obj.ctaActivo;
                    cmd.Parameters.Add("?ctaDepreciacion", MySqlDbType.VarChar).Value = obj.ctaDepreciacion;
                    cmd.Parameters.Add("?ctaGastos", MySqlDbType.VarChar).Value = obj.ctaGastos;
                    cmd.Parameters.Add("?ctaPerdida", MySqlDbType.VarChar).Value = obj.ctaPerdida;
                    cmd.Parameters.Add("?ctaGanancia", MySqlDbType.VarChar).Value = obj.ctaGanancia;
                    cmd.Parameters.Add("?ctaRevalorizar", MySqlDbType.VarChar).Value = obj.ctaRevalorizar;
                    cmd.Parameters.Add("?ctaMantenimiento", MySqlDbType.VarChar).Value = obj.ctaMantenimiento;
                    cmd.Parameters.Add("?ctaCorreccion", MySqlDbType.VarChar).Value = obj.ctaCorreccion;
                    cmd.Parameters.Add("?estado", MySqlDbType.String).Value = obj.estado;

                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }              
            }
            return reg;
        }

        public int guardarSubgrupo(ESubgrupo obj, string operacion)
        {
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "";
            if (operacion == "Nuevo")
            {
                sql = "INSERT INTO afsubgrupo (codigo, descripcion, estado, grupo )" +
                      " VALUES (?codigo, ?descripcion,  ?estado, ?grupo )";
                      
            }
            else if (operacion == "Editar")
            {
                sql = "UPDATE SET afsubgrupo SET  descripcion=?descripcion, estado=?estado,  " +
                      " grupo=?grupo WHERE codigo=?codigo"; 
            }

            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = obj.codigo;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;
                    cmd.Parameters.Add("?grupo", MySqlDbType.String).Value = obj.grupo;                   
                    cmd.Parameters.Add("?estado", MySqlDbType.String).Value = obj.estado;

                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
            }
            return reg;
        }

       

        public List<EGrupo> getAll(string filtro) {
            string condicion = "";
            if (filtro == "Todos")
            {
                condicion = "";
            }
            else {
                condicion = " estado = '" + filtro + "'";
            }
            List<EGrupo> lista = new List<EGrupo>();
            string sql = "SELECT  sigla, descripcion, consecutivo, estado FROM afgrupo "+condicion+"";
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
                            EGrupo objGrup = new EGrupo();
                            objGrup.sigla = dr.GetString("sigla");
                            objGrup.descripcion = dr.GetString("descripcion");
                            objGrup.consecutivo = dr.GetInt32("consecutivo");
                            objGrup.estado = dr.GetString("estado");
                            lista.Add(objGrup);
                        }
                        cnx.cerrarConexion();
                    }
                }               
            }
            return lista;
        }

        public List<ESubgrupo> getSubgrupo(string grupo)
        {            
            List<ESubgrupo> lista = new List<ESubgrupo>();
            string sql = "SELECT  * FROM afsubgrupo where grupo='"+grupo+"' ";
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
                            ESubgrupo objGrup = new ESubgrupo();
                            objGrup.codigo = dr.GetString("codigo");
                            objGrup.descripcion = dr.GetString("descripcion");
                            objGrup.consecutivo = dr.GetInt32("consecutivo");
                            objGrup.estado = dr.GetString("estado");
                            objGrup.grupo = dr.GetString("grupo");
                            lista.Add(objGrup);
                        }
                        cnx.cerrarConexion();
                    }
                }
            }
            return lista;
        }

        public EGrupo buscar(string codigo)
        {
            EGrupo objGrupo = null;
            string sql = "SELECT * FROM afgrupo WHERE sigla=?sigla";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?sigla", MySqlDbType.String).Value = codigo;
                    if (cnx.abrirConexion())
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objGrupo = mapearObjeto(dr);
                        }
                        cnx.cerrarConexion();
                    }
                }                
            }
            return objGrupo;
        }



        protected EGrupo mapearObjeto(MySqlDataReader fila)
        {
            EGrupo objG = new EGrupo();
            objG.sigla = fila.GetString("sigla");
            objG.consecutivo = fila.GetInt32("consecutivo");
            objG.ctaActivo = fila.GetString("ctaActivo");
            objG.ctaCorreccion = fila.GetString("ctaCorreccion");
            objG.ctaDepreciacion = fila.GetString("ctaDepreciacion");
            objG.ctaGanancia = fila.GetString("ctaGanancia");
            objG.ctaGastos = fila.GetString("ctaGastos");
            objG.ctaMantenimiento = fila.GetString("ctaMantenimiento");
            objG.ctaPerdida = fila.GetString("ctaPerdida");
            objG.ctaRevalorizar = fila.GetString("ctaRevalorizar");
            objG.descripcion = fila.GetString("descripcion");
            objG.estado = fila.GetString("estado");
            objG.metodoDep = fila.GetString("metodoDep");
            objG.valSalvamento = fila.GetInt16("valSalvamento");
            objG.vidaUtil = fila.GetInt32("vidaUtil");

            return objG;
        }
    }
}
