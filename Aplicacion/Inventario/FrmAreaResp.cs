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


namespace Aplicacion.Inventario
{
    public partial class FrmAreaResp : Form
    {
        string ultimo = string.Format("000");
        List<EArea> lista;
        BLL.AreaBLL bllArea = new BLL.AreaBLL();
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
                txtDescripcion.Text = dgvArea.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                if (!ctrVal.noEstaVacio(txtDescripcion.Text))
                {
                    smsError.SetError(txtDescripcion, "Ingresa la Descripcion");
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
            objArea.descripcion = txtDescripcion.Text;
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
            objArea.descripcion = txtDescripcion.Text;

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
    }
}
