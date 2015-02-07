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

        }
    }
}
