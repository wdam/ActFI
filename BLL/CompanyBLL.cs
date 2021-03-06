﻿using System;
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
        /// <summary>
        /// Devuelve los datos de la Compañia Actualmente Seleccionada
        /// </summary>
        /// <returns></returns>
        public ECompany buscar() {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.buscar(Inicializar.company);
        }

        /// <summary>
        /// Retorna los Datos de una Compañia
        /// </summary>
        /// <param name="login">Login de la Compañia</param>
        /// <param name="clave">Clave Compañia</param>
        /// <returns></returns>
        public ECompany buscar(string login, string clave) {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.buscar(login, clave);
        }

        /// <summary>
        /// Retorna una lista de todas las Compañias
        /// </summary>
        /// <returns></returns>
        public List<ECompany> getAll() { 
            CompanyDAO  cDao = new CompanyDAO();
            return cDao.getAll();
        }

        /// <summary>
        /// Obtiene el Periodo de Actual de la Compañia
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
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
                    try
                    {
                        string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\" + Inicializar.company + ".txt";                        
                        StreamWriter swEscritor = new StreamWriter(ruta, false);
                        swEscritor.Write(Inicializar.periodo.Trim());
                        swEscritor.Close();                       
                    }
                    catch (Exception ex)
                    {
                        return ex.Message.ToString();
                    }                   
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

        /// <summary>
        /// Obtiene el Periodo actual del Archivo .txt de la Compañia Seleccionada
        /// </summary>
        /// <returns></returns>
        private string llenarPeriodo() {           
            string ruta =  AppDomain.CurrentDomain.BaseDirectory + "\\" + Inicializar.company + ".txt";            
            if (System.IO.File.Exists(ruta)) {
                return System.IO.File.ReadAllText(ruta);                
            }
            else {
                return "Error";
            }                                                
        }

        /// <summary>
        /// Devuelve una Lista Con los Periodos Bloqueados de una Compañia
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public List<EPeriodo> getPerBloqueado(string dato) {
            CompanyDAO cDao = new CompanyDAO();
            return cDao.getPerBloqueado(dato);
        }

        public string abrirPeriodo(string periodo) {
              CompanyDAO cDao = new CompanyDAO();
            if (Inicializar.codCompany.HasValue) {
                EPeriodo objPer = cDao.getPeriodo(Inicializar.codCompany);
                int nReg = 0;
                if (objPer == null)
                {
                    nReg = cDao.guardarPeriodo(periodo, "Nuevo", Inicializar.codCompany);
                }
                else {
                    nReg = cDao.guardarPeriodo(periodo, "Actualizar", Inicializar.codCompany);
                }

                if (nReg > 0)
                {
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\" + Inicializar.company + ".txt";
                    StreamWriter swEscritor = new StreamWriter(ruta, false);
                    swEscritor.Write(periodo.Trim());
                    swEscritor.Close();
                    return "Correcto";
                }
                else {
                    return "Error al Abrir Periodo.. ";
                }
            }
            else
            {
                return "El período no se pudo abrir porque la compañia no existe, verifique... ";
            }            
            
        }
    }
}
