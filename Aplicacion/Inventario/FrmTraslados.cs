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
        BLL.TrasladosBLL bllTras = new BLL.TrasladosBLL();

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
            gbObser.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            lblNuevo.Enabled = false;
            lblOperacion.Text = "Nuevo";
        }

        protected void deshabilitar() {
            gbDatos.Enabled = false;
            gbTraslado.Enabled = false;
            gbObser.Enabled = false;
            
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
            txtObservacion.Text = "";
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
            lbl.BackColor = Color.FromArgb(24, 34, 45);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 49, 64);
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
                    lblResponsable.Text = activo.responsable;
                    lblArea.Text = activo.area;

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
            smsError.Dispose();
            habilitar();
            limpiar();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
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

        #region Implementacion de la interfaz
        public void SeleccionarDato(string dato)
        {
            texto.Text = dato;
        }

        public void SeleccionarDato(string dato, string descripcion)
        {
            throw new NotImplementedException();
        }
        #endregion
        

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
            smsError.Dispose();
            if(Validar()){
                if (lblOperacion.Text == "Nuevo") {
                    guardar();
                }                
            }
        }

        private void guardar() {
            ETraslados objTras = new ETraslados();
            objTras.activo = txtCodigo.Text;
            objTras.areaAnt = lblArea.Text;
            objTras.respAnt = lblResponsable.Text;
            objTras.nuevaArea = cboArea.SelectedValue.ToString();
            objTras.nuevoResp = txtNitResp.Text;
            objTras.fecha = dtFecha.Value;
            objTras.observacion = txtObservacion.Text;

            string mensaje = bllTras.insertar(objTras);

            if (mensaje == "Exito")
            {
                bllAct.trasladar(objTras.activo, objTras.nuevaArea, objTras.nuevoResp);
                MessageBox.Show("El traslado se ha realizado Correctamemte.. ", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deshabilitar();
                limpiar();
            }
            else {
                MessageBox.Show(mensaje, "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                        
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