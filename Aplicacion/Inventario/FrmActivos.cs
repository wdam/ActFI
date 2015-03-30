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
        
        #region Declaracion de Variables
        TextBox texto;
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        BLL.TerceroBLL bllTer = new BLL.TerceroBLL();
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CentroCostoBLL bllCentro = new BLL.CentroCostoBLL();
        BLL.GrupoBLL bllGrupo = new BLL.GrupoBLL();
        BLL.MantenimientoBLL bllMto = new BLL.MantenimientoBLL();
        BLL.PolizaBLL bllPoliza = new BLL.PolizaBLL();
        BLL.DocumentosBLL bllDoc = new BLL.DocumentosBLL();
        BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();

        bool Encontro = false;   // Verificar si encontro datos de un activo
        // Declaracion de Objetos
        ETerceros user;
        ECentroCosto centro;
        EActivos activo;
        EGrupo objGrupo;
        EMantenimiento objMnto;
        EPolizas objPoliza;
        EParametros objParametros;
        ETipoDocumento objTipodoc;

        // Declaracion de Listas
        List<EGrupo> lstGrupos;
        List<ESubgrupo> lstSubgrupo;

        double porSalvto = 0; // porcentaje de salvamento 
        string tipoDoc = "";   // Tipo de Documento Contable
        string numConsecutivo; //Numero Consecutivo Contable
        #endregion
        
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
            pnlMantenimiento.Enabled = true;
            pnlSeguro.Enabled = true;
            lblGuardar.Enabled = true;
            lblCancelar.Enabled = true;            
            txtCodResp.Enabled = true;
            cboAreaResp.Enabled = true;

            lblBuscar.Enabled = false;
            lblEditar.Enabled = false;
            lblNuevo.Enabled = false;
            lblpdf.Enabled = false;
            if (lblOperacion.Text == "Nuevo"){
                chkMantenimiento.Checked = false;
                chkPoliza.Checked = false;
            }
            
        }

        private void Deshabilitar()
        {
            pnlGeneral.Enabled = false;
            pnlDetalle.Enabled = false;
            pnlValores.Enabled = false;
            pnlMantenimiento.Enabled = false;
            pnlSeguro.Enabled = false;
            lblGuardar.Enabled = false;
            lblCancelar.Enabled = false;

            lblBuscar.Enabled = true;
            lblEditar.Enabled = true;
            lblNuevo.Enabled = true;
            lblpdf.Enabled = true;
            btnTab4.Enabled = false;
            btnTab5.Enabled = false;
        }

        private void colocarEnCero()
        {
            foreach (Control texto in gbValores.Controls) {
                if  (texto is TextBox) {
                    texto.Text = "0,00";
                }
            }
            pbxImagen.Image = Properties.Resources.defaultIm;
            chkMantenimiento.Checked = false;
            chkPoliza.Checked = false;
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

        #region Eventos De Controles

        //Evento Double_Click Para Seleccionar Cuentas Contables
        private void formCuenta(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelCuentas frm = Application.OpenForms.OfType<FrmSelCuentas>().FirstOrDefault();
            FrmSelCuentas form = frm ?? new FrmSelCuentas();
            form.ShowDialog(this);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Consulta")
            {
                mostrarDatos();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (lblOperacion.Text == "Nuevo")
            {
                mostrarDatos();
                if (Encontro)
                {
                    lblOperacion.Text = "Editar";
                }
            }
        }

        private void txtvalComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilSystem.ValNumeroDecimal(sender, e);
        }

        private void txtcentro_TextChanged(object sender, EventArgs e)
        {
            centro = bllCentro.buscar(txtcentro.Text);
            if (centro == null)
            {
                txtcentroNom.Text = "";
            }
            else
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
                txtProveedor.Text = string.Empty;
            }
            else
            {
                txtcodProveedor.Text = tercero.nit;
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


        private void cboAreaResp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtCodResp_TextChanged(object sender, EventArgs e)
        {
            user = bllTer.buscar(txtCodResp.Text);
            if (user == null)
            {
                txtResponsable.Text = string.Empty;
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

        private void txtProveedorMto_TextChanged(object sender, EventArgs e)
        {
            ETerceros tercero = bllTer.buscar(txtProveedorMto.Text);
            if (tercero == null)
            {
                txtNomProvMto.Text = "";
            }
            else
            {
                txtProveedorMto.Text = tercero.nit;
                txtNomProvMto.Text = tercero.nombre;
            }
        }

        private void txtProveedorMto_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelTercero Frm = new FrmSelTercero();
            Frm.tipo = "PROVEEDOR";
            Frm.ShowDialog(this);
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            ETerceros tercero = bllTer.buscar(txtEmpresa.Text);
            if (tercero == null)
            {
                txtNomEmpSeg.Text = "";
            }
            else
            {
                txtEmpresa.Text = tercero.nit;
                txtNomEmpSeg.Text = tercero.nombre;
            }
        }

        private void txtEmpresa_DoubleClick(object sender, EventArgs e)
        {
            texto = (TextBox)sender;
            FrmSelTercero Frm = new FrmSelTercero();
            Frm.tipo = "PROVEEDOR";
            Frm.ShowDialog(this);
        }

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSubgrupos(cboGrupo.SelectedValue.ToString());
            if (lblOperacion.Text == "Nuevo")
            {
                valoresGrupo(cboGrupo.SelectedValue.ToString());
            }
        }

        private void txtvidaUtil_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilSystem.ValidarNumero(sender, e);
        }

        private void chkPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPoliza.Checked == true)
            {
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
            else
            {
                btnTab5.Enabled = false;
            }
        }

        //Eventos LEAVE
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = txtNombre.Text;
            }
        }

        private void txtvalComercial_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtvalComercial.Text))
            {
                txtvalComercial.Text = "0";
            }
            txtvalHistorico.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalLibros.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalComercial.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text));
            txtvalSalvamento.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalComercial.Text) * porSalvto);
        }

        private void txtvalSalvamento_Leave(object sender, EventArgs e)
        {
            txtvalSalvamento.Text = UtilSystem.fMoneda(Convert.ToDouble(txtvalSalvamento.Text));
        }


        private void txtVComprar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVComprar.Text)){
                txtVComprar.Text = "0";
            }
            txtVComprar.Text = UtilSystem.fMoneda(Convert.ToDouble(txtVComprar.Text));
            txtvalComercial.Text = txtVComprar.Text;
            txtvalComercial_Leave(null, null);
        }

        private void txtValAsegurado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValAsegurado.Text))
            {
                txtValAsegurado.Text = "0";
            }
            txtValAsegurado.Text = UtilSystem.fMoneda(Convert.ToDouble(txtValAsegurado.Text));
        }

        private void txtValDeducible_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValDeducible.Text))
            {
                txtValDeducible.Text = "0";
            }
            txtValDeducible.Text = UtilSystem.fMoneda(Convert.ToDouble(txtValDeducible.Text));
        }


        #endregion

        #region Eventos Principales
        private void lblNuevo_Click(object sender, EventArgs e)
        {
            this.smsError.Dispose();
            lblOperacion.Text = "Nuevo";
            using (Utilidades util = new Utilidades())
            {
                util.limpiarControles(this);
            }
            obtenerTipoDoc();
            cboGrupo_SelectedIndexChanged(null, null);
            verPanel1();
            Habilitar();
            colocarEnCero();
            Encontro = false;
            
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

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            verPanel1();
            lblOperacion.Text = "Consulta";
            smsError.Dispose();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && Encontro == true)
            {
                lblOperacion.Text = "Editar";
                Habilitar();
                txtCodigo.Enabled = false;
                txtCodResp.Enabled = false;
                cboAreaResp.Enabled = false;
                if (chkPoliza.Checked == true)
                {
                    btnTab4.Enabled = true;
                }
                if (chkMantenimiento.Checked == true)
                {
                    btnTab5.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Activo (Valido o Registrado).. ", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            lblOperacion.Text = "Consulta";
            FrmSelActivos frm = new FrmSelActivos();
            frm.ShowDialog(this);
        }

        private void lblpdf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && lblOperacion.Text == "Consulta" && Encontro == true)
            {               
                BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
                ECompany objC = bllComp.buscar();
                DataTable dt = new DataTable();
                dt = bllAct.informeBasico(txtCodigo.Text);
                Informes.FrmVerInforme frm = new Informes.FrmVerInforme();
                ReportDocument reporte = new ReportDocument();
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\rptinfActBasico.rpt";
                reporte.Load(ruta);
                reporte.SetDataSource(dt);
                // Asignacion de Parametros 
                reporte.SetParameterValue("comp", objC.descripcion);
                reporte.SetParameterValue("nit", objC.nit);
                reporte.SetParameterValue("periodo", "Periodo Actual: " + BLL.Inicializar.periodo);

                frm.CReporte.ReportSource = reporte;
                frm.CReporte.Refresh();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un Activo (Valido O Registrado en el Sistem)", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        #endregion

        #region Proceso de Guardar y Modificar
        private void guardar()
        {
            activo = CrearActivo();
            string mensaje = bllAct.insertar(activo);
            if (mensaje == "Exito")
            {
                Encontro = true;
                bllGrupo.updateConsecutivo(activo.grupo);
                if (chkPoliza.Checked == true)
                {
                    guardarPoliza();
                }
                if (chkMantenimiento.Checked == true)
                {
                    guardarContratoMto();
                }
                guardarContable();
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
            objAct.fecha = UtilSystem.fFecha(dtpFechaCpra.Value);
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

            objAct.fechaDep = UtilSystem.fFecha(dtpFechaCpra.Value.AddMonths(Convert.ToInt16(txtvidaUtil.Text)));
            objAct.mantenimiento = chkMantenimiento.Checked ? "SI" : "NO";
            objAct.poliza = chkPoliza.Checked ? "SI" : "NO";
            objAct.nFactura = txtNFactura.Text;
            return objAct;
        }

        private void guardarPoliza()
        {
            EPolizas objPol = new EPolizas();
            objPol.codActivo = txtCodigo.Text;
            objPol.deducible = UtilSystem.DIN(txtValDeducible.Text);
            objPol.empresa = txtEmpresa.Text;
            objPol.fechaInicio = UtilSystem.fFecha(dtpFInicioSeg.Value);
            objPol.fechaVence = UtilSystem.fFecha(dtpFVenceSeg.Value);
            objPol.responsable = txtAgente.Text;
            objPol.telefono = txtTelSeguro.Text;
            objPol.valor = UtilSystem.DIN(txtValAsegurado.Text);
            objPol.nPoliza = txtPoliza.Text;
            bllPoliza.insertar(objPol);
        }

        private void guardarContratoMto()
        {
            EMantenimiento objMto = new EMantenimiento();
            objMto.codActivo = txtCodigo.Text;
            objMto.fInicio = UtilSystem.fFecha(dtpInicioMto.Value);
            objMto.fVence = UtilSystem.fFecha(dtpVenceMto.Value);
            objMto.nContrato = txtContrato.Text;
            objMto.nVisitas = Convert.ToInt32(txtNVisitas.Text);
            objMto.proveedor = txtProveedorMto.Text;
            objMto.valor = UtilSystem.DIN("0");
            bllMto.insertar(objMto);
        }       
        #endregion  

        #region Validacion de Datos

        private bool validar()
        {
            bool bandera = true;
            using (BLL.ValidacionesBLL ctrVal = new BLL.ValidacionesBLL())
            {
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

                if (cboAreaResp.Text == "" && lblOperacion.Text == "Nuevo")
                {
                    smsError.SetError(cboAreaResp, "Seleccione el Area Responsable");
                    bandera = false;
                }

                if (cboGrupo.Text == "")
                {
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

                if (!ctrVal.esValorValido(txtvalComercial.Text))
                {
                    smsError.SetError(txtvalComercial, "EL Valor Comercial Debe Ser mayor a cero (0)");
                    bandera = false;
                }
            }
            if (chkMantenimiento.Checked == true)
            {
                smsError.SetError(chkMantenimiento, "Ingrese los Datos del Contrato de Mantenimiento");
                bandera = validarMto();
            }
            if (chkPoliza.Checked == true)
            {
                smsError.SetError(chkPoliza, "Ingrese los Datos del Seguro");
                bandera = validarPoliza();
            }
            return bandera;
        }

        private bool validarMto()
        {
            bool correcto = true;
            if (string.IsNullOrWhiteSpace(txtContrato.Text))
            {
                smsError.SetError(txtContrato, "Ingrese el Numero de Contrato de Mantenimiento");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtNomProvMto.Text))
            {
                smsError.SetError(txtProveedorMto, "Ingrese el Proveedor Encargado del Mantenimiento");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtNVisitas.Text))
            {
                smsError.SetError(txtNVisitas, "Ingrese el Numero de Visitas");
                correcto = false;
            }
            return correcto;
        }

        private bool validarPoliza()
        {
            bool correcto = true;
            if (string.IsNullOrWhiteSpace(txtPoliza.Text))
            {
                smsError.SetError(txtPoliza, "Ingrese el N° de Poliza");
                correcto = false;
            }
            if (string.IsNullOrWhiteSpace(txtNomEmpSeg.Text))
            {
                smsError.SetError(txtEmpresa, "Ingrese el Nit De la Empresa (Valido)");
                correcto = false;
            }

            if (string.IsNullOrEmpty(txtValAsegurado.Text) || txtValAsegurado.Text == "0")
            {
                smsError.SetError(txtValAsegurado, "Ingrese el Valor del Seguro");
                correcto = false;
            }
            return correcto;
        }
        #endregion

        #region Mostrar Datos de Un Activo

        private void mostrarDatos()
        {
            Encontro = false;
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                activo = bllAct.buscar(txtCodigo.Text);
                colocarEnCero();
                if (activo != null)
                {
                    txtCodigo.Text = activo.codigo;
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
                    dtpFechaCpra.Value = DateTime.Parse(activo.fecha);
                    txtcodProveedor.Text = activo.proveedor;
                    txtcentro.Text = activo.centrocosto;
                    cboAreaResp.SelectedValue = activo.area;
                    txtCodResp.Text = activo.responsable;
                    cboEstado.Text = activo.estado;

                    txtvalComercial.Text = UtilSystem.fMoneda(activo.valComercial);
                    txtvalHistorico.Text = UtilSystem.fMoneda(activo.valHistorico);
                    txtvalLibros.Text = UtilSystem.fMoneda(activo.valLibros);
                    txtvalMejoras.Text = UtilSystem.fMoneda(activo.valMejoras);
                    txtvalSalvamento.Text = UtilSystem.fMoneda(activo.valSalvamento);
                    txtdepAcumulada.Text = UtilSystem.fMoneda(activo.depAcumulada);
                    txtdepAjustada.Text = UtilSystem.fMoneda(activo.depAjustada);
                    txtVComprar.Text = UtilSystem.fMoneda(activo.valComercial);

                    txtctaActivo.Text = activo.ctaActivo;
                    txtctaMantenimiento.Text = activo.ctaMantenimiento;
                    txtctaDepreciacion.Text = activo.ctaDepreciacion;
                    txtctaGastos.Text = activo.ctaGastos;
                    txtctaGanancia.Text = activo.ctaGanancia;
                    txtctaPerdida.Text = activo.ctaPerdida;
                    string ruta = UtilSystem.rutaImagen + activo.codigo + ".jpg";
                    if (System.IO.File.Exists(UtilSystem.rutaImagen + activo.codigo + ".jpg"))
                    {
                        pbxImagen.ImageLocation = UtilSystem.rutaImagen + activo.codigo + ".jpg";
                        pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    txtNFactura.Text = activo.nFactura;
                    if (activo.poliza == "SI")
                    {
                        chkPoliza.Checked = true;
                        mostrarPoliza(activo.codigo);
                    }

                    if (activo.mantenimiento == "SI")
                    {
                        chkMantenimiento.Checked = true;
                        mostrarCtoMto(activo.codigo);
                    }
                    Encontro = true;
                    verPanel1();
                }
            }

        }

        private void mostrarPoliza(string codigo)
        {
            objPoliza = bllPoliza.buscar(codigo);
            if (objPoliza != null)
            {
                txtPoliza.Text = objPoliza.nPoliza;
                txtValDeducible.Text = UtilSystem.fMoneda(objPoliza.deducible);
                txtEmpresa.Text = objPoliza.empresa;
                dtpFInicioSeg.Value = Convert.ToDateTime(objPoliza.fechaInicio);
                dtpFVenceSeg.Value = Convert.ToDateTime(objPoliza.fechaVence);
                txtAgente.Text = objPoliza.responsable;
                txtTelSeguro.Text = objPoliza.telefono;
                txtValAsegurado.Text = UtilSystem.fMoneda(objPoliza.valor);
                lblIDPoliza.Text = objPoliza.idPoliza.ToString();
            }
        }

        private void mostrarCtoMto(string codigo)
        {
            objMnto = bllMto.buscar(codigo);
            if (objMnto != null)
            {
                dtpInicioMto.Value = Convert.ToDateTime(objMnto.fInicio);
                dtpVenceMto.Value = Convert.ToDateTime(objMnto.fVence);
                txtContrato.Text = objMnto.nContrato;
                txtNVisitas.Text = objMnto.nVisitas.ToString();
                txtProveedorMto.Text = objMnto.proveedor;
                txtValContrato.Text = UtilSystem.fMoneda(objMnto.valor);
                lblIDContMant.Text = objMnto.idMto.ToString();
            }
        }
        #endregion
               
        #region Grupos y Subrgrupos , Obtencion del Consecutivo

        private void cargarGrupos()
        {
            lstGrupos = bllGrupo.getAll("Activo");
            cboGrupo.DataSource = lstGrupos;
            cboGrupo.DisplayMember = "descripcion";
            cboGrupo.ValueMember = "sigla";
            if (lstGrupos.Count > 0)
            {
                cboGrupo_SelectedIndexChanged(null, null);
            }
        }
       
        private void valoresGrupo(string sigla)
        {
            objGrupo = bllGrupo.buscar(sigla);
            if (objGrupo != null)
            {
                txtvidaUtil.Text = objGrupo.vidaUtil.ToString();
                cboMetodo.SelectedValue = objGrupo.metodoDep;
                txtctaActivo.Text = objGrupo.ctaActivo;
                txtctaDepreciacion.Text = objGrupo.ctaDepreciacion;
                txtctaGanancia.Text = objGrupo.ctaGanancia;
                txtctaGastos.Text = objGrupo.ctaGastos;
                txtctaMantenimiento.Text = objGrupo.ctaMantenimiento;
                txtctaPerdida.Text = objGrupo.ctaPerdida;
                porSalvto = Math.Round(Convert.ToDouble(objGrupo.valSalvamento) / 100, 2);
                // Obtener Numero Consecutivo deL Nuevo Codigo
                txtCodigo.Text = sigla + UtilSystem.fConsActivo(objGrupo.consecutivo + 1);
            }
        }    

        private void cargarSubgrupos(string sigla)
        {
            cboSubgrupo.Text = "";
            lstSubgrupo = bllGrupo.getSubgrupo(sigla);
            cboSubgrupo.DataSource = lstSubgrupo;
            cboSubgrupo.DisplayMember = "descripcion";
            cboSubgrupo.ValueMember = "codigo";            
        }
        #endregion
       
        #region Generar Proceso Contable

        private void obtenerTipoDoc() {
            if (objParametros != null)
            {
                if (!string.IsNullOrEmpty(objParametros.compras)){                    
                    tipoDoc = objParametros.compras;                  
                }
                else {
                    MessageBox.Show("No se ha Selecciondo el Documento Contable para Compras.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("Ho hay Documentos Contables Parametrizados.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }
        private void Consecutivo()
        {
            objTipodoc = bllTipo.buscarTipo(tipoDoc);
            if (objTipodoc == null){
                numConsecutivo = "0";
            }
            else {
                numConsecutivo = UtilSystem.fConsecutivo(objTipodoc.actual);
            }
        }

        private void movimientoContable() {
            dgvContable.Rows.Clear();
            dgvContable.Rows.Add("COMPRA DE " + cboSubgrupo.Text, txtvalComercial.Text, 0, txtctaActivo.Text, 0);
            dgvContable.Rows.Add("PROVEEDORES NACIONALES ", 0, txtvalComercial.Text, objParametros.ctaProveedor, 0);
        }

        private void guardarContable() {            
            movimientoContable();
            Consecutivo();
            int valCons = bllDoc.verificar(Convert.ToInt32(numConsecutivo), tipoDoc);
            if (valCons > 0){
                numConsecutivo = UtilSystem.fConsecutivo(Convert.ToInt32(numConsecutivo) + 1);
            }
            bllTipo.updateConsecutivo(Convert.ToInt32(numConsecutivo), tipoDoc);
            int cont = 0;
            string fecha = UtilSystem.truncarCadena(DateTime.Now.Date.ToShortDateString(), 10);
            foreach (DataGridViewRow item in dgvContable.Rows)
            {
                cont++;
                EDocumentos ObjDoc = new EDocumentos();
                ObjDoc.item = cont;
                ObjDoc.documento = Convert.ToInt32(numConsecutivo);
                ObjDoc.tipo = tipoDoc;
                ObjDoc.periodo = BLL.Inicializar.periodo;
                ObjDoc.dia = DateTime.Now.Day.ToString();
                ObjDoc.centro =  string.IsNullOrEmpty(txtcentro.Text) ? "0" : txtcentro.Text;
                ObjDoc.descripcion = UtilSystem.truncarCadena(item.Cells["dtDescripcion"].Value.ToString(), 50);
                ObjDoc.debito = UtilSystem.DIN(item.Cells["dtDebito"].Value.ToString() ?? "0");
                ObjDoc.credito = UtilSystem.DIN(item.Cells["dtCredito"].Value.ToString() ?? "0");
                ObjDoc.codigo = item.Cells["dtCuenta"].Value.ToString();
                ObjDoc.baseD = UtilSystem.DIN(item.Cells["dtBase"].Value.ToString() ?? "0"); 
                ObjDoc.diasv = 0;
                ObjDoc.fecha = fecha;
                ObjDoc.cheque = "";
                ObjDoc.nit = txtcodProveedor.Text;
                ObjDoc.modulo = "ACTIVOS";
                bllDoc.insertar(ObjDoc);
            }
            guardarMovimiento();
        }

        private void guardarMovimiento()
        {
            BLL.MovimientoBLL bllMov = new BLL.MovimientoBLL();
            EMovimientos objMov = new EMovimientos();
            objMov.cCosto = txtcentro.Text;
            objMov.codActivo = txtCodigo.Text;
            objMov.descripcion = "COMPRA DE ACTIVOS";
            objMov.documento = tipoDoc + numConsecutivo;
            objMov.estado = "AP";
            objMov.fecha = DateTime.Now;
            objMov.nit = "0";
            objMov.periodo = BLL.Inicializar.periodo;
            objMov.tipoDoc = tipoDoc;
            objMov.tipoMov = "COMPRA";
            objMov.valor = UtilSystem.DIN(txtvalComercial.Text);
            bllMov.insertar(objMov);
        }
        #endregion

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
                                    
        private void FrmActivos_Load(object sender, EventArgs e)
        {                        
            Deshabilitar();
            verPanel1();
            objParametros = bllPar.getParametros();            
            if (string.IsNullOrEmpty(objParametros.compras))
            {
                lblNuevo.Enabled = false;
                MessageBox.Show("No se ha Selecciondo el Documento Contable para Compras.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                lblNuevo.Enabled = true;                                    
            }
            CargarAreas();
            cargarGrupos();
            // Cargar Metodo de >Depreciacion
            List<EtipoDepreciacion> lstTipos = UtilSystem.metodosDepreciacion();
            cboMetodo.DisplayMember = "Descripcion";
            cboMetodo.ValueMember = "sigla";
            cboMetodo.DataSource = lstTipos;
        }
                                              
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }    
       
        private void lblSubirImg_Click(object sender, EventArgs e)
        {
            abrirDialog.ShowDialog();
            pbxImagen.ImageLocation = abrirDialog.FileName;
            pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
        }
       
    }
}
