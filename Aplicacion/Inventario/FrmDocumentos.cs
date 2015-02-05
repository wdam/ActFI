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
using Aplicacion.Interfaces;
namespace Aplicacion.Inventario
{
    public partial class FrmDocumentos : Form, ISeleccionar
    {
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();
        BLL.CentroCostoBLL bllCentro = new  BLL.CentroCostoBLL();
        BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();

        TextBox textoSel;
                
        ECentroCosto centro;
        ETerceros tercero;

        public FrmDocumentos()
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

        #region Habilitar , Deshabilitar , Limpiar Controles
            
        private void Habilitar (){
            lblBuscar.Enabled = false;            
            lblEditar.Enabled = false;
            lblEliminar.Enabled = false;           
            lblNuevo.Enabled = false;
            lblNuevoDoc.Enabled = false;
            lblPrint.Enabled = false;

            gbGeneral.Enabled = true;
            gbMovimiento.Enabled = true;
            lblCancelar.Enabled = true;
            lblGuardar.Enabled = true;
            txtObservaciones.Enabled = true;
        }

        private void Deshabilitar() {
            lblBuscar.Enabled = true;           
            lblEditar.Enabled = true;
            lblEliminar.Enabled = true;          
            lblNuevo.Enabled = true;
            lblNuevoDoc.Enabled = true;
            lblPrint.Enabled = true;

            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            gbGeneral.Enabled = false;
            gbMovimiento.Enabled = false;
            txtObservaciones.Enabled = false;
        }

        private void limpiar() {
            txtDocumento.Text = "";
            txtDesctipo.Text = "";
            txtDia.Text = "";
            txtCentro.Text = "";
            txtNit.Text = "";
            txtNombreTer.Text = "";
            txtNomCentro.Text = "";
            txtObservaciones.Text = "";
            lblCuenta.Text = "";
            txtNumero.Text = "";          
            txtDiferencia.Text = "0";
            txtCredito.Text = "0";
            txtDebito.Text = "0";
            txtVmto.Text = "0";

            dgvDatos.Rows.Clear();
            txtDia.Text = DateTime.Now.Day.ToString();
            txtNumero.Focus();
            txtPeriodo.Text = BLL.Inicializar.periodo.Substring(3,4) +"-"+BLL.Inicializar.periodo.Substring(0,2)+"-";
        }
        #endregion

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            Habilitar();
            lblOperacion.Text = "Nuevo";
            limpiar();
            txtDocumento_DoubleClick(txtDocumento, null);
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            smsError.Dispose();
            lblOperacion.Text = "Consulta";
        }

        #region Eventos relacionados con la grilla
		  private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox celda = (TextBox)e.Control;
            celda.KeyPress += new KeyPressEventHandler(this.ValidarGrilla);
        }
          // Validar teclas presionadas en la grilla /// 
        private void ValidarGrilla(object sender, KeyPressEventArgs e)
        {
            int columna = dgvDatos.CurrentCell.ColumnIndex;
            switch (columna)
            {

                case 1:  case 2: case 4: 
                    TextBox txt = (TextBox)sender;
                    if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == '.' && txt.Text.Contains(".") == false)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
                case 3: case 5:
                    if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                    {
                        e.KeyChar = Convert.ToChar(0);
                    }
                    break;
                case 6:
                    TextBox txt1 = (TextBox)sender;
                    if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == '/' )
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
            }

        }
        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value != null ){
                            dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value = dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value.ToString().ToUpper();
                        }                        
                        break;
                    case 1:
                        string debito = dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value.ToString();
                        if (debito == "") {                            
                            debito="0";
                        }
                        dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value = Math.Round(Convert.ToDouble(debito), 2);
                        dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value = "0.00";
                        break;
                    case 2:
                       string credito = dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value.ToString();
                       if (credito == "") {
                           credito = "0";
                        }
                       dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value = Math.Round(Convert.ToDouble(credito), 2);
                       dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value = "0.00";
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        try
                        {
                            int dias = Convert.ToInt16(dgvDatos.Rows[e.RowIndex].Cells["dtDvmto"].Value.ToString());                            
                            DateTime fecha = Convert.ToDateTime(txtDia.Text + txtFecha.Text);
                            dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value = fecha.AddDays(dias);
                        }
                        catch (Exception) { }                                                                                                                                                       
                        break;
                    case 6:                       
                        try
                        {
                            DateTime Fecha = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al digitar la fecha de vencimiento, Verifique el formato (DD/MM/AAAA)", "SAE Control de Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value = "00/00/0000";
                        }                        
                        break;

                }
            }
        }

        //private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dgvDatos.Columns[e.ColumnIndex].Name == "dtFecha")
        //    {
        //        formatoFecha(e);
        //    }
        //}

        private static void formatoFecha(DataGridViewCellFormattingEventArgs formato) {
            if (formato.Value != null) {
                StringBuilder dateString = new StringBuilder();
                DateTime fecha = DateTime.Parse(formato.Value.ToString());
                dateString.Append(fecha.Day.ToString());
                dateString.Append("/");               
                dateString.Append(fecha.Month.ToString());
                dateString.Append("/");
                dateString.Append(fecha.Year);
                formato.Value = dateString.ToString();
                formato.FormattingApplied = true;
            }        
        }
	    #endregion
                    
        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            txtFecha.Text = BLL.Inicializar.periodo;
            BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();
            BLL.CuentasBLL bllCuenta = new BLL.CuentasBLL();

            int nAux = bllCuenta.validarAuxiliares();
            List<ETipoDocumento> nTipo = bllTipo.getAll();

            if (nAux <= 0)
            {               
                MessageBox.Show("No se han Creado Cuentas Auxiliares ", "SAE Control ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nTipo.Count <= 0)
            {
                MessageBox.Show("No se han Creado Documentos Contables para los Activos Fijos", "SAE Control ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                lblNuevo.Enabled = true;
                lblBuscar.Enabled = true;
                lblEditar.Enabled = true;
            }
            
        }                

        private void lblPeriodo_Click(object sender, EventArgs e)
        {
            Principal.FrmPeriodo frm = new Principal.FrmPeriodo();
            frm.ShowDialog();
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validarDatos())
            {

            }
            else {
                MessageBox.Show("Datos Incorrectos, Por favor Verifique...", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validarDatos() {
            bool validar = true;
            if (txtDocumento.Text == "") {
                smsError.SetIconAlignment(txtDocumento, ErrorIconAlignment.MiddleLeft);
                smsError.SetError(txtDocumento, "Seleccione un tipo de Documento.");
                validar = false;
            }
            if (txtNumero.Text == "") {
                smsError.SetError(txtNumero, "Ingrese el Numero de Documento... ");
                validar = false;
            }
            if (Convert.ToDouble(txtDiferencia.Text) != 0){
                smsError.SetError(txtDiferencia, "La diferencia No puede ser distinta de Cero(0).. Verifique Items del Documento");
                validar = false;
            }
            if (Convert.ToDouble(txtDebito.Text) == 0) {
                smsError.SetError(txtDebito, "No ha Digitado Ningun Debito, Verifique items del Documento");
                validar = false;
            }
            if (Convert.ToDouble(txtCredito.Text ) == 0){
                smsError.SetError(txtCredito, "No ha Digitado ningun Debito, Veifique los items del Documento");
                validar = false;
            }

            try { // Validar Fecha del Documento          
                DateTime fecha;
                fecha = Convert.ToDateTime(txtDia.Text + txtFecha.Text);
            } catch (Exception ex){
                smsError.SetError(txtFecha, "Error en el formato de la fecha, Verifique el día.");
                validar = false;
            }           

            if (dgvDatos.RowCount <= 1) {                 
                smsError.SetError(lblCuenta, "Ingrese los Items del Documento Contable");                                
                return validar = false;
            }

            for (int i = 0; i < dgvDatos.RowCount-2; i++)
            {
                if (dgvDatos.Rows[i].Cells["dtDescripcion"].Value.ToString() == "")
                {
                    smsError.SetError(lblCuenta, "Falta digitar una descripcion");
                    dgvDatos.Rows[i].Cells["dtDescripcion"].Selected = true;
                    return false;
                }
                if (dgvDatos.Rows[i].Cells["dtCuenta"].Value == null)
                {
                    smsError.SetError(lblCuenta, "Falta digitar una Cuenta");
                    dgvDatos.Rows[i].Cells["dtCuenta"].Selected = true;
                    return false;
                }

                if (Convert.ToDouble(dgvDatos.Rows[i].Cells["dtCredito"].Value) == 0 && Convert.ToDouble(dgvDatos.Rows[i].Cells["dtDebito"].Value) == 0)
                {
                    smsError.SetError(lblCuenta, "Los valores debito y credito no pueden ser ambos iguales a cero(0) en un mismo Item.");
                    dgvDatos.Rows[i].Cells["dtDebito"].Selected = true;
                    return false;
                }

                if (Convert.ToDouble(dgvDatos.Rows[i].Cells["dtCentro"].Value) == 0 && txtCentro.Enabled == true)
                {
                    smsError.SetError(lblCuenta, "Verifique todos los centros de costos");
                    dgvDatos.Rows[i].Cells["dtCentro"].Selected = true;
                    return false;
                }
            }
            
            return validar;
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Editar";
        }
        
        private void txtNit_TextChanged(object sender, EventArgs e)
        {
            tercero = bllTer.buscar(txtNit.Text);
            if (tercero == null)
            {
                txtNombreTer.Text = "";
            }
            else
            {
                txtNit.Text = tercero.nit;
                txtNombreTer.Text = tercero.nombre;
            }
        }

        private void txtCentro_TextChanged(object sender, EventArgs e)
        {
                centro = bllCentro.buscar(txtCentro.Text); 
                if (centro  == null){
                   txtNomCentro.Text= "";
                } else
                {
                    txtNomCentro.Text = centro.Nombre;
                    txtCentro.Text = centro.Codigo;
                }
        }

        #region Implementacion de la Interfaz
        public void SeleccionarDato(string dato)
        {
            textoSel.Text = dato;            
        }        
        #endregion

        private void txtDocumento_DoubleClick(object sender, EventArgs e)
        {
            textoSel = (TextBox)sender;
            FrmTipoDocumento FRM = new FrmTipoDocumento();
            FRM.ShowDialog(this);
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Length >= 2) { 
                
            }
        }

        protected void buscarDocumento(){
            
        }
       
    }
}
