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
    public partial class FrmSubgrupo : Form
    {
        BLL.GrupoBLL bllGrupo = new BLL.GrupoBLL();
        private string operacion="";
        private string codigo = "";        

        public FrmSubgrupo(string grupo, string operacion)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.codigo = grupo;
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

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lblAplicar_Click(object sender, EventArgs e)
        {
            if (validar()){
                guardar();
            } else {
                MessageBox.Show("Datos Incorrectos .. Por favor Verifique", "Control de Informacion ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validar() {
            bool correcto = true;
            if (txtGrupo.Text == "") {
                smsError.SetError(txtGrupo, "No hay Grupo Seleeccionado");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) {
                smsError.SetError(txtCodigo, "Ingrese el Codifo del subgrupo");
                correcto = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) {
                smsError.SetError(txtDescripcion, "Ingrese la Descripcion del Subgrupo");
                correcto = false;
            }

            if (cboEstado.Text == "")
            {
                smsError.SetError(cboEstado, "Seleccione el estado");
                correcto = false;
            }
            return correcto;
        }

        private void guardar() {
            ESubgrupo objSub = new ESubgrupo();
            objSub.codigo = txtCodigo.Text;
            objSub.descripcion = txtDescripcion.Text;
            objSub.estado = cboEstado.Text;
            objSub.grupo = txtGrupo.Text;
            string mensaje="";
            if (this.operacion == "Nuevo") {
                mensaje = bllGrupo.guardarSubgrupo(objSub, "Nuevo");                
            }
            else if (this.operacion == "Editar") {
                mensaje = bllGrupo.guardarSubgrupo(objSub, "Editar");               
            }
            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Guardados  Correctamente", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(mensaje, "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void FrmSubgrupo_Load(object sender, EventArgs e)
        {
            if (this.operacion == "Nuevo")
            {
                txtGrupo.Text = codigo;
            }
            else if (this.operacion == "Editar") {
                txtCodigo.ReadOnly = true;
                mostrarDatos();
            }                        
        }

        private void mostrarDatos() {
            ESubgrupo obj = bllGrupo.buscarSubgrupo(codigo);
            if (obj != null) {
                txtCodigo.Text = obj.codigo;
                txtDescripcion.Text = obj.descripcion;
                txtGrupo.Text = obj.grupo;
                cboEstado.Text = obj.estado;
            }
        }
    }
}
