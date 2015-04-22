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
    public partial class FrmTerceros : Form, ISeleccionar
    {

        BLL.GenericaBLL bllGen = new BLL.GenericaBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();

        List<EDepartamentos> lstDpto; // lista de Departamentos
        List<EDepartamentos> lstMun; // Lista de Municipios
        ETerceros objTercero;

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
            lblOperacion.Text = "Nuevo";
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

        #region Procesos de Load

        private void cargarDpto() {
            lstDpto = bllGen.getDepartamentos();
            cboDepartamento.DisplayMember = "descripcion";
            cboDepartamento.ValueMember = "codigo";
            cboDepartamento.DataSource = lstDpto;
        
        }

        private void cargarMunicipio(string codigo) {
            lstMun = bllGen.getMunicipio(codigo);
            cboMunicipio.DisplayMember = "descripcion";
            cboMunicipio.ValueMember = "codigo";
            cboMunicipio.DataSource = lstMun;
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
            cargarDpto();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            Deshabilitar();
        }

        private void cboDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarMunicipio(cboDepartamento.SelectedValue.ToString());
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validar())
            {
                if (lblOperacion.Text == "Nuevo") {
                    guardar();
                }
            }
            else {
                MessageBox.Show("Datos Incorrectos .. Verifique", "SAE Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private bool validar() {
            bool correcto = true;

            if (!UtilSystem.validarCedula(txtNit.Text))
            {
                correcto = false;
                smsError.SetError(txtNit, "Nit No Valido .. Verifique longitug, el rango es entre  [7-12]");
            }

            if (string.IsNullOrWhiteSpace(txtNombres.Text)) {
                correcto = false;
                smsError.SetError(txtNombres, "Ingrese el Nombre del Tercero");
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                correcto = false;
                smsError.SetError(txtApellidos, "Ingrese los Apellidos del Tercero");
            }

            if (string.IsNullOrWhiteSpace(txtCelular.Text) && string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                correcto = false;
                smsError.SetError(txtCelular, "Por Favor Especifique un Numero Telefonico");
            }


            if (string.IsNullOrWhiteSpace(cboTipo.Text))
            {
                correcto = false;
                smsError.SetError(cboTipo, "Seleccione el Tipo de Tercero");
            }

            if (string.IsNullOrWhiteSpace(cboPersona.Text))
            {
                correcto = false;
                smsError.SetError(cboPersona, "Seleccione el Tipo de persona");
            }

            return correcto;
        }

        private void guardar() {
            ETerceros objTer = new ETerceros();

            objTer.apellidos = txtApellidos.Text;
            objTer.celular = txtCelular.Text;
            objTer.cuenta = txtCuenta.Text;
            objTer.banco = txtBanco.Text;
            objTer.departamento = cboDepartamento.SelectedValue.ToString();
            objTer.direccion = txtDireccion.Text;
            objTer.email = txtEmail.Text;
            objTer.Fax = txtFax.Text;
            objTer.municipio = cboMunicipio.SelectedValue.ToString();
            objTer.nit = txtNit.Text;
            objTer.nombre = txtNombres.Text;
            objTer.pais = cboPais.Text;
            objTer.persona = cboPersona.Text;
            objTer.telefono = txtTelefono.Text;
            objTer.tipo = cboTipo.Text;
            

            string mensaje = bllTer.insert(objTer);

            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Guardados Correctamente .. !!", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();                
                lblOperacion.Text = "Consulta";
            }
            else {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            FrmSelTercero Frm = new FrmSelTercero();
            Frm.tipo = "";
            Frm.ShowDialog(this);
        }

        public void SeleccionarDato(string dato)
        {
            txtNit.Text = dato;
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta") {
                mostrarDatos(txtNit.Text);
            }
        }

        private void mostrarDatos(string codigo) {
            objTercero = bllTer.buscar(codigo);
            if (objTercero != null) {
                txtApellidos.Text = objTercero.apellidos;
                txtBanco.Text = objTercero.banco;
                txtCelular.Text = objTercero.celular;
                txtCuenta.Text = objTercero.cuenta;
                txtDireccion.Text = objTercero.direccion;
                cboDepartamento.SelectedValue = objTercero.departamento;
                txtDV.Text = objTercero.dv;
                txtEmail.Text = objTercero.email;
                txtFax.Text = objTercero.Fax;
                txtNit.Text = objTercero.nit;
                cboMunicipio.SelectedValue = objTercero.municipio;
                txtNombres.Text = objTercero.nombre;
                txtTelefono.Text = objTercero.telefono;
                cboPais.Text = objTercero.pais;
                cboPersona.Text = objTercero.persona;
                cboTipo.Text = objTercero.tipo;            
            }
        }
    }
}
