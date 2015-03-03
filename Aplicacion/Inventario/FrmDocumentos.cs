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
        BLL.CuentasBLL bllCuenta = new BLL.CuentasBLL();
        BLL.DocumentosBLL bllDoc = new BLL.DocumentosBLL();

        TextBox textoSel;
        List<EDocumentos> lstDocumentos;                
        ECentroCosto objCentro;
        ETerceros tercero;
        ETipoDocumento tipodoc;
        ECuentas objCuenta;        

        double debito = 0;
        double credito = 0;
        bool busGrilla = false;
        int fila, FinEdit, columna;        

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
            if (lblOperacion.Text == "Editar")
            {
                txtDocumento.ReadOnly = true;
                txtNumero.ReadOnly = true;
            }
            else {
                txtDocumento.ReadOnly = false;
                txtNumero.ReadOnly = false;
            }
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
            txtCredito.Text = "0,00"; 
            txtDebito.Text = "0,00";
            txtDiferencia.Text = "0,00"; 
            txtVmto.Text = "0";            
            dgvDatos.Rows.Clear();
            txtDia.Text = DateTime.Now.Day.ToString();
            txtFecha.Text = BLL.Inicializar.periodo;                        
            txtPeriodo.Text = BLL.Inicializar.periodo.Substring(3,4) +"-"+BLL.Inicializar.periodo.Substring(0,2)+"-";
            txtNumero.Focus();            
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

        #region Eventos y Procedimientos Relacionados con la grilla

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
                    if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == ',' && txt.Text.Contains(",") == false)
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
            busGrilla = false;           
            if (e.RowIndex >= 0) {                
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value != null ){
                            dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value = dgvDatos.Rows[e.RowIndex].Cells["dtDescripcion"].Value.ToString().ToUpper();
                        }                        
                        break;
                    case 1:                       
                        string sdebito = (string)dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value ?? "0";
                        if (string.IsNullOrEmpty(sdebito) || sdebito == ",") {                            
                            sdebito="0";
                        }
                        dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value = UtilSystem.fMoneda(Math.Round(Convert.ToDouble(sdebito), 2));
                        if (Convert.ToDouble(sdebito) > 0) {
                            dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value = "0,00";
                            SendKeys.Send("{TAB}");    
                        }                        
                        break;
                    case 2:
                        string scredito = (string)dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value;
                       if (string.IsNullOrEmpty(scredito) || scredito == ","){
                           scredito = "0";
                        }
                       dgvDatos.Rows[e.RowIndex].Cells["dtCredito"].Value = UtilSystem.fMoneda(Math.Round(Convert.ToDouble(scredito), 2));                    
                        if (Convert.ToDouble(scredito) > 0) {
                           dgvDatos.Rows[e.RowIndex].Cells["dtDebito"].Value = "0,00";                       
                       }                       
                        break;
                    case 3:
                        busGrilla = true;
                        if (dgvDatos.Rows[e.RowIndex].Cells["dtCuenta"].Value != null)
                        {                           
                            buscarCuenta(dgvDatos.Rows[e.RowIndex].Cells["dtCuenta"].Value.ToString());
                        }
                        else {
                            FrmSelCuentas frmSC = new FrmSelCuentas();
                            frmSC.ShowDialog(this);
                        }                                            
                        break;
                    case 4:
                        string sBase = (string)dgvDatos.Rows[e.RowIndex].Cells["dtBase"].Value;
                        if (string.IsNullOrEmpty(sBase) || sBase == ","){
                            sBase = "0";
                        }
                        dgvDatos.Rows[e.RowIndex].Cells["dtBase"].Value = UtilSystem.fMoneda(Math.Round(Convert.ToDouble(sBase), 2));                        
                        break;
                    case 5:
                       
                            string sDias = (string)dgvDatos.Rows[e.RowIndex].Cells["dtDvmto"].Value ?? "0";
                            if (string.IsNullOrEmpty(sDias)) {
                                sDias = "0";
                            }
                            int dias = Convert.ToInt16(sDias);                            
                            DateTime fecha = Convert.ToDateTime(txtDia.Text + txtFecha.Text);
                            dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value = fecha.AddDays(dias).ToShortDateString();
                            MessageBox.Show(dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value.ToString());                                                                                                                                                                          
                        break;
                    case 6:                       
                        try {
                            DateTime Fecha = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value.ToString());
                        } catch (Exception){
                            MessageBox.Show("Error al digitar la fecha de vencimiento, Verifique el formato (DD/MM/AAAA)", "SAE Control de Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDatos.Rows[e.RowIndex].Cells["dtFecha"].Value = "00/00/0000";
                        }                        
                        break;
                    case 7:
                        busGrilla = true;
                        if (dgvDatos.Rows[e.RowIndex].Cells["dtNit"].Value != null) {
                            buscarNit(dgvDatos.Rows[e.RowIndex].Cells["dtNit"].Value.ToString());
                        }
                        else {
                            FrmSelTercero frmT = new FrmSelTercero();
                            frmT.tipo = "PROVEEDOR";
                            frmT.ShowDialog(this);
                        }                          
                        break;
                    case 8:
                        busGrilla = true;
                        if (dgvDatos.Rows[e.RowIndex].Cells["dtCentro"].Value != null) {
                            buscarCCosto(dgvDatos.Rows[e.RowIndex].Cells["dtCentro"].Value.ToString());
                        }
                        else {
                            FrmSelCentroCostos frmSCC = new FrmSelCentroCostos();
                            frmSCC.ShowDialog(this);
                        }                        
                        break;  

                }
            }
            sacarCuenta();           
        }

        private void sacarCuenta() {
            debito = dgvDatos.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["dtDebito"].Value));
            credito = dgvDatos.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["dtCredito"].Value));
            txtDebito.Text = UtilSystem.fMoneda(debito);
            txtCredito.Text = UtilSystem.fMoneda(credito);
        }

        private void dgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
            smsError.Dispose();
            if (txtCentro.Enabled == false){
                dgvDatos.Rows[e.RowIndex].Cells["dtCentro"].ReadOnly = true;
            }
            valoresporDefecto(e.RowIndex);
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblOperacion.Text != "Nuevo" && lblOperacion.Text != "Editar")
                return;
            
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (fila == dgvDatos.Rows.Count-1) {
                    return;
                }
                DialogResult resul;
                resul = MessageBox.Show("Toda la fila será retirada, ¿Desea Quitarla?", "Control de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    dgvDatos.Rows.RemoveAt(fila);
                }
                return;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dgvDatos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (FinEdit == 1 && e.ColumnIndex != 8){
                FinEdit = 0;
                if (e.ColumnIndex == 7 && txtCentro.Enabled == false)
                {
                    SendKeys.Send("{HOME}");
                }
                else {
                    SendKeys.Send("{TAB}");        
                }
                e.Cancel = true;  
            }
        }

        private void buscarCuenta(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                FrmSelCuentas frmSC = new FrmSelCuentas();
                frmSC.ShowDialog(this);
            }
            else
            {
                objCuenta = bllCuenta.buscar(codigo, "Auxiliar");
                if (objCuenta == null)
                {
                    FrmSelCuentas frmSC = new FrmSelCuentas();
                    frmSC.ShowDialog(this);
                }
            }
        }

        private void buscarCCosto(string centro) {
            if (string.IsNullOrWhiteSpace(centro))
            {
                FrmSelCentroCostos frmSCC = new FrmSelCentroCostos();
                frmSCC.ShowDialog(this);
            }
            else {
                objCentro = bllCentro.buscar(centro);
                if (objCentro == null)
                {
                    FrmSelCentroCostos frmSCC = new FrmSelCentroCostos();
                    frmSCC.ShowDialog(this);
                }               
            }
        }

        private void  buscarNit(string nit){
            if (string.IsNullOrWhiteSpace(nit))
            {
                FrmSelTercero frmST = new FrmSelTercero();
                frmST.tipo = "PROVEEDOR";
                frmST.ShowDialog(this);
            }
            else {
                tercero = bllTer.buscar(nit);
                if (tercero == null)
                {
                    DialogResult result;
                    result  = MessageBox.Show("El Nit / Cedula "+ nit + " del tercero no existe en los registros, ¿Desea Agregarlos? ",
                        "Control de Información ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmTerceros frmT = new FrmTerceros();
                        frmT.ShowDialog();
                    }                   
                }
            }
        }

        private void dgvDatos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            FinEdit = 1;
        }
             
        private void valoresporDefecto(int fila) {
            if (dgvDatos.Rows[fila].Cells["dtNit"].Value == null &&  txtNombreTer.Text != "") {
                dgvDatos.Rows[fila].Cells["dtNit"].Value = txtNit.Text;
            }
            if (dgvDatos.Rows[fila].Cells["dtDebito"].Value == null){
                dgvDatos.Rows[fila].Cells["dtDebito"].Value = "0,00";
            }

            if (dgvDatos.Rows[fila].Cells["dtCredito"].Value == null){
                dgvDatos.Rows[fila].Cells["dtCredito"].Value = "0,00";
            }
            if (dgvDatos.Rows[fila].Cells["dtBase"].Value == null) {
                dgvDatos.Rows[fila].Cells["dtBase"].Value = "0,00";
            }
            
            if (dgvDatos.Rows[fila].Cells["dtCentro"].Value == null && txtNomCentro.Text != "" && txtCentro.Enabled == true) {
                dgvDatos.Rows[fila].Cells["dtCentro"].Value = txtCentro.Text;
            }
            DateTime fecha = Convert.ToDateTime(txtDia.Text + txtFecha.Text);            
            if (dgvDatos.Rows[fila].Cells["dtDvmto"].Value == null) {
                dgvDatos.Rows[fila].Cells["dtDvmto"].Value = txtVmto.Text;
                dgvDatos.Rows[fila].Cells["dtFecha"].Value = fecha.AddDays(Convert.ToInt16(txtVmto.Text));
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
            lblPeriodo.Text = BLL.Inicializar.Mes;
            txtFecha.Text = BLL.Inicializar.periodo;
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
            BLL.GenericaBLL bllGen = new BLL.GenericaBLL();
            if (bllGen.verificarCCosto())
            {
                txtCentro.Enabled = true;
            }
            else {
                txtCentro.Enabled = false;
            }            
        }                

        private void lblPeriodo_Click(object sender, EventArgs e)
        {
            Principal.FrmPeriodo frm = new Principal.FrmPeriodo();
            frm.ShowDialog();
            if (lblOperacion.Text == "Nuevo" || lblOperacion.Text == "Editar") {
                txtFecha.Text = BLL.Inicializar.periodo;
                txtPeriodo.Text = BLL.Inicializar.periodo.Substring(3, 4) + "-" + BLL.Inicializar.periodo.Substring(0, 2) + "-";               
                buscarTipoDocumento();
            }
            lblPeriodo.Text = BLL.Inicializar.Mes;
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validarDatos())
            {
                if (lblOperacion.Text == "Nuevo"){
                    lstDocumentos = bllDoc.buscarDocumento(Convert.ToInt32(txtNumero.Text.Trim()), txtDocumento.Text);
                    if (lstDocumentos.Count > 0)
                    {
                        txtNumero.Text = UtilSystem.fConsecutivo(Convert.ToInt32(txtNumero.Text) + 1);
                    }
                    bllTipo.updateConsecutivo(Convert.ToInt32(txtNumero.Text), txtDocumento.Text);      
                }
                else {
                    bllDoc.modificarCuentas(Convert.ToInt32(txtNumero.Text), txtDocumento.Text);
                    bllDoc.eliminarDocumento(Convert.ToInt32(txtNumero.Text), txtDocumento.Text);
                }

                guardar();
                guardarObservacion();
                MessageBox.Show("Datos Guardados Correctamente.. ", "Control de Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblOperacion.Text = "Consulta";
                Deshabilitar();
            }
            else {
                MessageBox.Show("Datos Incorrectos, Por favor Verifique...", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guardar()
        {
            int cont = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                // Crear Objeto de tipo Documento
                if (!item.IsNewRow)
                {
                    cont++;
                    EDocumentos ObjDoc = new EDocumentos();
                    ObjDoc.item = cont;
                    ObjDoc.documento = Convert.ToInt32(txtNumero.Text);
                    ObjDoc.tipo = txtDocumento.Text.Trim();
                    ObjDoc.periodo = BLL.Inicializar.periodo;
                    ObjDoc.dia = txtDia.Text;
                    ObjDoc.centro = (string)item.Cells["dtCentro"].Value ?? "0";
                    ObjDoc.descripcion = UtilSystem.truncarCadena(item.Cells["dtDescripcion"].Value.ToString(), 50);
                    ObjDoc.debito = UtilSystem.DIN(item.Cells["dtDebito"].Value.ToString() ?? "0");
                    ObjDoc.credito = UtilSystem.DIN(item.Cells["dtCredito"].Value.ToString() ?? "0");
                    ObjDoc.codigo = item.Cells["dtCuenta"].Value.ToString();
                    ObjDoc.baseD = UtilSystem.DIN(item.Cells["dtBase"].Value.ToString() ?? "0");
                    ObjDoc.diasv = Convert.ToInt16(item.Cells["dtDvmto"].Value);
                    ObjDoc.fecha = UtilSystem.truncarCadena(item.Cells["dtFecha"].Value.ToString(), 10);
                    ObjDoc.cheque = (string)item.Cells["dtCheque"].Value ?? "";
                    ObjDoc.nit = (string)item.Cells["dtNit"].Value ?? "0";
                    ObjDoc.modulo = "Contabilidad AF";

                    bllDoc.insertar(ObjDoc);
                }
            }
        }

        private void guardarObservacion() {
            if (string.IsNullOrWhiteSpace(txtObservaciones.Text)) {
                return;
            }
            bllDoc.insertObservacion(Convert.ToInt32(txtNumero.Text), txtDocumento.Text, txtObservaciones.Text);
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

            if (txtNombreTer.Text == "" || txtNit.Text =="") {
                smsError.SetIconAlignment(txtNit, ErrorIconAlignment.MiddleLeft);
                smsError.SetError(txtNit, "Ingrese el Nit del Tercero ");
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

            for (int i = 0; i < dgvDatos.Rows.Count - 1; i++)
            {                                              
                if (dgvDatos.Rows[i].Cells["dtDescripcion"].Value == null)
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

                if (dgvDatos.Rows[i].Cells["dtCentro"].Value.ToString() == "0" && txtCentro.Enabled == true)
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
            if (txtDocumento.Text == "" || txtNit.Text == "")
            {
                MessageBox.Show("No ha Seleccionado ningun documento contable ", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                lblOperacion.Text = "Editar";
                Habilitar();
            }                        
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
                dgvDatos.Focus();
            }
        }

        private void txtCentro_TextChanged(object sender, EventArgs e)
        {
                objCentro = bllCentro.buscar(txtCentro.Text);
                if (objCentro == null)
                {
                   txtNomCentro.Text= "";
                } else
                {
                    txtNomCentro.Text = objCentro.Nombre;
                    txtCentro.Text = objCentro.Codigo;
                }
        }

        #region Implementacion de la Interfaz
        public void SeleccionarDato(string dato)
        {
            if (busGrilla  && fila >= 0)
            {
                switch (columna)
                {
                    case 3:
                        dgvDatos.Rows[fila].Cells["dtCuenta"].Value = dato;
                        break;
                    case 7:
                        dgvDatos.Rows[fila].Cells["dtNit"].Value = dato;
                        break;
                    case 8:
                        dgvDatos.Rows[fila].Cells["dtCentro"].Value = dato;                        
                        break;
                }
            }
            else {
                if (lblOperacion.Text == "Consulta") {
                    string[] aux = dato.Split('-');
                    //txtDocumento.Text = aux[0];
                    //txtNumero.Text = aux[1];
                    mostrarDocumento(aux[1], aux[0]);
                    
                }
                else {
                    textoSel.Text = dato;
                }                            
            }            
        }        
        #endregion

        private void txtDocumento_DoubleClick(object sender, EventArgs e)
        {
            busGrilla = false;
            textoSel = (TextBox)sender;
            FrmTipoDocumento FRM = new FrmTipoDocumento();
            FRM.ShowDialog(this);
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {                
            if (txtDocumento.Text.Length >= 2)
            {
                buscarTipoDocumento();
            }
            else {
                txtDesctipo.Text = "";
                txtNumero.Text = "";
            }
        }     

        protected void buscarTipoDocumento(){
            if (txtDocumento.Text == "")
            {
                if (lblOperacion.Text == "Nuevo" || lblOperacion.Text == "Editar") {
                    txtDocumento_DoubleClick(txtDocumento, null);
                }
            }
            else
            {
                tipodoc = bllTipo.buscarTipo(txtDocumento.Text);
                if (tipodoc == null)
                {
                    txtDesctipo.Text = "";
                    txtNumero.Text = "";
                    txtDocumento_DoubleClick(txtDocumento, null);                   
                }
                else {
                    txtDesctipo.Text = tipodoc.descripcion;
                    if (lblOperacion.Text == "Nuevo") {
                        txtNumero.Text = UtilSystem.fConsecutivo(tipodoc.actual);  
                    }
                }
            }
        }

        private void txtNit_DoubleClick(object sender, EventArgs e)
        {
            busGrilla = false;
            textoSel = (TextBox)sender;
            FrmSelTercero Frm = new FrmSelTercero();            
            Frm.tipo = "PROVEEDOR";
            Frm.ShowDialog(this);
        }

        private void txtDebito_TextChanged(object sender, EventArgs e)
        {
            txtDiferencia.Text = UtilSystem.fMoneda(debito - credito);
        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            txtDiferencia.Text = UtilSystem.fMoneda(debito - credito);
        }

        private void txtVmto_Leave(object sender, EventArgs e)
        {
            if (txtVmto.Text == "") {
                txtVmto.Text = "0";               
            }
        }

        private void txtDia_Leave(object sender, EventArgs e)
        {
            if (txtDia.Text == "") {
                txtDia.Text = DateTime.Now.Day.ToString();
            }
        }

        private void txtDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (Char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCentro_DoubleClick(object sender, EventArgs e)
        {
            busGrilla = false;
            textoSel = (TextBox)sender;
            FrmSelCentroCostos frmCC = new FrmSelCentroCostos();
            frmCC.ShowDialog(this);
        }

        private void lblBuscar_Click(object sender, EventArgs e) {
            busGrilla = false;
            lblOperacion.Text = "Consulta";
            textoSel = (TextBox)txtDocumento;
            FrmSelDocumentos frmDoc = new FrmSelDocumentos();
            frmDoc.ShowDialog(this);            
        }

        private void mostrarDocumento( string numero, string tipo) {
            dgvDatos.AutoGenerateColumns = false;
            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(numero)) {
                return;
            }
            limpiar();
            lstDocumentos = bllDoc.buscarDocumento(Convert.ToInt32(numero), tipo);
            if (lstDocumentos.Count > 0)
            {
                txtNumero.Text =UtilSystem.fConsecutivo(lstDocumentos[0].documento);
                txtDocumento.Text = lstDocumentos[0].tipo;
                txtNit.Text = lstDocumentos[0].nit;
                txtDia.Text = lstDocumentos[0].dia;
                txtVmto.Text = lstDocumentos[0].diasv.ToString();
                lblModulo.Text = lstDocumentos[0].modulo;
                txtCentro.Text = lstDocumentos[0].centro;                            
                foreach (EDocumentos item in lstDocumentos)
                {
                    dgvDatos.Rows.Add(item.descripcion, item.debito, item.credito, item.codigo, item.baseD,
                        item.diasv, item.fecha,item.nit, item.centro, item.cheque);
                }
                txtObservaciones.Text = bllDoc.getObservacion(numero, tipo);
                sacarCuenta();
            }
            else {
                MessageBox.Show("El documento no se encuentra en este Periodo ", "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
            
        }
    }
}
