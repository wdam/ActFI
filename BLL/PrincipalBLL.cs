using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
namespace BLL
{
    public class PrincipalBLL
    {

        /// <summary>
        /// Inicializar Base de Datos 
        /// </summary>
        /// <param name="bd">Nombre Base de Datos</param>
        public void inicializarBD(string bd)
        {           
            Inicializacion.BDatos = bd;                       
        }

        /// <summary>
        /// Encriptar Contraseñas
        /// </summary>
        /// <param name="clave">Contraseña o Clave a Encriptar</param>
        /// <param name="plainttext">Llave o Key de Encriptacion</param>
        /// <returns></returns>
        public string Encriptar(string clave, string plainttext) {
            EncriptarBLL encriptar = new EncriptarBLL(clave);
            return encriptar.EncryptData(plainttext);
        }

        public string Encriptar2(string clave, string plainttext)
        {
            EncriptarBLL encriptar = new EncriptarBLL(plainttext);
            return encriptar.EncryptData(clave);
        }


        /// <summary>
        /// Desencriptar datos Enviados desde la aplicacion SAE
        /// </summary>
        /// <param name="clave">Clave Encriptada</param>
        /// <param name="plaintext">Llave de Desencriptacion</param>
        /// <returns></returns>
        public string desencriptar(string clave, string plaintext) {
            EncriptarBLL encriptar = new EncriptarBLL(plaintext);
            return encriptar.DecryptData(clave);
        }

        /// <summary>
        /// Inicializar Variables Globales de Usuario
        /// </summary>
        /// <param name="user">Nombre de Usuario</param>
        /// <param name="rol">Rol del Usuario</param>
        public void iniciarUsuario(string user, string rol) {
            Inicializar.user = user;
            Inicializar.rolUser = rol;
        }

        /// <summary>
        /// Inicializar Variables Globales de Compañia
        /// </summary>
        /// <param name="company">Nombre de la Compañia</param>
        /// <param name="codigo">Codigo  Compañia</param>
        public void iniciarCompany(string company, int? codigo) {
            Inicializar.company = company;
            Inicializar.codCompany = codigo;
        }

        /// <summary>
        /// Inicializar Periodo Global
        /// </summary>
        /// <param name="periodo">Periodo Actual</param>
        public void iniciarPeriodo(string periodo) {
            Inicializar.periodo = periodo;
            Inicializar.Mes = periodo.Substring(0, 2);
        }               
    }
}
