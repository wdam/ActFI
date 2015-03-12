using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Principal
{
    public class Utilidades:IDisposable
    {
        
        #region Funciones para limpiar controles de Formularios
        public void limpiarControles(Form formulario)
        {
            foreach (Control frm in formulario.Controls)
            {
                if (frm is Panel)
                {
                    foreach (Control grupo in frm.Controls)
                    {
                        if (grupo is GroupBox)
                        {
                            foreach (Control control in grupo.Controls)
                            {
                                if (control is TextBox)
                                {
                                    control.Text = "";
                                }
                                else if (control is ComboBox)
                                {
                                    control.Text = "";
                                }                               
                            }
                        }
                    }
                }
            }
        }

        public  void limpiarPorGrupo(Form formulario){
            foreach (Control grupo in formulario.Controls) {
	            if (grupo is GroupBox) {
		            foreach (Control control in grupo.Controls) {
			            if (control is TextBox) {
				            control.Text = "";
			            } else if (control is ComboBox) {
				            control.Text = "";
                        }
                    }
                }
            }
        }

        

       
        #endregion  

       

        #region Implementacion de IDisposable
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    
                }
            }
            this.disposed = true;
        }
        #endregion  
        
    
    }
}
