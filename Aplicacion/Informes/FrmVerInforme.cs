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
            this.Dispose(true);
        }

        private void FrmVerInforme_Load(object sender, EventArgs e)
        {            
            //lista.Add(activo);
            //ReportDocument reporte = new ReportDocument();
            //string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\infActivo.rpt";
            //reporte.Load(ruta);
            //reporte.SetDataSource(lista);
            //CReporte.ReportSource = reporte;
            //CReporte.Refresh();
        }

        private void parametros (){
            BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
            comp = bllComp.buscar();


        }


    }
}
