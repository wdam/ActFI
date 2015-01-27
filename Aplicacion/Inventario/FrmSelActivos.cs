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
    public partial class FrmSelActivos : Form
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        List<EActivos> lista, lstActivos;

        public FrmSelActivos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void FrmSelActivos_Load(object sender, EventArgs e)
        {
            lista = bllAct.getActivos();
            dgvActivos.AutoGenerateColumns = false;
            cargarGrilla();
            cboBuscar.Text = "Nombre";
        }

        #region Proceso de cargar Grilla
        private void cargarGrilla()
        {
            if (lista.Count > 0)
            {
                dgvActivos.DataSource = lista;
                dgvActivos.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Visible = true;
            }
            lblRegistro.Text = "Cerca de " + lista.Count.ToString() + " registros encontrados";
        }

        private void cargarGrilla(string dato)
        {             
            if (cboBuscar.Text =="Codigo")
            {
                lstActivos = lista.Where(t => t.codigo.StartsWith(dato)).ToList();
            } 
            else if (cboBuscar.Text =="Propiedad")
            {
                lstActivos = lista.Where(t => t.propiedad.StartsWith(dato)).ToList();
            }
            else if (cboBuscar.Text =="Area")
            {
                lstActivos = lista.Where(t => t.area.StartsWith(dato)).ToList();
            } else{
                lstActivos = lista.Where(t => t.nombre.StartsWith(dato)).ToList();
            }

            if (lstActivos.Count > 0)
            {
                dgvActivos.DataSource = lstActivos;
                dgvActivos.Refresh();
                lblMensaje.Visible = false;
            }
            else {
                dgvActivos.DataSource = lstActivos;
                dgvActivos.Refresh();
                lblMensaje.Visible = true;
            }

            lblRegistro.Text = "Cerca de " + lstActivos.Count.ToString() + " registros encontrados";
        }
        #endregion

        private void dgvActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                seleccionar(e.RowIndex);    
            }
        }

        private void seleccionar(int fila) {
            ISeleccionar IForm = this.Owner as ISeleccionar;
            if (IForm != null) {
                IForm.SeleccionarDato(dgvActivos.Rows[fila].Cells[0].Value.ToString()); 
            }
            this.Dispose();
        }

        private void dgvActivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                seleccionar(e.RowIndex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {          
            cargarGrilla(txtBuscar.Text);
          
        }
        
    }
}
