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
        public static double DIN(string monto) {
            return Math.Round(Convert.ToDouble(monto),2);                              
        }

        public static string truncarCadena(string dato, int maxLength)
        {
            return dato.Length <= maxLength ? dato : dato.Substring(0, maxLength);
        }
        // Formato de Moneda
        public static string fMoneda(double valor) {
            return string.Format("{0:#,0.00}", valor);
        }

        public static string fConsecutivo(int numero)
        {
            return string.Format("{0:000000}", numero);            
        }


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

        public static List<Entidades.EtipoDepreciacion> metodosDepreciacion() {
            List<Entidades.EtipoDepreciacion> lstTipos = new List<Entidades.EtipoDepreciacion>();
            lstTipos.Add(new Entidades.EtipoDepreciacion { sigla = "NDP", Descripcion = "NDP > NO DEPRECIACBLE" });
            lstTipos.Add(new Entidades.EtipoDepreciacion { sigla = "DLR", Descripcion = "DLR > DEPRECIACION LINEA RECTA" });
            return lstTipos;
        }       
    }
}
