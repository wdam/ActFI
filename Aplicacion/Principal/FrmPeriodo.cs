using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Principal
{
    public partial class FrmPeriodo : Form
    {
        public FrmPeriodo()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void FrmPeriodo_Load(object sender, EventArgs e)
        {
            lblPeriodo.Text = BLL.Inicializar.periodo;
            txtanio.Text = BLL.Inicializar.periodo.Substring(3, 4);            
        }
    }
}
