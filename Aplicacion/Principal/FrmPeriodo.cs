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

namespace Aplicacion.Principal
{
    public partial class FrmPeriodo : Form
    {
        List<EPeriodo> lstPer;
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
        
        public FrmPeriodo()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void FrmPeriodo_Load(object sender, EventArgs e)
        {
            lblPeriodo.Text = BLL.Inicializar.periodo;
            txtanio.Text = BLL.Inicializar.periodo.Substring(3, 4);  

            if (BLL.Inicializar.rolUser == "admin" || BLL.Inicializar.rolUser == "modificacion")
            {
                lstPer = bllComp.getPerBloqueado("n");
                if (lstPer.Count > 0) {
                    cboPeriodo.DataSource = lstPer;
                    cboPeriodo.ValueMember = "periodo";
                    cboPeriodo.DisplayMember = "periodo";                        
                }                 
            }
            else {
                MessageBox.Show("Acceso denegado para este perfil de usuario.. ", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }                               
        }

        private void lblAplicar_Click(object sender, EventArgs e)
        {
            if (txtanio.Text != "" && cboPeriodo.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Se va abrir un período diferente, ¿ Desea Abrirlo ? ", "Control de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string mensaje = bllComp.abrirPeriodo(cboPeriodo.Text + "/" + txtanio.Text);
                    if (mensaje == "Correcto")
                    {
                        bllComp.buscarPeriodo();
                        MessageBox.Show(" El período se abrio correctamente.. !! ", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose(true);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                this.Dispose(true);
            }
            else {
                MessageBox.Show("No ha Seleccionado ningun periodo.. Verifique !! ", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
        }
    }
}
