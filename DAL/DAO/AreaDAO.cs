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
    public class AreaDAO
    {
        public int insertar(EArea obj) { 

            int reg  = 0; // Obtiene el numero de Registros afectados
            string sql = "INSERT INTO afarea (codigo, nombre, descripcion) VALUES (?codigo, ?nombre, ?descripcion)";

            using (conexion cnx = new conexion()) {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = obj.codigo;
                    cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = obj.nombre;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;

                    if (cnx.abrirConexion()) {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
                return reg;
            }           
        } 

        public  List<EArea> getAll (){
            EArea  objArea = null;
            List<EArea> lista = new List<EArea>();
            string sql  = "SELECT * FROM afarea ";
            using (conexion cnx = new conexion()){
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion()){
                     MySqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read()){
                            objArea = mapearObjeto (dr);
                            lista.Add (objArea);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

        protected EArea mapearObjeto(MySqlDataReader fila){
           EArea area  = new EArea();
            area.codigo =  fila.GetString ("codigo");
            area.nombre = fila.GetString ("nombre");
            area.descripcion = fila.GetString ("descripcion");
            return area;
        }

        public int actualizar(EArea obj)
        {
            int reg = 0; // Obtiene el numero de Registros afectados
            string sql = "UPDATE  afArea SET nombre=?nombre, descripcion=?descripcion WHERE  codigo=?codigo";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = Configuracion.Instanciar.conexionBD();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();

                    cmd.Parameters.Add("?codigo", MySqlDbType.String).Value = obj.codigo;
                    cmd.Parameters.Add("?nombre", MySqlDbType.String).Value = obj.nombre;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.String).Value = obj.descripcion;
                    if (cnx.abrirConexion())
                    {
                        reg = cmd.ExecuteNonQuery();
                        cnx.cerrarConexion();
                    }
                }
                return reg;
            }
        }

        public EArea buscar(string codigo) {
            EArea obj = null;
            string sql = "SELECT * FROM afarea WHERE codigo=?codigo";
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
                return obj;
            }
        }
        
    }
}
