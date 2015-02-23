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
    public partial class FrmSelDocumentos : Form
    {
        BLL.DocumentosBLL bllDoc = new BLL.DocumentosBLL();

        List<EDocumentos> lstDocumentos, lista;

        public FrmSelDocumentos()
        {
            InitializeComponent();
        }

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

        private void FrmSelDocumentos_Load(object sender, EventArgs e)
        {
            dgvDocumentos.AutoGenerateColumns = false;
            lista = bllDoc.getDocumentos();
            if (lista.Count > 0)
            {
                llenarCombo();                
                cargarGrilla("");
            }
            else {
                MessageBox.Show("No Encontraron Documentos.. En Este Periodo", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblMensaje.Visible = true;
            }
        }

        private void llenarCombo()
        {
            // Consulta LINQ para Seleccionar los tipo de documentos
            var tipos = from grupo in lista
                        group grupo by grupo.tipo into newGroup
                        orderby newGroup.Key
                        select newGroup;
            cboBuscar.Items.Clear();
            cboBuscar.Items.Add("TODOS");
            cboBuscar.Text = "TODOS";

            foreach (var item in tipos)
            {
                cboBuscar.Items.Add(item.Key);
            }
        }
        

        private void cargarGrilla(string dato)
        {
            if (dato == "")
            {
                lstDocumentos = lista;
            }
            else {
                lstDocumentos = lista.Where(t=> t.tipo==dato).ToList();
            }
            
            if (lstDocumentos.Count > 0)
            {
                dgvDocumentos.DataSource = lstDocumentos;
                dgvDocumentos.Refresh();
                lblMensaje.Visible = false;
            }
            else
            {
                dgvDocumentos.DataSource = lstDocumentos;
                dgvDocumentos.Refresh();
                lblMensaje.Visible = true;
            }
            lblRegistro.Text = "Cerca de " + lstDocumentos.Count.ToString() + " registros encontrados";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscar.Text == "TODOS")
            {
                cargarGrilla("");
            }
            else {
                cargarGrilla(cboBuscar.Text);
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1){
                seleccionar(e.RowIndex);
            }
        }

        private void seleccionar(int fila)
        {
            ISeleccionar Iform = this.Owner as ISeleccionar;
            if (Iform != null)
            {
                Iform.SeleccionarDato(dgvDocumentos.Rows[fila].Cells["dtTipo"].Value.ToString()+"-"+
                    dgvDocumentos.Rows[fila].Cells["dtcodigo"].Value.ToString());
            }
            this.Dispose();
        }

    }
}
