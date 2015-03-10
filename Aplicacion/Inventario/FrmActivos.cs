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
        BLL.GrupoBLL bllGrupo = new BLL.GrupoBLL();
                
        bool Encontro = false;   // Verificar si encontro datos de un activo
        
        ETerceros user;
        ECentroCosto centro;        
        EActivos activo;
        EGrupo objGrupo;
        // Declaracion de Listas
        List<EGrupo> lstGrupos;
        List<ESubgrupo> lstSubgrupo;
        double porSalvto = 0; // porcentaje de salvamento 
        public FrmActivos()
        {
            InitializeComponent();
        }

        #region Ocultar / Mostrar Paneles dependiendo de la opcion seleccionada

        private void verPanel1(){            
            pnlValores.Visible = false;
            pnlDetalle.Visible = false;
            pnlSeguro.Visible = false;
            pnlMantenimiento.Visible = false;
            pnlGeneral.Visible = true;
            pnlGeneral.Width = 780;
            lblLinea1.Visible = true;
            lblLinea2.Visible = false;
            lblLinea3.Visible = false;
            lblLinea4.Visible = false;
            lblLinea5.Visible = false;
            btnTab1.FlatAppearance.BorderSize = 1;
            btnTab2.FlatAppearance.BorderSize = 0;
            btnTab3.FlatAppearance.BorderSize = 0;
            btnTab4.FlatAppearance.BorderSize = 0;
            btnTab5.FlatAppearance.BorderSize = 0;
        }

        private void verPanel2() {
            pnlGeneral.Visible = false;
            pnlDetalle.Visible = true;
            pnlValores.Visible = false;
            pnlSeguro.Visible = false;
            pnlMantenimiento.Visible = false;
            pnlDetalle.Width = 780;
            lblLinea1.Visible = false;
            lblLinea2.Visible = true;
            lblLinea3.Visible = false;
            lblLinea4.Visible = false;
            lblLinea5.Visible = false;
            btnTab1.FlatAppearance.BorderSize = 0;
            btnTab2.FlatAppearance.BorderSize = 1;
            btnTab3.FlatAppearance.BorderSize = 0;
            btnTab4.FlatAppearance.BorderSize = 0;
            btnTab5.FlatAppearance.BorderSize = 0;
        }

        private void verPanel3() {
            pnlGeneral.Visible = false;
            pnlDetalle.Visible = false;
            pnlValores.Visible = true;
            pnlSeguro.Visible = false;
            pnlMantenimiento.Visible = false;
            pnlValores.Width = 780;
            lblLinea1.Visible = false;
            lblLinea2.Visible = false;
            lblLinea3.Visible = true;
            lblLinea4.Visible = false;
            lblLinea5.Visible = false;
            btnTab1.FlatAppearance.BorderSize = 0;
            btnTab2.FlatAppearance.BorderSize = 0;
            btnTab3.FlatAppearance.BorderSize = 1;
            btnTab4.FlatAppearance.BorderSize = 0;
            btnTab5.FlatAppearance.BorderSize = 0;
        }

        private void verPanel4() {
            pnlGeneral.Visible = false;
            pnlDetalle.Visible = false;
            pnlValores.Visible = false;
            pnlMantenimiento.Visible = false;
            pnlSeguro.Visible = true;
            pnlSeguro.Width = 780;
            lblLinea1.Visible = false;
            lblLinea2.Visible = false;
            lblLinea3.Visible = false;
            lblLinea4.Visible = true;
            lblLinea5.Visible = false;
            btnTab1.FlatAppearance.BorderSize = 0;
            btnTab2.FlatAppearance.BorderSize = 0;
            btnTab3.FlatAppearance.BorderSize = 0;
            btnTab4.FlatAppearance.BorderSize = 1;
            btnTab5.FlatAppearance.BorderSize = 0;
        }

        private void verPanel5() {
            pnlGeneral.Visible = false;
            pnlDetalle.Visible = false;
            pnlValores.Visible = false;
            pnlSeguro.Visible = false;
            pnlMantenimiento.Visible = true;
            pnlMantenimiento.Width = 780;
            lblLinea1.Visible = false;
            lblLinea2.Visible = false;
            lblLinea3.Visible = false;
            lblLinea4.Visible = false;
            lblLinea5.Visible = true;
            btnTab1.FlatAppearance.BorderSize = 0;
            btnTab2.FlatAppearance.BorderSize = 0;
            btnTab3.FlatAppearance.BorderSize = 0;
            btnTab4.FlatAppearance.BorderSize = 0;
            btnTab5.FlatAppearance.BorderSize = 1;  
        }

        private void btnTab1_Click(object sender, EventArgs e)
        {
            verPanel1();
        }

        private void btnTab2_Click(object sender, EventArgs e)
        {
            verPanel2();
        }

        private void btnTab3_Click(object sender, EventArgs e)
        {
            verPanel3();
        }       

        private void btnTab4_Click(object sender, EventArgs e)
        {
            verPanel4();
        }

        private void btnTab5_Click(object sender, EventArgs e)
        {
            verPanel5();
        }
        #endregion  

        #region Habilitar y Deshabilitar controles

        private void Habilitar()
        {
            pnlGeneral.Enabled = true;
            pnlDetalle.Enabled = true;
            pnlValores.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;            
            txtCodResp.Enabled = true;
            cboAreaResp.Enabled = true;

            lblBuscar.Enabled = false;
            lblEditar.Enabled = false;
            lblNuevo.Enabled = false;
            lblpdf.Enabled = false;
         
        }

        private void Deshabilitar()
        {
            pnlGeneral.Enabled = false;
            pnlDetalle.Enabled = false;
            pnlValores.Enabled = false;
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
            pbxImagen.Image = Properties.Resources.defaultIm;
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
        
        

        private void cargarGrupos() {
            lstGrupos = bllGrupo.getAll("Activo");
            cboGrupo.DataSource = lstGrupos;
            cboGrupo.DisplayMember = "descripcion";
            cboGrupo.ValueMember = "sigla";
            if (lstGrupos.Count > 0) {
                cboGrupo_SelectedIndexChanged(null, null);
            }
        }

        private void valoresGrupo(string sigla)
        {
            objGrupo = bllGrupo.buscar(sigla);
            if (objGrupo != null) {
                txtvidaUtil.Text = objGrupo.vidaUtil.ToString();
                cboMetodo.SelectedValue = objGrupo.metodoDep;
                txtctaActivo.Text = objGrupo.ctaActivo;
                txtctaDepreciacion.Text = objGrupo.ctaDepreciacion;
                txtctaGanancia.Text = objGrupo.ctaGanancia;
                txtctaGastos.Text = objGrupo.ctaGastos;
                txtctaMantenimiento.Text = objGrupo.ctaMantenimiento;
                txtctaPerdida.Text = objGrupo.ctaPerdida;
                porSalvto = Math.Round(Convert.ToDouble(objGrupo.valSalvamento) / 100, 2);
                txtCodigo.Text = sigla + UtilSystem.fConsActivo(objGrupo.consecutivo + 1);
            }
        }

        private void cargarSubgrupos(string sigla) {
            cboSubgrupo.Text = "";
            lstSubgrupo = bllGrupo.getSubgrupo(sigla);
            cboSubgrupo.DataSource = lstSubgrupo;
            cboSubgrupo.DisplayMember = "descripcion";
            cboSubgrupo.ValueMember = "codigo";
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
            verPanel1();
            lblOperacion.Text = "Consulta";
            smsError.Dispose();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            this.smsError.Dispose();
            lblOperacion.Text = "Nuevo";                      
            using (Utilidades util = new Utilidades()){
                util.limpiarControles(this);
            }
            cboGrupo_SelectedIndexChanged(null, null);

            verPanel1();     
            Habilitar();                    
            colocarEnCero();                        
        }

        private void FrmActivos_Load(object sender, EventArgs e)
        {
            objParametros = bllPar.getParametros();
            smsError.Dispose();
            Deshabilitar();
            verPanel1();
            CargarAreas();
            cargarGrupos();
            List<EtipoDepreciacion> lstTipos = UtilSystem.metodosDepreciacion();
            cboMetodo.DisplayMember = "Descripcion";
            cboMetodo.ValueMember = "sigla";
            cboMetodo.DataSource = lstTipos;
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

                if (cboAreaResp.Text =="" && lblOperacion.Text == "Nuevo")
                {
                    smsError.SetError(cboAreaResp, "Seleccione el Area Responsable");
                    bandera = false;
                }

                if (cboGrupo.Text == "") {
                    smsError.SetError(cboGrupo, "Seleccione el Grupo");
                    bandera = false;
                }

                if (cboSubgrupo.Text == "")
                {
                    smsError.SetError(cboSubgrupo, "Seleccione el Subgrupo");
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
                bllGrupo.updateConsecutivo(activo.grupo);
                guardarImagen();
                MessageBox.Show("Datos Guardados Correctamente .. !!", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();
                verPanel1();
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
                guardarImagen();
                MessageBox.Show("Datos Actualizados Correctamente .. !!", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deshabilitar();
                verPanel1();
                lblOperacion.Text = "Consulta";               
            }
            else
            {
                MessageBox.Show(mensaje, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guardarImagen()
        {
            if (pbxImagen.Image != null)
            {
                if (!System.IO.Directory.Exists(UtilSystem.rutaImagen))
                {
                    System.IO.Directory.CreateDirectory(UtilSystem.rutaImagen);
                }
                pbxImagen.Image.Save(UtilSystem.rutaImagen + txtCodigo.Text + ".jpg");
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
            objAct.metodoDep = cboMetodo.SelectedValue.ToString();

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
            objAct.ctaGanancia = txtctaGanancia.Text;
            objAct.ctaMantenimiento = txtctaMantenimiento.Text;
            objAct.ctaPerdida = txtctaPerdida.Text;
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
                    cboGrupo_SelectedIndexChanged(null, null);
                    cboSubgrupo.SelectedValue = activo.subGrupo;
                    cboMetodo.SelectedValue = activo.metodoDep;

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
                    txtctaMantenimiento.Text = activo.ctaMantenimiento;
                    txtctaDepreciacion.Text = activo.ctaDepreciacion;
                    txtctaGastos.Text = activo.ctaGastos;
                    txtctaGanancia.Text = activo.ctaGanancia;
                    txtctaPerdida.Text = activo.ctaPerdida;
                    string ruta = UtilSystem.rutaImagen + activo.codigo + ".jpg";
                    if (System.IO.File.Exists(UtilSystem.rutaImagen + activo.codigo + ".jpg")) {
                        pbxImagen.ImageLocation = UtilSystem.rutaImagen + activo.codigo + ".jpg";
                        pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
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
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\rptinfActBasico.rpt";
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

         private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "") {
                txtDescripcion.Text = txtNombre.Text;
            }            
        }

        private void txtvalComercial_Leave(object sender, EventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(txtvalComercial.Text)){
                txtvalComercial.Text="0";
            }
            txtvalHistorico.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalLibros.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalComercial.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalSalvamento.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text) * porSalvto);
        }

        private void txtvalSalvamento_Leave(object sender, EventArgs e){
             txtvalSalvamento.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalSalvamento.Text));
        }

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSubgrupos(cboGrupo.SelectedValue.ToString());
            if (lblOperacion.Text == "Nuevo") {
                valoresGrupo(cboGrupo.SelectedValue.ToString());
            }        
        }

        private void lblNuevoSub_Click(object sender, EventArgs e)
        {
            abrirDialog.ShowDialog();
            pbxImagen.ImageLocation = abrirDialog.FileName;
            pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;    
        }

        private void txtvidaUtil_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilSystem.ValidarNumero(sender, e);
        }

        private void chkPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPoliza.Checked == true) {
                btnTab4.Enabled = true;
            }
            else
            {
                btnTab4.Enabled = false;
            }
        }

        private void chkMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMantenimiento.Checked == true)
            {
                btnTab5.Enabled = true;
            }
            else {
                btnTab5.Enabled = false;
            }
        }

       

                  
    }
}
