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

namespace Aplicacion.Inventario
{
    public partial class FrmTipoDocumento : Form
    {
        public string tipo;
        BLL.TipoDocumentoBLL blltipo = new BLL.TipoDocumentoBLL();
        List<ETipoDocumento> lstTipos;

        public FrmTipoDocumento()
        {
            InitializeComponent();
        }

        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        protected void cargarGrilla() {
            lstTipos = blltipo.getAll();
            int cont = 0;
            if (lstTipos.Count > 0)
            {
                lblMensaje.Visible = false;
                foreach (var item in lstTipos)
                {
                    cont++;
                    dgvTipo.Rows.Add(cont, item.descripcion, item.tipoDoc, item.grupo);
                }
            }
            else {
                lblMensaje.Visible = true;
            }
           
        }
    }
}
