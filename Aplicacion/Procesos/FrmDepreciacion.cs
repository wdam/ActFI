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
namespace Aplicacion.Procesos
{
    public partial class FrmDepreciacion : Form
    {
        BLL.ActivosBLL bllAct = new BLL.ActivosBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
        BLL.ParametrosBLL bllPar = new BLL.ParametrosBLL();
        BLL.DocumentosBLL bllDoc = new BLL.DocumentosBLL();
        BLL.TipoDocumentoBLL bllTipo = new BLL.TipoDocumentoBLL();
        

        List<EPeriodo> lstPer;
        List<EDocumentos> lstDocumentos;      
        EActivos objActivo;
        EParametros objParametros;
        List<EActivos> lstActivos;
        ETipoDocumento tipodoc;

        string Documento = "";

        public FrmDepreciacion()
        {
            InitializeComponent();
        }        

        private void depreciar() {
            double depreciacion=0;
            double valorDep = 0;
            double depAcum = 0;
            dgvDatos.Rows.Clear();
            foreach (var item in lstActivos)
            {
                 valorDep= item.valComercial - item.valSalvamento;                                     
                 depreciacion = valorDep / item.vidaUtil;
                 depAcum = item.depAcumulada + depreciacion;
                 dgvDatos.Rows.Add(item.codigo, lblPeriodo.Text , depreciacion, depAcum, item.valComercial - depAcum, item.ctaGastos, item.ctaDepreciacion);
            }
        }

        private void FrmDepreciacion_Load(object sender, EventArgs e)
        {
            lblPeriodo.Text = BLL.Inicializar.periodo;
            lstPer = bllComp.getPerBloqueado("n");
            if (lstPer.Count > 0)
            {
                cboPeriodo.DataSource = lstPer;
                cboPeriodo.ValueMember = "periodo";
                cboPeriodo.DisplayMember = "periodo";
            }
            objParametros = bllPar.getParametros();
            if (objParametros != null)
            {
                if (!string.IsNullOrWhiteSpace(objParametros.depreciacion))
                {
                    lblDepreciar.Enabled = true;
                    Documento = objParametros.depreciacion;
                    Consecutivo();
                }
                else {
                    MessageBox.Show("No se ha Selecciondo el Documento Contable para Depreciaciones.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se ha Selecciondo el Documento Contable para Depreciaciones.. Verifique", "Control de Información ActFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Consecutivo()
        {
            tipodoc = bllTipo.buscarTipo(Documento);
            if (tipodoc == null)
            {
                txtNumero.Text = "";
            }
            else
            {
                txtNumero.Text = UtilSystem.fConsecutivo(tipodoc.actual);
            }
        }
    
        private void actualizarValores()
        {
            foreach(DataGridViewRow fila in dgvDatos.Rows)
            {
                bllAct.UpdateValores(UtilSystem.DIN(fila.Cells["dtLibros"].Value.ToString()), 
                    UtilSystem.DIN(fila.Cells["dtDepreciacion"].Value.ToString()),
                    UtilSystem.DIN(fila.Cells["dtDepAcum"].Value.ToString()), fila.Cells["dtCodigo"].Value.ToString());
            }     
        }

        private void Contabilidad() {
            lstDocumentos = bllDoc.buscarDocumento(Convert.ToInt32(txtNumero.Text.Trim()), Documento);
            if (lstDocumentos.Count > 0)
            {
                txtNumero.Text = UtilSystem.fConsecutivo(Convert.ToInt32(txtNumero.Text) + 1);
            }
            bllTipo.updateConsecutivo(Convert.ToInt32(txtNumero.Text), Documento);    

            var agruparDebito = from row in dgvDatos.Rows.Cast<DataGridViewRow>()
                                group row by row.Cells["dtCtaDep"].Value into
                                dtGrupo
                                select new
                                {
                                    cuenta = dtGrupo.Key,
                                    valor = dtGrupo.Sum(row => UtilSystem.DIN(row.Cells["dtDepreciacion"].Value.ToString()))
                                };

            var AgruparCredito = from row in dgvDatos.Rows.Cast<DataGridViewRow>()
                                 group row by row.Cells["dtCtaGastos"].Value into
                                 dtGrupo
                                 select new
                                 {
                                     cuenta = dtGrupo.Key,
                                     valor = dtGrupo.Sum(row => UtilSystem.DIN(row.Cells["dtDepreciacion"].Value.ToString()))
                                 };
          
            int cont = 0;
            foreach (var item in agruparDebito)
            {
                // Crear Objeto de tipo Documento                
                    cont++;
                    EDocumentos ObjDoc = new EDocumentos();
                    ObjDoc.item = cont;
                    ObjDoc.documento = Convert.ToInt32(txtNumero.Text);
                    ObjDoc.tipo = Documento;
                    ObjDoc.periodo = BLL.Inicializar.periodo;
                    ObjDoc.dia = DateTime.Now.Day.ToString();
                    ObjDoc.centro = "0";
                    ObjDoc.descripcion = "GASTO POR DEPRECIACION CTA " + item.cuenta;
                    ObjDoc.debito = UtilSystem.DIN(item.valor.ToString() ?? "0");
                    ObjDoc.credito = UtilSystem.DIN("0");
                    ObjDoc.codigo = item.cuenta.ToString();
                    ObjDoc.baseD = UtilSystem.DIN("0");
                    ObjDoc.diasv = 0;
                    ObjDoc.fecha = UtilSystem.truncarCadena(DateTime.Now.Date.ToShortDateString(), 10);
                    ObjDoc.cheque = "";
                    ObjDoc.nit = "0";
                    ObjDoc.modulo = "DEPRECIACION";
                    bllDoc.insertar(ObjDoc);                
            }

            foreach (var item in AgruparCredito)
            {
                // Crear Objeto de tipo Documento                
                cont++;
                EDocumentos ObjDoc = new EDocumentos();
                ObjDoc.item = cont;
                ObjDoc.documento = Convert.ToInt32(txtNumero.Text);
                ObjDoc.tipo = Documento;
                ObjDoc.periodo = BLL.Inicializar.periodo;
                ObjDoc.dia = DateTime.Now.Day.ToString();
                ObjDoc.centro = "0";
                ObjDoc.descripcion = "DEPRECIACION ACUMULADA CTA " + item.cuenta;
                ObjDoc.debito = UtilSystem.DIN("0");
                ObjDoc.credito = UtilSystem.DIN(item.valor.ToString() ?? "0"); 
                ObjDoc.codigo = item.cuenta.ToString();
                ObjDoc.baseD = UtilSystem.DIN("0");
                ObjDoc.diasv = 0;
                ObjDoc.fecha = UtilSystem.truncarCadena(DateTime.Now.Date.ToShortDateString(), 10);
                ObjDoc.cheque = "";
                ObjDoc.nit = "0";
                ObjDoc.modulo = "DEPRECIACION";
                bllDoc.insertar(ObjDoc);
            }
        }

     
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblDepreciar_Click(object sender, EventArgs e)
        {
            lstActivos = bllAct.getActivos("");
            if (lstActivos.Count > 0)
            {
                
                depreciar();
                //actualizarValores();  
                Contabilidad();                                                                                       
            }
            else
            {
                MessageBox.Show("No se Econtraron Activos a Depreciar en este Periodo", "Control de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
