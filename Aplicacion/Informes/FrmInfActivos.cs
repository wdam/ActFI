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
using Aplicacion.Interfaces;

namespace Aplicacion.Informes
{
    public partial class FrmInfActivos : Form,  ISeleccionar
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();

        TextBox texto;

        public FrmInfActivos()
        {
            InitializeComponent();
        }

        #region Proceso para mover formulario

        private bool mover;
        private int pX;
        private int pY;

        private void lblTituloPrinc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mover = true;
                pX = e.X;
                pY = e.Y;
                this.Cursor = Cursors.NoMove2D;
            }
        }

        private void lblTituloPrinc_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = new Point((this.Left + e.X - pX), (this.Top + e.Y - pY));
            }
        }

        private void lblTituloPrinc_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

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
                gbCentro.Enabled = false;
                gbResponsable.Enabled = false;
            }
            else {
                txtCodActivo.Enabled = false;
                gbCentro.Enabled = true;
                gbResponsable.Enabled = true;
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

        private void rbRUno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRUno.Checked == true)
            {
                txtResponsable.Enabled = true;
                txtResponsable.Focus();
            }
            else {
                txtResponsable.Enabled = false;
            }
        }

        private void rbCUno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCUno.Checked == true) {
                txtCentro.Enabled = true;
                txtCentro.Focus();
            }
            else {
                txtCentro.Enabled = false;
            }
        }



        public void SeleccionarDato(string dato)
        {
            texto.Text = dato;
        }

        private void txtCodActivo_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            Inventario.FrmSelActivos frmS = new Inventario.FrmSelActivos();
            frmS.ShowDialog(this);
        }

        private void txtResponsable_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            Inventario.FrmSelTercero frmt = new Inventario.FrmSelTercero();
            frmt.tipo = "Empleados";
            frmt.ShowDialog(this);
        }

        private void txtCentro_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            Inventario.FrmSelCentroCostos frmC = new Inventario.FrmSelCentroCostos();            
            frmC.ShowDialog(this);
        }
    }
}
