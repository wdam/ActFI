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
            if (!bllVal.noEstaVacio(txtctaActivo.Text))
            {
                msjError.SetError(txtctaActivo, "Ingrese la Cuenta de Activo");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaDepreciacion.Text))
            {
                msjError.SetError(txtctaDepreciacion, "Ingrese la Cuenta de Depreciacion");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaDepMonetaria.Text))
            {
                msjError.SetError(txtctaDepMonetaria, "Digite Cuenta de Correcion Monetaria de la Depreciacion");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaGastos.Text))
            {
                msjError.SetError(txtctaGastos, "Ingrese la Cuenta de Gastos");
                valido = false;
            }

            if (!bllVal.noEstaVacio(txtctaMonetaria.Text))
            {
                msjError.SetError(txtctaMonetaria, "Ingrese la Cuenta de Correccion Monetaria");
                valido = false;
            }
            return valido;
        }


        private void guardar() {
            EParametros obj = new EParametros();
            obj.Codigo = "1";
            obj.ctaActivo = txtctaActivo.Text;
            obj.ctaDepreciacion = txtctaDepreciacion.Text;
            obj.ctaGastos = txtctaGastos.Text;
            obj.ctaMonetaria = txtctaMonetaria.Text;
            obj.ctaDepMonetaria = txtctaDepMonetaria.Text;

            string mensaje = bllPar.Actualizar(obj);

            if (mensaje == "Exito")
            {
                MessageBox.Show("Parametros Guardados Correctamente", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cargarParametros() { 
            List<EParametros> lstPar;
            lstPar = bllPar.getParametros();

            if (lstPar.Count > 0 ){
               foreach (EParametros item in lstPar)
	             {
                txtctaActivo.Text = item.ctaActivo;
                txtctaDepreciacion.Text = item.ctaDepreciacion;
                txtctaGastos.Text = item.ctaGastos;
                txtctaMonetaria.Text = item.ctaMonetaria;
                txtctaDepMonetaria.Text = item.ctaDepMonetaria;
                }
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

        public void SeleccionarDato(string dato)
        {
            setTexto.Text = dato;
        }
    }
}
