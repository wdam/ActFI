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
    public partial class FrmTransaccion : Form, ISeleccionar
    {
        private BLL.ActivosBLL bllActivo = new BLL.ActivosBLL();
        private EActivos objActivo;
        
        public FrmTransaccion()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region 

        private void Habilitar() {
            gbDatos.Enabled = true;
            gbOperacion.Enabled = true;
            gbSeleccion.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            lblNuevo.Enabled = false;
        }

        private void Deshabilitar() {
            gbDatos.Enabled = false;
            gbOperacion.Enabled = false;
            gbSeleccion.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            lblNuevo.Enabled = true;
            lblOperacion.Text = "Consulta";
        }

        #endregion

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            Habilitar();
            lblOperacion.Text = "Nuevo";
        }

        private void cboOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboOperacion.SelectedIndex)
            {
                case 0: // Case Manteniento
                    gbOperacion.Text = "Ingrese Datos del Mantenimiento";
                    break;
                case 1: // Case Desactivar
                    gbOperacion.Text = "Dar de Baja Al Activo";
                    break;
                default:
                    break;
            }
            
        }

        void ISeleccionar.SeleccionarDato(string dato)
        {
            txtCodigo.Text = dato;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 3){
                MostrarDatos();
            }
            else {
                txtNombre.Text = "";
            }           
        }

        private void txtCodigo_DoubleClick(object sender, EventArgs e)
        {
            var frmSA = new Inventario.FrmSelActivos();
            frmSA.ShowDialog(this);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                MostrarDatos();
            }
        }

        private void MostrarDatos() {
            var codigo = txtCodigo.Text;
            objActivo = bllActivo.buscar(codigo);
            if (objActivo != null){
                txtNombre.Text = objActivo.nombre;
            }
            else {
                txtNombre.Text = "";
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (Validar()){

            }
            else {
                MessageBox.Show("Datos Incorrectos .. Verifique", "SAE Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Validar() {
            bool correcto = true;            
            if (txtNombre.Text.Length == 0) {
                smsError.SetError(txtCodigo, "Ingrese un Codigo Valido ");
                correcto = false;
            }

            if (cboOperacion.SelectedIndex < 0) {
                smsError.SetError(cboOperacion, "Seleccione Operación ");
                correcto = false;
            }
            return correcto;
        }
    }
}
