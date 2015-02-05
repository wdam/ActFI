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
using BLL;
using Aplicacion.Interfaces;


namespace Aplicacion.Inventario
{
    public partial class FrmSelTercero : Form
    {
        TerceroBLL bllT = new TerceroBLL();
        List<ETerceros> lstTerceros, lista;
        public string tipo;
        bool selBusqueda = false; // Para saber el tipo de busqueda en la grilla
        public FrmSelTercero()
        {
            InitializeComponent();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #region Proceso para mover formulario

        private bool mover;
        private int pX;
        private int pY;

        private void lblTituloPrinc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                mover = true; 
                 pX = e.X;
                 pY = e.Y;
                 this.Cursor = Cursors.NoMove2D;
            }
        }

        private void lblTituloPrinc_MouseMove(object sender, MouseEventArgs e)
        {
            if ( mover ){
                this.Location =  new Point((this.Left + e.X - pX), (this.Top + e.Y - pY));                 
            }                  
        }

        private void lblTituloPrinc_MouseUp(object sender, MouseEventArgs e)
        {
             mover = false;
             this.Cursor = Cursors.Default;
        }   

        #endregion

        #region Procesos de filtrar y cargar grilla

        protected void cargarGrilla()
        {

            if ((lstTerceros != null))
            {
                dgvTerceros.DataSource = lstTerceros;
                dgvTerceros.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Visible = true;
            }
        }

        protected void cargarGrilla(string dato)
        {

            lstTerceros = bllT.buscar(cboBuscar.Text, dato);
            if ((lstTerceros.Count > 0))
            {
                dgvTerceros.DataSource = lstTerceros;
                dgvTerceros.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                dgvTerceros.DataSource = lstTerceros;
                dgvTerceros.Refresh();
                lblMensaje.Text = "No Hay Coincidencias con la busqueda";
                lblMensaje.Visible = true;
            }
            lblRegistro.Text = "Cerca de " + lstTerceros.Count.ToString() + " registros encontrados";
        }

        protected void filtrarGrilla(string dato)
        {
            if (cboBuscar.Text == "Nombre")
            {
                lista = lstTerceros.Where(t => t.nombre.StartsWith(dato)).ToList();
            }
            else
            {
                lista = lstTerceros.Where(t => t.nit.StartsWith(dato)).ToList();
            }
            if ((lista.Count > 0))
            {
                dgvTerceros.DataSource = lista;
                dgvTerceros.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                dgvTerceros.DataSource = lista;
                dgvTerceros.Refresh();
                lblMensaje.Text = "No Hay Coincidencias con la busqueda";
                lblMensaje.Visible = true;
            }
            lblRegistro.Text = "Cerca de " + lista.Count.ToString() + " registros encontrados";
        }

        #endregion  

        private void FrmSelTercero_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tipo))
            {
                if (tipo == "PROVEEDOR") {
                    lstTerceros = bllT.getTipo(tipo);
                }
                else if (tipo == "Empleados") {
                    lstTerceros = bllT.getTipo(tipo);
                }
                selBusqueda = true;
            }
            else {
                lstTerceros = bllT.getAll();            
            }
            dgvTerceros.AutoGenerateColumns = false;
            cargarGrilla();
            cboBuscar.Text = "Nombre";
            lblRegistro.Text = "Cerca de " + lstTerceros.Count.ToString() + " registros encontrados";
        }

       
        
        private void dgvTerceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 ){
                seleccionar(e.RowIndex);        
            }
        }

        private void seleccionar(int fila) {
            // Se crea un  objeto interfaz para enviar el tercero seleccionado al formulario
            ISeleccionar Iform = this.Owner as ISeleccionar; 
            if (Iform != null) {
                Iform.SeleccionarDato(dgvTerceros.Rows[fila].Cells[0].Value.ToString());
            }
            this.Dispose();
        }

        private void dgvTerceros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                seleccionar(e.RowIndex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (selBusqueda == true)
            {
                filtrarGrilla(txtBuscar.Text.ToUpper());
            }
            else {
                if (txtBuscar.Text.Length > 3)
                {
                    cargarGrilla(txtBuscar.Text);
                }
            }           
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }                   
    }
}
