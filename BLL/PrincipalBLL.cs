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

        public void iniciarUsuario(string user) {
            Inicializar.user = user;                
        }

        public void iniciarCompany(string company) {
            Inicializar.company = company;            
        }

        public void iniciarPeriodo(string periodo) {
            Inicializar.periodo = periodo;
            Inicializar.Mes = periodo.Substring(0, 2);
        }

               
    }
}
