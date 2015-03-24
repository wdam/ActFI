using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Interfaces;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;

namespace Aplicacion.Informes
{
    public partial class FrmInfDepreciacion : Form,ISeleccionar
    {

        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
        public FrmInfDepreciacion()
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

        private void cboInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCombo(cboInicial.Text);
            cboFinal.Text = cboInicial.Text;
        }

        private void LlenarCombo(string periodo)
        {
            cboFinal.Items.Clear();
            for (int i = int.Parse(periodo); i <= 12; i++)
            {
                cboFinal.Items.Add(string.Format("{0:00}", i));
            }
        }

        private void FrmInfDepreciacion_Load(object sender, EventArgs e)
        {
            txtYear1.Text = BLL.Inicializar.periodo.Substring(2, 5);
            txtYear2.Text = BLL.Inicializar.periodo.Substring(2, 5);
            cboInicial.Text = BLL.Inicializar.Mes;
        }

        private void txtCodActivo_DoubleClick(object sender, EventArgs e)
        {
            Aplicacion.Inventario.FrmSelActivos frm = new Aplicacion.Inventario.FrmSelActivos();
            frm.ShowDialog(this);
        }

        public void SeleccionarDato(string dato)
        {
            txtCodActivo.Text = dato;
        }

        private void rbAunico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAunico.Checked == true)
            {
                txtCodActivo.Enabled = true;
                txtCodActivo.Text = "";
            }
            else
            {
                txtCodActivo.Enabled = false;
            }
        }

        private void lblGenerar_Click(object sender, EventArgs e)
        {
            if (rbAtodos.Checked == true)
            {
                generarTodosPDF();
            }
            else {
                if (string.IsNullOrWhiteSpace(txtCodActivo.Text)) {
                    MessageBox.Show("Seleccione un Activo", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodActivo.Focus();
                    return;
                }
                generarUno();
            }
        }

        private void generarTodosPDF()
        {
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            dt = bllAct.informeValores();
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptInfDepreciacion.rpt";
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

        private void generarUno()
        {
                
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

       
    }
}
