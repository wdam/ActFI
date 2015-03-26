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
    public partial class FrmInfGrupos : Form
    {
        BLL.GrupoBLL bllGrupo = new BLL.GrupoBLL();
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();

        List<EGrupo> lstGrupos;
        List<ESubgrupo> lstSubgrupo;
        public FrmInfGrupos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void cargarGrupos()
        {
            lstGrupos = bllGrupo.getAll("Activo");
            cboGrupo.DataSource = lstGrupos;
            cboGrupo.DisplayMember = "descripcion";
            cboGrupo.ValueMember = "sigla";
            if (lstGrupos.Count > 0)
            {
                cboGrupo_SelectedIndexChanged(null, null);
            }
        }

        private void cargarSubgrupos(string sigla)
        {
            cboSubgrupo.Text = "";
            lstSubgrupo = bllGrupo.getSubgrupo(sigla);
            cboSubgrupo.DataSource = lstSubgrupo;
            cboSubgrupo.DisplayMember = "descripcion";
            cboSubgrupo.ValueMember = "codigo";
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSubgrupos(cboGrupo.SelectedValue.ToString());
        }

        private void rbUnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnGrupo.Checked == true)
            {
                cboGrupo.Enabled = true;
            }
            else {
                cboGrupo.Enabled = false;
            }
        }

        private void rbUnSubg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnSubg.Checked == true) {
                cboSubgrupo.Enabled = true;
            }
            else
            {
                cboSubgrupo.Enabled = false;
            }
        }

        private void FrmInfGrupos_Load(object sender, EventArgs e)
        {
            cargarGrupos();            
            dtpInicio.Value = DateTime.Now.AddMonths(-12);
        }

        private void lblGenerar_Click(object sender, EventArgs e)
        {
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            string grupo="";
            string subgrupo="";
            string fInicio="";
            string fFinal = "";
            if (rbtodosGrupo.Checked == true) {
                grupo = "Todos";
            }
            else {
                grupo = cboGrupo.SelectedValue.ToString();
            }

            if (rbtodosSubg.Checked == true)
            {
                subgrupo = "Todos";
            }
            else {
                subgrupo = cboSubgrupo.SelectedValue.ToString();
            }

            if (rbFecha.Checked == true)
            {
                fFinal = "Todos";
                fInicio = "Todos";
            }
            else {
                fInicio = UtilSystem.fFecha(dtpInicio.Value);
                fFinal = UtilSystem.fFecha(dtpFinal.Value);
            }

            dt = bllAct.informeGrupo(grupo, subgrupo, fInicio, fFinal);

            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptInfGrupos.rpt";
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

        private void rbRango_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRango.Checked == true)
            {
                dtpFinal.Enabled = true;
                dtpInicio.Enabled = true;
            }
            else {
                dtpFinal.Enabled = false;
                dtpInicio.Enabled = false;
            }
        }
    }
}
