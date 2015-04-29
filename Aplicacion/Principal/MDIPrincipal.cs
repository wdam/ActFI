using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;


namespace Aplicacion.Principal
{
    public partial class MDIPrincipal : Form
    {        
        public MDIPrincipal()
        {
            InitializeComponent();           
        }

        private void mostrarFormulario(Form Frm)
        {
            if (SpContenedor.Panel2.Controls.Count > 0)
            {
                this.SpContenedor.Panel2.Controls.RemoveAt(0);
            }
            Frm.Dock = DockStyle.Fill;
            Frm.TopLevel = false;
            SpContenedor.Panel2.Controls.Add(Frm);
            SpContenedor.Panel2.Tag = Frm;
            Frm.Show();
        }

        private void lblInventario_Click(object sender, EventArgs e)
        {         
            Inventario.FrmInventario frm = Application.OpenForms.OfType<Inventario.FrmInventario>().FirstOrDefault();
            Inventario.FrmInventario activos = frm ?? new Inventario.FrmInventario();
            mostrarFormulario(activos);
        }        

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            Application.Exit();            
        }

        private void lblProcesos_Click(object sender, EventArgs e)
        {
            Procesos.FrmProcesos frm = Application.OpenForms.OfType<Procesos.FrmProcesos>().FirstOrDefault();
            Procesos.FrmProcesos procesos = frm ?? new Procesos.FrmProcesos();
            mostrarFormulario(procesos);
        }

        private void lblInformes_Click(object sender, EventArgs e)
        {
            Informes.FrmInformes frm = Application.OpenForms.OfType<Informes.FrmInformes>().FirstOrDefault();
            Informes.FrmInformes informes = frm ?? new Informes.FrmInformes();
            mostrarFormulario(informes);
        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblCerrar_ButtonClick(object sender, EventArgs e)
        {
            this.FormClosing -= MDIPrincipal_FormClosing;
            this.Dispose();
            FrmLogin frm = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
            frm.Show();
        }

        #region Modificar imagenes de menu principal        
   
        private void lblInventario_MouseMove(object sender, MouseEventArgs e)
        {           
            lblInventario.Image = Properties.Resources.inventario1;
            lblInventario.ForeColor = Color.Black;
        }

        private void lblInventario_MouseLeave(object sender, EventArgs e)
        {
            lblInventario.Image = Properties.Resources.inventario;
            lblInventario.ForeColor = Color.White;
        }

        private void lblProcesos_MouseMove(object sender, MouseEventArgs e)
        {
            lblProcesos.Image = Properties.Resources.proceso1;
            lblProcesos.ForeColor = Color.Black;
        }

        private void lblProcesos_MouseLeave(object sender, EventArgs e)
        {
            lblProcesos.Image = Properties.Resources.proceso;
            lblProcesos.ForeColor = Color.White;
        }

        private void lblInformes_MouseMove(object sender, MouseEventArgs e)
        {
            lblInformes.Image = Properties.Resources.informes1;
            lblInformes.ForeColor = Color.Black;
        }

        private void lblInformes_MouseLeave(object sender, EventArgs e)
        {
            lblInformes.Image = Properties.Resources.informes;
            lblInformes.ForeColor = Color.White;
        }

        private void lblSalir_MouseMove(object sender, MouseEventArgs e)
        {
            lblSalir.Image = Properties.Resources.Salir1;
            lblSalir.ForeColor = Color.Black;
        }

        private void lblSalir_MouseLeave(object sender, EventArgs e)
        {
            lblSalir.Image = Properties.Resources.Salir;
            lblSalir.ForeColor = Color.White;
        }
        #endregion

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + Inicializar.user.ToUpper();
            lblCompania.Text = Inicializar.company;
            lblPeriodo.Text = Inicializar.periodo;
        }

        private void tsmCambiarPer_Click(object sender, EventArgs e)
        {
            FrmPeriodo frmP = new FrmPeriodo();
            frmP.ShowDialog();
        }

        private void definirDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoDocumento frmT = new FrmTipoDocumento();
            frmT.ShowDialog();
        }

        
    }
}
