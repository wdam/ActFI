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
    public partial class FrmSelTipoDocumento : Form
    {
        public string tipo;
        BLL.TipoDocumentoBLL blltipo = new BLL.TipoDocumentoBLL();
        List<ETipoDocumento> lstTipos;

        public FrmSelTipoDocumento()
        {
            InitializeComponent();
        }

        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            cargarGrilla();
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

        protected void cargarGrilla() {
            lstTipos = blltipo.getAll();
            int cont = 0;
            if (lstTipos.Count > 0)
            {
                lblMensaje.Visible = false;
                foreach (var item in lstTipos)
                {
                    cont++;
                    dgvTipo.Rows.Add(cont, item.descripcion, item.tipoDoc, item.grupo);
                }
            }
            else {
                lblMensaje.Visible = true;
            }

        }

        private void seleccionar(int fila)
        {
            ISeleccionar Iform = this.Owner as ISeleccionar;
            if (Iform != null)
            {
                Iform.SeleccionarDato(dgvTipo.Rows[fila].Cells[2].Value.ToString());
            }
            this.Close();
        }

        private void dgvTipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1){
                seleccionar(e.RowIndex);
            }
        }

        private void dgvTipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                seleccionar(e.RowIndex);
            }
        }
    }
}
