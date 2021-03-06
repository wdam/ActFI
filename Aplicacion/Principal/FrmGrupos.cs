﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.Principal
{
    public partial class FrmGrupos : Form, ISeleccionar
    {
        BLL.GrupoBLL bllGrupo = new BLL.GrupoBLL();
        TextBox texto;

        List<EGrupo> lstGrupos;
        EGrupo objGrupo;
        List<ESubgrupo> lstSubgrupo;
        string grupoSel; // Grupo Seleccionado
        int fila; // Fila Seleccionada

        public FrmGrupos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        #region Cambiar Colores de Fondo de los label
        private void ColocarColorFondo(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 32, 64);
        }

        private void QuitarColorFondo(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(0, 111, 169);
        }
        #endregion  

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

        #region Ocultar / Mostrar Paneles dependiendo de la opcion seleccionada

        private void ocultarPanel1()
        {
            panelGrupo.Visible = false;
            panelSubgrupo.Visible = true;
          //  panelVal.Width = 780;
            lblColor.Visible = false;
            lblColor1.Visible = true;
            btnTab2.FlatAppearance.BorderSize = 1;
            btnTab1.FlatAppearance.BorderSize = 0;
        }

        private void ocultarPanel2()
        {
            panelGrupo.Visible = true;
            panelSubgrupo.Visible = false;
            //panelVal.Width = 780;
            lblColor1.Visible = false;
            lblColor.Visible = true;
            btnTab2.FlatAppearance.BorderSize = 0;
            btnTab1.FlatAppearance.BorderSize = 1;
        }

        private void btnTab1_Click(object sender, EventArgs e)
        {
            ocultarPanel2();
        }

        private void btnTab2_Click(object sender, EventArgs e)
        {
            ocultarPanel1();
        }

        #endregion  

        #region  Habilitar y Deshabilitar

        private void Habilitar() {
            panelGrupo.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            lblNuevo.Enabled = false;
            lblEditar.Enabled = false;
            if (lblOperacion.Text == "Editar")
            {
                txtSigla.ReadOnly = true;
            }
            else {
                txtSigla.ReadOnly = false;
            }
        }

        private void Deshabilitar() {
            panelGrupo.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            lblNuevo.Enabled = true;
            lblEditar.Enabled = true;           
            lblOperacion.Text = "Consulta";
        }

        private void limpiar() {
            txtSigla.Text = "";
            txtDescripcion.Text = "";
            txtActivo.Clear();
            txtCorreccion.Clear();
            txtDepreciacion.Clear();
            txtGanancia.Clear();
            txtGastos.Clear();
            txtMantenimiento.Clear();
            txtPerdida.Clear();
            txtRevalorizar.Clear();
            txtValSalvamento.Value = 0;
            txtVidaUtil.Value = 12;
        }
        #endregion

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            ocultarPanel2();
            dgvGrupo.AutoGenerateColumns = false;
            dgvSubGrupo.AutoGenerateColumns = false;
            List<EtiposGenericos> lstTipos = UtilSystem.metodosDepreciacion();
            cboMetodo.DisplayMember = "Descripcion";
            cboMetodo.ValueMember = "sigla";            
            cboMetodo.DataSource = lstTipos;
            cargarGrupos();
        }

        private void cargarGrupos() {
            lstGrupos = bllGrupo.getAll("Todos");
           
            dgvGrupo.DataSource = lstGrupos;
            dgvGrupo.Refresh();
            if (lstGrupos.Count > 0)
            {
                fila = dgvGrupo.CurrentCell.RowIndex;
                lblNuevoSub.Visible = true;
            }
        }

        private void cboVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVer.Text == "SIGLA")
            {
                this.dgDescripcion.Visible = false;
                this.dgCodigo.Visible = true;
            }
            else {
                this.dgCodigo.Visible = false;
                this.dgDescripcion.Visible = true;
            }
        }

        private void cboVer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {            
            lblOperacion.Text = "Nuevo";
            smsError.Dispose();
            btnTab1.PerformClick();
            Habilitar();         
            limpiar();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            smsError.Dispose();
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validar())
            {
                if (lblOperacion.Text == "Nuevo") {
                    Guardar();
                }
                else if (lblOperacion.Text == "Editar") {
                    Modificar();
                }
                cargarGrupos();
            }
            else {
                MessageBox.Show("Datos Incorrectos .. Por favor Verifique", "Control de Informacion ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }
        public void Guardar() {
            EGrupo objGrupo = crearGrupo();
            string mensaje = bllGrupo.insertar(objGrupo, "Nuevo");
            if (mensaje == "Exito")
            {
                MessageBox.Show("Grupo Creado Correctamente", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(mensaje, "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Deshabilitar();
        }


        public void Modificar()
        {
            EGrupo objGrupo = crearGrupo();
            string mensaje = bllGrupo.insertar(objGrupo, "Editar");
            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Actualizados  Correctamente", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Deshabilitar();
        }

        private EGrupo crearGrupo() {
            EGrupo objGrupo = new EGrupo();
            objGrupo.sigla = txtSigla.Text;
            objGrupo.descripcion = txtDescripcion.Text;
            objGrupo.metodoDep = cboMetodo.SelectedValue.ToString();
            objGrupo.valSalvamento = Convert.ToInt16(txtValSalvamento.Value);
            objGrupo.vidaUtil = Convert.ToInt16(txtVidaUtil.Value);
            objGrupo.ctaActivo = txtActivo.Text;
            objGrupo.ctaCorreccion = txtCorreccion.Text;
            objGrupo.ctaDepreciacion = txtDepreciacion.Text;
            objGrupo.ctaGanancia = txtGanancia.Text;
            objGrupo.ctaGastos = txtGastos.Text;
            objGrupo.ctaMantenimiento = txtMantenimiento.Text;
            objGrupo.ctaPerdida = txtPerdida.Text;
            objGrupo.ctaRevalorizar = txtRevalorizar.Text;
            objGrupo.estado = "ACTIVO";
            return objGrupo;
        }

        private bool validar() {
             bool correcto = true;
            if (string.IsNullOrWhiteSpace(txtSigla.Text)) {
                 smsError.SetError(txtSigla, "Ingrese Codigo o Sigla del grupo");
                 correcto = false;
             }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) {
                smsError.SetError(txtDescripcion, "Ingrese la Descripción");
                correcto = false;
            }
            if (string.IsNullOrEmpty(txtVidaUtil.Text.ToString())) {
                smsError.SetError(lblmeses, "La Vida Util no debe ser menor a 12 Meses");
                correcto = false;
            }
            if (string.IsNullOrEmpty(txtValSalvamento.Text.ToString()))
            {
                smsError.SetError(lblPorcentaje, "El valor del valor de Salvamento");
                correcto = false;
            }
             return correcto;
        }

        private void txtValSalvamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilSystem.ValidarNumero(sender, e);
        }

        private void cboMetodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
        private void cuentas_DoubleClick(object sender, EventArgs e) {
            texto = (TextBox)sender;
            Inventario.FrmSelCuentas frm = Application.OpenForms.OfType<Inventario.FrmSelCuentas>().FirstOrDefault();
            Inventario.FrmSelCuentas form = frm ?? new Inventario.FrmSelCuentas();
            form.ShowDialog(this);
        }

        #region Implementacion de la interfaz ISeleccionar
        public void SeleccionarDato(string codigo)
        {           
            texto.Text = codigo;            
        }
        #endregion   

        private void dgvGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1){
                mostrarGrupo(dgvGrupo.Rows[e.RowIndex].Cells["dgCodigo"].Value.ToString());
            }
        }

        private void mostrarGrupo(string codigo) {
            objGrupo = bllGrupo.buscar(codigo);
            limpiar();
            if (objGrupo != null) {
                txtSigla.Text = objGrupo.sigla;
                txtDescripcion.Text = objGrupo.descripcion;
                cboMetodo.SelectedValue = objGrupo.metodoDep;
                txtValSalvamento.Value = objGrupo.valSalvamento;
                txtVidaUtil.Value = objGrupo.vidaUtil;
                txtActivo.Text = objGrupo.ctaActivo;
                txtCorreccion.Text = objGrupo.ctaCorreccion;
                txtDepreciacion.Text = objGrupo.ctaDepreciacion;
                txtGanancia.Text = objGrupo.ctaGanancia;
                txtGastos.Text = objGrupo.ctaGastos;
                txtMantenimiento.Text = objGrupo.ctaMantenimiento;
                txtPerdida.Text = objGrupo.ctaPerdida;
                txtRevalorizar.Text = objGrupo.ctaRevalorizar;
                lblOperacion.Text = "Editar";
                txtSigla.ReadOnly = true;
                //Buscar Subgrupos 
                cargarSubgrupos(codigo);
            }
        }
        private void cargarSubgrupos(string codigo) {
            lstSubgrupo = bllGrupo.getSubgrupo(codigo);
            dgvSubGrupo.DataSource = lstSubgrupo;
            dgvSubGrupo.Refresh();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (!string.IsNullOrWhiteSpace(txtSigla.Text))
            {
                lblOperacion.Text = "Editar";
                Habilitar();
            }
            else {

                MessageBox.Show("No ha Seleccionado Ningun Grupo para Editar", "Control de Informaión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void lblNuevoSub_Click(object sender, EventArgs e)
        {
            fila = dgvGrupo.CurrentCell.RowIndex;
            if (fila != -1)
            {
                grupoSel = (string)dgvGrupo.Rows[fila].Cells["dgCodigo"].Value;
                FrmSubgrupo frm = new FrmSubgrupo(grupoSel, "Nuevo");
                frm.ShowDialog();
                cargarSubgrupos(grupoSel);
            }
            else {
                MessageBox.Show("Para agregar Subgrupos debe Seleccionar Un Grupo", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dgvSubGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.RowIndex != -1)
            {
                fila = dgvGrupo.CurrentCell.RowIndex;
                grupoSel = (string)dgvGrupo.Rows[fila].Cells["dgCodigo"].Value;
                string subgrupo = dgvSubGrupo.Rows[e.RowIndex].Cells["dsCodigo"].Value.ToString();
                FrmSubgrupo frm = new FrmSubgrupo(subgrupo, "Editar");
                frm.ShowDialog();
                cargarSubgrupos(grupoSel);
            }
        }

    }
}
