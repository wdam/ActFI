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


namespace Aplicacion.Principal
{
    public partial class FrmLogin : Form
    {
        BLL.PrincipalBLL bllPrin = new BLL.PrincipalBLL();
        BLL.UsuarioBLL bllUser = new BLL.UsuarioBLL();
        BLL.CompanyBLL bllComp = new BLL.CompanyBLL();
        EUsuario user; // Objeto de tipo Usuario;
        ECompany company; // Objeto de tipo compañia
        List<ECompany> lstCompany;
        string pass; // Obtiene contraseña encriptada

        public FrmLogin()
        {
            InitializeComponent();            
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {           
            if (validar())  // Verificar que los campos no este vacios
            {
                if (txtusuario.Text == "sae"  && txtclaveUsua.Text =="root")
                {                    
                    pass = bllPrin.Encriptar2("upcvoting", "root");
                }
                else
                {
                    pass = bllPrin.Encriptar(txtclaveUsua .Text, "sae");
                }
                
                user = bllUser.buscar(txtusuario.Text, pass);
                if (user != null)  // Verificar si el usuario existe en la base de datos
                {
                    if (!string.IsNullOrEmpty(user.rol))  // Verifica que tiene un rol definido como usuario
                    {
                        if (buscarCompany(user.rol))
                        {
                            this.Hide();                       
                            MDIPrincipal frm = new MDIPrincipal();
                            frm.ShowDialog();
                            
                        }                                           
                    }
                    else 
                    {
                        MessageBox.Show("El Usuario no tiene un rol definido ", "SAE Control.. Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                                       
                }
                else 
                {
                    MessageBox.Show("Usuario o Contraseña incorrectas", "SAE Control -> Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                               
            }
            else 
            {
                MessageBox.Show("Datos de Inicio de Sesion Incorrectos", "SAE Control -> Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private bool validar() {
           
            if (string.IsNullOrWhiteSpace(txtusuario.Text) || txtusuario.Text == "Usuario")
            {
                txtusuario.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtclaveUsua.Text) || txtclaveUsua.Text == "Clave Usuario")
            {
                txtclaveUsua.Focus();
                return false;
            }
            
            return true;
        }

        private bool buscarCompany(string rol) {
            if (rol == "admin" && txtcompania.Text == "" || txtcompania.Text == "Compañia")
            {
                bllPrin.iniciarUsuario(txtusuario.Text, rol);
                
                lstCompany = bllComp.getAll(); // Obtener todas las compañias creadas 
                if (lstCompany == null)
                {
                    MessageBox.Show("No hay compañias creadas, Verifique ", "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    bllPrin.iniciarCompany("",null);
                    bllPrin.iniciarPeriodo("00/0000");
                }
                else
                {
                    bllPrin.iniciarCompany(lstCompany.ElementAt(0).login, lstCompany.ElementAt(0).codigo);
                    string buscarPeriodo = bllComp.buscarPeriodo();
                    if (buscarPeriodo != "") {
                        MessageBox.Show(buscarPeriodo, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else 
            {
                pass =bllPrin.Encriptar(txtpasswC.Text, "sae");
                company = bllComp.buscar(txtcompania.Text, pass);

                if (company == null)
                {
                    MessageBox.Show("Compañia o contraseña invalido, Verifique ", "SAE Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcompania.Focus();
                    return false;
                }
                else
                {
                    bllPrin.iniciarUsuario(txtusuario.Text, rol);
                    bllPrin.iniciarCompany(company.login, company.codigo);
                    string buscarPeriodo = bllComp.buscarPeriodo();
                    if (buscarPeriodo != "")
                    {
                        MessageBox.Show(buscarPeriodo, "SAE Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return true;            
            
        }
       
        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { 
                SendKeys.Send("{TAB}");
            }
        }

        private void txtpasswC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter){
                btnEntrar_Click(null, null);
            }
        }
        
        #region Controlar Uso de Password Char .. Ocultar Contraseña.
        private void txtclaveUsua_LostFocus(object sender, EventArgs e)
        {
            if (txtclaveUsua.Text == "" )
            {
                txtclaveUsua.UseSystemPasswordChar = false;
                txtclaveUsua.Text = "Clave Usuario";
            }
        }

        private void txtclaveUsua_GotFocus(object sender, EventArgs e)
        {            
            txtclaveUsua.UseSystemPasswordChar = true;            
        }

        private void txtpasswC_LostFocus(object sender, EventArgs e)
        {
            if (txtpasswC.Text == "")
            {
                txtpasswC.UseSystemPasswordChar = false;
                txtpasswC.Text = "Clave Compañia";
            }
        }

        private void txtpasswC_GotFocus(object sender, EventArgs e)
        {           
            txtpasswC.UseSystemPasswordChar = true;            
        }

       
        
        #endregion              

        private void FrmLogin_Load(object sender, EventArgs e) {

            // Leer Si existen datos de Acceso
            string datoArc = "";
            string ruta ="C:\\ActFI\\datos.txt";
            if (System.IO.File.Exists(ruta)){
                datoArc = System.IO.File.ReadAllText(ruta);
            }

            if (!string.IsNullOrWhiteSpace(datoArc)) { 
                string[] datos = datoArc.Split(' ');
                txtusuario.Text = bllPrin.desencriptar(datos[0], "sae2015");
                txtclaveUsua.Text = bllPrin.desencriptar(datos[1], "sae2015");
                this.btnEntrar_Click(null, null);
            }
            // Agregar Eventros a Controles 
            this.txtclaveUsua.LostFocus += new EventHandler(this.txtclaveUsua_LostFocus);
            this.txtclaveUsua.GotFocus += new EventHandler(this.txtclaveUsua_GotFocus);
            this.txtpasswC.LostFocus += new EventHandler(this.txtpasswC_LostFocus);
            this.txtpasswC.GotFocus += new EventHandler(this.txtpasswC_GotFocus);           
        }

    }
}
