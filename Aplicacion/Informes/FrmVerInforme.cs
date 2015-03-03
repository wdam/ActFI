using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows;

namespace Aplicacion.Informes
{
    public partial class FrmVerInforme : Form
    {
        
         Entidades.ECompany comp;
        public FrmVerInforme()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void parametros (){
            BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
            comp = bllComp.buscar();
        }


    }
}
