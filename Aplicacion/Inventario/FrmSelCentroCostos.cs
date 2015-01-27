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
    public partial class FrmSelCentroCostos : Form
    {
        List<ECentroCosto> lstCentro, lista;
        BLL.CentroCostoBLL bllCentro = new BLL.CentroCostoBLL();

        public FrmSelCentroCostos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }
        #region Procesos de Cargar Grilla
      
        private void cargarGrilla(string dato){
            if (cboBuscar.Text == "Codigo")
            {
            lista = lstCentro.Where(t => t.Codigo.StartsWith(dato)).ToList();
            }
            else if (cboBuscar.Text == "Nombre")
            {
                lista = lstCentro.Where(t => t.Nombre.StartsWith(dato)).ToList();
            }
            else if (dato == "Load"){
                lista = lstCentro;
            }
              
            if (lista.Count > 0)
            {
                dgvCentro.DataSource = lista;
                dgvCentro.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                dgvCentro.DataSource = lista;
                dgvCentro.Refresh();
                lblMensaje.Visible = true;
            }

            lblRegistro.Text = "Cerca de " + lista.Count.ToString() + " registros encontrados";
        }
        #endregion

        private void FrmSelCentroCostos_Load(object sender, EventArgs e)
        {
            lstCentro = bllCentro.getAll();
            dgvCentro.AutoGenerateColumns = false;
            cargarGrilla("Load");
            cboBuscar.Text = "Nombre";
        }

        private void dgvCentro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                if (dgvCentro.Rows[e.RowIndex].Cells[2].Value.ToString() == "centro")
                {
                    Seleccionar(e.RowIndex);
                } 
                else {
                MessageBox.Show("Solo Puede Seleccionar los de Nivel  Centro", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgvCentro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                if (dgvCentro.Rows[e.RowIndex].Cells[2].Value.ToString() == "centro")
                {
                    Seleccionar(e.RowIndex);
                }
                else
                {
                    MessageBox.Show("Solo Puede Seleccionar los de Nivel  Centro", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Seleccionar(int fila) {
            ISeleccionar Iform = this.Owner as ISeleccionar;
                if (Iform != null) {
                    Iform.SeleccionarDato(dgvCentro.Rows[fila].Cells[1].Value.ToString());
                }
                this.Dispose();                                                         
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) {
                cargarGrilla(txtBuscar.Text);
            }

        }

    }
}
