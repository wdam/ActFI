using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Interfaces;
using Entidades;

namespace Aplicacion.Procesos
{
    public partial class FrmVentas : Form , ISeleccionar
    {

        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        EActivos activo;

        public FrmVentas()
        {
            InitializeComponent();
        }
               

        #region Cambiar Colores de Fondo de los label
        private void ColocarColorFondo(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 32, 64);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(0, 111, 169);
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

        #region Habilitar, Deshabilitar, limpiar controles

        protected void habilitatar() {
            gbDatos.Enabled = true;
            gbVenta.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            lblNuevo.Enabled = false;
            lblpdf.Enabled = false;
            lblOperacion.Text = "Nuevo";
        }

        protected void Deshabilitar() {
            gbDatos.Enabled = false;
            gbVenta.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            lblNuevo.Enabled = true;
            lblpdf.Enabled = true;
            lblOperacion.Text = "Consulta";
        }

        protected void limpiar() {
            txtDescripcion.Text = "";
            txtValCompra.Text = "0";
            txtValLibros.Text = "0";
            txtValVenta.Text = "";
            txtDepreciacion.Text = "0";
            txtCodigo.Text = "";
        }
        #endregion
    
        #region Implementacion de la Interfaz ISeleccionar
        public void SeleccionarDato(string dato)
        {
            txtCodigo.Text = dato;
        }

        public void SeleccionarDato(string dato, string descripcion)
        {
            throw new NotImplementedException();
        }
        #endregion
       
        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }


        private void FrmVentas_Load(object sender, EventArgs e)
        {

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Consulta";
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                buscarActivo();
            }
            else {
                Aplicacion.Inventario.FrmSelActivos frm = new Inventario.FrmSelActivos();
                frm.ShowDialog(this);
            }
        }

        protected void buscarActivo() {
          if(!string.IsNullOrWhiteSpace(txtCodigo.Text)){            
            activo = bllAct.buscar(txtCodigo.Text);
            if (activo != null)
            {
                txtDescripcion.Text = activo.descripcion.ToString();
                txtValCompra.Text = activo.valComercial.ToString();
                txtValLibros.Text = activo.valLibros.ToString();
                txtDepreciacion.Text = activo.depAcumulada.ToString();
            }
            else {
                MessageBox.Show("El Activo no Se Encuentra registrado Verifique.. !!", "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiar();
                Aplicacion.Inventario.FrmSelActivos frm = new Inventario.FrmSelActivos();
                frm.ShowDialog();
            }
          }
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            habilitatar();
            limpiar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta") {
                buscarActivo();
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
        }

        private void txtValVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }            
            if (e.KeyChar == (Char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtValVenta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtValVenta.Text)) {                
                txtUtilidad.Text = (Convert.ToDouble(txtValVenta.Text) - Convert.ToDouble(txtValLibros.Text)).ToString();
            }
            else
            {
                txtUtilidad.Text = "";
            }
        }

        private void txtUtilidad_TextChanged(object sender, EventArgs e)
        {
            if(txtUtilidad.Text != ""){
                double valUtil = Convert.ToDouble(txtUtilidad.Text);
                if (valUtil >= 0)
                {
                    txtUtilidad.ForeColor = Color.ForestGreen;
                }
                else {
                    txtUtilidad.ForeColor = Color.Crimson;
                }
            }
        }


       
    }
}
