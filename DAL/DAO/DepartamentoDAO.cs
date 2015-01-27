using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Conexion;

namespace DAL.DAO
{
    public class DepartamentoDAO
    {
        public List<EDepartamentos> getDepartamentos()
        {
            EDepartamentos objDepart = null;
            List<EDepartamentos> lista = new List<EDepartamentos>();
            string sql = "SELECT * FROM dptos";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    if (cnx.abrirConexion())
                    {
                        MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {                            
                            objDepart = new EDepartamentos();
                            objDepart.codigo = dr.GetString("codigo");
                            objDepart.descripcion = dr.GetString("descripcion");                            
                            lista.Add(objDepart);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }


        public List<EDepartamentos> getMunicipios(string depar)
        {
            EDepartamentos objMun = null;
            List<EDepartamentos> lista = new List<EDepartamentos>();
            string sql = "SELECT * FROM mun WHERE coddep=?depart";
            using (conexion cnx = new conexion())
            {
                cnx.cadena = ConfigSAE.Instanciar.cadenaSAE();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = cnx.getConexion();
                    cmd.Parameters.Add("?depart", MySql.Data.MySqlClient.MySqlDbType.String).Value = depar;
                    if (cnx.abrirConexion())
                    {
                        MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objMun = new EDepartamentos();
                            objMun.codigo = dr.GetString("codmun");
                            objMun.descripcion = dr.GetString("descripcion");
                            lista.Add(objMun);
                        }
                        cnx.cerrarConexion();
                    }
                }
                return lista;
            }
        }

    }
}
