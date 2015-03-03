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
            this.menuPrincipal.Visible = false;            
            FrmActivos frm = Application.OpenForms.OfType<FrmActivos>().FirstOrDefault();
            FrmActivos form = frm ?? new FrmActivos();
            form.ShowDialog();
            this.menuPrincipal.Visible = true;
            
        }

        private void lblAreas_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;            
            FrmAreaResp frm = new FrmAreaResp();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;            
        }

        private void lblParametros_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;            
            FrmParametros frm = new FrmParametros();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;
        }

        private void lblTerceros_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;            
            FrmTerceros frm = new FrmTerceros();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;
        }

        private void lblTraslados_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;            
            FrmTraslados frm = new FrmTraslados();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;
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
            this.menuPrincipal.Visible = false;
            FrmDocumentos frm = new FrmDocumentos();
            frm.ShowDialog();
            this.menuPrincipal.Visible = true;
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Visible = false;
            Principal.FrmGrupos frmG = new Principal.FrmGrupos();
            frmG.ShowDialog();
            this.menuPrincipal.Visible = true;
        }
    }
}
