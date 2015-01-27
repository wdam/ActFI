using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Configuration;


namespace DAL.Conexion
{

    public class Configuracion
    {
        private static Configuracion instancia = null;
       
        private static string cnxBDatos {get; set;}
        public string BDatos { set; get; }

        private Configuracion()
        {
            cnxBDatos = datosConexion(Inicializacion.BDatos);            
        }

        public static Configuracion Instanciar
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Configuracion();
                }
                return instancia;
            }
        }
        

        public string conexionBD()
        {            
            return cnxBDatos;
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
            
        }


    }

