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

namespace Aplicacion.Inventario
{
    public partial class FrmSaldosIniciales : Form
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        EActivos activo;
        string codigo;

        public FrmSaldosIniciales()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void dgvItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0) {
                dgvItems.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            }
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0) {

                switch (e.ColumnIndex)
                {
                    case 1:
                        codigo = dgvItems.Rows[e.RowIndex].Cells["dtCodigo"].Value.ToString().Trim();
                        if (codigo.Length > 0)
                        {
                            activo = bllAct.buscar(codigo);
                            if (activo != null)
                            {
                                dgvItems.Rows[e.RowIndex].Cells["dtDescripcion"].Value = activo.nombre;
                            }
                            else
                            {
                                dgvItems.Rows[e.RowIndex].Cells["dtDescripcion"].Value = string.Empty;
                                MessageBox.Show("Codigo no Existe.. Verifique", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        break;

                    case 4:
                        int cant = Convert.ToInt16(dgvItems.Rows[e.RowIndex].Cells["dtCantidad"].Value);
                        double valor = Convert.ToDouble(dgvItems.Rows[e.RowIndex].Cells["dtvalUnitario"].Value);
                        dgvItems.Rows[e.RowIndex].Cells["dtTotal"].Value = cant * valor;
                        break;
                }                
            }
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = (TextBox)e.Control;
            validar.KeyPress +=  new KeyPressEventHandler(this.Validar);
        }

        // Validar teclas presionadas en la grilla /// 
        private void Validar(object sender, KeyPressEventArgs e) {
            int columna = dgvItems.CurrentCell.ColumnIndex;
            switch (columna)
            {
                case 3:
                    if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back)){                    
                        e.KeyChar = Convert.ToChar(0);
                    }
                    break;
                case 4:
                    TextBox txt = (TextBox)sender;
                        if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)  || e.KeyChar == '.' && txt.Text.Contains(".") == false)
                            {
                                e.Handled = false;
                            } else {
                            e.Handled = true;
                            }
                    break;
            }
           
        }                      
    }
}
