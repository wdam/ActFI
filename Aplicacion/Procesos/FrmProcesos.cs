using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Procesos
{
    public partial class FrmProcesos : Form
    {
        public FrmProcesos()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblParametros_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.ShowDialog();
        }

        private void lblDepreciacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDepreciacion frmDep = new FrmDepreciacion();
            frmDep.ShowDialog();
            this.Show();
        }

        private void FrmProcesos_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.01D;
            this.BackColor = Color.Blue;
        }

        private void FrmProcesos_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1D;
        }
    }
}
