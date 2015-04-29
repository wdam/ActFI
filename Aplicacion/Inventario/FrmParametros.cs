using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.Inventario
{
    public partial class FrmParametros : Form, ISeleccionar
    {
        BLL.ValidacionesBLL bllVal = new BLL.ValidacionesBLL();
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        TextBox setTexto;
        public FrmParametros()
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
            lbl.BackColor = Color.FromArgb(0, 140, 140);
        }
        #endregion  

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            msjError.Dispose();
            if (validar())
            {
                guardar();
            }
            else {
                MessageBox.Show("Verifique la Informacion", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool validar() {
            bool valido = true;
            if (!bllVal.noEstaVacio(txtctaCaja.Text))
            {
                msjError.SetError(txtctaCaja, "Ingrese la Cuenta de Activo");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaIva.Text))
            {
                msjError.SetError(txtctaIva, "Ingrese la Cuenta de Depreciacion");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaDepMonetaria.Text))
            {
                msjError.SetError(txtctaDepMonetaria, "Digite Cuenta de Correcion Monetaria de la Depreciacion");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaBanco.Text))
            {
                msjError.SetError(txtctaBanco, "Ingrese la Cuenta de Gastos");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaProveedor.Text))
            {
                msjError.SetError(txtctaProveedor, "Ingrese la Cuenta de Correccion Monetaria");
                valido = false;
            }


            if (!bllVal.noEstaVacio(txtVentas.Text))
            {
                msjError.SetError(txtVentas, "Seleccione Documento  para Ventas");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtCompra.Text))
            {
                msjError.SetError(txtCompra, "Seccione Documento para Compras");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtDepreciacion.Text))
            {
                msjError.SetError(txtDepreciacion, "Seleccione Documento para la Depreciacion");
                valido = false;
            }
            return valido;
        }


        private void guardar() {
            EParametros obj = new EParametros();
            obj.Codigo = "1";
            obj.ctaCaja = txtctaCaja.Text;
            obj.ctaIVA = txtctaIva.Text;
            obj.ctaBanco = txtctaBanco.Text;
            obj.ctaProveedor = txtctaProveedor.Text;
            obj.ctaDepMonetaria = txtctaDepMonetaria.Text;
            obj.compras = txtCompra.Text;
            obj.ventas = txtVentas.Text;
            obj.depreciacion = txtDepreciacion.Text;

            string mensaje = bllPar.Actualizar(obj);

            if (mensaje == "Exito")
            {
                MessageBox.Show("Parametros Guardados Correctamente", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cargarParametros() { 
            EParametros lstPar;
            lstPar = bllPar.getParametros();

            if (lstPar !=null ){
                txtctaCaja.Text = lstPar.ctaCaja;
                txtctaIva.Text = lstPar.ctaIVA;
                txtctaBanco.Text = lstPar.ctaBanco;
                txtctaProveedor.Text = lstPar.ctaProveedor;
                txtctaDepMonetaria.Text = lstPar.ctaDepMonetaria;
                txtCompra.Text = lstPar.compras;
                txtVentas.Text = lstPar.ventas;
                txtDepreciacion.Text = lstPar.depreciacion;                
            }        
        }

        private void FrmParametros_Load(object sender, EventArgs e)
        {
            cargarParametros();
        }

        private void seleccionar(object sender, EventArgs e)
        {
            setTexto = (TextBox)sender;
            FrmSelCuentas frm = new FrmSelCuentas();
            frm.ShowDialog(this);
        }

        private void seleccionarDoc(object sender, EventArgs e)
        {
            setTexto = (TextBox)sender;
            FrmSelTipoDocumento frm = new FrmSelTipoDocumento();
            frm.ShowDialog(this);
        }

        public void SeleccionarDato(string dato)
        {
            setTexto.Text = dato;
        }
     
        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            e.Handled = true;
        }
    }
}
