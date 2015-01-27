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


namespace Aplicacion.Inventario
{
    public partial class FrmTraslados : Form, ISeleccionar
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();
        BLL.AreaBLL bllArea = new BLL.AreaBLL();
        EActivos activo;
        ETerceros user;
        EArea area;
        List<EArea> lstArea;
        TextBox texto;
        public FrmTraslados()
        {
            InitializeComponent();
        }
        #region Habilitar , Deshabilitar   y Limpiar
        protected void habilitar() {
            gbDatos.Enabled = true;
            gbTraslado.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            
            lblNuevo.Enabled = false;
            lblOperacion.Text = "Nuevo";
        }

        protected void deshabilitar() {
            gbDatos.Enabled = false;
            gbTraslado.Enabled = false;
            
            lblNuevo.Enabled = true;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
        }

        protected void limpiar() {
            txtDescripcion.Text = "";
            txtArea.Text = "";
            txtResponsable.Text = "";
            txtNitResp.Text = "";
            txtNuevoRespon.Text = "";
            txtCodigo.Text = "";
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter){
                mostrarDatos();
            }
        }

        private void mostrarDatos(){
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text)) {
                activo = bllAct.buscar(txtCodigo.Text);
                if (activo != null)
                {
                    txtCodigo.Text = activo.codigo;
                    txtDescripcion.Text = activo.descripcion;
                    area = bllArea.buscar(activo.area);
                    if (area != null)
                    {
                        txtArea.Text = area.nombre;
                    }
                    user = bllTer.buscar(activo.responsable);
                    if (user != null)
                    {
                        txtResponsable.Text = user.nombre;
                    }                                        
                }
                else {
                    MessageBox.Show("El Activo no se encuentra Registrado", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 5) {
                mostrarDatos();
            }
        }

      
        private void lblNuevo_Click(object sender, EventArgs e)
        {
            habilitar();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            deshabilitar();
        }

        private void FrmTraslados_Load(object sender, EventArgs e)
        {
            lstArea = bllArea.getAll();
            cboArea.DataSource = lstArea;
            cboArea.DisplayMember = "nombre";
            cboArea.ValueMember = "codigo";
        }

      
        private void txtNitResp_TextChanged(object sender, EventArgs e)
        {
            user = bllTer.buscar(txtNitResp.Text);
            if (user != null)
            {
                txtNitResp.Text = user.nit;
                txtNuevoRespon.Text = user.nombre;
            }
            else {
                txtNuevoRespon.Text = "";
            }
        }
      
        public void SeleccionarDato(string dato)
        {
            texto.Text = dato; 
        }

        private void txtCodigo_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelActivos frm = new FrmSelActivos();
            frm.ShowDialog(this);
        }

        private void txtNitResp_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelTercero frm = new FrmSelTercero();
            frm.ShowDialog(this);
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            if(Validar()){
                if (lblOperacion.Text == "Nuevo") { 
                    
                }                
            }
        }

        private void guardar() { 
            
        }

        private bool Validar() {
            bool bandera = true;
            using (BLL.ValidacionesBLL ctrVal = new BLL.ValidacionesBLL()) { 

              if (!ctrVal.noEstaVacio(txtCodigo.Text)){
                  smsError.SetError(txtCodigo, "Codigo Incorrecto");
                  bandera = false;
              }

              if (!ctrVal.noEstaVacio(txtNuevoRespon.Text)) {
                  smsError.SetError(txtNitResp, "No ha Seleccinado El Responsable");
                  bandera = false;
              }
              return bandera;
            }
        }
       
    }
}