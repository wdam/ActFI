namespace Aplicacion.Inventario
{
    partial class FrmParametros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParametros));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.txtctaActivo = new System.Windows.Forms.TextBox();
            this.txtctaDepMonetaria = new System.Windows.Forms.TextBox();
            this.txtctaGastos = new System.Windows.Forms.TextBox();
            this.txtctaDepreciacion = new System.Windows.Forms.TextBox();
            this.txtctaMonetaria = new System.Windows.Forms.TextBox();
            this.msjError = new System.Windows.Forms.ErrorProvider(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.msjError)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(695, 4);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 202;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(719, 45);
            this.lblTituloPrinc.TabIndex = 201;
            this.lblTituloPrinc.Text = " SAE >> Parametros Generales";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 450);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(719, 2);
            this.lblMargenInf.TabIndex = 200;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(721, 2);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 450);
            this.lblMargenIzq.TabIndex = 199;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 2);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 450);
            this.lblMargenDer.TabIndex = 198;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(0, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(723, 2);
            this.lblMargenTop.TabIndex = 197;
            // 
            // lblSalir
            // 
            this.lblSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(368, 1);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 66);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir ");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            this.lblSalir.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblSalir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblGuardar
            // 
            this.lblGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuardar.ForeColor = System.Drawing.Color.White;
            this.lblGuardar.Image = global::Aplicacion.Properties.Resources.guardar;
            this.lblGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGuardar.Location = new System.Drawing.Point(292, 1);
            this.lblGuardar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(58, 66);
            this.lblGuardar.TabIndex = 1;
            this.lblGuardar.Text = "&Guardar";
            this.lblGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGuardar, "Guardar Registro");
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lblGuardar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // txtctaActivo
            // 
            this.txtctaActivo.Location = new System.Drawing.Point(89, 28);
            this.txtctaActivo.MaxLength = 9;
            this.txtctaActivo.Name = "txtctaActivo";
            this.txtctaActivo.Size = new System.Drawing.Size(175, 29);
            this.txtctaActivo.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtctaActivo, "Cuenta de Activo");
            this.txtctaActivo.DoubleClick += new System.EventHandler(this.seleccionar);
            // 
            // txtctaDepMonetaria
            // 
            this.txtctaDepMonetaria.Location = new System.Drawing.Point(306, 100);
            this.txtctaDepMonetaria.MaxLength = 9;
            this.txtctaDepMonetaria.Name = "txtctaDepMonetaria";
            this.txtctaDepMonetaria.Size = new System.Drawing.Size(175, 29);
            this.txtctaDepMonetaria.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtctaDepMonetaria, "Cuenta Monetaria (Depreciación)");
            this.txtctaDepMonetaria.DoubleClick += new System.EventHandler(this.seleccionar);
            // 
            // txtctaGastos
            // 
            this.txtctaGastos.Location = new System.Drawing.Point(89, 65);
            this.txtctaGastos.MaxLength = 9;
            this.txtctaGastos.Name = "txtctaGastos";
            this.txtctaGastos.Size = new System.Drawing.Size(175, 29);
            this.txtctaGastos.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtctaGastos, "Cuenta de Gastos");
            this.txtctaGastos.DoubleClick += new System.EventHandler(this.seleccionar);
            // 
            // txtctaDepreciacion
            // 
            this.txtctaDepreciacion.Location = new System.Drawing.Point(501, 28);
            this.txtctaDepreciacion.MaxLength = 9;
            this.txtctaDepreciacion.Name = "txtctaDepreciacion";
            this.txtctaDepreciacion.Size = new System.Drawing.Size(175, 29);
            this.txtctaDepreciacion.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtctaDepreciacion, "Cuenta de Depreciación");
            this.txtctaDepreciacion.DoubleClick += new System.EventHandler(this.seleccionar);
            // 
            // txtctaMonetaria
            // 
            this.txtctaMonetaria.Location = new System.Drawing.Point(501, 65);
            this.txtctaMonetaria.MaxLength = 9;
            this.txtctaMonetaria.Name = "txtctaMonetaria";
            this.txtctaMonetaria.Size = new System.Drawing.Size(175, 29);
            this.txtctaMonetaria.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtctaMonetaria, "Cuenta Corrección Monetaria");
            this.txtctaMonetaria.DoubleClick += new System.EventHandler(this.seleccionar);
            // 
            // msjError
            // 
            this.msjError.ContainerControl = this;
            this.msjError.Icon = ((System.Drawing.Icon)(resources.GetObject("msjError.Icon")));
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtctaActivo);
            this.GroupBox1.Controls.Add(this.Label21);
            this.GroupBox1.Controls.Add(this.Label22);
            this.GroupBox1.Controls.Add(this.txtctaDepMonetaria);
            this.GroupBox1.Controls.Add(this.txtctaGastos);
            this.GroupBox1.Controls.Add(this.txtctaDepreciacion);
            this.GroupBox1.Controls.Add(this.txtctaMonetaria);
            this.GroupBox1.Controls.Add(this.Label23);
            this.GroupBox1.Controls.Add(this.Label24);
            this.GroupBox1.Controls.Add(this.Label25);
            this.GroupBox1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.GroupBox1.Location = new System.Drawing.Point(12, 67);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(699, 161);
            this.GroupBox1.TabIndex = 203;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Cuentas Contable";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(181, 138);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(225, 18);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Doble Click Para Seleccionar Cuentas";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(22, 31);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(56, 22);
            this.Label21.TabIndex = 6;
            this.Label21.Text = "Activo";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(388, 31);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(110, 22);
            this.Label22.TabIndex = 7;
            this.Label22.Text = "Depreciación";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(331, 68);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(167, 22);
            this.Label23.TabIndex = 8;
            this.Label23.Text = "Correción Monetaria";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(23, 68);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(63, 22);
            this.Label24.TabIndex = 9;
            this.Label24.Text = "Gastos";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(23, 103);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(281, 22);
            this.Label25.TabIndex = 10;
            this.Label25.Text = "Correción Monetaria (Depreciación)";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Panel1.Controls.Add(this.lblSalir);
            this.Panel1.Controls.Add(this.lblGuardar);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(2, 382);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(719, 68);
            this.Panel1.TabIndex = 204;
            // 
            // FrmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(723, 452);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmParametros";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmParametros";
            this.Load += new System.EventHandler(this.FrmParametros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msjError)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.Label lblMargenInf;
        internal System.Windows.Forms.Label lblMargenIzq;
        internal System.Windows.Forms.Label lblMargenDer;
        internal System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider msjError;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtctaActivo;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox txtctaDepMonetaria;
        internal System.Windows.Forms.TextBox txtctaGastos;
        internal System.Windows.Forms.TextBox txtctaDepreciacion;
        internal System.Windows.Forms.TextBox txtctaMonetaria;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblSalir;
        internal System.Windows.Forms.Label lblGuardar;
    }
}