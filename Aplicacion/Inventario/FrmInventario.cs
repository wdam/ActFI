using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Inventario
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblActivos_Click(object sender, EventArgs e)
        {            
            this.Hide();
            FrmActivos frm = Application.OpenForms.OfType<FrmActivos>().FirstOrDefault();
            FrmActivos form = frm ?? new FrmActivos();
            form.ShowDialog();            
            this.Show();
        }

        private void lblAreas_Click(object sender, EventArgs e)
        {                   
            this.Hide();
            FrmAreaResp frm = new FrmAreaResp();
            frm.ShowDialog();
            this.Show();                     
        }

        private void lblParametros_Click(object sender, EventArgs e)
        {                   
            this.Hide();
            FrmParametros frm = new FrmParametros();
            frm.ShowDialog();
            this.Show();
        }

        private void lblTerceros_Click(object sender, EventArgs e)
        {                 
            this.Hide();
            FrmTerceros frm = new FrmTerceros();
            frm.ShowDialog();
            this.Show();            
        }

       
        private void lblSaldos_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;
            FrmSaldosIniciales frm = new FrmSaldosIniciales();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;
        }

        private void lblDocumentos_Click(object sender, EventArgs e)
        {            
            this.Hide();
            FrmDocumentos frm = new FrmDocumentos();
            frm.ShowDialog();
            this.Show();            
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {            
            this.Hide();
            Principal.FrmGrupos frmG = new Principal.FrmGrupos();
            frmG.ShowDialog();
            this.Show();            
        }
    }
}
