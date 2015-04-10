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

        #region Habilitar y Deshabilitar controles

        protected void Habilitar()
        {
            this.gbDatos.Enabled = true;
            this.lblGuardar.Enabled = true;
            this.lblCancelar.Enabled = true;
            this.lblEditar.Enabled = false;
            this.lblBuscar.Enabled = false;
            this.lblNuevo.Enabled = false;            
            this.txtNit.Focus();
        }

        protected void Deshabilitar()
        {
            this.gbDatos.Enabled = false;
            this.lblGuardar.Enabled = false;
            this.lblCancelar.Enabled = false;
            this.lblEditar.Enabled = true;
            this.lblBuscar.Enabled = true;
            this.lblNuevo.Enabled = true;
                        
        }

        protected void limpiar() {
            this.txtApellidos.Text = "";
            this.txtBanco.Text = "";
            this.txtCelular.Text = "";
            this.txtCuenta.Text = "";
            this.txtDireccion.Text = "";
            this.txtDV.Text = "";
            this.txtEmail.Text = "";
            this.txtFax.Text = "";
            this.txtNit.Text = "";
            this.txtTelefono.Text = "";
            this.txtNombres.Text = "";

        }
        #endregion

        #region Proceso para mover formulario

        private bool mover;
        private int pX;
        private int pY;

        private void lblTituloPrinc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mover = true;
                pX = e.X;
                pY = e.Y;
                this.Cursor = Cursors.NoMove2D;
            }
        }

        private void lblTituloPrinc_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = new Point((this.Left + e.X - pX), (this.Top + e.Y - pY));
            }
        }

        private void lblTituloPrinc_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

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

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void FrmTerceros_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            limpiar();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
        }
    }
}
