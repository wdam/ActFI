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
using Aplicacion.Principal;
using CrystalDecisions.CrystalReports.Engine;


namespace Aplicacion.Inventario
{
    public partial class FrmActivos : Form, ISeleccionar
    {
        TextBox texto;
        EParametros objParametros;
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CentroCostoBLL bllCentro = new BLL.CentroCostoBLL();
                
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
                    texto.Text = "0,00";
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

        #region Implementacion de la interfaz ISeleccionar

        public void SeleccionarDato(string codigo)
        {
            if (lblOperacion.Text == "Consulta")
            {
                txtCodigo.Text = codigo;
            }
            else
            {
                texto.Text = codigo;
            }
        }      

        #endregion        
        
        private void cargarCuentas() {
            if ((objParametros != null))
            {

                txtctaActivo.Text = objParametros.ctaActivo;
                txtctaDepreciacion.Text = objParametros.ctaDepreciacion;
                txtctaGastos.Text = objParametros.ctaGastos;
                txtGanancia.Text = objParametros.ctaMonetaria;
                txtMantenimiento.Text = objParametros.ctaDepMonetaria;
                
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
            objParametros = bllPar.getParametros();
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

                if (!ctrVal.noEstaVacio(cboGrupo.Text))
                {
                    smsError.SetError(cboGrupo, "Seleccione un Tipo");
                    bandera = false;
                }

                if (!ctrVal.noEstaVacio(cboAreaResp.SelectedValue.ToString()) && lblOperacion.Text == "Nuevo")
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
            objAct.marca = txtMarca.Text;
            objAct.modelo = txtModelo.Text;
            objAct.grupo = cboGrupo.SelectedValue.ToString();
            objAct.subGrupo = cboSubgrupo.SelectedValue.ToString();
            objAct.vidaUtil = Convert.ToInt16(txtvidaUtil.Text);

            objAct.propiedad = cboPropiedad.Text;
            objAct.fecha = dtpFecha.Value.ToShortDateString();
            objAct.area = cboAreaResp.SelectedValue.ToString();
            objAct.responsable = txtCodResp.Text;
            objAct.proveedor = txtcodProveedor.Text;
            objAct.centrocosto = txtcentro.Text;
            objAct.estado = cboEstado.Text;

            objAct.valComercial = UtilSystem.DIN(txtvalComercial.Text);
            objAct.valSalvamento = UtilSystem.DIN(txtvalSalvamento.Text);
            objAct.valHistorico = UtilSystem.DIN(txtvalHistorico.Text);
            objAct.valLibros = UtilSystem.DIN(txtvalLibros.Text);
            objAct.valMejoras = UtilSystem.DIN(txtvalMejoras.Text);
            objAct.depAjustada = UtilSystem.DIN(txtdepAjustada.Text);
            objAct.depAcumulada = UtilSystem.DIN(txtdepAcumulada.Text);

            objAct.ctaActivo = txtctaActivo.Text;
            objAct.ctaDepreciacion = txtctaDepreciacion.Text;
            objAct.ctaGastos = txtctaGastos.Text;
            objAct.ctaGanancia = txtGanancia.Text;
            objAct.ctaMantenimiento = txtMantenimiento.Text;
            objAct.ctaPerdida = txtPerdida.Text;
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
            UtilSystem.ValNumeroDecimal(sender, e);
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
                    txtMarca.Text = activo.marca;
                    txtModelo.Text = activo.modelo;
                    txtvidaUtil.Text = activo.vidaUtil.ToString();
                    cboGrupo.SelectedValue = activo.grupo;
                    cboSubgrupo.SelectedValue = activo.subGrupo;

                    cboPropiedad.Text = activo.propiedad;
                    dtpFecha.Value = DateTime.Parse(activo.fecha);
                    txtcodProveedor.Text = activo.proveedor;
                    txtcentro.Text = activo.centrocosto;                   
                    cboAreaResp.SelectedValue = activo.area;                    
                    txtCodResp.Text = activo.responsable;
                    cboEstado.Text = activo.estado;

                    txtvalComercial.Text =UtilSystem.fMoneda(activo.valComercial);
                    txtvalHistorico.Text = UtilSystem.fMoneda(activo.valHistorico);
                    txtvalLibros.Text = UtilSystem.fMoneda(activo.valLibros);
                    txtvalMejoras.Text = UtilSystem.fMoneda(activo.valMejoras);
                    txtvalSalvamento.Text = UtilSystem.fMoneda(activo.valSalvamento);
                    txtdepAcumulada.Text =UtilSystem.fMoneda( activo.depAcumulada);
                    txtdepAjustada.Text = UtilSystem.fMoneda(activo.depAjustada);

                    txtctaActivo.Text = activo.ctaActivo;
                    txtMantenimiento.Text = activo.ctaMantenimiento;
                    txtctaDepreciacion.Text = activo.ctaDepreciacion;
                    txtctaGastos.Text = activo.ctaGastos;
                    txtGanancia.Text = activo.ctaGanancia;
                    txtPerdida.Text = activo.ctaPerdida;
                    Encontro = true;
                }
            }   

        }

        private void txtcentro_TextChanged(object sender, EventArgs e)
        {
                centro = bllCentro.buscar(txtcentro.Text); 
                if (centro  == null){
                   txtcentroNom.Text= "";
                } else {
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
                reporte.SetParameterValue("periodo", "Periodo Actual: "+ BLL.Inicializar.periodo);
                
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
            else {
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

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupo.Text == "Construcción y Edificaciones"){
                txtvidaUtil.Text = "240";
            }
            else if (cboGrupo.Text == "Maquinaria y Equipos" || cboGrupo.Text == "Equipo de Oficina")
            {
                txtvidaUtil.Text = "120";
            }
            else if (cboGrupo.Text == "Equipo de Computación y Comunicación" || cboGrupo.Text == "Flota y Equipo de transporte")
            {
                txtvidaUtil.Text = "60";
            }            
            else {
                txtvidaUtil.Text = "0";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtDescripcion.Text = txtNombre.Text;
        }

        private void txtvalComercial_Leave(object sender, EventArgs e)
        {            
            txtvalHistorico.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalLibros.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalComercial.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
        }

        private void txtvalSalvamento_Leave(object sender, EventArgs e){
             txtvalSalvamento.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalSalvamento.Text));
        }

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

      
    }
}
