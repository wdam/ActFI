using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Principal;
using Entidades;
using Aplicacion.Interfaces;


namespace Aplicacion.Inventario
{
    public partial class FrmAreaResp : Form, ISeleccionar
    {
        string ultimo = string.Format("000");
       
        BLL.AreaBLL bllArea = new BLL.AreaBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();

        ETerceros user;
        List<EArea> lista;

        public FrmAreaResp()
        {
            InitializeComponent();
        }

        #region Habilitar y Deshabilitar controles 

        protected void Habilitar() { 
            this.gbArea.Enabled = true;            
            this.lblGuardar.Enabled = true;
            this.lblCancelar.Enabled = true;
            this.lblEditar.Enabled = false;
            this.lblBuscar.Enabled = false;
            this.lblNuevo.Enabled = false;
            this.dgvArea.Enabled = false;
            this.txtNomArea.Focus();
        }

        protected void Deshabilitar() {
            this.gbArea.Enabled = false;
            this.lblGuardar.Enabled = false;
            this.lblCancelar.Enabled = false;
            this.lblEditar.Enabled = true;
            this.lblBuscar.Enabled = true;
            this.lblNuevo.Enabled = true;
            this.dgvArea.Enabled = true;
            this.txtNomArea.Focus();
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
            lbl.BackColor = Color.FromArgb(26,35,40);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(30, 150, 130);
        }
        #endregion  

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            Habilitar();
            using (Utilidades val = new Utilidades()) {
                val.limpiarPorGrupo(this);
            }            
            txtCodigo.Text = ultimo;
            lblEstado.Text = "Nuevo";
        }

        private void cargargrilla() {
            lista = bllArea.getAll();
            dgvArea.DataSource = lista;
            dgvArea.Refresh();
            ultimo = string.Format("{0:000}", Convert.ToInt32(lista.Count + 1));
        }

        private void FrmAreaResp_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            cargargrilla();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            Deshabilitar();
            using (Utilidades val = new Utilidades()){
                val.limpiarPorGrupo(this);
            } 
        }

        private void dgvArea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1){
                txtCodigo.Text = dgvArea.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNomArea.Text = dgvArea.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNit.Text = dgvArea.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "000" || txtCodigo.Text == "")
            {
                MessageBox.Show("Seleccione un Area de la tabla para modificar", "SAE Control",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                Habilitar();
                lblEstado.Text = "Editar";
            }
        }

        private bool validar()
        {
            bool bandera = true;
            BLL.ValidacionesBLL ctrVal = new BLL.ValidacionesBLL();
            
                if (!ctrVal.esCodigoAreaValida(txtCodigo.Text))
                {
                    smsError.SetError(txtCodigo, "Codigo de Area Incorrecto ");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(txtNomArea.Text))
                {
                    smsError.SetError(txtNomArea, "Ingrese el Nombre del Area");
                    bandera = false;
                }
                if (!ctrVal.noEstaVacio(txtNombreResp.Text))
                {
                   smsError.SetError(txtNit, "Seleccione el Responsable del Area");
                    bandera = false;
                }
                return bandera;     
                  
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validar())
            {
                if (lblEstado.Text == "Nuevo"){
                    guardar();
                } else if (lblEstado.Text == "Editar") {
                    modificar();
                } else {
                    MessageBox.Show("Operacion No Especificada",  "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cargargrilla();
            } else {
                MessageBox.Show("Datos Incorrectos.. Verifique",  "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardar()
        {
            EArea objArea = new EArea();
            objArea.codigo = txtCodigo.Text;
            objArea.nombre = txtNomArea.Text;
            objArea.responsable = txtNit.Text;
            string mensaje = bllArea.insertar(objArea);

            if (mensaje == "Exito")
            {
               MessageBox.Show("Datos Guardados Correctamente", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();
            }
            else
            {
                MessageBox.Show(mensaje + ".. Verifique",  "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void modificar()
        {
            EArea objArea = new EArea();
            objArea.codigo = txtCodigo.Text;
            objArea.nombre = txtNomArea.Text;
            objArea.responsable = txtNit.Text;

            string mensaje = bllArea.actualizar(objArea);

            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Actualizados Correctamente",  "SAE Control");
                Deshabilitar();
            }
            else
            {
                MessageBox.Show(mensaje + ".. Verifique", "SAE Control");
            }
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {
           user = bllTer.buscar(txtNit.Text);
           if (user == null)
           {
              txtNombreResp.Text = "";
           }
           else
           {
               txtNit.Text = user.nit;
               txtNombreResp.Text = user.nombre;
           }
        }

        private void txtNit_DoubleClick(object sender, EventArgs e)
        {
            FrmSelTercero Frm = new FrmSelTercero();
            Frm.tipo = "Empleados";
            Frm.ShowDialog(this);
        }

        public void SeleccionarDato(string dato)
        {
            txtNit.Text = dato;
        }
    }
}
