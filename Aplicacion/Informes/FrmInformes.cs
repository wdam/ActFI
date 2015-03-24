using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Informes
{
    public partial class FrmInformes : Form
    {
        public FrmInformes()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
   

        private void lblAreas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrminfAreas frmA = new FrminfAreas();
            frmA.ShowDialog();
            this.Show();
        }

        private void lblHistorial_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInfActivos frm = new FrmInfActivos();
            frm.ShowDialog();
            this.Show();
        }

        

        private void lblMovimientos_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInfMovimiento frm = new FrmInfMovimiento();
            frm.ShowDialog();
            this.Show();
        }

        private void lblDepreciacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInfDepreciacion frm = new FrmInfDepreciacion();
            frm.ShowDialog();
            this.Show();
        }

      
    }
}
