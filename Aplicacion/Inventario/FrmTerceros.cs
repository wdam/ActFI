using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Inventario
{
    public partial class FrmTerceros : Form
    {
        public FrmTerceros()
        {
            InitializeComponent();
        }

        #region Cambiar Colores de Fondo de los label
        private void ColocarColorFondo(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(26, 35, 40);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 32, 64);
        }
        #endregion  

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
