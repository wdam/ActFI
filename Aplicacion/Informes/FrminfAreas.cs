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
    public partial class FrminfAreas : Form
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        string codArea; // Codido de Area Seleccionada
        public FrminfAreas()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void CargarAreas()
        {
            BLL.AreaBLL ctrArea = new BLL.AreaBLL();
            List<EArea> Areas = null;
            Areas = ctrArea.getAll();
            if (Areas.Count > 0)
            {
                cboArea.DisplayMember = "nombre";
                cboArea.ValueMember = "codigo";
                cboArea.DataSource = Areas;
            }
        }

        private void FrminfAreas_Load(object sender, EventArgs e)
        {
            CargarAreas();
            codArea = "";
        }

        private void rbUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnico.Checked == true){
                cboArea.Enabled = true;
                codArea = cboArea.SelectedValue.ToString();
            } else{
                cboArea.Enabled = false;
                codArea = "";
            }
        }

        private void lblGenerar_Click(object sender, EventArgs e)
        {
            informe(codArea);
        }

        private void informe(string codigo) {
            BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            dt = bllAct.informeUbicacion(codigo);
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptInfAreas.rpt";
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

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            codArea = cboArea.SelectedValue.ToString();
        }
    }
}
