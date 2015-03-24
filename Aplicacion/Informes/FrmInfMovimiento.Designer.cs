namespace Aplicacion.Informes
{
    partial class FrmInfMovimiento
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblGenerar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboFinal = new System.Windows.Forms.ComboBox();
            this.cboInicial = new System.Windows.Forms.ComboBox();
            this.txtCodActivo = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtYear2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAunico = new System.Windows.Forms.RadioButton();
            this.rbAtodos = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.rbDocUnico = new System.Windows.Forms.RadioButton();
            this.rbDoctodos = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.rbDocumentos = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
          
            // 
            // lblGenerar
            // 
            this.lblGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerar.ForeColor = System.Drawing.Color.White;
            this.lblGenerar.Image = global::Aplicacion.Properties.Resources.pdf;
            this.lblGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGenerar.Location = new System.Drawing.Point(180, 0);
            this.lblGenerar.Margin = new System.Windows.Forms.Padding(180, 0, 3, 0);
            this.lblGenerar.Name = "lblGenerar";
            this.lblGenerar.Size = new System.Drawing.Size(70, 64);
            this.lblGenerar.TabIndex = 1;
            this.lblGenerar.Text = "&Generar";
            this.lblGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGenerar, "Generar Informe");
            this.lblGenerar.Click += new System.EventHandler(this.lblGenerar_Click);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(268, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(70, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(504, 5);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 231;
            this.btnExit.Text = "X";
            this.toolTip1.SetToolTip(this.btnExit, "ESC");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboFinal
            // 
            this.cboFinal.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFinal.FormattingEnabled = true;
            this.cboFinal.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboFinal.Location = new System.Drawing.Point(374, 38);
            this.cboFinal.Name = "cboFinal";
            this.cboFinal.Size = new System.Drawing.Size(59, 28);
            this.cboFinal.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboFinal, "Seleccione Rango Final");            
            this.cboFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // cboInicial
            // 
            this.cboInicial.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInicial.FormattingEnabled = true;
            this.cboInicial.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboInicial.Location = new System.Drawing.Point(147, 38);
            this.cboInicial.Name = "cboInicial";
            this.cboInicial.Size = new System.Drawing.Size(59, 28);
            this.cboInicial.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cboInicial, "Seleccione Rango Inicial");
            this.cboInicial.SelectedIndexChanged += new System.EventHandler(this.cboInicial_SelectedIndexChanged);
            this.cboInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // txtCodActivo
            // 
            this.txtCodActivo.Enabled = false;
            this.txtCodActivo.Location = new System.Drawing.Point(147, 66);
            this.txtCodActivo.Name = "txtCodActivo";
            this.txtCodActivo.Size = new System.Drawing.Size(132, 29);
            this.txtCodActivo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtCodActivo, "Ingrese el Codigo del Activo");            
            this.txtCodActivo.DoubleClick += new System.EventHandler(this.txtCodActivo_DoubleClick);
            // 
            // cboTipo
            // 
            this.cboTipo.Enabled = false;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(145, 60);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(46, 30);
            this.cboTipo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cboTipo, "Seleccione un Tipo de Documento");
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            this.cboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboFinal);
            this.groupBox2.Controls.Add(this.txtYear2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboInicial);
            this.groupBox2.Controls.Add(this.txtYear1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox2.Location = new System.Drawing.Point(10, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 83);
            this.groupBox2.TabIndex = 235;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango de Periodos";            
            // 
            // txtYear2
            // 
            this.txtYear2.Enabled = false;
            this.txtYear2.Location = new System.Drawing.Point(436, 38);
            this.txtYear2.Name = "txtYear2";
            this.txtYear2.Size = new System.Drawing.Size(61, 29);
            this.txtYear2.TabIndex = 5;
          
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(325, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Final";            
            // 
            // txtYear1
            // 
            this.txtYear1.Enabled = false;
            this.txtYear1.Location = new System.Drawing.Point(209, 38);
            this.txtYear1.Name = "txtYear1";
            this.txtYear1.Size = new System.Drawing.Size(61, 29);
            this.txtYear1.TabIndex = 2;
          
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(89, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicial";
           
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblGenerar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 407);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(529, 66);
            this.FlowLayoutPanel1.TabIndex = 234;

            // 
            // rbAunico
            // 
            this.rbAunico.AutoSize = true;
            this.rbAunico.ForeColor = System.Drawing.Color.Black;
            this.rbAunico.Location = new System.Drawing.Point(19, 67);
            this.rbAunico.Name = "rbAunico";
            this.rbAunico.Size = new System.Drawing.Size(100, 26);
            this.rbAunico.TabIndex = 1;
            this.rbAunico.Text = "Un Activo";
            this.rbAunico.UseVisualStyleBackColor = true;
            this.rbAunico.CheckedChanged += new System.EventHandler(this.rbAunico_CheckedChanged);
            // 
            // rbAtodos
            // 
            this.rbAtodos.AutoSize = true;
            this.rbAtodos.Checked = true;
            this.rbAtodos.ForeColor = System.Drawing.Color.Black;
            this.rbAtodos.Location = new System.Drawing.Point(19, 33);
            this.rbAtodos.Name = "rbAtodos";
            this.rbAtodos.Size = new System.Drawing.Size(75, 26);
            this.rbAtodos.TabIndex = 0;
            this.rbAtodos.TabStop = true;
            this.rbAtodos.Text = "Todos";
            this.rbAtodos.UseVisualStyleBackColor = true;
         
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodActivo);
            this.groupBox1.Controls.Add(this.rbAunico);
            this.groupBox1.Controls.Add(this.rbAtodos);
            this.groupBox1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox1.Location = new System.Drawing.Point(10, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 108);
            this.groupBox1.TabIndex = 233;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione Activo";
            
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 473);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(529, 2);
            this.lblMargenInf.TabIndex = 232;
          
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(529, 45);
            this.lblTituloPrinc.TabIndex = 230;
            this.lblTituloPrinc.Text = " SAE  >> Informe de Movimientos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;        
            this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
            this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
            this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(531, 2);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 473);
            this.lblMargenIzq.TabIndex = 229;
         
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 2);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 473);
            this.lblMargenDer.TabIndex = 228;         
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(0, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(533, 2);
            this.lblMargenTop.TabIndex = 227;         
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboMostrar);
            this.groupBox3.Controls.Add(this.cboTipo);
            this.groupBox3.Controls.Add(this.rbDocUnico);
            this.groupBox3.Controls.Add(this.rbDoctodos);
            this.groupBox3.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 97);
            this.groupBox3.TabIndex = 236;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccione Documento";          
            // 
            // cboMostrar
            // 
            this.cboMostrar.BackColor = System.Drawing.Color.White;
            this.cboMostrar.Enabled = false;
            this.cboMostrar.FormattingEnabled = true;
            this.cboMostrar.Location = new System.Drawing.Point(196, 60);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(299, 30);
            this.cboMostrar.TabIndex = 3;         
            // 
            // rbDocUnico
            // 
            this.rbDocUnico.AutoSize = true;
            this.rbDocUnico.ForeColor = System.Drawing.Color.Black;
            this.rbDocUnico.Location = new System.Drawing.Point(19, 62);
            this.rbDocUnico.Name = "rbDocUnico";
            this.rbDocUnico.Size = new System.Drawing.Size(123, 26);
            this.rbDocUnico.TabIndex = 1;
            this.rbDocUnico.Text = "Un solo Tipo";
            this.rbDocUnico.UseVisualStyleBackColor = true;
            this.rbDocUnico.CheckedChanged += new System.EventHandler(this.rbDocUnico_CheckedChanged);
            // 
            // rbDoctodos
            // 
            this.rbDoctodos.AutoSize = true;
            this.rbDoctodos.Checked = true;
            this.rbDoctodos.ForeColor = System.Drawing.Color.Black;
            this.rbDoctodos.Location = new System.Drawing.Point(19, 29);
            this.rbDoctodos.Name = "rbDoctodos";
            this.rbDoctodos.Size = new System.Drawing.Size(75, 26);
            this.rbDoctodos.TabIndex = 0;
            this.rbDoctodos.TabStop = true;
            this.rbDoctodos.Text = "Todos";
            this.rbDoctodos.UseVisualStyleBackColor = true;
            this.rbDoctodos.CheckedChanged += new System.EventHandler(this.rbDoctodos_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbActivo);
            this.groupBox4.Controls.Add(this.rbDocumentos);
            this.groupBox4.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox4.Location = new System.Drawing.Point(8, 344);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(513, 57);
            this.groupBox4.TabIndex = 237;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Agrupar Por";           
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.ForeColor = System.Drawing.Color.Black;
            this.rbActivo.Location = new System.Drawing.Point(331, 22);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(82, 26);
            this.rbActivo.TabIndex = 0;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activos";
            this.rbActivo.UseVisualStyleBackColor = true;         
            // 
            // rbDocumentos
            // 
            this.rbDocumentos.AutoSize = true;
            this.rbDocumentos.Checked = true;
            this.rbDocumentos.ForeColor = System.Drawing.Color.Black;
            this.rbDocumentos.Location = new System.Drawing.Point(149, 22);
            this.rbDocumentos.Name = "rbDocumentos";
            this.rbDocumentos.Size = new System.Drawing.Size(126, 26);
            this.rbDocumentos.TabIndex = 0;
            this.rbDocumentos.TabStop = true;
            this.rbDocumentos.Text = "Documentos";
            this.rbDocumentos.UseVisualStyleBackColor = true;           
            // 
            // FrmInfMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(533, 475);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenTop);
            this.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmInfMovimiento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInfMantenimiento";
            this.Load += new System.EventHandler(this.FrmInfMantenimiento_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblGenerar;
        private System.Windows.Forms.Label lblSalir;
        internal System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.TextBox txtCodActivo;
        private System.Windows.Forms.RadioButton rbAunico;
        private System.Windows.Forms.RadioButton rbAtodos;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label lblMargenInf;
        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.Label lblMargenIzq;
        internal System.Windows.Forms.Label lblMargenDer;
        internal System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbDocUnico;
        private System.Windows.Forms.RadioButton rbDoctodos;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFinal;
        private System.Windows.Forms.TextBox txtYear2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboInicial;
        private System.Windows.Forms.TextBox txtYear1;
        private System.Windows.Forms.ComboBox cboMostrar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbDocumentos;
        private System.Windows.Forms.RadioButton rbActivo;

    }
}