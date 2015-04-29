namespace Aplicacion.Principal
{
    partial class MDIPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIPrincipal));
            this.SpContenedor = new System.Windows.Forms.SplitContainer();
            this.menuPrincipal = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInventario = new System.Windows.Forms.Label();
            this.lblProcesos = new System.Windows.Forms.Label();
            this.lblInformes = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.lblCerrar = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCambiarPer = new System.Windows.Forms.ToolStripMenuItem();
            this.AcercadeoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCompania = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPeriodo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.definirDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SpContenedor)).BeginInit();
            this.SpContenedor.Panel1.SuspendLayout();
            this.SpContenedor.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.barraEstado.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpContenedor
            // 
            this.SpContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpContenedor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SpContenedor.IsSplitterFixed = true;
            this.SpContenedor.Location = new System.Drawing.Point(5, 39);
            this.SpContenedor.Name = "SpContenedor";
            // 
            // SpContenedor.Panel1
            // 
            this.SpContenedor.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(111)))), ((int)(((byte)(193)))));
            this.SpContenedor.Panel1.Controls.Add(this.menuPrincipal);
            // 
            // SpContenedor.Panel2
            // 
            this.SpContenedor.Panel2.BackColor = System.Drawing.Color.White;
            this.SpContenedor.Panel2.BackgroundImage = global::Aplicacion.Properties.Resources.letra;
            this.SpContenedor.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SpContenedor.Size = new System.Drawing.Size(995, 502);
            this.SpContenedor.SplitterDistance = 120;
            this.SpContenedor.SplitterWidth = 1;
            this.SpContenedor.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.menuPrincipal.Controls.Add(this.lblInventario);
            this.menuPrincipal.Controls.Add(this.lblProcesos);
            this.menuPrincipal.Controls.Add(this.lblInformes);
            this.menuPrincipal.Controls.Add(this.lblSalir);
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Margin = new System.Windows.Forms.Padding(5);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.menuPrincipal.Size = new System.Drawing.Size(118, 500);
            this.menuPrincipal.TabIndex = 0;
            // 
            // lblInventario
            // 
            this.lblInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventario.ForeColor = System.Drawing.Color.White;
            this.lblInventario.Image = global::Aplicacion.Properties.Resources.inventario;
            this.lblInventario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInventario.Location = new System.Drawing.Point(11, 11);
            this.lblInventario.Margin = new System.Windows.Forms.Padding(8);
            this.lblInventario.Name = "lblInventario";
            this.lblInventario.Size = new System.Drawing.Size(100, 70);
            this.lblInventario.TabIndex = 2;
            this.lblInventario.Text = "Activos";
            this.lblInventario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.lblInventario, "Activos");
            this.lblInventario.Click += new System.EventHandler(this.lblInventario_Click);
            this.lblInventario.MouseLeave += new System.EventHandler(this.lblInventario_MouseLeave);
            this.lblInventario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblInventario_MouseMove);
            // 
            // lblProcesos
            // 
            this.lblProcesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProcesos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesos.ForeColor = System.Drawing.Color.White;
            this.lblProcesos.Image = global::Aplicacion.Properties.Resources.proceso;
            this.lblProcesos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblProcesos.Location = new System.Drawing.Point(11, 97);
            this.lblProcesos.Margin = new System.Windows.Forms.Padding(8);
            this.lblProcesos.Name = "lblProcesos";
            this.lblProcesos.Size = new System.Drawing.Size(100, 70);
            this.lblProcesos.TabIndex = 1;
            this.lblProcesos.Text = "Procesos";
            this.lblProcesos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.lblProcesos, "Procesos");
            this.lblProcesos.Click += new System.EventHandler(this.lblProcesos_Click);
            this.lblProcesos.MouseLeave += new System.EventHandler(this.lblProcesos_MouseLeave);
            this.lblProcesos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblProcesos_MouseMove);
            // 
            // lblInformes
            // 
            this.lblInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInformes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformes.ForeColor = System.Drawing.Color.White;
            this.lblInformes.Image = global::Aplicacion.Properties.Resources.informes;
            this.lblInformes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInformes.Location = new System.Drawing.Point(11, 183);
            this.lblInformes.Margin = new System.Windows.Forms.Padding(8);
            this.lblInformes.Name = "lblInformes";
            this.lblInformes.Size = new System.Drawing.Size(100, 70);
            this.lblInformes.TabIndex = 3;
            this.lblInformes.Text = "Informes";
            this.lblInformes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.lblInformes, "Informes");
            this.lblInformes.Click += new System.EventHandler(this.lblInformes_Click);
            this.lblInformes.MouseLeave += new System.EventHandler(this.lblInformes_MouseLeave);
            this.lblInformes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblInformes_MouseMove);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.Salir;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(11, 269);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(8);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(100, 70);
            this.lblSalir.TabIndex = 4;
            this.lblSalir.Text = "Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            this.lblSalir.MouseLeave += new System.EventHandler(this.lblSalir_MouseLeave);
            this.lblSalir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSalir_MouseMove);
            // 
            // barraEstado
            // 
            this.barraEstado.BackColor = System.Drawing.Color.White;
            this.barraEstado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCerrar,
            this.ToolStripStatusLabel1,
            this.lblUsuario});
            this.barraEstado.Location = new System.Drawing.Point(5, 541);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barraEstado.Size = new System.Drawing.Size(995, 31);
            this.barraEstado.TabIndex = 1;
            this.barraEstado.Text = "StatusStrip1";
            // 
            // lblCerrar
            // 
            this.lblCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCerrar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.lblCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCerrar.Size = new System.Drawing.Size(147, 29);
            this.lblCerrar.Text = "Cerrar Sesion";
            this.lblCerrar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblCerrar.ButtonClick += new System.EventHandler(this.lblCerrar_ButtonClick);
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(67, 26);
            this.ToolStripStatusLabel1.Text = "           ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.lblUsuario.Image = global::Aplicacion.Properties.Resources.user;
            this.lblUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuario.Size = new System.Drawing.Size(303, 26);
            this.lblUsuario.Text = "Usuario: Daniel Arias Martinez";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.Color.White;
            this.MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeneralesToolStripMenuItem,
            this.AcercadeoolStripMenuItem,
            this.lblCompania,
            this.lblPeriodo});
            this.MenuStrip1.Location = new System.Drawing.Point(5, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.MenuStrip1.Size = new System.Drawing.Size(995, 39);
            this.MenuStrip1.TabIndex = 3;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // GeneralesToolStripMenuItem
            // 
            this.GeneralesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCambiarPer,
            this.definirDocumentosToolStripMenuItem});
            this.GeneralesToolStripMenuItem.Name = "GeneralesToolStripMenuItem";
            this.GeneralesToolStripMenuItem.Size = new System.Drawing.Size(108, 29);
            this.GeneralesToolStripMenuItem.Text = "Generales";
            // 
            // tsmCambiarPer
            // 
            this.tsmCambiarPer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsmCambiarPer.Image = global::Aplicacion.Properties.Resources.calendar;
            this.tsmCambiarPer.Name = "tsmCambiarPer";
            this.tsmCambiarPer.Size = new System.Drawing.Size(252, 30);
            this.tsmCambiarPer.Text = "Cambiar &Periodo";
            this.tsmCambiarPer.Click += new System.EventHandler(this.tsmCambiarPer_Click);
            // 
            // AcercadeoolStripMenuItem
            // 
            this.AcercadeoolStripMenuItem.Name = "AcercadeoolStripMenuItem";
            this.AcercadeoolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.AcercadeoolStripMenuItem.Text = "Acerca de ";
            // 
            // lblCompania
            // 
            this.lblCompania.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCompania.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.lblCompania.Image = global::Aplicacion.Properties.Resources.house;
            this.lblCompania.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblCompania.Name = "lblCompania";
            this.lblCompania.Size = new System.Drawing.Size(233, 29);
            this.lblCompania.Text = "CSI Informatica LTDA";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.lblPeriodo.Image = global::Aplicacion.Properties.Resources.calendar;
            this.lblPeriodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPeriodo.Size = new System.Drawing.Size(128, 29);
            this.lblPeriodo.Text = "12 / 2014";
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.InitialDelay = 300;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // definirDocumentosToolStripMenuItem
            // 
            this.definirDocumentosToolStripMenuItem.Name = "definirDocumentosToolStripMenuItem";
            this.definirDocumentosToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.definirDocumentosToolStripMenuItem.Text = "Definir &Documentos";
            this.definirDocumentosToolStripMenuItem.Click += new System.EventHandler(this.definirDocumentosToolStripMenuItem_Click);
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.ClientSize = new System.Drawing.Size(1000, 577);
            this.Controls.Add(this.SpContenedor);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.barraEstado);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 620);
            this.Name = "MDIPrincipal";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAE -  Activos Fijos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MDIPrincipal_Load);
            this.SpContenedor.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpContenedor)).EndInit();
            this.SpContenedor.ResumeLayout(false);
            this.menuPrincipal.ResumeLayout(false);
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.SplitContainer SpContenedor;
        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripSplitButton lblCerrar;
        private System.Windows.Forms.FlowLayoutPanel menuPrincipal;
        private System.Windows.Forms.Label lblProcesos;
        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.Label lblInventario;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.Label lblInformes;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.ToolStripMenuItem GeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AcercadeoolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem lblCompania;
        private System.Windows.Forms.ToolStripMenuItem lblPeriodo;
        private System.Windows.Forms.ToolStripMenuItem tsmCambiarPer;
        private System.Windows.Forms.ToolStripMenuItem definirDocumentosToolStripMenuItem;
    }
}



