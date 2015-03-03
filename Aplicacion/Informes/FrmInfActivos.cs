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
using CrystalDecisions.CrystalReports.Engine;

namespace Aplicacion.Informes
{
    public partial class FrmInfActivos : Form
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        public FrmInfActivos()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblGenerar_Click(object sender, EventArgs e)
        {
            if (rbTodos.Checked== true)
            {
                informeGeneral();
            }
            else {
                informeIndidual();
            }            
        }
        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void informeIndidual() {
            List<EActivos> lst = new List<EActivos>();
            lst.Add(bllAct.buscar(txtCodActivo.Text));
            BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
            ECompany objC = bllComp.buscar();

            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\infActivo.rpt";
            reporte.Load(ruta);
            reporte.SetDataSource(lst);
            // Asignacion de Parametros 
            reporte.SetParameterValue("comp", objC.descripcion);
            reporte.SetParameterValue("nit", objC.nit);
            reporte.SetParameterValue("periodo", "Periodo Actual: " + BLL.Inicializar.periodo);

            frm.CReporte.ReportSource = reporte;
            frm.CReporte.Refresh();
            frm.Show();
        }

        private void informeGeneral() {
        
            BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            dt = bllAct.informeGeneral();
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\FrminfActivos.rpt";
            reporte.Load(ruta);
            reporte.SetDataSource(dt);
            // Asignacion de Parametros 
            reporte.SetParameterValue("comp", objC.descripcion);
            reporte.SetParameterValue("nit", objC.nit);
            reporte.SetParameterValue("periodo", "Periodo Actual: " + BLL.Inicializar.periodo);

            frm.CReporte.ReportSource = reporte;
            frm.CReporte.Refresh();
            frm.ShowDialog();             
        }

        private void rbUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnico.Checked == true)
            {
                txtCodActivo.Enabled = true;
                txtCodActivo.Focus();
            }
            else {
                txtCodActivo.Enabled = false;
            }
        }

      
    }
}
