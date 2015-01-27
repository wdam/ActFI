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
    public partial class FrmSelCuentas : Form
    {
        BLL.CuentasBLL bllCuenta = new BLL.CuentasBLL();
        List<ECuentas> lista, lstCuenta;
        public FrmSelCuentas()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void cargarGrilla(string dato) {

            if (cboBuscar.Text == "Cuenta") {
                lstCuenta = lista.Where(t => t.codigo.StartsWith(dato)).ToList();
            }
            else if (cboBuscar.Text == "Descripcion")
            {
                lstCuenta = lista.Where(t => t.descripcion.StartsWith(dato)).ToList();
            }
            else if (dato == "Auxiliar")
            {
                lstCuenta = lista.Where(t => t.nivel.StartsWith("Auxiliar")).ToList() ;
            }
            if (lstCuenta.Count > 0)
            {
                dgvCuentas.DataSource = lstCuenta;
                dgvCuentas.Refresh();
                lblMensaje.Visible = false;
                
            }
            else {
                dgvCuentas.DataSource = lstCuenta;
                dgvCuentas.Refresh();
                lblMensaje.Visible = true;
            }
            lblRegistro.Text = "Cerca de " + lstCuenta.Count.ToString() + " registros encontrados";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBuscar.Text)){
                cargarGrilla(txtBuscar.Text );
            }
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }

        private void FrmSelCuentas_Load(object sender, EventArgs e)
        {
            lista = bllCuenta.getAll();
            dgvCuentas.AutoGenerateColumns = false;
            cargarGrilla("Auxiliar");
            cboBuscar.Text = "Descripcion";
            txtBuscar.Focus();
        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                if (dgvCuentas.Rows[e.RowIndex].Cells[2].Value.ToString() == "Auxiliar")
                {
                    seleccionar(e.RowIndex);
                }
                else {
                    MessageBox.Show("Solo Puede Elegir Cuentas de Nivel Auxiliar", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void seleccionar(int fila) {
            ISeleccionar Iform = this.Owner as ISeleccionar;
            if (Iform != null) { 
                Iform.SeleccionarDato(dgvCuentas.Rows[fila].Cells[0].Value.ToString());
            }
            this.Dispose();
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvCuentas.Rows[e.RowIndex].Cells[2].Value.ToString() == "Auxiliar")
                {
                    seleccionar(e.RowIndex);
                }
                else
                {
                    MessageBox.Show("Solo Puede Elegir Cuentas de Nivel Auxiliar", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter) {
                dgvCuentas.Focus();
            }
        }

    }
}
