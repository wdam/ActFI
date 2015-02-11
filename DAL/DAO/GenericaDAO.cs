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
    public  class GenericaDAO
    {
        public EGenerica verificarCCosto() {
            EGenerica objG = null;
            string sql = " SELECT ccosto FROM parcontab ";

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
                        if (dr.HasRows == true)
                        {
                            dr.Read();
                            objG = new EGenerica();
                            objG.ccosto = dr.GetString("ccosto");
                        }
                        cnx.cerrarConexion();
                    }
                }               
            }
            return objG;

        }
    }
}
