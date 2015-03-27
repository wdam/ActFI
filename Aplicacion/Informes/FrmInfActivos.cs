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
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();

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
            if (cboAgrupar.Text == "NO AGRUPAR") { // Si Decide No Agrupar los Datos 

                if (rbTodos.Checked == true)
                { // Si Son todos los Activos
                    informeGeneral();
                }
                else
                {
                    informeIndidual();
                }
            }
            else { 
            // Realizar Informe Agrupado por Centro de Costo o Responsable
                if (cboAgrupar.Text == "RESPONSABLE")
                {
                    informeAgrupado("responsable");
                }
                else {
                    informeAgrupado("ccosto");
                }
            }
                    
        }
        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void informeIndidual() {
            List<EActivos> lst = new List<EActivos>();
            lst.Add(bllAct.buscar(txtCodActivo.Text));           
            ECompany objC = bllComp.buscar();
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\rptinfActBasico.rpt";
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
                  
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();           
            dt = bllAct.informeGeneral(cboPropiedad.Text);
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptinfActivos.rpt";
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

        private void informeAgrupado(string campo) {

            FieldDefinition fielDef;
            
           
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            dt = bllAct.informeGeneral(cboPropiedad.Text,campo);
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptinfActivos2.rpt";
          
            reporte.Load(ruta);
            reporte.SetDataSource(dt);
            // Asignacion de Parametros 
            reporte.SetParameterValue("comp", objC.descripcion);
            reporte.SetParameterValue("nit", objC.nit);
            reporte.SetParameterValue("periodo", "Periodo Actual: " + BLL.Inicializar.periodo);
            fielDef = reporte.Database.Tables[0].Fields[campo];
            reporte.DataDefinition.Groups[0].ConditionField = fielDef;
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

        private void cboPropiedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmInfActivos_Load(object sender, EventArgs e)
        {
            cboAgrupar.SelectedIndex = 0;
            cboPropiedad.SelectedIndex = 0;
        }

      
    }
}
