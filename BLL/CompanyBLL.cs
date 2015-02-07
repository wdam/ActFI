using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.DAO;
using System.IO;

namespace BLL
{
    public class CompanyBLL
    {
        public ECompany buscar() {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.buscar(Inicializar.company);
        }

        public ECompany buscar(string login, string clave) {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.buscar(login, clave);
        }

        public List<ECompany> getAll() { 
            CompanyDAO  cDao = new CompanyDAO();
            return cDao.getAll();
        }

        public EPeriodo getPeriodo(int codigo) {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.getPeriodo(codigo);
        }

        public string buscarPeriodo() {
            string mensaje = "";
            PrincipalBLL bllPrin = new PrincipalBLL();
            ECompany company = buscar();
            if (company == null) // Verificando la Compañia
            {
                mensaje = "El período no se pudo abrir porque la compañia no existe, verifique";
                bllPrin.iniciarPeriodo("(ninguno)");
            }
            else 
            {
                string per = llenarPeriodo();
                if (per == "Error")
                {
                    EPeriodo ObjPer = getPeriodo(company.codigo);
                    if (ObjPer == null)
                    {
                        bllPrin.iniciarPeriodo("(ninguno)");
                        mensaje = "No hay periodos usados, Verifique.";
                    }
                    else
                    {
                        bllPrin.iniciarPeriodo(ObjPer.periodo);
                    }

                    // Crear Archivo con el periodo actual 
                    string ruta =  AppDomain.CurrentDomain.BaseDirectory + "\\" + Inicializar.company + ".txt";
                    StreamWriter swEscritor = new StreamWriter(ruta, false);
                    swEscritor.Write(Inicializar.periodo.Trim());
                    swEscritor.Close();
                }
                else
                {
                    bllPrin.iniciarPeriodo(per); 
                }
                string BDato = "sae" + Inicializar.company.ToLower() + Inicializar.periodo.Substring(3,4);
                bllPrin.inicializarBD(BDato);                
            }
            return mensaje;
        }

        private string llenarPeriodo() {           
            string ruta =  AppDomain.CurrentDomain.BaseDirectory + "\\" + Inicializar.company + ".txt";
            if (System.IO.File.Exists(ruta))
            {
                return System.IO.File.ReadAllText(ruta);                
            }
            else {
                return "Error";
            }                                                
        }
    }
}
