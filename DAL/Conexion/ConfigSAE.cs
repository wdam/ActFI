using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Conexion
{
    public class ConfigSAE
    {
        private static ConfigSAE instancia = null;
        private static string cnxSAE;

        private ConfigSAE() 
        {
            cnxSAE = datosConexion("sae");            
        }

         public static ConfigSAE Instanciar
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConfigSAE();
                }
                return instancia;
            }
        }

         private string datosConexion(string bd)
        {
           var appSetting = ConfigurationManager.AppSettings;
            if (appSetting.Count == 0)
            {
                return "No hay Datos de Conexion";
            }
            string server = "server=" + ConfigurationManager.AppSettings["server"] + ";";
            string user = "user=" + ConfigurationManager.AppSettings["user"] + ";";
            string password = "password=" + ConfigurationManager.AppSettings["password"] + ";";
            string puerto = "port=" + ConfigurationManager.AppSettings["port"] + ";";
            string BD = "database=" + bd + ";";

            return server + user + password + BD + puerto;
           
        }

         public string cadenaSAE() {
             return cnxSAE; 
        }       
    }
}
