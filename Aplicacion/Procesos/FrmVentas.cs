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

namespace Aplicacion.Procesos
{
    public partial class FrmVentas : Form , ISeleccionar
    {

        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.DocumentosBLL bllDoc = new BLL.DocumentosBLL();
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();
       

        EActivos activo;
        EParametros objParametros;
        ETipoDocumento objTipodoc;
        string tipoDoc = ""; // Tipo de Documento Contable 

       
        public FrmVentas()
        {
            InitializeComponent();
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

        #region Habilitar, Deshabilitar, limpiar controles

        protected void habilitatar() {
            gbDatos.Enabled = true;
            gbVenta.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            lblNuevo.Enabled = false;
            lblpdf.Enabled = false;
            lblOperacion.Text = "Nuevo";
        }

        protected void Deshabilitar() {
            gbDatos.Enabled = false;
            gbVenta.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;
            lblNuevo.Enabled = true;
            lblpdf.Enabled = true;
            lblOperacion.Text = "Consulta";
        }

        protected void limpiar() {
            txtDescripcion.Text = "";
            txtValCompra.Text = "0";
            txtValLibros.Text = "0";
            txtValVenta.Text = "";
            txtDepreciacion.Text = "0";
            txtCodigo.Text = "";
        }
        #endregion
    
        #region Implementacion de la Interfaz ISeleccionar
        public void SeleccionarDato(string dato)
        {
            txtCodigo.Text = dato;
        }

        public void SeleccionarDato(string dato, string descripcion)
        {
            throw new NotImplementedException();
        }
        #endregion
       
        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

       
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            objParametros = bllPar.getParametros();
            if (objParametros != null)
            {
                if (!string.IsNullOrEmpty(objParametros.ventas)) {

                    if (string.IsNullOrEmpty(objParametros.ctaCaja)) {
                        MessageBox.Show("No se ha Parametrizado la cuenta de Caja.. ","Control de Informacion.. ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblNuevo.Enabled = false;
                        return;
                    }
                    tipoDoc = objParametros.depreciacion;
                    Consecutivo();
                }
                else {                    
                    MessageBox.Show("No se ha Selecciondo el Documento Contable para Ventas.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblNuevo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se ha Selecciondo el Documento Contable para Ventas.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Consecutivo()
        {
            objTipodoc = bllTipo.buscarTipo(tipoDoc);
            if (objTipodoc == null)
            {
                txtNumero.Text = "";
            }
            else
            {
                txtNumero.Text = UtilSystem.fConsecutivo(objTipodoc.actual);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Consulta";
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                buscarActivo();
            }
            else {
                Aplicacion.Inventario.FrmSelActivos frm = new Inventario.FrmSelActivos();
                frm.ShowDialog(this);
            }
        }

        protected void buscarActivo() {
          if(!string.IsNullOrWhiteSpace(txtCodigo.Text)){            
            activo = bllAct.buscar(txtCodigo.Text);
            if (activo != null)
            {
                txtDescripcion.Text = activo.descripcion.ToString();
                txtValCompra.Text = UtilSystem.fMoneda(activo.valComercial);
                txtValLibros.Text = UtilSystem.fMoneda(activo.valLibros);
                txtDepreciacion.Text = UtilSystem.fMoneda(activo.depAcumulada);
                lblCtaActivo.Text = activo.ctaActivo;
                lblCtaDepreciacion.Text = activo.ctaDepreciacion;
            }
            else {
                MessageBox.Show("El Activo no Se Encuentra registrado Verifique.. !!", "Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiar();
                Aplicacion.Inventario.FrmSelActivos frm = new Inventario.FrmSelActivos();
                frm.ShowDialog();
            }
          }
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            habilitatar();
            limpiar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta") {
                buscarActivo();
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
        }

        private void txtValVenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValVenta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtValVenta.Text)) {                
                txtUtilidad.Text = UtilSystem.fMoneda(Convert.ToDouble(txtValVenta.Text) - Convert.ToDouble(txtValLibros.Text));
            }
            else
            {
                txtUtilidad.Text = "";
            }
        }

        private void txtUtilidad_TextChanged(object sender, EventArgs e)
        {
            if(txtUtilidad.Text != ""){
                double valUtil = Convert.ToDouble(txtUtilidad.Text);
                if (valUtil >= 0)
                {
                    txtUtilidad.ForeColor = Color.ForestGreen;
                }
                else {
                    txtUtilidad.ForeColor = Color.Crimson;
                }
            }
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardar();
                Deshabilitar();
            }
            else {
                MessageBox.Show("Datos Incorrectos. Verifique", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        /// <summary>
        ///  Movimiento Contable
        /// </summary>
        /// <param name="tipo">Tipo de Operacion</param>
        /// <param name="cuenta">Cuenta Contable</param>
        /// <param name="Descripcion">Descripcion del Movimiento</param>
        /// <param name="nit">Nit quien realiza el movimiento</param>
        private void MovimientoContable(string tipo, string cuenta, string Descripcion, string nit) {
            if (string.IsNullOrWhiteSpace(cuenta))
                return;

            dgvContable.Rows.Add(cuenta, "0", "0", Descripcion, nit);
            int fila = dgvContable.Rows.Count - 1;
            switch (tipo)
            {   
                case "Ganancia":
                    dgvContable.Rows[fila].Cells["dtDebito"].Value = 0;
                    dgvContable.Rows[fila].Cells["dtCredito"].Value = Convert.ToDouble(txtUtilidad.Text);
                    break;
                case "Articulo":
                    dgvContable.Rows[fila].Cells["dtDebito"].Value = 0;
                    dgvContable.Rows[fila].Cells["dtCredito"].Value = Convert.ToDouble(txtValCompra.Text);
                    break;
                    
                case "Caja":
                    dgvContable.Rows[fila].Cells["dtDebito"].Value = Convert.ToDouble(txtValVenta.Text);
                    dgvContable.Rows[fila].Cells["dtCredito"].Value = 0;
                    break;                
                case "Perdida":
                    dgvContable.Rows[fila].Cells["dtDebito"].Value = Math.Abs(Convert.ToDouble(txtUtilidad.Text));
                    dgvContable.Rows[fila].Cells["dtCredito"].Value = 0;
                    break;
                case "Depreciacion":
                    dgvContable.Rows[fila].Cells["dtDebito"].Value = Convert.ToDouble(txtDepreciacion.Text);
                    dgvContable.Rows[fila].Cells["dtCredito"].Value = 0;
                    break;
            }            
        }

        private bool validar() {
            bool correcto = true;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)){
                smsError.SetError(lblBuscar, "Ingrese el Codigo del Articulo");
                correcto = false;                
            }

            if (string.IsNullOrWhiteSpace(txtValVenta.Text) || txtValVenta.Text == "0") {
                smsError.SetError(txtValVenta, "Ingrese el Valor de Venta");
                correcto = false;
            }
            return correcto;
        }

        private void guardar()
        {
            dgvContable.Rows.Clear();
            MovimientoContable("Caja", objParametros.ctaCaja, "VENTA DE ACTIVO " + txtCodigo.Text, "0");
            MovimientoContable("Depreciacion", activo.ctaDepreciacion, "DEPRECIACION  ACUMULADA", "0");
            MovimientoContable("Articulo", activo.ctaActivo, "VALOR ADQUISICION", "0");
            if (Convert.ToDouble(txtUtilidad.Text) > 0) {
                MovimientoContable("Ganancia", activo.ctaGanancia, "UTILIDAD POR VENTA", "0");
            }
            else {
                MovimientoContable("Perdida", activo.ctaPerdida, "PERDIDA POR VENTA", "0");
            }

            int valCons = bllDoc.verificar(Convert.ToInt32(txtNumero.Text.Trim()), tipoDoc);
            if (valCons > 0)
            {
                txtNumero.Text = UtilSystem.fConsecutivo(Convert.ToInt32(txtNumero.Text) + 1);
            }
            bllTipo.updateConsecutivo(Convert.ToInt32(txtNumero.Text), tipoDoc); 

            int cont = 0;
            foreach (DataGridViewRow item in dgvContable.Rows)
            {
                // Crear Objeto de tipo Documento                
                    cont++;
                    EDocumentos ObjDoc = new EDocumentos();
                    ObjDoc.item = cont;
                    ObjDoc.documento = Convert.ToInt32(txtNumero.Text);
                    ObjDoc.tipo = tipoDoc;
                    ObjDoc.periodo = BLL.Inicializar.Mes;
                    ObjDoc.dia = DateTime.Now.Day.ToString();
                    ObjDoc.centro = "0";
                    ObjDoc.descripcion = UtilSystem.truncarCadena(item.Cells["dtDescripcion"].Value.ToString(), 50);
                    ObjDoc.debito = UtilSystem.DIN(item.Cells["dtDebito"].Value.ToString() ?? "0");
                    ObjDoc.credito = UtilSystem.DIN(item.Cells["dtCredito"].Value.ToString() ?? "0");
                    ObjDoc.codigo = item.Cells["dtCuenta"].Value.ToString();
                    ObjDoc.baseD =0;
                    ObjDoc.diasv = 0;
                    ObjDoc.fecha = dtpFecha.Value.ToString("d"); 
                    ObjDoc.cheque = "";
                    ObjDoc.nit = (string)item.Cells["dtNit"].Value ?? "0";
                    ObjDoc.modulo = "Venta AF";                    
                    bllDoc.insertar(ObjDoc);                
            }
        }

        private void txtValVenta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValVenta.Text))
            {
                txtValVenta.Text = "0";
            }
            txtValVenta.Text = UtilSystem.fMoneda(Convert.ToDouble(txtValVenta.Text));
            
        }       
    }
}
