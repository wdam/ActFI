using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Principal;
using Entidades;
using Aplicacion.Interfaces;
using CrystalDecisions.CrystalReports.Engine;


namespace Aplicacion.Inventario
{
    public partial class FrmActivos : Form, ISeleccionar
    {
        TextBox texto;
        List<EParametros> lstParametros;
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CentroCostoBLL bllCentro = new BLL.CentroCostoBLL();
        
        Utilidades util = new Utilidades();
        bool Encontro = false;   // Verificar si encontro datos de un activo
        ETerceros user;
        ECentroCosto centro;
        
        EActivos activo;
         
        public FrmActivos()
        {
            InitializeComponent();
        }

        #region Ocultar / Mostrar Paneles dependiendo de la opcion seleccionada

        private void ocultarPanel1(){
            panelBasicos.Visible = false;
            panelVal.Visible = true;
            panelVal.Width = 780;
            lblColor.Visible = false;
            lblColor1.Visible = true;
            btnTab2.FlatAppearance.BorderSize = 1;
            btnTab1.FlatAppearance.BorderSize = 0;
        }

        private void ocultarPanel2() { 
            panelBasicos.Visible = true;
            panelVal.Visible = false;
            panelVal.Width = 780;
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

        #region Habilitar y Deshabilitar controles

        private void Habilitar()
        {
            panelBasicos.Enabled = true;
            panelVal.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;
            txtCodigo.Enabled = true;
            txtCodResp.Enabled = true;
            cboAreaResp.Enabled = true;

            lblBuscar.Enabled = false;
            lblEditar.Enabled = false;
            lblNuevo.Enabled = false;
            lblpdf.Enabled = false;
         
        }

        private void Deshabilitar()
        {
            panelBasicos.Enabled = false;
            panelVal.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;

            lblBuscar.Enabled = true;
            lblEditar.Enabled = true;
            lblNuevo.Enabled = true;
            lblpdf.Enabled = true;
        }

        private void colocarEnCero()
        {
            foreach (Control texto in gbValores.Controls) {
                if  (texto is TextBox) {
                    texto.Text = "0";
                }
            }
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
        
        private void cargarCuentas() {                       
            if ((lstParametros != null))
            {
                foreach (EParametros item in lstParametros)
                {
                    txtctaActivo.Text = item.ctaActivo;
                    txtctaDepreciacion.Text = item.ctaDepreciacion;
                    txtctaGastos.Text = item.ctaGastos;
                    txtctaMonetaria.Text = item.ctaMonetaria;
                    txtctaDepMonetaria.Text = item.ctaDepMonetaria;
                }
            }
        }

        private void CargarAreas() {
            BLL.AreaBLL  ctrArea = new BLL.AreaBLL();
            List<EArea> Areas = null;
            Areas = ctrArea.getAll();
            if (Areas.Count > 0)
            {
                cboAreaResp.DisplayMember = "nombre";
                cboAreaResp.ValueMember = "codigo";
                cboAreaResp.DataSource = Areas;
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {            
            Deshabilitar();
            ocultarPanel2();
            lblOperacion.Text = "Consulta";
            smsError.Dispose();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            using (Utilidades util = new Utilidades()) {
                util.limpiarControles(this);
            }

            this.smsError.Dispose();
            Habilitar();
            ocultarPanel2();              
            colocarEnCero();
            cargarCuentas();
            lblOperacion.Text = "Nuevo";
        }

        private void FrmActivos_Load(object sender, EventArgs e)
        {
            lstParametros = bllPar.getParametros();
            smsError.Dispose();
            Deshabilitar();
            ocultarPanel2();
            CargarAreas();
        }

        private bool validar() {
            bool bandera = true;
            using (BLL.ValidacionesBLL ctrVal = new BLL.ValidacionesBLL()) {
                if (!ctrVal.esCodigoValido(txtCodigo.Text))
                {
                    smsError.SetError(txtCodigo, "Codigo Incorrecto");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(txtNombre.Text))
                {
                    smsError.SetError(txtNombre, "Ingrese Nombre del Activo");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(txtDescripcion.Text))
                {
                    smsError.SetError(txtDescripcion, "Ingrese Descripcion detallada");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(cboTipo.Text))
                {
                    smsError.SetError(cboTipo, "Seleccione un Tipo");
                    bandera = false;
                }
                
                if (!ctrVal.noEstaVacio(cboAreaResp.SelectedText.ToString()))
                {
                    smsError.SetError(cboAreaResp, "Seleccione el Area Responsable");
                    bandera = false;
                }
                if (!ctrVal.noEstaVacio(txtResponsable.Text))
                {
                    smsError.SetError(txtCodResp, "Ingrese El Responsable");
                    bandera = false;
                }
                if (!ctrVal.noEstaVacio(cboPropiedad.Text))
                {
                    smsError.SetError(cboPropiedad, "Seleccione el tipo de Propiedad");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(txtvidaUtil.Text))
                {
                    smsError.SetError(txtvidaUtil, "Ingrese la Vida Util");
                    bandera = false;
                }

                if(!ctrVal.esValorValido(txtvalComercial.Text)){
                    smsError.SetError(txtvalComercial, "EL Valor Comercial Debe Ser mayor a cero (0)");
                    bandera = false;
                }

                if (!ctrVal.esValorValido(txtvalSalvamento.Text))
                {
                    smsError.SetError(txtvalSalvamento, "EL Valor Salvamento Debe Ser mayor a cero (0)");
                    bandera = false;
                }
                
            }
            return bandera;
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            smsError.Dispose();
            if (validar())
            {
                if (lblOperacion.Text == "Nuevo")
                {
                    guardar();                   
                }
                else if (lblOperacion.Text == "Editar")
                {
                    modificar();                  
                }
            }
            else 
            { 
                MessageBox.Show("Datos Incorrectos .. Verifique", "SAE Control de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Proceso de Guardar y Modificar 
        private void guardar()
        {
            activo = CrearActivo();
            string mensaje = bllAct.insertar(activo);
            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Guardados Correctamente .. !!", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();
                ocultarPanel2();
                lblOperacion.Text = "Consulta";
            }
            else
            {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void modificar()
        {
            activo = CrearActivo();
            string mensaje = bllAct.actualizar(activo);
            if (mensaje == "Exito")
            {
                MessageBox.Show("Datos Actualizados Correctamente .. !!", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();
                ocultarPanel2();
                lblOperacion.Text = "Consulta";
            }
            else
            {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private EActivos CrearActivo()
        {
            EActivos objAct = new EActivos();
            objAct.codigo = txtCodigo.Text;
            objAct.nombre = txtNombre.Text;
            objAct.descripcion = txtDescripcion.Text;
            objAct.numSerie = txtNumSerie.Text;
            objAct.referencia = txtReferencia.Text;
            objAct.tipo = cboTipo.Text;
            objAct.vidaUtil = txtvidaUtil.Text;

            objAct.propiedad = cboPropiedad.Text;
            objAct.fecha = dtpFecha.Value;
            objAct.area = cboAreaResp.SelectedValue.ToString();
            objAct.responsable = txtCodResp.Text;
            objAct.proveedor = txtcodProveedor.Text;
            objAct.centrocosto = txtcentro.Text;
            objAct.estado = "Activo";

            objAct.valComercial = Convert.ToDouble(txtvalComercial.Text);
            objAct.valSalvamento = Convert.ToDouble(txtvalSalvamento.Text);
            objAct.valHistorico = Convert.ToDouble(txtvalHistorico.Text);
            objAct.valLibros = Convert.ToDouble(txtvalLibros.Text);
            objAct.valMejoras = Convert.ToDouble(txtvalMejoras.Text);
            objAct.depAjustada = Convert.ToDouble(txtdepAjustada.Text);
            objAct.depAcumulada = Convert.ToDouble(txtdepAcumulada.Text);

            objAct.ctaActivo = txtctaActivo.Text;
            objAct.ctaDepreciacion = txtctaDepreciacion.Text;
            objAct.ctaGastos = txtctaGastos.Text;
            objAct.ctaMonetaria = txtctaMonetaria.Text;
            objAct.ctaDepMonetaria = txtctaDepMonetaria.Text;

            return objAct;
        }

        #endregion  
                    
        private void lblBuscar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Consulta";
            FrmSelActivos frm = new FrmSelActivos();
            frm.ShowDialog(this);
        }

        private void txtvalComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            util.ValidarNumero(sender, e);
        }

        private void FrmActivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            util.Dispose();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                lblOperacion.Text = "Editar";
                Habilitar();
                txtCodigo.Enabled = false;
                txtCodResp.Enabled = false;
                cboAreaResp.Enabled = false;
            }
            else {
                MessageBox.Show("Debe Seleccionar un Activo.. ", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private  void mostrarDatos(){
            Encontro = false;
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text)){
                activo = bllAct.buscar(txtCodigo.Text);
                if (activo != null) {
                    txtNombre.Text = activo.nombre;
                    txtNumSerie.Text = activo.numSerie;
                    txtReferencia.Text = activo.referencia;
                    txtDescripcion.Text = activo.descripcion;
                    txtvidaUtil.Text = activo.vidaUtil;
                    cboTipo.Text = activo.tipo;

                    cboPropiedad.Text = activo.propiedad;
                    dtpFecha.Value = activo.fecha;
                    txtcodProveedor.Text = activo.proveedor;
                    txtcentro.Text = activo.centrocosto;
                    cboAreaResp.SelectedValue = activo.area;
                    txtCodResp.Text = activo.responsable;

                    txtvalComercial.Text = activo.valComercial.ToString();
                    txtvalHistorico.Text = activo.valHistorico.ToString();
                    txtvalLibros.Text = activo.valLibros.ToString();
                    txtvalMejoras.Text = activo.valMejoras.ToString();
                    txtvalSalvamento.Text = activo.valSalvamento.ToString();
                    txtdepAcumulada.Text = activo.depAcumulada.ToString();
                    txtdepAjustada.Text = activo.depAjustada.ToString();

                    txtctaActivo.Text = activo.ctaActivo;
                    txtctaDepMonetaria.Text = activo.ctaDepMonetaria;
                    txtctaDepreciacion.Text = activo.ctaDepreciacion;
                    txtctaGastos.Text = activo.ctaGastos;
                    txtctaMonetaria.Text = activo.ctaMonetaria;
                    Encontro = true;
                }
            }   

        }

        private void txtcentro_TextChanged(object sender, EventArgs e)
        {
            centro = bllCentro.buscar(txtcentro.Text); 
                if (centro  == null){
                   txtcentroNom.Text= "";
                } else
                {
                    txtcentroNom.Text = centro.Nombre;
                    txtcentro.Text = centro.Codigo;
                }
        }

        private void txtcodProveedor_TextChanged(object sender, EventArgs e)
        {
            ETerceros tercero = bllTer.buscar(txtcodProveedor.Text);
            if (tercero == null)
            {
                txtProveedor.Text = "";
            }
            else { 
                txtcodProveedor.Text =  tercero.nit;
                txtProveedor.Text = tercero.nombre;
            }

        }

        #region Implementacion de la interfaz ISeleccionar

        public void SeleccionarDato(string codigo)
        {
            if (lblOperacion.Text == "Consulta")
            {
                txtCodigo.Text = codigo;
            }
            else {
                texto.Text = codigo;
            }
        }
    
        #endregion        

        private void txtcodProveedor_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelTercero Frm = new FrmSelTercero();            
            Frm.tipo = "PROVEEDOR";
            Frm.ShowDialog(this);          
        }
        
        private void txtcentro_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelCentroCostos frm = new FrmSelCentroCostos();
            frm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }    

        private void formCuenta(object sender, EventArgs e)
        {
             texto= (TextBox)sender;
             FrmSelCuentas frm = Application.OpenForms.OfType<FrmSelCuentas>().FirstOrDefault();
             FrmSelCuentas form = frm ?? new FrmSelCuentas();
             form.ShowDialog(this);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta") {
                mostrarDatos();
            }
        }

        private void lblpdf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && lblOperacion.Text == "Consulta")
            {
                List<EActivos> lst = new List<EActivos>();
                lst.Add(bllAct.buscar(txtCodigo.Text));
                BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
                ECompany objC = bllComp.buscar();

                Informes.FrmVerInforme frm = new Informes.FrmVerInforme();                
                ReportDocument reporte = new ReportDocument();
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\infActivo.rpt";
                reporte.Load(ruta);
                reporte.SetDataSource(lst);
                // Asignacion de Parametros 
                reporte.SetParameterValue("comp", objC.descripcion);
                reporte.SetParameterValue("nit", objC.nit);
                reporte.SetParameterValue("periodo", "Periodo Actual: 07 / 2014");
                
                frm.CReporte.ReportSource = reporte;
                frm.CReporte.Refresh();
                frm.ShowDialog();
            }
            else {
                MessageBox.Show("Seleccione El Activo", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Nuevo") {
                mostrarDatos();
                if (Encontro) {
                    lblOperacion.Text = "Editar";
                }
            }            
        }

        private void cboAreaResp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtCodResp_TextChanged(object sender, EventArgs e)
        {
            user  = bllTer.buscar(txtCodResp.Text);
            if (user == null)
            {
                txtResponsable.Text = "";
            }
            else
            {
                txtCodResp.Text = user.nit;
                txtResponsable.Text = user.nombre;
            }
        }

        private void txtCodResp_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelTercero Frm = new FrmSelTercero();
            Frm.tipo = "Empleados";
            Frm.ShowDialog(this);
        }        
    }
}
