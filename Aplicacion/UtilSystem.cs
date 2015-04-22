using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public static class UtilSystem 
    {
        /// <summary>
        /// Ruta donde se guardan las Imagenes de los Activos
        /// </summary>
        public static string rutaImagen = AppDomain.CurrentDomain.BaseDirectory + "assetsimages\\";
        
        /// <summary>
        /// Metodo Utilizado para Guardar Valores de tipo Double ($) en Mysql
        /// </summary>
        /// <param name="monto">Valor a Convertir a Double</param>
        /// <returns></returns>
        public static double DIN(string monto) {
            return Math.Round(Convert.ToDouble(monto),2);                              
        }

        /// <summary>
        /// Devuelve una cadena con el tamaño maximo Espeficicado 
        /// </summary>
        /// <param name="dato">Cadena de Caracteres</param>
        /// <param name="maxLength">Tamaño Maximo que debe tener la Cadena</param>
        /// <returns></returns>
        public static string truncarCadena(string dato, int maxLength)
        {
            return dato.Length <= maxLength ? dato : dato.Substring(0, maxLength);
        }
       
        /// <summary>
        /// Devuelve Un valor con formato de Separacion de Decimales 
        /// </summary>
        /// <param name="valor">Valor a Convertir</param>
        /// <returns></returns>
        public static string fMoneda(double valor) {
            return string.Format("{0:#,0.00}", valor);
        }

        /// <summary>
        /// Devuelve el formato del Consecutivo para documentos de Contabilidad
        /// </summary>
        /// <param name="numero">Consecutivo </param>
        /// <returns></returns>
        public static string fConsecutivo(int numero)
        {
            return string.Format("{0:000000}", numero);            
        }

        /// <summary>
     /// Devuelve el Formato del Consecutivo de Nuevos Activos Fijos
     /// </summary>
     /// <param name="numero">Numero Consecutivo</param>
     /// <returns></returns>
        public static string fConsActivo(int numero) {
            return string.Format("{0:00000}", numero);
        }

        /// <summary>
        /// Convertir Fecha para guardar en MySQL
        /// </summary>
        /// <param name="fecha">Fecha a Convertir</param>
        /// <returns></returns>
        public static string fFecha(DateTime fecha) {
            return string.Format("{0:yyyy-MM-dd}", fecha);
        }

        /// <summary>
        /// Validar la entrada de datos  de tipo Numerico  y De Control
        /// </summary>
        /// <param name="sender">Objeto a Validar</param>
        /// <param name="e">Evento</param>
        public static void ValidarNumero(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (Char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Validar Cedula o Nit del Tercero 
        /// </summary>
        /// <param name="cedula">Cedula del Tercero</param>
        /// <returns></returns>
        public static bool validarCedula(string cedula)
        {
            return cedula.Trim().Length >= 7 && cedula.Trim().Length <= 12;
        }

        /// <summary>
        /// Validar la entrada de datos  de tipo Numerico, caracter  Decimal y teclas de Control
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        public static void ValNumeroDecimal(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox txtControl = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || (char.IsControl(e.KeyChar)) || e.KeyChar == ',' && txtControl.Text.Contains(",") == false) {
                e.Handled = false;                
            } else {
                e.Handled = true;
            }
            if (e.KeyChar == (Char)Keys.Enter) {
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Estable y Recupera los metodos de Depreciacion a Utilizar
        /// </summary>
        /// <returns></returns>
        public static List<Entidades.EtipoDepreciacion> metodosDepreciacion() {
            List<Entidades.EtipoDepreciacion> lstTipos = new List<Entidades.EtipoDepreciacion>();
            lstTipos.Add(new Entidades.EtipoDepreciacion { sigla = "NDP", Descripcion = "NDP > NO DEPRECIACBLE" });
            lstTipos.Add(new Entidades.EtipoDepreciacion { sigla = "DLR", Descripcion = "DLR > DEPRECIACION LINEA RECTA" });
            return lstTipos;
        }       
    }
}
