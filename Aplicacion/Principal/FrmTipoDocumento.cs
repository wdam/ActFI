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

namespace Aplicacion.Principal
{
    public partial class FrmTipoDocumento : Form, ISeleccionar
    {
        BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();
        ETipoDocumento objTipoDoc;


        public FrmTipoDocumento()
        {
            InitializeComponent();
        }

        #region Cambiar Colores de Fondo de los label
        private void ColocarColorFondo(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(24, 34, 45);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(7, 94, 117);
        }
        #endregion  

        #region Proceso para mover formulario

        private bool mover;
        private int pX;
        private int pY;

        private void lblTituloPrinc_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void lblTituloPrinc_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void lblTituloPrinc_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Habilitar y Deshabilitar Controles

        private void habilitar() {
            gbTipos.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;

            lblNuevo.Enabled = false;
            lblEditar.Enabled = false;
            lblBuscar.Enabled = false;
            txtTipo.Enabled = true;
            smsError.Dispose();
        }

        private void deshabilitar() {
            gbTipos.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            lblNuevo.Enabled = true;
            lblEditar.Enabled = true;
            lblBuscar.Enabled = true;
            lblOperacion.Text = "Consulta";            
        }

        private void limpiar() {
            txtDescripcion.Text = "";
            txtTipo.Text = "";
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            if (BLL.Inicializar.rolUser != "admin") {
                gbTipos.Visible = false;
                lblMensaje.Visible = true;
                return;
            }
            List<EtiposGenericos> lstTipos = UtilSystem.gruposDocumentos();
            cboGrupo.DisplayMember = "Descripcion";
            cboGrupo.ValueMember = "sigla";
            cboGrupo.DataSource = lstTipos;
            lblPerActual.Text = BLL.Inicializar.periodo;            
            deshabilitar();            
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = cboGrupo.Text.Substring(5);
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {            
            habilitar();
            limpiar();
            lblOperacion.Text = "Nuevo";
            cboGrupo_SelectedIndexChanged(null, null);
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            deshabilitar();
            smsError.Dispose();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Editar";
            habilitar();
            txtTipo.Enabled = false;  
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validar())
            {
                if (lblOperacion.Text == "Nuevo") {
                    guardar();
                }
                else if (lblOperacion.Text == "Editar")
                {
                    modificar();
                }
            }
            else {
                MessageBox.Show("Datos Incorrectos , Verifique", "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool validar() {
            bool correcto = true;
            if (cboGrupo.Text=="") {
                smsError.SetError(cboGrupo, "Seleccione Un Grupo ");
                correcto = false;
            }

            if (txtTipo.Text.Trim().Length != 2 ) {
                smsError.SetError(txtTipo, "Ingrese la Sigla, Debe tener dos Caracteres ");
                correcto = false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text)) {
                smsError.SetError(txtDescripcion, "Ingrese la Descripcion");
                correcto = false;
            }
            return correcto;
        }

        private void guardar() {
            ETipoDocumento obj = new ETipoDocumento();
            obj.actual = Convert.ToInt16(txtActual.Text);
            obj.descripcion = txtDescripcion.Text;
            obj.grupo = cboGrupo.SelectedValue.ToString();            
            obj.tipoDoc = txtTipo.Text;

            string mensaje = bllTipo.insertar(obj);
            if (mensaje == "Exito") {
                MessageBox.Show("Datos Guardados Correctamente ", "Control de informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deshabilitar();
            }
            else
            {
                MessageBox.Show(mensaje, "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void modificar() {
            ETipoDocumento obj = new ETipoDocumento();
            obj.actual = Convert.ToInt16(txtActual.Text);
            obj.descripcion = txtDescripcion.Text;
            obj.grupo = cboGrupo.SelectedValue.ToString();
            obj.tipoDoc = txtTipo.Text;

            string mensaje = bllTipo.actualizar(obj);
            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Guardados Correctamente ", "Control de informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deshabilitar();
            }
            else
            {
                MessageBox.Show(mensaje, "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        private void txtActual_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtActual.Text)) {
                txtActual.Text = "0";
            }
        }       

        private void cboGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilSystem.ValidarNumero(sender, e);
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            Inventario.FrmSelTipoDocumento frmD = new Inventario.FrmSelTipoDocumento();
            frmD.ShowDialog(this);
        }

        public void SeleccionarDato(string dato)
        {
            txtTipo.Text = dato;
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta") {
                mostrarDatos();
            }
        }

        private void mostrarDatos() {
            objTipoDoc = bllTipo.buscarTipo(txtTipo.Text);
            if (objTipoDoc != null) {
                txtDescripcion.Text = objTipoDoc.descripcion;
                txtActual.Text = (objTipoDoc.actual - 1).ToString();
                cboGrupo.SelectedValue = objTipoDoc.grupo;
            }
        }


    }
}
