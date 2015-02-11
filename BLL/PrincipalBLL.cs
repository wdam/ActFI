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
        public void inicializarBD(string bd)
        {           
            Inicializacion.BDatos = bd;                       
        }

        public string Encriptar(string clave, string plainttext) {
            EncriptarBLL encriptar = new EncriptarBLL(clave);
            return encriptar.EncryptData(plainttext);
        }

        public string Encriptar2(string clave, string plainttext)
        {
            EncriptarBLL encriptar = new EncriptarBLL(plainttext);
            return encriptar.EncryptData(clave);
        }

        public void iniciarUsuario(string user, string rol) {
            Inicializar.user = user;
            Inicializar.rolUser = rol;
        }

        public void iniciarCompany(string company, int? codigo) {
            Inicializar.company = company;
            Inicializar.codCompany = codigo;
        }

        public void iniciarPeriodo(string periodo) {
            Inicializar.periodo = periodo;
            Inicializar.Mes = periodo.Substring(0, 2);
        }               
    }
}
