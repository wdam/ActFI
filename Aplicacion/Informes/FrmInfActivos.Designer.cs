namespace Aplicacion.Informes
{
    partial class FrmInfActivos
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.gbActivo = new System.Windows.Forms.GroupBox();
            this.txtNomActivo = new System.Windows.Forms.TextBox();
            this.txtCodActivo = new System.Windows.Forms.TextBox();
            this.rbUnico = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGenerar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPropiedad = new System.Windows.Forms.ComboBox();
            this.gbResponsable = new System.Windows.Forms.GroupBox();
            this.txtNomResp = new System.Windows.Forms.TextBox();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.rbRUno = new System.Windows.Forms.RadioButton();
            this.rbRTodos = new System.Windows.Forms.RadioButton();
            this.gbCentro = new System.Windows.Forms.GroupBox();
            this.txtCCosto = new System.Windows.Forms.TextBox();
            this.txtCentro = new System.Windows.Forms.TextBox();
            this.rbCUno = new System.Windows.Forms.RadioButton();
            this.rbCTodos = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboAgrupar = new System.Windows.Forms.ComboBox();
            this.gbActivo.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbResponsable.SuspendLayout();
            this.gbCentro.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(506, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 169;
            this.btnExit.Text = "X";
            this.toolTip1.SetToolTip(this.btnExit, "ESC");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(533, 45);
            this.lblTituloPrinc.TabIndex = 168;
            this.lblTituloPrinc.Text = " SAE  >> Informe de Activos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(535, 2);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 502);
            this.lblMargenIzq.TabIndex = 167;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 2);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 502);
            this.lblMargenDer.TabIndex = 166;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(0, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(537, 2);
            this.lblMargenTop.TabIndex = 165;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 502);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(533, 2);
            this.lblMargenInf.TabIndex = 170;
            // 
            // gbActivo
            // 
            this.gbActivo.Controls.Add(this.txtNomActivo);
            this.gbActivo.Controls.Add(this.txtCodActivo);
            this.gbActivo.Controls.Add(this.rbUnico);
            this.gbActivo.Controls.Add(this.rbTodos);
            this.gbActivo.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.gbActivo.Location = new System.Drawing.Point(10, 50);
            this.gbActivo.Name = "gbActivo";
            this.gbActivo.Size = new System.Drawing.Size(517, 95);
            this.gbActivo.TabIndex = 171;
            this.gbActivo.TabStop = false;
            this.gbActivo.Text = "Seleccione Activo";
            // 
            // txtNomActivo
            // 
            this.txtNomActivo.Enabled = false;
            this.txtNomActivo.Location = new System.Drawing.Point(172, 57);
            this.txtNomActivo.Name = "txtNomActivo";
            this.txtNomActivo.Size = new System.Drawing.Size(275, 29);
            this.txtNomActivo.TabIndex = 2;
            // 
            // txtCodActivo
            // 
            this.txtCodActivo.Enabled = false;
            this.txtCodActivo.Location = new System.Drawing.Point(34, 57);
            this.txtCodActivo.Name = "txtCodActivo";
            this.txtCodActivo.Size = new System.Drawing.Size(132, 29);
            this.txtCodActivo.TabIndex = 2;
            this.txtCodActivo.DoubleClick += new System.EventHandler(this.txtCodActivo_DoubleClick);
            // 
            // rbUnico
            // 
            this.rbUnico.AutoSize = true;
            this.rbUnico.ForeColor = System.Drawing.Color.Black;
            this.rbUnico.Location = new System.Drawing.Point(34, 28);
            this.rbUnico.Name = "rbUnico";
            this.rbUnico.Size = new System.Drawing.Size(100, 26);
            this.rbUnico.TabIndex = 1;
            this.rbUnico.Text = "Un Activo";
            this.rbUnico.UseVisualStyleBackColor = true;
            this.rbUnico.CheckedChanged += new System.EventHandler(this.rbUnico_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.ForeColor = System.Drawing.Color.Black;
            this.rbTodos.Location = new System.Drawing.Point(224, 28);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(75, 26);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblGenerar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 436);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(533, 66);
            this.FlowLayoutPanel1.TabIndex = 225;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPropiedad);
            this.groupBox2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox2.Location = new System.Drawing.Point(11, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 80);
            this.groupBox2.TabIndex = 236;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propiedad";
            // 
            // cboPropiedad
            // 
            this.cboPropiedad.FormattingEnabled = true;
            this.cboPropiedad.Items.AddRange(new object[] {
            "TODOS",
            "PROPIO",
            "ARRENDADO",
            "LEASING"});
            this.cboPropiedad.Location = new System.Drawing.Point(33, 38);
            this.cboPropiedad.Name = "cboPropiedad";
            this.cboPropiedad.Size = new System.Drawing.Size(189, 30);
            this.cboPropiedad.TabIndex = 1;
            this.cboPropiedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPropiedad_KeyPress);
            // 
            // gbResponsable
            // 
            this.gbResponsable.Controls.Add(this.txtNomResp);
            this.gbResponsable.Controls.Add(this.txtResponsable);
            this.gbResponsable.Controls.Add(this.rbRUno);
            this.gbResponsable.Controls.Add(this.rbRTodos);
            this.gbResponsable.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResponsable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.gbResponsable.Location = new System.Drawing.Point(10, 147);
            this.gbResponsable.Name = "gbResponsable";
            this.gbResponsable.Size = new System.Drawing.Size(517, 97);
            this.gbResponsable.TabIndex = 237;
            this.gbResponsable.TabStop = false;
            this.gbResponsable.Text = "Seleccione Responsable";
            // 
            // txtNomResp
            // 
            this.txtNomResp.Enabled = false;
            this.txtNomResp.Location = new System.Drawing.Point(172, 59);
            this.txtNomResp.Name = "txtNomResp";
            this.txtNomResp.Size = new System.Drawing.Size(275, 29);
            this.txtNomResp.TabIndex = 3;
            // 
            // txtResponsable
            // 
            this.txtResponsable.Enabled = false;
            this.txtResponsable.Location = new System.Drawing.Point(34, 59);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(132, 29);
            this.txtResponsable.TabIndex = 2;
            this.txtResponsable.DoubleClick += new System.EventHandler(this.txtResponsable_DoubleClick);
            // 
            // rbRUno
            // 
            this.rbRUno.AutoSize = true;
            this.rbRUno.ForeColor = System.Drawing.Color.Black;
            this.rbRUno.Location = new System.Drawing.Point(34, 28);
            this.rbRUno.Name = "rbRUno";
            this.rbRUno.Size = new System.Drawing.Size(151, 26);
            this.rbRUno.TabIndex = 1;
            this.rbRUno.Text = "Un Responsable";
            this.rbRUno.UseVisualStyleBackColor = true;
            this.rbRUno.CheckedChanged += new System.EventHandler(this.rbRUno_CheckedChanged);
            // 
            // rbRTodos
            // 
            this.rbRTodos.AutoSize = true;
            this.rbRTodos.Checked = true;
            this.rbRTodos.ForeColor = System.Drawing.Color.Black;
            this.rbRTodos.Location = new System.Drawing.Point(224, 28);
            this.rbRTodos.Name = "rbRTodos";
            this.rbRTodos.Size = new System.Drawing.Size(75, 26);
            this.rbRTodos.TabIndex = 0;
            this.rbRTodos.TabStop = true;
            this.rbRTodos.Text = "Todos";
            this.rbRTodos.UseVisualStyleBackColor = true;
            // 
            // gbCentro
            // 
            this.gbCentro.Controls.Add(this.txtCCosto);
            this.gbCentro.Controls.Add(this.txtCentro);
            this.gbCentro.Controls.Add(this.rbCUno);
            this.gbCentro.Controls.Add(this.rbCTodos);
            this.gbCentro.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCentro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.gbCentro.Location = new System.Drawing.Point(10, 246);
            this.gbCentro.Name = "gbCentro";
            this.gbCentro.Size = new System.Drawing.Size(517, 97);
            this.gbCentro.TabIndex = 238;
            this.gbCentro.TabStop = false;
            this.gbCentro.Text = "Seleccione Centro de Costo";
            // 
            // txtCCosto
            // 
            this.txtCCosto.Enabled = false;
            this.txtCCosto.Location = new System.Drawing.Point(172, 58);
            this.txtCCosto.Name = "txtCCosto";
            this.txtCCosto.Size = new System.Drawing.Size(275, 29);
            this.txtCCosto.TabIndex = 3;
            // 
            // txtCentro
            // 
            this.txtCentro.Enabled = false;
            this.txtCentro.Location = new System.Drawing.Point(34, 58);
            this.txtCentro.Name = "txtCentro";
            this.txtCentro.Size = new System.Drawing.Size(132, 29);
            this.txtCentro.TabIndex = 2;
            this.txtCentro.DoubleClick += new System.EventHandler(this.txtCentro_DoubleClick);
            // 
            // rbCUno
            // 
            this.rbCUno.AutoSize = true;
            this.rbCUno.ForeColor = System.Drawing.Color.Black;
            this.rbCUno.Location = new System.Drawing.Point(34, 28);
            this.rbCUno.Name = "rbCUno";
            this.rbCUno.Size = new System.Drawing.Size(106, 26);
            this.rbCUno.TabIndex = 1;
            this.rbCUno.Text = "Un Centro";
            this.rbCUno.UseVisualStyleBackColor = true;
            this.rbCUno.CheckedChanged += new System.EventHandler(this.rbCUno_CheckedChanged);
            // 
            // rbCTodos
            // 
            this.rbCTodos.AutoSize = true;
            this.rbCTodos.Checked = true;
            this.rbCTodos.ForeColor = System.Drawing.Color.Black;
            this.rbCTodos.Location = new System.Drawing.Point(224, 28);
            this.rbCTodos.Name = "rbCTodos";
            this.rbCTodos.Size = new System.Drawing.Size(75, 26);
            this.rbCTodos.TabIndex = 0;
            this.rbCTodos.TabStop = true;
            this.rbCTodos.Text = "Todos";
            this.rbCTodos.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboAgrupar);
            this.groupBox5.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox5.Location = new System.Drawing.Point(272, 349);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 80);
            this.groupBox5.TabIndex = 239;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Agrupar Por";
            // 
            // cboAgrupar
            // 
            this.cboAgrupar.FormattingEnabled = true;
            this.cboAgrupar.Items.AddRange(new object[] {
            "NO AGRUPAR",
            "RESPONSABLE",
            "C. COSTO"});
            this.cboAgrupar.Location = new System.Drawing.Point(43, 35);
            this.cboAgrupar.Name = "cboAgrupar";
            this.cboAgrupar.Size = new System.Drawing.Size(171, 30);
            this.cboAgrupar.TabIndex = 1;
            this.cboAgrupar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPropiedad_KeyPress);
            // 
            // FrmInfActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(537, 504);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gbCentro);
            this.Controls.Add(this.gbResponsable);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.gbActivo);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInfActivos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInfActivos";
            this.Load += new System.EventHandler(this.FrmInfActivos_Load);
            this.gbActivo.ResumeLayout(false);
            this.gbActivo.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbResponsable.ResumeLayout(false);
            this.gbResponsable.PerformLayout();
            this.gbCentro.ResumeLayout(false);
            this.gbCentro.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.Label lblMargenIzq;
        internal System.Windows.Forms.Label lblMargenDer;
        internal System.Windows.Forms.Label lblMargenTop;
        internal System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.GroupBox gbActivo;
        private System.Windows.Forms.RadioButton rbUnico;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.TextBox txtCodActivo;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblGenerar;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbResponsable;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.RadioButton rbRUno;
        private System.Windows.Forms.RadioButton rbRTodos;
        private System.Windows.Forms.GroupBox gbCentro;
        private System.Windows.Forms.TextBox txtCentro;
        private System.Windows.Forms.RadioButton rbCUno;
        private System.Windows.Forms.RadioButton rbCTodos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboPropiedad;
        private System.Windows.Forms.ComboBox cboAgrupar;
        private System.Windows.Forms.TextBox txtNomActivo;
        private System.Windows.Forms.TextBox txtNomResp;
        private System.Windows.Forms.TextBox txtCCosto;
    }
}