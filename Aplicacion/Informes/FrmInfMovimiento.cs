using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Aplicacion.Interfaces;
using CrystalDecisions.CrystalReports.Engine;


namespace Aplicacion.Informes
{
    public partial class FrmInfMovimiento : Form, ISeleccionar
    {
        BLL.TipoDocumentoBLL blltipo = new BLL.TipoDocumentoBLL();
        BLL.MovimientoBLL bllMov = new BLL.MovimientoBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();

        string tipo = "Todos";
        string activo = "Todos";
        List<ETipoDocumento> lstTipos;
        
        public FrmInfMovimiento()
        {
            InitializeComponent();
        }

            
        private void FrmInfMantenimiento_Load(object sender, EventArgs e)
        {
            lstTipos = blltipo.getAll();
            cboTipo.DataSource = lstTipos;
            cboTipo.DisplayMember = "tipoDoc";
            cboTipo.ValueMember = "tipoDoc";
           
            cboMostrar.DataSource = lstTipos;
            cboMostrar.DisplayMember = "descripcion";
            cboMostrar.ValueMember = "tipoDoc";

            txtYear1.Text = BLL.Inicializar.periodo.Substring(2, 5);
            txtYear2.Text = BLL.Inicializar.periodo.Substring(2, 5);

            cboInicial.Text = BLL.Inicializar.Mes;
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

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void rbDocUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDocUnico.Checked == true) {
                cboTipo.Enabled = true;
                tipo = cboTipo.SelectedValue.ToString();
            }
            else
            {
                cboTipo.Enabled = false;
                tipo = "Todos";
            }
             
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rbAunico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAunico.Checked == true)
            {
                txtCodActivo.Enabled = true;
            }
            else {
                txtCodActivo.Enabled = false;
            }
        }

        private void cboInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCombo(cboInicial.Text);
            cboFinal.Text = cboInicial.Text;
        }

        private void LlenarCombo(string periodo) {
            cboFinal.Items.Clear();
            for (int i = int.Parse(periodo); i <= 12; i++)
            {
                cboFinal.Items.Add(string.Format("{0:00}",i));
            }
        }

        private void lblGenerar_Click(object sender, EventArgs e)
        {
            if (rbDocumentos.Checked == true)
            {
                generarPorDocumento();
            }
            else {
                generarPorActivo();
            }
        }

        private void generarPorDocumento() {           
            ECompany objC = bllComp.buscar();
            DataTable dt = new DataTable();
            dt = bllMov.getAll(tipo, "Todos", cboInicial.Text + txtYear1.Text, cboFinal.Text + txtYear1.Text);
            Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
            ReportDocument reporte = new ReportDocument();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\RptInfMovimiento.rpt";
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

        private void generarPorActivo() { 
            
        }


        // Implementacion de interfaz
        public void SeleccionarDato(string dato)
        {
            throw new NotImplementedException();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo = cboTipo.SelectedValue.ToString();
        }

      
    }
}
